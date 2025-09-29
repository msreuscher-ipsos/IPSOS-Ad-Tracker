<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        MenuStrip = New MenuStrip()
        FileMenu = New ToolStripMenuItem()
        ExportDIMRoutingToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        menuStaging = New ToolStripMenuItem()
        PromoteToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        ToolsMenu = New ToolStripMenuItem()
        RestoreToolStripMenuItem = New ToolStripMenuItem()
        RestoreFromBackupToolStripMenuItem = New ToolStripMenuItem()
        HelpMenu = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        ToolStrip = New ToolStrip()
        btnStaging = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        PromoteToolStripButton = New ToolStripButton()
        ToolTip = New ToolTip(components)
        Timer = New Timer(components)
        SaveFile = New SaveFileDialog()
        MenuStrip.SuspendLayout()
        ToolStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip
        ' 
        MenuStrip.ImageScalingSize = New Size(20, 20)
        MenuStrip.Items.AddRange(New ToolStripItem() {FileMenu, ToolsMenu, HelpMenu})
        MenuStrip.Location = New Point(0, 0)
        MenuStrip.Name = "MenuStrip"
        MenuStrip.Padding = New Padding(8, 3, 0, 3)
        MenuStrip.Size = New Size(1482, 30)
        MenuStrip.TabIndex = 5
        MenuStrip.Text = "MenuStrip"
        ' 
        ' FileMenu
        ' 
        FileMenu.DropDownItems.AddRange(New ToolStripItem() {ExportDIMRoutingToolStripMenuItem, ToolStripSeparator3, menuStaging, PromoteToolStripMenuItem, ToolStripSeparator4, ExitToolStripMenuItem})
        FileMenu.ImageTransparentColor = SystemColors.ActiveBorder
        FileMenu.Name = "FileMenu"
        FileMenu.Size = New Size(46, 24)
        FileMenu.Text = "&File"
        ' 
        ' ExportDIMRoutingToolStripMenuItem
        ' 
        ExportDIMRoutingToolStripMenuItem.Image = CType(resources.GetObject("ExportDIMRoutingToolStripMenuItem.Image"), Image)
        ExportDIMRoutingToolStripMenuItem.Name = "ExportDIMRoutingToolStripMenuItem"
        ExportDIMRoutingToolStripMenuItem.Size = New Size(293, 26)
        ExportDIMRoutingToolStripMenuItem.Text = "&Export DIM Routing"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(290, 6)
        ' 
        ' menuStaging
        ' 
        menuStaging.Enabled = False
        menuStaging.Image = CType(resources.GetObject("menuStaging.Image"), Image)
        menuStaging.ImageTransparentColor = Color.Black
        menuStaging.Name = "menuStaging"
        menuStaging.ShortcutKeys = Keys.Control Or Keys.S
        menuStaging.Size = New Size(293, 26)
        menuStaging.Text = "&Load to Staging"
        ' 
        ' PromoteToolStripMenuItem
        ' 
        PromoteToolStripMenuItem.Enabled = False
        PromoteToolStripMenuItem.Image = CType(resources.GetObject("PromoteToolStripMenuItem.Image"), Image)
        PromoteToolStripMenuItem.ImageTransparentColor = Color.Black
        PromoteToolStripMenuItem.Name = "PromoteToolStripMenuItem"
        PromoteToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.P
        PromoteToolStripMenuItem.Size = New Size(293, 26)
        PromoteToolStripMenuItem.Text = "&Promote to Production"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(290, 6)
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(293, 26)
        ExitToolStripMenuItem.Text = "E&xit"
        ' 
        ' ToolsMenu
        ' 
        ToolsMenu.DropDownItems.AddRange(New ToolStripItem() {RestoreToolStripMenuItem, RestoreFromBackupToolStripMenuItem})
        ToolsMenu.Name = "ToolsMenu"
        ToolsMenu.Size = New Size(58, 24)
        ToolsMenu.Text = "&Tools"
        ' 
        ' RestoreToolStripMenuItem
        ' 
        RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        RestoreToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.L
        RestoreToolStripMenuItem.Size = New Size(281, 26)
        RestoreToolStripMenuItem.Text = "Restore &Lists"
        ' 
        ' RestoreFromBackupToolStripMenuItem
        ' 
        RestoreFromBackupToolStripMenuItem.Name = "RestoreFromBackupToolStripMenuItem"
        RestoreFromBackupToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.B
        RestoreFromBackupToolStripMenuItem.Size = New Size(281, 26)
        RestoreFromBackupToolStripMenuItem.Text = "Restore from &Backup"
        ' 
        ' HelpMenu
        ' 
        HelpMenu.DropDownItems.AddRange(New ToolStripItem() {AboutToolStripMenuItem})
        HelpMenu.Name = "HelpMenu"
        HelpMenu.Size = New Size(55, 24)
        HelpMenu.Text = "&Help"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(146, 26)
        AboutToolStripMenuItem.Text = "&About ..."
        ' 
        ' ToolStrip
        ' 
        ToolStrip.AllowMerge = False
        ToolStrip.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip.ImageScalingSize = New Size(20, 20)
        ToolStrip.Items.AddRange(New ToolStripItem() {btnStaging, ToolStripSeparator1, PromoteToolStripButton})
        ToolStrip.Location = New Point(0, 30)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New Size(1482, 27)
        ToolStrip.TabIndex = 6
        ToolStrip.Text = "ToolStrip"
        ' 
        ' btnStaging
        ' 
        btnStaging.Enabled = False
        btnStaging.Image = CType(resources.GetObject("btnStaging.Image"), Image)
        btnStaging.ImageTransparentColor = Color.Black
        btnStaging.Name = "btnStaging"
        btnStaging.Size = New Size(139, 24)
        btnStaging.Text = "Load to Staging"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 27)
        ' 
        ' PromoteToolStripButton
        ' 
        PromoteToolStripButton.Alignment = ToolStripItemAlignment.Right
        PromoteToolStripButton.Enabled = False
        PromoteToolStripButton.Image = CType(resources.GetObject("PromoteToolStripButton.Image"), Image)
        PromoteToolStripButton.ImageTransparentColor = Color.Black
        PromoteToolStripButton.Name = "PromoteToolStripButton"
        PromoteToolStripButton.Size = New Size(184, 24)
        PromoteToolStripButton.Text = "Promote to Production"
        PromoteToolStripButton.TextImageRelation = TextImageRelation.TextBeforeImage
        ' 
        ' Timer
        ' 
        Timer.Interval = 250
        ' 
        ' SaveFile
        ' 
        SaveFile.DefaultExt = "*.txt"
        SaveFile.RestoreDirectory = True
        SaveFile.Title = "Save File:"
        ' 
        ' Manager
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1482, 728)
        Controls.Add(ToolStrip)
        Controls.Add(MenuStrip)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip
        Margin = New Padding(4, 5, 4, 5)
        Name = "Manager"
        ShowIcon = False
        Text = "IPSOS Ad Tracker"
        MenuStrip.ResumeLayout(False)
        MenuStrip.PerformLayout()
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnStaging As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuStaging As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PromoteToolStripButton As ToolStripButton
    Friend WithEvents Timer As Timer
    Friend WithEvents RestoreFromBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportDIMRoutingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFile As SaveFileDialog

End Class
