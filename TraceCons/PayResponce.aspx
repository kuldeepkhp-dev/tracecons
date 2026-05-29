<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayResponce.aspx.cs" Inherits="PayResponce" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
 <table id="tblDisplay" runat="server" width="100%">
       <tr>
           <td  class="PageMessageheader">
           Payment Status
            </td>
           
       </tr>
       
       <tr>
           <td align="center">
          
            <table>
                    <tr>
                   <td class="text" align="left" colspan="2"> &nbsp;</td>
               </tr>
                   <tr id="Tr2" runat="server">
                   
                   <td class="text" align="left" colspan="2"> 
                       <asp:Label ID="lblMsg" Font-Bold="true" ForeColor="Red" CssClass="txtlabel""   runat="server" Text=""></asp:Label> 
                            

                   </td>
               </tr>

                    <tr id="TrId" runat="server">
                   <td class="text" align="left"> Payment Transaction ID</td>
                   <td class="text" align="left"> 
                       <asp:Label ID="lblTransactionID" CssClass="txtlabel"  runat="server" Text=""></asp:Label> </td>
               </tr>

                 <tr id="Tr4" runat="server">
                   <td class="text" align="left"> Payment Ref No.</td>
                   <td class="text" align="left"> 
                       <asp:Label ID="lblOrderNo" CssClass="txtlabel"  runat="server" Text=""></asp:Label> </td>
                   </tr>

                     <tr id="Tr1" runat="server">
                   <td class="text" align="left"> Status</td>
                   <td class="text" align="left"> 
                       <asp:Label ID="lblStatus" CssClass="txtlabel"  runat="server" Text=""></asp:Label> </td>
               </tr>
             <%--  <tr>
                   <td class="text" align="left">IECODE </td>
                   <td class="text" align="left"> 
                        <asp:Label ID="lblApplNo" CssClass="txtlabel" runat="server" Text=""></asp:Label> </td>
               </tr>--%>
               <tr>
                   <td class="text" align="left">Payment Date (DD/MM/YYYY) </td>
                   <td class="text" align="left"> 
                        <asp:Label ID="lblappDate" CssClass="txtlabel" runat="server" Text=""></asp:Label> </td>
               </tr>
 <%-- 
			    <tr>
                   <td class="MessageRed" align="center" colspan="2">
                   
                       Kindly submit you document(s) at APEDA Office to which you have applied for 
                       registration.</td>
               </tr>

                <tr>
                   <td class="text" align="center" colspan="2">
                   
                <asp:LinkButton ID="lnkPrintApp" runat="server" onclick="lnkPrintApp_Click">Download/Print Application</asp:LinkButton>
                   
                   &nbsp;</td>
               </tr>
--%>
            
            </table>
          
          
            </td>
           
       </tr>
       
       
       
       
   </table>
</asp:Content>

