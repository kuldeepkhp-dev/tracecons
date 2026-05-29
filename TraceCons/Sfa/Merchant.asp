<%
Class Merchant
	Private mstrMerchantID
    Private mstrPartner
    Private mstrRespURL
    Private mstrRespMethod
    Private mstrExt1
    Private mstrExt2
    Private mstrExt3
    Private mstrExt4
    Private mstrExt5
    Private mstrCurrCode
    Private mstrOrderReferenceNo
    Private mstrMerchantTxnID
    Private mstrMessageType
    Private mstrGMTTimeOffset
    Private mstrInvoiceNo
    Private mstrInvoiceDate
    Private mstrAmount
    Private mstrCustIPAddress
    Private mstrVendor

    'Added For Related Txn
    Private mstrRootTxnSysRefNum
    Private mstrRootPNRefNum
    Private mstrRootAuthCode
    Private mstrLanguageCode

	'Added For Transaction Search
	Private mstrStartDate
	Private mstrEndDate

   public Function getStartDate()
   		getStartDate = mstrStartDate
   End Function

   public Function getEndDate()
   		getEndDate = mstrEndDate
   End Function

   public Function getLanguageCode()
		getLanguageCode = mstrLanguageCode
    End Function

    Public Function getRootTxnSysRefNum ()
		getRootTxnSysRefNum= mstrRootTxnSysRefNum
	End Function

	Public Function getRootPNRefNum ()
			getRootPNRefNum= mstrRootPNRefNum
	End Function

	Public Function getRootAuthCode ()
				getRootAuthCode= mstrRootAuthCode
	End Function

    Public Function getVendor()
        getVendor = mstrVendor
    End Function

    Public Function getMerchantID()
        getMerchantID = mstrMerchantID
    End Function

    Public Function getPartner()
        getPartner = mstrPartner
    End Function


    Public Function getOrderReferenceNo()
        getOrderReferenceNo = mstrOrderReferenceNo
    End Function


    Public Function getRespURL()
        getRespURL = mstrRespURL
    End Function


    Public Function getRespMethod()
        getRespMethod = mstrRespMethod
    End Function


    Public Function getCurrCode()
        getCurrCode = mstrCurrCode
    End Function

    Public Function getInvoiceNo()
        getInvoiceNo = mstrInvoiceNo
    End Function

    Public Function getInvoiceDate()
        getInvoiceDate = getTimestamp()
    End Function

    Public Function getMerchantTxnID()
        getMerchantTxnID = mstrMerchantTxnID
    End Function

    Public Function getMessageType()
        getMessageType = mstrMessageType
    End Function


    Public Function getAmount()
        getAmount = mstrAmount
    End Function

    Public Function getGMTTimeOffset()
     getGMTTimeOffset = mstrGMTTimeOffset
    End Function

    'getter methods

    Public Function getExt1()
        getExt1 = mstrExt1
    End Function

    Public Function getExt2()
        getExt2 = mstrExt2
    End Function

    Public Function getExt3()
        getExt3 = mstrExt3
    End Function

    Public Function getExt4()
        getExt4 = mstrExt4
    End Function

    Public Function getExt5()
        getExt5 = mstrExt5
    End Function

    Public Function getCustIPAddress()
        getCustIPAddress = mstrCustIPAddress
    End Function


    Public Sub setMerchantDetails(astrMerchantID , astrVendor ,astrPartner , astrCustIPAddress , astrMerchantTxnID ,astrOrderReferenceNo , astrRespURL , astrRespMethod , astrCurrCode , astrInvoiceNo , astrMessageType , astrAmount ,astrGMTTimeOffset ,astrExt1 , astrExt2 , astrExt3 , astrExt4 , astrExt5 )
      
        mstrMerchantID = astrMerchantID
        mstrCustIPAddress = astrCustIPAddress
        mstrVendor	=	astrVendor
        mstrPartner = astrPartner
        mstrOrderReferenceNo = astrOrderReferenceNo
        mstrRespURL = astrRespURL
        mstrRespMethod = astrRespMethod
        mstrCurrCode = astrCurrCode
        mstrInvoiceNo = astrInvoiceNo
        mstrMessageType = astrMessageType
        mstrAmount = astrAmount
        mstrGMTTimeOffset=astrGMTTimeOffset
        mstrExt1 = astrExt1
        mstrExt2 = astrExt2
        mstrExt3 = astrExt3
        mstrExt4 = astrExt4
        mstrExt5 = astrExt5
        mstrMerchantTxnID = astrMerchantTxnID
    End Sub

    Public Function getMrtIPAddress()
        getMrtIPAddress = Request.ServerVariables("LOCAL_ADDR")
    End Function

    Public Function getTimestamp()
        Const off = 5.5
        Dim SecsSince
        SecsSince = CLng(DateDiff("s", "01/01/1970 00:00:00", Now))
        getTimeStamp = CStr(SecsSince - 3600 * Abs(off)) + "000"
    End Function

	Public Sub setMerchantRelatedTxnDetails(astrMerchantID , astrVendor ,astrPartner, astrMerchantTxnID, astrRootTxnSysRefNum, astrRootPNRef,  astrRootAuthCode,  astrCurrCode, astrMessageType,  astrAmount, astrGMTTimeOffset, astrExt1,  astrExt2,  astrExt3,  astrExt4,  astrExt5)

		mstrMerchantID = astrMerchantID
		mstrVendor = astrVendor
		mstrPartner = astrPartner
		mstrMerchantTxnID	=	astrMerchantTxnID
		mstrRootTxnSysRefNum=   astrRootTxnSysRefNum
		mstrRootPNRefNum	=   astrRootPNRef
		mstrRootAuthCode	=   astrRootAuthCode
		mstrCurrCode = astrCurrCode
		mstrMessageType = astrMessageType
		mstrAmount = astrAmount
		mstrGMTTimeOffset=astrGMTTimeOffset
		mstrExt1 	= astrExt1
		mstrExt2 	= astrExt2
		mstrExt3 	= astrExt3
		mstrExt4 	= astrExt4
		mstrExt5 	= astrExt5

	 End Sub

	 Public Sub  setLanguageCode(astrLanguageCode)
		mstrLanguageCode = astrLanguageCode
	 End Sub


	 Public Sub setMerchantOnlineInquiry( astrMerchantID ,  astrMerchantTxnID)

	 				mstrMerchantID = astrMerchantID
	 				mstrMerchantTxnID	=	astrMerchantTxnID

	 End Sub

	 Public Sub setMerchantTxnSearch( astrMerchantID , astrStartDate , astrEndDate)
	 						 					
	 					mstrMerchantID = astrMerchantID
	 					mstrStartDate = astrStartDate
	 					mstrEndDate = astrEndDate

	 End Sub


End Class
%>

