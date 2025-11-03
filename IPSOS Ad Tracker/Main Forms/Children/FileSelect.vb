Imports System.Net.Http.Headers
Imports System.Windows.Forms
Imports GlobalRefs.GlobalFunctions

Public Class FileSelect

    Public ParentAd As Ad
    Public Type As MediaType
    Dim Language As String
    Public Sub New(ByRef _Parent As Ad, ByVal _Language As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ParentAd = _Parent
        Language = _Language

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Public Files As New Dictionary(Of String, File)
    Private Sub lblAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblAdd.LinkClicked

        OpenFile = New OpenFileDialog
        With OpenFile
            .Multiselect = True
            .Filter = "All Files|*.*|JPG Image File|*.jpg|PNG Image File|*.png|GIF Image File|*.gif|MOV File|*.mov|MP4 File|*.mp4|MP3 File|*.mp3"
            .FilterIndex = 0
            .FileName = ""
        End With
        If OpenFile.ShowDialog() = DialogResult.OK Then
            For Each file As String In OpenFile.FileNames
                Dim NewFile As New File(Me, file, Language)
                Files.Add(file, NewFile)
            Next
            ParentAd.ParentListManager.hasChanges.Checked = True
        End If

    End Sub

    Public ReadOnly Property GetFiles As String
        Get
            GetFiles = ""
            For Each F As KeyValuePair(Of String, File) In Files
                If LCase(Mid(Files(F.Key).File, 1, 4)) <> "http" Then
                    GetFiles &= ConvertToHTML(Files(F.Key)) & ","
                Else
                    GetFiles &= Files(F.Key).File & ","
                End If
            Next
            If Len(GetFiles) > 0 Then GetFiles = Mid(GetFiles, 1, Len(GetFiles) - 1)
            Return GetFiles
        End Get
    End Property

    Function ConvertToHTML(ByVal FileName As File) As String

        Dim TimeStamp As String = $"{Replace(Replace(Replace(DateTime.UtcNow, "/", "."), ":", "."), " ", ".")}"

        Dim TmpFileName As String = Mid(FileName.File, FileName.File.LastIndexOf("\") + 2)
        Dim Ext As String = Mid(FileName.File, FileName.File.LastIndexOf(".") + 2)
        TmpFileName = TmpFileName.Replace(Ext, "_" & TimeStamp & "." & Ext)

        Dim TmpProject As Project = ParentAd.ParentListManager.ParentProject
        Dim TmpListManager As ListManager = ParentAd.ParentListManager

        If Trim(Language) <> "" Then
            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName) <> True Then My.Computer.FileSystem.CopyFile(FileName.File, "C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName)
            Return "https://cdn.ipsosinteractive.com/projects/" & TmpProject.SID & "/Ads/" & TmpListManager.Name & "/" & Language & "/" & TmpFileName
        Else
            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & TmpFileName) <> True Then My.Computer.FileSystem.CopyFile(FileName.File, "C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName)
            Return "https://cdn.ipsosinteractive.com/projects/" & TmpProject.SID & "/Ads/" & TmpListManager.Name & "/" & TmpFileName
        End If

    End Function

    Public Sub Add(ByVal File As String)
        Dim NewFile As New File(Me, File, Language)
        Files.Add(File, NewFile)
    End Sub

End Class


Public Class File

    Dim ParentFileSelect As FileSelect

    Dim Panel As New Panel
    Public File As String
    Dim ImageBox As New PictureBox
    Dim lblFile As New Label
    Public Language As String
    WithEvents lblRemove As New LinkLabel
    Sub New(ByRef _Parent As FileSelect, ByVal _File As String, ByVal _Language As String)

        ParentFileSelect = _Parent
        File = _File
        Language = _Language

        ParentFileSelect.MediaPanel.Controls.Add(Panel)
        With Panel
            .Width = 310
            .Height = 120
            .BorderStyle = BorderStyle.FixedSingle
        End With

        If My.Computer.FileSystem.FileExists(File) Then
            Try
                ImageBox.Image = Image.FromFile(File)
                ImageBox.Text = File
                Dim bmp As New Bitmap(File)
                ImageBox.Width = bmp.Width + 20
                ImageBox.Height = bmp.Height + 20
            Catch ex As Exception
                With lblFile
                    .Text = File
                    .AutoSize = True
                    .Location = New Point(10, 10)
                End With
                Panel.Height = 40
                Panel.Controls.Add(lblFile)
            Finally
                Panel.Controls.Add(ImageBox)
            End Try
        Else
            Try
                Dim img_url As String = File ' Replace with the actual image URL
                img_url = Replace(Replace(img_url, "//", "/"), "https:/cdn.ipsosinteractive.com/projects/", "file:///C:/Ad%20Loader/")
                Dim req As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(img_url), Net.HttpWebRequest)
                Dim res As Net.HttpWebResponse = DirectCast(req.GetResponse, Net.HttpWebResponse)
                Dim img As System.Drawing.Image = New System.Drawing.Bitmap(res.GetResponseStream)
                ImageBox.Width = img.Width + 20
                ImageBox.Height = img.Height + 20
                res.Close()
                ImageBox.Image = img
                ImageBox.Text = img_url
            Catch ex As Exception
                With lblFile
                    .Text = File
                    .AutoSize = True
                    .Location = New Point(10, 10)
                End With
                Panel.Height = 40
                Panel.Controls.Add(lblFile)
            Finally
                Panel.Controls.Add(ImageBox)
            End Try
        End If

        With ImageBox
            .Location = New Point(10, 10)
        End With

        With lblRemove
            .BringToFront()
            .Text = "Remove"
            .AutoSize = True
            .Location = New Point(Panel.Width - .Width - 3, (Panel.Height / 2) - (.Height / 2))
        End With
        Panel.Controls.Add(lblRemove)
        lblRemove.BringToFront()

    End Sub

    Private Sub lblRemove_Click(sender As Object, e As MouseEventArgs) Handles lblRemove.Click
        ParentFileSelect.MediaPanel.Controls.Remove(Panel)
        ParentFileSelect.Files.Remove(File)
        ParentFileSelect.ParentAd.ParentListManager.hasChanges.Checked = True
    End Sub

End Class