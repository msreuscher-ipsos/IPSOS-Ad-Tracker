Imports GlobalRefs.GlobalFunctions
Imports unvell.ReoGrid
Imports unvell.ReoGrid.CellTypes
Imports unvell.ReoGrid.DataFormat
Public Class Ad

    Public ParentListManager As ListManager
    Public Sheet As unvell.ReoGrid.Worksheet

    Public Headers As New Dictionary(Of String, Header)
    Public Cells As New Dictionary(Of Integer, Cell)

    Public Row As Integer
    Public Index As Integer
    Public isNew As Boolean
    Public isUpdated As Boolean = False
    Public include As Boolean = True

    WithEvents btnRemove As New ButtonCell("Remove")

    Public Value As String
    Public Label As String

    Public Countries As New Dictionary(Of String, Country)
    Public Languages As New Dictionary(Of String, String)

    Sub New(ByRef _Parent As ListManager,
            ByRef _Countries As Dictionary(Of String, Country),
            ByVal _Value As String,
            ByVal _Label As String)

        ParentListManager = _Parent
        Sheet = ParentListManager.Book.Worksheets(0)
        Countries = _Countries
        Value = _Value
        Label = _Label

        For Each C As KeyValuePair(Of String, Country) In Countries
            With Countries(C.Key)
                For Each L As KeyValuePair(Of String, String) In .Languages
                    If Not Languages.ContainsKey(L.Key) Then
                        Languages.Add(L.Key, L.Key)
                    End If
                Next
            End With
        Next

    End Sub

    Sub LoadAd(ByVal _Row As Integer, ByRef _Headers As Dictionary(Of String, Header))

        Headers = _Headers
        Row = _Row

        For Each C As KeyValuePair(Of String, Header) In Headers
            With Headers(C.Key)
                Dim CurrentColumn As String = GetExcelColumnName(.Index + 1)
                Dim CurrentCell As unvell.ReoGrid.Cell = Sheet.Cells(CurrentColumn & (Row + 1))
                Dim NewCell As New Cell(Me, Headers(C.Key), Sheet, CurrentCell, Row, Headers(C.Key).Languages)
                Cells.Add(Headers(C.Key).Index, NewCell)
            End With
        Next

    End Sub

End Class

Public Class Cell

    Public ParentAd As Ad
    Public Head As Header
    Public WithEvents Sheet As unvell.ReoGrid.Worksheet
    Public WithEvents Cell As unvell.ReoGrid.Cell
    Public Value As String = ""
    Public Row As Integer
    Public Language As String

    Public isFile As Boolean = False
    Public isMedium As Boolean = False

    WithEvents dropdown As New DropdownListCell()
    Sub New(ByRef _Parent As Ad,
            ByRef _Header As Header,
            ByRef _Sheet As unvell.ReoGrid.Worksheet,
            ByRef _Cell As unvell.ReoGrid.Cell,
            ByVal _Row As Integer,
            ByVal _Language As String)

        ParentAd = _Parent
        Head = _Header
        Sheet = _Sheet
        Cell = _Cell
        Row = _Row
        Language = _Language

        Files = New FileSelect(ParentAd, Language)
        SetCellFormat()

    End Sub


    Sub UpdateFileCell()
        Sheet.Ranges(Cell.Address).Data = NewCell
        RemoveHandler NewCell.Click, AddressOf GetFileName
        AddHandler NewCell.Click, AddressOf GetFileName
    End Sub

    Dim NewCell As New HyperlinkCell("Click to add file(s)", False)
    Sub SetCellFormat()

        With Head.Variable
            Select Case CType(.boxType.SelectedItem, DataType).Value
                Case 1 '"Text"
                Case 2 '"Punch/Categorical"
                    If .txtName.Text = "Medium" Then isMedium = True
                    If .PList.Punches.Count > 0 Then
                        For Each P As KeyValuePair(Of Integer, Punch) In .PList.Punches
                            dropdown.Items.Add(.PList.Punches(P.Key))
                        Next
                        Sheet.Ranges(Cell.Address).Data = dropdown
                        AddHandler dropdown.SelectedItemChanged, AddressOf DropDownChanged
                    End If
                Case 3 '"Number"
                    Dim TmpForm As New NumberDataFormatter.NumberFormatArgs
                    TmpForm.DecimalPlaces = 0
                    TmpForm.UseSeparator = True
                    Sheet.SetRangeDataFormat(Cell.Address, CellDataFormatFlag.Number, TmpForm)
                    Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                Case 4 '"Yes/No"
                    Sheet.Ranges(Cell.Address).Data = New CheckBoxCell()
                    If Head.Variable.txtName.Text = "Show_Ad" Then
                        Sheet.Ranges(Cell.Address).Data = True
                    End If
                    Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                Case 5 '"Date/Time"
                    Sheet.Cells(Cell.Address).DataFormat = CellDataFormatFlag.DateTime
                    Sheet.Ranges(Cell.Address).Data = New DatePickerCell
                    Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                Case 6 '"File Upload"
                    isFile = True
                    If ParentAd.Languages.ContainsKey(Head.Languages) Then
                        Sheet.Ranges(Cell.Address).Data = NewCell
                        Dim Border As New RangeBorderStyle
                        Border.Color = Color.Red
                        Border.Style = BorderLineStyle.Solid
                        Sheet.SetRangeBorders(Cell.Address, BorderPositions.All, Border)
                        AddHandler NewCell.Click, AddressOf GetFileName
                        Sheet.Ranges(Cell.Address).Style.TextColor = Color.Red
                        NewCell.ActivateColor = Color.DarkGoldenrod
                        Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                    Else
                        Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                        Sheet.Ranges(Cell.Address).Data = "--------------"
                        Sheet.Ranges(Cell.Address).IsReadonly = True
                    End If
            End Select
        End With

        'AddHandler Cell..CellKeyUp, AddressOf UpdateCell

    End Sub

    Public Sub DropDownChanged(sender As Object, e As EventArgs)
        If ParentAd.ParentListManager.isLoaded Then
            ParentAd.ParentListManager.hasChanges.Checked = True
        End If
    End Sub

    Public Files As FileSelect
    Private Sub GetFileName(sender As Object, e As EventArgs)

        Files.ShowDialog()
        CleanCell()

    End Sub

    Public Sub CleanCell()

        If Files.Files.Count > 0 Then
            Dim Border As New RangeBorderStyle
            Border.Color = Color.Green
            Border.Style = BorderLineStyle.Solid
            NewCell.VisitedColor = Color.Green
            Sheet.Ranges(Cell.Address).Style.TextColor = Color.Green
            Sheet.SetRangeBorders(Cell.Address, BorderPositions.All, Border)
            Sheet.Ranges(Cell.Address).Data = "Click to view file(s)"
        Else
            Dim Border As New RangeBorderStyle
            Border.Color = Color.Red
            Border.Style = BorderLineStyle.Solid
            NewCell.VisitedColor = Color.Red
            Sheet.Ranges(Cell.Address).Style.TextColor = Color.Red
            Sheet.SetRangeBorders(Cell.Address, BorderPositions.All, Border)
            Sheet.Ranges(Cell.Address).Data = "Click to add file(s)"
        End If

    End Sub

    Public Sub LoadFiles(ByVal _Files As String)

        Dim LoadFiles() As String = Split(_Files, ",")
        For Each File As String In LoadFiles
            If File <> "" Then
                Files.Add(File)
            End If
        Next

        CleanCell()

    End Sub


End Class


