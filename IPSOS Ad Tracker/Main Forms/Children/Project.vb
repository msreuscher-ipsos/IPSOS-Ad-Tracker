Imports System.Xml
Imports GlobalRefs.Export
Imports GlobalRefs.GlobalFunctions
Imports IPSOS_Ad_Tracker.Intro
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32.SafeHandles
Imports WinSCP

Public Class Project

    Public ParentManager As Manager
    Public UserName As String = ""
    Public Password As String = ""

    Public SID As String
    Public FTP As String

    Dim Title As String
    Dim WaveName As String
    Dim WaveID As String

    Public Countries As New Dictionary(Of String, Country)
    Public Lists As New Dictionary(Of String, ListManager)
    Public ExcludeLists As New Dictionary(Of String, ListManager)

    Public VariableManager As New VariableManager(Me)
    Public Variables As New Dictionary(Of Integer, VariablePanel)
    Public VariableNames As New Dictionary(Of String, Integer)
    Public CurrentIndex As Integer

    Public WithEvents VersionMajor As New NumericUpDown
    Public WithEvents VersionMinor As New NumericUpDown

    Public LoadDate As String = ""

    Dim ProjInfo As New ProjectInfo
    Public IntroPage As Intro

    Dim PBar As New Progress


    Public MaximumCategories As Integer = 1000
    Public WithEvents hasChanges As New System.Windows.Forms.CheckBox
    Public WithEvents readyForProduction As New System.Windows.Forms.CheckBox
    Dim UserMsg As New UserMessage
    Public Sub New(ByRef _Parent As Manager,
                   ByVal XMLFile As String,
                   ByVal _User As String,
                   ByVal _Pass As String,
                   ByVal _FTP As String,
                   ByVal _SID As String,
                   ByRef _Intro As Intro,
                   Optional ByVal Restarted As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        Me.MdiParent = _Parent

        PBar.StartPosition = FormStartPosition.Manual
        PBar.Location = New Point(
            _Parent.Location.X + (_Parent.Width - PBar.Width) \ 2,
            _Parent.Location.Y + (_Parent.Height - PBar.Height) \ 2)
        PBar.Show()


        IntroPage = _Intro

        If IntroPage.chkCleanLocal.Checked Then
            PBar.Add("Cleaning Local Files for " & _SID)
            CleanFiles(_SID)
        End If
        PBar.Add("Loading " & _SID)

        ' Add any initialization after the InitializeComponent() call.
        ParentManager = _Parent
        UserName = _User
        Password = _Pass
        FTP = _FTP
        SID = _SID

        CreateLocalProjectFolder(Me)

        VersionMinor.DecimalPlaces = 2

        Dim XR As New XmlDocument()
        If IntroPage.chkXML.Checked = True Then
            XR.Load(XMLFile)

            Me.Text = XR.SelectNodes("/main/ipsosfileinfo/program_name")(0).InnerText

            WaveName = XR.SelectNodes("/main/wave/name")(0).InnerText
            WaveID = XR.SelectNodes("/main/wave/identifier")(0).InnerText
        End If


        Dim projectExists As Boolean = LoadFromStaging(Restarted)

        VariableManager.StartUp(projectExists)
        If projectExists Then

            PBar.Add("Importing Version Data")
            Dim SW() As String = Split(My.Computer.FileSystem.ReadAllText($"C:\Ad Loader\{SID}\Ads\{SID}_Version.txt"), vbCrLf)
            For Each line As String In SW
                If line <> "" Then
                    Dim Tag As String = LCase(Trim(Mid(line, 1, line.IndexOf(":"))))
                    Dim Value As String = Mid(line, line.IndexOf(":") + 2)
                    Select Case Tag
                        Case "user"
                            ProjInfo.User = Trim(Value)
                        Case "staging"
                            ProjInfo.Staging = Trim(Value)
                        Case "production"
                            ProjInfo.Production = Trim(Value)
                        Case "variables"
                            ProjInfo.Variables = Split(Trim(Value), ";")
                        Case "lists"
                            ProjInfo.Lists = Split(Trim(Value), ",")
                        Case "exclude"
                            ProjInfo.Excludes = Split(Trim(Value), ",")
                        Case "max"
                            ProjInfo.Max = Trim(Value)
                    End Select
                End If
            Next

            VersionMinor.Value = ProjInfo.Staging
            VersionMajor.Value = ProjInfo.Production
            If ProjInfo.Max <> "" Then
                MaximumCategories = ProjInfo.Max
            End If
            VariableManager.ReadinCustomVariables(ProjInfo.Variables)

            If IntroPage.chkShowVariables.Checked = True Then
                PBar.Hide()
                VariableManager.ShowDialog()
                PBar.Show()
            End If
        Else
            PBar.Hide()
            VariableManager.ShowDialog()
            PBar.Show()
        End If

        VariableNames.Clear()
        For Each V As KeyValuePair(Of Integer, VariablePanel) In Variables
            VariableNames.Add(Variables(V.Key).txtName.Text, Variables(V.Key).Index)
        Next

        If IntroPage.chkXML.Checked = True Or projectExists = False Then

            PBar.Add("Reading X-Track Countries")
            For Each Node As XmlNode In XR.SelectNodes("/main/countries/country")
                Dim NewCountry As New Country(Node.Attributes("countryname").Value, Node.Attributes("code").Value)
                For Each ChildNode As XmlNode In Node.SelectSingleNode("languages")
                    NewCountry.Languages.Add(LCase(ChildNode.InnerText), LCase(ChildNode.InnerText))
                Next
                Countries.Add(Node.Attributes("code").Value, NewCountry)
            Next

            PBar.Add("Reading X-Track Lists")
            For Each Node As XmlNode In XR.SelectNodes("/main/lists/list")
                Dim ListName As String = Node.SelectSingleNode("scriptlabel").InnerText
                Dim ListLabel As String = Node.SelectSingleNode("label").InnerText
                Dim NewList As New ListManager(Me, Variables, ListName, ListLabel)
                For Each ChildNode As XmlNode In Node.SelectSingleNode("listitems")
                    Dim Label As String = ChildNode.SelectSingleNode("labels/label").Attributes("text").Value
                    Dim Value As String = ChildNode.SelectSingleNode("code").InnerText
                    Dim NewCountries As New Dictionary(Of String, Country)
                    For Each MapNode As XmlNode In ChildNode.SelectSingleNode("mapping")
                        NewCountries.Add(MapNode.Attributes("countrycode").Value, Countries(MapNode.Attributes("countrycode").Value))
                    Next
                    Dim NewAd As New Ad(NewList, NewCountries, Value, Label)
                    NewList.Ads.Add(Value, NewAd)
                Next
                NewList.Load()

                Dim Keep As Boolean = True
                For Each L As String In ProjInfo.Excludes
                    If InStr(L, ListName) > 0 Then
                        Keep = False
                        Exit For
                    End If
                Next

                If Keep Then
                    Lists.Add(ListName, NewList)
                Else
                    ExcludeLists.Add(ListName, NewList)
                End If
            Next

        End If

        If projectExists Then

            If IntroPage.chkXML.Checked = False Then CreateLists()

            For Each line As String In ProjInfo.Lists
                If Trim(line) <> "" Then
                    PBar.Add("Importing " & line)
                    If Lists.ContainsKey(Trim(line)) Then
                        Dim LatestVersion As Double = 0
                        Dim LatestLanguage As String = ""
                        Dim LatestCulturedList() As Boolean
                        Dim LatestHeaderList() As String
                        Dim LatestSW() As String

                        For Each Lang As String In My.Computer.FileSystem.GetDirectories($"C:\Ad Loader\{SID}\Ads\{Trim(line)}\", FileIO.SearchOption.SearchTopLevelOnly)

                            PBar.Add("Importing " & Lang)
                            Dim Language As String = Mid(Lang, Lang.LastIndexOf("\") + 2)
                            Dim SW() As String = Split(My.Computer.FileSystem.ReadAllText($"{Lang}\{SID}_Staging.txt"), vbCrLf)
                            Dim HeaderList() As String = Split(SW(2), vbTab)
                            Dim CulturedList(HeaderList.Count - 1) As Boolean
                            For i As Integer = 0 To UBound(HeaderList)
                                If Trim(HeaderList(i)) <> "" Then
                                    If VariableNames.ContainsKey(HeaderList(i)) Then
                                        If Variables(VariableNames(HeaderList(i))).chkCultured.Checked Then
                                            CulturedList(i) = True
                                        Else
                                            CulturedList(i) = False
                                        End If
                                    Else
                                        CulturedList(i) = False
                                    End If
                                End If
                            Next

                            If Double.Parse(SW(0)) > LatestVersion Then
                                LatestVersion = Double.Parse(SW(0))
                                LatestLanguage = Language
                                LatestCulturedList = CulturedList
                                LatestSW = SW
                                LatestHeaderList = HeaderList
                            End If

                            PBar.Add("Importing Ads for " & Lang)
                            For i As Integer = 3 To UBound(SW)
                                Dim Record() As String = Split(SW(i), vbTab)
                                Dim VCnt As Integer = 0
                                Dim Punch As String = Record(0)
                                If Lists(Trim(line)).Ads.ContainsKey(Punch) Then
                                    For j As Integer = 0 To UBound(HeaderList)
                                        If CulturedList(j) Then
                                            Dim HeaderIndex As String = Variables(VariableNames(HeaderList(j))).txtName.Text & " - " & Language
                                            Dim CellKey As String = Lists(Trim(line)).Headers(HeaderIndex).Index
                                            Dim VarType As DataType = CType(Variables(VariableNames(HeaderList(j))).boxType.SelectedItem, DataType)

                                            If (VarType.Value <> 2 And VarType.Value <> 6) Or
                                               Variables(VariableNames(LatestHeaderList(j))).PList.Punches.Count > 0 Then
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).Cell.Data = Record(j)
                                            ElseIf VarType.Value = 6 Then
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).UpdateFileCell()
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).LoadFiles(Record(j))
                                            Else
                                                If Record(j) <> "" Then
                                                    With Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown
                                                        For k As Integer = 0 To .Items.Count - 1
                                                            If CType(Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown.Items(k), Punch).txtValue.Text = Record(j) Then
                                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).Cell.Data = Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown.Items(k)
                                                                Exit For
                                                            End If
                                                        Next
                                                    End With
                                                End If
                                            End If

                                        End If
                                    Next
                                End If
                            Next
                        Next

                        PBar.Add("Importing Ads for Uncultured Data")
                        For i As Integer = 3 To UBound(LatestSW)
                            Dim Record() As String = Split(LatestSW(i), vbTab)
                            Dim VCnt As Integer = 0
                            Dim Punch As String = Record(0)
                            If Lists(Trim(line)).Ads.ContainsKey(Punch) Then
                                For j As Integer = 0 To UBound(LatestHeaderList)
                                    If LatestCulturedList(j) = False And
                                       Trim(LatestHeaderList(j)) <> "" Then
                                        If VariableNames.ContainsKey(LatestHeaderList(j)) Then

                                            Dim HeaderIndex As String = Variables(VariableNames(LatestHeaderList(j))).txtName.Text
                                            Dim CellKey As String = Lists(Trim(line)).Headers(HeaderIndex).Index
                                            Dim VarType As DataType = CType(Variables(VariableNames(LatestHeaderList(j))).boxType.SelectedItem, DataType)

                                            If (VarType.Value <> 2 Or Variables(VariableNames(LatestHeaderList(j))).PList.Punches.Count = 0) And
                                                VarType.Value <> 6 Then
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).Cell.Data = Record(j)
                                            ElseIf VarType.Value = 6 Then
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).UpdateFileCell()
                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).LoadFiles(Record(j))
                                            Else
                                                If Record(j) <> "" Then
                                                    With Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown
                                                        For k As Integer = 0 To .Items.Count - 1
                                                            If CType(Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown.Items(k), Punch).txtValue.Text = Record(j) Then
                                                                Lists(Trim(line)).Ads(Punch).Cells(CellKey).Cell.Data = Lists(Trim(line)).Ads(Punch).Cells(CellKey).dropdown.Items(k)
                                                                Exit For
                                                            End If
                                                        Next
                                                    End With
                                                End If
                                            End If

                                        End If
                                    End If
                                Next
                            End If
                        Next

                    End If
                End If
            Next
            readyForProduction.Checked = True
        End If

        'MainPanel.SplitterDistance = ListStrip.Width
        Me.WindowState = FormWindowState.Maximized

        For Each L As KeyValuePair(Of String, ListManager) In Lists
            PBar.Add($"Validating List: {Lists(L.Key).lblTitle.Text}")
            Dim CleanLists As Boolean = True
            Dim BadListMessage As String = ""
            For Each A As KeyValuePair(Of String, Ad) In Lists(L.Key).Ads
                Dim CurrentValues As String = Lists(L.Key).Ads(A.Key).Value
                If Mid(CurrentValues, 1, 1) <> "_" Then
                    CleanLists = False
                    BadListMessage &= $"Value {CurrentValues} is invalid. All values must lead with an underscore.{vbCrLf}{vbCrLf}"
                ElseIf Val(Mid(CurrentValues, 2)) > MaximumCategories Then
                    CleanLists = False
                    BadListMessage = $"Value {CurrentValues} is invalid. Please note that the current maximum number of categories currently built into the survey (MDD) is {MaximumCategories} and at least one punch exceeds that value. In order avoid errors, the current survey must be updated before continuing.{vbCrLf}{vbCrLf}"
                Else
                    For i As Integer = 2 To Len(CurrentValues)
                        If Not Mid(CurrentValues, i, 1) Like "[0-9]" Then
                            CleanLists = False
                            BadListMessage = $"{CurrentValues} is invalid. All values must be a numeric value.{vbCrLf}{vbCrLf}"
                            Exit For
                        End If
                    Next
                End If
            Next
            If CleanLists = False Then
                Lists(L.Key).InvalidateList(BadListMessage)
            End If
        Next


        PBar.Close()

        If Restarted Then
            UserMsg.Location = New Point((ParentManager.Width / 2) - (UserMsg.Width / 2), (ParentManager.Height / 2) - (UserMsg.Height / 2))
            ParentManager.Controls.Add(UserMsg)
            UserMsg.BringToFront()
            hasChanges.Checked = True
        End If

        If ParentManager.IntroReturn = IntroReturn.NewFile Then
            hasChanges.Checked = True
        End If

        Me.Show()
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Sub CreateLists()

        Dim LocalDir As String = $"C:\Ad Loader\{SID}\Ads\"
        For Each Line As String In ProjInfo.Lists
            If Line <> "" Then
                Dim ListName As String = Replace(Replace(Line, LocalDir, ""), "\", "")
                Dim NewList As New ListManager(Me, Variables, ListName, ListName)
                For Each LangDir As String In My.Computer.FileSystem.GetDirectories($"{LocalDir & Line}", FileIO.SearchOption.SearchTopLevelOnly)
                    Dim LangName As String = Replace(Replace(LangDir, Line, ""), "\", "")
                    Dim FileLines() As String = Split(My.Computer.FileSystem.ReadAllText(LangDir & "\" & SID & "_Staging.txt"), vbCrLf)
                    Dim SystemValues() As String = Split(FileLines(1), ",")
                    Dim CountryValues() As String = Split(SystemValues(3), ":")
                    NewList.lblTitle.Text = SystemValues(2)
                    Dim NewCountry As New Country(CountryValues(1), CountryValues(0))
                    NewCountry.Languages.Add(SystemValues(4), SystemValues(4))
                    Dim NewCountryDict As New Dictionary(Of String, Country)
                    NewCountryDict.Add(NewCountry.Code, NewCountry)
                    Dim Headers() As String = Split(FileLines(2))
                    For i As Integer = 3 To UBound(FileLines) - 1
                        Dim Values() As String = Split(FileLines(i), vbTab)
                        Dim NewAd As Ad
                        If Not NewList.Ads.ContainsKey(Values(0)) Then
                            NewAd = New Ad(NewList, NewCountryDict, Values(0), Values(1))
                            NewList.Ads.Add(Values(0), NewAd)
                        Else
                            NewAd = NewList.Ads(Values(0))
                        End If
                        If NewAd.Countries.ContainsKey(NewCountry.Code) Then
                            If Not NewAd.Countries(NewCountry.Code).Languages.ContainsKey(SystemValues(4)) Then
                                NewAd.Countries(NewCountry.Code).Languages.Add(SystemValues(4), SystemValues(4))
                            End If
                        Else
                            NewAd.Countries.Add(NewCountry.Code, NewCountry)
                            NewAd.Countries(NewCountry.Code).Languages.Add(SystemValues(4), SystemValues(4))
                        End If
                    Next
                Next
                NewList.Load()
                Lists.Add(NewList.Name, NewList)
            End If
        Next

    End Sub

    Sub CleanFiles(ByVal SID As String)
        If My.Computer.FileSystem.DirectoryExists($"C:\Ad Loader\{SID}\Ads\") Then
            For Each file In My.Computer.FileSystem.GetFiles($"C:\Ad Loader\{SID}\Ads\", SearchOption.SearchAllSubDirectories, "*")
                My.Computer.FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
            Next
            My.Computer.FileSystem.DeleteDirectory($"C:\Ad Loader\{SID}\Ads\", DeleteDirectoryOption.DeleteAllContents)
        Else
            My.Computer.FileSystem.CreateDirectory($"C:\Ad Loader\{SID}\Ads\")
        End If
    End Sub
    Private Sub VersionMinor_ValueChanged(sender As Object, e As EventArgs) Handles VersionMinor.ValueChanged
        Me.Text = SID & " - " & VersionMinor.Value
    End Sub
    Function LoadFromStaging(ByVal Restarted As Boolean) As Boolean

        PBar.Add("Checking FTP Site for Current Files.")

        ' ADD FTP Check, Return True if found, False if Not
        Dim SFTP As New SFTPWinSCP
        Dim FTPDirectory As String = "/projects/" & SID
        SFTP.Session(UserName, Password, IntroPage.boxServer.Text)

        If SFTP.DirectoryExists(Me, FTPDirectory & "/Ads/") Then
            If Restarted = False Then
                PBar.Add("Synchronizating Local Files with FTP Files.")
                SFTP.Sync(Me, PBar, SynchronizationMode.Local, "C:\Ad Loader\" & SID & "\Ads\", FTPDirectory & "/Ads/")
            End If
        End If

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & SID & "\Ads\" & SID & "_Version.txt") Then
            PBar.Add("Main " & SID & " File Found.")
            Return True
        Else
            PBar.Add("Main " & SID & " File Not Found.")
            Return False
        End If

    End Function

    Private Sub Project_Activated(sender As Object, e As EventArgs) Handles MyBase.Enter
        ParentManager.ActiveProject = SID
    End Sub

    Private Sub GetFileName(sender As Object, e As EventArgs) Handles hasChanges.CheckedChanged
        If hasChanges.Checked Then
            ParentManager.btnStaging.Enabled = True
            ParentManager.menuStaging.Enabled = True
        Else
            ParentManager.btnStaging.Enabled = False
            ParentManager.menuStaging.Enabled = False
            readyForProduction.Checked = True
        End If
    End Sub

    Private Sub hasChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles hasChanges.CheckedChanged
        Select Case hasChanges.Checked
            Case True
                ParentManager.btnStaging.Enabled = True
                ParentManager.menuStaging.Enabled = True
                readyForProduction.Checked = False
            Case False
                ParentManager.btnStaging.Enabled = False
                ParentManager.menuStaging.Enabled = False
                If VersionMinor.Value > 0 Then
                    readyForProduction.Checked = True
                Else
                    readyForProduction.Checked = False
                End If
        End Select
    End Sub

    Private Sub readyForProduction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles readyForProduction.CheckedChanged
        Select Case readyForProduction.Checked
            Case True
                ParentManager.PromoteToolStripButton.Enabled = True
                ParentManager.PromoteToolStripMenuItem.Enabled = True
            Case False
                ParentManager.PromoteToolStripButton.Enabled = False
                ParentManager.PromoteToolStripMenuItem.Enabled = False
        End Select
    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        lblClose.Visible = False
        lblOpen.Visible = True
        MainSplit.SplitterDistance = 25

        For Each L As KeyValuePair(Of String, ListManager) In Lists
            Lists(L.Key).Tool.Visible = False
        Next
    End Sub

    Private Sub lblOpen_Click(sender As Object, e As EventArgs) Handles lblOpen.Click
        lblClose.Visible = True
        lblOpen.Visible = False
        MainSplit.SplitterDistance = 283

        For Each L As KeyValuePair(Of String, ListManager) In Lists
            Lists(L.Key).Tool.Visible = True
        Next
    End Sub

    Private Sub lblOpenClose_MouseEnter(sender As Object, e As EventArgs) Handles lblClose.MouseEnter, lblOpen.MouseEnter
        sender.ForeColor = SystemColors.MenuHighlight
    End Sub

    Private Sub lblOpenClose_MouseLeave(sender As Object, e As EventArgs) Handles lblClose.MouseLeave, lblOpen.MouseLeave
        sender.ForeColor = SystemColors.ControlText
    End Sub
End Class


Public Class Country

    Public Name As String
    Public Code As String

    Public Languages As New Dictionary(Of String, String)
    Public Sub New(ByVal _Name As String, ByVal _Code As String)
        Name = _Name
        Code = _Code
    End Sub

End Class


Public Class ProjectInfo
    Public User As String
    Public Staging As String
    Public Production As String
    Public Variables() As String = Split("", vbCrLf)
    Public Lists() As String = Split("", vbCrLf)
    Public Excludes() As String = Split("", vbCrLf)
    Public Max As String
End Class

