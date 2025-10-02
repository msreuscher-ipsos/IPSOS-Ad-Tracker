<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaxCategories
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
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        lblNote = New Label()
        lblNoteTitle = New Label()
        numMax = New NumericUpDown()
        lblWarn = New Label()
        TableLayoutPanel1.SuspendLayout()
        CType(numMax, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(75, 292)
        TableLayoutPanel1.Margin = New Padding(4, 5, 4, 5)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(195, 45)
        TableLayoutPanel1.TabIndex = 0
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
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(101, 5)
        Cancel_Button.Margin = New Padding(4, 5, 4, 5)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(89, 35)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' lblNote
        ' 
        lblNote.Location = New Point(12, 47)
        lblNote.Name = "lblNote"
        lblNote.Size = New Size(258, 91)
        lblNote.TabIndex = 1
        lblNote.Text = "Please be sure the number set matches the categorical list within the study's MDD. If it is not, an error could occur."
        ' 
        ' lblNoteTitle
        ' 
        lblNoteTitle.AutoSize = True
        lblNoteTitle.Font = New Font("Segoe UI", 12F)
        lblNoteTitle.Location = New Point(12, 9)
        lblNoteTitle.Name = "lblNoteTitle"
        lblNoteTitle.Size = New Size(60, 28)
        lblNoteTitle.TabIndex = 2
        lblNoteTitle.Text = "Note:"
        ' 
        ' numMax
        ' 
        numMax.BorderStyle = BorderStyle.FixedSingle
        numMax.Location = New Point(12, 244)
        numMax.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numMax.Name = "numMax"
        numMax.Size = New Size(258, 27)
        numMax.TabIndex = 3
        numMax.TextAlign = HorizontalAlignment.Right
        numMax.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        ' 
        ' lblWarn
        ' 
        lblWarn.Location = New Point(12, 152)
        lblWarn.Name = "lblWarn"
        lblWarn.Size = New Size(258, 73)
        lblWarn.TabIndex = 4
        lblWarn.Text = "If changes are made here, they must be loaded to Staging in order to save them."
        ' 
        ' MaxCategories
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(286, 355)
        Controls.Add(lblWarn)
        Controls.Add(numMax)
        Controls.Add(lblNoteTitle)
        Controls.Add(lblNote)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "MaxCategories"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Set Max Categories"
        TableLayoutPanel1.ResumeLayout(False)
        CType(numMax, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblNote As Label
    Friend WithEvents lblNoteTitle As Label
    Friend WithEvents numMax As NumericUpDown
    Friend WithEvents lblWarn As Label

End Class
