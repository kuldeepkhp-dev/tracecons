<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Importer Module" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
     <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
     <script type="text/javascript">
            function Captcha() {
                debugger;
                var txtCaptcha_New = document.getElementById('<%= txtCaptcha.ClientID %>');
                txtCaptcha_New.value = "";
                var img = document.getElementById('<%= chapthca.ClientID %>');
                img.src = "JpegImage.aspx?id=" + Math.random();
            }
     </script>

     <link href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
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
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">                   
                         <ContentTemplate>
                            <img id="chapthca" runat="server" src="JpegImage.aspx" />
                               <asp:LinkButton runat="server" ID="btn_Refereshcaptch" class="btn btn-mini" ValidationGroup="None" 
                                 OnClick="btn_Refereshcaptch_Click"><i class="fa fa-refresh fa-lg" aria-hidden="true" style="color: #778899;position: absolute;margin-top: 20px; transform:scale(1.1,1.1)"></i></asp:LinkButton><br />
                                        Letters are not case-sensitive
                                           </ContentTemplate>
                           <Triggers>
            <asp:AsyncPostBackTrigger controlid="btn_Refereshcaptch" eventname="Click" />
        </Triggers>
                     </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:TextBox ID="txtCaptcha" runat="server" AutoComplete="Off"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblPwd" runat="server" ForeColor="Red"></asp:Label>
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

