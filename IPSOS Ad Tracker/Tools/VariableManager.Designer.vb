<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VariableManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        OK_Button = New Button()
        VariablePanel = New FlowLayoutPanel()
        Panel1 = New Panel()
        lblCultured = New Label()
        lblType = New Label()
        lblVariable = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Cancel_Button = New Button()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = AnchorStyles.None
        OK_Button.Location = New Point(4, 5)
        OK_Button.Margin = New Padding(4, 5, 4, 5)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(89, 35)
        OK_Button.TabIndex = 0
        OK_Button.Text = "OK"
        ' 
        ' VariablePanel
        ' 
        VariablePanel.AutoScroll = True
        VariablePanel.FlowDirection = FlowDirection.TopDown
        VariablePanel.Location = New Point(12, 71)
        VariablePanel.Name = "VariablePanel"
        VariablePanel.Size = New Size(570, 487)
        VariablePanel.TabIndex = 1
        VariablePanel.WrapContents = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblCultured)
        Panel1.Controls.Add(lblType)
        Panel1.Controls.Add(lblVariable)
        Panel1.Location = New Point(12, 18)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(570, 47)
        Panel1.TabIndex = 2
        ' 
        ' lblCultured
        ' 
        lblCultured.AutoSize = True
        lblCultured.Location = New Point(395, 18)
        lblCultured.Name = "lblCultured"
        lblCultured.Size = New Size(99, 20)
        lblCultured.TabIndex = 2
        lblCultured.Text = "Cultured Text:"
        ' 
        ' lblType
        ' 
        lblType.AutoSize = True
        lblType.Location = New Point(212, 18)
        lblType.Name = "lblType"
        lblType.Size = New Size(43, 20)
        lblType.TabIndex = 1
        lblType.Text = "Type:"
        ' 
        ' lblVariable
        ' 
        lblVariable.AutoSize = True
        lblVariable.Location = New Point(3, 18)
        lblVariable.Name = "lblVariable"
        lblVariable.Size = New Size(110, 20)
        lblVariable.TabIndex = 0
        lblVariable.Text = "Variable Name:"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(392, 566)
        TableLayoutPanel1.Margin = New Padding(4, 5, 4, 5)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(195, 45)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(101, 5)
        Cancel_Button.Margin = New Padding(4, 5, 4, 5)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(89, 35)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        Cancel_Button.Visible = False
        ' 
        ' VariableManager
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(603, 629)
        ControlBox = False
        Controls.Add(Panel1)
        Controls.Add(VariablePanel)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "VariableManager"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        TopMost = True
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents VariablePanel As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblType As Label
    Friend WithEvents lblVariable As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents lblCultured As Label

End Class
