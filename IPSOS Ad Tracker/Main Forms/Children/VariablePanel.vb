Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Menu
Imports System.Windows.Media.Converters
Imports GlobalRefs.GlobalFunctions

Public Class VariablePanel

    Public Shadows Parent As Project
    Public Shadows ParentPanel As FlowLayoutPanel
    Public Variables As Dictionary(Of Integer, VariablePanel)

    Public allowChanges As Boolean
    Public Index As Integer

    Public DataTypes As New Dictionary(Of Integer, DataType)

    Public isLoaded As Boolean = False

    Public Sub New(ByRef _Parent As Project,
                   ByRef _Panel As FlowLayoutPanel,
                   ByVal _Index As Integer,
                   ByVal _AllowChanges As Boolean,
                   ByVal _Name As String,
                   ByVal _Type As Integer,
                   ByVal _isCultured As Boolean,
                   ByVal Optional isNew As Boolean = False,
                   ByVal Optional Punches As Dictionary(Of Integer, Punch) = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Parent = _Parent
        Variables = Parent.Variables
        ParentPanel = _Panel
        Index = _Index
        allowChanges = _AllowChanges

        If allowChanges = False Then Me.Enabled = False

        DataTypes.Add(1, New DataType("Text", 1))
        DataTypes.Add(2, New DataType("Punch/Categorical", 2))
        DataTypes.Add(3, New DataType("Number", 3))
        DataTypes.Add(4, New DataType("Yes/No", 4))
        DataTypes.Add(5, New DataType("Date/Time", 5))
        DataTypes.Add(6, New DataType("File Upload", 6))

        For Each DT As KeyValuePair(Of Integer, DataType) In DataTypes
            boxType.Items.Add(DataTypes(DT.Key))
        Next

        If isNew = False Then
            txtName.Text = _Name
            boxType.SelectedItem = DataTypes(_Type)
            If _Type = 2 Then
                PList.Punches = Punches
                If PList.Punches.Count > 0 Then
                    For Each P As KeyValuePair(Of Integer, Punch) In PList.Punches
                        PList.Punches(P.Key).UpdatePunch(PList, PList.FlowPanel)
                    Next
                    PList.PCnt = PList.Punches.Count
                ElseIf _Name = "Medium" Then
                    Dim items As Array = System.Enum.GetNames(GetType(MediaType))
                    Dim values As Array = System.Enum.GetValues(GetType(MediaType))
                    For i As Integer = 0 To UBound(items)
                        Dim NewPunch As New Punch(PList, i, PList.FlowPanel)
                        NewPunch.txtValue.Text = "_" & values(i)
                        NewPunch.txtLabel.Text = items(i)
                        PList.Punches.Add(i + 1, NewPunch)
                        PList.PCnt = i + 1
                    Next
                End If
            End If
        End If

        Me.Controls.Add(Panel)
        ParentPanel.Controls.Add(Me)

        chkCultured.Checked = _isCultured
        isLoaded = True

    End Sub

    Private Sub lblRemove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRemove.LinkClicked
        ParentPanel.Controls.Remove(Me)
        Variables.Remove(Index)
    End Sub

    Public PList As New PunchScreen
    Private Sub boxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxType.SelectedIndexChanged
        If isLoaded Then
            If CType(boxType.SelectedItem, DataType).Value = 2 Then
                PList.ShowDialog()
            Else
                PList.Punches.Clear()
            End If
        End If
    End Sub
End Class


Public Class DataType

    Public Name As String
    Public Value As String

    Public Sub New(ByVal _Name As String, ByVal _Value As Integer)

        Name = _Name
        Value = _Value

    End Sub
    Public Overrides Function ToString() As String
        Return Name ' This will be displayed in the ComboBox
    End Function

End Class