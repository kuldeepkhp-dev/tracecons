using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Mail;

public partial class _NewReg : System.Web.UI.Page 
{
    private Random random = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("TraceCons.aspx");
        Button1.Attributes.Add("onClick", "return REGconvertToSHA512();");
        if (!IsPostBack)
        {
            BLL_Default obj = new BLL_Default();
            DataSet ds = obj.BindCountry();
            drpcountryR.DataSource = ds;
            drpcountryR.DataTextField = "Country_Name";
            drpcountryR.DataValueField = "Country_Code";
            drpcountryR.DataBind();
            Session["CaptchaImageText"] = GenerateRandomCode();
            
        }
    }

    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["CaptchaImageText"].ToString() == txtCaptcha.Text)
        {


            BLL_Default obj = new BLL_Default();

            obj.hiddenpwd = txthidden.Value.Replace("'","''");
            //obj.hiddenpwd = txtPwd.Text.ToString().Replace("'", "''");
            //obj.hiddenpwd = txtRePwd.Text.ToString().Replace("'", "''");
            //obj.hiddenpwd = txthidden.Text.Tostring.Replace("'", "''");
            obj.ImporterFirstName = txtFirstName.Text.ToString().Replace("'", "");
            Session["IMPNAME"] = txtFirstName.Text.ToString().Replace("'", "");
            obj.ImporterLastName = txtLastName.Text.ToString().Replace("'", "");

            obj.ImporterAddress = txtaddress.Text.ToString().Replace("'", "");
            Session["IMPADD"] = txtaddress.Text.ToString().Replace("'", "");

            obj.ImporterCity = txtcity.Text.ToString().Replace("'", "");
            Session["IMPCITY"] = txtcity.Text.ToString().Replace("'", "");
            //obj.ImporterState = txtState.Text.ToString().Replace("'", "");
            //obj.ImporterCountry = txtcountryR.Text.ToString().Replace("'", "");
            obj.ImporterCountry = drpcountryR.SelectedValue.ToString().Replace("'", "");
            //obj.ImporterZip = txtzipcode.Text.ToString().Replace("'", "");
            obj.ImporterEmail = txtemail.Text.ToString().Replace("'", "");
            Session["IMPEMAIL"] = txtemail.Text.ToString().Replace("'", "");
            obj.ImporterCompanyname = txtCompany.Text.ToString().Replace("'", "");
            obj.ImporterOccupation = txtOccupation.Text.ToString().Replace("'", "");
            obj.ImporterDesig = txtDesign.Text.ToString().Replace("'", "");
            obj.ImporterTelePhone = txtTele.Text.ToString().Replace("'", "");
            obj.ImporterMobile = txtMobile.Text.ToString().Replace("'", "");
            obj.ImporterTeleFax = txtFax.Text.ToString().Replace("'", "");
            obj.ImporterLoginID = txtLoginID.Text.ToString().Replace("'", "");
            obj.ImporterPassword = txtPwd.Text.ToString().Replace("'", "");
            obj.ImporterSubscriptionDate = null;
            
            obj.ImporterSubscriptionDate = "1/1/" + DateTime.Today.Year.ToString().Replace("'", "");
            obj.ImporterExpiryDate = "12/31/" + DateTime.Today.Year.ToString().Replace("'", "");
            
            obj.ImporterSubscriptionAmount = "0";
            obj.ImporterTransactionID = "0";
            obj.ImporterActiveFlag = "N";
            obj.CreatedBy = txtFirstName.Text.ToString().Replace("'", "");
            obj.Updated_on = null;



            string sErrMsg = " The form could not be submited because of the following errors:%0A%0A";
            bool iflag = false;

            if (txtFirstName.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - First Name is required.%0A";
            }
            if (txtLastName.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Last Name is required.%0A";
            }
            if (txtaddress.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Address is required.%0A";
            }
            if (txtcity.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - City is required.%0A";
            }
            //if (txtState.Text == "")
            //{
            //    iflag = true;
            //    sErrMsg = sErrMsg + " - State is required.%0A";
            //}
            //if (txtzipcode.Text == "")
            //{
            //    iflag = true;
            //    sErrMsg = sErrMsg + " - Zip Code is required.%0A";
            //}

            if (txtemail.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Email is required.%0A";
            }
            if (txtCompany.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Company is required.%0A";
            }
            if (txtOccupation.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Occupation is required.%0A";
            }
            if (txtLoginID.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - LoginID is required.%0A";
            }
            if (txtPwd.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Password is required.%0A";
            }
            if (txtRePwd.Text == "")
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Password is required.%0A";
            }
            if (txtPwd.Text != txtRePwd.Text)
            {
                iflag = true;
                sErrMsg = sErrMsg + " - Password and confirm password is same .%0A";
            }
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtemail.Text.Length > 0)
            {
                if (!regEx.IsMatch(txtemail.Text))
                {
                    iflag = true;
                    sErrMsg = sErrMsg + " - Enter valid email-ID.%0A";
                }
            }

            if (iflag)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("alert(unescape('" + sErrMsg.ToString() + "'))");
                Response.Write("</script>");
            }
            else
            {


                //sendMail();
                int i = obj.InsertImporterInfo();
                if (i == 1)
                {
                    BLL_Default objbll = new BLL_Default();
                    objbll.Userid = txtLoginID.Text.ToString().Replace("'", "");
                    objbll.pwd = txtPwd.Text.ToString().Replace("'", "");

                    DataSet ds = objbll.BindLoginInfo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["ActiveFlag"] = ds.Tables[0].Rows[0]["ImporterActiveFlag"].ToString();
                        Session["UserID"] = ds.Tables[0].Rows[0]["ImporterID"].ToString();
                        Session["ImporterLoginID"] = ds.Tables[0].Rows[0]["ImporterLoginID"].ToString();
                        Session["Module"] = "IMP";
                        Response.Redirect("HomeImp.aspx");


                    }
                    else
                    {
                        //lblmessage.Text = "Login failed. Try again";
                    }
                }
                else
                {
                    lblMsg.Text = "LoginID already exist !!! Please try with new LoginID.";
                }

            }
        }
        else
        {
            Session["CaptchaImageText"] = GenerateRandomCode();
            Errmsg.Text = "Characters you type and Characters in the picture  are not same";
        }

    }


    //void sendMail()
    //{
    //    string email = txtemail.Text;
    //    string userid = txtLoginID.Text;
    //    if (txtemail.Text.Length > 0)
    //    {
    //        //MailMessage mail = new MailMessage();
    //        //mail.BodyFormat = MailFormat.Html;
    //        //mail.From = "grapenet@apeda.com";
    //        //mail.To =  email;
    //        //mail.Subject = " Welcome to Reporting Service of Grapes Shipments";
    //        string body = "";
    //        body = body + " Dear " + txtFirstName.Text + "  <br></t>Welcome to the reporting service of Grapes Shipments. We are happy to have you as a member of this service.<br><br>";
    //        body = body + " To Login to this service, use the following : <br><br>";
    //        body = body + " URL                 : http://www.apeda.gov.in/apedawebsite/Grapenet/GrapeNet_new.htm <br>";
    //        body = body + " Username            : " + userid + "<br>";
    //        body = body + " Password            : " + txthidden.Value + "<br><br><br>";
            
    //        body = body + " Thanks again for registering. If you have any questions or comments, feel free to contact us. <br><br>";
    //        //body = body + " Sincerely,<br>";
    //        //body = body + " APEDA Team <br><br>";
    //        body = body + " EMail: agmci@apeda.com<br>";
    //        body = body + " Web: http://www.apeda.gov.in/apedawebsite/Grapenet/GrapeNet_new.htm";

    //        //mail.Body = body;
    //        //mail.Priority =  MailPriority.High;
    //        //SmtpMail.SmtpServer = "";    //hostname smtpserver
    //        //SmtpMail.Send(mail);


    //        Multiverse.Mail.SmtpClient sc = new Multiverse.Mail.SmtpClient();
    //        sc.Server = "mail.nic.in";
    //        sc.Port = "465";
    //        sc.type = "1";

    //        sc.UserName = "grapenet.apeda@nic.in";
    //        sc.Password = "Gr@penet2011";
    //        sc.To = email;
    //        sc.IsHtml = true;

    //        sc.Subject = " Welcome to Reporting Service of Grapes Shipments ";
    //        sc.FromDisplayName = "GrapeNet";

    //        sc.From = "grapenet.apeda@nic.in";

    //        sc.Body = body;


    //        sc.SendMail();
    //        Response.Write(sc.ErrorMessage);
    //    }
    //}
}