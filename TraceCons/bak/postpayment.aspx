<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="postpayment, App_Web_qqg4g2bw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    &nbsp;<table width="100%">
        <tr>
            <td align="center" class="row1" colspan="3">
                Payment Message</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="row2" width="400">
                <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
                <asp:Label ID="lblResponseMsg" runat="server"></asp:Label><br />
                <asp:Label ID="lblTranID" runat="server"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="row2">
                <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Click here to re-login.</asp:LinkButton></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

