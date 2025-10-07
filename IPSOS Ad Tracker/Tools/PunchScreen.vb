Public Class PunchScreen

    Public PCnt As Integer = 0
    Public Punches As New Dictionary(Of Integer, Punch)

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Punches.Count > 0 Then
            Me.SuspendLayout()
            Dim tmpString As New Dictionary(Of String, String)
            Dim cleanList As Boolean = True
            For Each P As KeyValuePair(Of Integer, Punch) In Punches
                With Punches(P.Key)
                    .txtValue.BackColor = SystemColors.Window
                    If Trim(.txtValue.Text) = "" Then
                        .txtValue.BackColor = Color.Red
                        cleanList = False
                    Else
                        If tmpString.ContainsKey(.txtValue.Text) Then
                            .txtValue.BackColor = Color.Red
                            cleanList = False
                        Else
                            tmpString.Add(.txtValue.Text, .txtValue.Text)
                            .txtValue.BackColor = SystemColors.Window
                        End If
                    End If
                End With
            Next
            Me.ResumeLayout()

            If cleanList = False Then
                Exit Sub
            End If

        End If

        Me.DialogResult = DialogResult.OK
        Close()
    End Sub
    Private Sub lblAddPunch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblAddPunch.LinkClicked
        PCnt += 1
        Dim NewPunch As New Punch(Me, PCnt, FlowPanel)
        Punches.Add(PCnt, NewPunch)
    End Sub
End Class
