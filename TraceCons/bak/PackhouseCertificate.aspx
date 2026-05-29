<%@ page language="C#" autoeventwireup="true" inherits="PackhouseCertificate, App_Web_ixcqzp9m" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pack house certificate</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" width="100%">
  <tr>
    <td width="100%" colspan="3">
      <p align="center"><img border="0" src="images/logo.gif" width="381" height="65"></td>
  </tr>
  <tr>
    <td width="100%" colspan="3">
      <p align="center"><b>THE AGRICULTURAL AND PROCESSED FOOD PRODUCTS EXPORT
      DEVELOPMENT AUTHORITY<br>
      (Department of commerce ,Govt. of India)</b></p>
      <p align="center"><u><b>CERTIFICATE OF HORICULTURE PACKHOUSE RECOGNITION</b></u></td>
  </tr>
  <tr>
    <td width="100%" colspan="3">This is to certify that packhouse described
      below has been inspected by the Packhouse Recognition Committee
      constituted by APEDA and the existing facilities are considered adequate
      to meet the requirements of packhouse recognition for exports:</td>
  </tr>
  <tr>
    <td width="50%" colspan="2" valign="top">1. Name of exporter</td>
    <td width="50%">&nbsp;<asp:Label ID="lblExporter" runat="server"></asp:Label><br />
        &nbsp;<asp:Label ID="lblAdd" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">2. Certificate Number</td>
    <td width="50%">&nbsp;<asp:Label ID="lblCertificate" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">3. Certificate Valid upto&nbsp;</td>
    <td width="50%">&nbsp;<asp:Label ID="lblValid" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">4. Location of the Packhouse</td>
    <td width="50%">&nbsp;<asp:Label ID="lblLoaction" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">5. Horticulture Products exported</td>
    <td width="50%">&nbsp;<asp:Label ID="lblProducts" runat="server" Text="GRAPES"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">6. Precooling capacity</td>
    <td width="50%">&nbsp;<asp:Label ID="lblPreCoolCap" runat="server" Text="--"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" colspan="2">7. Cold store capacity</td>
    <td width="50%">&nbsp;<asp:Label ID="lblStoreCap" runat="server" Text="--"></asp:Label></td>
  </tr>
  <tr>
    <td width="100%" colspan="3">&nbsp;</td>
  </tr>
  <tr>
    <td width="25%">Place 
        <asp:Label ID="lblPlace" runat="server" Text="New Delhi"></asp:Label>&nbsp;<p>Date
            <asp:Label ID="lblDate" runat="server"></asp:Label>
    </td>
    <td width="25%">&nbsp;
      <p>&nbsp;</td>
    <td width="50%">
      <p align="center">For and on behalf of APEDA<br />
          <asp:Image ID="Image1" runat="server" ImageUrl="~/images/dirSign.jpg" /><br />
          DIRECTOR</p>
      </td>
  </tr>
  <tr>
    <td width="100%" colspan="3">&nbsp;</td>
  </tr>
  <tr>
    <td width="100%" colspan="3">
      <p align="center">3RD AND 4TH <span style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;text-transform:uppercase;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">floor, ncui building,
      3 siri institutional area,</span><br>
      AUGUST KRANTI MARG (OPP. ASIAD VILLAGE) NEW DELHI -110016<br>
      TELEFAX: 011-26514046<br>
          Email : gmffv@apeda.com</td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
