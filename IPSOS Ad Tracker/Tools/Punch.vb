Public Class Punch

    Dim ParentScreen As PunchScreen
    Dim ParentPanel As FlowLayoutPanel
    Dim Index As Integer
    Public Sub New(ByRef _Parent As PunchScreen, ByVal _Index As Integer, ByRef Panel As FlowLayoutPanel)

        ' This call is required by the designer.
        InitializeComponent()

        If Not _Parent Is Nothing Then _Parent.lnkBatch.Visible = False
        ' Add any initialization after the InitializeComponent() call.
        If Not _Parent Is Nothing Then ParentPanel = Panel
        If Not Panel Is Nothing Then
            ParentScreen = _Parent
            Panel.Controls.Add(Me)
        End If
        Index = _Index

    End Sub

    Public Sub UpdatePunch(ByRef _Parent As PunchScreen, ByRef Panel As FlowLayoutPanel)
        ParentPanel = Panel
        ParentScreen = _Parent
        Panel.Controls.Add(Me)
    End Sub

    Private Sub lblRemove_Click(sender As Object, e As EventArgs) Handles lblRemove.Click
        ParentPanel.Controls.Remove(Me)
        ParentScreen.Punches.Remove(Index)
        Me.Dispose()
    End Sub

    Private Sub txtValue_MouseClick(sender As Object, e As MouseEventArgs) Handles txtValue.MouseClick
        txtValue.BackColor = SystemColors.Window
    End Sub

    Private Sub txtValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValue.KeyPress
        If (Char.IsLetter(e.KeyChar) Or
           e.KeyChar = "_") Or e.KeyChar = ControlChars.Back Or
           (Char.IsDigit(e.KeyChar) And Len(txtValue.Text) > 0) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtValue_Leave(sender As Object, e As EventArgs) Handles txtValue.Leave
        If Len(txtValue.Text) > 0 Then
            If Mid(txtValue.Text, 1, 1) Like "[0-9]" Then
                txtValue.Focus()
            End If
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return txtLabel.Text ' This will be displayed in the ComboBox
    End Function

End Class
