Imports System.IO
Imports System.IO.Packaging
Imports System.Threading
Imports System.Windows.Automation
Imports System.Windows.Diagnostics
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ApplicationServices
Imports WinSCP

Public Class SFTPWinSCP

    Dim sessionOptions As New SessionOptions
    Dim timeOut As Boolean = 0

    Private Sub TimeOutError(ByRef Study As Project, ByVal ex As Exception)

        If timeOut >= 3 Then
            PBar.Add($"Error: Closing Program.")
            Thread.Sleep(5000)
            End
        End If

        Dim Login As New LoginForm(Study.UserName, Study.Password, Study.IntroPage.boxServer.Text, Study.SID, Study.IntroPage.chkSaveInfo.Checked)
        If InStr(ex.Message, "Connection failed.") > 0 Then
            With Login
                .Text = "Connection Failed. Verify your VPN Connect."
                .boxServer.Enabled = True
                .txtSID.Enabled = False
                .txtUserName.Enabled = False
                .txtPassword.Enabled = False
                .ShowDialog(Study.ParentManager)
            End With
        ElseIf InStr(ex.Message, "Authentication failed.") > 0 Then
            With Login
                .Text = "Authenication Failed. VerifyResult your Username And Password."
                .boxServer.Enabled = False
                .txtSID.Enabled = False
                .txtUserName.Enabled = True
                .txtPassword.Enabled = True
                .ShowDialog(Study.ParentManager)
            End With
        Else
            With Login
                .Text = "Connection Failed. Please verify all your information."
                .boxServer.Enabled = True
                .txtSID.Enabled = False
                .txtUserName.Enabled = True
                .txtPassword.Enabled = True
                .ShowDialog(Study.ParentManager)
            End With
        End If

        If Study.IntroPage.DialogResult = DialogResult.Cancel Then End

        Study.UserName = Study.IntroPage.txtUserName.Text
        Study.Password = Study.IntroPage.txtPassword.Text

        Study.IntroPage.txtUserName.Text = Login.txtUserName.Text
        Study.IntroPage.txtPassword.Text = Login.txtPassword.Text
        Study.IntroPage.boxServer.Text = Login.boxServer.SelectedItem
        Study.IntroPage.chkSaveInfo.Checked = Login.chkSaveInfo.Checked

        If Login.chkSaveInfo.Checked Then
            Dim RestartInfo As New Restart(Study.IntroPage.txtUserName.Text,
                                       Study.IntroPage.txtPassword.Text,
                                       Study.IntroPage.txtSID.Text,
                                       Study.IntroPage.boxServer.SelectedItem, False,
                                       Study.IntroPage.chkSaveInfo.Checked)
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(Restart))
            Dim RestartResx As StreamWriter = New StreamWriter("C:\Ad Loader\LastInstance.resx")
            mySerializer.Serialize(RestartResx, RestartInfo)
            RestartResx.Close()
        End If

        Session(Study.IntroPage.txtUserName.Text, Study.IntroPage.txtPassword.Text, Study.IntroPage.boxServer.SelectedItem)

    End Sub
    Public Sub Session(ByVal User As String, ByVal Password As String, ByVal Host As String)
        ' Setup session options
        With sessionOptions
            .Protocol = Protocol.Ftp
            .HostName = Host
            .UserName = "IPSOSGROUP\" & User
            .Password = Password
            .FtpSecure = FtpSecure.Explicit
            '.SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxx..."
        End With

    End Sub

    Public Function DirectoryExists(ByRef Study As Project, ByVal remotePath As String) As Boolean
        Try
            timeOut += 1
            Using session As New Session
                session.Open(sessionOptions)
                DirectoryExists = session.FileExists(remotePath)
                session.Close()
            End Using
            timeOut = 0
            Return DirectoryExists
        Catch ex As Exception
            TimeOutError(Study, ex)
            DirectoryExists(Study, remotePath)
        End Try
    End Function

    Public Sub CreateDirectory(ByRef Study As Project, ByVal remotePath As String)
        Try
            timeOut += 1
            Using session As New Session
                session.Open(sessionOptions)
                session.CreateDirectory(remotePath)
                session.Close()
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            CreateDirectory(Study, remotePath)
        End Try
    End Sub

    Dim PBar As Progress
    Public Sub Sync(ByRef Study As Project, ByRef _PBar As Progress, ByVal mode As SynchronizationMode, ByVal localPath As String, ByVal remotePath As String)

        Try
            timeOut += 1
            PBar = _PBar

            Using session As New Session
                ' Will continuously report progress of synchronization
                AddHandler session.FileTransferred, AddressOf FileTransferred

                ' Connect
                session.Open(sessionOptions)

                ' Synchronize files
                Dim synchronizationResult As SynchronizationResult
                synchronizationResult = session.SynchronizeDirectories(mode, localPath, remotePath, False)

                ' Throw on any error
                synchronizationResult.Check()
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            Sync(Study, _PBar, mode, localPath, remotePath)
        End Try

    End Sub

    Private Sub FileTransferred(sender As Object, e As TransferEventArgs)

        If e.Error Is Nothing Then
            PBar.Add($"Syncing {e.FileName} succeeded")
        Else
            PBar.Add($"Syncing {e.FileName} failed")
        End If

    End Sub
    Public Function ListDirectory(ByRef Study As Project, ByVal FTPDirectory As String) As RemoteDirectoryInfo
        Try
            timeOut += 1
            Using session As New Session
                session.Open(sessionOptions)
                Dim directory As RemoteDirectoryInfo = session.ListDirectory(FTPDirectory)
                session.Close()
                Return directory
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            Return ListDirectory(Study, FTPDirectory)
        End Try
    End Function

    Public Sub Upload(ByRef Study As Project, ByVal FTPFile As String, ByVal LocalFile As String)
        Try
            timeOut += 1
            Using session As New Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                transferResult = session.PutFiles(LocalFile, FTPFile, False, transferOptions)

                ' Throw on any error
                transferResult.Check()

                ' Print results
                For Each transfer In transferResult.Transfers
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName)
                Next

                session.Close()
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            Upload(Study, FTPFile, LocalFile)
        End Try

    End Sub

    Public Function Download(ByRef Study As Project, ByVal FTPFile As String, ByVal LocalFile As String) As Boolean
        Try
            timeOut += 1
            Using session As New Session
                ' Connect
                session.Open(sessionOptions)
                If session.FileExists(FTPFile) Then
                    session.GetFiles(FTPFile, LocalFile).Check()
                    Return True
                Else
                    Return False
                End If
                session.Close()
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            Return Download(Study, FTPFile, LocalFile)
        End Try
    End Function


    Public Function Copy(ByRef Study As Project, ByVal FTPTo As String, ByVal FTPFrom As String) As Boolean
        Try
            timeOut += 1
            Using session As New Session
                ' Connect
                session.Open(sessionOptions)
                If session.FileExists(FTPFrom) Then
                    session.ExecuteCommand($"cp {FTPFrom} {FTPTo}")
                    Return True
                Else
                    Return False
                End If
                session.Close()
            End Using
            timeOut = 0
        Catch ex As Exception
            TimeOutError(Study, ex)
            Return Copy(Study, FTPTo, FTPFrom)
        End Try

    End Function


End Class
