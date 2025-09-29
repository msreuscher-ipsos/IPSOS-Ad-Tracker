<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileSelect))
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        lblAdd = New LinkLabel()
        MediaPanel = New FlowLayoutPanel()
        OpenFile = New OpenFileDialog()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        resources.ApplyResources(TableLayoutPanel1, "TableLayoutPanel1")
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        ' 
        ' OK_Button
        ' 
        resources.ApplyResources(OK_Button, "OK_Button")
        OK_Button.Name = "OK_Button"
        ' 
        ' lblAdd
        ' 
        resources.ApplyResources(lblAdd, "lblAdd")
        lblAdd.Name = "lblAdd"
        lblAdd.TabStop = True
        ' 
        ' MediaPanel
        ' 
        resources.ApplyResources(MediaPanel, "MediaPanel")
        MediaPanel.Name = "MediaPanel"
        ' 
        ' FileSelect
        ' 
        AcceptButton = OK_Button
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(MediaPanel)
        Controls.Add(lblAdd)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FileSelect"
        ShowInTaskbar = False
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents lblAdd As LinkLabel
    Friend WithEvents MediaPanel As FlowLayoutPanel
    Friend WithEvents OpenFile As OpenFileDialog

End Class
