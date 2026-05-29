using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net.NetworkInformation;


//using System.Linq;


/// <summary>
/// Summary description for SampleSqlInjectionScreeningModule
/// </summary>
/// Added By Upendra Dixit for Security.
namespace Sample
    {
    
public class SampleSqlInjectionScreeningModule:IHttpModule
{
    public static string[] blackList = {"0x4400450043004C00410052004500",";--","; ","/*","*/","@@",
                                               "nchar","varchar","nvarchar",
                                               "alter ","begin","cast","create ","cursor ","declare","delete ","drop","end","exec","execute",
                                               "fetch","insert ","kill","open ",
                                               "select", "sys","sysobjects","syscolumns",
                                               "table","update","sp_","xp_"};


	public SampleSqlInjectionScreeningModule()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Dispose()
    {
        //no-op
    }
    public void Init(HttpApplication app)
    {
        app.BeginRequest += new EventHandler(app_BeginRequest);
    }
    void app_BeginRequest(object sender, EventArgs e)
    {
        HttpRequest Request = (sender as HttpApplication).Context.Request;

        foreach (string key in Request.QueryString)
            CheckInput(Request.QueryString[key]);
        foreach (string key in Request.Form)
            CheckInput(Request.Form[key]);
        foreach (string key in Request.Cookies)
            CheckInput(Request.Cookies[key].Value);
    }
     private void CheckInput(string parameter)
            {
                for (int i = 0; i < blackList.Length; i++)
                {
                    if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        /*
                          HttpContext.Current.Response.Redirect("error.html");
                        */                                            
                        
                        MailMessage Mail = new MailMessage();
                        MailAddress ma = new MailAddress("grapenet@apeda.com", "APEDA");
                        Mail.From = ma;
                        Mail.To.Add("webcons@apeda.com");
                        Mail.Subject = "Sql injection attack on GrapeNet";
                        Mail.Body = blackList[i].ToString();

                        try
                        {
                            SmtpClient smtpMailObj = new SmtpClient();
                            //eg:localhost, 192.168.0.x, replace with your server name
                            smtpMailObj.Host = "localhost";
                            smtpMailObj.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                            smtpMailObj.UseDefaultCredentials = true;
                            smtpMailObj.Port = 25;
                            //smtpMailObj.PickupDirectoryLocation="C:/Inetpub/mailroot/Mailbox";
                            smtpMailObj.Send(Mail);
                            HttpContext.Current.Response.Redirect("error.html");
                           // Response.Write("Your Message has been sent successfully");
                        }
                        catch (Exception ex)
                        {
                            //lblStatus.Text = "Send Email Failed." + ex.Message;
                        }
                        
                    }
                }
            }

        }
    }

