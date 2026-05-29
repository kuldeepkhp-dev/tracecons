<%@ Page Language="C#" MasterPageFile="~/MenuMasterPage.master" AutoEventWireup="true" CodeFile="yourcont.aspx.cs" Inherits="yourcont"%>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr class="row1">
    <td align="left" colspan="1" style="width: 162px">
        Your containers &gt;&gt;</td>
    <td align="center"  colspan="3">
        List of Containers of &nbsp;<asp:Label ID="lblExporter" runat="server"></asp:Label>&nbsp;
    (Season <% Response.Write(System.DateTime.Today.Year.ToString()); %>)</td>
</tr>
<tr>
    <td align="center" colspan="1" style="width: 162px">
    </td>
<td align="center" colspan="3"> 


    <asp:DataGrid id="DataGrid1" runat="server"  AutoGenerateColumns="False" CellPadding="4" BackColor="White"
        BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" CssClass="row2" OnItemDataBound="DataGrid1_ItemDataBound" ShowFooter="True">
                                <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                            <ItemStyle CssClass="row2"></ItemStyle>
                            <HeaderStyle cssclass="row1" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
                            <FooterStyle CssClass="row1"></FooterStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="country_to_export" HeaderText="Country">
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importer_Name" HeaderText="Importer">
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                        <FooterStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                     <asp:TemplateColumn HeaderText="Number of containers">
                                     <ItemTemplate>
                                         <asp:Label ID="lbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cnt" ) %>' Visible="false"></asp:Label>
                                     <a href="javascript:OpenWindowBigS('ExpConsDetail.aspx?icntry=<%# DataBinder.Eval(Container.DataItem, "country_to_export" ) %>&amp;imp=<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "Importer_Name")).Replace("&","~~") %>','title')""><%# DataBinder.Eval(Container.DataItem, "cnt" )  %></a>
                                     </ItemTemplate>
                                         <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                             Font-Underline="False" HorizontalAlign="Right" />
                                         <FooterStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                             Font-Underline="False" HorizontalAlign="Right" />
                                     </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="Qunatity(In MT)" DataField="QTY">
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Right" />
                                        <FooterStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                   
                                </Columns>
                            <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                            </asp:DataGrid>

</td>

</tr>
    



</table>

</asp:Content>

