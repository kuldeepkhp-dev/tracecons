<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostYes.aspx.cs" Inherits="Payment_PostYes"  MaintainScrollPositionOnPostback="false"
    EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false"%>

<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <title>Card Request</title>
</head>
<body onload="autoSubmit();" cz-shortcut-listen="true">
    <h3>Please wait, redirecting to process payment..</h3>
    <form name="payment" id="payment" method="post" runat="server">
        <%
            if (Request != null && Request.Form != null)
            {
                NameValueCollection nameValue = (Request.Form.Count > 0) ? Request.Form : Request.QueryString;
                //uses linq extension
                //SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>(nameValue.AllKeys.ToDictionary(k => k, k => nameValue[k]));
                //uses non linq function
                SortedDictionary<string, string> sortedDict = Common.SortNameValueCollection(nameValue);
                
                foreach (KeyValuePair<string, string> p in sortedDict)
                {
                    if (p.Key.ToString() != "secure_hash" && !p.Key.ToString().ToLower().StartsWith("__") && p.Key.ToString() != "secretkey" && p.Key.ToString() != "submitted")
                    {
        %>
        <input type="hidden" value="<% =p.Value.ToString() %>" name="<% =p.Key.ToString() %>" />
        <%
                    }
                }
        %>
        <input type="hidden" value="" id="secure_hash" name="secure_hash" runat="server" />
        <script type="text/javascript">
            function autoSubmit() {
                document.forms[0].submit();
            }
        </script>
        <%}
            else
            {%>
        <h1>Error!</h1>
        <p>Invalid response</p>
        <%} %>
    </form>
</body>
</html>

