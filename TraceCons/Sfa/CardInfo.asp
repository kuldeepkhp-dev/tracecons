<%
Class CardInfo
    Private mstrCardType
    Private mstrCardNum
    Private mstrExpDtYr
    Private mstrExpDtMon
    Private mstrCVVNum
    Private mstrNameOnCard
    Private mstrInstrType


    Public Function getCardType()
        getCardType = mstrCardType
    End Function

    Public Function getCardNum()
        getCardNum = mstrCardNum
    End Function

    Public Function getCVVNum()
        getCVVNum = mstrCVVNum
    End Function

    Public Function getExpDtYr()
        getExpDtYr = mstrExpDtYr
    End Function

    Public Function getExpDtMon()
        getExpDtMon = mstrExpDtMon
    End Function

    Public Function getNameOnCard()
        getNameOnCard = mstrNameOnCard
    End Function

    Public Function getInstrType()
        getInstrType = mstrInstrType
    End Function

    Public Sub setCardDetails(astrCardType , astrCardNum , astrCVVNum , astrExpDtYr , astrExpDtMon , astrName , astrInstrType )
        mstrCardType = astrCardType
        mstrCardNum = astrCardNum
        mstrCVVNum = astrCVVNum
        mstrExpDtYr = astrExpDtYr
        mstrExpDtMon = astrExpDtMon
        mstrNameOnCard = astrName
        mstrInstrType = astrInstrType

    End Sub

End Class
 %>