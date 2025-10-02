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
        btnNew = New Button()
        btnExisting = New Button()
        btnGuide = New Button()
        SuspendLayout()
        ' 
        ' btnNew
        ' 
        btnNew.Location = New Point(12, 12)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(322, 40)
        btnNew.TabIndex = 1
        btnNew.Text = "Start New Project"
        btnNew.UseVisualStyleBackColor = True
        ' 
        ' btnExisting
        ' 
        btnExisting.Location = New Point(12, 58)
        btnExisting.Name = "btnExisting"
        btnExisting.Size = New Size(322, 40)
        btnExisting.TabIndex = 2
        btnExisting.Text = "Existing Project"
        btnExisting.UseVisualStyleBackColor = True
        ' 
        ' btnGuide
        ' 
        btnGuide.Location = New Point(12, 104)
        btnGuide.Name = "btnGuide"
        btnGuide.Size = New Size(322, 40)
        btnGuide.TabIndex = 3
        btnGuide.Text = "Guide"
        btnGuide.UseVisualStyleBackColor = True
        ' 
        ' Intro
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(346, 155)
        Controls.Add(btnGuide)
        Controls.Add(btnExisting)
        Controls.Add(btnNew)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Intro"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "IPSOS Ad Tracker"
        ResumeLayout(False)

    End Sub

    Friend WithEvents btnNew As Button
    Friend WithEvents btnExisting As Button
    Friend WithEvents btnGuide As Button

End Class
