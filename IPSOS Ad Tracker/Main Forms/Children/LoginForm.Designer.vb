<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        LogoPictureBox = New PictureBox()
        lblUserName = New Label()
        lblPassword = New Label()
        txtUserName = New TextBox()
        txtPassword = New TextBox()
        OK = New Button()
        lblSID = New Label()
        txtSID = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        lblServer = New Label()
        boxServer = New ComboBox()
        btnCancel = New Button()
        chkShowVariables = New CheckBox()
        chkXML = New CheckBox()
        chkCleanLocal = New CheckBox()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), Image)
        LogoPictureBox.Location = New Point(0, 0)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(155, 156)
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
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
        ' OK
        ' 
        OK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        OK.Location = New Point(444, 302)
        OK.Name = "OK"
        OK.Size = New Size(94, 34)
        OK.TabIndex = 4
        OK.Text = "&OK"
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
        TableLayoutPanel1.Location = New Point(161, 12)
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
        TableLayoutPanel1.TabIndex = 8
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
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.Location = New Point(544, 302)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 34)
        btnCancel.TabIndex = 5
        btnCancel.Text = "&Cancel"
        ' 
        ' chkShowVariables
        ' 
        chkShowVariables.AutoSize = True
        chkShowVariables.Location = New Point(258, 238)
        chkShowVariables.Name = "chkShowVariables"
        chkShowVariables.Size = New Size(272, 24)
        chkShowVariables.TabIndex = 9
        chkShowVariables.Text = "Update Variables (if Existing Project)"
        chkShowVariables.UseVisualStyleBackColor = True
        ' 
        ' chkXML
        ' 
        chkXML.AutoSize = True
        chkXML.Location = New Point(258, 208)
        chkXML.Name = "chkXML"
        chkXML.Size = New Size(382, 24)
        chkXML.TabIndex = 10
        chkXML.Text = "Readin Existing XML File (required if no existing files)"
        chkXML.UseVisualStyleBackColor = True
        ' 
        ' chkCleanLocal
        ' 
        chkCleanLocal.AutoSize = True
        chkCleanLocal.Location = New Point(258, 268)
        chkCleanLocal.Name = "chkCleanLocal"
        chkCleanLocal.Size = New Size(238, 24)
        chkCleanLocal.TabIndex = 11
        chkCleanLocal.Text = "Clean local files before loading"
        chkCleanLocal.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(650, 348)
        Controls.Add(chkCleanLocal)
        Controls.Add(chkXML)
        Controls.Add(chkShowVariables)
        Controls.Add(btnCancel)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(OK)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        TopMost = True
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents lblSID As Label
    Friend WithEvents txtSID As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkShowVariables As CheckBox
    Friend WithEvents chkXML As CheckBox
    Friend WithEvents chkCleanLocal As CheckBox
    Friend WithEvents lblServer As Label
    Friend WithEvents boxServer As ComboBox

End Class
