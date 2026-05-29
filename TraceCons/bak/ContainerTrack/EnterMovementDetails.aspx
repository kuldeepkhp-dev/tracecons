<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ContainerTrack_EnterMovementDetails, App_Web_mhmux3x6" title="EnterMovementDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
<table width="100%">
<tr>
<td align="right"  class="row1"> <a href="InputForm.aspx"> << Go Back </a></td>
</tr>
</table>
    <table width="100%">
        <tr>
            <td class="header" >
            Consignment Details
            </td>
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
                               
                    
                </Columns>
                <RowStyle CssClass="row2" />
                <HeaderStyle CssClass="row1" />
                </asp:GridView>
    
            </td>
           
       </tr>
       
       <tr>
            <td align="center">
                        <table>
                                <tr>
                                    <td colspan="2" class="row1">
                                     Enter Container Location
                                    </td>
                                   </tr>
                                <tr>
                                    <td class="row1"> Enter Port Name
                                    </td>
                                    <td class="row2">
                                        <asp:TextBox ID="txtPortName" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                                <tr>
                                    <td class="row1"> Check in Date
                                    </td>
                                    <td  class="row2"><asp:TextBox ID="txtCheckInDate" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="row1"> Check out Date
                                    </td>
                                    <td  class="row2"><asp:TextBox ID="txtCheckOutDate" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" class="row2">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Add Details" OnClick="btnSubmit_Click" />
                                    </td>
                                   </tr>
                            </table>
    
            </td>
           
       </tr>
        <tr>
            <td align="left" class="header" style="height: 19px">
                Container Details
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView2" runat="server">
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
    
    



</asp:Content>

