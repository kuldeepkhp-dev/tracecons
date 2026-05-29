<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="forgotpasword.aspx.cs" Inherits="forgotpasword" Title="Forgot Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
 <TABLE id="Table1"  cellSpacing="1" cellPadding="3" align="center" bgColor="#cc6600"
				border="1">
					
				<TR>
					<TD class="row1" align="center" colSpan="2">
                        Forgot password&nbsp;
					</TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD class="row2" noWrap><B>Enter User ID</B></TD>
					<TD class="row2">
                        &nbsp;<asp:TextBox ID="txtUserID" runat="server" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID"
                            Display="Dynamic" ErrorMessage="Please enter User ID"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;
                    </TD>
				</TR>
     <tr>
         <td align="center" class="row2" colspan="2">
             <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="False" Visible="true"></asp:Label></td>
     </tr>
				<TR>
					<TD class="row2" align="center" colSpan="2">
						<asp:button id="btnProceed" runat="server" Text="Send Password" OnClick="btnProceed_Click"></asp:button>&nbsp;
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" /></TD>
				</TR>
			</TABLE> 
			
</asp:Content>

