Public Class VariablePanel

    Public Shadows Parent As Project
    Public Shadows ParentPanel As FlowLayoutPanel
    Public Variables As Dictionary(Of Integer, VariablePanel)

    Public allowChanges As Boolean
    Public Index As Integer
    Public Sub New(ByRef _Parent As Project,
                   ByRef _Panel As FlowLayoutPanel,
                   ByVal _Index As Integer,
                   ByVal _AllowChanges As Boolean,
                   ByVal _Name As String,
                   ByVal _Type As String,
                   ByVal _isCultured As Boolean,
                   ByVal Optional isNew As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Parent = _Parent
        Variables = Parent.Variables
        ParentPanel = _Panel
        Index = _Index
        allowChanges = _AllowChanges

        If allowChanges = False Then
            Me.Enabled = False
        End If

        If isNew = False Then
            txtName.Text = _Name
            boxType.Text = _Type
        End If

        Me.Controls.Add(Panel)
        ParentPanel.Controls.Add(Me)

        chkCultured.Checked = _isCultured

    End Sub

    Private Sub lblRemove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRemove.LinkClicked
        ParentPanel.Controls.Remove(Me)
        Variables.Remove(Index)
    End Sub

End Class
