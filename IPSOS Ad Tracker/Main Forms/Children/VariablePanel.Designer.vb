<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VariablePanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Panel = New Panel()
        chkCultured = New CheckBox()
        lblRemove = New LinkLabel()
        boxType = New ComboBox()
        txtName = New TextBox()
        Panel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel
        ' 
        Panel.Controls.Add(chkCultured)
        Panel.Controls.Add(lblRemove)
        Panel.Controls.Add(boxType)
        Panel.Controls.Add(txtName)
        Panel.Dock = DockStyle.Fill
        Panel.Location = New Point(0, 0)
        Panel.Name = "Panel"
        Panel.Size = New Size(560, 50)
        Panel.TabIndex = 0
        ' 
        ' chkCultured
        ' 
        chkCultured.AutoSize = True
        chkCultured.Checked = True
        chkCultured.CheckState = CheckState.Checked
        chkCultured.Location = New Point(429, 16)
        chkCultured.Name = "chkCultured"
        chkCultured.Size = New Size(18, 17)
        chkCultured.TabIndex = 5
        chkCultured.UseVisualStyleBackColor = True
        ' 
        ' lblRemove
        ' 
        lblRemove.AutoSize = True
        lblRemove.Location = New Point(490, 16)
        lblRemove.Name = "lblRemove"
        lblRemove.Size = New Size(63, 20)
        lblRemove.TabIndex = 4
        lblRemove.TabStop = True
        lblRemove.Text = "Remove"
        ' 
        ' boxType
        ' 
        boxType.FormattingEnabled = True
        boxType.Items.AddRange(New Object() {"Text", "Number", "Yes/No", "Date/Time"})
        boxType.Location = New Point(214, 10)
        boxType.Name = "boxType"
        boxType.Size = New Size(151, 28)
        boxType.TabIndex = 2
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(3, 10)
        txtName.Name = "txtName"
        txtName.Size = New Size(190, 27)
        txtName.TabIndex = 1
        ' 
        ' VariablePanel
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel)
        Name = "VariablePanel"
        Size = New Size(560, 50)
        Panel.ResumeLayout(False)
        Panel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents lblRemove As LinkLabel
    Friend WithEvents boxType As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents chkCultured As CheckBox

End Class
