dim sourseFolderPath
'sourseFolderPath = "C:\Program Files (x86)\Интеллект\Bmp\Person"
dim intellectBmpFolderPath
intellectBmpFolderPath = "C:\Program Files (x86)\Интеллект\Bmp\Person"
dim resultFolder
'resultFolder = "M:\Projecs\UfoService\UfoService\WorkResult"

Dim imagePath
imagePath = ""
Dim year
year = "2020"
Dim guid
guid = "{00000000-0000-0000-0000-000000000000}"
Dim objArgs
Set objArgs = WScript.Arguments

Dim i
For i=0 to objArgs.Count-1
	If i=0 Then
		imagePath = objArgs(i)
	ElseIf objArgs(i) = "-y" Then
		year = objArgs(i+1)
	ElseIf objArgs(i) = "-g" Then
		guid = objArgs(i+1)
	End If
Next

If guid = "{00000000-0000-0000-0000-000000000000}" Then
	guid = Mid(imagePath, InStrRev(imagePath,"\"), Len(guid)-1)
End If

resultFolder = Mid(imagePath, 1, Len(imagePath)-InStrRev(imagePath,"\")+1)
'MsgBox(resultFolder)

set FSO = CreateObject("Scripting.FileSystemObject")
' set WshShell = CreateObject("WScript.Shell")
' dim CurrDirPath
' CurrDirPath = WshShell.CurrentDirectory
' set objDestFolder  = FSO.GetFolder(CurrDirPath) 'папка откуда запускаетсІ скрипт
'dim targetFilePath
'targetFilePath = "C:\" & year & ".jpg"

dim sourseFilePath
sourseFilePath = sourseFolderPath  & "\" & year & ".bmp"
'WScript.Echo("sourseFolderPath: " & sourseFolderPath)
set sourseFile = FSO.GetFile(imagePath)

dim logFilePath
logFilePath = resultFolder & "\" & guid & ".log"

Const ForReading = 1
Const ForWriting = 2
Const ForAppanding = 8
Const CreateNew = true
Const Overwrite = true
Const DoNotCreateNew = false

'WScript.Echo("Script's started work")
set f = FSO.OpenTextFile(logFilePath, ForAppanding,CreateNew)
f.WriteLine("Скрипт запущен")
For i=0 to 10
	WScript.Sleep 1000
	If i = 0 Then
		f.Write(i)
	Else
		f.Write("," & i)
	End If		
Next
f.WriteLine("")
f.Close()


dim htmlContent
htmlContent = "<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=utf-8'><head><title>Результат работы скрипта</title></head><body><table style='width:30%;'><tr><td>Фото</td><td>Информация</td></tr><tr><td style='width:30%'><img src='data:image/jpeg;base64," & _
GetBase64TextFromFile(imagePath) & _
"'></td><td>Файл:<br>" & _
imagePath & "<br></td></tr></table></body></html>"

dim resultFilePath
resultFilePath = resultFolder & "\" & guid & ".html"
set f = FSO.CreateTextFile(resultFilePath, Overwrite)
f.Write(htmlContent)
f.Close()


set f = FSO.OpenTextFile(logFilePath, ForAppanding,DoNotCreateNew)
f.WriteLine("Скрипт завершил работу")
f.Close()
'WScript.Echo("Script's ended work")

'sourseFile.Copy(targetFilePath)

'Base64EncodeFile(sourseFilePath)

'WScript.Echo(Base64Encode(readBinary(sourseFilePath)))
'WScript.Echo(Base64Encode(year))

Function readBinary(strPath)

    Dim oFSO: Set oFSO = CreateObject("Scripting.FileSystemObject")
    Dim oFile: Set oFile = oFSO.GetFile(strPath)

    If IsNull(oFile) Then MsgBox("File not found: " & strPath) : Exit Function

    With oFile.OpenAsTextStream()
        readBinary = .Read(oFile.Size)
        .Close
    End With

End Function

Function GetBase64TextFromFile(filePath)
    Const adTypeBinary      = 1     ' Binary file is encoded

	' Variables for writing base64 code to file
	'Dim objFSO
	'Dim objFileOut

	' Variables for encoding
	Dim objXML
	Dim objDocElem

	' Variable for reading binary picture
	Dim objStream

	' Open data stream from picture
	Set objStream = CreateObject("ADODB.Stream")
	objStream.Type = adTypeBinary
	objStream.Open()
	objStream.LoadFromFile(filePath)

	' Create XML Document object and root node
	' that will contain the data
	Set objXML = CreateObject("MSXml2.DOMDocument")
	Set objDocElem = objXML.createElement("Base64Data")
	objDocElem.dataType = "bin.base64"

	' Set binary value
	objDocElem.nodeTypedValue = objStream.Read()
	GetBase64TextFromFile = objDocElem.text
	
	' Open data stream to base64 code file
	'Set objFSO = CreateObject("Scripting.FileSystemObject")
	'Set objFileOut = objFSO.CreateTextFile("C:\encoded.txt", fsDoOverwrite, fsAsASCII)

	' Get base64 value and write to file
	'objFileOut.Write objDocElem.text
	'objFileOut.Close()

	
	
	' Clean all
	'Set objFSO = Nothing
	'Set objFileOut = Nothing
	Set objXML = Nothing
	Set objDocElem = Nothing
	Set objStream = Nothing
End Function

Function Base64EncodeFileToFile(filePath)
    Const fsDoOverwrite     = true  ' Overwrite file with base64 code
	Const fsAsASCII         = false ' Create base64 code file as ASCII file
	Const adTypeBinary      = 1     ' Binary file is encoded

	' Variables for writing base64 code to file
	Dim objFSO
	Dim objFileOut

	' Variables for encoding
	Dim objXML
	Dim objDocElem

	' Variable for reading binary picture
	Dim objStream

	' Open data stream from picture
	Set objStream = CreateObject("ADODB.Stream")
	objStream.Type = adTypeBinary
	objStream.Open()
	objStream.LoadFromFile(filePath)

	' Create XML Document object and root node
	' that will contain the data
	Set objXML = CreateObject("MSXml2.DOMDocument")
	Set objDocElem = objXML.createElement("Base64Data")
	objDocElem.dataType = "bin.base64"

	' Set binary value
	objDocElem.nodeTypedValue = objStream.Read()

	' Open data stream to base64 code file
	Set objFSO = CreateObject("Scripting.FileSystemObject")
	Set objFileOut = objFSO.CreateTextFile("C:\encoded.txt", fsDoOverwrite, fsAsASCII)

	' Get base64 value and write to file
	objFileOut.Write objDocElem.text
	objFileOut.Close()

	' Clean all
	Set objFSO = Nothing
	Set objFileOut = Nothing
	Set objXML = Nothing
	Set objDocElem = Nothing
	Set objStream = Nothing
End Function

Function Base64Encode(sText)
    Dim oXML, oNode

    Set oXML = CreateObject("Msxml2.DOMDocument.3.0")
    Set oNode = oXML.CreateElement("base64")
    oNode.dataType = "bin.base64"
    oNode.nodeTypedValue =Stream_StringToBinary(sText)
    Base64Encode = oNode.text
    Set oNode = Nothing
    Set oXML = Nothing
End Function

Function Base64Decode(ByVal vCode)
    Dim oXML, oNode

    Set oXML = CreateObject("Msxml2.DOMDocument.3.0")
    Set oNode = oXML.CreateElement("base64")
    oNode.dataType = "bin.base64"
    oNode.text = vCode
    Base64Decode = Stream_BinaryToString(oNode.nodeTypedValue)
    Set oNode = Nothing
    Set oXML = Nothing
End Function

'Stream_StringToBinary Function
'2003 Antonin Foller, http://www.motobit.com
'Text - string parameter To convert To binary data
Function Stream_StringToBinary(Text)
  Const adTypeText = 2
  Const adTypeBinary = 1

  'Create Stream object
  Dim BinaryStream 'As New Stream
  Set BinaryStream = CreateObject("ADODB.Stream")

  'Specify stream type - we want To save text/string data.
  BinaryStream.Type = adTypeText

  'Specify charset For the source text (unicode) data.
  BinaryStream.CharSet = "us-ascii"

  'Open the stream And write text/string data To the object
  BinaryStream.Open
  BinaryStream.WriteText Text

  'Change stream type To binary
  BinaryStream.Position = 0
  BinaryStream.Type = adTypeBinary

  'Ignore first two bytes - sign of
  BinaryStream.Position = 0

  'Open the stream And get binary data from the object
  Stream_StringToBinary = BinaryStream.Read

  Set BinaryStream = Nothing
End Function

'Stream_BinaryToString Function
'2003 Antonin Foller, http://www.motobit.com
'Binary - VT_UI1 | VT_ARRAY data To convert To a string 
Function Stream_BinaryToString(Binary)
  Const adTypeText = 2
  Const adTypeBinary = 1

  'Create Stream object
  Dim BinaryStream 'As New Stream
  Set BinaryStream = CreateObject("ADODB.Stream")

  'Specify stream type - we want To save binary data.
  BinaryStream.Type = adTypeBinary

  'Open the stream And write binary data To the object
  BinaryStream.Open
  BinaryStream.Write Binary

  'Change stream type To text/string
  BinaryStream.Position = 0
  BinaryStream.Type = adTypeText

  'Specify charset For the output text (unicode) data.
  BinaryStream.CharSet = "us-ascii"

  'Open the stream And get text/string data from the object
  Stream_BinaryToString = BinaryStream.ReadText
  Set BinaryStream = Nothing
End Function