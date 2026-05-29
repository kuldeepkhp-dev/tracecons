<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="AGMARK_Inspection_Report_AO.aspx.cs" Inherits="AgamrkInspection_AGMARK_Inspection_Report_FO" %>

<asp:Content ID="cnt" ContentPlaceHolderID="RegCPH" runat="server">

<table width="100%" border=0 cellpadding="0" cellspacing="0">
<TR class="row1">
    <td align="left"  style="width: 432px">
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True">[View Lot Detail]</asp:HyperLink></td>
	<TD align="right" >
	<a href="javascript:void(0);"><IMG onclick="javascript:displayHTML(printarea.innerHTML)" src="images/Print.jpg" border="0"></a>
	
	<a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a>
	
	</TD>
</TR>
</table>
<div id='printarea'>
<table width="100%">
<tr class="row2">
    <td colspan="2">
    
    </td>
    </tr>
    <tr class="row1">
    <td colspan="2" align="center">
        Agmark Inspection Report ID is
        <asp:Label ID="lblAgmarkID" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <strong>INSPECTION REPORT FOR
                <asp:Label ID="lblProduct" runat="server"></asp:Label></strong></td>
    </tr>
        <tr>
        <td >
            <strong>To</strong><br />
                <asp:Label ID="lblName" runat="server"></asp:Label><br />
            <asp:Label ID="lblDesignation" runat="server"></asp:Label><br />
            <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
            <asp:Label ID="lblCity" runat="server"></asp:Label><br />
            <asp:Label ID="lblPIN" runat="server"></asp:Label><br />
            <asp:Label ID="lblPhone" runat="server"></asp:Label></td>
        <td style="width: 125px; height: 121px;"></td>
    </tr>
    <tr>
        <td ></td>
        <td ></td>
    </tr>
    <tr>
        <td >
            <strong>Name of the commodity</strong></td>
        <td >
            <asp:Label ID="lblNameofCommodity" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Name of Authorised Packer</strong></td>
        <td >
            <asp:Label ID="lblPacker" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Address of Pack House</strong></td>
        <td >
            <asp:Label ID="lblPackHouseAddress" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Pack House No.</strong></td>
        <td style="height: 19px; width: 125px;">
            <asp:Label ID="lblPackHouseNo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Pack House Validity Date</strong></td>
        <td >
            <asp:Label ID="lblValidityDate" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Shipping Marks (if any) </strong>
        </td>
        <td >
            <asp:Label ID="lblShippingMark" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="2" align="center" >
            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" BorderColor="Black"
                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" OnRowDataBound="GV_RowDataBound"
                ShowFooter="True">
                <FooterStyle Font-Bold="True" />
                <Columns>
                    <asp:BoundField HeaderText="S.No." />
                    <asp:BoundField DataField="Noofbox" HeaderText="No of Boxes" />
                    <asp:BoundField DataField="QtyinBox_kg" HeaderText="Quantity in Box (Pack Size)" />
                    <asp:BoundField DataField="Total_Qty" HeaderText="Total Quantity (in Kgs)" />
                </Columns>
                <RowStyle BorderColor="Black" BorderWidth="1px" />
            </asp:GridView>
        
        
        
        </td>
    </tr>
    <tr>
        <td >
            <strong>Total Quantity (in MTs)</strong></td>
        <td >
            <asp:Label ID="lblTotalQTY" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Exporter Name</strong>
        </td>
        <td >
            <asp:Label ID="lblExporterName" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Exporter Email </strong>
        </td>
        <td >
            <asp:Label ID="lblExporterEmail" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td ></td>
        <td ></td>
    </tr>
    <tr>
        <td colspan="2">
            <strong>QUALITY PARAMETERS.</strong><br />
        </td>
    </tr>
    <tr>
        <td ></td>
        <td style="height: 19px; width: 125px;"></td>
    </tr>
    <tr>
        <td >
            <strong>Cleanliness </strong>
        </td>
        <td >
            <asp:Label ID="lblCleanliness" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Soundness</strong></td>
        <td >
            <asp:Label ID="lblSoundness" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Foreign Matter</strong>
        </td>
        <td >
            <asp:Label ID="lblForeignMatter" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Pests </strong>
        </td>
        <td >
            <asp:Label ID="lblPets" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>General Appearance</strong>
        </td>
        <td style="height: 19px; width: 125px;">
            <asp:Label ID="lblGeneralAppearance" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Damage Caused By Pests (or) Disease</strong></td>
        <td style="width: 125px; height: 19px">
            <asp:Label ID="lblDamageCausedbyPests" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Abnormal External Moisture </strong>
        </td>
        <td style="width: 125px; height: 19px">
            <asp:Label ID="lblAbnormalMoisture" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Foreign Smell/Taste</strong>
        </td>
        <td style="height: 19px; width: 125px;">
            <asp:Label ID="lblForeignSmell" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Damages Caused by High/Low Temperature</strong>
        </td>
        <td >
            <asp:Label ID="lblDamageCausedbyTemp" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Visible Traces of Moulds</strong>
        </td>
        <td >
            <asp:Label ID="lblVisibleTrace" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Condition of Berries</strong>
        </td>
        <td >
            <asp:Label ID="lblConditionOfBerries" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Berry Size (if applicable)</strong>
        </td>
        <td >
            <asp:Label ID="lblBerrySize" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Total Soluble Solids (Brix)</strong></td>
        <td style="height: 19px; width: 125px;">
            <asp:Label ID="lblTotalSolubleSolids" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Sugar/Acid Ratio</strong>
        </td>
        <td >
            <asp:Label ID="lblSugar" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Defects in Shape</strong></td>
        <td >
            <asp:Label ID="lblDefectInShape" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Defects in Color</strong>
        </td>
        <td >
            <asp:Label ID="lblDefectInColor" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Defects in Skin by Sun Scorch</strong></td>
        <td >
            <asp:Label ID="lblDeffectinSkinbySun" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Bruising</strong>
        </td>
        <td >
            <asp:Label ID="lblBruishing" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Skin Defects</strong></td>
        <td >
            <asp:Label ID="lblSkinDefect" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Size (weight of the bunch in grams)</strong></td>
        <td >
            <asp:Label ID="lblSize" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Percentage Grade Tolerances (%)</strong></td>
        <td >
            <asp:Label ID="lblPercentageGrade" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td >
            <strong>Remarks (if any)</strong></td>
        <td >
            <asp:Label ID="lblRemarks" runat="server" ></asp:Label></td>
    </tr>
     <tr>
        <td >
            <strong>Grade assigned </strong>
        </td>
        <td >
            <asp:Label ID="lblGradeAssigned" runat="server" ></asp:Label></td>
    </tr>
     <tr>
        <td >
            <strong>Recommended / Not Recommended for issue of CAG. </strong>
        </td>
        <td >
            <asp:Label ID="lblRecommendedCAG" runat="server" ></asp:Label></td>
    </tr>
     <tr>
        <td ></td>
        <td ></td>
    </tr>
     <tr>
        <td ></td>
        <td ></td>
    </tr>
     <tr>
        <td ></td>
        <td ></td>
    </tr>
     <tr>
        <td colspan="3">
        
          <table width="100%">
        
        <tr>
         <td style="width: 349px" >
            <strong>Dated :</strong><asp:Label ID="lblDate" runat="server"></asp:Label>
         </td>
         
        <td align="center" valign="middle">
            <asp:Image ID="Image1" runat="server" Height="100px" Width="150px" /><br />
                <strong>(Signature)<br />
                <asp:Label ID="lblFO" runat="server"></asp:Label><br />
                Name of the Approved Chemist</strong>
                
              </td>
        <td align="center" valign="middle">
            <asp:Image ID="Image2" runat="server" Height="100px" Width="150px" /><br />
                <strong>(Signature)<br />
                <asp:Label ID="lblLO" runat="server"></asp:Label><br />
                Name of the Authorized Laboratory Officer</strong>
        </td>
        
        <%--<td align="center" valign="middle">
            <asp:Image ID="Image3" runat="server" /><br />
                <strong>(Signature)<br />
                <asp:Label ID="lblAO" runat="server"></asp:Label><br />
                Name of the Authorized Agmark Officer</strong>
        </td>--%>
        </tr>
        
        </table>
        
    </tr>
    


</table>
</div>
</asp:Content>