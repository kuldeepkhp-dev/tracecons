<%
Class PGResponse

	private strRespCode
	private strRespMessage
	private strTxnId
	private strEPGTxnId
	private strRedirectionTxnId
	private strRedirectionUrl
	private strAuthIdCode
	private strRRN
	private strTxnType
	private strTxnDateTime

	public Function getRespCode()
		getRespCode =	strRespCode
	End Function

	public Function getRespMessage()
		getRespMessage=strRespMessage
	End Function

	public Function getTxnId()
		getTxnId=strTxnId
	End Function

	public Function getEpgTxnId()
		getEpgTxnId=strEPGTxnId
	End Function

	public Function getRedirectionTxnId()
			getRedirectionTxnId=strRedirectionTxnId
	End Function

	public Function getRedirectionUrl()
			getRedirectionUrl=strRedirectionUrl
	End Function

	public Function getAuthIdCode()
			getAuthIdCode=strAuthIdCode
	End Function

	public Function getRRN()
			getRRN=strRRN
	End Function

	public Function getTxnType()
				getTxnType=strTxnType
	End Function

	public Function getTxnDateTime()
			getTxnDateTime=strTxnDateTime
	End Function

	public sub setRespCode(astrRespCode)
		strRespCode=astrRespCode
	End sub

	public sub setRespMessage(astrRespMessage)
		strRespMessage=astrRespMessage
	End sub

	public sub setTxnId(astrTxnId)
		strTxnId=astrTxnId
	End sub

	public sub setEpgTxnId(astrEPGTxnId)
		strEPGTxnId=astrEPGTxnId
	End sub

	public sub setRedirectionTxnId(astrRedirectionTxnId)
			strRedirectionTxnId=astrRedirectionTxnId
	End sub

	public Sub setRedirectionUrl(astrRedirectionUrl)
			strRedirectionUrl = astrRedirectionUrl
	End Sub

	public sub setAuthIdCode(astrAuthIdCode)
			strAuthIdCode=astrAuthIdCode
	End sub

	public sub setRRN(astrRRN)
			strRRN=astrRRN
	End sub

	public sub setTxnType(astrTxnType)
				strTxnType=astrTxnType
	End sub

	public sub setTxnDateTime(astrTxnDateTime)
				strTxnDateTime=astrTxnDateTime
	End sub

	public Sub getResponse(strResponse)
			Dim oDictionary
			Set oDictionary = CreateObject("Scripting.Dictionary")
			oItems=split(strResponse,"&")
			maxcounter=ubound(oItems)

			For counter=0 TO maxcounter
				strTokenData = split(oItems(counter),"=")
				If(ubound(strTokenData)>0) Then
				strKey =strTokenData(0)
				strData=strTokenData(1)
				strDecodedData=URLDecode (strData)
				oDictionary.Add strKey,strDecodedData
				End If
			Next
			
				strRespCode = oDictionary.Item("RespCode")
				strRespMessage = oDictionary.Item("Message")
				strTxnId = oDictionary.Item("TxnID")
				strEPGTxnId = oDictionary.Item("ePGTxnID")
				strRedirectionTxnId = oDictionary.Item("RedirectionTxnID")
				strAuthIdCode=oDictionary.Item("AuthIdCode")
				strRRN=oDictionary.Item("RRN")
				strTxnType=oDictionary.Item("TxnType")
				strTxnDateTime=oDictionary.Item("TxnDateTime")	
	End Sub

	'Function getNextToken(strItem)
	'	oItems=split(strItem,"=")
	'	key=oItems(0)
	'	getNextToken	=	oItems(1)
	'End Function


		Function URLDecode(What)
		'URL decode Function
		'2001 Antonin Foller, PSTRUH Software, http://www.pstruh.cz
		 Dim Pos, pPos

		 'replace + To Space
		 What = Replace(What, "+", " ")

		 on error resume Next
		 Dim Stream: Set Stream = server.CreateObject("ADODB.Stream")
		 If err = 0 Then 'URLDecode using ADODB.Stream, If possible
		   on error goto 0
		   Stream.Type = 2 'String
		   Stream.Open

		   'replace all %XX To character
		   Pos = InStr(1, What, "%")
		   pPos = 1
		   Do While Pos > 0
			 Stream.WriteText Mid(What, pPos, Pos - pPos) + _
			   Chr(CLng("&H" & Mid(What, Pos + 1, 2)))
			 pPos = Pos + 3
			 Pos = InStr(pPos, What, "%")
		   Loop
		   Stream.WriteText Mid(What, pPos)

		   'Read the text stream
		   Stream.Position = 0
		   URLDecode = Stream.ReadText

		   'Free resources
		   Stream.Close
		 Else 'URL decode using string concentation
		   on error goto 0
		   'UfUf, this is a little slow method.
			'Do Not use it For data length over 100k
		   Pos = InStr(1, What, "%")
		   Do While Pos>0
			  What = Left(What, Pos-1) + _
			   Chr(Clng("&H" & Mid(What, Pos+1, 2))) + _
			   Mid(What, Pos+3)
			 Pos = InStr(Pos+1, What, "%")
		   Loop
		   URLDecode = What
		 End If
		 set Stream = nothing
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
