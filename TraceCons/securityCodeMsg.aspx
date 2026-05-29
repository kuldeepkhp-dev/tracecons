<%@ Page Language="C#" AutoEventWireup="true" CodeFile="securityCodeMsg.aspx.cs" Inherits="securityCodeMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title>Importer Module</title>
    <link href="SSheets/MasterStyle.css" rel="stylesheet" type="text/css" />  
    <script language="javascript" src="JS/encmd5.js"></script>
    <script language="javascript" src="JS/JScript.js"></script>
    <script language="javascript" src="JS/date-picker.js"></script>
    <script language="javascript" src="JS/suycCalendar.js"></script>
    <script language="javascript" src="JS/AgmarkJScript.js"></script>
    
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
    <tr><td class="rowMsg" align="center" >
        Congratulations!<br />
        Your security code has been created successfully and&nbsp; mailed
        to your e-mail ID registered with APEDA.</td></tr>
    <tr><td align="center">
        <input id="Button1" type="button" onclick="javascript:parent.opener.location.reload();self.close()" value="Close" /></td></tr>
    </table>
    
    </form>
</body>
</html>
