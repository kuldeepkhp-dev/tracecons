<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCons.aspx.cs" Inherits="ViewCons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="row1">
            <td align="left"  valign="middle">
                <strong><span style="font-size: 10pt">View&nbsp;Consignment Details</span></strong></td>
            <td align="right"   valign="middle">
                <a href="javascript:self.close()">
                    <img border="0" src="images/btnClose.jpg" /></a></td>
        </tr>
        
         <tr>
            <td align="center"  colspan="2" style="height: 26px">
      </td>
        </tr>
           <tr>
      <td align="center"  colspan="2" style="height: 26px">
         Enter Consignment ID :  <asp:TextBox ID="txtConsignmentID" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
</td>
  </tr>
        </table>
        <table id="tblData" runat="server" width="100%">
        
        
        <tr>
            <td align="center" colspan="2" style="height: 26px">
                <asp:DataList ID="Datalist1" runat="server" BorderWidth="1px" CellPadding="0" CssClass="row2"
                    ForeColor="Black" OnItemDataBound="Datalist1_ItemDataBound" Width="100%">
                    <HeaderTemplate>
                        <table id="tblheader" border="1" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                            </tbody>
                                <tr>
                                     <td class="row1">
                                        <b>Container Number</b>
                                        
                                        </td>

                                    <td class="row1">
                                        <b>Phytosanitary Certificate Number</b></td>
                                    <td class="row1">
                                        <b>Agmark Certificate Number</b></td>
                                    <td class="row1">
                                        <b>CAG ID</b></td>
                                    <td class="row1">
                                        <b><font face="Arial" size="2"><b>Details </b></font></b>
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                                    <td class="row2" nowrap="nowrap">
                                        <asp:Label ID="lblCont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Container_No")%>'></asp:Label>
                               
                               
                            </td>
                            
                            <td class="row2" nowrap="nowrap">
                                <a href="javascript:void(0)" onclick="javascript:OpenWindowBig('PSC_Generate_Certificate.aspx?cagid=<%# DataBinder.Eval(Container.DataItem, "consignmentid" ) %>')">
                                    <%# DataBinder.Eval(Container.DataItem, "pscCertificate")%>
                                </a>
                                <asp:HyperLink ID="lblPSCCert" runat="server"></asp:HyperLink>
                            </td>
                            <td class="row2" nowrap="nowrap">
                                <a href="javascript:void(0)" onclick="javascript:OpenWindowBig('AGMARK_Generate_Certificate.aspx?cagid=<%# DataBinder.Eval(Container.DataItem, "consignmentid" ) %>')">
                                    <%# DataBinder.Eval(Container.DataItem, "certificate_no")%>
                                </a>
                                <asp:Label ID="lblCAG" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "consignmentid1" ) %>'
                                    Visible="false"></asp:Label>
                            </td>
                            <td class="row2" nowrap="nowrap">
                                <asp:Label ID="CAGID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Consignmentid" ) %>'>
                                </asp:Label>
                            </td>
                            <td class="row2">
                                <asp:DataList ID="dlView" runat="server" BorderWidth="1px" CellPadding="0" CssClass="row2"
                                    ForeColor="Black" OnItemDataBound="dlView_ItemDataBound" Width="100%">
                                    <HeaderTemplate>
                                        <table id="tblheader" border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tbody>
                                            </tbody>
                                               
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="row2">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="false" BackColor="White"
                                                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="row2"
                                                    OnItemDataBound="DataGrid1_OnItemDataBound" Width="100%">
                                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                                    <ItemStyle CssClass="row2" />
                                                    <HeaderStyle CssClass="row1" Font-Bold="True" HorizontalAlign="Center" />
                                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                                    <Columns>
                                                        <asp:HyperLinkColumn DataNavigateUrlField="AIMID" DataNavigateUrlFormatString="javascript:OpenWindowBig('AGMARK_Inspection_Report_AO.aspx?AIMID={0}')"
                                                            DataTextField="aimid" HeaderText="Agmark Inspection Report ID"></asp:HyperLinkColumn>
                                                        <asp:HyperLinkColumn DataNavigateUrlField="Lab_Code_no" DataNavigateUrlFormatString="javascript:OpenWindowBig('Generate_Test_Certificate.aspx?lcn={0}')"
                                                            DataTextField="Lab_Code_no" HeaderText="Residue Analysis Report"></asp:HyperLinkColumn>
                                                        <asp:HyperLinkColumn DataNavigateUrlField="FarmRegNo" DataNavigateUrlFormatString="javascript:OpenWindowBig('PlotDetails.aspx?frm={0}')"
                                                            DataTextField="FarmRegNo" HeaderText="Farm Registration Number"></asp:HyperLinkColumn>
                                                        <asp:TemplateColumn HeaderText="Total Quantity <br/>(in MTs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>'
                                                                    Visible="false"></asp:Label>
                                                                <a class="more" href="javascript:void(0);" onclick="flag=0" onmouseout="javascript:document.getElementById('Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>').style.visibility='hidden'"
                                                                    onmouseover="javascript:document.getElementById('Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>').style.visibility='visible'">
                                                                    <asp:Label ID="lblQTY" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "qty" )%>'></asp:Label>
                                                                </a>
                                                                <br />
                                                                <div id='Usefull<%# DataBinder.Eval(Container.DataItem, "LotID" ) %>' align="center"
                                                                    class="row2" style="visibility: hidden; border: 1px solid #669900; position:absolute;width: auto;left:70%">
                                                                    <asp:DataList ID="dlBox" runat="server" BorderWidth="0px" CellPadding="0" ForeColor="Black">
                                                                        <HeaderTemplate>
                                                                            <table id="tblheader" border="0" cellpadding="2" cellspacing="2">
                                                                            
                                                                                <tr class="col2">
                                                                                    <td nowrap="nowrap">
                                                                                        <b><b>No. of
                                                                                            <br />
                                                                                            Boxes </b></b>
                                                                                    </td>
                                                                                    <td nowrap="nowrap">
                                                                                        <b><b>Pack Size<br />
                                                                                            ( In Kgs.)</b> </b>
                                                                                    </td>
                                                                                    <td nowrap="nowrap">
                                                                                        <b><b>Total Qty.
                                                                                            <br />
                                                                                            (in Kgs.) </b></b>
                                                                                    </td>
                                                                                    <td nowrap><b><B>Class </B></b>
						                                            </td>
						                                            <td nowrap><b><B>Variety </B></b>
						                                            </td>
                                                                                </tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr class="col1">
                                                                                <td>
                                                                                    <asp:Label ID="lblNoofBox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Noofbox" ) %>'>
					                                            </asp:Label>
                                                                                </td>
                                                                                <td nowrap="nowrap">
                                                                                    <asp:Label ID="lblQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QtyinBox_kg" ) %>'>
					                                            </asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblTotalQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total_Qty" ) %>'>
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
                                                                    </asp:DataList>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:HyperLinkColumn DataNavigateUrlField="packhouseno" DataNavigateUrlFormatString="javascript:OpenWindowBig('packhouses.aspx?packhouse={0}')"
                                                            DataTextField="packhousename" HeaderText="Name of Authorised Packer"></asp:HyperLinkColumn>
                                                        <asp:HyperLinkColumn DataNavigateUrlField="IECODE" DataNavigateUrlFormatString="javascript:OpenWindowBigS('ExporterDetail.aspx?IECODE={0}','Exporter')"
                                                            DataTextField="Exp_Name" HeaderText="Exporter Name"></asp:HyperLinkColumn>
                                                    </Columns>
                                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:DataList>
                            </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td class="row1" colspan="3">
                                <b></b><b>
                                    <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                </b></FONT> </b>
                            </td>
                        </tr>
                        </table>
                    </FooterTemplate>
                </asp:DataList></td>
        </tr>

            </table>

                <table id="tbtNoData" runat="server" width="100%">
                    <tr>
                        <td align="center" class="row1">
                            Sorry! No Consignment Report(s) found.
                        </td>
                    </tr>
                </table>
           

</asp:Content>

