using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;

public partial class securityCodeMsg : System.Web.UI.Page
{

    BLL_SecurityCheck objbll = new BLL_SecurityCheck();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Update_SecurityCode();
        }
    }

    void Update_SecurityCode()
    {
        string code = RandomString();
        objbll.SecurityCode = code;
        objbll.UserID = Session["UserID"].ToString();
        objbll.RcmcNo = Session["RCMCNo"].ToString();
        int i = objbll.UpdateSecurityCode();
        if (i > 0)
        {
            Send_Code(code);
        }
    }

    void Send_Code(string code)
    {
        DataTable dt = objbll.GetEmailID();
        string email = "";
        if (dt.Rows[0].IsNull("Email") == false)
        {
            email = dt.Rows[0]["Email"].ToString();
        }
        MailMessage mail = new MailMessage();
        mail.BodyFormat = MailFormat.Html;
        mail.From = "grapenet@apeda.com";
        mail.To = "imtiyaz.007@gmail.com;" + email;
        mail.Subject = "Security Code for GrapeNet System";
        string body = "";
        body = body + " Dear sir<br></t>Your security code for GrapeNet system is :<b>" + code + "</b>";
        mail.Body = body;
        mail.Priority = MailPriority.High;
        SmtpMail.SmtpServer = "";    //hostname smtpserver
        SmtpMail.Send(mail);
        //lblmessage.Text = "Security Code has been sent at your email id:" + email;

    }



    private string RandomString()
    {
        int i, r;
        Random ran = new Random();
        string randomString, values = "";
        for (i = 0; i < 4; i++)
        {

            r = Convert.ToInt32((ran.Next(62)));
            if (r < 10)
                r = r + 48;
            else if (r < 36)
                r = (r - 10) + 65;
            else
                r = (r - 10 - 26) + 97;
            char c = (char)(r);
            values = values + c;
        }
        randomString = values;
        return randomString;
    }
}
