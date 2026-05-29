<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay"   MaintainScrollPositionOnPostback="false"
    EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.NET Integration Kit - Request page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style>
	    h1       { font-family:Arial,sans-serif; font-size:24pt; color:#08185A; font-weight:100; margin-bottom:0.1em}
        h2.co    { font-family:Arial,sans-serif; font-size:24pt; color:#FFFFFF; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
        h3.co    { font-family:Arial,sans-serif; font-size:16pt; color:#000000; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
        h3       { font-family:Arial,sans-serif; font-size:16pt; color:#08185A; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
        body     { font-family:Verdana,Arial,sans-serif; font-size:11px; color:#08185A;}
	    th 		 { font-size:12px;background:#015289;color:#FFFFFF;font-weight:bold;height:30px;}
	    td 		 { font-size:12px;background:#DDE8F3}
	    .pageTitle { font-size:24px;}
    </style>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" bgcolor="#ECF1F7">
<center>
    <table width="100%" cellpadding="0" cellspacing="0" ><tr><th width="90%">&nbsp;</th></tr></table>
	<center><h3>Payment Process</h3></center>
	<form  method="post" action="Post.aspx" name="frmTransaction" id="frmTransaction" runat="server" >  
	<table id="Table1" width="600" name="tblTransDetails" runat="server" cellpadding="2" cellspacing="2" border="0">
	<tr>
	<td colspan="2"> <b>Transaction Details </b> </td>
	</tr>
	<tr>
	<td> Order No.</td>
	<td> 
         <asp:Label ID="lblOrderNo" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td> Amount Payable</td>
	<td> <asp:Label ID="lblAmountPayable" runat="server" Text=""></asp:Label> </td>
	</tr>
	<tr>
	<td colspan="2" align="center">   <input name="submitted" value="Submit" type="submit" />  </td>
	</tr>
	</table>
	<div style="height:1px;width:1px;visibility:hidden;">
    <table width="600" name="tblTrans" cellpadding="2" cellspacing="2" border="0">
    <tr>
        <th colspan="2">Transaction Details</th>
    </tr>
	<tr>
        <td class="fieldName"><span class="error">*</span> Channel</td>
        <td align="left"><select name="channel" >
			<option value="10">Standard</option>
		</select></td>
    </tr>
	<tr>
        <td class="fieldName" width="50%"><span class="error">*</span> Account Id</td>
        <td  align="left" width="50%"> <input runat="server" id="account_id" name="account_id" type="text" value="18658"/><br><span><font color="red"> Please Enter your Account ID provided.</font></span> </td> 
    </tr>
    <tr>
        <td class="fieldName" width="50%"><span class="error">*</span> Secret Key</td>
        <td  align="left" width="50%"> <input runat="server" id="secretkey" name="secretkey" type="text" value="8fa1b0529d5cba8ea9cf5a437464805f" size="35"/><br><span><font color="red"> Please Enter your Secret Key provided.</font></span></td>
    </tr>
	<tr>
        <td class="fieldName" width="50%"><span class="error">*</span> Reference No</td>
        <td  align="left" width="50%"> <input  runat="server" name="reference_no" id="reference_no" runat="server" type="text"  /></td>
    </tr>
    <tr>
        <td class="fieldName" width="50%"><span class="error">*</span> Sale Amount</td>
        <td  align="left" width="50%"> 
            <input name="amount" id="amount" runat="server" type="text"  /> 
            <select name="currency" >
			<option value="INR">INR</option>
		</select></td>
    </tr>
	<tr>
        <td class="fieldName">Additional Currency</td>
        <td align="left"><select name="display_currency" >
			<option value="INR">INR</option>
			<option value="USD" selected>USD</option>
			<option value="EUR" selected>EURO</option>
			<option value="GBP" selected>GBP</option>
		</select></td>
    </tr>
	<tr>
        <td class="fieldName" width="50%">Additional Currency Rate</td>
        <td  align="left" width="50%"> <input id="display_currency_rates" name="display_currency_rates" runat="server" type="text" value="1" /></td>

    </tr>
    <tr>
        <td class="fieldName" width="50%"><span class="error">*</span> Description</td>
        <td  align="left" width="50%"> <input name="description" id="description" runat="server" type="text"  /></td>
    </tr>
		    <tr>
        <td class="fieldName"><span class="error">*</span> Return Url</td>

        <td align="left"><input name="return_url" id="return_url" runat="server" type="text" size="60"  /> </td>
    </tr>
	<tr>
        <td class="fieldName"><span class="error">*</span> Mode</td>
        <td align="left"><select name="mode" >
			<option value="LIVE" selected>LIVE</option>
		</select> </td>
    </tr>
	
	<tr>
        <td class="fieldName">Page ID</td>
        <td align="left">
            <input name="page_id" type="text" value="2652" /> 
        </td>
    </tr>
    <tr>
        <th colspan="2">Billing Address</th>
    </tr>
	<tr>
        <td class="fieldName"><span class="error">*</span> Name</td>
        <td align="left">
            <input name="name" id="name" type="text" runat="server" /></td>
    </tr>       
    <tr>

        <td class="fieldName"><span class="error">*</span>Address</td>
        <td align="left">
            <textarea name="address"  id="address" runat="server"></textarea>
        </td>
    </tr>
    <tr>
        <td class="fieldName"><span class="error">*</span>City</td>

        <td align="left">
            <input name="city" id="city" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName">State/Province</td>
        <td align="left">
            <input name="state" id="state" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName"><span class="error">*</span>ZIP/Postal Code</td>
        <td align="left">
            <input name="postal_code" id="postal_code" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName"><span class="error">*</span>Country</td>
        <td align="left">
            <input name="country" id="country" type="text" runat="server" value="IND" />
        </td>
    </tr>
    <tr>
        <td class="fieldName"><span class="error">*</span>Email</td>
        <td align="left">
            <input name="email" id="email" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName"><span class="error">*</span>Telephone</td>
        <td align="left"><input name="phone" id="phone" type="text" runat="server" /></td>
    </tr>		
    <tr>
        <th colspan="2">Delivery Address</th>
    </tr>
	<tr>
        <td class="fieldName">Name</td>
        <td align="left">
            <input id="ship_name" name="ship_name" type="text" runat="server" />
        </td>
    </tr>       
    <tr>
        <td class="fieldName">Address</td>
        <td align="left">
            <input id="ship_address" name="ship_address" type="text" runat="server" />
        </td>
    </tr>

    <tr>
        <td class="fieldName">City</td>
        <td align="left">
            <input id="ship_city" name="ship_city" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName">State/Province</td>
        <td align="left">
            <input id="ship_state" name="ship_state" type="text" runat="server"/>
        </td>
    </tr>
    <tr>
        <td class="fieldName">ZIP/Postal Code</td>
        <td align="left">
            <input id="ship_postal_code" name="ship_postal_code" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="fieldName">Country</td>
        <td align="left"><input id="ship_country" name="ship_country" type="text" runat="server" value="IND" /></td>
    </tr>
    <tr>
        <td class="fieldName">Telephone</td>
        <td align="left"><input id="ship_phone" name="ship_phone" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td valign="top" align="center" colspan="2">
            &nbsp; 
            <input value="Reset" type="reset" />
        </td>
    </tr>
    <tr>
        <td valign="top" align="center" colspan="2">
            <span class="error">*</span> 
            <span>denotes required field</span>
        </td>
    </tr>
</table>
</div>
    </form>
</center>
</body>
</html>
