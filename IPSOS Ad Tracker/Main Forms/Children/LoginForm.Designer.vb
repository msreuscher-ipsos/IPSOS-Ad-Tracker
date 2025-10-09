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
        chkSaveInfo = New CheckBox()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
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
        OK.Location = New Point(299, 211)
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
        TableLayoutPanel1.Location = New Point(12, 12)
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
        btnCancel.Location = New Point(399, 211)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 34)
        btnCancel.TabIndex = 5
        btnCancel.Text = "&Cancel"
        ' 
        ' chkSaveInfo
        ' 
        chkSaveInfo.AutoSize = True
        chkSaveInfo.Location = New Point(121, 212)
        chkSaveInfo.Name = "chkSaveInfo"
        chkSaveInfo.Size = New Size(129, 24)
        chkSaveInfo.TabIndex = 9
        chkSaveInfo.Text = "Save password"
        chkSaveInfo.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(508, 257)
        Controls.Add(chkSaveInfo)
        Controls.Add(btnCancel)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(OK)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        TopMost = True
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents lblSID As Label
    Friend WithEvents txtSID As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblServer As Label
    Friend WithEvents boxServer As ComboBox
    Friend WithEvents chkSaveInfo As CheckBox

End Class
