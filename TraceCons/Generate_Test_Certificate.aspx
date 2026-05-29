<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Generate_Test_Certificate.aspx.cs" Inherits="Residue_Analysis_Generate_Test_Certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Residue Monitoring Plan (Grapes)-Test Report</title>
    

    <link href="SSheets/Certificate.css" rel="stylesheet" type="text/css" />
    <style>div.break {page-break-before:always}</style>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Lab Logo + LabDetails Table -->
    <!--Header-->
    <%--<BR><BR><BR><BR><BR><BR>--%>
    <table width="100%">
    <tr>
    <td valign="top" width="65%"><asp:Image ID="imgLogo" runat="server" /></td>
    <td align="right">
        <FONT face=Verdana size=2><asp:Label ID="lblLabName" runat="server" Font-Bold="true" ></asp:Label><br />
        </FONT>
        <FONT face=Verdana size=2><asp:Label ID="lblLabAddress" runat="server"></asp:Label><br />
            <asp:Label ID="lblLabCity" runat="server"></asp:Label><br />
            <asp:Label ID="lblLabState" runat="server"></asp:Label><br />
            <asp:Label ID="lblLabPIN" runat="server"></asp:Label></FONT></td>
    </tr>
   
    </table>
        <BR><BR>
    <TABLE  width="100%" border=0>
  <TBODY>
  <TR>
    <TD width="100%" height=19>
          <TABLE width="100%" border=0>
                <TBODY>
                <TR>
                         <TD width="100%" bgColor=#c0c0c0>
                          <P align=center><B><FONT face="Arial Narrow" size=3>CERTIFICATE OF RESIDUE ANALYSIS</FONT></B></P>
                        </TD>
                </TR>
                </TBODY>
            </TABLE>
     </TD>
    </TR>
  <TR>
    <TD width="100%" height=0>
      
          <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
                     <TBODY>
                        <TR>
                          <TD noWrap align=right colSpan=4>
                          <FONT face=Verdana size=1><B>
                              <asp:Label ID="lblSampleType" runat="server"></asp:Label>&nbsp;&nbsp;</B></FONT>
                          </TD>
                         </TR>
                         <tr>
                             <td align="left" colspan="4">
                                 <asp:PlaceHolder ID="PHTop" runat="server"></asp:PlaceHolder>
                             </td>
                         </tr>
                         <TR>
                              <TD align=left>&nbsp; <FONT face=Verdana size=1><BR><B>Test Report No.<asp:Label ID="lblHReportNo" runat="server"></asp:Label></B></FONT></TD>
                              <TD align=left>&nbsp; <FONT face=Verdana size=1><BR><B>Report 
                                Date&nbsp;:&nbsp;<asp:Label ID="lblHreportDate" runat="server"></asp:Label></B></FONT></TD>
                              <TD noWrap align=right colSpan=2>&nbsp; <FONT face=Verdana 
                                size=1><BR><B>
                                    <asp:Label ID="lblHeadPage" runat="server"></asp:Label></B></FONT> 
                                    </TD>
                            </TR>
                        </TBODY>
             </TABLE>
      <TABLE height=27 cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY>
              <TR>
                  <TD vAlign=top width="4%" style="height: 25px"><FONT face=Verdana 
                    size=1>1)</FONT></TD>
                  <TD vAlign=top width="41%" style="height: 25px"><FONT face=Verdana size=1>Name 
                    &amp; Address of the Farmer </FONT></TD>
                  <TD width="55%" style="height: 25px"><FONT face=Verdana size=1><B>
                      <asp:Label ID="lblFarmerName" runat="server"></asp:Label>
                      ,
                      <asp:Label ID="lblAddress" runat="server"></asp:Label></B></FONT>
                  </TD>
              </TR>
                <TR>
                      <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                        size=1>2)</FONT></TD>
                      <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Name 
                        of the Exporter </FONT></TD>
                      <TD width="55%" height=25><FONT face=Verdana size=1><B>
                          <asp:Label ID="lblExpname" runat="server"></asp:Label></B></FONT>
                         </TD>
                   </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>3)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>Farm/Plot Registration No. </FONT></TD>
                          <TD width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblFarmRegno" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>4)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>Location of the Farm/Plot </FONT></TD>
                          <TD width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblLocation" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>5)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Area 
                            of the Farm/Plot(s) covered by this report (In Ha.) </FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblArea" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>6)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Total 
                            likely production of the Farm (in MT.) <BR>covered by this report 
                            [calculated on the basis of<BR>Annexure-2(for area purposes) and 
                            Annexure-4(B)]<BR><BR></FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblProduction" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>7)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Name 
                            of Grape's variety </FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblVariety" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>8)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>Sample Details </FONT></TD>
                          <TD vAlign=top width="55%" height=25></TD>
                    </TR>
                    <TR>
                          <TD width="4%" height=25>&nbsp;</TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>&nbsp; (a) Date of Sample drawn</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblSampleDraw" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25>&nbsp;</TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>&nbsp; (b) Quantity of Total Sample (In Kgs.)</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblSampleQty" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" style="height: 25px">&nbsp;</TD>
                          <TD vAlign=top width="41%" style="height: 25px"><FONT face=Verdana 
                            size=1>&nbsp; (c) Quantity of Lab Sample (In Kgs.)</FONT></TD>
                          <TD width="55%" style="height: 25px"><FONT face=Verdana 
                          size=1><B>
                              <asp:Label ID="lblLabQty" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25>&nbsp;</TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>&nbsp; (d) Packing</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>Packed as per Instructions of APEDA</B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25>&nbsp;</TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>&nbsp; (e) Sample Code No.</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblSample_CodeNo" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25>&nbsp;</TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>&nbsp; (f) Sampling Procedure</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana size=1><B>As 
                            per annexure(7) of APEDA guidelines</B></FONT> </TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>9)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Name 
                            of the representative <BR>who has drawn the sample</FONT><BR><BR></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblSample_draw" runat="server" BorderStyle="None"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top  width="4%" height=25><FONT face=Verdana 
                            size=1>10)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Date 
                            of drawl of sample</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblDateofDraw" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>11)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Date 
                            of receipt of sample in Laboratory</FONT></TD><!--  <td width="55%" height="25" valign=top><font face="Verdana" size="1"><b>17/02/2008</b></font></td> -->
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lbldateofreceive" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>12)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana size=1>Date 
                            of completion of&nbsp;analysis</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana 
                            size=1><B>
                                <asp:Label ID="lblDateofCompletion" runat="server"></asp:Label></B></FONT></TD>
                    </TR>
                    <TR>
                          <TD vAlign=top width="4%" height=25><FONT face=Verdana 
                            size=1>13)</FONT></TD>
                          <TD vAlign=top width="41%" height=25><FONT face=Verdana 
                            size=1>Method of Analysis</FONT></TD>
                          <TD vAlign=top width="55%" height=25><FONT face=Verdana size=1><B>As 
                            per the validated method harmonized by NRL<BR>(National Referral 
                            Laboratory)</B></FONT></TD>
                     </TR>
        </TBODY>
    </TABLE>
    
    
    <!-- Body -->
    
    
    
    
        <asp:PlaceHolder ID="PH" runat="server"></asp:PlaceHolder>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
     <!-- Footer of Page  -->  
    
   <TABLE width="100%" align=center border=0>
      <TBODY>
              <TR>
                <TD align=left><FONT face=Verdana size=1><B>BLQ - Below Limit of 
                  Quantification</B></FONT></TD>
               </TR>
       </TBODY>
   </TABLE>
<DIV class=break>
<TABLE width="100%" align=center border=0>
  <TBODY>
  <TR>
    <TD><BR><BR><BR><BR><BR><BR><BR><BR>
                  <TABLE cellSpacing=0 cellPadding=0 width="100%" align=center border=0>
                    <TBODY>
                        <TR>
                          <TD align=left style="height: 35px" colspan="3">
                              <asp:PlaceHolder ID="PHFooter" runat="server"></asp:PlaceHolder>
                          </TD>
                          </TR></TBODY></TABLE></TD>
                       </TR>
                      <TR>
                        <TD style="text-align: center" ><FONT face=Verdana 
                          size=2><B><U><BR><BR>CERTIFICATE</U></B></FONT></TD>
                      </TR>
                      <TR>
                        <TD><FONT face=Verdana size=1><B>1) This is to certify that the sample was 
                          drawn by our authorized representative from farm having Registration 
                          No:&nbsp;<U><asp:Label ID="lblFooterPlotNo" runat="server"></asp:Label></U>&nbsp;and has been analyzed by us. The sample 
                          was tested for the residue of the pesticides mentioned above and the 
                          residue content in the sample is as given in Column 3 of the table given 
                          above.</B></FONT></TD>
                      </TR>
                      <TR>
                        <TD><FONT face=Verdana size=1><B>2) The APEDA recognition of this 
                          laboratory is valid as on date.</B></FONT></TD>
                      </TR>
                       <TR>
                         <TD><FONT face=Verdana size=1></FONT>&nbsp;</TD>
                        </TR>
               </TBODY>
               </TABLE><BR>
            <TABLE width="100%" align=center border=0>
                  <TBODY>
                      <TR>
                        <TD style="height: 14px"><FONT face=Verdana size=1><B>Result 
                          :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sample <U>
                              <asp:Label ID="lblResultDesc" runat="server"></asp:Label></U></B></FONT></TD>
                       </TR>
                       
                   </TBODY>
               </TABLE><BR><BR><BR><BR><BR>

     
    
    
 
            <TABLE width="100%" align=center border=0>
              <TBODY>
              <TR>
                <TD><FONT face=Verdana size=1><B>Date&nbsp;:&nbsp;<asp:Label ID="lblFooterDate" runat="server"></asp:Label></B></FONT></TD>
                <TD><FONT face=Verdana size=1><B></B></FONT></TD>
                <TD><FONT face=Verdana size=1><B></B></FONT></TD>
                <TD align=right><FONT face=Verdana size=1><B>Signature of authorized 
                  signatory of</B></FONT></TD>
              </TR>
              <TR>
                <TD><FONT face=Verdana size=1><B>Place:<asp:Label ID="lblFooterPlace" runat="server"></asp:Label></B></FONT></TD>
                <TD><FONT face=Verdana size=1><B></B></FONT></TD>
                <TD><FONT face=Verdana size=1><B></B></FONT></TD>
                <TD align=right><FONT face=Verdana size=1><B>Nominated Laboratory along 
                  with seal</B></FONT></TD>
              </TR>
                  <!-- <tr>
		            <td nowrap><font face="Verdana" size="1" colspan=2 ><B><br><br><I>Note: This is a computer generated report and does not require any signature, if sent by e-mail.</I></b></font></td>
	            </tr> -->
	         </TBODY>
	     </TABLE>
        </DIV>
</TD>
</TR>
        </TABLE>
    </form>

</body>
</html>
