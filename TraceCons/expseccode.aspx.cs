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

public partial class expseccode : System.Web.UI.Page
{

    BLL_SecurityCheck objbll = new BLL_SecurityCheck();

    protected void Page_Load(object sender, EventArgs e)
    {
        hpSecurity.Attributes.Add("href", "javascript:OpenWindowBigS('securityCodeMsg.aspx','MsggN')");
        LinkButton1.Attributes.Add("href", "javascript:OpenWindowBigS('securityCodeMsg.aspx','MsggU')");
        if (!IsPostBack)
        {
            checkCode();
        }
    }


    public void checkCode()
    {
        objbll.UserID = Session["UserID"].ToString();
        objbll.RcmcNo = Session["RCMCNo"].ToString();
        DataTable dt = objbll.GetSecurityCodeOnLoad();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0].IsNull("SecCode") == true || dt.Rows[0]["SecCode"].ToString() == "")
            {
                txtSecurity.Enabled = false;
                btnProceed.Enabled = false;
                hpSecurity.Visible = true;
                Label1.Visible = false;
                LinkButton1.Visible = false;
            }
            else
            {
                txtSecurity.Enabled = true;
                btnProceed.Enabled = true;
                hpSecurity.Visible = false;
                Label1.Visible = true;
                LinkButton1.Visible = true;
            }
        }
    }
   
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        objbll.SecurityCode = txtSecurity.Text.Replace("'", "").Replace("%27", "");
        objbll.UserID = Session["UserID"].ToString();
        objbll.RcmcNo = Session["RCMCNo"].ToString();
        DataTable dt = objbll.CheckSecurityCode();
        if (dt.Rows.Count > 0)
        {
            Session["SecCode"] = dt.Rows[0]["SecCode"].ToString();
            Response.Redirect("HomeImp.aspx");
        }
        else
        {
            lblmessage.Text = "Invalid Security Code!!!";
        }
    }
    protected void btnSec_Click(object sender, EventArgs e)
    {
        
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
        if (dt.Rows[0].IsNull("Email") == false)
        {
            string email = dt.Rows[0]["Email"].ToString();
            MailMessage mail = new MailMessage();
            mail.BodyFormat = MailFormat.Html;
            mail.From = "grapenet@apeda.com";
            mail.To = "imtiyaz.007@gmail.com;" + email;
            mail.Subject = "Security code";
            string body = "";
            body = body + " Dear sir<br></t>Your security code is :<b>" + code + "</b>";
            mail.Body = body;
            mail.Priority = MailPriority.High;
            SmtpMail.SmtpServer = "";    //hostname smtpserver
            SmtpMail.Send(mail);
            lblmessage.Text = "Security Code has been sent at your email id:" + email;

        }
        else
        {
            lblmessage.Text = "Please Update Your Email Address.";
        }
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
    protected void hpSecurity_Click(object sender, EventArgs e)
    {
        //Update_SecurityCode();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Update_SecurityCode();
    }
}
