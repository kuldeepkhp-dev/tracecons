<%
Class PGSearchResponse

	private  mstrRespCode
	private  mstrRespMessage
	Dim moPGResponseObjects
	

	public Function getRespCode()
		getRespCode =	mstrRespCode
	End Function

	public Function setRespCode(astrRespCode)
		mstrRespCode =	astrRespCode
	End Function

	public Function getRespMessage()
		getRespMessage =	mstrRespMessage
	End Function

	public Function setRespMessage(astrRespMessage)
		mstrRespMessage =	astrRespMessage
	End Function

	public Function getPGResponseObjects()
		If(IsObject(moPGResponseObjects)) Then
			set getPGResponseObjects =	moPGResponseObjects
		Else
			 set moPGResponseObjects= Nothing
			 set getPGResponseObjects = moPGResponseObjects 
		End If
	End Function

	public Function setPGResponseObjects(aoPGResponseObjects)
			moPGResponseObjects =	aoPGResponseObjects
	End Function
	
	public Function getSearchResponse(strResponse)
		pos = InStr (strResponse,vbLf)
		If(pos = 0) Then
			strResponse = strResponse & vbLf
		End If
		oItems=split(strResponse,vbLf)
		maxcounter=ubound(oItems)
		Dim oPGResponse
		
		
		index = 1
		Key = 0
		For counter=0 TO maxcounter-1 
			strItem = oItems(counter)
			strItem	=	Replace(strItem, vbTab, "")
			strItem = Trim (strItem)
			Set oPGResponse = New PGResponse
			oPGResponse.getResponse(strItem)
				If (index=1) Then
					mstrRespCode = oPGResponse.getRespCode()
					mstrRespMessage = oPGResponse.getRespMessage()
					
					If (mstrRespCode = 0) Then
						Set moPGResponseObjects = CreateObject("Scripting.Dictionary")
					Else
						exit Function
					End If
				Else
					moPGResponseObjects.Add Key,oPGResponse
				End If
				
				index = index+1
				Key = Key+1
		Next

	End Function
	'Sub Logger(description)
	'	message="At " & Now
	'	strtoday= Month(Now()) & "-" & Day(Now())& "-" & Year(Now())
	'	Set objFile = Server.CreateObject("Scripting.FileSystemObject")
	'	strFile =  strtoday & ".log"
	'	Set objLog = objFile.OpenTextFile(Server.MapPath(strFile),8,True)
		
	'	objLog.writeLine message & description
	'	objLog.Close

	'End Sub

End Class
%>