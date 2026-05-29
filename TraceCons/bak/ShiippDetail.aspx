<%@ page language="C#" autoeventwireup="true" inherits="ShiippDetail, App_Web_ixcqzp9m" %>

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
    <div>
        <table width="100%">
            <tr>
                <td align="center" class="row1" colspan="2">
                    Details of containers shipped to
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    *</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GV_PSCIssued" runat="server" AutoGenerateColumns="False" CssClass="row2"
                         ShowFooter="True" OnRowDataBound="GV_PSCIssued_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DateofConsignment" HeaderText="Date of PSC">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cnt" HeaderText="Number of Containers">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QtyInMT" HeaderText="Quantity   (in MT)">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <FooterStyle CssClass="row1" HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" class="row2" style="height: 15px">
                    <strong>* Shipped/Likely to be shipped in 2-3 days of the date of PSC. </strong>
                </td>
            </tr>
            <tr>
                <td align="left" class="row2" style="height: 15px">
                    <strong>Disclaimer : The schedule given above is indicative in nature. APEDA will not
                        take any responsiblity for any changes in arrival/departure schedule.</strong></td>
            </tr>
            <tr>
                <td align="center" style="height: 15px">
                    <input id="Button1" type="button" value="Close" onclick="javascript:self.close();" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
