<%@ page language="C#" autoeventwireup="true" inherits="ExpConsDetail, App_Web_ixcqzp9m" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <title>Exporter Module</title>
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
                    Details of&nbsp; containers of
                    <asp:Label ID="lblExporter" runat="server"></asp:Label>
                    Shipped to
                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GV_PSCIssued" runat="server" AutoGenerateColumns="False" CssClass="row2"
                         ShowFooter="True" OnRowDataBound="GV_PSCIssued_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="pdate" HeaderText="Date of PSC">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            
                            
                             <asp:TemplateField HeaderText="Container Number">
                                     <ItemTemplate>
                                     
                                     <a href="javascript:OpenWindowBig('ViewCons.aspx?ConsID=<%# DataBinder.Eval(Container.DataItem, "Container_No" ) %>','Detail')"><%# DataBinder.Eval(Container.DataItem, "Container_No")%></a>
                                     </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Right" />
                                     </asp:TemplateField>
                            
                            
                            <asp:BoundField DataField="Quantity_Declared" HeaderText="Quantity (in MT)">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <FooterStyle CssClass="row1" HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
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
