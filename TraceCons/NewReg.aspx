<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="NewReg.aspx.cs" Inherits="_NewReg" %>


<asp:Content ID="cnt1" runat="server" ContentPlaceHolderID="RegCPH">
<table width="100%" border="1" >
    <tr>
        <td colspan="2" valign="top" align="right">
            
           <a href="Default.aspx"> <img src="images/btnBack.gif" border="0" /></a></td>
    </tr>
    <tr>
        <td colspan="2" valign="top" class="row1">
            New Registration</td>
    </tr>
<tr>
<td valign="top"  class="row2">
    <table>
        <tr>
            <td valign="top" class="row1" style="width: 336px" >First Name<span style="color: #ff0000">*</span></td>
            <td valign="top" class="row2">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*"></asp:RequiredFieldValidator></td>
           </tr>
        <tr>
            <td valign="top" class="row1" style="width: 336px" >Last Name <span style="color: #ff0000">*</span></td>
            <td valign="top" class="row2"><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            
        </tr>
        <tr>
            <td valign="top" class="row1" style="width: 336px" >Address <span style="color: #ff0000">*</span>
            </td>
            <td valign="top" class="row2"><asp:TextBox ID="txtaddress" runat="server" Height="68px" TextMode="MultiLine" Width="257px"></asp:TextBox>*<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaddress"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            
        </tr>
        <tr>
            <td valign="top" class="row1" style="width: 336px" >City <span style="color: #ff0000">*</span></td>
            <td valign="top" class="row2"><asp:TextBox ID="txtcity" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcity"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            
        </tr>
        <%-- <tr>
            <td valign="top" class="row1">State/Territory 
            </td>
            <td valign="top" class="row2"><asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtState"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            
        </tr>--%>
         <tr>
            <td valign="top" class="row1" style="width: 336px">Country <span style="color: #ff0000">*</span>&nbsp;</td>
            <td valign="top" class="row2">
            
                <asp:DropDownList ID="drpcountryR" runat="server">
                </asp:DropDownList>
            </td>
            
        </tr>
         <%-- <tr>
            <td valign="top" class="row1">Zipcode
            </td>
            <td valign="top" class="row2"><asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtzipcode"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Enter valid zipcode" ControlToValidate="txtzipcode" Display="Dynamic" ValidationExpression="^\d{1,6}$"></asp:RegularExpressionValidator></td>
            
        </tr>--%>
        
    </table>

</td>
<td valign="top" class="row2">

<table>
        <tr>
            <td class="row1" style="width: 205px">E-mail <span style="color: #ff0000">*</span></td>
            <td style="width: 158px" class="row2">
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Enter valid email ID"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" Display="Dynamic"></asp:RegularExpressionValidator></td>
           </tr>
        <tr>
            <td class="row1" style="width: 205px">Company Name <span style="color: #ff0000">*</span></td>
            <td style="width: 158px" class="row2"><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCompany"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        <tr>
            <td class="row1" style="width: 205px">  Occupation <span style="color: #ff0000">*</span></td>
            <td style="width: 158px" class="row2"> <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOccupation"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        
        <tr>
            <td class="row1" style="width: 205px">  Designation</td>
            <td style="width: 158px" class="row2">  <asp:TextBox ID="txtDesign" runat="server"></asp:TextBox>&nbsp;
            </td>
            
        </tr>
        <tr>
            <td class="row1" style="height: 28px; width: 205px;">  Mobile No.</td>
            <td style="width: 158px; height: 28px;" class="row2">  <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>&nbsp;<br />
                <asp:RegularExpressionValidator
                ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter valid mobile no." ControlToValidate="txtMobile" Display="Dynamic" ValidationExpression="^\d{1,20}$"></asp:RegularExpressionValidator></td>
            
        </tr>
        
        <tr>
            <td class="row1" style="width: 205px">  Telephone</td>
            <td style="width: 158px" class="row2">  <asp:TextBox ID="txtTele" runat="server"></asp:TextBox>&nbsp;<br />
                <asp:RegularExpressionValidator
                ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Enter valid telephone no." ControlToValidate="txtTele" Display="Dynamic" ValidationExpression="^\d{1,20}$"></asp:RegularExpressionValidator>
            </td>
            
        </tr>
         <tr>
            <td class="row1" style="width: 205px">  Fax</td>
            <td style="width: 158px" class="row2">  <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter valid fax no." ControlToValidate="txtFax" Display="Dynamic" ValidationExpression="^\d{1,20}$"></asp:RegularExpressionValidator></td>
            
        </tr>
    <tr>
        <td class="row1" style="height: 41px; width: 205px;">
            Type the code shown below <span style="color: #ff0000">*</span></td>
        <td class="row2" style="width: 158px; height: 41px;">
            <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
            <asp:Label ID="Errmsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr class="row2" >
        <td style="width: 205px" >
        </td>
        <td style="width: 158px">
            <img id="chapthca" runat="server" src="JpegImage.aspx" /></td>
    </tr>
        
    </table>




</td>
</tr>
    <tr>
        <td colspan="2" valign="top" align="center" class="row2">
            <br /><hr class="row1" />
            <table>
                <tr>
                    <td class="row1">
                        &nbsp;LoginID
                    </td>
                    <td class="row2">
                        <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLoginID"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" class="row2">
                    Begin with a letter, and use only letters (a-z), numbers (0-9), the underscore( _ ).
                    </td>
                </tr>
                <tr>
                    <td class="row1">Password  </td>
                    <td class="row2">
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPwd"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    <td class="row1">
                        Confirm Password
                    </td>
                    <td class="row2">
                        <asp:TextBox ID="txtRePwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRePwd"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="row2" colspan="4" style="text-align: center">
                        <input id="txthidden" type="hidden" runat="server" value="Not Available" />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: center" class="row2" colspan="4">
                        &nbsp;<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 342px">
        </td>
        <td valign="top">
        </td>
    </tr>
</table>
    <input name="challenge" type="hidden" value="$$CHALLENGE" />

</asp:Content>
