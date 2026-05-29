<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="PlotDetails, App_Web_qqg4g2bw" %>

<asp:Content ID="cnt" runat="server" ContentPlaceHolderID="RegCPH">

<table width="100%" class="row1">
    <tr>
        <td align="left" width="0">
            <strong><span style="font-size: 10pt">Registered Farm</span></strong></td>
	<TD align="right" width="0"><a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a></TD>
</TR>
    </table>

<TABLE id="Table1" cellSpacing="3" cellPadding="1" width="100%" border="0">
				
				
				<TR>
					<TD align="center" colSpan="4" class="row1"><B>Detail(s) of Registered Farm</B></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Farm Reg.No.</B></TD>
					<TD colSpan="3" class="row2"><asp:label id="lblRegNo" runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Farmer Name</B></TD>
					<TD class="row2"><asp:label id="lblFName" runat="server"></asp:label></TD>
					<TD class="row1"><B>Farmer Address</B></TD>
					<TD class="row2"><asp:label id="lblFaddress" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Pin Code</B></TD>
					<TD class="row2"><asp:label id="lblpin" runat="server"></asp:label></TD>
					<TD class="row1"><B>Telephone No.</B></TD>
					<TD class="row2"><asp:label id="lblPhone" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Area Per Plot</B></TD>
					<TD class="row2"><asp:label id="lblArea" runat="server"></asp:label></TD>
					<TD class="row1"><B>Survey/GAT No.</B></TD>
					<TD class="row2"><asp:label id="lblGat" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Variety</B></TD>
					<TD colSpan="3" class="row2"><asp:label id="lblVariety" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4" class="row2"><B>Farm Registration Details</B></TD>
				</TR>
				<TR>
					<TD class="row1" style="HEIGHT: 23px"><B>State</B></TD>
					<TD class="row2" style="HEIGHT: 23px"><asp:label id="lblSate" runat="server"></asp:label></TD>
					<TD class="row1" style="HEIGHT: 23px"><B>District</B></TD>
					<TD class="row2" style="HEIGHT: 23px"><asp:label id="lblDistrict" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="row1"><B>Taluk</B></TD>
					<TD class="row2"><asp:label id="lblTaluk" runat="server"></asp:label></TD>
					<TD class="row1" style="HEIGHT: 19px"><B>Date of Reg.</B></TD>
					<TD class="row2" style="HEIGHT: 19px"><asp:label id="lblDAteOfReg" runat="server"></asp:label></TD>
				</TR>
				
				<TR>
					<TD align="center" colSpan="4" class="row1"><asp:label id="lblerrorMsg" runat="server" Width="56px" Font-Bold="True"></asp:label></TD>
				</TR>
			</TABLE>
      <br />
    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="col1">View farm registration certificate</asp:HyperLink>

</asp:Content>
