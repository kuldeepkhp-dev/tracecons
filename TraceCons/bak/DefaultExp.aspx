<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="_Default, App_Web_dlg9uj0z" title="Exporter Module" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    <input id="apeda" runat="server"
        type="hidden" />
    <input id="wrongCount" runat="server" type="hidden" value="0" /><br />
    <table align="center">
    <%--<tr>
            <td align="left" class="row1" colspan="2">
            
            <a href="javascript:void(0);" onclick="javascript:OpenWindowBig('http://www.apeda.com/apedawebsite/grapenet/reports_on_grape_shipment.htm','about')" >
   <BLINK><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: medium; BACKGROUND: #ff8000">About this service </SPAN></BLINK>
    </a>
    
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" class="row2" align="center">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="Exp">Exporter</asp:ListItem>
                    <asp:ListItem Value="Imp">Importer</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" class="row1" colspan="2">
                Exporter Login</td>
        </tr>
        <tr>
            <td class="row1">
                RCMC No.</td>
            <td class="row2">
                <asp:TextBox ID="txtRCMCNo" runat="server" Width="150px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRCMCNo"
                    Display="Dynamic" ErrorMessage="*Enter valid RCMC number" ValidationExpression="^\d{1,20}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="row1"> Login ID       </td>
            <td class="row2">  
                <asp:TextBox ID="txtloginID" runat="server" Width="150px"></asp:TextBox>    </td>
          
        </tr>
         <tr>
            <td class="row1"> Password    </td>
            <td class="row2">   
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>    </td>
          
        </tr>
        <tr>
            <td align="center" class="row2" colspan="2">
                <table id="tblCatcha" runat="server">
                    <tr>
                        <td align="center">
                            Enter the correct password above and then type the
                            <br />
                            characters you see in the picture below.
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <img id="chapthca" runat="server" src="JpegImage.aspx" /><br />
                            Letters are not case-sensitive
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblPwd" runat="server" CssClass="row2" ForeColor="Red"></asp:Label></td>
        </tr>
         <tr>
            <td colspan="2" align="right" class="row2">
                <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="75px" />
            </td>
           
          
        </tr>
        
        
        <tr>
            <td colspan="2" class="row2" style="height: 12px">
            </td>
                    
        </tr>
      
    </table>
    <table>
    <tr>
    <td class="row2">
        
   <strong style="color: red"> Caution: </strong><strong > We recommend to you not to share RCMC Number, UserID and Password with anybody, otherwise he will be able to access information of all your grape shipments
        all over Europe. </strong>
    </td>
    </tr>
    </table>
    






</asp:Content>

