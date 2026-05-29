<%

Class BillToAddress

    Private mstrEmail
    Private mstrCustomerId
    Private mstrCustomerName
    Private mstrAddrLine1
    Private mstrAddrLine2
    Private mstrAddrLine3
    Private mstrCity
    Private mstrState
    Private mstrZip
    Private mstrCountryAlphaCode


    Public Function getEmail()
        getEmail = mstrEmail
    End Function


    Public Function getAddrLine1()
        getAddrLine1 = mstrAddrLine1
    End Function

    Public Function getAddrLine2()
        getAddrLine2 = mstrAddrLine2
    End Function

    Public Function getAddrLine3()
        getAddrLine3 = mstrAddrLine3
    End Function


    Public Function getCity()
        getCity = mstrCity
    End Function

    Public Function getState()
        getState = mstrState
    End Function

    Public Function getZip()
        getZip = mstrZip
    End Function

    Public Function getCustomerId()
        getCustomerId = mstrCustomerId
    End Function

    Public Function getName()
        getName = mstrCustomerName
    End Function



    Public Function getCountryAlphaCode()
        getCountryAlphaCode = mstrCountryAlphaCode
    End Function

    Public Sub setAddressDetails(astrCustomerId,astrCustomerName,astrAddrLine1 , astrAddrLine2 , astrAddrLine3 , astrCity , astrState , astrZip , astrCountryAlpha , astrEmail )
            mstrCustomerId = astrCustomerId
            mstrCustomerName = astrCustomerName
            mstrEmail = astrEmail
            mstrAddrLine1 = astrAddrLine1
            mstrAddrLine2 = astrAddrLine2
            mstrAddrLine3 = astrAddrLine3
            mstrCity = astrCity
            mstrState = astrState
            mstrZip = astrZip
            mstrCountryAlphaCode = astrCountryAlpha
    End Sub


End Class

%>
