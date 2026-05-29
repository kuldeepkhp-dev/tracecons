<%@ page language="C#" masterpagefile="~/MenuMasterPage.master" autoeventwireup="true" inherits="NoofPSCIssued, App_Web_dlg9uj0z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

<table width="100%">
<tr>
<td colspan="2" class="row1" align="center"> Number of containers likely to be shipped from India in  next 2-3 days</td>
</tr>
<tr>
<td align="center"> 


    <asp:GridView ID="GV_PSCIssued" runat="server" AutoGenerateColumns="False" CssClass="row2"  ShowFooter="True" OnRowDataBound="GV_PSCIssued_RowDataBound">
        <Columns>
        <asp:BoundField DataField="DateofConsignment" HeaderText="Date of PSC" >
         <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        <asp:BoundField DataField="Country_to_export" HeaderText="Destination Country " >
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
            <asp:BoundField DataField="cnt" HeaderText="Number of containers">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
               
            <asp:BoundField DataField="QtyInMT" HeaderText="Quantity (in MT)" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
           
        </Columns>
        <HeaderStyle CssClass="row1" />
        <FooterStyle CssClass="row1" HorizontalAlign="Right" />
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
    <br />

</td>

</tr>



</table>
    <strong>  <asp:Label ID="lblDisccl" runat="server" Text="Disclaimer : The schedule given above is indicative in nature. APEDA will not take any responsiblity for any changes in arrival/departure schedule."></asp:Label></strong>
</asp:Content>

