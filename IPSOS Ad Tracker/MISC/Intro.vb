Imports System.IO
Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports Markdig

Public Class Intro

    Public Intro As IntroReturn = IntroReturn.Existing
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Intro = IntroReturn.NewFile
        Close()
    End Sub

    Private Sub btnExisting_Click(sender As Object, e As EventArgs) Handles btnExisting.Click
        Intro = IntroReturn.Existing
        Close()
    End Sub

    Private Sub btnGuide_Click(sender As Object, e As EventArgs) Handles btnGuide.Click
        Guide.ShowDialog()
    End Sub

    Private Sub Intro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Visible = False
        Dim Manager As New Manager(Restarted, RestartInfo, Intro)
        Manager.Show()
    End Sub

    Public Restarted As Boolean = False
    Public RestartInfo As Restart
    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\LastInstance.resx") Then
            Dim mySerializer As New XmlSerializer(GetType(Restart))
            Using myFileStream As New FileStream("C:\Ad Loader\LastInstance.resx", FileMode.Open)
                RestartInfo = CType(mySerializer.Deserialize(myFileStream), Restart)
            End Using
            Restarted = RestartInfo.Restarted
        End If

        If Restarted Then
            Intro = IntroReturn.Existing
            Close()
        End If

    End Sub

    Public Enum IntroReturn
        NewFile = 1
        Existing = 2
    End Enum
End Class

