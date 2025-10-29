Imports GlobalRefs.GlobalFunctions
Imports unvell.ReoGrid
Imports unvell.ReoGrid.CellTypes
Imports unvell.ReoGrid.DataFormat
Imports unvell.ReoGrid.IO.OpenXML.Schema
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
    Public isDrop As Boolean = False

    Public WithEvents dropdown As New DropdownListCell()
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

        'Files = New FileSelect(ParentAd, Language)
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
                        isDrop = True
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
                    If .chkCultured.Checked Then
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
                    Else
                        Sheet.Ranges(Cell.Address).Data = NewCell
                        Dim Border As New RangeBorderStyle
                        Border.Color = Color.Red
                        Border.Style = BorderLineStyle.Solid
                        Sheet.SetRangeBorders(Cell.Address, BorderPositions.All, Border)
                        AddHandler NewCell.Click, AddressOf GetFileName
                        Sheet.Ranges(Cell.Address).Style.TextColor = Color.Red
                        NewCell.ActivateColor = Color.DarkGoldenrod
                        Sheet.Ranges(Cell.Address).Style.HorizontalAlign = unvell.ReoGrid.ReoGridHorAlign.Center
                    End If
            End Select
        End With

        With Head.Variable
            Sheet.AutoFitColumnWidth(Head.Index, False)
            If CType(.boxType.SelectedItem, DataType).Value = 2 Or
           CType(.boxType.SelectedItem, DataType).Value = 6 Then
                'Sheet.ColumnHeaders(Head.Index).Width = Sheet.ColumnHeaders(Head.Index).Width + 100
            End If
        End With

        'AddHandler Cell..CellKeyUp, AddressOf UpdateCell

    End Sub

    Public Sub DropDownChanged(sender As Object, e As EventArgs)
        If ParentAd.ParentListManager.isLoaded Then
            ParentAd.ParentListManager.hasChanges.Checked = True
        End If
    End Sub

    'Public Files As FileSelect
    Public OpenFile As OpenFileDialog
    Public File As String = ""
    Private Sub GetFileName(sender As Object, e As EventArgs)

        'Files.ShowDialog()

        OpenFile = New OpenFileDialog
        With OpenFile
            .Title = "Select File For " & ParentAd.Label
            .Multiselect = False
            .Filter = "All Files|*.*|JPG Image File|*.jpg|PNG Image File|*.png|GIF Image File|*.gif|MOV File|*.mov|MP4 File|*.mp4|MP3 File|*.mp3"
            .FilterIndex = 0
            .FileName = ""
        End With

        If OpenFile.ShowDialog() = DialogResult.OK Then
            File = OpenFile.FileName
            ParentAd.ParentListManager.hasChanges.Checked = True
        End If
        CleanCell()

    End Sub

    Dim isNewFile As Boolean = False
    Public Sub CleanCell(ByVal Optional Update As Boolean = True)

        If Trim(File) <> "" Then

            Dim GoodColor As Color
            Select Case Update
                Case True
                    GoodColor = Color.Green
                    isNewFile = True
                Case False
                    GoodColor = Color.Blue
            End Select

            Dim Border As New RangeBorderStyle
            Border.Color = GoodColor
            Border.Style = BorderLineStyle.Solid
            NewCell.VisitedColor = GoodColor
            Sheet.Ranges(Cell.Address).Style.TextColor = GoodColor
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

        'Dim LoadFiles() As String = Split(_Files, ",")
        'For Each File As String In LoadFiles
        'If File <> "" Then
        'Files.Add(File)
        'End If
        'Next
        File = _Files
        CleanCell(False)

    End Sub

    Public Function GetFile() As String
        If isNewFile Then
            Return ConvertToHTML(File)
        Else
            Return File
        End If
    End Function


    Function ConvertToHTML(ByVal FileName As String) As String

        Dim TimeStamp As String = $"{Replace(Replace(Replace(DateTime.UtcNow, "/", "."), ":", "."), " ", ".")}"

        Dim TmpFileName As String = Mid(FileName, FileName.LastIndexOf("\") + 2)
        Dim Ext As String = Mid(FileName, FileName.LastIndexOf(".") + 2)
        TmpFileName = TmpFileName.Replace(Ext, "_" & TimeStamp & "." & Ext)

        Dim TmpProject As Project = ParentAd.ParentListManager.ParentProject
        Dim TmpListManager As ListManager = ParentAd.ParentListManager

        If Trim(Language) <> "" Then
            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName) <> True Then My.Computer.FileSystem.CopyFile(FileName, "C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName)
            Return "https://media.ipsosinteractive.com/projects/" & TmpProject.SID & "/Ads/" & TmpListManager.Name & "/" & Language & "/" & TmpFileName
        Else
            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & TmpFileName) <> True Then My.Computer.FileSystem.CopyFile(FileName, "C:\Ad Loader\" & TmpProject.SID & "\Ads\" & TmpListManager.Name & "\" & Language & "\" & TmpFileName)
            Return "https://media.ipsosinteractive.com/projects/" & TmpProject.SID & "/Ads/" & TmpListManager.Name & "/" & TmpFileName
        End If

    End Function


End Class


