<!--#Include File = "Sfa/include.asp"-->
<%

Dim oPostLib
Dim BGCustID,BGAmount
Set oPostLib = New PostLib
Dim oCI, oMPI, oMerchant, oBTA, oSTA
Set oCI = New CardInfo
Set oMPI = New MPIData
Set oMerchant = New Merchant
Set oBTA = New BillToAddress
Set oSTA = New ShipToAddress

'set Conn=server.CreateObject ("ADODB.connection")
'Conn.Open (Application("conn_ConnectionString"))

Importer_Id=Request.QueryString("id")
Amount = Request.QueryString("BGAmount")
Module = Request.QueryString("mdl")
'sql="select URGID,sum(price) as price from Customer_Order_Detail where InvoiceNo='"&Invoice_number&"' group by urgid"
'response.write(sql)
'response.end
'set rs=server.CreateObject("ADODB.Recordset")
'rs.open sql,conn
'if not rs.eof Then
'	BGCustID = rs("URGID")
'	BGAmount = rs("price")
'end if
BGAmount = Amount

'Response.Write(BGAmount)
'Response.End()
'UID=session("uid") 'ext1
'PWD=session("pwd") 'ext2
'iecode=Session("numb") 'ext3

'app_form_no=Session("application_no")
'exp_name=Session("name")
Invoice_number="APEDA/GRPI/" & cstr(Importer_Id)
Response_url="http://apeda.com/trace/insert.asp?imp="&Importer_Id&"&BGAmount="&BGAmount&"&mdl="&Module
Order_number="APEDA/GRP/" & cstr(Importer_Id)
purchase_Amount=BGAmount
'exp_add1=Session("add1")
'exp_add2=Session("add2")
'exp_add3=Session("add3")
'exp_state=Session("State")
'exp_pin=Session("pinc")
'exp_email=Session("emal")

'oMerchant.setMerchantDetails "00001133","00001133","00001133","",CLng(DateDiff("s", "01/01/1970 00:00:00", Now)),"Ord123","http://www.shaadihelp.com/trialpage.asp","GET","INR","INV123","req.Preauthorization","10.00","GMT+05:30","Ext1","Ext2","Ext3","Ext4","Ext5"

  oMerchant.setMerchantDetails "00001133","00001133","00001133","",CLng(DateDiff("s", "01/01/1970 00:00:00", Now)),Order_number,Response_url,"POST","INR",Invoice_number,"req.Preauthorization",purchase_Amount,"GMT+05:30",iecode,"true",PWD,app_form_no,exp_name

  oBTA.setAddressDetails "0000","Name","Adress1","Adress2","Adress3","Delhi","INDIA","110001","IND","user@nodomain.com"

  oSTA.setAddressDetails "Adress1","Adress2","Adress3","Delhi","INDIA","110001","IND","user@nodomain.com"

  oMPI.setMPIRequestDetails BGAmount,"INR "&BGAmount,"356","2","RCMC","","","","0","","image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*","Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)"




Dim oPGResp
Set oPGResp=oPostLib.postSSL (oMPI,oMerchant,oBTA,oSTA)
If oPGResp.getRedirectionUrl() <> "" Then
	strResponseURL=oPGResp.getRedirectionUrl()
	Response.Redirect strResponseURL
else
	Response.Write "Response code:" & oPgResp.getRespCode() & "<br>"
	Response.Write "Response message:" & oPgResp.getRespMessage() & "<br>"
End If
%>