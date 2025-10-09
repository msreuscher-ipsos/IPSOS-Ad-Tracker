<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Intro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Intro))
        LogoPictureBox = New PictureBox()
        txtUserName = New TextBox()
        lblUserName = New Label()
        txtPassword = New TextBox()
        lblPassword = New Label()
        btnXMLLoad = New Button()
        txtSID = New TextBox()
        lblSID = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        lblServer = New Label()
        boxServer = New ComboBox()
        chkSaveInfo = New CheckBox()
        chkCleanLocal = New CheckBox()
        chkShowVariables = New CheckBox()
        btnCancel = New Button()
        btnLoad = New Button()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), Image)
        LogoPictureBox.Location = New Point(-1, 6)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(155, 156)
        LogoPictureBox.TabIndex = 13
        LogoPictureBox.TabStop = False
        ' 
        ' txtUserName
        ' 
        txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtUserName.Dock = DockStyle.Fill
        txtUserName.Location = New Point(109, 10)
        txtUserName.Margin = New Padding(3, 10, 3, 3)
        txtUserName.Name = "txtUserName"
        txtUserName.Size = New Size(365, 27)
        txtUserName.TabIndex = 1
        ' 
        ' lblUserName
        ' 
        lblUserName.Dock = DockStyle.Fill
        lblUserName.Location = New Point(3, 0)
        lblUserName.Name = "lblUserName"
        lblUserName.Size = New Size(100, 48)
        lblUserName.TabIndex = 0
        lblUserName.Text = "&User Name:"
        lblUserName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtPassword
        ' 
        txtPassword.Dock = DockStyle.Fill
        txtPassword.Location = New Point(109, 58)
        txtPassword.Margin = New Padding(3, 10, 3, 3)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(365, 27)
        txtPassword.TabIndex = 2
        ' 
        ' lblPassword
        ' 
        lblPassword.Dock = DockStyle.Fill
        lblPassword.Location = New Point(3, 48)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(100, 48)
        lblPassword.TabIndex = 2
        lblPassword.Text = "&Password:"
        lblPassword.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnXMLLoad
        ' 
        btnXMLLoad.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnXMLLoad.Location = New Point(181, 314)
        btnXMLLoad.Name = "btnXMLLoad"
        btnXMLLoad.Size = New Size(175, 34)
        btnXMLLoad.TabIndex = 14
        btnXMLLoad.Text = "Load with &XML File"
        ' 
        ' txtSID
        ' 
        txtSID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSID.CharacterCasing = CharacterCasing.Upper
        txtSID.Dock = DockStyle.Fill
        txtSID.Location = New Point(109, 106)
        txtSID.Margin = New Padding(3, 10, 3, 3)
        txtSID.Name = "txtSID"
        txtSID.Size = New Size(365, 27)
        txtSID.TabIndex = 3
        ' 
        ' lblSID
        ' 
        lblSID.Dock = DockStyle.Fill
        lblSID.Location = New Point(3, 96)
        lblSID.Name = "lblSID"
        lblSID.Size = New Size(100, 48)
        lblSID.TabIndex = 6
        lblSID.Text = "&SID:"
        lblSID.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.2222214F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 77.77778F))
        TableLayoutPanel1.Controls.Add(lblServer, 0, 3)
        TableLayoutPanel1.Controls.Add(txtUserName, 1, 0)
        TableLayoutPanel1.Controls.Add(txtSID, 1, 2)
        TableLayoutPanel1.Controls.Add(lblUserName, 0, 0)
        TableLayoutPanel1.Controls.Add(lblSID, 0, 2)
        TableLayoutPanel1.Controls.Add(txtPassword, 1, 1)
        TableLayoutPanel1.Controls.Add(lblPassword, 0, 1)
        TableLayoutPanel1.Controls.Add(boxServer, 1, 3)
        TableLayoutPanel1.Location = New Point(160, 18)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(477, 190)
        TableLayoutPanel1.TabIndex = 16
        ' 
        ' lblServer
        ' 
        lblServer.Dock = DockStyle.Fill
        lblServer.Location = New Point(3, 144)
        lblServer.Name = "lblServer"
        lblServer.Size = New Size(100, 46)
        lblServer.TabIndex = 8
        lblServer.Text = "&Media Server:"
        lblServer.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' boxServer
        ' 
        boxServer.FormattingEnabled = True
        boxServer.Items.AddRange(New Object() {"ftp-media.ipsosinteractive.com"})
        boxServer.Location = New Point(109, 154)
        boxServer.Margin = New Padding(3, 10, 3, 3)
        boxServer.Name = "boxServer"
        boxServer.Size = New Size(365, 28)
        boxServer.TabIndex = 7
        ' 
        ' chkSaveInfo
        ' 
        chkSaveInfo.AutoSize = True
        chkSaveInfo.Location = New Point(269, 218)
        chkSaveInfo.Name = "chkSaveInfo"
        chkSaveInfo.Size = New Size(129, 24)
        chkSaveInfo.TabIndex = 17
        chkSaveInfo.Text = "Save password"
        chkSaveInfo.UseVisualStyleBackColor = True
        ' 
        ' chkCleanLocal
        ' 
        chkCleanLocal.AutoSize = True
        chkCleanLocal.Location = New Point(269, 278)
        chkCleanLocal.Name = "chkCleanLocal"
        chkCleanLocal.Size = New Size(238, 24)
        chkCleanLocal.TabIndex = 20
        chkCleanLocal.Text = "Clean local files before loading"
        chkCleanLocal.UseVisualStyleBackColor = True
        ' 
        ' chkShowVariables
        ' 
        chkShowVariables.AutoSize = True
        chkShowVariables.Location = New Point(269, 248)
        chkShowVariables.Name = "chkShowVariables"
        chkShowVariables.Size = New Size(272, 24)
        chkShowVariables.TabIndex = 19
        chkShowVariables.Text = "Update Variables (if Existing Project)"
        chkShowVariables.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.Location = New Point(543, 314)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 34)
        btnCancel.TabIndex = 15
        btnCancel.Text = "&Close"
        ' 
        ' btnLoad
        ' 
        btnLoad.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnLoad.Location = New Point(362, 314)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(175, 34)
        btnLoad.TabIndex = 21
        btnLoad.Text = "Load &withOUT XML File"
        ' 
        ' Intro
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(650, 360)
        Controls.Add(btnLoad)
        Controls.Add(LogoPictureBox)
        Controls.Add(btnXMLLoad)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(chkSaveInfo)
        Controls.Add(chkCleanLocal)
        Controls.Add(chkShowVariables)
        Controls.Add(btnCancel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        HelpButton = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Intro"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "IPSOS Ad Tracker"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnXMLLoad As Button
    Friend WithEvents txtSID As TextBox
    Friend WithEvents lblSID As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblServer As Label
    Friend WithEvents boxServer As ComboBox
    Friend WithEvents chkSaveInfo As CheckBox
    Friend WithEvents chkCleanLocal As CheckBox
    Friend WithEvents chkShowVariables As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnLoad As Button

End Class
