<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Password
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
        lblPassword = New Label()
        txtPassword = New TextBox()
        btnOkay = New Button()
        SuspendLayout()
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(12, 9)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(134, 20)
        lblPassword.TabIndex = 0
        lblPassword.Text = "Re-Enter Password:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(12, 40)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(331, 27)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnOkay
        ' 
        btnOkay.Enabled = False
        btnOkay.Location = New Point(249, 90)
        btnOkay.Name = "btnOkay"
        btnOkay.Size = New Size(94, 29)
        btnOkay.TabIndex = 2
        btnOkay.Text = "OK"
        btnOkay.UseVisualStyleBackColor = True
        ' 
        ' Password
        ' 
        AcceptButton = btnOkay
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(355, 131)
        Controls.Add(btnOkay)
        Controls.Add(txtPassword)
        Controls.Add(lblPassword)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Password"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "Password"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnOkay As Button
End Class
