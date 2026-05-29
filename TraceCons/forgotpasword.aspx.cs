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

public partial class forgotpasword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("defaulr.aspx");
    }


    void sendMail()
    {
        BLL_Default objdef = new BLL_Default();
        objdef.Userid = txtUserID.Text.Replace("'", "");
        DataTable dt = objdef.GetUserPassword();
        if (dt.Rows.Count > 0)
        {
            string email = dt.Rows[0]["ImporterEmail"].ToString(); ;
            string userid = txtUserID.Text.Replace("'", "");
            if (email != null && email.Length > 0)
            {
                MailMessage mail = new MailMessage();
                mail.BodyFormat = MailFormat.Html;
                mail.To = email;
                mail.From = "grapenet@apeda.com";
                mail.Subject = " Your password for grapenet system ";
                string body = "";
                body = body + " Dear " + dt.Rows[0]["ImporterFirstName"].ToString() + "  <br></t>";
                body = body + " Your login details are as follows : <br><br>";

                body = body + " Username            : " + dt.Rows[0]["ImporterLoginID"].ToString() + "<br>";
                body = body + " Password            : " + dt.Rows[0]["InfoYourpd"].ToString() + "<br><br><br>";

                //body = body + " Thanks again for registering. If you have any questions or comments, feel free to contact us. <br><br>";
                //body = body + " Sincerely,<br>";
                //body = body + " APEDA Team <br><br>";
                body = body + " EMail: agmci@apeda.com<br>";
                body = body + " Web: http://www.apeda.com/grapenet";

                mail.Body = body;
                mail.Priority = MailPriority.High;
                SmtpMail.SmtpServer = "";    //hostname smtpserver
                SmtpMail.Send(mail);
                lblMsg.Text = "Your Login Details Has Been Send To : " + email;
            }
        }
        else
            lblMsg.Text = "Please enter valid user ID !!!";
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        sendMail();
    }
}
