<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="AGMARK_Generate_Certificate.aspx.cs" Inherits="AgamrkInspection_AGMARK_Generate_Certificate" %>

<asp:Content ID="cnt" runat="server" ContentPlaceHolderID="RegCPH">
<table width="100%" id="tblprint" runat="SERVER" >
<TR class="row1">
	<TD align="right" >
	<a href="javascript:void(0);"><IMG onclick="javascript:displayHTML(printarea.innerHTML)" src="images/Print.jpg" border="0"></a>
		<a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a>
	</TD>
	
</TR>
</table>
<div id="printarea">

<table width="100%" border="1">
    <tr>
        <td colspan="8" align="center">
            <strong>
                <img src="images/Ag_Logo.jpg" /><br />
                GOVERNMENT OF INDIA
                <br />
 
MINISTRY OF AGRICULTURE
                <br />
 
DEPARTMENT OF AGRICULTURE AND COOPERATION 
                <br />
 
DIRECTORATE OF MARKETING & INSPECTION
                <br />
                <br />
                <span style="text-decoration: underline">

 
CERTIFICATE OF AGMARK GRADING FOR EXPORT OF
                    <br />
 
FRESH FRUITS AND VEGETABLES </span></strong>
</td>
    </tr>
    <tr>
        <td style="height: 36px" valign="top">
            <strong>1.</strong></td>
        <td colspan="2" style="height: 36px" valign="top">
            <strong>Name of the Exporter (CA Holder)</strong></td>
        <td colspan="5" style="height: 36px" valign="top">
            <asp:Label ID="lblExporterName" runat="server"></asp:Label><br />
            <strong>RCMC No. : </strong><asp:Label ID="lblRCAC" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td valign="top">
            <strong>2.</strong></td>
        <td colspan="3" valign="top">
            <strong>Exporter Address </strong>
                <br />
                <asp:Label ID="lblExpAddress" runat="server"></asp:Label></td>
        <td valign="top" style="width: 28px">
            <strong>3.</strong></td>
        <td colspan="3" valign="top">
            <strong>Place of inspection (Pack House)</strong> 
                <br />
                <asp:Label ID="lblPackHouse" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td valign="top">
            <strong>4.</strong></td>
        <td colspan="3" valign="top">
            <strong>Country of origin </strong>
                <br />
                <asp:Label ID="lblOriginCntry" runat="server">India</asp:Label></td>
        <td valign="top" style="width: 28px">
            <strong>5.</strong></td>
        <td colspan="3" valign="top">
            <strong>Name of consignee and country of destination</strong><br />
                <asp:Label ID="lblDestination" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td valign="top">
            <strong>6.</strong></td>
        <td colspan="3" valign="top">
            <strong>Identification of means of transport</strong><br />
                <asp:Label ID="lblMode" runat="server"></asp:Label></td>
        <td valign="top" style="width: 28px">
            <strong>7.</strong></td>
        <td colspan="3" valign="top">
            <strong>Packer's /exporter's shipping marks</strong><br />
                <asp:Label ID="lblSippingMark" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td valign="top">
            <strong>8.</strong></td>
        <td valign="top">
            <strong>Packages (number, type and identification)</strong><br />
                <asp:Label ID="lblPackageNo" runat="server"></asp:Label></td>
        <td valign="top">
            <strong>9.</strong></td>
        <td valign="top">
            <strong>Name of product (Variety if the standard specifies)<br />
                </strong>
                <asp:datalist id="dlVar" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" 
								CellPadding="0">
								<HeaderTemplate>
									<table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
										<tr>
										<td colspan="2" align="center"><b>Table Grapes</b></td>
										</tr>
											<tr>
												
												<td ><b><B>Agmark Ins. ID </B> </b>
												</td>
												<td ><b><B>Variety </B></b>
												</td>
											</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td nowrap>
											<asp:Label id="lblAgmarkid" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "aimid" ) %>'>
											</asp:Label>
											
											
										</td>
										<td >
												<asp:Label id="lblVariety" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "VarietyName" ) %>'>
											</asp:Label>
										</td>
										
									</tr>
								</ItemTemplate>
                               <FooterTemplate>
                               </table>
                               </FooterTemplate>
							</asp:datalist>
                </td>
        <td valign="top" style="width: 28px">
            <strong>10.</strong></td>
        <td valign="top">
            <strong>Quality grade<br /></strong>
                            <asp:datalist id="dlGRADE" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" 
								CellPadding="0">
								<HeaderTemplate>
									<table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
											<tr>
												
												<td ><b><B>Agmark Ins. ID </B> </b>
												</td>
												<td ><b><B>Grade </B></b>
												</td>
											</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td nowrap>
											<asp:Label id="lblAgmarkid" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "aimid" ) %>'>
											</asp:Label>
											
											
										</td>
										<td >
												<asp:Label id="lblGrade" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "qp_Grade_Assigned" ) %>'>
											</asp:Label>
										</td>
										
									</tr>
								</ItemTemplate>
                               <FooterTemplate>
                               </table>
                               </FooterTemplate>
							</asp:datalist>
            
            <asp:Label ID="lblCAGID" runat="server"></asp:Label></td>
        <td valign="top">
            <strong>11.</strong></td>
        <td valign="top">
            <strong>Total weight in kg. gross/net<br /></strong>
             <asp:datalist id="dlBox" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" 
								CellPadding="0" OnItemDataBound="dlBox_ItemDataBound">
								<HeaderTemplate>
									<table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
											<tr>
												
												<td ><b><B>Agmark Ins. ID </B> </b>
												</td>
												<td ><b><B>No. of Boxes </B></b>
												</td>
												<td ><b><B>Qty.(Pack Size)</B> </b>
												</td>
												<td ><b><B>Total Qty.(in Kgs) </B></b>
												</td>
											</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td nowrap>
											<asp:Label id="lblAgmarkid" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "aimid" ) %>'>
											</asp:Label>
											
											
										</td>
										<td >
												<asp:Label id="lblNoofBox" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Noofbox" ) %>'>
											</asp:Label>
										</td>
										<td nowrap>
											<asp:Label id="lblQty" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "QtyinBox_kg" ) %>'>
											</asp:Label>
											
											
										</td>
										<td >
												<asp:Label id="lblTotalQty" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Total_Qty" ) %>'>
											</asp:Label>
										</td>
										
									</tr>
								</ItemTemplate>
                               <FooterTemplate>
                               <tr>
                               <td>Total</td>
                               <td>
                                   <asp:Label ID="lblTotBox" runat="server" Text=""></asp:Label></td>
                               <td></td>
                               <td>
                                   <asp:Label ID="lblTotQty" runat="server" Text=""></asp:Label></td>
                               </tr>
                               
                               <tr>
                               <td colspan="3">Total Quantity (in MTs)</td>
                               <td>
                                   <asp:Label ID="lblInMT" runat="server" Text=""></asp:Label></td>
                               
                               </tr>
                               </table>
                               </FooterTemplate>
							</asp:datalist>
            
            </td>
    </tr>
    <tr>
    <td valign="top">
    <b>12.</b>
    </td>
        <td colspan="7" valign="top">
            
                        <b> The above mentioned inspection body certifies, following inspection by sampling,
                            that the above goods correspond, at the time of inspection, to the grading and marking
                            standards in force.</b>
               
        </td>
    </tr>
    <tr>
        <td style="height: 19px" valign="top">
            <strong>13.</strong></td>
        <td style="height: 19px" valign="top">
            <strong>Comments / remarks </strong>
        </td>
        <td colspan="6" valign="top">
            <asp:Label ID="lblComments" runat="server"></asp:Label></td>
        
    </tr>
    <tr>
        <td style="height: 19px" valign="top">
            <strong>14.</strong></td>
        <td style="height: 19px" valign="top">
            <strong>Certificate No.</strong></td>
        <td colspan="6" style="height: 19px" valign="top">
            <asp:Label ID="lblCertificateNo" runat="server"></asp:Label></td>
        
    </tr>
    <tr>
        <td valign="top">
            <strong>15.</strong></td>
        <td valign="top">
            <strong>Period of validity </strong>
        </td>
        <td colspan="6" valign="top">
            <asp:Label ID="lblValidity" runat="server"></asp:Label></td>
        
    </tr>
    <tr>
        <td colspan="8" valign="top">
        <table width="100%" border="1">
        
        <tr>
        <td align="left" valign="bottom" style="width: 512px">
            <asp:Label ID="lblPlaceDate" runat="server"></asp:Label><br />
            <strong>Place and date of issue</strong></td>
        <td align="center" valign="top"> 
            <asp:Image ID="Image1" runat="server" Height="100px" Width="150px" /><br />
            _______________<br />
            <strong>Signature<br />
                <asp:Label ID="lblUserName" runat="server"></asp:Label><br />
                (Authorized Laboratory Officer)<br />
                <asp:Label ID="lblLabName" runat="server"></asp:Label><br />
            </strong>
        </td>
        </tr>
        
        </table>
        
        </td>
    </tr>
</table>
    
    </div>
</asp:Content>