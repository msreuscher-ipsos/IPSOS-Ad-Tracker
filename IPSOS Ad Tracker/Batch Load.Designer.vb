<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Batch_Load
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
        txtInput = New RichTextBox()
        txtOutput = New RichTextBox()
        lblInput = New Label()
        lblOutput = New Label()
        lblInstructions = New Label()
        btnDone = New Button()
        SuspendLayout()
        ' 
        ' txtInput
        ' 
        txtInput.BorderStyle = BorderStyle.None
        txtInput.DetectUrls = False
        txtInput.Location = New Point(12, 96)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(670, 150)
        txtInput.TabIndex = 0
        txtInput.Text = ""
        txtInput.WordWrap = False
        ' 
        ' txtOutput
        ' 
        txtOutput.BorderStyle = BorderStyle.None
        txtOutput.DetectUrls = False
        txtOutput.Location = New Point(12, 287)
        txtOutput.Name = "txtOutput"
        txtOutput.ReadOnly = True
        txtOutput.Size = New Size(670, 150)
        txtOutput.TabIndex = 1
        txtOutput.Text = ""
        txtOutput.WordWrap = False
        ' 
        ' lblInput
        ' 
        lblInput.AutoSize = True
        lblInput.Location = New Point(21, 64)
        lblInput.Name = "lblInput"
        lblInput.Size = New Size(46, 20)
        lblInput.TabIndex = 2
        lblInput.Text = "Input:"
        ' 
        ' lblOutput
        ' 
        lblOutput.AutoSize = True
        lblOutput.Location = New Point(21, 264)
        lblOutput.Name = "lblOutput"
        lblOutput.Size = New Size(58, 20)
        lblOutput.TabIndex = 3
        lblOutput.Text = "Output:"
        ' 
        ' lblInstructions
        ' 
        lblInstructions.Location = New Point(21, 9)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(661, 43)
        lblInstructions.TabIndex = 4
        lblInstructions.Text = "Insert punch values, one per line, in the Input field. Add a space after the punch value to include the label. Click ""Done"" when you are finished."
        ' 
        ' btnDone
        ' 
        btnDone.DialogResult = DialogResult.OK
        btnDone.Location = New Point(588, 443)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(94, 29)
        btnDone.TabIndex = 5
        btnDone.Text = "Done"
        btnDone.UseVisualStyleBackColor = True
        ' 
        ' Batch_Load
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(694, 483)
        Controls.Add(btnDone)
        Controls.Add(lblInstructions)
        Controls.Add(lblOutput)
        Controls.Add(lblInput)
        Controls.Add(txtOutput)
        Controls.Add(txtInput)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Batch_Load"
        ShowIcon = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Batch Load"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtInput As RichTextBox
    Friend WithEvents txtOutput As RichTextBox
    Friend WithEvents lblInput As Label
    Friend WithEvents lblOutput As Label
    Friend WithEvents lblInstructions As Label
    Friend WithEvents btnDone As Button
End Class
