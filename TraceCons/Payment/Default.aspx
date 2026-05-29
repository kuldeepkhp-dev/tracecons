<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Integration Kit</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style>
    table {
	    font-family:Arial, Helvetica, sans-serif;
	    font-size:12px;
    }
    th 		 { font-size:12px;background:#015289;color:#FFFFFF;font-weight:bold;height:30px;}
    td 		 { font-size:12px;background:#DDE8F3}
    .error {color:#FF0000; font-weight:bold;}
    </style>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" bgcolor="#ECF1F7">
    <table width="900" cellpadding="2" cellspacing="2" border="0" align="center">
    <tr>
    <th colspan="2">
        <div id="tabs">
            <div id="tabs-1">
                    <form action="pay.aspx" name="payment" method="post" runat="server">
                    <ul>
                    <h3 style="font-size:25px;">
                        This is a sample .NET file to demonstrate the payment page integration
                    </h3>
                        </ul>

                    <h4 style="font-size:20px; text-align:left;">
                    Please ensure the following assets are available to view the demonstration
                    </h4>
                    <ol style="text-align:left;">
                    <li> IIS server need to be installed and service needs to be started.</li>
                    <li> Copy the hdfcpg in IIS root directory </li>
                    <li> Use this url in your browser http://localhost/hdfcpg/ to view the demo </li>
                    </ol>
                    <h4 style="font-size:20px; text-align:left;"> Page Details: </h4>
                    <ol style="text-align:left;">
                    <li>The next page will list the parameters that is passed from the merchant website to the payment gateway </li>
                    <li>Please ensure you fill in the Account ID and the Secret key you are provided and submit the page </li>
                    <li>The page that follows will print the parameters that are passed to the payment page along with the secure hash value printed as the last detail.</li>
                    <li>Please proceed to the payment page but submitting these details.</li>
                    </ol>
                    <input type="submit" value="SUBMIT" runat="server" />
                    </form>
            </div>
        </div>
    </th>
    </tr>
    </table>
</body>
</html>
