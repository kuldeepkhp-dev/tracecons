<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MenuMasterPage.master"CodeFile="PaymentResponse.aspx.cs" Inherits="PaymentResponse" %>

<asp:Content ID="cnt" runat="server" ContentPlaceHolderID="RegCPH">
   <table id="tblDisplay" runat="server" width="100%">
       <tr>
           <td  class="rowPayment">
           Payment Processing Details
            </td>
           
       </tr>
       
       <tr>
           <td align="center">
          
            <table>
                    <tr>
                   <td class="text" align="left" colspan="2"> &nbsp;</td>
               </tr>
                    <tr>
                   <td class="text" align="left"> Payment Transaction ID</td>
                   <td class="text" align="left"> 
                       <asp:Label ID="lblTransactionID" CssClass="txtlabel"  runat="server" Text=""></asp:Label> </td>
               </tr>
              <%-- <tr>
                   <td class="text" align="left">RCMC Application  Number </td>
                   <td class="text" align="left"> 
                        <asp:Label ID="lblApplNo" CssClass="txtlabel" runat="server" Text=""></asp:Label> </td>
               </tr>
               <tr>
                   <td class="text" align="left">RCMC Application Date (DD/MM/YYYY) </td>
                   <td class="text" align="left"> 
                        <asp:Label ID="lblappDate" CssClass="txtlabel" runat="server" Text=""></asp:Label> </td>
               </tr>--%>
            
            </table>
          
          
            </td>
           
       </tr>
       
       
       
       
   </table>

    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>
