<%@ page language="C#" autoeventwireup="true" inherits="ExporterDetails, App_Web_ixcqzp9m" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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

<table width="100%" class="row1">
<TR>
    <td align="left" >
        <strong><span style="font-size: 10pt">Exporter Contact Detail(s)</span></strong><a href="javascript:void(0);"></a></td>
	<TD align="right" ><a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a></TD>
</TR>
</table>
    <table align="center">
     <tr>
            <td colspan="2" class="row1">
                        
            </td>
            
           
        </tr>
      <%  if (Session["Module"].ToString() != "IMP")
            {
            %> 
        <tr>
            <td class="row1" style="height: 20px">IECODE
            </td>
            <td class="row2" style="height: 20px">
                <asp:Label ID="lblIecode" runat="server" Text=""></asp:Label>
            
            </td>
           
        </tr>
        <tr>
            <td class="row1">APEDA Reg. No.
            </td>
            <td class="row2">
             <asp:Label ID="lblRcmcNo" runat="server" Text=""></asp:Label>
            
            </td>
            
        </tr>
        <%} %>
        <tr>
            <td class="row1">Exporter Name
            </td>
            <td class="row2">
             <asp:Label ID="lblExp_name" runat="server" Text=""></asp:Label>
            
            </td>
           
        </tr>
        
         <tr>
            <td class="row1">Exporter Address
            </td>
            <td class="row2">
             <asp:Label ID="lblExp_address" runat="server" Text=""></asp:Label>
            </td>
           
        </tr>
        
        
         <tr>
            <td class="row1">State 
            </td>
            <td class="row2"> <asp:Label ID="lblStatename" runat="server" Text=""></asp:Label>
            
            </td>
           
        </tr>
        <tr>
            <td class="row1">Country 
            </td>
            <td class="row2"> <asp:Label ID="Label1" runat="server" Text="INDIA"></asp:Label>
            
            </td>
           
        </tr>
        
        
         <tr>
            <td class="row1">Pin
            </td>
            <td class="row2">
            <asp:Label ID="lblPin" runat="server" Text=""></asp:Label>
            
            </td>
           
        </tr>
        
        
         <tr>
            <td class="row1">
                Telephone
            </td>
            <td class="row2">
             <asp:Label ID="lblTelePhone" runat="server" Text=""></asp:Label>
            
            </td>
           
        </tr>
        
         <tr>
            <td class="row1">Fax
            </td>
            <td class="row2">
            <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
            </td>
           
        </tr>
        
           <tr>
            <td class="row1">E-mail
            </td>
            <td class="row2">
             <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </td>
           
        </tr>
        
        
    </table>
  </form>
</body>
</html>
