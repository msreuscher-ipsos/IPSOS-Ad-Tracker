Public Class UserMessage
    Private Sub UserMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMessage.Text = $"Note:{vbCrLf}{vbCrLf}You have restored an older file. In order to use this file, you must re-save this project. If you do not, the next time you open this project, it will revert to the previously saved files."
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Hide()
    End Sub
End Class
