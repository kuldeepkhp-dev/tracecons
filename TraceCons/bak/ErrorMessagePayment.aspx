<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ErrorMessagePayment, App_Web_qqg4g2bw" title="" %>

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

