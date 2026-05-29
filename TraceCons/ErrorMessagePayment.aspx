<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorMessagePayment.aspx.cs" Inherits="ErrorMessagePayment" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">
<table>
<tr>
<td> Response Code: <%= Request.QueryString["Code"].ToString()%> 
<br />
Response message: <%= Request.QueryString["message"].ToString()%> 
 
            </td>
</tr>
</table>
</asp:Content>

