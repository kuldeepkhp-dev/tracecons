<%@ Page Language="C#" MasterPageFile="~/MenuMasterPage.master" AutoEventWireup="true" CodeFile="NoofAgmarkIssued.aspx.cs" Inherits="NoofAgmarkIssued"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

<table width="100%">
<tr>
<td colspan="2" class="row1" align="center"> Number of containers likely to be
             shipped from India in 
             
             next one week*</td>
</tr>
<tr>
<td align="center"> 
    <asp:GridView ID="GV_AGIssued" runat="server" AutoGenerateColumns="False" CssClass="row2"
        ShowFooter="True" OnRowDataBound="GV_AGIssued_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CreatedOn" HeaderText="Date of Agmark Certificate">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Consignee_Country" HeaderText="Destination Country">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Cnt" HeaderText="Number of Containers" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
            <asp:BoundField DataField="QtyInMT" HeaderText="Quantity (in MT)">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="row1" />
        <FooterStyle CssClass="row1" HorizontalAlign="Right" />
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>&nbsp;

   

</td>

</tr>



</table>
    <strong>  *This information excludes containers covered by column B.<br /><br />
        <asp:Label ID="lblDisccl" runat="server" Text="Disclaimer : The schedule given above is indicative in nature. APEDA will not take any responsiblity for any changes in arrival/departure schedule."></asp:Label></strong>

</asp:Content>

