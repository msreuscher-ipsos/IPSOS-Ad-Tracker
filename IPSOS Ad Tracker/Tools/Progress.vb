Imports System.Windows.Controls

Public Class Progress

    Sub Add(ByVal Txt As String)

        Me.SuspendLayout()
        txtProgress.AppendText(Txt & vbCrLf)
        txtProgress.SelectionStart = txtProgress.TextLength
        txtProgress.ScrollToCaret()
        Me.ResumeLayout()

    End Sub

End Class