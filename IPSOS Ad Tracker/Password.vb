Imports System.Windows.Input

Public Class Password
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text.Length > 0 Then
            btnOkay.Enabled = True
        Else
            btnOkay.Enabled = False
        End If
    End Sub

    Private Sub btnOkay_Click(sender As Object, e As EventArgs) Handles btnOkay.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Password_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.DialogResult <> DialogResult.OK Then End
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOkay.PerformClick()
        End If
    End Sub
End Class