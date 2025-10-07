<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Project
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
        MainPanel = New SplitContainer()
        MainSplit = New SplitContainer()
        FlowLayout = New FlowLayoutPanel()
        HideShowPanel = New Panel()
        lblClose = New Label()
        ListPanel = New Panel()
        lblOpen = New Label()
        CType(MainPanel, ComponentModel.ISupportInitialize).BeginInit()
        MainPanel.SuspendLayout()
        CType(MainSplit, ComponentModel.ISupportInitialize).BeginInit()
        MainSplit.Panel1.SuspendLayout()
        MainSplit.Panel2.SuspendLayout()
        MainSplit.SuspendLayout()
        FlowLayout.SuspendLayout()
        HideShowPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' MainPanel
        ' 
        MainPanel.Dock = DockStyle.Fill
        MainPanel.FixedPanel = FixedPanel.Panel1
        MainPanel.IsSplitterFixed = True
        MainPanel.Location = New Point(0, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(824, 504)
        MainPanel.SplitterDistance = 179
        MainPanel.TabIndex = 0
        ' 
        ' MainSplit
        ' 
        MainSplit.Dock = DockStyle.Fill
        MainSplit.FixedPanel = FixedPanel.Panel1
        MainSplit.IsSplitterFixed = True
        MainSplit.Location = New Point(0, 0)
        MainSplit.Name = "MainSplit"
        ' 
        ' MainSplit.Panel1
        ' 
        MainSplit.Panel1.Controls.Add(FlowLayout)
        ' 
        ' MainSplit.Panel2
        ' 
        MainSplit.Panel2.Controls.Add(ListPanel)
        MainSplit.Size = New Size(850, 504)
        MainSplit.SplitterDistance = 283
        MainSplit.TabIndex = 0
        ' 
        ' FlowLayout
        ' 
        FlowLayout.AutoScroll = True
        FlowLayout.Controls.Add(HideShowPanel)
        FlowLayout.Dock = DockStyle.Fill
        FlowLayout.FlowDirection = FlowDirection.TopDown
        FlowLayout.Location = New Point(0, 0)
        FlowLayout.Name = "FlowLayout"
        FlowLayout.Size = New Size(283, 504)
        FlowLayout.TabIndex = 0
        FlowLayout.WrapContents = False
        ' 
        ' HideShowPanel
        ' 
        HideShowPanel.Controls.Add(lblOpen)
        HideShowPanel.Controls.Add(lblClose)
        HideShowPanel.Location = New Point(3, 3)
        HideShowPanel.Name = "HideShowPanel"
        HideShowPanel.Size = New Size(283, 40)
        HideShowPanel.TabIndex = 0
        ' 
        ' lblClose
        ' 
        lblClose.Font = New Font("Segoe UI", 12F)
        lblClose.Location = New Point(244, -7)
        lblClose.Name = "lblClose"
        lblClose.Size = New Size(34, 38)
        lblClose.TabIndex = 2
        lblClose.Text = "◀"
        lblClose.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ListPanel
        ' 
        ListPanel.Dock = DockStyle.Fill
        ListPanel.Location = New Point(0, 0)
        ListPanel.Name = "ListPanel"
        ListPanel.Size = New Size(563, 504)
        ListPanel.TabIndex = 0
        ' 
        ' lblOpen
        ' 
        lblOpen.Font = New Font("Segoe UI", 12F)
        lblOpen.Location = New Point(3, -7)
        lblOpen.Name = "lblOpen"
        lblOpen.Size = New Size(34, 38)
        lblOpen.TabIndex = 3
        lblOpen.Text = "▶"
        lblOpen.TextAlign = ContentAlignment.MiddleCenter
        lblOpen.Visible = False
        ' 
        ' Project
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(850, 504)
        ControlBox = False
        Controls.Add(MainSplit)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Project"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Project"
        CType(MainPanel, ComponentModel.ISupportInitialize).EndInit()
        MainPanel.ResumeLayout(False)
        MainSplit.Panel1.ResumeLayout(False)
        MainSplit.Panel2.ResumeLayout(False)
        CType(MainSplit, ComponentModel.ISupportInitialize).EndInit()
        MainSplit.ResumeLayout(False)
        FlowLayout.ResumeLayout(False)
        HideShowPanel.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents MainPanel As SplitContainer
    Friend WithEvents MainSplit As SplitContainer
    Friend WithEvents ListPanel As Panel
    Friend WithEvents FlowLayout As FlowLayoutPanel
    Friend WithEvents HideShowPanel As Panel
    Friend WithEvents lblClose As Label
    Friend WithEvents lblOpen As Label
End Class
