<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListSelector
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
        components = New ComponentModel.Container()
        Border = New Panel()
        Panel1 = New Panel()
        ContextMenuStrip = New ContextMenuStrip(components)
        RemoveToolStripMenuItem = New ToolStripMenuItem()
        lblRemove = New Label()
        btnTool = New Button()
        Border.SuspendLayout()
        Panel1.SuspendLayout()
        ContextMenuStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' Border
        ' 
        Border.BackColor = SystemColors.Control
        Border.Controls.Add(Panel1)
        Border.Dock = DockStyle.Fill
        Border.Location = New Point(0, 0)
        Border.Margin = New Padding(2)
        Border.Name = "Border"
        Border.Padding = New Padding(2)
        Border.Size = New Size(283, 40)
        Border.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.ContextMenuStrip = ContextMenuStrip
        Panel1.Controls.Add(lblRemove)
        Panel1.Controls.Add(btnTool)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(2, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(279, 36)
        Panel1.TabIndex = 0
        ' 
        ' ContextMenuStrip
        ' 
        ContextMenuStrip.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip.Items.AddRange(New ToolStripItem() {RemoveToolStripMenuItem})
        ContextMenuStrip.Name = "ContextMenuStrip"
        ContextMenuStrip.Size = New Size(133, 28)
        ' 
        ' RemoveToolStripMenuItem
        ' 
        RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        RemoveToolStripMenuItem.Size = New Size(132, 24)
        RemoveToolStripMenuItem.Text = "&Remove"
        ' 
        ' lblRemove
        ' 
        lblRemove.ContextMenuStrip = ContextMenuStrip
        lblRemove.Font = New Font("Segoe UI", 16F)
        lblRemove.Location = New Point(244, -7)
        lblRemove.Name = "lblRemove"
        lblRemove.Size = New Size(34, 38)
        lblRemove.TabIndex = 1
        lblRemove.Text = "🞃"
        lblRemove.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnTool
        ' 
        btnTool.Dock = DockStyle.Left
        btnTool.Location = New Point(0, 0)
        btnTool.Name = "btnTool"
        btnTool.Size = New Size(238, 36)
        btnTool.TabIndex = 0
        btnTool.Text = "btnTool"
        btnTool.UseVisualStyleBackColor = True
        ' 
        ' ListSelector
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Border)
        Margin = New Padding(0)
        Name = "ListSelector"
        Size = New Size(283, 40)
        Border.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ContextMenuStrip.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Border As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents linkRemove As LinkLabel
    Friend WithEvents btnTool As Button
    Friend WithEvents lblRemove As Label

End Class
