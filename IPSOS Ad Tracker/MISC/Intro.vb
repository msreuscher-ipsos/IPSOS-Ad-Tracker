Imports System.IO
Imports System.Resources
Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports Markdig
Imports Microsoft.VisualBasic.Logging

Public Class Intro

    Public Intro As IntroReturn = IntroReturn.Existing
    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXMLLoad.Click
        Me.DialogResult = DialogResult.OK
        chkXML.Checked = True
        Intro = IntroReturn.NewFile
        Close()
    End Sub

    Private Sub btnNoXML_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Me.DialogResult = DialogResult.OK
        chkXML.Checked = False
        Intro = IntroReturn.Existing
        Close()
    End Sub


    Private Sub Intro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Visible = False
        Dim Manager As New Manager(Restarted, RestartInfo, Me, Intro)
        Manager.Show()
    End Sub

    Public Restarted As Boolean = False
    Public RestartInfo As Restart

    Public chkXML As New CheckBox
    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\LastInstance.resx") Then
            Dim mySerializer As New XmlSerializer(GetType(Restart))
            Using myFileStream As New FileStream("C:\Ad Loader\LastInstance.resx", FileMode.Open)
                RestartInfo = CType(mySerializer.Deserialize(myFileStream), Restart)
            End Using
            Restarted = RestartInfo.Restarted

            txtUserName.Text = RestartInfo.Username
            txtPassword.Text = RestartInfo.GetPassword
            txtSID.Text = RestartInfo.SID
            boxServer.Text = RestartInfo.FTPServer
            chkSaveInfo.Checked = RestartInfo.SaveInfo
        End If

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\Users.resx") Then
            Dim User As New AutoCompleteStringCollection
            Using UserResx As New ResXResourceReader("C:\Ad Loader\Users.resx")
                For Each entry As DictionaryEntry In UserResx
                    User.Add(CType(entry.Value, String))
                Next
            End Using
            txtUserName.AutoCompleteCustomSource = User
            txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\SIDs.resx") Then
            Dim SIDs As New AutoCompleteStringCollection
            Using SIDResx As New ResXResourceReader("C:\Ad Loader\SIDs.resx")
                For Each entry As DictionaryEntry In SIDResx
                    SIDs.Add(CType(entry.Value, String))
                Next
            End Using
            txtSID.AutoCompleteCustomSource = SIDs
            txtSID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSID.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If

        If Restarted Then
            Intro = IntroReturn.Existing
            Close()
        End If

    End Sub

    Private Sub Intro_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        Guide.ShowDialog()
        e.Cancel = True
    End Sub

    Public Enum IntroReturn
        NewFile = 1
        Existing = 2
    End Enum
End Class

