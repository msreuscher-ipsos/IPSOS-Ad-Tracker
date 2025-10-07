Imports System.Collections.Specialized
Imports System.IO
Imports System.Net.Http
Imports System.Resources
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Logging

Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Public Sub New(ByVal _Username As String, ByVal _Password As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtUserName.Text = _Username
        txtPassword.Text = _Password

        boxServer.SelectedIndex = 0

        If My.Computer.FileSystem.FileExists("C:\Ad Loader\Users.resx") Then
            Dim User As New AutoCompleteStringCollection
            Using UserResx As New ResXResourceReader("C:\Ad Loader\Users.resx")
                For Each entry As DictionaryEntry In UserResx
                    User.Add(CType(entry.Value, String))
                Next
            End Using
            txtUserName.AutoCompleteCustomSource = User
            txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If
        If My.Computer.FileSystem.FileExists("C:\Ad Loader\SIDs.resx") Then
            Dim SIDs As New AutoCompleteStringCollection
            Using SIDResx As New ResXResourceReader("C:\Ad Loader\SIDs.resx")
                For Each entry As DictionaryEntry In SIDResx
                    SIDs.Add(CType(entry.Value, String))
                Next
            End Using
            txtSID.AutoCompleteCustomSource = SIDs
            txtSID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSID.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtUserName.Text.Length = 0 Then
            txtUserName.Select()
        ElseIf txtPassword.Text.Length = 0 Then
            txtPassword.Select()
        ElseIf txtSID.Text.Length = 0 Then
            txtSID.Select()
        Else
            OK.Select()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        End
    End Sub
End Class
