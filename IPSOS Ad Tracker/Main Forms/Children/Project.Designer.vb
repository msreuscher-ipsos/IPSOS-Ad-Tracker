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
        ListStrip = New ToolStrip()
        MainSplit = New SplitContainer()
        ListPanel = New Panel()
        CType(MainPanel, ComponentModel.ISupportInitialize).BeginInit()
        MainPanel.SuspendLayout()
        CType(MainSplit, ComponentModel.ISupportInitialize).BeginInit()
        MainSplit.Panel1.SuspendLayout()
        MainSplit.Panel2.SuspendLayout()
        MainSplit.SuspendLayout()
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
        ' ListStrip
        ' 
        ListStrip.AllowMerge = False
        ListStrip.Dock = DockStyle.Fill
        ListStrip.GripStyle = ToolStripGripStyle.Hidden
        ListStrip.ImageScalingSize = New Size(20, 20)
        ListStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        ListStrip.Location = New Point(0, 0)
        ListStrip.Name = "ListStrip"
        ListStrip.Size = New Size(283, 504)
        ListStrip.TabIndex = 0
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
        MainSplit.Panel1.Controls.Add(ListStrip)
        ' 
        ' MainSplit.Panel2
        ' 
        MainSplit.Panel2.Controls.Add(ListPanel)
        MainSplit.Size = New Size(850, 504)
        MainSplit.SplitterDistance = 283
        MainSplit.TabIndex = 0
        ' 
        ' ListPanel
        ' 
        ListPanel.Dock = DockStyle.Fill
        ListPanel.Location = New Point(0, 0)
        ListPanel.Name = "ListPanel"
        ListPanel.Size = New Size(563, 504)
        ListPanel.TabIndex = 0
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
        Text = "Project"
        WindowState = FormWindowState.Maximized
        CType(MainPanel, ComponentModel.ISupportInitialize).EndInit()
        MainPanel.ResumeLayout(False)
        MainSplit.Panel1.ResumeLayout(False)
        MainSplit.Panel1.PerformLayout()
        MainSplit.Panel2.ResumeLayout(False)
        CType(MainSplit, ComponentModel.ISupportInitialize).EndInit()
        MainSplit.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListStrip As ToolStrip
    Friend WithEvents MainPanel As SplitContainer
    Friend WithEvents MainSplit As SplitContainer
    Friend WithEvents ListPanel As Panel
End Class
