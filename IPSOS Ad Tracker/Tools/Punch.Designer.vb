<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Punch
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
        txtValue = New TextBox()
        txtLabel = New TextBox()
        lblRemove = New LinkLabel()
        SuspendLayout()
        ' 
        ' txtValue
        ' 
        txtValue.Location = New Point(10, 5)
        txtValue.Name = "txtValue"
        txtValue.Size = New Size(40, 27)
        txtValue.TabIndex = 0
        ' 
        ' txtLabel
        ' 
        txtLabel.Location = New Point(65, 5)
        txtLabel.Name = "txtLabel"
        txtLabel.Size = New Size(178, 27)
        txtLabel.TabIndex = 1
        ' 
        ' lblRemove
        ' 
        lblRemove.AutoSize = True
        lblRemove.Location = New Point(270, 8)
        lblRemove.Name = "lblRemove"
        lblRemove.Size = New Size(18, 20)
        lblRemove.TabIndex = 2
        lblRemove.TabStop = True
        lblRemove.Text = "X"
        ' 
        ' Punch
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblRemove)
        Controls.Add(txtLabel)
        Controls.Add(txtValue)
        Margin = New Padding(0)
        Name = "Punch"
        Size = New Size(300, 35)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtValue As TextBox
    Friend WithEvents txtLabel As TextBox
    Friend WithEvents lblRemove As LinkLabel

End Class
