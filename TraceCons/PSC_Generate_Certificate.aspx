<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PSC_Generate_Certificate.aspx.cs" Inherits="Exporter_Payment_PSC_Generate_Certificate" %>
<asp:Content ID="cnt" ContentPlaceHolderID="RegCPH" Runat="Server">
 <table width="100%">
    <tr><td align="right" width="100%" class="row1"><a href="javascript:void(0);"><IMG onclick="javascript:displayHTML(printarea.innerHTML)" src="images/Print.jpg" border="0"></a></td>
	<TD align="right" width="0"><a href="javascript:void(0);"><IMG onclick="javascript:self.close()" src="images/btnClose.jpg" border="0"></a></TD>
</TR>
    </table>
    
   <div id='printarea'>
<table border='1' align='center' bordercolor='#330033'  height='75' cellpadding='1' cellspacing='0' width='100%'>

<tr>
<td width='14%' rowspan='2' height='69' align='center'><IMG SRC=images/asoka.jpg  BORDER='0' ></td>
<td width='68%' rowspan='2' height='69'>
<p align='center'><BR>
	 <align>GOVERNMENT OF INDIA<BR>
  <align='center'>MINISTRY OF AGRICULTURE<BR> 
  <align='center'>&nbsp;&nbsp;DEPARTMENT OF AGRICULTURE &amp; COOPERATION<BR> 
  <align='center'><ALIGN='CENTER' /><BR />DIRECTORATE OF PLANT PROTECTION, QUARANTINE &amp; STORAGE<br> 
  <align='center'>
    &nbsp;&nbsp;NH-IV Faridabad, Haryana State&nbsp;
  <p align='center'><b>PHYTOSANITARY CERTIFICATE</b></td>
  <td rowspan='2' colspan='3' height='69' align='center' nowrap><B>PSC No.&nbsp;&nbsp;<asp:Label ID="lblCertificateNo" runat="server"></asp:Label></B><br>________________________<br>E/Reg No.&nbsp;<asp:Label ID="lblE_RegnNo" runat="server"></asp:Label></td>
  </tr>
</table>



<table border='1' width='100%' cellpadding='0' cellspacing='0'>
 <tr>
<td width='50%'  valign='top'>1.&nbsp; From&nbsp;
 <p align=center><B>PLANT PROTECTION ORGANISATION OF INDIA</B></td>

<td width='50%' valign='top' colspan='2'>2.&nbsp; To <p align=center><b>PLANT PROTECTION ORGANISATION OF <br>&nbsp <asp:Label ID="lblImpCountry" runat="server"></asp:Label>
    </b></td>
</tr>

<tr>
 <td width='100%' colspan='3' valign='top'>
 <p align='center'>DESCRIPTION OF CONSIGNMENT</td>
</tr>

<tr>
<td width='50%' valign='top'>3.&nbsp;&nbsp;Declared Name & Address of Exporter<p align=center><b> & 
    <asp:Label ID="lblExpName" runat="server"></asp:Label><BR> <asp:Label ID="lblExpAddress" runat="server"></asp:Label>
    <br></b>Pincode - 
    <asp:Label ID="lblPIN" runat="server"></asp:Label><br> 
    <asp:Label ID="lblState" runat="server"></asp:Label>
</td>
<td width='50%' valign='top' colspan='2'>4.&nbsp;&nbsp;Declared Name & Address of Consignee<p align=center><b> <asp:Label ID="lblImpName" runat="server"></asp:Label></b>
    <p align="center">
        <b><asp:Label ID="lblImpAddress" runat="server"></asp:Label></b></p>
</td>
</tr>

<tr><td colspan=3>

<table width='100%' border=0><tr>

<td valign='middle' width='18%'>5.&nbsp;&nbsp;Declared means of conveyance:</td><td width='3%' align=center><B> 
    <asp:Label ID="lblModeOfShipment" runat="server"></asp:Label></B></td>
<td valign='middle' width='14%'>6.&nbsp; Place of origin : <B>INDIA</B></td>
<td valign='middle' width='12%' nowrap>7.&nbsp; Declared Port of Entry :</td><td width='10%'><B> 
    <asp:Label ID="lblPortofEntry" runat="server"></asp:Label></B></td>

</tr></table>

</td></tr>


<tr>
<td width='50%' valign='top'>8.&nbsp;&nbsp; Distinguising Marks <p align=center><b> 
    <asp:Label ID="lblDistinguishMark" runat="server"></asp:Label></b></td>
<td width='50%' colspan='2'>9.&nbsp; Number & description of packages<p align=center>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<B> 
    <asp:Label ID="lblPackageTypeIdentification" runat="server"></asp:Label></B>

</p></td>
 </tr>

<tr>
<td width='50%' valign='top'>10. Name of produce / Botanical name of plants<p align=center><B>Table Grapes / <I>vitis venifera</I></B></td>
<td width='50%' colspan='2' valign='top'>11.Quantity declared<p align=center><b> 
    <asp:Label ID="lblQuuntity" runat="server"></asp:Label> (in MTs)</b></td>
</tr>

<tr>
<td width='100%' colspan='3'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This is to certify that the plants or the plant products described above have been inspected according to appropriate procedures and are considered to be free from quarantine pests and practically free from other injurious pests and they are considered to conform with the current phytosanitary regulations of the importing country.</td>
</tr>
	  
<tr>
<td width='100%' colspan='3' align='center'>DISINFESTATION AND / OR DISINFECTION TREATMENT</td>
</tr>
	  
<tr>
<td width='50%'><table border=0 width='100%'> <tr><td width='50%'>12.&nbsp;Date :-</td><td><b> 
    <asp:Label ID="lblTreatmentDate" runat="server"></asp:Label></B></td></tr></table></td>
<td width='50%' colspan='2'> <table border=0 width='100%'> <tr><td width='50%' nowrap>13. Treatment :-</td><td><B> 
    <asp:Label ID="lblTreatment" runat="server"></asp:Label></B></td></tr></table></td>
</tr>

<tr>
	
<td width='50%'><table border=0 width='100%'> <tr><td width='50%'>14.&nbsp;Chemical (Ingredients) :-</td><td><B> 
    <asp:Label ID="lblChemical" runat="server"></asp:Label></B></td></tr></table></td>
	
<td width='50%' colspan='2'><table border=0 width='100%'> <tr><td width='50%'>15.&nbsp;Duration &amp; Temperature :-</td><td><B> 
    <asp:Label ID="lblDurationTemp" runat="server"></asp:Label></B></td></tr></table></td>
</tr>
	
<tr>
<td width='50%'>16.&nbsp;Concentration :- <B>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblConcentration" runat="server"></asp:Label></B></td>

<td width='50%' colspan='2'><table border=0 width='100%'> <tr><td width='50%'>17.&nbsp;Additional information :-</td><td><B> 
    <asp:Label ID="lblAdditionalInfo" runat="server"></asp:Label></B></td></tr></table></td>
</tr>
<tr>
<td width='100%' colspan='3'> <table border=0 width='100%'> <tr><td width='25%'>18.&nbsp;Additional declaration :-</td><td><B> 
    <asp:Label ID="lblAdditionalDec" runat="server"></asp:Label></B></td></tr></table></td>
</tr>
</table>

<table border=1 width='100%' cellpadding=0 cellspacing=0>
<tr>
<td width='33%' height='33'> <table border=0 width='100%'><tr><td width='50%' style="height: 53px">Date :- </td><td style="height: 53px"><B> 
    <asp:Label ID="lblPSCCertificateDate" runat="server"></asp:Label></B></td></tr></table></td>
<td width='33%' rowspan='3' height='69' align='center' valign=bottom>Stamp of Organisation<br><br></td>
<td width='34%' rowspan='3' height='104' align='center' nowrap>Name of authorised officer <br><BR>

<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<B> 
    <asp:Label ID="lblName" runat="server"></asp:Label></B><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Label ID="lblDesignation" runat="server"></asp:Label><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Label ID="lblAddress" runat="server"></asp:Label><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Label ID="lblLocation" runat="server"></asp:Label>&nbsp;&nbsp;<br>_________________________________________<br>(Signature & Stamp of authorised officer)</td>
</tr>

<tr>
<td width='33%' height='36'><table border=0 width='100%'><tr><td width='50%'>Place of Issue :- </td><td><B> 
    <asp:Label ID="lblLocation1" runat="server"></asp:Label></B></td></tr></table></td>
</tr>
<tr>
<td width='33%' height='40'><table border=0 width='100%'><tr><td width='50%'>Code No. :-</td><td><B> 
    <asp:Label ID="lblCodeNo" runat="server"></asp:Label></B></td></tr></table></td>
</tr>
</table>

<table border='0' width='100%'  cellpadding=0 cellspacing=0>

<tr>
<td colspan='3'><br> No financial liability with respect to this certificate shall attach to the Ministry of Agriculture (Department of Agriculture and Co-operation), Government of India or any officers or its representative.<p align='center'> CONTAINER NO :- &nbsp;&nbsp&nbsp;&nbsp;<U><B><asp:Label ID="lblContainerNo" runat="server"></asp:Label></B></U></p>  </td>
</tr>

</table>
</div>
</asp:Content>

