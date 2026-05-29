<%@ page language="C#" autoeventwireup="true" inherits="comfirm, App_Web_swv41vow" maintainscrollpositiononpostback="false" enableeventvalidation="false" enableviewstatemac="false" enableviewstate="false" %>
<%--<%@ Import Namespace="System.Linq" %>--%>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.NET Integration Demo - Confirmation Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <style>
        h1
        {
            font-family: Arial,sans-serif;
            font-size: 24pt;
            color: #08185A;
            font-weight: 100;
            margin-bottom: 0.1em;
        }

        h2.co
        {
            font-family: Arial,sans-serif;
            font-size: 24pt;
            color: #FFFFFF;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }

        h3.co
        {
            font-family: Arial,sans-serif;
            font-size: 16pt;
            color: #000000;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }

        h3
        {
            font-family: Arial,sans-serif;
            font-size: 16pt;
            color: #08185A;
            margin-top: 0.1em;
            margin-bottom: 0.1em;
            font-weight: 100;
        }

        body
        {
            font-family: Verdana,Arial,sans-serif;
            font-size: 11px;
            color: #08185A;
        }

        th
        {
            font-size: 12px;
            background: #015289;
            color: #FFFFFF;
            font-weight: bold;
            height: 30px;
        }

        td
        {
            font-size: 12px;
            background: #DDE8F3;
        }

        .pageTitle
        {
            font-size: 24px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" bgcolor="#ECF1F7">
    <form id="form1" runat="server">
        <center>
            <%if (req != null && req.QueryString != null)
              { %>
        <table width="100%" cellpadding="0" cellspacing="0" ><tr><th width="90%">&nbsp;</th></tr></table>
	        <center><h3>.NET Integration Kit - Confirmation Page </H3></center>
	        <p align="center"><b>Payment Status : <%= Session["paymentStatus"] + "" %></b></p>
            <table width="600" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <th colspan="2">Transaction Response</th>
                </tr>
                <%
                  NameValueCollection nameValue = (req.QueryString.Count > 0) ? req.QueryString : req.Form;
                  //uses linq extension
                  //SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>(nameValue.AllKeys.ToDictionary(k => k, k => nameValue[k]));
                  //uses non linq function
                  SortedDictionary<string, string> sortedDict = Common.SortNameValueCollection(nameValue);
                  
                  foreach (KeyValuePair<string, string> p in sortedDict)
                  {
                      if (p.Key.ToString() != "secure_hash" && p.Key.ToString() != "paymentStatus" && !p.Key.ToString().ToLower().StartsWith("__") && p.Key.ToString() != "secretkey" && p.Key.ToString() != "submitted")
                      {
                     %>
                <tr>
                    <td class="fieldName" width="50%"><% =p.Key.ToString() %></td>
                    <td class="fieldName" align="left" width="50%"><% =p.Value.ToString() %></td>
                </tr>
                    <%
                      }
                  }
         %>
	        </table>
            <%} %>
        </center>
        <table width="100%" cellpadding='0' cellspacing="0">
            <tr>
                <th width="90%">&nbsp;</th>
            </tr>
        </table>
    </form>
</body>
</html>
