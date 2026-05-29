<%@ page language="C#" autoeventwireup="true" inherits="CertificateIssue, App_Web_ixcqzp9m" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Certificate</title>
    <script language="javascript" src="JS/JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
    <tr><td align="right" width="100%"><a href="javascript:void(0);"><IMG onclick="javascript:displayHTML(printarea.innerHTML)" src="images/Print.jpg" border="0"></a></td>

</TR>
    </table>
	 <div id="printarea">

<TABLE class=TBCLASS1 cellSpacing=0 cellPadding=0 width="100%" border=1 bordercolor="#660000" >
<TR>
	<TD align="center">
<TABLE class="TBCLASS1" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td align="right" colspan="3" ><b>ANNEXURE 2A</b></td>
			</tr>
			<tr>
				<td class="certificatestyle" vAlign="middle" align="center">
				</td>
				<td align="center"><IMG src="images/emblem.jpg"></td>
				<td vAlign="middle" align="center">
				</td>
			</tr>
			<tr>
				<TD align="right" colspan="3">
					<h3 align="center">
                        <span style="font-family: Courier New">GOVERNMENT 
							OF </span>
							<asp:Label id="lblState" Font-Bold="True" runat="server"></asp:Label>
                        <br />
                        <span style="font-family: Courier New">DEPARTMENT 
							OF AGRICULTURE </span>
					</h3>
				</TD>
			</tr>
			<tr>
				<td align="center" colSpan="3"><font size="+1"><b><U>Certificate of Registration Of Grapes Farm 
								for Export</U></b></font></td>
			</tr>
		</TABLE>
		<br>
		<table class="TBCLASS1" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td colSpan="4" align="left">This is to certify that <b>
						<asp:label id="lblFarmerName" Font-Bold="True" runat="server"></asp:label>&nbsp;</b>is 
					here by registered as Grape Grower/Grape Exporter with the office of the 
					District Superintending Agriculture officer, <B>
						<asp:label id="lblDistrict2" Font-Bold="True" runat="server"></asp:label>&nbsp;</B>in 
					accordance with the APEDA residue monitoring plan for pesticides for export of 
					fresh grapes from India during the year&nbsp;
					<asp:label id="lblyear" Font-Bold="True" runat="server"></asp:label>&nbsp;as 
					per <B>APEDA Trade Notice No. 49 dated
						<asp:label id="lblIssueDate" Font-Bold="True" runat="server"></asp:label>. </B>
				</td>
			</tr>
			<tr>
				<td align="left" colSpan="4"><b><br>
						The details of the registered Grape Grower is as follows.<br>
						<br>
					</b>
				</td>
			</tr>
			<tr>
				<td align="left"><b>Name of the Grape Grower</b></td>
				<td align="left" colSpan="3"><asp:label id="lblrapeGroverName" runat="server"></asp:label>&nbsp;
				</td>
			</tr>
			<tr>
				
				<td align="left" style="height: 19px"><b>Full Address</b></td>
                <td align="left" colspan="1" style="height: 19px">
                    <asp:label id="lblAddress" runat="server"></asp:label></td>
                <td align="center" colspan="1" style="height: 19px">
                    <strong>Village</strong>
                </td>
				<td align="left" colSpan="3" style="height: 19px">
                    <asp:Label ID="lblVillage" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td align="left"><b>Taluk/Mandal</b>
				</td>
				<td><asp:label id="lblTaluk" runat="server"></asp:label></td>
				<td><b>District</b>
				</td>
				<td align="left"><asp:label id="lblDistrict" runat="server"></asp:label>&nbsp;
				</td>
			</tr>
		</table>
		<table borderColor="black" width="100%" border="1">
			<tr>
				<td align="center"><b>Sr.no.</b></td>
				<td align="center"><b>Survey/GAT No.</b></td>
				<td align="center"><b>Plot No.</b></td>
				<td align="center"><b>Variety</b></td>
				<td align="center"><b>Area of Plot(Ha.)</b></td>
				<td align="center"><b>Farm Reg.No.</b></td>
			</tr>
			<tr>
				<td align="center"><asp:label id="lblSn" runat="server"></asp:label></td>
				<td align="center"><asp:label id="lblGat" runat="server"></asp:label></td>
				<td align="center"><asp:label id="lblPlotNo" runat="server"></asp:label></td>
				<td align="center"><asp:label id="lblVariety" runat="server"></asp:label>&nbsp;
				</td>
				<td align="center"><asp:label id="lblArea" runat="server"></asp:label></td>
				<td align="center"><asp:label id="lblFarmNo" runat="server"></asp:label></td>
			</tr>
		</table>
		<table width="100%" border="0">
			<tr>
				<td align="left" colSpan="3"><b>1).</b> Map Layout enclosed.
				</td>
			</tr>
			<tr>
				<td align="left" colSpan="3"><b>2).</b> This certificate is valid up to<b>
						<asp:label id="lblValidDate" runat="server"></asp:label><U>.</U></b>
				</td>
			</tr>
			<tr>
				<td align="left" colSpan="3"><b>3).</b> have verified the Survey/GAT No. with 
					respect to the registration and to the best of my knowledge the above 
					information is correct.
				</td>
			</tr>
			<tr>
				<td colSpan="3"><br>
					&nbsp;
				</td>
			</tr>
			<tr>
				<td align="left" ><b>Place:
						<asp:label id="lblPlace" runat="server"></asp:label><br>
						Date:&nbsp;
						<asp:label id="lblDate" runat="server"></asp:label></b></td>
				<td align="left" style="width: 533px; height: 55px; text-align: center">
				
				<img id="barcode" runat="server"  alt="Global Location No." height=160 width=395/>
				
				</td>
				<td align="right" style="height: 55px; text-align: center"><b>Registration Authority and
						<br>
						District Superintending Agriculture Officer,<br>
						<asp:label id="lbldistrict1" runat="server"></asp:label></b></td>
			</tr>
			<tr>
				<td colSpan="4">
					<hr>
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" >
						<tr>
							<td style="height: 9px" align="left"><b>Terms &amp; Conditions of Registration of the Grape farm for Export</b></td>
						</tr>
						<tr>
							<td align="left"><b>a)</b> To follow only the recommended package of practices.
							</td>
						</tr>
						<tr>
							<td align="left"><b>b)</b> The Farmer shall not use pesticides other than those allowed for use 
								on grapes and listed in Annexure-7.
							</td>
						</tr>
						<tr>
							<td style="height: 7px" align="left"><b>c)</b> Misbranded,Non-recommended or banned pesticides or any harmfull 
								chemical shall not be used.
							</td>
						</tr>
						<tr>
							<td style="height: 17px" align="left"><b>d)</b> After drawal of sample for residue testing, spraying/application of 
								any pesticide shall not be carried out.&nbsp;
							</td>
						</tr>
						<tr>
							<td align="left"><b>e)</b> The registered farmer shall maintain record of package of practices 
								followed by them in a prescribed register to be prescribed by this office.
							</td>
						</tr>
						<tr>
							<td align="left"><b>f)</b> The registered farmer/exporter at the time of harvest shall give a 
								declaration in annexure-5 stating that no pesticide,insecticide,weedicides etc. 
								have been sprayed/applied after drawal of the sample for laboratory analysis.</td>
						</tr>
						<tr>
							<td align="left"><b>g)</b> No amendments will be made by them on the registration records or the 
								registration certificate.&nbsp;
							</td>
						</tr>
						<tr>
							<td align="left"><b>h)</b> Growers are not allowed for sampling or export of grapes from 
								unregistered farms.</td>
						</tr>
						<tr>
							<td align="left"><b>i)</b> Applicant should renew their certificates of registration of grapes 
								garden every year before 30th Nov. giving detail information.
							</td>
						</tr>
					</TABLE>
				</td>
			</tr>
		</table>

</TD>

</TR>
</TABLE>
</div>
    </form>
</body>
</html>

