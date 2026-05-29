<%@ page language="C#" masterpagefile="~/MenuMasterPage.master" autoeventwireup="true" inherits="HomeImp, App_Web_dlg9uj0z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegCPH" Runat="Server">

    <table id="tblnotActive" runat="server">
        <tr>
        
        <td>
            <table id="tblPayMessageImp" runat="server">
                <tr>
                    <td class="rowPayment" > Dear User,<br />
                        <br />
                        Please select the option for subscription of reports for one season.<br />
                        <br />
                        <table>
                            <tr>
                                <td align="right" valign="top" >
                                    a)</td>
                                <td valign="top" >
                                    Report 1, Report 2 and Report 3 @ Rs.<asp:Label ID="lbl50" runat="server">3500</asp:Label>/-
                                    (This is approximately equivalent to Euros 50 based on current exchange rate;*)</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    b)</td>
                                <td valign="top">
                                    Report 4 @
                                    <%--(75 Euro)--%> Rs.
                                    <asp:Label ID="lbl75" runat="server">5000</asp:Label>/- (This is approximately equivalent
                                    to Euros 75 based on current exchange rate;*)</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" >
                                    c)</td>
                                <td valign="top" >
                                    All Reports <%--(150 Euro)--%> @ Rs.<asp:Label ID="lbl150" runat="server">10000</asp:Label>/- for the current season
                                    (This is approximately equivalent to Euros 150 based on current exchange rate;*)</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" valign="top">
                                    </td>
                            </tr>
                            <tr>
                                <td valign="top" >
                                </td>
                                <td valign="top" >
                                    &nbsp;&nbsp;
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
<BR /><asp:RadioButton id="rdbIndi" runat="server" Text="Individual Reports" GroupName="GRP" OnCheckedChanged="RadioButton2_CheckedChanged"></asp:RadioButton><BR />&nbsp; <asp:CheckBox id="chkRep1" runat="server" Text="Report 1 [Know your container(s)]" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep2" runat="server" Text="Report 2 [Containers to be shipped in 2-3 days]" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep3" runat="server" Text="Report 3 [Containers to be shipped in one week]" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep4" runat="server" Text="Report 4 [Summary report of all Grape Containers from INDIA]" OnCheckedChanged="CheckBox4_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR /><BR /><asp:RadioButton id="rdbAll" runat="server" Text="All Reports" Checked="True" GroupName="GRP" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" __designer:wfdid="w2"></asp:RadioButton> 
</ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                                    * You would need an international credit card to make payment for this service.
                                    The actual amount deducted in Euros shall be based on the prevailing exhange rate
                                    on your date of transaction.</td>
                 </tr>
                <tr>
                    <td align="right" class="rowPayment">
                      
                        <asp:Button ID="Button1" runat="server" Text=" Click to pay >> " OnClick="Button1_Click" /></td>
                </tr>
             </table>
             
              <table id="tblPayMessageExp" runat="server">
                <tr>
                    <td class="rowPayment" > Dear User,<br />
                        <br />
                        Please select the option for subscription of reports for one season.
                        <br />
                        <table>
                            <tr>
                                <td align="right" valign="top" >
                                    a)</td>
                                <td valign="top" >
                                    Report 1, Report 2 and Report 3 (Rs. 2500 each)</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    b)</td>
                                <td valign="top" >
                                    Report 4 (Rs. 3500)</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" >
                                    c)</td>
                                <td valign="top" >
                                    All Reports (Rs. 7000)</td>
                            </tr>
                            <tr>
                                <td valign="top" >
                                </td>
                                <td valign="top" >
                                    &nbsp;&nbsp;
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
<BR /><asp:RadioButton id="rdbIndiExp" runat="server" Text="Individual Reports" GroupName="GRP" OnCheckedChanged="rdbIndiExp_CheckedChanged"></asp:RadioButton><BR />&nbsp; <asp:CheckBox id="chkRep1Exp" runat="server" Text="Report 1 [Know your container(s)]" OnCheckedChanged="chkRep1Exp_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep2Exp" runat="server" Text="Report 2 [Containers to be shipped in 2-3 days]" OnCheckedChanged="chkRep2Exp_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep3Exp" runat="server" Text="Report 3 [Containers to be shipped in one week]" OnCheckedChanged="chkRep3Exp_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR />&nbsp; <asp:CheckBox id="chkRep4Exp" runat="server" Text="Report 4 [Summary report of all Grape Containers from INDIA]" OnCheckedChanged="chkRep4Exp_CheckedChanged" AutoPostBack="True"></asp:CheckBox> <BR /><BR /><asp:RadioButton id="rdbAllExp" runat="server" Text="All Reports (Report 1+ Report 2 + Report 3 + Report 4 =Rs.7000)" Checked="True" GroupName="GRP" OnCheckedChanged="rdbAllExp_CheckedChanged" AutoPostBack="True" __designer:wfdid="w3"></asp:RadioButton> 
</ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                     
                     </td>
                 </tr>
                <tr>
                    <td align="right" class="rowPayment">
                      
                        <asp:Button ID="btnPayExp" runat="server" Text=" Click to pay >> " OnClick="btnPayExp_Click" /></td>
                </tr>
             </table>
             
             
              <table id="tblErrorMessage" runat="server">
                <tr>
                    <td class="row2" style="height: 83px"> Dear User,<br />
                    Rates for this year are not available in software.
                     </td>
                 </tr>
             </table>
             
             </td>
        </tr>
        <tr>
            <td> 
            </td>
        </tr>
        
        
       
    </table>
    
    
    <table id="tblActive" runat="server">
        <tr>
            <td> 
            
            
            
            
            
            
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        
    </table>
    <input id="amt" runat="server" type="hidden" />
</asp:Content>

