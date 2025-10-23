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
        lnkBatch.Visible = False
    End Sub

    Private Sub lnkBatch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBatch.LinkClicked

        Me.Hide()

        Dim Batch As New Batch_Load
        Batch.ShowDialog()
        If Batch.DialogResult = DialogResult.OK Then

            For Each line As String In Batch.txtInput.Lines
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

                    PCnt += 1
                    Dim NewPunch As New Punch(Me, PCnt, FlowPanel)
                    Punches.Add(PCnt, NewPunch)
                    Punches(PCnt).txtValue.Text = Punch
                    Punches(PCnt).txtLabel.Text = Label
                    lnkBatch.Visible = False
                End If
            Next

        End If

        Me.Show()
    End Sub
End Class
