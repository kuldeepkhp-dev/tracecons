<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ContainerTrack_InputForm, App_Web_mhmux3x6" title="Entry Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

<table width="100%">
<tr>
<td style="height: 19px" class="row1"> List of Container(s)</td>
</tr>
<tr>
<td align="center"> 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Certificate_No" HeaderText="PSC No." />
            <asp:BoundField DataField="Container_No" HeaderText="Container No." />
            <asp:BoundField DataField="Exp_name" HeaderText="Exporter Name" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="OriginPort" HeaderText="Port of Origin" />
            <asp:BoundField DataField="DestinationCountry" HeaderText="Destination Country" />
            <asp:BoundField DataField="destinationPort" HeaderText="Destination Port" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                 <a href='EnterMovementDetails.aspx?customid=<%# Eval("ConsignmentID") %>'>Enter Container Movement Details</a>   <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text=""></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
        <RowStyle CssClass="row2" />
        <HeaderStyle CssClass="row1" />
    </asp:GridView>
</td>
</tr>
<tr>
<td> </td>
</tr>
</table>


</asp:Content>

