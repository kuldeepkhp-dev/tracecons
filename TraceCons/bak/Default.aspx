<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="_Default, App_Web_qqg4g2bw" title="Importer Module" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    <input name="challenge" type="hidden" value="$$CHALLENGE" /><input id="apeda" runat="server"
        type="hidden" />
    <input id="wrongCount" runat="server" type="hidden" value="0" />
  
    <table align="center">
       <%-- <tr>
            <td align="left" class="row1" colspan="2">
            
            <a href="javascript:void(0);" onclick="javascript:OpenWindowBig('http://www.apeda.com/apedawebsite/grapenet/reports_on_grape_shipment.htm','about')" >
   <BLINK><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: medium; BACKGROUND: #ff8000">About this service </SPAN></BLINK>
    </a>
    
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" class="row2" align="center">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Value="Exp">Exporter</asp:ListItem>
                    <asp:ListItem Value="Imp" Selected="True">Importer</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" class="row1" colspan="2">
                Importer Login</td>
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
                <asp:Label ID="lblPwd" runat="server" CssClass="row2" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" class="row2" colspan="2">
                </td>
        </tr>
         <tr>
            <td colspan="2" align="right" class="row2">
                <strong>
             <font color="green">   Existing Subscriber! </font> </strong>
              
               &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="88px" />
            </td>
           
          
        </tr>
        
        
        <tr>
            <td colspan="2" class="row2" align="center"> <a href="newReg.aspx"><strong>New Subscriber! Click here</strong></a><strong>
            </strong>
            </td>
                    
        </tr>
      
    </table>






</asp:Content>

