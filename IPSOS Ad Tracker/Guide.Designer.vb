<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Guide
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
        WebView = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(WebView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' WebView
        ' 
        WebView.AllowExternalDrop = True
        WebView.CreationProperties = Nothing
        WebView.DefaultBackgroundColor = Color.White
        WebView.Dock = DockStyle.Fill
        WebView.Location = New Point(0, 0)
        WebView.Name = "WebView"
        WebView.Size = New Size(982, 553)
        WebView.TabIndex = 1
        WebView.ZoomFactor = 1R
        ' 
        ' Guide
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 553)
        Controls.Add(WebView)
        Margin = New Padding(4, 5, 4, 5)
        MinimizeBox = False
        Name = "Guide"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Guide:"
        CType(WebView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents WebView As Microsoft.Web.WebView2.WinForms.WebView2

End Class
