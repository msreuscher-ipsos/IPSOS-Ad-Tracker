Public Class UserMessage


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblMessage.Text = $"Note:{vbCrLf}{vbCrLf}You have restored an older file. In order to use this file, you must re-save this project. If you do not, the next time you open this project, it will revert to the previously saved files."

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
