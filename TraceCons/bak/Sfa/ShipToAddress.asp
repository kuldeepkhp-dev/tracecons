<%

Class ShipToAddress

    Private mstrEmail
    Private mstrAddLine1
    Private mstrAddLine2
    Private mstrAddLine3
    Private mstrCity
    Private mstrState
    Private mstrZip
    Private mstrCountryAlphaCode

    Public Function getEmail()
        getEmail = mstrEmail
    End Function


    Public Sub setAddrLine1(astrAddrLine1)
        mstrAddLine1 = astrAddrLine1
    End Sub

    Public Sub setAddrLine2(astrAddrLine2)
        mstrAddLine2 = astrAddrLine2
    End Sub

    Public Sub setAddrLine3(astrAddrLine3)
        mstrAddLine3 = astrAddrLine3
    End Sub

    Public Function getAddrLine1()
        getAddrLine1 = mstrAddLine1
    End Function

    Public Function getAddrLine2()
        getAddrLine2 = mstrAddLine2
    End Function

    Public Function getAddrLine3()
        getAddrLine3 = mstrAddLine3
    End Function

    Public Sub setCity(city)
        mstrCity = city
    End Sub

    Public Function getCity()
        getCity = mstrCity
    End Function

    Public Sub setState(state)
        mstrState = state
    End Sub

    Public Function getState()
        getState = mstrState
    End Function

    Public Sub setZip(zip)
        mstrZip = zip
    End Sub

    Public Function getZip()
        getZip = mstrZip
    End Function

    Public Sub setCountryAlphaCode(countryalpha)
        mstrCountryAlphaCode = countryalpha
    End Sub

    Public Function getCountryAlphaCode()
        getCountryAlphaCode = mstrCountryAlphaCode
    End Function

    Public Sub setAddressDetails(astrAddrLine1 , astrAddrLine2 , astrAddrLine3 , astrCity , astrState , astrZip , astrCountryAlpha ,astrEmail )

    	mstrAddLine1 = astrAddrLine1
        mstrAddLine2 = astrAddrLine2
        mstrAddLine3 = astrAddrLine3
        mstrCity = astrCity
        mstrState = astrState
        mstrZip = astrZip
        mstrCountryAlphaCode = astrCountryAlpha
        mstrEmail	=	astrEmail
    End Sub
End Class

%>
