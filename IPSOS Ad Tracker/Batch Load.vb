Imports System.Windows.Shapes

Public Class Batch_Load
    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        txtOutput.SuspendLayout()
        txtOutput.Text = ""
        For Each line As String In txtInput.Lines
            If Trim(line) <> "" Then
                Dim CurrentLine As String = Trim(line)
                Dim Punch As String
                Dim Label As String
                Dim i As Integer
                For i = 1 To Len(CurrentLine)
                    If Mid(CurrentLine, i, 1) = " " Then
                        Exit For
                    End If
                Next
                Punch = Trim(Mid(CurrentLine, 1, i - 1))
                Label = Trim(Mid(CurrentLine, i + 1))

                txtOutput.Text &= $"Value = {Punch}{vbTab}Label = {Label}{vbCrLf}"
            End If
        Next
        txtOutput.ResumeLayout()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class