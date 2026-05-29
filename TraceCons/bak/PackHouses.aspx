<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="PayAOther_PackHouses, App_Web_dlg9uj0z" %>

<asp:Content ID="cnt" runat="server" ContentPlaceHolderID="RegCPH">

<table width="100%" class="row1">
<TR>
    <td align="left" >
        <strong><span style="font-size: 10pt">Pack House Detail(s)</span></strong><a href="javascript:void(0);"></a></td>
	<TD align="right" ><a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a></TD>
</TR>
</table>

<table width="100%" >
<TR>
	<TD align="center" class="row1" colspan="2" >
        </TD>
</TR>

<TR>
	<TD align="center" class="row2" colspan="2" >
	
	<table runat="server" id="tblDisplay">
	
	<tr>
	    <td class="row1">Pack House No.</td>
	    <td class="row2">
            <asp:Label ID="lblpackhouse" runat="server" Text=""></asp:Label>
        </td>
	</tr>
   	<tr>
	    <td class="row1">Gs1 Company Prefix</td>
	    <td class="row2">
	    <asp:Label ID="lblgs" runat="server" Text=""></asp:Label>
	    </td>
	</tr>
	
	<tr>
	    <td class="row1">Name of Authorised Packer</td>
	    <td class="row2"><asp:Label ID="lblpacker" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	    <td class="row1">Email</td>
	    <td class="row2"><asp:Label ID="lblemail" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Address</td>
	    <td class="row2"><asp:Label ID="lbladdress" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Taluk</td>
	    <td class="row2"><asp:Label ID="lbltaluk" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Distt.</td>
	    <td class="row2"><asp:Label ID="lbldistt" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Pin</td>
	    <td class="row2"><asp:Label ID="lblpin" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">State</td>
	    <td class="row2"><asp:Label ID="lblstate" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Contact Person</td>
	    <td class="row2"><asp:Label ID="lblContactP" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Phone</td>
	    <td class="row2"><asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Mobile</td>
	    <td class="row2"><asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Fax</td>
	    <td class="row2"><asp:Label ID="lblFAX" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Date of Issue</td>
	    <td class="row2"><asp:Label ID="lblDateofIssue" runat="server" Text=""></asp:Label></td>
	</tr>

	<tr>
	    <td class="row1">Date of Expiry</td>
	    <td class="row2"><asp:Label ID="lblvalidityDate" runat="server" Text=""></asp:Label></td>
	</tr>
	
	
	
	
	</table>
	
	
	</TD>
	
</TR>

</table>

    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="col1">View pack house recognition certificate</asp:HyperLink>










</asp:Content>
