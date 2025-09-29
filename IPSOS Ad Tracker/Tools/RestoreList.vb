Imports System.Windows.Forms

Public Class RestoreList


    Dim ParentProject As Project
    Public Sub New(ByRef _Parent As Project)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ParentProject = _Parent
    End Sub


    Public Lists As New Dictionary(Of String, CheckBox)
    Private Sub RestoreList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each List As KeyValuePair(Of String, ListManager) In ParentProject.Lists
            Dim NewCheck As New CheckBox
            With NewCheck
                .Checked = True
                .Text = ParentProject.Lists(List.Key).Name
                .AutoSize = True
            End With
            ListPanel.Controls.Add(NewCheck)
            Lists.Add(NewCheck.Text, NewCheck)
        Next
        For Each List As KeyValuePair(Of String, ListManager) In ParentProject.ExcludeLists
            Dim NewCheck As New CheckBox
            With NewCheck
                .Text = ParentProject.ExcludeLists(List.Key).Name
                .AutoSize = True
            End With
            ListPanel.Controls.Add(NewCheck)
            Lists.Add(NewCheck.Text, NewCheck)
        Next
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
