<!--#Include File = "CardInfo.asp"-->
<!--#Include File = "MPIData.asp"-->
<!--#Include File = "Merchant.asp"-->
<!--#Include File = "BillToAddress.asp"-->
<!--#Include File = "ShipToAddress.asp"-->
<!--#Include File = "PGResponse.asp"-->
<!--#Include File = "PGSearchResponse.asp"-->

<%
Class PostLib

Dim motoURL,sslURL,verbose,EPGUrl
Dim strKeyDir,strOsType
Dim oPGErrResponse
Dim oPGSeaErrResponse
Dim strMerchantTxnId


	Public Sub loadUrl()

		Set oFso=Server.CreateObject("Scripting.FileSystemObject")
		Set propFile=oFso.OpenTextFile(Server.MapPath("sfa.properties"), 1)

		'Read motoURL from sfa.properties file.
		If (propFile.AtEndOfStream <> True) Then
			strurl = propFile.ReadLine
			mypos = Instr(1, strurl,"=", 1)
			motoURL = Mid(strurl, mypos+1, len(strurl)-mypos)
		End if
		If motoURL = "" Then
			 Err.number=1
			 Err.Description = "Error in the properties file. Value for motoURL is not mentioned or is invalid"
   			 Err.Source = "loadUrl"
   			 Call checkErrors(Err.Description)
   			 exit sub
		End If

		'Read sslURL from sfa.properties file.
		If (propFile.AtEndOfStream <> True) Then
			strurl = propFile.ReadLine
			mypos = Instr(1, strurl,"=", 1)
			sslURL = Mid(strurl, mypos+1, len(strurl)-mypos)
		End If
		If sslURL = "" Then
			 Err.number=2
			 Err.Description = "Error in the properties file. Value for sslURL is not mentioned or is invalid"
			 Err.Source = "loadUrl"
			 Call checkErrors(Err.Description)
			 exit sub
		End If


		propFile.SkipLine

		'Read Key.Directory from sfa.properties file.
		If (propFile.AtEndOfStream <> True) Then
			strDir = propFile.ReadLine
			mypos = Instr(1, strDir,"=", 1)
			strKeyDir = Mid(strDir, mypos+1, len(strDir)-mypos)
		End If

		If strKeyDir = "" Then
				 Err.number=3
				 Err.Description = "Error in the properties file. Value for Key.Directory is not mentioned or is invalid"
				 Err.Source = "loadUrl"
				 Call checkErrors(Err.Description)
				 exit sub
		End If

		'Read OS.Type from sfa.properties file
		If (propFile.AtEndOfStream <> True) Then
			strOS = propFile.ReadLine
			mypos = Instr(1, strOS,"=", 1)
			strOsType = Mid(strOS, mypos+1, len(strOS)-mypos)
		End If

		If (Len(strOsType)=0) or strOsType = "" Then
				 Err.number=4
				 Err.Description = "Error in the properties file. Value for OS.Type is not mentioned or is invalid"
				 Err.Source = "loadUrl"
				 Call checkErrors(Err.Description)
				 exit sub
		End If

		'Read epgURL from sfa.properties file
		If (propFile.AtEndOfStream <> True) Then
			strEpgUrl = propFile.ReadLine
			mypos = Instr(1, strEpgUrl,"=", 1)
			EPGUrl = Mid(strEpgUrl, mypos+1, len(strEpgUrl)-mypos)
		End If

		If (Len(EPGUrl)=0) or EPGUrl = "" Then
				 Err.number=5
				 Err.Description = "Error in the properties file. Value for EPGUrl is not mentioned or is invalid"
				 Err.Source = "loadUrl"
				 Call checkErrors(Err.Description)
				 exit Sub
		End If

		propFile.Close
		Set propFile=Nothing
		Set oFso=Nothing

	Call checkErrors("Error")

	End Sub

	public sub getMotoUrl()
		getMotoUrl	=	motoURL
	end sub

	public sub getSslUrl()
		getSslUrl	=	sslUrl
	end sub

	Public Function postMOTO(oCInfo, oMPI, oMerchant, oBTA, oSTA)
		'Call CheckVerbose()

		Dim oPGResponse
		Set oPGResponse = New PGResponse
		oPGErrResponse = Null


		If( IsObject(oMerchant)=false ) Then
				Err.number=6
				Err.Description ="Invalid Merchant Object passed to postMOTO method. Object is null. Transaction cannot proceed."
				Err.Source = "postMOTO"
				Call checkErrors(Err.Description)
				set postMOTO=oPGErrResponse
				exit function
		End If

		strMerchantTxnId = oMerchant.getMerchantTxnID()

		If(isnull(oMerchant.getMerchantID()) or oMerchant.getMerchantID()="" ) Then
				Err.number=7
				Err.Description ="Merchant ID is null or invalid.Transaction cannot proceed."
				Err.Source = "postMOTO"
				Call checkErrors(Err.Description)
				set postMOTO=oPGErrResponse
				exit function
		End If

		If(isnull(oMerchant.getMessageType()) or oMerchant.getMessageType()="" ) Then
				Err.number=8
				Err.Description ="Message Type is null or Invalid. Transaction cannot proceed."
				Err.Source = "postMOTO"
				Call checkErrors(Err.Description)
				set postSSl=oPGErrResponse
				exit function
		End If

		If(IsObject(oCInfo)=false) Then
					Err.number = 9
					Err.Description ="Invalid Card Info Object passed to postMOTO method. Object is null or invalid. Transaction cannot proceed."
					Err.Source = "postMOTO"
					Call checkErrors(Err.Description)
					set postMOTO=oPGErrResponse
					exit function
		End If
		Dim objXML, strData, fs, f, strurl, mypos, parturl

		'Read property File
		Call loadUrl()
		'check for error in property file
		if (IsNull(oPGErrResponse)) then
			set postMOTO=oPGResponse
		else
			set postMOTO=oPGErrResponse
			exit function
		End if

		strData	=	buildMerchantBillShip(oMerchant,oBTA,oSTA)


		'Encrypt data
		Dim strEncryptedData
		set oEncryptionLib = GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
		strEncryptedData = oEncryptionLib.encryptMerchantData(oMerchant.getMerchantID(), strKeyDir ,oMerchant.getMerchantTxnID(),oMerchant.getAmount())

		If(isnull(strEncryptedData) or strEncryptedData="" ) Then
				Err.number=10
				Err.Description ="Error in Encrypting Merchant Data.Transaction cannot proceed."
				Err.Source = "postMOTO"
				Call checkErrors(Err.Description)
				set postMOTO=oPGErrResponse
				exit function
		End If

		'Append Encrypted Data
		strData =strData + "&EncryptedData=" + strEncryptedData

		'Append Keys
		'strMrtId = oMerchant.getMerchantID()
		'strData = strData + getKeys(strMrtId)

		'Append OSType,LanguageType
		strData = strData + "&OsType=" +strOsType
	    strData = strData + "&LanguageType=" + "asp"

		'Customers IP Address as captured by the MOTO Merchant

		strData = strData + "&CustIPAddress=" + getValue(oMerchant.getCustIPAddress())

		'Card Details
		strData = strData + "&InstrType=" + getValue(oCInfo.getInstrType())
		strData = strData + "&CardType=" + getValue(oCInfo.getCardType())
		strData = strData + "&CardNum=" + getValue(oCInfo.getCardNum())
		strData = strData + "&ExpDtYr=" + getValue(oCInfo.getExpDtYr())
		strData = strData + "&ExpDtMon=" + getValue(oCInfo.getExpDtMon())
		strData = strData + "&CVVNum=" + getValue(oCInfo.getCVVNum())
		strData = strData + "&NameOnCard=" + getValue(oCInfo.getNameOnCard())

		'MPI Details
		if IsObject(oMPI)  then
		strData = strData + "&status=" + getValue(oMPI.getVBVStatus())
		strData = strData + "&cavv=" + getValue(oMPI.getCAVV())
		strData = strData + "&eci=" + getValue(oMPI.getECI())
		strData = strData + "&xid=" + getValue(oMPI.getXID())
		strData = strData + "&shoppingcontext="+ getValue(oMPI.getShoppingContext())
		Else
		strData = strData + "&status=" + getValue("")
		strData = strData + "&cavv=" + getValue("")
		strData = strData + "&eci=" + getValue("")
		strData = strData + "&xid=" + getValue("")
		strData = strData + "&shoppingcontext="+ getValue("")
		End If
		Dim retData

		'checking for error before posting the data
		Call checkErrors("Error")

		if (IsNull(oPGErrResponse)) then
			set postMOTO=oPGResponse
		else
			set postMOTO=oPGErrResponse
			exit function
		End if

		'post the data
		retData	=	postData(motoURL,strData)

		retData	=	Replace(retData, vbCrLf, "")
		retData	=	Replace(retData, vbLf, "")
		retData	=	Replace(retData, vbTab, "")
		retData = Trim (retData)

		'check for response from payment gateway
		if( Len(retData)=0 ) then
			 Err.number = 11
			 Err.Description = "No response From Payment Gateway or URL not Found"
			 Err.Source = "postMoto"
			Call checkErrors(Err.Description)
			set postMOTO=oPGErrResponse
			exit function
		else
			oPGResponse.getResponse(retData)
		End If

		Call checkErrors("Error")

		if (IsNull(oPGErrResponse)) then
			set postMOTO=oPGResponse
		else
			set postMOTO=oPGErrResponse
		End if

	End Function


	Public Function postSSL(oMPI, oMerchant, oBTA, oSTA)
		'Call CheckVerbose()

	   Dim oPGResponse
	   Set oPGResponse = New PGResponse
	   oPGErrResponse = Null

		If(IsObject(oMerchant)=false) Then
			Err.number=12
			Err.Description ="Invalid Merchant Object passed to postSSL method. Object is null or invalid. Transaction cannot proceed."
		    Err.Source = "postSSL"
		    Call checkErrors(Err.Description)
		    set postSSl=oPGErrResponse
			exit function
		End If

		strMerchantTxnId = oMerchant.getMerchantTxnID()

		If(isnull(oMerchant.getMerchantID()) or oMerchant.getMerchantID()="" ) Then
				Err.number=13
				Err.Description ="Merchant ID is null or invalid. Transaction cannot proceed."
				Err.Source = "postSSL"
				Call checkErrors(Err.Description)
				set postSSl=oPGErrResponse
				exit function
		End If

		If(isnull(oMerchant.getMessageType()) or oMerchant.getMessageType()="" ) Then
				Err.number=14
				Err.Description ="Message Type is null or Invalid. Transaction cannot proceed."
				Err.Source = "postSSL"
				Call checkErrors(Err.Description)
				set postSSl=oPGErrResponse
				exit function
		End If

		Dim objXML, strData, fs, f, strurl, mypos, parturl

		'Read property File
		Call loadUrl()

		'check for error in property file
		if (IsNull(oPGErrResponse)) then
			set postSSL=oPGResponse
		else
			set postSSL=oPGErrResponse
			exit function
		End if

		strData	=	buildMerchantBillShip(oMerchant,oBTA,oSTA)

		'encrypt the Data
		Dim strEncryptedData
		set oEncryptionLib = GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
		strEncryptedData = oEncryptionLib.encryptMerchantData(oMerchant.getMerchantID(), strKeyDir ,oMerchant.getMerchantTxnID(),oMerchant.getAmount())

		If(isnull(strEncryptedData) or strEncryptedData="" ) Then
				Err.number=15
				Err.Description ="Error in Encrypting Data.Transaction cannot proceed."
				Err.Source = "postSSL"
				Call checkErrors(Err.Description)
				set postSSl=oPGErrResponse
				exit function
		End If

		'Append Encrypted Data
		strData =strData + "&EncryptedData=" + strEncryptedData

		'Append Keys
		'strMrtId = oMerchant.getMerchantID()
		'strData = strData + getKeys(strMrtId)

		'Append OSType,LanguageType
		strData = strData + "&OsType=" +strOsType
	    strData = strData + "&LanguageType=" + "asp"


		'MPI Details
		If(IsObject(oMPI)) Then
			strData = strData + "&WhatIUse=" + getValue(oMPI.getWhatIUse())
			strData = strData + "&AcceptHdr=" + getValue(oMPI.getAcceptHdr())
			strData = strData + "&UserAgent=" + getValue(oMPI.getAgentHdr())
			strData = strData + "&CurrencyVal=" + getValue(oMPI.getCurrencyVal())
			strData = strData + "&Exponent=" + getValue(oMPI.getExponent())
			strData = strData + "&RecurFreq=" + getValue(oMPI.getRecurFreq())
			strData = strData + "&RecurEnd=" + getValue(oMPI.getRecurEnd())
			strData = strData + "&Installment=" + getValue(oMPI.getInstallment())
			strData = strData + "&DeviceCategory=" + getValue(oMPI.getDeviceCategory())
			strData = strData + "&OrderDesc=" + getValue(oMPI.getOrderDesc())
			strData = strData + "&PurchaseAmount=" + getValue(oMPI.getPurchaseAmount())
			strData = strData + "&DisplayAmount=" + getValue(oMPI.getDisplayAmount())
		Else
			strData = strData + "&WhatIUse=" + getValue("")
			strData = strData + "&AcceptHdr=" + getValue("")
			strData = strData + "&UserAgent=" + getValue("")
			strData = strData + "&CurrencyVal=" + getValue("")
			strData = strData + "&Exponent=" + getValue("")
			strData = strData + "&RecurFreq=" + getValue("")
			strData = strData + "&RecurEnd=" + getValue("")
			strData = strData + "&Installment=" + getValue("")
			strData = strData + "&DeviceCategory=" + getValue("")
			strData = strData + "&OrderDesc=" + getValue("")
			strData = strData + "&PurchaseAmount=" + getValue("")
			strData = strData + "&DisplayAmount=" + getValue("")
		End IF

		Dim retData
		'Checking for error before posting the data
		Call checkErrors("Error")

		if (IsNull(oPGErrResponse)) then
			set postSSL=oPGResponse
		else
			set postSSL=oPGErrResponse
			exit function

		End if

		'post data
		retData	=	postData(sslURL,strData)

		retData	=	Replace(retData, vbCrLf, "")
		'check for response from payment gateway
		if( Len(retData)=0 ) then
			 Err.number = 16
			 Err.Description = "No response From Payment Gateway or URL not Found"
			 Err.Source = "postSSL"
			Call checkErrors(Err.Description)
			set postSSl=oPGErrResponse
			exit function
		else
			oPGResponse.getResponse(retData)
		End If

		If (oPGResponse.getRedirectionTxnId()<> "") Then
			oPGResponse.setRedirectionUrl(sslURL+"?txnId="+oPGResponse.getRedirectionTxnId())
		End If

		'checking for Error after posting the Data
		Call checkErrors("Error")

		if (IsNull(oPGErrResponse)) then
			set postSSL=oPGResponse
		else
			set postSSL=oPGErrResponse
		End if

	End Function



	private function getValue(astrValue)
		if isnull(astrValue) then
			getValue	=	""
		else
			getValue	=	Server.URLEncode(astrValue)
		end if
	end function


	Function postData(astrUrlToPostTo,astrDataToPost)

		On Error Resume Next

			Dim objXML
			Set objXML=Server.CreateObject("MSXML2.ServerXMLHTTP")
			objXML.open "POST",astrUrlToPostTo, false
			objXML.setRequestHeader "Content-Type","application/x-www-form-urlencoded"
			objXML.setRequestHeader "Content-Length", Len(astrDataToPost)
			objXML.setTimeouts 120000,120000,120000,120000
			objXML.send astrDataToPost
			If (objXML.status = 200 and Err.number = 0) Then
				postData	= 	objXML.responseText
			Else
				postData	=	""
			End If
		Call checkErrors("Error")
		Set objXML=nothing
	End Function


	Function buildMerchantBillShip(oMerchant,oBTA,oSTA)
		Dim strData
		strData	=	""
		'Merchant details
		strData = strData + "MerchantID=" + getValue(oMerchant.getMerchantID())
		strData = strData + "&Vendor=" + getValue(oMerchant.getVendor())
		strData = strData + "&Partner=" + getValue(oMerchant.getPartner())
		strData = strData + "&OrdRefNo=" + getValue(oMerchant.getOrderReferenceNo())
		strData = strData + "&Partner=" + getValue(oMerchant.getPartner())
		strData = strData + "&MerchantTxnID=" + getValue(oMerchant.getMerchantTxnID())
		strData = strData + "&MessageType=" + getValue(oMerchant.getMessageType())
		strData = strData + "&InvoiceNo=" + getValue(oMerchant.getInvoiceNo())
		strData = strData + "&InvoiceDate=" + getValue(oMerchant.getInvoiceDate())
		strData = strData + "&CurrCode=" + getValue(oMerchant.getCurrCode())
		strData = strData + "&GMTOffset=" + getValue(oMerchant.getGMTTimeOffset())
		strData = strData + "&RespMethod=" + getValue(oMerchant.getRespMethod())
		strData = strData + "&RespURL=" + getValue(oMerchant.getRespURL())
		strData = strData + "&Amount=" + getValue(oMerchant.getAmount())
		strData = strData + "&Ext1=" + getValue(oMerchant.getExt1())
		strData = strData + "&Ext2=" + getValue(oMerchant.getExt2())
		strData = strData + "&Ext3=" + getValue(oMerchant.getExt3())
		strData = strData + "&Ext4=" + getValue(oMerchant.getExt4())
		strData = strData + "&Ext5=" + getValue(oMerchant.getExt5())
		strData = strData + "&MrtIpAddr=" + getValue(oMerchant.getMrtIPAddress())


		'Bill To Address

		 if IsObject(oBTA)  then
			strData = strData + "&CustomerId="    + getValue(oBTA.getCustomerId())
			strData = strData + "&CustomerName="  + getValue(oBTA.getName())
			strData = strData + "&BillAddrLine1=" + getValue(oBTA.getAddrLine1())
			strData = strData + "&BillAddrLine2=" + getValue(oBTA.getAddrLine2())
			strData = strData + "&BillAddrLine3=" + getValue(oBTA.getAddrLine3())
			strData = strData + "&BillCity="	  + getValue(oBTA.getCity())
			strData = strData + "&BillState="     + getValue(oBTA.getState())
			strData = strData + "&BillZip="		  + getValue(oBTA.getZip())
			strData = strData + "&BillCountryAlphaCode=" + getValue(oBTA.getCountryAlphaCode())
			strData = strData + "&BillEmail="	  + getValue(oBTA.getEmail())
		 Else
			strData = strData + "&CustomerId="    + getValue("")
			strData = strData + "&CustomerName="  + getValue("")
			strData = strData + "&BillAddrLine1=" + getValue("")
			strData = strData + "&BillAddrLine2=" + getValue("")
			strData = strData + "&BillAddrLine3=" + getValue("")
			strData = strData + "&BillCity="	  + getValue("")
			strData = strData + "&BillState="     + getValue("")
			strData = strData + "&BillZip="		  + getValue("")
			strData = strData + "&BillCountryAlphaCode=" + getValue("")
			strData = strData + "&BillEmail="	  + getValue("")
		 End if


		'Ship To Address
		if IsObject(oSTA)  then
			strData = strData + "&ShipAddrLine1=" + getValue(oSTA.getAddrLine1())
			strData = strData + "&ShipAddrLine2=" + getValue(oSTA.getAddrLine2())
			strData = strData + "&ShipAddrLine3=" + getValue(oSTA.getAddrLine3())
			strData = strData + "&ShipCity="	  + getValue(oSTA.getCity())
			strData = strData + "&ShipState="	  + getValue(oSTA.getState())
			strData = strData + "&ShipZip="		  + getValue(oSTA.getZip())
			strData = strData + "&ShipCountryAlphaCode=" + getValue(oSTA.getCountryAlphaCode())
			strData = strData + "&ShipEmail="     + getValue(oSTA.getEmail())
		Else
			strData = strData + "&ShipAddrLine1=" + getValue("")
			strData = strData + "&ShipAddrLine2=" + getValue("")
			strData = strData + "&ShipAddrLine3=" + getValue("")
			strData = strData + "&ShipCity="	  + getValue("")
			strData = strData + "&ShipState="	  + getValue("")
			strData = strData + "&ShipZip="		  + getValue("")
			strData = strData + "&ShipCountryAlphaCode=" + getValue("")
			strData = strData + "&ShipEmail="     + getValue("")
		End If


		buildMerchantBillShip	=	strData

	End Function

	'Function IIf( expr, truepart, falsepart )
	'		IIf = falsepart
	'		If expr Then IIf = truepart
	'End Function

	'Function IsNothing (Obj)
	'	  If IsNull(Obj) or Obj Is Nothing Then
		  'If TypeName(Obj) = "Nothing" then
	'		IsNothing = True
	'	  Else
	'		IsNothing = False
	'	  End If
	'End Function

	Sub checkErrors (where)
			'strtoday= Month(Now()) & "-" & Day(Now())& "-" & Year(Now())
		If Err.Number <> 0 Then
		   'message="At " & Now & " the following errors occurred "
		   'Set objFile = Server.CreateObject("Scripting.FileSystemObject")
		   'strFile =  strtoday & ".log"
		   'Set objLog = objFile.OpenTextFile(Server.MapPath(strFile),8,True)
		   'objLog.writeLine(message & where & " *** ERROR Number # " & CStr(Err.Number)  & " *** ERROR Description # " & Err.Description  )
		   'objLog.Close
			  IF(where<>"Error") Then
				Set oPGErrResponse = New PGResponse
				oPGErrResponse.setRespCode("2")
				oPGErrResponse.setRespMessage(where)
				oPGErrResponse.setTxnId(strMerchantTxnId)

				Set oPGSeaErrResponse = New PGSearchResponse
				oPGSeaErrResponse.setRespCode("2")
				oPGSeaErrResponse.setRespMessage(where)
				Err.clear
			 Else
			  Set oPGErrResponse = New PGResponse
				oPGErrResponse.setRespCode("2")
				oPGErrResponse.setRespMessage("Internal Processing Error")
				oPGErrResponse.setTxnId(strMerchantTxnId)

				Set oPGSeaErrResponse = New PGSearchResponse
				oPGSeaErrResponse.setRespCode("2")
				oPGSeaErrResponse.setRespMessage("Internal Processing Error")
				Err.clear
			End If
		 End If
	End Sub


	Sub Logger(description)
		message="At " & Now
		strtoday= Month(Now()) & "-" & Day(Now())& "-" & Year(Now())
		Set objFile = Server.CreateObject("Scripting.FileSystemObject")
		strFile =  strtoday & ".log"
		Set objLog = objFile.OpenTextFile(Server.MapPath(strFile),8,True)
		objLog.writeLine message & description
		objLog.Close
	End Sub



Sub CheckVerbose()
	verbose =false
	Set oFso=Server.CreateObject("Scripting.FileSystemObject")
	Set propFile=oFso.OpenTextFile(Server.MapPath("sfa.properties"), 1)
	propFile.SkipLine
	propFile.SkipLine
	strverbose = propFile.ReadLine
	mypos = Instr(1, strverbose,"=", 1)
	verbose = Mid(strverbose, mypos+1, len(strverbose)-mypos)
	If verbose <> "" or verbose = "true" Then
			 verbose = true
	End If
	propFile.Close
	Set propFile=Nothing
	Set oFso=Nothing
End Sub

Function buildMerchantRelatedTxn(oMerchant)
	Dim strData
	strData	=	""

	'Merchant details
	strData = strData + "MerchantID=" + getValue(oMerchant.getMerchantID())
	strData = strData + "&Vendor=" + getValue(oMerchant.getVendor())
	strData = strData + "&Partner=" + getValue(oMerchant.getPartner())
	strData = strData + "&RespURL=" + getValue(oMerchant.getRespURL())
	strData = strData + "&RespMethod=" + getValue(oMerchant.getRespMethod())
	strData = strData + "&CurrCode=" + getValue(oMerchant.getCurrCode())
	strData = strData + "&RootTxnSysRefNum=" + getValue(oMerchant.getRootTxnSysRefNum())
	strData = strData + "&RootPNRefNum=" + getValue(oMerchant.getRootPNRefNum())
	strData = strData + "&RootAuthCode=" + getValue(oMerchant.getRootAuthCode())
	strData = strData + "&MessageType=" + getValue(oMerchant.getMessageType())
	strData = strData + "&Amount=" + getValue(oMerchant.getAmount())
	strData = strData + "&Ext1=" + getValue(oMerchant.getExt1())
	strData = strData + "&Ext2=" + getValue(oMerchant.getExt2())
	strData = strData + "&Ext3=" + getValue(oMerchant.getExt3())
	strData = strData + "&Ext4=" + getValue(oMerchant.getExt4())
	strData = strData + "&Ext5=" + getValue(oMerchant.getExt5())
	strData = strData + "&MrtIpAddr=" + getValue(oMerchant.getMrtIPAddress())
	strData = strData + "&MerchantTxnID=" + getValue(oMerchant.getMerchantTxnID())
	strData = strData + "&GMTOffset=" + getValue(oMerchant.getGMTTimeOffset())
	strData = strData + "&RequestType=" + "RelatedTxn"

	buildMerchantRelatedTxn=strData

End Function



Public Function postRelatedTxn(oMerchant)

	'Call CheckVerbose()

	Dim oPGResponse
	Set oPGResponse = New PGResponse
	oPGErrResponse = Null

	If(IsObject(oMerchant)= false ) Then
		Err.number=17
		Err.Description ="Invalid Merchant Object passed to postRelatedTxn method. Object is null or invalid. Transaction cannot proceed."
	    Err.Source = "postRelatedTxn"
	    Call checkErrors(Err.Description)
	    set postRelatedTxn=oPGErrResponse
		exit function
	End If

	strMerchantTxnId = oMerchant.getMerchantTxnID()

	If(isnull(oMerchant.getMerchantID()) or oMerchant.getMerchantID()="" ) Then
				Err.number=18
				Err.Description ="Merchant ID is null or invalid. Transaction cannot proceed."
				Err.Source = "postRelatedTxn"
				Call checkErrors(Err.Description)
				set postRelatedTxn=oPGErrResponse
				exit function
	End If

	If(isnull(oMerchant.getRootTxnSysRefNum()) or oMerchant.getRootTxnSysRefNum="" ) Then
				Err.number=19
				Err.Description ="Previous transaction System referance number is null or invalid.Transaction cannot proceed."
				Err.Source = "postRelatedTxn"
				Call checkErrors(Err.Description)
				set postRelatedTxn=oPGErrResponse
				exit function
	End If
	If(isnull(oMerchant.getMessageType()) or oMerchant.getMessageType="" ) Then
				Err.number=19
				Err.Description ="Message Type is null or invalid.Transaction cannot proceed."
				Err.Source = "postRelatedTxn"
				Call checkErrors(Err.Description)
				set postRelatedTxn=oPGErrResponse
				exit function
	End If

	'load the url from property file
	Call loadUrl()

	'check for error in property file
	if (IsNull(oPGErrResponse)) then
			set postRelatedTxn=oPGResponse
	else
			set postRelatedTxn=oPGErrResponse
	End if

	strData = buildMerchantRelatedTxn(oMerchant)

	'Encrypting The Data
	Dim strEncryptedData
	set oEncryptionLib = GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
	strEncryptedData = oEncryptionLib.encryptMerchantData(oMerchant.getMerchantID(), strKeyDir ,oMerchant.getMerchantTxnID(),oMerchant.getAmount())

	If(isnull(strEncryptedData) or strEncryptedData="" ) Then
				Err.number=20
				Err.Description ="Error in Encrypting Merchant Data.Transaction cannot proceed."
				Err.Source = "postRelatedTxn"
				Call checkErrors(Err.Description)
				set postRelatedTxn=oPGErrResponse
				exit function
	End If
	'Appending to string
	strData =strData + "&EncryptedData=" + strEncryptedData

    'Append OSType,LanguageType
	strData = strData + "&OsType=" +strOsType
	strData = strData + "&LanguageType=" + "asp"

	'Checking for error before posting the data
	if (IsNull(oPGErrResponse)) then
		set postRelatedTxn=oPGResponse
	else
		set postRelatedTxn=oPGErrResponse
		exit function
	End if

	strRetData	= PostData(EPGUrl,strData)

		strRetData	=	Replace(strRetData, vbCrLf, "")
		strRetData	=	Replace(strRetData, vbLf, "")
		strRetData	=	Replace(strRetData, vbTab, "")
		strRetData = Trim (strRetData)

		'checking for the response from payment gateway
		if( Len(strRetData)=0 ) then
			 Err.number = 21
			 Err.Description = "No response From Payment Gateway or URL not Found"
			 Err.Source = "postRelatedTxn"
			Call checkErrors(Err.Description)
			set postRelatedTxn=oPGErrResponse
			exit function
		else
		oPGResponse.getResponse(strRetData)
		End If

		'checking for error after posting the data
		Call checkErrors("Error")

		if (IsNull(oPGErrResponse)) then
			set postRelatedTxn=oPGResponse
		else
			set postRelatedTxn=oPGErrResponse
		End if

End Function

Public Function postStatusInquiry(oMerchant)
	Dim oPGSearchResponse
	Set oPGSearchResponse = New PGSearchResponse
	oPGSeaErrResponse = Null

	'Read property file
	Call loadUrl()
	'check for error in property file
	if (IsNull(oPGSeaErrResponse)) then
			set postStatusInquiry=oPGSearchResponse
	else
			set postStatusInquiry=oPGSeaErrResponse
			exit function
	End if


	If(isObject(oMerchant)=false) Then
			Err.number=22
			Err.Description ="Invalid Merchant Object passed to postStatusInquiry method. Object is null. Transaction cannot proceed."
		    Err.Source = "postStatusInquiry"
		    Call checkErrors(Err.Description)
		    set postStatusInquiry=oPGSeaErrResponse
			exit function
	End If

	If(isnull(oMerchant.getMerchantID()) or oMerchant.getMerchantID()="" ) Then
				Err.number=23
				Err.Description ="Merchant ID is null or invalid. Transaction cannot proceed."
				Err.Source = "postStatusInquiry"
				Call checkErrors(Err.Description)
				set postStatusInquiry=oPGSeaErrResponse
				exit function
	End If

	If(isnull(oMerchant.getMerchantTxnID()) or oMerchant.getMerchantTxnID()="" ) Then
					Err.number=24
					Err.Description ="Merchant Transaction ID is null or invalid. Transaction cannot proceed."
					Err.Source = "postStatusInquiry"
					Call checkErrors(Err.Description)
					set postStatusInquiry=oPGSeaErrResponse
					exit function
	End If

	Dim strData , strRetnData
	strData=""
	strData = strData + "MerchantID=" + getValue(oMerchant.getMerchantID())
	strData = strData + "&MerchantTxnID=" + getValue(oMerchant.getMerchantTxnID())

	'encrypt the data
	Dim strEncryptedData
	set oEncryptionLib = GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
	strEncryptedData = oEncryptionLib.encryptMerchantData(oMerchant.getMerchantID(), strKeyDir ,oMerchant.getMerchantTxnID(),oMerchant.getAmount())

	If(isnull(strEncryptedData) or strEncryptedData="" ) Then
			Err.number=25
			Err.Description ="Error in Encrypting Data.Transaction cannot proceed."
			Err.Source = "postStatusInquiry"
			Call checkErrors(Err.Description)
			set postStatusInquiry=oPGSeaErrResponse
			exit function
	End If

	'Append Encrypted data
	strData =strData + "&EncryptedData=" + strEncryptedData

	'Append OSType,LanguageType,RequestType
	strData = strData + "&OsType=" +strOsType
	strData = strData + "&LanguageType=" + "asp"
	strData = strData + "&RequestType=" + "SFAStatusInquiry"

	'Checking for error before posting the data
	if (IsNull(oPGSeaErrResponse)) then
				set postStatusInquiry=oPGSearchResponse
				else
				set postStatusInquiry=oPGSeaErrResponse
				exit function
	End if

	'post data
	strRetnData	= PostData(EPGUrl,strData)
	Logger("return data" & strRetnData)
	'strRetnData	=	Replace(strRetnData, vbTab, "")
	'strRetnData = Trim (strRetnData)


	'checking for response form payment gateway
	if( Len(strRetnData)=0 ) then
		 Err.number = 25
		 Err.Description = "No response From Payment Gateway or URL not Found"
		 Err.Source = "postStatusInquiry"
		Call checkErrors(Err.Description)
		set postStatusInquiry=oPGSeaErrResponse
		exit function
		else
		oPGSearchResponse.getSearchResponse(strRetnData)
	End If

	Call checkErrors("Error")

	if (IsNull(oPGSeaErrResponse)) then
		set postStatusInquiry=oPGSearchResponse
	else
		set postStatusInquiry=oPGSeaErrResponse
	End if

End Function

Public Function postTxnSearch(oMerchant)
	Dim oPGSearchResponse
	Set oPGSearchResponse = New PGSearchResponse
	oPGSeaErrResponse = Null

	'Read property file
	Call loadUrl()
	'check for error in property file
	if (IsNull(oPGSeaErrResponse)) then
			set postTxnSearch=oPGSearchResponse
	else
			set postTxnSearch=oPGSeaErrResponse
			exit function
	End if


	If(IsObject(oMerchant)=false) Then
				Err.number=26
				Err.Description ="Invalid Merchant Object passed to postTxnSearch method. Object is null. Transaction cannot proceed."
			    Err.Source = "postTxnSearch"
			    Call checkErrors(Err.Description)
			    set postTxnSearch=oPGSeaErrResponse
				exit function
	End If

	If(IsNull(oMerchant.getMerchantID()) or oMerchant.getMerchantID()="" ) Then
				Err.number=27
				Err.Description ="Merchant ID is null or invalid. Transaction cannot proceed."
				Err.Source = "postTxnSearch"
				Call checkErrors(Err.Description)
				set postTxnSearch=oPGSeaErrResponse
				exit function
	End If
  	If(isnull(oMerchant.getStartDate()) or oMerchant.getStartDate()="" ) Then
				Err.number=28
				Err.Description ="Merchant txn Start Date is null or invalid. Transaction cannot proceed."
				Err.Source = "postTxnSearch"
				Call checkErrors(Err.Description)
				set postTxnSearch=oPGSeaErrResponse
				exit function
	End If

	If(isnull(oMerchant.getEndDate()) or oMerchant.getEndDate()="" ) Then
				Err.number=29
				Err.Description ="Merchant txn End Date is null or invalid. Transaction cannot proceed."
				Err.Source = "postTxnSearch"
				Call checkErrors(Err.Description)
				set postTxnSearch=oPGSeaErrResponse
				exit function
	End If

		Dim strData , strRetnData
		strData=""
		strData = strData + "MerchantID=" + getValue(oMerchant.getMerchantID())
		strData = strData + "&StartDate=" + getValue(oMerchant.getStartDate())
		strData = strData + "&EndDate=" + getValue(oMerchant.getEndDate())

		'encrypt the data
		Dim strEncryptedData
		set oEncryptionLib = GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
		strEncryptedData = oEncryptionLib.encryptMerchantData(oMerchant.getMerchantID(),strKeyDir,oMerchant.getMerchantTxnID(),oMerchant.getAmount())

		If(isnull(strEncryptedData) or strEncryptedData="" ) Then
					Err.number=30
					Err.Description ="Error in Encrypting Data.Transaction cannot proceed."
					Err.Source = "postTxnSearch"
					Call checkErrors(Err.Description)
					set postTxnSearch=oPGSeaErrResponse
					exit function
		End If

		'Append Encrypted data
		strData =strData + "&EncryptedData=" + strEncryptedData

		'Append OSType,LanguageType,RequestType
		strData = strData + "&OsType=" +strOsType
		strData = strData + "&LanguageType=" + "asp"
		strData = strData + "&RequestType=" + "SFATxnSearch"

		'Checking for error before posting the data
		if (IsNull(oPGSeaErrResponse)) then
			set postTxnSearch=oPGSearchResponse
		else
			set postTxnSearch=oPGSeaErrResponse
			exit function
		End if

		'post data
		strRetnData	= PostData(EPGUrl,strData)
		Logger("return data" & strRetnData)
		'strRetnData	=	Replace(strRetnData, vbTab, "")
		'strRetnData = Trim (strRetnData)

		'check for response from payment gateway
		if( Len(strRetnData)=0 ) then
				 Err.number = 31
				 Err.Description = "No response From Payment Gateway or URL not Found"
				 Err.Source = "postTxnSearch"
				Call checkErrors(Err.Description)
				set postTxnSearch=oPGSeaErrResponse
				exit function
				else
				oPGSearchResponse.getSearchResponse(strRetnData)
		End If

		Call checkErrors("Error")

		if (IsNull(oPGSeaErrResponse)) then
			set postTxnSearch=oPGSearchResponse
		else
			set postTxnSearch=oPGSeaErrResponse
		End if

End Function

 End Class%>

