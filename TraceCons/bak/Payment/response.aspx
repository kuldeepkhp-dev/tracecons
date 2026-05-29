<%@ page language="C#" autoeventwireup="true" inherits="response, App_Web_swv41vow" enableeventvalidation="false" enableviewstatemac="false" enableviewstate="false" %>

<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="autoSubmit();" cz-shortcut-listen="true">
    <form action="confirm.aspx" name="payment" method="post" runat="server">
        <%
            if (confirmData != null && confirmData.Count > 0)
            {
                foreach (KeyValuePair<string, string> p in confirmData)
                {
                    if (p.Key.ToString() != "secure_hash" && !p.Key.ToString().ToLower().StartsWith("__") && p.Key.ToString() != "secretkey" && p.Key.ToString() != "submitted")
                    {
        %>
        <input type="hidden" value="<% =p.Value.ToString() %>" name="<% =p.Key.ToString() %>" />
        <%
                }
            }
            }
        %>
        <input type="hidden" value="" id="SecureHash" name="SecureHash" runat="server" />
        <script type="text/javascript">
            function autoSubmit() {
                document.forms[0].submit();
            }
        </script>
    </form>
</body>
</html>

