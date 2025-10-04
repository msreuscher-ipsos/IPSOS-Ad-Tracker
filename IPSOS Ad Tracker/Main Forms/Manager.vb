Imports System.ComponentModel
Imports System.IO
Imports System.Resources
Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports ExportToDIM
Imports GlobalRefs.Export
Public Class Manager

    Dim UserName As String = ""
    Dim Password As String = ""

    Public Projects As Project
    Public ActiveProject As String

    Public Restarted As Boolean = False
    Public RestartInfo As Restart
    Public IntroReturn As Intro.IntroReturn

    Public Sub New(ByVal _Restarted As Boolean, ByVal _RestartInfo As Restart, ByVal _IntroReturn As Intro.IntroReturn)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Restarted = _Restarted
        RestartInfo = _RestartInfo
        IntroReturn = _IntroReturn

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

        Dim Login As New LoginForm(UserName, Password)
        Dim OpenFileDialog As New OpenFileDialog

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\LastInstance.resx") Then
            Using ListResx As New ResXResourceReader("C:\Ad Loader\LastInstance.resx")
                For Each entry As DictionaryEntry In ListResx
                    Dim Last As Instance = entry.Value
                    Login.txtUserName.Text = Last.User
                    Login.txtSID.Text = Last.SID
                    OpenFileDialog.FileName = Last.File
                Next
            End Using
        End If
        If Restarted Then
            Login.txtUserName.Text = RestartInfo.Username
            Login.txtSID.Text = RestartInfo.SID
            Login.boxServer.Text = RestartInfo.FTPServer
            Dim _Password As New Password
            _Password.ShowDialog()
            Login.txtPassword.Text = _Password.txtPassword.Text
            Login.DialogResult = DialogResult.OK
        Else
            If IntroReturn = Intro.IntroReturn.NewFile Then
                Login.chkXML.Checked = True
                Login.chkXML.Enabled = False
                Login.chkShowVariables.Checked = True
                Login.chkShowVariables.Enabled = False
                Login.chkCleanLocal.Enabled = False
            End If
            Login.StartPosition = FormStartPosition.CenterScreen
            Login.ShowDialog()
        End If
        OpenFileDialog.RestoreDirectory = True
        OpenFileDialog.Filter = "X-Track XML File|*.xml"


        If Login.DialogResult = DialogResult.OK Then

            UserName = Login.txtUserName.Text
            Password = Login.txtPassword.Text

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
                SIDDict.Add(Login.txtSID.Text, Login.txtSID.Text)
                If My.Computer.FileSystem.FileExists("C:\Ad Loader\SIDs.resx") Then
                    Using SIDResx As New ResXResourceReader("C:\Ad Loader\SIDs.resx")
                        For Each entry As DictionaryEntry In SIDResx
                            If Login.txtSID.Text <> entry.Value Then
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

            If Login.chkXML.Checked Then
                If OpenFileDialog.ShowDialog(Login) = System.Windows.Forms.DialogResult.OK Then
                    Projects = New Project(Me, OpenFileDialog.FileName, UserName, Password, Login.txtSID.Text, Login)
                Else
                    End
                End If
            Else
                Projects = New Project(Me, OpenFileDialog.FileName, UserName, Password, Login.txtSID.Text, Login, Restarted)
            End If

            If Restarted Then
                If Not My.Computer.FileSystem.FileExists("C:\Ad Loader\LastInstance.resx") Then My.Computer.FileSystem.WriteAllText("C:\Ad Loader\LastInstance.resx", "", False)
                Using LastResx As New ResXResourceWriter("C:\Ad Loader\LastInstance.resx")
                    LastResx.AddResource("LastInstance", New Instance(UserName, Login.txtSID.Text, OpenFileDialog.FileName))
                End Using
            End If

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

<Serializable()> Public Class Instance

    Public User As String
    Public SID As String
    Public File As String
    Sub New(ByVal _User As String, _SID As String, ByVal _File As String)
        User = _User
        SID = _SID
        File = _File
    End Sub

End Class
