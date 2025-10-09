Imports System.ComponentModel
Imports System.IO
Imports System.Net.Sockets
Imports System.Resources
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Xml.Serialization
Imports ExportToDIM
Imports GlobalRefs.Export
Imports Microsoft.Web.WebView2.Core
Public Class Manager


    Public IntroPage As Intro

    Dim UserName As String = ""
    Dim Password As String = ""

    Public Projects As Project
    Public ActiveProject As String

    Public Restarted As Boolean = False
    Public RestartInfo As Restart
    Public IntroReturn As Intro.IntroReturn

    Public Sub New(ByVal _Restarted As Boolean, ByVal _RestartInfo As Restart, ByRef _Intro As Intro, ByVal _IntroReturn As Intro.IntroReturn)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Restarted = _Restarted
        RestartInfo = _RestartInfo
        IntroReturn = _IntroReturn
        IntroPage = _Intro

    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles btnStaging.Click, menuStaging.Click
        StartExport(Projects)
    End Sub

    Private Sub PromoteToolStripButton_Click(sender As Object, e As EventArgs) Handles PromoteToolStripButton.Click, PromoteToolStripMenuItem.Click
        StartPromotion(Projects)
    End Sub

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim OpenFileDialog As New OpenFileDialog

        If Restarted = False Then
            If IntroReturn = Intro.IntroReturn.NewFile Then
            End If
        End If

        OpenFileDialog.RestoreDirectory = True
        OpenFileDialog.Filter = "X-Track XML File|*.xml"


        If IntroPage.DialogResult = DialogResult.OK Then

            UserName = IntroPage.txtUserName.Text
            Password = IntroPage.txtPassword.Text

            Dim UserDict As New Dictionary(Of String, String)
            UserDict.Add(UserName, UserName)
            If Restarted Then
                If My.Computer.FileSystem.FileExists("C:\Ad Loader\Users.resx") Then
                    Using UserResx As New ResXResourceReader("C:\Ad Loader\Users.resx")
                        For Each entry As DictionaryEntry In UserResx
                            If UserName <> entry.Value Then
                                UserDict.Add(entry.Value, entry.Value)
                            End If
                        Next
                    End Using
                Else
                    My.Computer.FileSystem.WriteAllText("C:\Ad Loader\Users.resx", "", False)
                End If
                Using UserResx As New ResXResourceWriter("C:\Ad Loader\Users.resx")
                    For Each U As KeyValuePair(Of String, String) In UserDict
                        UserResx.AddResource(UserDict(U.Key), UserDict(U.Key))
                    Next
                End Using

                Dim SIDDict As New Dictionary(Of String, String)
                SIDDict.Add(IntroPage.txtSID.Text, IntroPage.txtSID.Text)
                If My.Computer.FileSystem.FileExists("C:\Ad Loader\SIDs.resx") Then
                    Using SIDResx As New ResXResourceReader("C:\Ad Loader\SIDs.resx")
                        For Each entry As DictionaryEntry In SIDResx
                            If IntroPage.txtSID.Text <> entry.Value Then
                                SIDDict.Add(entry.Value, entry.Value)
                            End If
                        Next
                    End Using
                Else
                    My.Computer.FileSystem.WriteAllText("C:\Ad Loader\SIDs.resx", "", False)
                End If
                Using SIDResx As New ResXResourceWriter("C:\Ad Loader\SIDs.resx")
                    For Each S As KeyValuePair(Of String, String) In SIDDict
                        SIDResx.AddResource(SIDDict(S.Key), SIDDict(S.Key))
                    Next
                End Using

            End If

            If Intro.chkXML.Checked Then
                If OpenFileDialog.ShowDialog(IntroPage) = System.Windows.Forms.DialogResult.OK Then
                    Projects = New Project(Me, OpenFileDialog.FileName, UserName, Password, IntroPage.txtSID.Text, Intro)
                Else
                    End
                End If
            Else
                Projects = New Project(Me, OpenFileDialog.FileName, UserName, Password, IntroPage.txtSID.Text, Intro, Restarted)
            End If

            'If Not My.Computer.FileSystem.FileExists("C:\Ad Loader\LastInstance.resx") Then My.Computer.FileSystem.WriteAllText("C:\Ad Loader\LastInstance.resx", "", False)
            Dim RestartInfo As New Restart(IntroPage.txtUserName.Text, IntroPage.txtPassword.Text, IntroPage.txtSID.Text, IntroPage.boxServer.Text, False, IntroPage.chkSaveInfo.Checked)
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(Restart))
            Dim RestartResx As StreamWriter = New StreamWriter("C:\Ad Loader\LastInstance.resx")
            mySerializer.Serialize(RestartResx, RestartInfo)
            RestartResx.Close()

        Else
            End
        End If
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Dim ManageLists As New RestoreList(Projects)
        If ManageLists.ShowDialog() = DialogResult.OK Then
            Me.SuspendLayout()
            For Each List As KeyValuePair(Of String, CheckBox) In ManageLists.Lists
                Select Case ManageLists.Lists(List.Key).Checked
                    Case True
                        If Not Projects.Lists.ContainsKey(List.Key) Then
                            Projects.Lists.Add(List.Key, Projects.ExcludeLists(List.Key))
                            Projects.FlowLayout.Controls.Add(Projects.Lists(List.Key).Tool)
                            Projects.ListPanel.Controls.Add(Projects.Lists(List.Key))
                            Projects.ExcludeLists.Remove(List.Key)
                        End If
                    Case False
                        If Not Projects.ExcludeLists.ContainsKey(List.Key) Then
                            Projects.ExcludeLists.Add(List.Key, Projects.Lists(List.Key))
                            Projects.FlowLayout.Controls.Remove(Projects.Lists(List.Key).Tool)
                            Projects.ListPanel.Controls.Remove(Projects.Lists(List.Key))
                            Projects.Lists.Remove(List.Key)
                        End If
                End Select
            Next
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim About As New AboutBox
        About.ShowDialog()
    End Sub

    Private Sub RestoreFromBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreFromBackupToolStripMenuItem.Click

        Dim RestoreFiles As New Restore(Projects)
        RestoreFiles.ShowDialog()

    End Sub

    Private Sub ExportDIMRoutingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportDIMRoutingToolStripMenuItem.Click
        SaveFile.ShowDialog()
        If SaveFile.FileName <> "" Then
            ExportToDIM.ExportToDIM.Export(Projects, SaveFile.FileName)
        End If
    End Sub

    Private Sub SetMaxCategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetMaxCategoriesToolStripMenuItem.Click
        Dim SetMax As New MaxCategories
        SetMax.numMax.Value = Projects.MaximumCategories
        SetMax.ShowDialog()

        If SetMax.DialogResult = DialogResult.OK Then
            Projects.MaximumCategories = SetMax.numMax.Value
        End If
    End Sub
End Class

Public Class DataProtectionSample
    ' Create byte array for additional entropy when using Protect method.
    Private Shared s_additionalEntropy As Byte() = {10, 7, 20, 25}


    Public Shared Sub Main()
        ' Create a simple byte array containing data to be encrypted.
        Dim secret As Byte() = {0, 1, 2, 3, 4, 1, 2, 3, 4}

        'Encrypt the data.
        Dim encryptedSecret As Byte() = Protect(secret)
        Console.WriteLine("The encrypted byte array is:")
        PrintValues(encryptedSecret)

        ' Decrypt the data and store in a byte array.
        Dim originalData As Byte() = Unprotect(encryptedSecret)
        Console.WriteLine("{0}The original data is:", Environment.NewLine)
        PrintValues(originalData)

    End Sub


    Public Shared Function Protect(ByVal data() As Byte) As Byte()
        Try
            ' Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
            '  only by the same current user.
            Return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser)
        Catch e As CryptographicException
            Console.WriteLine("Data was not encrypted. An error occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function


    Public Shared Function Unprotect(ByVal data() As Byte) As Byte()
        Try
            'Decrypt the data using DataProtectionScope.CurrentUser.
            Try
                Return ProtectedData.Unprotect(data, s_additionalEntropy, DataProtectionScope.CurrentUser)
            Catch ex As Exception
                Return Nothing
            End Try
        Catch e As CryptographicException
            Console.WriteLine("Data was not decrypted. An error occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function

    Public Shared Function PrintValues(ByVal myArr() As [Byte]) As String
        Dim ReturnString = ""
        Dim i As [Byte]
        For Each i In myArr
            ReturnString &= i
        Next i
        Return ReturnString
    End Function

End Class