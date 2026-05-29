<%@ page language="C#" masterpagefile="~/MenuMasterPage.master" autoeventwireup="true" inherits="CountryWiseIssued, App_Web_dlg9uj0z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">


<table width="100%">
<tr>
<td colspan="2" class="row1" align="center"> Country wise Containers Shipped (Season <% Response.Write(System.DateTime.Today.Year.ToString()); %>)</td>
</tr>
<tr>
<td align="center"> 


    <asp:GridView ID="GV_PSCIssued" runat="server" AutoGenerateColumns="False" CssClass="row2"  ShowFooter="True" OnRowDataBound="GV_PSCIssued_RowDataBound">
        <Columns>
        <asp:BoundField DataField="Country_to_export" HeaderText="Destination Country">
        <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        
            <asp:BoundField DataField="TotalConsignment" HeaderText="Number of Constainers" Visible="False" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Number of containers">
            <ItemTemplate>
                <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TotalConsignment" ) %>'></asp:Label>
            <a onclick="javascript:OpenWindowBigS('ShiippDetail.aspx?c=<%# DataBinder.Eval(Container.DataItem, "Country_to_export" ) %>','detail')" href="javascript:void(0);"><%# DataBinder.Eval(Container.DataItem, "TotalConsignment" ) %></a>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            
            <asp:BoundField DataField="QtyInMT" HeaderText="Quantity (in MT)" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
           
        </Columns>
        <HeaderStyle CssClass="row1" />
        <FooterStyle CssClass="row1" HorizontalAlign="Right" />
    </asp:GridView>

</td>

</tr>
    <tr>
        <td align="left" style="height: 15px">
            <strong>Note : The above report is based on Phytosanitary Certificates issued.<br />
                <asp:Label ID="lblDisccl" runat="server" Text="Disclaimer : The schedule given above is indicative in nature. APEDA will not take any responsiblity for any changes in arrival/departure schedule."></asp:Label></strong></td>
    </tr>



</table>
</asp:Content>

