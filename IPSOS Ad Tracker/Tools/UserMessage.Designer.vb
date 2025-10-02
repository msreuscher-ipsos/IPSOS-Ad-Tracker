<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMessage
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
        Panel1 = New Panel()
        lblMessage = New Label()
        btnOK = New Button()
        txtError = New RichTextBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(txtError)
        Panel1.Controls.Add(lblMessage)
        Panel1.Controls.Add(btnOK)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(5, 5)
        Panel1.Margin = New Padding(5)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5)
        Panel1.Size = New Size(383, 186)
        Panel1.TabIndex = 0
        ' 
        ' lblMessage
        ' 
        lblMessage.Location = New Point(8, 5)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(367, 141)
        lblMessage.TabIndex = 1
        lblMessage.Text = "lblMessage"
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(305, 149)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 29)
        btnOK.TabIndex = 0
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' txtError
        ' 
        txtError.BorderStyle = BorderStyle.None
        txtError.Location = New Point(8, 3)
        txtError.Name = "txtError"
        txtError.ReadOnly = True
        txtError.Size = New Size(367, 140)
        txtError.TabIndex = 2
        txtError.Text = ""
        txtError.Visible = False
        ' 
        ' UserMessage
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Red
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Panel1)
        Margin = New Padding(5)
        Name = "UserMessage"
        Padding = New Padding(5)
        Size = New Size(393, 196)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents txtError As RichTextBox

End Class
