Imports System.Windows.Documents
Imports GlobalRefs.GlobalFunctions
Imports IPSOS_Ad_Tracker
Imports WinSCP

Namespace Global.GlobalRefs

    Public Class GlobalFunctions
        Shared Function GetExcelColumnName(columnNumber As Integer) As String
            Dim dividend As Integer = columnNumber
            Dim columnName As String = String.Empty
            Dim modulo As Integer

            While dividend > 0
                modulo = (dividend - 1) Mod 26
                columnName = Convert.ToChar(65 + modulo).ToString() & columnName
                dividend = CInt((dividend - modulo) / 26)
            End While

            Return columnName
        End Function

        Shared Function GetColor(i As Integer) As Color

            Select Case (i + 2) Mod 2
                Case 0
                    Return Color.FloralWhite
                Case 1
                    Return Color.Lavender
            End Select

        End Function

        Public Enum MediaType
            TV = 1
            OLV = 2
            Digital = 3
            Social = 4
            Print = 5
            Audio = 6
            OOH = 7
            Cinema = 8
            Other = 9
        End Enum


    End Class

    Public Class Export

        Shared Sub StartExport(ByRef Study As Project)

            Dim localDateTime As DateTime = DateTime.Now ' Get current local time
            Dim convertedUtcDateTime As DateTime = localDateTime.ToUniversalTime()
            Study.LoadDate = convertedUtcDateTime

            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt") Then
                Try
                    My.Computer.FileSystem.RenameFile("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt", Study.SID & "_Version.txt." & Study.VersionMinor.Value)
                Catch ex As Exception
                End Try
            End If

            Study.VersionMinor.Value += 0.01
            CreateLocalProjectFolder(Study)

            Dim StudySettings As String = ""
            StudySettings &= "User: " & Study.UserName & vbCrLf
            StudySettings &= "Staging: " & Study.VersionMinor.Value & vbCrLf
            StudySettings &= "Production: " & Study.VersionMajor.Value & vbCrLf
            StudySettings &= "Max:" & Study.MaximumCategories & vbCrLf
            StudySettings &= "Variables: "

            Dim QCnt As Integer = 0
            StudySettings &= $"0,Punch,False,Number,False;"
            For Each Q As KeyValuePair(Of Integer, VariablePanel) In Study.Variables
                QCnt += 1
                With Study.Variables(Q.Key)
                    If .PList.Punches.Count > 0 Then
                        Dim PString As String = ""
                        For Each P As KeyValuePair(Of Integer, Punch) In .PList.Punches
                            PString &= $"|{ .PList.Punches(P.Key).txtValue.Text}:{ .PList.Punches(P.Key).txtLabel.Text}"
                        Next
                        PString = Mid(PString, 2)
                        StudySettings &= $"{QCnt},{ .txtName.Text},{ .allowChanges},{ CType(.boxType.SelectedItem, DataType).Value},{ .chkCultured.Checked},{PString};"
                    Else
                        StudySettings &= $"{QCnt},{ .txtName.Text},{ .allowChanges},{ CType(.boxType.SelectedItem, DataType).Value},{ .chkCultured.Checked};"
                    End If
                End With
            Next
            StudySettings &= vbCrLf

            StudySettings &= "Lists: "
            For Each L As KeyValuePair(Of String, ListManager) In Study.Lists
                Dim ListText As String = ""
                With Study.Lists(L.Key)
                    StudySettings &= .Name & ","
                    For Each Lang As KeyValuePair(Of String, Language) In .Languages
                        If Study.Lists(L.Key).Languages(Lang.Key).chkLanguage.Checked Then
                            CreateLocalCultureFiles(Study, Study.Lists(L.Key), .Languages(Lang.Key))
                        End If
                    Next
                End With
            Next

            StudySettings &= vbCrLf & "Excludes: "
            For Each L As KeyValuePair(Of String, ListManager) In Study.ExcludeLists
                With Study.ExcludeLists(L.Key)
                    StudySettings &= .Name & ","
                End With
            Next


            My.Computer.FileSystem.WriteAllText("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt", StudySettings, False)

            StartUpload(Study)
            Study.hasChanges.Checked = False
            For Each L As KeyValuePair(Of String, ListManager) In Study.Lists
                Study.Lists(L.Key).hasChanges.Checked = False
            Next

        End Sub

        Shared Sub StartPromotion(ByRef Study As Project)

            Dim localDateTime As DateTime = DateTime.Now ' Get current local time
            Dim convertedUtcDateTime As DateTime = localDateTime.ToUniversalTime()
            Study.LoadDate = convertedUtcDateTime

            Dim PBar As New Progress
            PBar.StartPosition = FormStartPosition.Manual
            PBar.Location = New Point(
            Study.ParentManager.Location.X + (Study.ParentManager.Width - PBar.Width) \ 2,
            Study.ParentManager.Location.Y + (Study.ParentManager.Height - PBar.Height) \ 2)
            PBar.Show()
            PBar.Add("Promoting to Production for " & Study.SID)

            Dim SFTP As New SFTPWinSCP
            Dim FTPDirectory As String = "/projects/" & Study.SID

            SFTP.Session(Study.UserName, Study.Password, Study.IntroPage.boxServer.Text)

            If SFTP.DirectoryExists(Study, FTPDirectory) = False Then
                PBar.Add("FTP Folder does not exist.")
                PBar.Add("Stopping process.")
                PBar.Close()
                Exit Sub
            End If

            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt") Then
                Dim SplitMinor() As String = Split(My.Computer.FileSystem.ReadAllText("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt"), vbCrLf)
                Dim ProductionFile As String = Study.UserName & vbCrLf &
                                               "Staging: "(Study.VersionMajor.Value + 1) & ".0" & vbCrLf &
                                               "Production: " & (Study.VersionMajor.Value + 1) & vbCrLf
                For i = 3 To UBound(SplitMinor)
                    ProductionFile &= SplitMinor(i) & vbCrLf
                Next
                My.Computer.FileSystem.RenameFile("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt", Study.SID & "_Version.txt." & Study.VersionMinor.Value)
                My.Computer.FileSystem.WriteAllText("C:\Ad Loader\" & Study.SID & "\Ads\" & Study.SID & "_Version.txt", ProductionFile, False)

                For Each L As KeyValuePair(Of String, ListManager) In Study.Lists
                    With Study.Lists(L.Key)
                        For Each Lang As KeyValuePair(Of String, Language) In .Languages
                            If Study.Lists(L.Key).Languages(Lang.Key).chkLanguage.Checked Then
                                Dim FileDir As String = "C:\Ad Loader\" & Study.SID & "\Ads\" & .Name & "\" & Lang.Key & "\"
                                SplitMinor = Split(My.Computer.FileSystem.ReadAllText(FileDir & Study.SID & "_Staging.txt"), vbCrLf)
                                ProductionFile = (Study.VersionMajor.Value + 1) & ".0" & vbCrLf &
                                                 Study.UserName & "," &
                                                 Study.LoadDate & "," &
                                                .lblTitle.Text & "," &
                                                .Languages(Lang.Key).Country.Code & ":" & .Languages(Lang.Key).Country.Name & "," &
                                                .Languages(Lang.Key).Language & vbCrLf
                                For i = 2 To UBound(SplitMinor)
                                    ProductionFile &= SplitMinor(i) & vbCrLf
                                Next
                                If My.Computer.FileSystem.FileExists(FileDir & Study.SID & "_Production.txt") Then My.Computer.FileSystem.RenameFile(FileDir & Study.SID & "_Production.txt", Study.SID & "_Production.txt." & Study.VersionMajor.Value)
                                My.Computer.FileSystem.WriteAllText(FileDir & Study.SID & "_Production.txt", ProductionFile, False)
                            End If
                        Next
                    End With
                Next
            Else
                PBar.Add("Study File does not exist.")
                PBar.Add("Stopping process.")
                PBar.Close()
                Exit Sub
            End If
            Study.VersionMajor.Value += 1
            Study.VersionMinor.Value = Study.VersionMajor.Value

            PBar.Add("Synchronizating FTP Files with Local Files.")
            SFTP.Sync(Study, New Progress, SynchronizationMode.Remote, "C:\Ad Loader\" & Study.SID, FTPDirectory)

            PBar.Close()

        End Sub

        Shared Sub StartUpload(ByRef Study As Project)

            Dim PBar As New Progress
            PBar.StartPosition = FormStartPosition.Manual
            PBar.Location = New Point(
            Study.ParentManager.Location.X + (Study.ParentManager.Width - PBar.Width) \ 2,
            Study.ParentManager.Location.Y + (Study.ParentManager.Height - PBar.Height) \ 2)
            PBar.Show()
            PBar.Add("Loading to Staging for " & Study.SID)


            Dim SFTP As New SFTPWinSCP
            Dim FTPDirectory As String = "/projects/" & Study.SID

            SFTP.Session(Study.UserName, Study.Password, Study.FTP)

            If SFTP.DirectoryExists(Study, FTPDirectory) = False Then
                PBar.Add("Creating FTP Folder")
                SFTP.CreateDirectory(Study, FTPDirectory)
            End If

            PBar.Add("Synchronizating FTP Files with Local Files.")
            SFTP.Sync(Study, New Progress, SynchronizationMode.Remote, "C:\Ad Loader\" & Study.SID, FTPDirectory)

            PBar.Close()
            Study.hasChanges.Checked = False
        End Sub

        Shared Sub CreateLocalProjectFolder(ByRef Study As Project)

            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID) = False Then
                My.Computer.FileSystem.CreateDirectory("C:\Ad Loader\" & Study.SID)
            End If

            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads") = False Then
                My.Computer.FileSystem.CreateDirectory("C:\Ad Loader\" & Study.SID & "\Ads")
            End If

            For Each L As KeyValuePair(Of String, ListManager) In Study.Lists
                With Study.Lists(L.Key)
                    If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads\" & .Name) = False Then
                        My.Computer.FileSystem.CreateDirectory("C:\Ad Loader\" & Study.SID & "\Ads\" & .Name)
                    End If
                    For Each Lang As KeyValuePair(Of String, Language) In .Languages
                        If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads\" & .Name & "\" & .Languages(Lang.Key).Language) = False Then
                            My.Computer.FileSystem.CreateDirectory("C:\Ad Loader\" & Study.SID & "\Ads\" & .Name & "\" & .Languages(Lang.Key).Language)
                        End If
                    Next
                End With
            Next

        End Sub


        Shared Function CreateLocalCultureFiles(ByRef Study As Project, ByRef _List As ListManager, ByRef _Language As Language) As String

            Dim CultureSettings As String = Study.VersionMinor.Value & vbCrLf &
                                            Study.UserName & "," &
                                            Study.LoadDate & "," &
                                            _List.lblTitle.Text & "," &
                                            _Language.Country.Code & ":" & _Language.Country.Name & "," &
                                            _Language.Language & vbCrLf

            With _List

                CultureSettings &= "Punch" & vbTab
                'Build Header:
                For Each H As KeyValuePair(Of String, Header) In .Headers
                    If LCase(_Language.Language) <> LCase(.Headers(H.Key).Languages) Then
                        CultureSettings &= .Headers(H.Key).Name & vbTab
                    End If
                Next

                CultureSettings &= vbCrLf

                'Write Rows:
                For Each A As KeyValuePair(Of String, Ad) In .Ads
                    CultureSettings &= .Ads(A.Key).Value & vbTab

                    For Each H As KeyValuePair(Of String, Header) In .Ads(A.Key).Headers
                        If LCase(_Language.Language) = LCase(.Headers(H.Key).Languages) Or
                           Trim(.Headers(H.Key).Languages) = "" Then
                            If .Ads(A.Key).Cells(.Headers(H.Key).Index).isFile Then
                                If .Ads(A.Key).include Then
                                    CultureSettings &= .Ads(A.Key).Cells(.Headers(H.Key).Index).Files.GetFiles & vbTab
                                End If
                            Else
                                If .Ads(A.Key).include Then
                                    If .Ads(A.Key).Cells(.Headers(H.Key).Index).isDrop Then
                                        If Not .Ads(A.Key).Cells(.Headers(H.Key).Index).Cell.Data Is Nothing Then
                                            If .Ads(A.Key).Cells(.Headers(H.Key).Index).Cell.Data.ToString <> "" Then
                                                CultureSettings &= CType(.Ads(A.Key).Cells(.Headers(H.Key).Index).Cell.Data, Punch).txtValue.Text & vbTab
                                            Else
                                                CultureSettings &= vbTab
                                            End If
                                        Else
                                            CultureSettings &= vbTab
                                        End If
                                    Else
                                        CultureSettings &= .Ads(A.Key).Cells(.Headers(H.Key).Index).Cell.Data & vbTab
                                        End If
                                    End If
                                End If
                        End If
                    Next
                    CultureSettings &= vbCrLf
                Next
            End With

            If My.Computer.FileSystem.FileExists("C:\Ad Loader\" & Study.SID & "\Ads\" & _List.Name & "\" & _Language.Language & "\" & Study.SID & "_Staging.txt") Then
                Try
                    My.Computer.FileSystem.RenameFile("C:\Ad Loader\" & Study.SID & "\Ads\" & _List.Name & "\" & _Language.Language & "\" & Study.SID & "_Staging.txt", Study.SID & "_Staging.txt." & Study.VersionMinor.Value)
                Catch ex As Exception
                End Try
            End If

            My.Computer.FileSystem.WriteAllText("C:\Ad Loader\" & Study.SID & "\Ads\" & _List.Name & "\" & _Language.Language & "\" & Study.SID & "_Staging.txt", CultureSettings, False)

            Return ""

        End Function

    End Class

End Namespace

