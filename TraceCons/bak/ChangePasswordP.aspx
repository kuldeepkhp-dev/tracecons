<%@ page language="C#" autoeventwireup="true" inherits="ChangePasswordP, App_Web_ixcqzp9m" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Change Password</title>
    <link href="SSheets/MasterStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="JS/encmd5.js"></script>
   <%-- <script language="javascript" src="JS/JScript.js"></script>--%>
    <script language="javascript" type="text/javascript">
    
    function convertToMD5()
    {
//       document.forms[0].txtOldPassword.value=hex_hmac_md5(document.forms[0].txtOldPassword.value, document.forms[0].challenge.value)
//       document.forms[0].txtNewPassword.value=hex_hmac_md5(document.forms[0].txtNewPassword.value, document.forms[0].challenge.value)
//       document.forms[0].txtConfirmPassword.value=hex_hmac_md5(document.forms[0].txtConfirmPassword.value, document.forms[0].challenge.value)

   
        var strNewPass=document.getElementById("txtNewPassword").value;
         var strCPass=document.getElementById("txtConfirmPassword").value;
      
        if(document.forms[0].txtOldPassword.value!="" && document.forms[0].txtNewPassword.value!=="" && document.forms[0].txtConfirmPassword.value!="")
        {
        
            if(strNewPass.length < 6 || strNewPass.length > 20)
            {
                alert("Password Length should be 6 to 20 character !");
                return false;
            }
            else 
            {
            if(document.forms[0].txtNewPassword.value.match(/[!,@,#,$,%,^,*,?,_,~,-]/g))
               {
               
                    document.forms[0].txtOldPassword.value=hex_hmac_md5(document.forms[0].txtOldPassword.value,document.forms[0].challenge.value);   
                    document.forms[0].txtNewPassword.value=hex_hmac_md5(document.forms[0].txtNewPassword.value,document.forms[0].challenge.value);   
                    document.forms[0].txtConfirmPassword.value=hex_hmac_md5(document.forms[0].txtConfirmPassword.value,document.forms[0].challenge.value);   
                    
                      if(document.forms[0].txtNewPassword.value==document.forms[0].txtConfirmPassword.value)
                      {
                        return true;
                      }
                      else
                      
                      {
                            alert("New Password and Conform Password should be same")
                            document.forms[0].txtOldPassword.value="";
                            document.forms[0].txtNewPassword.value="";
                            document.forms[0].txtConfirmPassword.value="";
                            document.forms[0].txtOldPassword.focus();
                            return false;
                      }
                 }
                else
                {
                    alert("Please enter at least one special character like (!,@,#,$,%,^,*,?,_,~,-) ");
                    return false;
                }
            }
        }
        else
        {
         alert("All Password entries are mandatory")
         
          return false;
        }




    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <input type="hidden" name="challenge" value="$$CHALLENGE"/>
    <div>
        <table width="100%">
            <tr>
                <td class="row1">
                    User Name
                </td>
                <td class="row2">
                    <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
            </tr>
    <tr>
            <td class="row1">
                    Old Password</td>
                <td class="row2">
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="row1">
                    New Password</td>
                <td class="row2">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="row1">
                    Confirm password</td>
                <td class="row2">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" class="row1" colspan="2">
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                
                <td class="row1" colspan="2" align="center">
                    &nbsp;<asp:Button ID="BtnChangePassword" runat="server" Text="Change password" OnClick="BtnChangePassword_Click" />
                    </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>