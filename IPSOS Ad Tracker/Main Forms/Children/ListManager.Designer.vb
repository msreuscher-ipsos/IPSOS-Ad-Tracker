<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListManager))
        Panel = New SplitContainer()
        lblTitle = New Label()
        Book = New unvell.ReoGrid.ReoGridControl()
        MainSplitContainer = New SplitContainer()
        SplitContainer1 = New SplitContainer()
        lblLanguage = New Label()
        LanguageFlow = New FlowLayoutPanel()
        SplitContainer2 = New SplitContainer()
        ListToolStrip = New ToolStrip()
        btnStaging = New ToolStripButton()
        btnPromote = New ToolStripButton()
        CType(Panel, ComponentModel.ISupportInitialize).BeginInit()
        Panel.Panel1.SuspendLayout()
        Panel.Panel2.SuspendLayout()
        Panel.SuspendLayout()
        CType(MainSplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        MainSplitContainer.Panel1.SuspendLayout()
        MainSplitContainer.Panel2.SuspendLayout()
        MainSplitContainer.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        ListToolStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel
        ' 
        Panel.BackColor = SystemColors.Control
        Panel.Dock = DockStyle.Fill
        Panel.FixedPanel = FixedPanel.Panel1
        Panel.IsSplitterFixed = True
        Panel.Location = New Point(0, 0)
        Panel.Name = "Panel"
        Panel.Orientation = Orientation.Horizontal
        ' 
        ' Panel.Panel1
        ' 
        Panel.Panel1.Controls.Add(lblTitle)
        ' 
        ' Panel.Panel2
        ' 
        Panel.Panel2.Controls.Add(Book)
        Panel.Size = New Size(1001, 505)
        Panel.SplitterDistance = 45
        Panel.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Fill
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1001, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "lblTitle"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Book
        ' 
        Book.BackColor = SystemColors.Control
        Book.ColumnHeaderContextMenuStrip = Nothing
        Book.Dock = DockStyle.Fill
        Book.LeadHeaderContextMenuStrip = Nothing
        Book.Location = New Point(0, 0)
        Book.Name = "Book"
        Book.RowHeaderContextMenuStrip = Nothing
        Book.Script = Nothing
        Book.SheetTabContextMenuStrip = Nothing
        Book.SheetTabNewButtonVisible = True
        Book.SheetTabVisible = True
        Book.SheetTabWidth = 60
        Book.ShowScrollEndSpacing = True
        Book.Size = New Size(1001, 456)
        Book.TabIndex = 0
        Book.Text = "ReoGridControl1"
        ' 
        ' MainSplitContainer
        ' 
        MainSplitContainer.Dock = DockStyle.Fill
        MainSplitContainer.FixedPanel = FixedPanel.Panel1
        MainSplitContainer.IsSplitterFixed = True
        MainSplitContainer.Location = New Point(0, 0)
        MainSplitContainer.Name = "MainSplitContainer"
        MainSplitContainer.Orientation = Orientation.Horizontal
        ' 
        ' MainSplitContainer.Panel1
        ' 
        MainSplitContainer.Panel1.Controls.Add(SplitContainer1)
        ' 
        ' MainSplitContainer.Panel2
        ' 
        MainSplitContainer.Panel2.Controls.Add(Panel)
        MainSplitContainer.Size = New Size(1001, 571)
        MainSplitContainer.SplitterDistance = 62
        MainSplitContainer.TabIndex = 1
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(lblLanguage)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(LanguageFlow)
        SplitContainer1.Size = New Size(1001, 62)
        SplitContainer1.SplitterDistance = 100
        SplitContainer1.TabIndex = 1
        ' 
        ' lblLanguage
        ' 
        lblLanguage.AutoSize = True
        lblLanguage.Location = New Point(3, 13)
        lblLanguage.Name = "lblLanguage"
        lblLanguage.Size = New Size(83, 20)
        lblLanguage.TabIndex = 0
        lblLanguage.Text = "Languages:"
        ' 
        ' LanguageFlow
        ' 
        LanguageFlow.Dock = DockStyle.Fill
        LanguageFlow.FlowDirection = FlowDirection.TopDown
        LanguageFlow.Location = New Point(0, 0)
        LanguageFlow.Name = "LanguageFlow"
        LanguageFlow.Padding = New Padding(5)
        LanguageFlow.Size = New Size(897, 62)
        LanguageFlow.TabIndex = 0
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.FixedPanel = FixedPanel.Panel1
        SplitContainer2.IsSplitterFixed = True
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(ListToolStrip)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(MainSplitContainer)
        SplitContainer2.Size = New Size(1001, 605)
        SplitContainer2.SplitterDistance = 30
        SplitContainer2.TabIndex = 2
        ' 
        ' ListToolStrip
        ' 
        ListToolStrip.AllowMerge = False
        ListToolStrip.GripStyle = ToolStripGripStyle.Hidden
        ListToolStrip.ImageScalingSize = New Size(20, 20)
        ListToolStrip.Items.AddRange(New ToolStripItem() {btnStaging, btnPromote})
        ListToolStrip.Location = New Point(0, 0)
        ListToolStrip.Name = "ListToolStrip"
        ListToolStrip.Size = New Size(1001, 27)
        ListToolStrip.TabIndex = 0
        ListToolStrip.Text = "ListToolStrip"
        ' 
        ' btnStaging
        ' 
        btnStaging.Enabled = False
        btnStaging.Image = CType(resources.GetObject("btnStaging.Image"), Image)
        btnStaging.ImageTransparentColor = Color.Black
        btnStaging.Name = "btnStaging"
        btnStaging.Size = New Size(217, 24)
        btnStaging.Text = "Load Current List to Staging"
        ' 
        ' btnPromote
        ' 
        btnPromote.Alignment = ToolStripItemAlignment.Right
        btnPromote.Enabled = False
        btnPromote.Image = CType(resources.GetObject("btnPromote.Image"), Image)
        btnPromote.ImageTransparentColor = Color.Black
        btnPromote.Name = "btnPromote"
        btnPromote.Size = New Size(262, 24)
        btnPromote.Text = "Promote Current List to Production"
        btnPromote.TextImageRelation = TextImageRelation.TextBeforeImage
        ' 
        ' ListManager
        ' 
        BackColor = SystemColors.Control
        Controls.Add(SplitContainer2)
        Name = "ListManager"
        Size = New Size(1001, 605)
        Panel.Panel1.ResumeLayout(False)
        Panel.Panel2.ResumeLayout(False)
        CType(Panel, ComponentModel.ISupportInitialize).EndInit()
        Panel.ResumeLayout(False)
        MainSplitContainer.Panel1.ResumeLayout(False)
        MainSplitContainer.Panel2.ResumeLayout(False)
        CType(MainSplitContainer, ComponentModel.ISupportInitialize).EndInit()
        MainSplitContainer.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel1.PerformLayout()
        SplitContainer2.Panel2.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        ListToolStrip.ResumeLayout(False)
        ListToolStrip.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel As SplitContainer
    Friend WithEvents Book As unvell.ReoGrid.ReoGridControl
    Friend WithEvents lblTitle As Label
    Friend WithEvents MainSplitContainer As SplitContainer
    Friend WithEvents LanguageFlow As FlowLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblLanguage As Label
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ListToolStrip As ToolStrip
    Friend WithEvents btnStaging As ToolStripButton
    Friend WithEvents btnPromote As ToolStripButton
End Class
