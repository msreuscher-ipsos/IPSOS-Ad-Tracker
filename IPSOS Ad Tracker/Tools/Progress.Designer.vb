<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Progress
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
        txtProgress = New RichTextBox()
        SuspendLayout()
        ' 
        ' txtProgress
        ' 
        txtProgress.BackColor = SystemColors.Control
        txtProgress.BorderStyle = BorderStyle.None
        txtProgress.Location = New Point(12, 12)
        txtProgress.Name = "txtProgress"
        txtProgress.Size = New Size(648, 257)
        txtProgress.TabIndex = 0
        txtProgress.Text = ""
        ' 
        ' Progress
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(672, 281)
        ControlBox = False
        Controls.Add(txtProgress)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "Progress"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        TopMost = True
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtProgress As RichTextBox
End Class
