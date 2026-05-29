<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="FA_ViewLotDetail, App_Web_qqg4g2bw" title="Lot Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

<table id="tblData" runat="server" cellspacing="0" cellpadding="0" width="100%" border="1">
				
				<tr class="row1">
					<td style="height: 6px" >
                        <strong><span style="font-size: 10pt">
                        List of Lot</span></strong></td>
					<td align="right" style="height: 6px"><img onclick="javascript:self.close()" alt="close" src="Images/btnClose.jpg" border="0"/>
					</td>
				</tr>
				<tr>
					<td class="header" align="center" colspan="2" style="height: 20px"><b>Detail of Lot(s) available for Packing </b></td>
				</tr>
				<tr>
					<td class="header" align="center" colspan="2">
                        &nbsp;<asp:DataGrid ID="GD" runat="server" AutoGenerateColumns="False" Width="100%" >
        <Columns>
            <asp:BoundColumn DataField="LotID" HeaderText="Lot ID" />
            <asp:BoundColumn DataField="qty" HeaderText="Qty." />

            <asp:TemplateColumn HeaderText="Farm Reg. No.">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="javascript:OpenWindowBig('PlotDetails.aspx?frm=<%# DataBinder.Eval(Container.DataItem, "farmregno" ) %>','frm')"><%# DataBinder.Eval(Container.DataItem, "farmregno")%></a>
                </ItemTemplate>
               
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Lab Test Report No.">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="javascript:OpenWindowBig('Generate_Test_Certificate.aspx?lcn=<%# DataBinder.Eval(Container.DataItem, "lab_code_no" ) %>','lcn')"><%# DataBinder.Eval(Container.DataItem, "lab_code_no")%></a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="result_desc" HeaderText="Result Description" />
        </Columns>
        <ItemStyle CssClass="row2" />
        <HeaderStyle CssClass="row1" />
                            <AlternatingItemStyle CssClass="row2" />
    </asp:DataGrid>
					</td>
				</tr>
				</table>
</asp:Content>

