<%@ Page Language="C#" MasterPageFile="~/MenuMasterPage.master" AutoEventWireup="true" CodeFile="TraceCons.aspx.cs" Inherits="TraceCons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="row1">
            <td align="center"  valign="middle">
                <strong><span style="font-size: 10pt">Know your container</span></strong></td>
            <td align="right"   valign="middle">
               <%-- <a href="javascript:self.close()">
                    <img border="0" src="images/btnClose.jpg" /></a></td>--%>
        </tr>
        
         <tr>
            <td align="center"  colspan="2" style="height: 26px">
            <table id="tblInp" runat="server" border="0" cellpadding="0" cellspacing="0" class="row2">
        <tr class="row2">
            <td align="right" class="row1">
                Enter Container Number</td>
            <td align="left" class="row2">
                <asp:TextBox ID="txtPSCCertificate" runat="server"></asp:TextBox>
                </td>
        </tr>
                <tr class="row2">
                    <td align="right" class="row1">
                        Enter CAG ID</td>
                    <td align="left" class="row2">
                        <asp:TextBox ID="txtCAGID" runat="server"></asp:TextBox></td>
                </tr>
        <tr class="row2">
           
            <td colspan="2" >
            <i>Enter Container Number and CAG ID&nbsp; above and <br />then type the characters you see in the picture below</i>
                <br /><IMG id="chapthca" src="JpegImage.aspx" runat="server"></td>
        </tr>
        
        <TR class="row2">
								
									<TD colspan="2">
										<asp:textbox id="txtCaptcha" runat="server"></asp:textbox><br />
										Letters are not case-sensitive <br />
										<asp:Label id="Errmsg" runat="server" ForeColor="Red"></asp:Label></TD>
								    </TR>
        
        
        <tr>
            <td align="center" class="row2" colspan="2" style="height: 26px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" /></td>
        </tr>
        </table>
      </td>
        </tr>
       
        <tr>
            <td align="left" colspan="2" >
            <br />
            
            <br />
                <table id="tblmessage" runat="server">
                    <tr>
                        <td valign="top">
                            <strong>1) </strong>
                        </td>
                        <td valign="top">
                            <strong>Your exporter has been requested to inform you the container number and CAG
                                ID for all your shipments. </strong>
                        </td>
                       
                    </tr>
                    <tr>
                        <td valign="top" >
                            <strong>2)</strong></td>
                        <td style="height: 15px">
                            <strong>Both fields are mandatory</strong></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong>3)</strong></td>
                        <td valign="top">
                            <strong>Even if there is a mistake in entering characters of container number, it will
                                correct itself on the basis of CAG ID. This means that CAG ID must be entered correctly</strong></td>
                    </tr>
                   
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 26px">
                <table id="tblData" runat="server" width="100%" class="row2" >
                    <tr>
                        <td class="row1">
                 <asp:datalist id="Datalist1" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" CssClass="row2"
        CellPadding="0" OnItemDataBound="Datalist1_ItemDataBound">
        <HeaderTemplate>
            <table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
                <TBODY>
                <tr> 
                 <td class="row1">
                                        <b>Container Number</b>
                                        
                                        </td>
                     <td class="row1"><b>Phytosanitary Certificate Number</b></td>
                    <td class="row1"><b>Agmark Certificate Number</b></td>
                    <td class="row1"><b>CAG ID</b></td>
                    <td class="row1"><b><FONT face="Arial" size="2"><B>Details </B></FONT> </b>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td class="row2" nowrap="nowrap">
                                        <asp:Label ID="lblCont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Container_No")%>'></asp:Label>
                               
                               
                            </td>
             <td class="row2" nowrap>
              <a href="javascript:void(0)" onclick="javascript:OpenWindowBig('PSC_Generate_Certificate.aspx?cagid=<%# DataBinder.Eval(Container.DataItem, "consignmentid" ) %>')"><%# DataBinder.Eval(Container.DataItem, "pscCertificate")%></a>
                    <asp:HyperLink ID="lblPSCCert" runat="server"></asp:HyperLink>
               </td>
                <td class="row2" nowrap>
                    <a href="javascript:void(0)" onclick="javascript:OpenWindowBig('AGMARK_Generate_Certificate.aspx?cagid=<%# DataBinder.Eval(Container.DataItem, "consignmentid" ) %>')"><%# DataBinder.Eval(Container.DataItem, "certificate_no")%></a>
                    <asp:Label ID="lblCAG" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "consignmentid1" ) %>' Visible="false"></asp:Label>
               </td>
                <td class="row2" nowrap>
                                <asp:Label id="CAGID" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Consignmentid" ) %>'>
                                </asp:Label>
                                
                            </td>
               <td class="row2">
                <asp:datalist id="dlView" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" CssClass="row2"
        CellPadding="0" OnItemDataBound="dlView_ItemDataBound">
                <HeaderTemplate>
                    <table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
                    <TBODY>
                       
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                           
                            <td class="row2">
                                <asp:DataGrid id="DataGrid1" runat="server" OnItemDataBound="DataGrid1_OnItemDataBound" AutoGenerateColumns="false" CellPadding="4" BackColor="White"
        BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Width="100%" CssClass="row2">
                                <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                            <ItemStyle CssClass="row2"></ItemStyle>
                            <HeaderStyle cssclass="row1" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                <Columns>
                                     <asp:HyperLinkColumn HeaderText="Agmark Inspection Report ID" DataTextField="aimid" DataNavigateUrlFormatString="javascript:OpenWindowBig('AGMARK_Inspection_Report_AO.aspx?AIMID={0}')"
                                    DataNavigateUrlField="AIMID"></asp:HyperLinkColumn>
                                    <asp:HyperLinkColumn HeaderText="Residue Analysis Report" DataTextField="Lab_Code_no" DataNavigateUrlFormatString="javascript:OpenWindowBig('Generate_Test_Certificate.aspx?lcn={0}')"
                                    DataNavigateUrlField="Lab_Code_no"></asp:HyperLinkColumn>
                                    
                                     <asp:HyperLinkColumn HeaderText="Farm Registration Number" DataTextField="FarmRegNo" DataNavigateUrlFormatString="javascript:OpenWindowBig('PlotDetails.aspx?frm={0}')"
                                    DataNavigateUrlField="FarmRegNo"></asp:HyperLinkColumn>
                                    <asp:TemplateColumn HeaderText="Total Quantity <br/>(in MTs.)" HeaderStyle-Width="15%" >
                                 
                                    <ItemTemplate >
                                        <asp:Label ID="lblLot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>' Visible="false"></asp:Label>
                                        <a href="javascript:void(0);" onMouseOver="javascript:document.getElementById('Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>').style.visibility='visible'"   class="more" onClick="flag=0" onmouseout="javascript:document.getElementById('Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>').style.visibility='hidden'"> 
                                        <asp:Label ID="lblQTY" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "qty" )%>'></asp:Label>
                                        </a>
                                        <br />
                                        <div align="center" id="Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>" style="visibility:hidden;border:1px solid #669900;position:absolute;width:auto;left:70%" class="row2" >
                                                 <asp:datalist id="dlBox" runat="server" CellPadding="0" BorderWidth="0px" ForeColor="Black" >
		                                            <HeaderTemplate>
			                                            <table id="tblheader" border="0" cellpadding="2" cellspacing="2">
					                                            <tr class="col2">
                                            						
						                                            <td nowrap><b><B>No. of <br /> Boxes </B></b>
						                                            </td>
						                                            <td nowrap><b><B>Pack Size<br />( In Kgs.)</B> </b>
						                                            </td>
						                                            <td nowrap><b><B>Total Qty. <br />(in Kgs.) </B></b>
						                                            </td>
						                                            <td nowrap><b><B>Class </B></b>
						                                            </td>
						                                            <td nowrap><b><B>Variety </B></b>
						                                            </td>
					                                            </tr>
		                                            </HeaderTemplate>
		                                            <ItemTemplate>
			                                            <tr class="col1">
                                            				
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
                                            				 <td >
						                                            <asp:Label id="Label1" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "qp_Grade_Assigned" ) %>'>
					                                            </asp:Label>
				                                            </td>
				                                             <td >
						                                            <asp:Label id="Label2" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "VarietyName" ) %>'>
					                                            </asp:Label>
				                                            </td>
			                                            </tr>
		                                            </ItemTemplate>
                                                   <FooterTemplate>
                                                                    
                                                   </table>
                                                   </FooterTemplate>
	                                            </asp:datalist>
	                                            
                                            </div>
                                    </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:HyperLinkColumn HeaderText="Name of Authorised Packer" DataTextField="packhousename" DataNavigateUrlFormatString="javascript:OpenWindowBig('packhouses.aspx?packhouse={0}')"
                                    DataNavigateUrlField="packhouseno"></asp:HyperLinkColumn>
                                     <asp:HyperLinkColumn HeaderText="Exporter Name" DataTextField="Exp_Name" DataNavigateUrlFormatString="javascript:OpenWindowBigS('ExporterDetail.aspx?IECODE={0}','Exporter')"
                                    DataNavigateUrlField="IECODE"></asp:HyperLinkColumn>
                                   
                                </Columns>
                            <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                            </asp:DataGrid>
                           </td>
                           
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
           </asp:datalist>
            </td>

        </ItemTemplate>
        <FooterTemplate>
         <tr> 
                     <td class="row1" colspan="3"><b> </b><B>
                        <asp:Label ID="lblGrandTotal" runat="server"></asp:Label> </B></FONT> </b>
                    </td>
                </tr>
                </table>
        </FooterTemplate>
        </asp:datalist>	
                        </td>
                    </tr>
                     <tr>
                    <td colspan="6" align="left">
                          <asp:datalist id="dlBot" runat="server" Width="100%" ForeColor="Black" BorderWidth="1px" CssClass="row2"
        CellPadding="0" OnItemDataBound="dlBot_ItemDataBound">
                <HeaderTemplate>
                    <table id="tblheader" width="100%" border="1" cellpadding="0" cellspacing="0">
                    <TBODY>
                       
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td class="row2" nowrap>
                            <asp:Label id="lblPDate"  runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "date_of_issue_psc" ) %>'>
                                </asp:Label>
                                <asp:Label id="lblCAG"  runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Consignmentid" ) %>'>
                                </asp:Label>
                                <asp:Label id="lbl"  runat="server" Font-Bold="true">
                                </asp:Label>
                                
                            </td>
                    
                          
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
           </asp:datalist>
                        <strong>Disclaimer : The schedule given above is indicative in nature. APEDA will not
                            take any responsiblity for any changes in arrival/departure schedule.&nbsp;</strong></td>
                    </tr>
                    <tr>
                    <td colspan="6" align="left">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">To know about another container, please click here</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            
        </tr>
        <tr>
            <td colspan="2">
                <table id="tbtNoData" runat="server" width="100%">
                    <tr>
                        <td align="center" class="row1">
                            Sorry! No Container Found.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

