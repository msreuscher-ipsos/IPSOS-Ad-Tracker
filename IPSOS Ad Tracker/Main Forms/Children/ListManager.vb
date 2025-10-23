Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports GlobalRefs.GlobalFunctions
Imports unvell.ReoGrid
Imports unvell.ReoGrid.Events
Imports unvell.ReoGrid.IO.OpenXML.Schema
Public Class ListManager

    Public ParentProject As Project

    Public WithEvents Tool As New ListSelector

    Public Ads As New Dictionary(Of String, Ad)
    Public Variables As New Dictionary(Of Integer, VariablePanel)
    Public Headers As New Dictionary(Of String, Header)

    Public WithEvents Sheet As unvell.ReoGrid.Worksheet
    Dim Column As Integer = -1

    Public Languages As New Dictionary(Of String, Language)

    Public isLoaded As Boolean = False

    Public WithEvents hasChanges As New System.Windows.Forms.CheckBox
    Public WithEvents readyForProduction As New System.Windows.Forms.CheckBox

    Public Sub New(ByRef _Parent As Project,
                   ByRef _Variables As Dictionary(Of Integer, VariablePanel),
                   ByVal _Name As String,
                   ByVal _Label As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Name = _Name
        lblTitle.Text = _Label
        ParentProject = _Parent

        Variables = _Variables

        Tool.ParentList = Me
        Tool.btnTool.Text = Name
        Tool.RemoveToolStripMenuItem.Text &= " " & Name

        ParentProject.FlowLayout.Controls.Add(Tool)
        ParentProject.ListPanel.Controls.Add(Me)
        Me.Dock = DockStyle.Fill

        Book.SheetTabVisible = False
        Book.SheetTabNewButtonVisible = False
        Sheet = Book.Worksheets(0)
        Sheet.SetSettings(WorksheetSettings.View_AllowCellTextOverflow, False)
        Sheet.SetSettings(WorksheetSettings.Behavior_DoubleClickToFitColumnWidth, True)
        Sheet.SetSettings(WorksheetSettings.View_ShowGridLine, True)

    End Sub

    Sub Load()

        For Each A As KeyValuePair(Of String, Ad) In Ads
            With Ads(A.Key)
                For Each C As KeyValuePair(Of String, Country) In .Countries
                    With .Countries(C.Key)
                        For Each L As KeyValuePair(Of String, String) In .Languages
                            If Not Languages.ContainsKey(L.Key) Then
                                Dim NewLanguage As New Language(Me, L.Key, Ads(A.Key).Countries(C.Key))
                                Languages.Add(L.Key, NewLanguage)
                            End If
                        Next
                    End With
                Next
            End With
        Next

        For Each Var As KeyValuePair(Of Integer, VariablePanel) In Variables
            If Variables(Var.Key).chkCultured.Checked = False Then
                Column += 1
                Dim NewHeader As New Header(Nothing, Column, Variables(Var.Key).txtName.Text, Variables(Var.Key))
                Headers.Add(Variables(Var.Key).txtName.Text, NewHeader)
                Sheet.ColumnHeaders(Column).Text = Variables(Var.Key).txtName.Text
                Sheet.ColumnHeaders(Column).Width = Len(Variables(Var.Key).txtName.Text) * 10
                Sheet.AutoFitColumnWidth(Column)
                If Sheet.ColumnHeaders(Column).Width < 100 Then Sheet.ColumnHeaders(Column).Width = 100
            End If
        Next

        Sheet.Ranges("A1:Z100").Style.BackColor = Color.White
        Dim LCnt As Integer = 0
        If Languages.Count > 0 Then
            For Each L As KeyValuePair(Of String, Language) In Languages
                LCnt += 1
                For Each Var As KeyValuePair(Of Integer, VariablePanel) In Variables
                    If Variables(Var.Key).chkCultured.Checked = True Then
                        Column += 1
                        Dim NewHeader As New Header(Languages(L.Key).Language, Column, Variables(Var.Key).txtName.Text, Variables(Var.Key))
                        Headers.Add(Variables(Var.Key).txtName.Text & " - " & Languages(L.Key).Language, NewHeader)
                        Sheet.ColumnHeaders(Column).Text = Variables(Var.Key).txtName.Text & " - " & Languages(L.Key).Language
                        Sheet.ColumnHeaders(Column).Width = Len(Variables(Var.Key).txtName.Text & " - " & Languages(L.Key).Language) * 10
                        Sheet.AutoFitColumnWidth(Column)
                        Sheet.Ranges(GetExcelColumnName(Column + 1) & "1:" & GetExcelColumnName(Column + 1) & Sheet.RowCount).Style.BackColor = GetColor(LCnt)
                        If Sheet.ColumnHeaders(Column).Width < 100 Then Sheet.ColumnHeaders(Column).Width = 100
                        Select Case Variables(Var.Key).txtName.Text
                            Case "Version"
                                Sheet.Ranges(GetExcelColumnName(Column + 1) & "1:" & GetExcelColumnName(Column + 1) & Sheet.RowCount).IsReadonly = True
                            Case "File_Name"
                                Sheet.Ranges(GetExcelColumnName(Column + 1) & "1:" & GetExcelColumnName(Column + 1) & Sheet.RowCount).IsReadonly = True
                        End Select
                    End If
                Next
            Next
        End If

        Dim Row As Integer = -1
        For Each A As KeyValuePair(Of String, Ad) In Ads
            With Ads(A.Key)
                Row += 1
                Sheet.RowHeaders(Row).Text = .Value
                Sheet.Ranges("A" & (Row + 1)).Data = Ads(A.Key).Label
                Ads(A.Key).LoadAd(Row, Headers)
            End With
        Next


        Sheet.CreateColumnFilter(0, Column, 0)

        Sheet.DeleteRows(Row + 1, Sheet.RowCount - (Row + 1))
        Sheet.DeleteColumns(Column + 1, Sheet.ColumnCount - (Column + 1))


        'AddHandler Sheet.CellDataChanged, AddressOf EditCell
        isLoaded = True
    End Sub

    Sub EditCell(ByVal sender As Object, ByVal e As CellEventArgs)
        If isLoaded Then
            hasChanges.Checked = True
        End If
    End Sub

    Private Sub hasChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles hasChanges.CheckedChanged
        If isLoaded Then
            Select Case hasChanges.Checked
                Case True
                    btnStaging.Enabled = True
                    ParentProject.hasChanges.Checked = True
                Case False
                    btnStaging.Enabled = False
                    readyForProduction.Checked = True
            End Select
        End If
    End Sub

    Private Sub readyForProduction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles readyForProduction.CheckedChanged
        If isLoaded Then
            Select Case readyForProduction.Checked
                Case True
                    btnPromote.Enabled = True
                    ParentProject.readyForProduction.Checked = True
                Case False
                    btnPromote.Enabled = False
                    ParentProject.readyForProduction.Checked = False
            End Select
        End If
    End Sub

    Private Sub Book_KeyDown(sender As Object, e As KeyEventArgs) Handles Book.KeyDown
        hasChanged(True)
    End Sub

    Public Sub hasChanged(ByVal Value As Boolean)
        btnStaging.Enabled = Value
        ParentProject.hasChanges.Checked = Value
    End Sub

    Dim UserMsg As New UserMessage
    Public Sub InvalidateList(ByVal ErrorMessage As String)

        UserMsg.lblMessage.Visible = False
        UserMsg.txtError.Text = ErrorMessage
        UserMsg.txtError.Visible = True
        UserMsg.txtError.BringToFront()

        UserMsg.Location = New Point(
             (ParentProject.Width - UserMsg.Width) \ 2,
            (ParentProject.Height - UserMsg.Height) \ 2)

        Me.Controls.Add(UserMsg)
        UserMsg.BringToFront()
        Tool.Border.BackColor = Color.Red

    End Sub

End Class

Public Class Header

    Public Languages As String
    Public hasCulture As Boolean = False
    Public Index As Integer
    Public Name As String
    Public Variable As VariablePanel
    Sub New(ByRef _Languages As String, ByVal _Index As Integer, ByVal _Name As String, ByVal _Variable As VariablePanel)

        If _Languages <> "" Then
            Languages = _Languages
            hasCulture = True
        End If
        Variable = _Variable
        Index = _Index
        Name = _Name

    End Sub

End Class

Public Class Language

    Public ParentListManager As ListManager
    Public Language As String
    Public WithEvents chkLanguage As New System.Windows.Forms.CheckBox
    Public Country As Country
    Sub New(ByRef _Parent As ListManager, ByVal _Language As String, ByVal _Country As Country)
        ParentListManager = _Parent
        Language = _Language
        Country = _Country
        With chkLanguage
            .Text = Language
            .Checked = True
            .Margin = New Padding(0)
        End With
        ParentListManager.LanguageFlow.Controls.Add(chkLanguage)
    End Sub

    Private Sub chkLanguage_CheckedChanged(sender As Object, e As EventArgs) Handles chkLanguage.CheckedChanged

        Select Case chkLanguage.Checked
            Case True
                For Each H As KeyValuePair(Of String, Header) In ParentListManager.Headers
                    If ParentListManager.Headers(H.Key).Languages = Language Then
                        ParentListManager.Sheet.ShowColumns(ParentListManager.Headers(H.Key).Index, 1)
                    End If
                Next
            Case False
                For Each H As KeyValuePair(Of String, Header) In ParentListManager.Headers
                    If ParentListManager.Headers(H.Key).Languages = Language Then
                        ParentListManager.Sheet.HideColumns(ParentListManager.Headers(H.Key).Index, 1)
                    End If
                Next
        End Select

    End Sub

End Class