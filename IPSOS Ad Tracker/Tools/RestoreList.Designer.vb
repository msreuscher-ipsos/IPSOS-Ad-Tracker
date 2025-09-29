<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestoreList
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
        lblInfo = New Label()
        ListPanel = New FlowLayoutPanel()
        TableLayoutPanel1.SuspendLayout()
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
        TableLayoutPanel1.Location = New Point(93, 315)
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
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(12, 21)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(154, 20)
        lblInfo.TabIndex = 2
        lblInfo.Text = "Select Lists to Include:"
        ' 
        ' ListPanel
        ' 
        ListPanel.AutoScroll = True
        ListPanel.FlowDirection = FlowDirection.TopDown
        ListPanel.Location = New Point(12, 59)
        ListPanel.Name = "ListPanel"
        ListPanel.Size = New Size(280, 248)
        ListPanel.TabIndex = 3
        ListPanel.WrapContents = False
        ' 
        ' RestoreList
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(304, 378)
        Controls.Add(ListPanel)
        Controls.Add(lblInfo)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "RestoreList"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Restore List:"
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblInfo As Label
    Friend WithEvents ListPanel As FlowLayoutPanel

End Class
