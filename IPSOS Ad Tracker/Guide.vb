Imports System.Windows.Forms
Imports Microsoft.Web.WebView2
Imports Markdig
Imports Microsoft.Web.WebView2.Core

Public Class Guide

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Async Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim markdownText As String = My.Computer.FileSystem.ReadAllText("Guide.md")
        Dim htmlContent As String = markdownText
        Await WebView.EnsureCoreWebView2Async
        WebView.NavigateToString(htmlContent)
    End Sub


End Class
