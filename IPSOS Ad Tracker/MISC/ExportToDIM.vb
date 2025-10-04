Imports System.Globalization
Imports System.Runtime.InteropServices.JavaScript
Imports System.Windows.Documents
Imports IPSOS_Ad_Tracker

Namespace Global.ExportToDIM

	Public Class ExportToDIM
		Shared Function Tabs(ByVal Length As Integer) As String
			Dim TabReturn As String = ""
			For i As Integer = 1 To Length
				TabReturn &= vbTab
			Next
			Return TabReturn
		End Function
		Shared Sub Export(ByRef Study As Project, ByVal File As String)

			Dim ExportTxt As String = $"Note:{vbCrLf}The below information is intended to be a rough scripting of the Tracker metadata, routing, and logic.{vbCrLf}This may be missing important data you'll need or include duplicate scripting.{vbCrLf}Be sure to review and test each part when implementing.{vbCrLf}{vbCrLf}{vbCrLf}"

			ExportTxt &= $"Metadata:{vbCrLf}{vbCrLf}"
			ExportTxt &= $"{Tabs(1)}Ad_Source ""[HIDDEN] Data Source"" categorical [1..1] " & "{" & "_1 ""Staging"", _2 ""Production""};" & vbCrLf & vbCrLf
			ExportTxt &= $"{Tabs(1)}Ad_Version ""Program Version:"" text [1..];" & vbCrLf & vbCrLf
			ExportTxt &= $"{Tabs(1)}Ad_User ""Last Saved By:"" text [1..];" & vbCrLf & vbCrLf
			ExportTxt &= $"{Tabs(1)}Ad_Date ""Last Saved On:"" text [1..];" & vbCrLf & vbCrLf

			For Each List As KeyValuePair(Of String, ListManager) In Study.Lists
				ExportTxt &= $"{Tabs(1)}{Study.Lists(List.Key).Name}_List [IIS_HiddenQ= true] ""[HIDDEN] Contains all listed ads"" loop [0..25] fields{vbCrLf}{Tabs(1)}({vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}'Item 0{vbCrLf}{Tabs(2)}Ad_Punch ""[HIDDEN] Ad_Punch Value"" style (Control(Type = ""SingleLineEdit"")) text [1..];{vbCrLf}{vbCrLf}"
				For i As Integer = 1 To Study.Variables.Count
					ExportTxt &= $"{Tabs(2)}'Item {i}{vbCrLf}{Tabs(2)}{Study.Variables(i).txtName.Text} ""[HIDDEN] {Study.Variables(i).txtName.Text}"" style (Control(Type = ""SingleLineEdit"")) text [1..];{vbCrLf}{vbCrLf}"
				Next
				ExportTxt &= $"{Tabs(1)}) expand grid;{vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}{Study.Lists(List.Key).Name}_Available ""[HIDDEN] {Study.Lists(List.Key).Name} Available"" categorical [0..]{vbCrLf}{Tabs(1)}{{{vbCrLf}"
				For i As Integer = 1 To 25
					ExportTxt &= $"{Tabs(2)}_{i} ""Listed Ad #{i}""{vbCrLf}"
				Next
				ExportTxt &= $"{Tabs(1)}}} ran;{vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}{Study.Lists(List.Key).Name}_Page ""[HIDDEN] Show Current Ads Available"" page( Ad_Version, Ad_User, {Study.Lists(List.Key).Name}_List);{vbCrLf}{vbCrLf}"
			Next

			ExportTxt &= $"{Tabs(1)}PN: This data is considered *ROTATED* for DP purposes.{vbCrLf}{Tabs(1)}The categorical value and label are used for data purposes to apply automated de-rotation.{vbCrLf}{Tabs(1)}All variables that will be de-rotated *must* have ""_FLD"" appended to the name (excluding loop scales).{vbCrLf}{Tabs(1)}Any labels or temporary variables that do not need de-rotating should *not* have this appended.{vbCrLf}{vbCrLf}"
			For Each List As KeyValuePair(Of String, ListManager) In Study.Lists
				ExportTxt &= $"{Tabs(1)}Ads_Loop_FLD """" loop {vbCrLf}{Tabs(1)}{{{vbCrLf}"
				For i As Integer = 1 To 25
					Select Case i
						Case 1, 21
							ExportTxt &= $"{Tabs(2)}SHOWN_{i} ""{i}st"",{vbCrLf}"
						Case 2, 22
							ExportTxt &= $"{Tabs(2)}SHOWN_{i} ""{i}nd"",{vbCrLf}"
						Case 3, 23
							ExportTxt &= $"{Tabs(2)}SHOWN_{i} ""{i}rd"",{vbCrLf}"
						Case 4 To 20, 24
							ExportTxt &= $"{Tabs(2)}SHOWN_{i} ""{i}th"",{vbCrLf}"
						Case 25
							ExportTxt &= $"{Tabs(2)}SHOWN_{i} ""{i}th""{vbCrLf}"
					End Select
				Next
				ExportTxt &= $"{Tabs(1)}}} fields{vbCrLf}{Tabs(1)}({vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}Ad_Assigned ""[HIDDEN] Ad Evaluated for this loop"" categorical [1..1] {{ [INSERT CATEGORIES HERE }};{vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}Ad_Name ""[HIDDEN] Ad_Name"" text [1..1];{vbCrLf}{vbCrLf}"
				For i As Integer = 1 To Study.Variables.Count
					If Study.Variables(i).txtName.Text <> "Ad_Name" Then
						'' Review the logic to account for the data type set for each variable:
						ExportTxt &= $"{Tabs(2)}{Study.Variables(i).txtName.Text}_FLD ""[HIDDEN] {Study.Variables(i).txtName.Text}"" categorical [1..1] {{ [INSERT CATEGORIES HERE }};{vbCrLf}{vbCrLf}"
					End If
				Next
				ExportTxt &= $"{Tabs(2)}'ADD Any Non-Imported Variables Here:{vbCrLf}{vbCrLf}{Tabs(1)}) expand grid;{vbCrLf}{vbCrLf}"
			Next


			ExportTxt &= $"{vbCrLf}{vbCrLf}Routing:{vbCrLf}{vbCrLf}"
			ExportTxt &= $"{Tabs(1)}'PN: Include this in routing before the first question for Quality Testing/Verification purposes.{vbCrLf}"
			ExportTxt &= $"{Tabs(1)}Dim cat, ReadAds,Ad,AdListDir,AdsToShow{vbCrLf}"

			For Each List As KeyValuePair(Of String, ListManager) In Study.Lists
				ExportTxt &= $"{Tabs(1)}AdListDir = ""{Study.Lists(List.Key).Name}/""{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}If TemplateProperties[{{platform}}].DataValue = ""online-stg"" Or _{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}TemplateProperties[{{platform}}].DataValue = ""stg751"" Or _{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}ServerInfo(IOM, ""platform"" ) = ""Staging01"" Or _{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}iom.Info.IsAutoAnswer Or iom.Info.IsDebug Then{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}Ad_Source = {{_1}}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}ReadAds = ReadAdFile(IOM, ""Ads/"" + AdListDir + CultureInfo + "" / "" + IOM.ProjectName + ""_Staging.txt"", CultureInfo){vbCrLf}"
				ExportTxt &= $"{Tabs(1)}Else{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}Ad_Source = {{_2}}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}ReadAds = ReadAdFile(IOM, ""Ads/"" + AdListDir + CultureInfo + ""/"" + IOM.ProjectName + ""_Production.txt"", CultureInfo){vbCrLf}"
				ExportTxt &= $"{Tabs(1)}End If{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}ImportAds(IOM, ""{Study.Lists(List.Key).Name}_List"", ReadAds){vbCrLf}{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}if idtype = {{test}} then{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}{Study.Lists(List.Key).Name}_Page.Show(){vbCrLf}"
				ExportTxt &= $"{Tabs(1)}end if{vbCrLf}{vbCrLf}"


				ExportTxt &= $"{Tabs(1)}'PN: Include this is routing where {Study.Lists(List.Key).Name} are asked:{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}'---- {Study.Lists(List.Key).Name} SECTION:{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}If idtype = {{test}} Then {Study.Lists(List.Key).Name}_List.Show(){vbCrLf}{vbCrLf}"

				ExportTxt &= $"{Tabs(1)}'----- {Study.Lists(List.Key).Name}_Available{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}If {Study.Lists(List.Key).Name}_Available.info.OffPathResponse = null Then{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}{Study.Lists(List.Key).Name}_Available.Categories.Filter = nset(Len({Study.Lists(List.Key).Name}_List.Categories)){vbCrLf}"
				ExportTxt &= $"{Tabs(2)}{Study.Lists(List.Key).Name}_Available.Response = {Study.Lists(List.Key).Name}_Available.Categories.Filter.Ran(){vbCrLf}"
				ExportTxt &= $"{Tabs(1)}Else{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}{Study.Lists(List.Key).Name}_Available.Response = {Study.Lists(List.Key).Name}_Available.info.OffPathResponse{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}End If{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}{Study.Lists(List.Key).Name}_Loop_FLD.Categories.Filter = nset(Len({Study.Lists(List.Key).Name}_Available.Response)){vbCrLf}{vbCrLf}"

				ExportTxt &= $"{Tabs(1)}AdsToShow = {Study.Lists(List.Key).Name}_Available.Response{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}hasVideo.Response = {{_2}}{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}hasStatic.Response = {{_2}}{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}hasAudio.Response = {{_2}}{vbCrLf}{vbCrLf}"

				ExportTxt &= $"{Tabs(1)}For cat = 0 To Len(AdsToShow) - 1{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}With {Study.Lists(List.Key).Name}_Loop_FLD[cat]{vbCrLf}"
				ExportTxt &= $"{Tabs(3)}.Ad_Assigned.Response = ccategorical({Study.Lists(List.Key).Name}_List[ccategorical(AdsToShow[cat])].Ad_Punch.Response.Value){vbCrLf}"
				ExportTxt &= $"{Tabs(3)}.Ad_Name.Response.Value = {Study.Lists(List.Key).Name}_List[ccategorical(AdsToShow[cat])].Ad_Name.Response.Value{vbCrLf}"
				For i As Integer = 1 To Study.Variables.Count
					If Study.Variables(i).txtName.Text <> "Punch" And
						Study.Variables(i).txtName.Text <> "Ad_Name" And
						Study.Variables(i).txtName.Text <> "Medium" And
						Study.Variables(i).txtName.Text <> "File_Name" Then
						'' Review the logic to account for the data type set for each variable:
						ExportTxt &= $"{Tabs(3)}.{Study.Variables(i).txtName.Text}_FLD.Response = ccategorical(""_"" + {Study.Lists(List.Key).Name}_List[ccategorical(AdsToShow[cat])].{Study.Variables(i).txtName.Text}.Response.Value){vbCrLf}"
					End If
				Next
				ExportTxt &= $"{Tabs(3)}If containsany(.Ad_Medium_FLD.Response, {{_1, _3, _8}}) Then hasVideo.Response = {{_1}}{vbCrLf}"
				ExportTxt &= $"{Tabs(3)}If containsany(.Ad_Medium_FLD.Response, {{_3, _5, _7}}) Then hasStatic.Response = {{_1}}{vbCrLf}"
				ExportTxt &= $"{Tabs(3)}If containsany(.Ad_Medium_FLD.Response, {{_3, _6}}) Then hasAudio.Response = {{_1}}{vbCrLf}"
				ExportTxt &= $"{Tabs(2)}End With{vbCrLf}"
				ExportTxt &= $"{Tabs(1)}Next{vbCrLf}{vbCrLf}"

			Next

			ExportTxt &= $"{vbCrLf}{vbCrLf}Functions:{vbCrLf}{vbCrLf}{Tabs(1)}'PN: Include this in your custom functions:{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(1)}Sub ImportAds(IOM, AdLoop, strFile){vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}If IOM.Info.IsDebug Then On Error GoTo PostImport{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}If IOM.Info.IsAutoAnswer Then GoTo PostImport{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}Dim AdLines 'Array Split Project Text File into Array By Lines. First Line Version Info, Second Line Header, Rest are Ads{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim AdVersionInfo 'Array Contains Split of Version Info by Tabs{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim AdVariables 'Array Contains Split of Header Info by Tabs{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim CurrentAd 'Temporary Array by Line Splitting Ad Data{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim Ad 'Current Ad Categorical Value{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim Var 'Current Variable Value{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim Data 'Current Data Value{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Dim i, j{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}AdLines = Split(strFile, mr.CrLf){vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_Version""].Response.Value = AdLines[0]{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}AdVersionInfo = split(AdLines[1],"",""){vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_User""].Response.Value = AdVersionInfo[0]{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_Date""].Response.Value = AdVersionInfo[1]{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}AdVariables = Split(AdLines[2], mr.Tab){vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}IOM.Questions[AdLoop].Categories.Filter = nset(Len(AdLines) - 4) {vbCrLf}"
			ExportTxt &= $"{Tabs(2)}For i = 3 To UBound(AdLines) - 1{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}CurrentAd = Split(AdLines[i], mr.Tab){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}If CurrentAd[0] <> """" Then{vbCrLf}"
			ExportTxt &= $"{Tabs(4)}Ad = i - 3{vbCrLf}"
			ExportTxt &= $"{Tabs(4)}For j = 0 To UBound(AdVariables) - 1{vbCrLf}"
			ExportTxt &= $"{Tabs(5)}Var = AdVariables[j]{vbCrLf}"
			ExportTxt &= $"{Tabs(5)}Data = CurrentAd[j]{vbCrLf}"
			ExportTxt &= $"{Tabs(5)}If Trim(Var) <> """" And{vbCrLf}"
			ExportTxt &= $"{Tabs(6)}Trim(Data) <> """" Then{vbCrLf}"
			ExportTxt &= $"{Tabs(6)}Select Case LCase(Var){vbCrLf}"
			ExportTxt &= $"{Tabs(7)}Case ""punch""{vbCrLf}"
			ExportTxt &= $"{Tabs(8)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""Ad_Punch""])) then IOM.Questions[AdLoop].Item[Ad].Item[""Ad_Punch""].Response.Value = Data{vbCrLf}"
			ExportTxt &= $"{Tabs(7)}Case ""ad_name""{vbCrLf}"
			ExportTxt &= $"{Tabs(8)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""Ad_Name""])) then IOM.Questions[AdLoop].Item[Ad].Item[""Ad_Name""].Response.Value = Data{vbCrLf}"
			ExportTxt &= $"{Tabs(7)}Case ""medium""{vbCrLf}"
			ExportTxt &= $"{Tabs(8)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""Medium""])) then IOM.Questions[AdLoop].Item[Ad].Item[""Medium""].Response.Value = Data{vbCrLf}"
			ExportTxt &= $"{Tabs(7)}Case ""file_name""{vbCrLf}"
			ExportTxt &= $"{Tabs(8)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""File_Name""])) then IOM.Questions[AdLoop].Item[Ad].Item[""File_Name""].Response.Value = Data{vbCrLf}"
			ExportTxt &= $"{Tabs(7)}Case Else{vbCrLf}"
			ExportTxt &= $"{Tabs(8)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[Var])) then IOM.Questions[AdLoop].Item[Ad].Item[Var].Response.Value = Data{vbCrLf}"
			ExportTxt &= $"{Tabs(6)}End Select{vbCrLf}"
			ExportTxt &= $"{Tabs(5)}End If{vbCrLf}"
			ExportTxt &= $"{Tabs(4)}Next{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}End If{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Next{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}Exit Sub{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}'PostImport:{vbCrLf}{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_Version""].Response.Value = ""1""{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_User""].Response.Value = ""user@ipsos.com""{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[""Ad_Date""].Response.Value = ctext(Now()){vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}Dim Max{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}Max = generatelongbetween(1, 10){vbCrLf}"
			ExportTxt &= $"{Tabs(2)}IOM.Questions[AdLoop].Categories.Filter = nset(Max){vbCrLf}"
			ExportTxt &= $"{Tabs(2)}For i = 1 To Max{vbCrLf}"

			ExportTxt &= $"{Tabs(3)}IOM.Questions[AdLoop].Item[i-1].Item[0].Response.Value = ""_"" + ctext(i){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""Ad_Name""])) then IOM.Questions[AdLoop].Item[i-1].Item[""Ad_Name""].Response.Value = ""Ad #"" + ctext(i){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""Medium""])) then IOM.Questions[AdLoop].Item[i-1].Item[""Medium""].Response.Value = ""_"" + ctext(i){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""File_Name""])) then IOM.Questions[AdLoop].Item[i-1].Item[""File_Name""].Response.Value = ""File "" + ctext(i){vbCrLf}"

			For i As Integer = 1 To Study.Variables.Count
				If Study.Variables(i).txtName.Text <> "Punch" And
				   Study.Variables(i).txtName.Text <> "Ad_Name" And
				   Study.Variables(i).txtName.Text <> "Medium" And
				   Study.Variables(i).txtName.Text <> "File_Name" Then
					ExportTxt &= $"{Tabs(3)}if (CheckIfQuestionExists(IOM, IOM.Questions[AdLoop].Item[i-1].Item[""{Study.Variables(i).txtName.Text}""])) then IOM.Questions[AdLoop].Item[i-1].Item[""{Study.Variables(i).txtName.Text}""].Response.Value = ctext(generatelongbetween(1,9)){vbCrLf}"
				End If
			Next
			ExportTxt &= $"{Tabs(2)}Next{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(1)}End Sub{vbCrLf}{vbCrLf}"


			ExportTxt &= $"{Tabs(1)}Function ReadAdFile(IOM, strFile, CCInfo){vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}If IOM.Info.IsAutoAnswer Or{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}IOM.Info.IsDebug Then On Error GoTo PostAdRead{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(3)}Dim projectName, url{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}projectName = IOM.ProjectName{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}url = ""https://cdn.ipsosinteractive.com/projects/"" + projectName + ""/"" + strFile{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(3)}Dim xmlhttp{vbCrLf}"
			ExportTxt &= $"{Tabs(3)}set xmlhttp = SetXmlHttpObject(IOM){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}xmlhttp.open(""GET"", url, True){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}xmlhttp.send(){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}ServerWaitForResponse(xmlhttp, 5){vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(3)}If CText(xmlhttp.readystate) = ""4"" Then  'checks if the response is not null {vbCrLf}"
			ExportTxt &= $"{Tabs(3)}If CText(xmlhttp.status) = ""200"" Then{vbCrLf}"
			ExportTxt &= $"{Tabs(4)}ReadAdFile = CText(xmlhttp.responseText){vbCrLf}"
			ExportTxt &= $"{Tabs(3)}End If{vbCrLf}"
			ExportTxt &= $"{Tabs(2)}End If{vbCrLf}{vbCrLf}"

			ExportTxt &= $"{Tabs(2)}PostAdRead:{vbCrLf}"

			ExportTxt &= $"{Tabs(1)}End Function{vbCrLf}{vbCrLf}"

			My.Computer.FileSystem.WriteAllText(File, ExportTxt, False)

		End Sub

	End Class

End Namespace
