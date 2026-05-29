<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ContainerTrack_Default1, App_Web_mhmux3x6" title="Operator Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
  <input id="wrongCount" runat="server" type="hidden" value="0" />
  <input name="challenge" type="hidden" value="$$CHALLENGE" />
  <input id="apeda" runat="server"  type="hidden" />
<table>
<tr>
<td colspan="2" class="row1"> Login Data Operator </td>
</tr>

<tr>
<td class="row1">User ID :</td>
<td class="row2"> 
    <asp:TextBox ID="txtloginID" runat="server"></asp:TextBox> </td>
</tr>

<tr>
<td class="row1">Password : </td>
<td class="row2"> <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox> </td>
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
                            <img id="chapthca" runat="server" src="../JpegImage.aspx" /><br />
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
<td  class="row1" colspan="2" align="right"> 
    <asp:Button ID="btnSignin" runat="server" Text="Sign in" OnClick="btnSignin_Click" /> </td>
</tr>

</table>

</asp:Content>

