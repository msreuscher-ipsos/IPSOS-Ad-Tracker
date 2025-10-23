<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PunchScreen
    Inherits System.Windows.Forms.Form

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
        FlowPanel = New FlowLayoutPanel()
        HeaderPanel = New Panel()
        lblRemove = New Label()
        lblLabel = New Label()
        lblValue = New Label()
        SplitContainer = New SplitContainer()
        lbl = New Label()
        btnOK = New Button()
        lblAddPunch = New LinkLabel()
        lnkBatch = New LinkLabel()
        FlowPanel.SuspendLayout()
        HeaderPanel.SuspendLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        SuspendLayout()
        ' 
        ' FlowPanel
        ' 
        FlowPanel.AutoScroll = True
        FlowPanel.Controls.Add(HeaderPanel)
        FlowPanel.Dock = DockStyle.Fill
        FlowPanel.FlowDirection = FlowDirection.TopDown
        FlowPanel.Location = New Point(0, 0)
        FlowPanel.Name = "FlowPanel"
        FlowPanel.Size = New Size(336, 337)
        FlowPanel.TabIndex = 0
        FlowPanel.WrapContents = False
        ' 
        ' HeaderPanel
        ' 
        HeaderPanel.Controls.Add(lblRemove)
        HeaderPanel.Controls.Add(lblLabel)
        HeaderPanel.Controls.Add(lblValue)
        HeaderPanel.Location = New Point(3, 3)
        HeaderPanel.Name = "HeaderPanel"
        HeaderPanel.Size = New Size(306, 37)
        HeaderPanel.TabIndex = 0
        ' 
        ' lblRemove
        ' 
        lblRemove.AutoSize = True
        lblRemove.Location = New Point(240, 16)
        lblRemove.Name = "lblRemove"
        lblRemove.Size = New Size(66, 20)
        lblRemove.TabIndex = 2
        lblRemove.Text = "Remove:"
        ' 
        ' lblLabel
        ' 
        lblLabel.AutoSize = True
        lblLabel.Location = New Point(70, 16)
        lblLabel.Name = "lblLabel"
        lblLabel.Size = New Size(48, 20)
        lblLabel.TabIndex = 1
        lblLabel.Text = "Label:"
        ' 
        ' lblValue
        ' 
        lblValue.AutoSize = True
        lblValue.Location = New Point(3, 16)
        lblValue.Name = "lblValue"
        lblValue.Size = New Size(48, 20)
        lblValue.TabIndex = 0
        lblValue.Text = "Value:"
        ' 
        ' SplitContainer
        ' 
        SplitContainer.Dock = DockStyle.Fill
        SplitContainer.FixedPanel = FixedPanel.Panel1
        SplitContainer.IsSplitterFixed = True
        SplitContainer.Location = New Point(0, 0)
        SplitContainer.Name = "SplitContainer"
        SplitContainer.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer.Panel1
        ' 
        SplitContainer.Panel1.Controls.Add(lnkBatch)
        SplitContainer.Panel1.Controls.Add(lbl)
        SplitContainer.Panel1.Controls.Add(btnOK)
        SplitContainer.Panel1.Controls.Add(lblAddPunch)
        ' 
        ' SplitContainer.Panel2
        ' 
        SplitContainer.Panel2.Controls.Add(FlowPanel)
        SplitContainer.Size = New Size(336, 401)
        SplitContainer.SplitterDistance = 60
        SplitContainer.TabIndex = 1
        ' 
        ' lbl
        ' 
        lbl.AutoSize = True
        lbl.Location = New Point(3, 9)
        lbl.Name = "lbl"
        lbl.Size = New Size(217, 20)
        lbl.TabIndex = 2
        lbl.Text = "Leave list blank for an open list."
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(230, 3)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(96, 48)
        btnOK.TabIndex = 1
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' lblAddPunch
        ' 
        lblAddPunch.AutoSize = True
        lblAddPunch.Location = New Point(3, 37)
        lblAddPunch.Name = "lblAddPunch"
        lblAddPunch.Size = New Size(80, 20)
        lblAddPunch.TabIndex = 0
        lblAddPunch.TabStop = True
        lblAddPunch.Text = "Add Value:"
        ' 
        ' lnkBatch
        ' 
        lnkBatch.AutoSize = True
        lnkBatch.Location = New Point(148, 37)
        lnkBatch.Name = "lnkBatch"
        lnkBatch.Size = New Size(72, 20)
        lnkBatch.TabIndex = 3
        lnkBatch.TabStop = True
        lnkBatch.Text = "Batch List"
        ' 
        ' PunchScreen
        ' 
        AcceptButton = btnOK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(336, 401)
        ControlBox = False
        Controls.Add(SplitContainer)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "PunchScreen"
        StartPosition = FormStartPosition.CenterParent
        TopMost = True
        FlowPanel.ResumeLayout(False)
        HeaderPanel.ResumeLayout(False)
        HeaderPanel.PerformLayout()
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel1.PerformLayout()
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlowPanel As FlowLayoutPanel
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents lbl As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents lblAddPunch As LinkLabel
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents lblRemove As Label
    Friend WithEvents lblLabel As Label
    Friend WithEvents lblValue As Label
    Friend WithEvents lnkBatch As LinkLabel

End Class
