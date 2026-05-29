<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="expseccode.aspx.cs" Inherits="expseccode"%>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr  class="row1">
            <td align="left">
               Enter Security Code</td>
            <td align="right">
                <a href="javascript:void(0);">
                    <img border="0" onclick="javascript:self.close()" src="images/btnClose.jpg" /></a></td>
        </tr>
    </table>
    <table align="center" width="50%">
        <tr>
            <td colspan="2"  class="row2"  align="right">
            <BLINK>
                &nbsp;<asp:LinkButton ID="hpSecurity" runat="server" OnClick="hpSecurity_Click" Font-Bold="True" Font-Size="Small" BackColor="GreenYellow">Click here to create your security code</asp:LinkButton></td>
                </BLINK>
        </tr>
        <tr>
            <td colspan="2"  class="row2"  align="right">
            
        </tr>
        <tr>
            <td class="row1" style="width: 251px">
                Enter Your Security Code</td>
            <td class="row2">
                <asp:TextBox ID="txtSecurity" runat="server"></asp:TextBox>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="row2" colspan="2">
                <asp:Label ID="lblmessage"
                    runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" class="row2" colspan="2" style="height: 28px">
                <asp:Button ID="btnProceed" runat="server" Text=" Continue >> " OnClick="btnProceed_Click" /><br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Forgot Security Code?"></asp:Label>&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click to re-create</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

