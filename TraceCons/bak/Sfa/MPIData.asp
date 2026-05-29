<%
Class MPIData

    Private mstrPurchaseAmount
    Private mstrDisplayAmount
    Private mstrCurrencyVal
    Private mstrExponent
    Private mstrOrderDesc
    Private mstrRecurFreq
    Private mstrRecurEnd
    Private mstrInstallment
    Private mstrDeviceCategory
    Private mstrWhatIUse
    Private mstrAcceptHdr
    Private mstrAgentHdr
    Private mstrVBVStatus
    Private mstrCAVV
    Private mstrECI
    Private mstrXID
    Private mstrShoppingContext


    Public Function getECI()
        getECI = mstrECI
    End Function


    Public Function getXID()
        getXID = mstrXID
    End Function

    Public Function getVBVStatus()
        getVBVStatus = mstrVBVStatus
    End Function

    Public Sub setECI(astrECI)
        mstrECI = astrECI
    End Sub

    Public Sub setXID(astrXID)
        mstrXID = astrXID
    End Sub

    Public Sub setVBVStatus(astrVBVStatus)
        mstrVBVStatus = astrVBVStatus
    End Sub

    Public Function getCAVV()
        getCAVV = mstrCAVV
    End Function

    Public Sub setCAVV(astrCAVV)
        mstrCAVV = astrCAVV
    End Sub

    Public Sub setPurchaseAmount(astrPurchaseAmount)
        mstrPurchaseAmount = astrPurchaseAmount
    End Sub

    Public Function getPurchaseAmount()
        getPurchaseAmount = mstrPurchaseAmount
    End Function

    Public Sub setDisplayAmount(astrDisplayAmount)
        mstrDisplayAmount = astrDisplayAmount
    End Sub

    Public Function getDisplayAmount()
        getDisplayAmount = mstrDisplayAmount
    End Function

    Public Sub setCurrencyVal(astrCurrencyVal)
        mstrCurrencyVal = astrCurrencyVal
    End Sub

    Public Function getCurrencyVal()
        getCurrencyVal = mstrCurrencyVal
    End Function

    Public Sub setExponent(astrExponent)
        mstrExponent = astrExponent
    End Sub

    Public Function getExponent()
        getExponent = mstrExponent
    End Function

    Public Sub setOrderDesc(astrOrderDesc)
        mstrOrderDesc = astrOrderDesc
    End Sub

    Public Function getOrderDesc()
        getOrderDesc = mstrOrderDesc
    End Function

    Public Sub setRecurFreq(astrRecurFreq)
        mstrRecurFreq = astrRecurFreq
    End Sub

    Public Function getRecurFreq()
        getRecurFreq = mstrRecurFreq
    End Function

    Public Sub setRecurEnd(astrRecurEnd)
        mstrRecurEnd = astrRecurEnd
    End Sub

    Public Function getRecurEnd()
        getRecurEnd = mstrRecurEnd
    End Function

    Public Sub setInstallment(astrInstallment)
        mstrInstallment = astrInstallment
    End Sub

    Public Function getInstallment()
        getInstallment = mstrInstallment
    End Function

    Public Sub setDeviceCategory(astrDeviceCategory)
        mstrDeviceCategory = astrDeviceCategory
    End Sub

    Public Function getDeviceCategory()
        getDeviceCategory = mstrDeviceCategory
    End Function

    Public Sub setWhatIUse(astrWhatIUse)
        mstrWhatIUse = astrWhatIUse
    End Sub

    Public Function getWhatIUse()
        getWhatIUse = mstrWhatIUse
    End Function

    Public Sub setAcceptHdr(astrAcceptHdr)
        mstrAcceptHdr = astrAcceptHdr
    End Sub

    Public Function getAcceptHdr()
        getAcceptHdr = mstrAcceptHdr
    End Function

    Public Sub setAgentHdr(astrAgentHdr)
        mstrAgentHdr = astrAgentHdr
    End Sub

    Public Function getAgentHdr()
        getAgentHdr = mstrAgentHdr
    End Function

    Public Function getShoppingContext()
        getShoppingContext	= mstrShoppingContext
    End Function


    Public Sub setMPIRequestDetails( astrPurchaseAmount , astrDisplayAmount , astrCurrencyVal , astrExponent , astrOrderDesc , astrRecurFreq , astrRecurEnd , astrInstallment , astrDeviceCategory , astrWhatIUse , astrAcceptHdr , astrAgentHdr )

        mstrPurchaseAmount = astrPurchaseAmount
        mstrDisplayAmount = astrDisplayAmount
        mstrCurrencyVal = astrCurrencyVal
        mstrExponent = astrExponent
        mstrOrderDesc = astrOrderDesc
        mstrRecurFreq = astrRecurFreq
        mstrRecurEnd = astrRecurEnd
        mstrInstallment = astrInstallment
        mstrDeviceCategory = astrDeviceCategory
        mstrWhatIUse = astrWhatIUse
        mstrAcceptHdr = astrAcceptHdr
        mstrAgentHdr = astrAgentHdr

    End Sub


    Public Sub setMPIResponseDetails(astrECI , astrXID , astrVBVStatus , astrCAVV , astrPurchaseAmount , astrCurrencyVal )
        mstrECI = astrECI
        mstrXID = astrXID
        mstrVBVStatus = astrVBVStatus
        mstrCAVV = astrCAVV
        mstrCurrencyVal = astrCurrencyVal
        mstrPurchaseAmount = astrPurchaseAmount
    End Sub

End Class
%>
