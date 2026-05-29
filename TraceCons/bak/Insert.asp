<!--#Include File = "sfa/PGResponse.asp"-->
<html>
<head>
<title>A P E D A 's e-Commerce enabled Service</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="description" content="Fireworks Splice HTML">


<%


'set strResponsecode=Request.Querystring("RespCode")
'set strMessage=Request.Querystring("Message")
'set strMerchantTxnId=Request.Querystring("TxnID")
'set strTxnId=Request.Querystring("ePGTxnID")
'set strAuthIdCode=Request.Querystring("AuthIdCode")
'set strRPN=Request.Querystring("RPN")
'set strTxnType=Request.Querystring("TxnType")
%>

<%

	
	Dim oPGResponse
	Dim respcd,respmsg,TxnID,ePGTxnID,AuthIdCode
	Dim astrResponseData,astrClearData
	Dim strMerchantId,astrFileName
	Dim strKey

	ImpNo=Request.QueryString("imp")
	'BGCustID=Request.QueryString("BGCustID")
	BGAmount=Request.QueryString("BGAmount")
	Module=Request.QueryString("mdl")

	' this is the path of the merchants key file..please use appropriate path as used on your Server where SFA is installed..
	strMerchantId="00001133"
	astrFileName=Server.mappath("..\") & "\" & "00001133.key"
	'astrFileName="00001133.key"

	if Request.ServerVariables("HTTP_METHOD")="POST" then
		astrResponseData= Request.Form("DATA")
        'response.write(astrResponseData)
        'response.end
		astrClearData= validateEncryptedData(astrResponseData,astrFileName,strMerchantId)
		Set oPGResponse = New PGResponse
		oPGResponse.getResponse(astrClearData)
		respcd=oPGResponse.getRespCode()
		respmsg=oPGResponse.getRespMessage()
		TxnID=oPGResponse.getTxnId()
		ePGTxnID=oPGResponse.getEpgTxnId()
		AuthIdCode=oPGResponse.getAuthIdCode()
	end If
	
    if  cstr(respcd)="1" then
		        ActivFlag="N"
	elseif  cstr(respcd)="2" then
				ActivFlag="N"
	elseif  cstr(respcd)="" then
				ActivFlag="N"
	else
	    ActivFlag="Y"
	end if

	 'cstr(respcd)="3"
	 'response.write("dsfdhgfh" & cstr(respcd))
	 'response.end
	 set Conn=server.CreateObject ("ADODB.connection")
	 Conn.Open (Application("conn_ConnectionStringGRP"))
	 if Module = "IMP" Then
	    qlstat=" update APEDA.LS_SubscriptionIMP set  TransactionID ='" & ePGTxnID & "',SubscriptionAmount='"&BGAmount&"', ImporterActiveFlag='"&ActivFlag&"'"
	    qlstat=qlstat &" , reasoniffail='"& respmsg &"'"
	    qlstat=qlstat &"  Where ImporterID='"&ImpNo&"'  AND Subscriptionyear = year(getdate())"
	 else
	    qlstat=" update APEDA.LS_SubscriptionEXP set  TransactionID ='" & ePGTxnID & "',SubscriptionAmount='"&BGAmount&"', ExporterActiveFlag='"&ActivFlag&"'"
	    qlstat=qlstat &" , reasoniffail='"& respmsg &"'"
	    qlstat=qlstat &"  Where RCMCNo='"&ImpNo&"' AND Subscriptionyear = year(getdate())"
	 end if
	
	Conn.Execute(qlstat)
	'response.write(qlstat)
	'response.end
	if  cstr(respcd)="1" then
		response.write "Payment Unsuccessful- Rejected by the switch<br>" 
		
		Response.write "Message : " & respmsg & "<br>"
		
		Response.write "Transaction ID : " & ePGTxnID & "<br>"
		response.Redirect("http://203.196.130.19/Tracecons/postpayment.aspx?q=1&a=")
		response.end
	elseif  cstr(respcd)="2" then
		response.write "Payment Unsuccessful- Rejected by the Payment Gateway<br>" 
		Response.write "Message : " & respmsg & "<br>"
		
		Response.write "Transaction ID : " & ePGTxnID & "<br>"
		response.Redirect("http://203.196.130.19/Tracecons/postpayment.aspx?q=2")
		response.end
	elseif  cstr(respcd)="" then
		response.write "Payment Unsuccessful"
		response.Redirect("http://203.196.130.19/Tracecons/postpayment.aspx?q=3")
		response.end
	else
	    response.Redirect("http://203.196.130.19/Tracecons/postpayment.aspx?q=4")
		response.end
	end if
	
	

%>
	

<%
	

	Function validateEncryptedData(astrResponseData,astrFileName,strMerchantId)
		Set fs = CreateObject("Scripting.FileSystemObject")
		Set wfile = fs.OpenTextFile(astrFileName)
		strModulus = wfile.ReadLine
		strModulus=decryptMerchantKey(strModulus,strMerchantId)
		strExponent = wfile.ReadLine
		strExponent=decryptMerchantKey(strExponent,strMerchantId)
		wfile.close
		Set wfile=nothing
		Set fs=nothing
		Dim oEPGMerchantEncryptionLib
		Set oEPGMerchantEncryptionLib= GetObject("java:com.opus.epg.sfa.java.EPGMerchantEncryptionLib")
		validateEncryptedData=oEPGMerchantEncryptionLib.decryptDataWithPrivateKeyContents(astrResponseData,strModulus,strExponent)
	End Function

	Function decryptMerchantKey(strData, strMerchantId)
		strMerchantId=strMerchantId&strMerchantId
		strKey=Mid(strMerchantId,1,16)
		decryptMerchantKey=decryptData(strData,strKey)
	End Function

	Function decryptData(strData,strKey)
	   	Dim oEPGCryptLib
		Set oEPGCryptLib=GetObject("java:com.opus.epg.sfa.java.EPGCryptLib")
		decryptData=oEPGCryptLib.Decrypt(strKey, strData)
	End Function
%>
<!--To put this html into an existing HTML document, you must copy the JavaScript and-->
<!--paste it in a specific location within the destination HTML document. You must then copy-->
<!--and paste the table in a different location.-->

<!-- Fireworks 3.0  Dreamweaver 3.0 target.  Created Mon Jun 18 11:19:20 GMT-0700 (Pacific Daylight Time) 2001 -->
<script language="JavaScript">
<!--
<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
// -->

function MM_findObj(n, d) { //v4.0
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && document.getElementById) x=document.getElementById(n); return x;
}

function MM_showHideLayers() { //v3.0
  var i,p,v,obj,args=MM_showHideLayers.arguments;
  for (i=0; i<(args.length-2); i+=3) if ((obj=MM_findObj(args[i]))!=null) { v=args[i+2];
    if (obj.style) { obj=obj.style; v=(v=='show')?'visible':(v='hide')?'hidden':v; }
    obj.visibility=v; }
}
//-->
</script>
</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" onLoad="MM_showHideLayers('Layer1','','hide','Layer2','','hide','Layer3','','hide','Layer4','','hide','Layer5','','hide','Layer6','','hide','Layer7','','hide','Layer8','','hide','Layer9','','hide','Layer10','','hide','Layer11','','hide','Layer12','','hide','Layer13','','hide')">
<!--The following section is an HTML table which reassembles the sliced image in a browser.-->
<!--Copy the table section including the opening and closing table tags, and paste the data where-->
<!--you want the reassembled image to appear in the destination document. -->
<!-------------------------- BEGIN COPYING THE HTML HERE ---------------------------->
<!-- Image with table -->
<div id="Layer1" style="position:absolute; left:14px; top:169px; width:11px; height:10px; z-index:1; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer2" style="position:absolute; left:12px; top:182px; width:11px; height:10px; z-index:2; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer3" style="position:absolute; left:11px; top:195px; width:14px; height:12px; z-index:3; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer4" style="position:absolute; left:12px; top:222px; width:13px; height:10px; z-index:4; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer5" style="position:absolute; left:11px; top:237px; width:14px; height:12px; z-index:5; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer6" style="position:absolute; left:11px; top:269px; width:20px; height:12px; z-index:6; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer7" style="position:absolute; left:11px; top:281px; width:14px; height:10px; z-index:7; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer8" style="position:absolute; left:11px; top:307px; width:13px; height:13px; z-index:8; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer9" style="position:absolute; left:11px; top:323px; width:12px; height:9px; z-index:9; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer10" style="position:absolute; left:10px; top:350px; width:12px; height:11px; z-index:10; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer11" style="position:absolute; left:10px; top:363px; width:14px; height:11px; z-index:11; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer12" style="position:absolute; left:12px; top:379px; width:14px; height:10px; z-index:12; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<div id="Layer13" style="position:absolute; left:11px; top:391px; width:9px; height:13px; z-index:13; visibility: hidden"><img src="../images/arrow.gif" width="15" height="10"></div>
<table border="0" cellpadding="0" cellspacing="0" width="750" height="463">
  <!-- fwtable fwsrc="ecommerece3.png" fwbase="ecommerece2.jpg" --> 
  <tr valign="top"> 
    <!-- row 1 -->
    <td background="../images/sideback.gif" height="430"> 
      <table border="0" cellpadding="0" cellspacing="0" width="142">
        <tr valign="top"> 
          <!-- row 1 -->
          <td> 
            <table border="0" cellpadding="0" cellspacing="0" width="142">
              <tr valign="top"> 
                <!-- row 1 -->
                <td> 
                  <table border="0" cellpadding="0" cellspacing="0" width="1">
                    <tr valign="top"> 
                      <!-- row 1 -->
                      <td><img name="ecommerece2_r1_c1" src="../images/ecommerece2_r1_c1.jpg" width="1" height="1" border="0"></td>
                    </tr>
                    <tr valign="top"> 
                      <!-- row 2 -->
                      <td><img name="ecommerece2_r2_c1" src="../images/ecommerece2_r2_c1.jpg" width="1" height="147" border="0"></td>
                    </tr>
                  </table>
                </td>
                <td><img name="ecommerece2_r1_c2" src="../images/ecommerece2_r1_c2.jpg" width="141" height="148" border="0"></td>
              </tr>
            </table>
          </td>
        </tr>
        <tr valign="top"> 
          <!-- row 2 -->
          <td background="../images/sideback.gif"><img name="ecommerece2_r4_c1" src="../images/ecommerece2_r4_c1.jpg" width="142" height="281" border="0" usemap="#ecommerece2_r4_c1Map"></td>
        </tr>
      </table>
    </td>
    <td height="430"> 
      <table border="0" cellpadding="0" cellspacing="0" width="669">
        <tr valign="top"> 
          <!-- row 1 -->
          <td height="217"> 
            <table border="0" cellpadding="0" cellspacing="0" width="606">
              <tr valign="top"> 
                <!-- row 1 -->
                <td><img name="ecommerece2_r1_c22" src="../images/ecommerece2_r1_c22.jpg" width="26" height="216" border="0"></td>
                <td> 
                  <table border="0" cellpadding="0" cellspacing="0" width="468">
                    <tr valign="top"> 
                      <!-- row 1 -->
                      <td><img name="ecommerece2_r1_c23" src="../images/bannerfinal5.gif" width="468" height="60" border="0"></td>
                    </tr>
                    <tr valign="top"> 
                      <!-- row 2 -->
                      <td><img name="ecommerece2_r3_c23" src="../images/ecommerece2_r3_c23.jpg" width="468" height="88" border="0"></td>
                    </tr>
                    <tr valign="top"> 
                      <!-- row 3 -->
                      <td> 
                        <table border="0" cellpadding="0" cellspacing="0" width="468">
                          <tr valign="top"> 
                            <!-- row 1 -->
                            <td><img name="ecommerece2_r4_c23" src="../images/ecommerece2_r4_c23.jpg" width="22" height="68" border="0"></td>
                            <td> 
                              <table border="0" cellpadding="0" cellspacing="0" width="446">
                                <tr valign="top"> 
                                  <!-- row 1 -->
                                  <td> 
                                    <table border="0" cellpadding="0" cellspacing="0" width="446">
                                      <tr valign="top"> 
                                        <!-- row 1 -->
                                        <td><img name="ecommerece2_r4_c24" src="../images/ecommerece2_r4_c24.jpg" width="352" height="42" border="0"></td>
                                        <td><img name="ecommerece2_r4_c25" src="../images/ecommerece2_r4_c25.jpg" width="94" height="42" border="0"></td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr valign="top"> 
                                  <!-- row 2 -->
                                  <td>&nbsp;</td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
                <td><img name="ecommerece2_r1_c26" src="../images/ecommerece2_r1_c26.jpg" width="112" height="216" border="0"></td>
              </tr>
            </table>
          </td>
        </tr>
        <tr valign="top"> 
          <!-- row 2 -->
          <td> 
            <table width="607" border="0" height="106" cellpadding="0" cellspacing="0">
              <tr> 
                <td height="25" width="21" bgcolor="#FFFFFF">&nbsp;</td>
                <td height="25" background="../images/point.gif" width="6">&nbsp;</td>
                <td height="25" width="353"><font color="#FF0000" face="Verdana, Arial, Helvetica, sans-serif"><b><font color="#FF0000" face="Verdana, Arial, Helvetica, sans-serif"><b><font size="2" face="Geneva, Arial, Helvetica, san-serif"><i><font size="3">Welcome</font></i> 
                  <font color="#FFB871">to Online Services Zone</font></font></b></font> 
                  <font color="#FF0000">* </font><font size="2" face="Geneva, Arial, Helvetica, san-serif"><i></i></font></b></font></td>
                <td height="25" background="../images/point.gif" width="36"><img src="../images/card4.gif" width="32" height="19"></td>
                <td height="25" background="../images/point.gif" width="33"><img src="../images/visa.gif" width="33" height="20"></td>
                <td height="25" background="../images/point.gif" width="32">&nbsp;</td>
                <td height="25" background="../images/point.gif" width="126">&nbsp;</td>
              </tr>
              <tr valign="top" align="left"> 
                <td height="47" colspan="7"> 
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" cols="yes">
                    <tr> 
                      <td width="57%" nowrap>

<%
'if not session("insert") then 
'connect to database
set Conn=server.CreateObject ("ADODB.connection")
Conn.Open (Application("conn_ConnectionString"))
r=session("application_no")
iecode=Session("numb")
r=cdbl(r)

' Here instead of taking information from Session, take it from the exporter_rcmc_temp table and insert it to the corresponding final tables.
sql="select * from Customer_Order_Master where SessionID='"&SessionID&"' and urgid ='"&BGCustID&"'"
response.write(sql)
response.end
set rs=server.CreateObject("ADODB.Recordset")
rs.open sql,conn
if not rs.eof Then
	invoiceNo=rs("InvoiceNo")
	invoiceDate=rs("InvoiceDate")
	CustomerName=rs("CustomerName")
	Address=rs("Address")
	Country=rs("Country")
	State=rs("State")
	City=rs("City")
	PinCode=rs("Pincode")
	Telephone=rs("Telephone")
	Email=rs("Email")
	description=rs("description")
end if
'---------------------added--------------
'sql_reg_chk="select max(app_form_no) as reg_max from exporter_rcmc"
'set rs_reg_chk=server.createobject("ADODB.RecordSet")
'rs_reg_chk.open sql_reg_chk,Conn
'	if not rs_reg_chk.eof then 
'		reg_max=cdbl(rs_reg_chk("reg_max"))
'		if (reg_max+1)<>r then
'			r=reg_max+1
'		end if
'	end if
'rs_reg_chk.close
'set rs_reg_chk=nothing
'------------------------------------------

'sq="select iecode from exporter_rcmc where (iecode='" & IEcode & "') and (deregd_flag='R')"
'set rs_final=server.CreateObject("ADODB.Recordset")
'rs_final.Open sq,Conn
'if rs_final.EOF then
	pass=true
'	if ((Validity_Date="") or isnull(Validity_Date)) then 
	
		qlstat="update Customer_Order_Master set  TxnReferenceNumber ='" & ePGTxnID & "',TxnAmount='"&BGAmount&"' Where InvoiceNo='"&InvoiceNo&"' And URGID ='"&BGCustID&"'"
'	else
'		qlstat="insert into exporter_rcmc values ('" & IEcode & "','" & Exp_name & "','"& Exp_add1 & "','" & Exp_add2 & "','" & Exp_add3 & "','"& Exp_state & "'," & Exp_pin & ",'" & Exp_tele & "','" & Exp_email & "','" & Date_est & "','" & Iecode_allot_date & "','"& Exp_type & "','" & Exp_pan & "',"& Nature_firm & ",'" & Exp_bnk_name & "',"& Exp_acc_type & ",'"& Exp_acc_no & "'," & Exp_status & ",'" & App_form_no & "','"& Reg_date &"','" & Remarks & "','" & User_id & "','" & Secret_ques & "','" & Secret_ans & "','" & Deregd_flag & "','" & Product_type & "','" & Exp_grade & "','" & ePGTxnID & "','" & date() & "','" & registered_SSI &"','"&city&"',"&Male_No&","&Female_No&",'"&EOU&"','"&Validity_Date&"',null,null)"
'	end if
	Conn.Execute(qlstat)
	response.write(qlstat)

	'inserting values to table exporter_rcmc_br from application form
	'sqlstat2="insert into exporter_rcmc_br values('" & IEcode & "','" & Branch_code & "','" & Branch_add1 & "','" & Branch_add2 & "','"& Branch_State & "','" & Branch_pin & "','')"
	'response.write(sqlstat2)
	'response.end
	'Conn.Execute(sqlstat2)


	'inserting values to table exporter_rcmc_partner from application form
	'sqlstat3="insert into exporter_rcmc_partner values ('" & IEcode & "','" & Partner_name & "')"
	'Conn.Execute(sqlstat3)

	'inserting values to table login_rcmc from application form
	'sqllogin="insert into login_rcmc values ('" & User_id & "','" & Password & "')"
	'Conn.Execute(sqllogin)

	'inserting values to table login_rcmc_details from application form
	'sqllogin_details="insert into login_rcmc_details values (" & App_form_no &",'" & User_id & "','" & Password & "')"
	'response.write(sqllogin_details)
	'Conn.Execute(sqllogin_details)
	
	'turn_over=cdbl(0)
	'	sql_addtional="insert into exporter_rcmc_additional values(" & App_form_no & ",'new','new'," & turn_over & ",'" & Keyperson & "','" & Fax_no & "')"
	'	Conn.Execute(sql_addtional)

	'	sql="delete from exporter_rcmc_temp where iecode='"& iecode &"'"
		'response.write(sql)	
	'	conn.execute(sql)
	'end if
	'Conn.Close
	session("insert")=true
%> 
<%
Session("userid")=u
%> 
                        <p>
						
						<font color="#004921"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633">Payment 
                          Transation ID</font><FONT SIZE="" COLOR="#FF9933"> : <%=session("rapp_no")%></FONT></b>&nbsp;<br>
                          </b></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><br>
                          <font color="#336633">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Registration 
                          Number &nbsp;&nbsp;&nbsp;&nbsp;:</font></b> <font color="#FF9933"><b><%=r%></b></font></p>
						  						<p>
						<font color="#004921"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633"></font><FONT SIZE="" COLOR="#FF9933"> </FONT></b>&nbsp;<br>
                          </b></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><br>
                          <font color="#336633">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User ID 
                           &nbsp;&nbsp;&nbsp;&nbsp;:</font></b> <font color="#FF9933"><b><%=User_id%></b></font></p>
						<p>
							<font color="#004921"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633"></font><FONT SIZE="" COLOR="#FF9933"> </FONT></b>&nbsp;<br>
                          </b></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><br>
                          <font color="#336633">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PassWord
                           &nbsp;&nbsp;&nbsp;&nbsp;:</font></b> <font color="#FF9933"><b><%=Password%></b></font></p>

                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633">Registration 
                          Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;:</font></b><font color="#FF9933"><b><%=date()%></b></font> 
                          <%
'**************************************************** Auto responder 
'html="<table width=99% border=0 cellpadding=0 cellspacing=0><tr>    <td width='23%' height='104'><img src='http://209.61.214.16/ecom/images/apedalogo.jpg' width='140' height='80'></td>   <td width='32%' height='104' align='bottom'>       <div align='left'><b></b></div>    </td>    <td width='45%' height='104'>&nbsp;</td>    <td width='0%' height='104'>&nbsp;</td>  </tr>  <tr>     <td width='23%'>&nbsp;</td>    <td colspan='2' valign='top'>       <p><b><font color='#757575' size='4'>Dear Exporter,</font></b></p>      <p><b><font color='#757575' size='4'><img src='http://209.61.214.16/ecom/images/rose.jpg' width='200' height='100'></font></b></p>      <p><b><font color=#757575 size=2><font color=#9900FF size=2> </font> M/s "         & b & ".<br><br>You Have been Registered with APEDA and allocated <br>Registration No. as : "& r &". <br>Your Payment TransactionID is: "& session("rapp_no") &". <br>Your Account has been debited by Rs. 5000/- towards registration charges.<br>your User ID is :"& u &"<br>Password   :"& v &"  </font></b></p>      <b><font color=#757575 size=2>      </font></b>       <p><b><font color=#757575 size=2>It is to inform that the following online facilities have been launched :<br>1.Submission of Monthly Party Returns.<br>2.Submission of Financial Assistance Application.<br>        <br>You are suggested to use the online facilities regularly.<br>        <br>        <br>        <br>        </font><font color=#339966 size=2>PUSHPA<br>Manager<br>        APEDA</font> </b></p>      <p><font color='#0000CC'><b>Visit at : <a href='http://www.apeda.com'>http://www.apeda.com</a></b></font></p>    </td>    <td width='0%'>&nbsp;</td>  </tr>  <tr>     <td width='23%'>&nbsp;</td>    <td olspan='2'>&nbsp;</td>    <td width='0%'>&nbsp;</td>  </tr></table>"
'set mymail=server.createobject("CDONTS.newmail")
'mymail.mailformat=0
'mymail.bodyformat=0
'mymail.from="new_rcmc@indiatimes.com"
'mymail.to=h 
'mymail.subject="Registration With APEDA"
'mymail.body=html
'mymail.bcc="new_rcmc@indiatimes.com,vtf@indiatimes.com"
'mymail.send
'set mymail=nothing
'******************************************************************
%> </p>
                        <p>
<% 
'ELSE
	pass=false
	'Response.Write("<b><font size='3' color='#FF0000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Some Error Has Occurred !!! .<br>Please Do The Registration Process Again.<br> If Any Amount Debited Twice For The Same Process, APEDA Will Refund the Amount.  </font></b><br>")
	'session.Abandon
%>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="reg_form.asp">Click 
							  Here to Enter IE Code Again </a> 
<%
'end if
%> </p>
                        

<%'else
pass=true
%>
<p><font color="#004921"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633">Payment 
                          Transation ID</font><FONT SIZE="" COLOR="#FF9933"> : RCMC - <%=session("rapp_no")%></FONT></b>&nbsp;<br>
                          </b></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><br>
                          <font color="#336633">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Registration 
                          Number &nbsp;&nbsp;&nbsp;&nbsp;:</font></b> <font color="#FF9933"><b><%=r%></b></font></p>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color="#336633">Registration 
                          Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;:</font></b><font color="#FF9933"><b><%=date()%></b></font> 
                        
<%'end if%>

</td>

<%
if pass then
%>
                      <td align="right" width="42%" bgcolor="#FFFFFF"><img src="../images/rose.jpg" width="242" height="156"> 
                      </td>
 <%
else
 %>
                      <td align="right" width="1%" bgcolor="#FFFFFF">&nbsp; </td>
 <%
 end if
 %>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
         
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <!--   This table was automatically created with Macromedia Fireworks 3.0   -->
  <!--   http://www.macromedia.com   -->
</table>
<!--------------------------- STOP COPYING THE HTML HERE --------------------------->
<!--#include file="left.inc" -->
</form>
</body>
</html>
