Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Class VariableManager

    Shadows Parent As Project
    Public NewPanel As New Panel
    Public WithEvents lblNew As New LinkLabel

    Public Sub New(ByRef _Parent As Project)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Parent = _Parent

    End Sub

    Public Sub StartUp(ByVal projectExists As Boolean)

        If projectExists = False Then
            With Parent.Variables
                .Add(1, New VariablePanel(Parent, VariablePanel, 1, True, "Ad_Name", 1, False))
                .Add(2, New VariablePanel(Parent, VariablePanel, 2, True, "Medium", 2, False,, New Dictionary(Of Integer, Punch)))
                .Add(3, New VariablePanel(Parent, VariablePanel, 3, True, "File_Name", 6, True))
            End With
            Parent.CurrentIndex = 3
        End If

        NewPanel.Size = New Size(465, 50)
        With lblNew
            .Text = "Add New Variable"
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
            .Padding = New Padding(20, 5, 5, 5)
        End With
        NewPanel.Controls.Add(lblNew)
        VariablePanel.Controls.Add(NewPanel)

    End Sub


    Public Sub ReadinCustomVariables(ByVal CustomVariables() As String)

        For Each Line As String In CustomVariables
            If Trim(Line) <> "" Then
                Dim VariableInfo() As String = Split(Line, ",")
                If Not Parent.Variables.ContainsKey(VariableInfo(0)) And
                   VariableInfo(0) <> 0 Then
                    If VariableInfo.Count > 5 Then
                        Dim PSplit() As String = Split(VariableInfo(5), "|")
                        Dim Punches As New Dictionary(Of Integer, Punch)
                        For i As Integer = 0 To UBound(PSplit)
                            Dim NewPunch As New Punch(Nothing, i + 1, Nothing)
                            NewPunch.txtValue.Text = Split(PSplit(i), ":")(0)
                            NewPunch.txtLabel.Text = Split(PSplit(i), ":")(1)
                            Punches.Add(i + 1, NewPunch)
                        Next
                        Parent.Variables.Add(VariableInfo(0), New VariablePanel(Parent, VariablePanel, VariableInfo(0), VariableInfo(2), VariableInfo(1), VariableInfo(3), VariableInfo(4),, Punches))
                    ElseIf VariableInfo(2) = "2" Then
                        Dim Punches As New Dictionary(Of Integer, Punch)
                        Parent.Variables.Add(VariableInfo(0), New VariablePanel(Parent, VariablePanel, VariableInfo(0), VariableInfo(2), VariableInfo(1), VariableInfo(3), VariableInfo(4),, Punches))
                    Else
                        Parent.Variables.Add(VariableInfo(0), New VariablePanel(Parent, VariablePanel, VariableInfo(0), VariableInfo(2), VariableInfo(1), VariableInfo(3), VariableInfo(4),,))
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub lblNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblNew.LinkClicked
        Me.ResumeLayout()
        Parent.CurrentIndex += 1
        VariablePanel.Controls.Remove(NewPanel)
        Parent.Variables.Add(Parent.CurrentIndex, New VariablePanel(Parent, VariablePanel, Parent.CurrentIndex, True, "", 1, False))
        VariablePanel.Controls.Add(NewPanel)
        Me.SuspendLayout()
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
