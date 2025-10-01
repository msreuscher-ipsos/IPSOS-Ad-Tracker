<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restore
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
        RestoreTab = New TabControl()
        RestoreAllPage = New TabPage()
        lblSelectVersion = New Label()
        btnRestoreAll = New Button()
        RestoreAllTree = New TreeView()
        RestoreSelectPage = New TabPage()
        RestoreSelectedTree = New TreeView()
        lblSelectFiles = New Label()
        btnRestoreSelected = New Button()
        SplitContainer1 = New SplitContainer()
        lblInstructions = New Label()
        RestoreTab.SuspendLayout()
        RestoreAllPage.SuspendLayout()
        RestoreSelectPage.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RestoreTab
        ' 
        RestoreTab.Controls.Add(RestoreAllPage)
        RestoreTab.Controls.Add(RestoreSelectPage)
        RestoreTab.Dock = DockStyle.Fill
        RestoreTab.Location = New Point(0, 0)
        RestoreTab.Name = "RestoreTab"
        RestoreTab.SelectedIndex = 0
        RestoreTab.Size = New Size(453, 450)
        RestoreTab.TabIndex = 2
        ' 
        ' RestoreAllPage
        ' 
        RestoreAllPage.Controls.Add(lblSelectVersion)
        RestoreAllPage.Controls.Add(btnRestoreAll)
        RestoreAllPage.Controls.Add(RestoreAllTree)
        RestoreAllPage.Location = New Point(4, 29)
        RestoreAllPage.Name = "RestoreAllPage"
        RestoreAllPage.Padding = New Padding(3)
        RestoreAllPage.Size = New Size(445, 417)
        RestoreAllPage.TabIndex = 0
        RestoreAllPage.Text = "Restore All Files"
        RestoreAllPage.UseVisualStyleBackColor = True
        ' 
        ' lblSelectVersion
        ' 
        lblSelectVersion.AutoSize = True
        lblSelectVersion.Location = New Point(3, 5)
        lblSelectVersion.Name = "lblSelectVersion"
        lblSelectVersion.Size = New Size(104, 20)
        lblSelectVersion.TabIndex = 2
        lblSelectVersion.Text = "Select Version:"
        ' 
        ' btnRestoreAll
        ' 
        btnRestoreAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRestoreAll.Enabled = False
        btnRestoreAll.Location = New Point(343, 380)
        btnRestoreAll.Name = "btnRestoreAll"
        btnRestoreAll.Size = New Size(94, 29)
        btnRestoreAll.TabIndex = 1
        btnRestoreAll.Text = "Restore"
        btnRestoreAll.UseVisualStyleBackColor = True
        ' 
        ' RestoreAllTree
        ' 
        RestoreAllTree.CheckBoxes = True
        RestoreAllTree.Location = New Point(3, 28)
        RestoreAllTree.Name = "RestoreAllTree"
        RestoreAllTree.Size = New Size(439, 328)
        RestoreAllTree.TabIndex = 0
        ' 
        ' RestoreSelectPage
        ' 
        RestoreSelectPage.Controls.Add(RestoreSelectedTree)
        RestoreSelectPage.Controls.Add(lblSelectFiles)
        RestoreSelectPage.Controls.Add(btnRestoreSelected)
        RestoreSelectPage.Location = New Point(4, 29)
        RestoreSelectPage.Name = "RestoreSelectPage"
        RestoreSelectPage.Padding = New Padding(3)
        RestoreSelectPage.Size = New Size(445, 417)
        RestoreSelectPage.TabIndex = 1
        RestoreSelectPage.Text = "Restore Selected File(s)"
        RestoreSelectPage.UseVisualStyleBackColor = True
        ' 
        ' RestoreSelectedTree
        ' 
        RestoreSelectedTree.CheckBoxes = True
        RestoreSelectedTree.Location = New Point(3, 28)
        RestoreSelectedTree.Name = "RestoreSelectedTree"
        RestoreSelectedTree.ShowLines = False
        RestoreSelectedTree.ShowPlusMinus = False
        RestoreSelectedTree.ShowRootLines = False
        RestoreSelectedTree.Size = New Size(439, 328)
        RestoreSelectedTree.TabIndex = 5
        ' 
        ' lblSelectFiles
        ' 
        lblSelectFiles.AutoSize = True
        lblSelectFiles.Location = New Point(3, 5)
        lblSelectFiles.Name = "lblSelectFiles"
        lblSelectFiles.Size = New Size(157, 20)
        lblSelectFiles.TabIndex = 4
        lblSelectFiles.Text = "Select Files to Restore:"
        ' 
        ' btnRestoreSelected
        ' 
        btnRestoreSelected.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRestoreSelected.Enabled = False
        btnRestoreSelected.Location = New Point(343, 380)
        btnRestoreSelected.Name = "btnRestoreSelected"
        btnRestoreSelected.Size = New Size(94, 29)
        btnRestoreSelected.TabIndex = 2
        btnRestoreSelected.Text = "Restore"
        btnRestoreSelected.UseVisualStyleBackColor = True
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(lblInstructions)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(RestoreTab)
        SplitContainer1.Size = New Size(453, 508)
        SplitContainer1.SplitterDistance = 54
        SplitContainer1.TabIndex = 3
        ' 
        ' lblInstructions
        ' 
        lblInstructions.Dock = DockStyle.Fill
        lblInstructions.Location = New Point(0, 0)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Padding = New Padding(5)
        lblInstructions.Size = New Size(453, 54)
        lblInstructions.TabIndex = 0
        lblInstructions.Text = "Note: Any unsaved data changes will not be retained. Be sure to save before clicking to Restore a back up."
        ' 
        ' Restore
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(453, 508)
        Controls.Add(SplitContainer1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MinimizeBox = False
        Name = "Restore"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "Restore"
        RestoreTab.ResumeLayout(False)
        RestoreAllPage.ResumeLayout(False)
        RestoreAllPage.PerformLayout()
        RestoreSelectPage.ResumeLayout(False)
        RestoreSelectPage.PerformLayout()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblMasterVersion As Label
    Friend WithEvents lblSelectVersion As Label
    Friend WithEvents RestoreTab As TabControl
    Friend WithEvents RestoreAllPage As TabPage
    Friend WithEvents RestoreSelectPage As TabPage
    Friend WithEvents btnRestoreAll As Button
    Friend WithEvents RestoreAllTree As TreeView
    Friend WithEvents lblSelectFiles As Label
    Friend WithEvents btnRestoreSelected As Button
    Friend WithEvents RestoreSelectedTree As TreeView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblInstructions As Label
End Class
