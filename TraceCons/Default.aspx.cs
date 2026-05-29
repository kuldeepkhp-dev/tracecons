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

public partial class _Default : System.Web.UI.Page
{
    string PostString = "YES";
    private Random random = new Random();
    URLRandomNumbers randomnumber = new URLRandomNumbers();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogin.Attributes.Add("onClick", "return convertTosha512GrapesImporter();");
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                Response.Redirect("HomeImp.aspx");

            {
                this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();// GenerateRandomCode();
                ViewState["countlogin"] = "0";
                ViewState["UserName"] = "";
                tblCatcha.Visible = true;
            }
        }
    }



    public class URLRandomNumbers
    {
        private Random random = new Random();
        public URLRandomNumbers()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string GenerateRandomCodes()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }


    }


    protected void btn_Refereshcaptch_Click(object sender, EventArgs e)
    {
        this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();// GenerateRandomCode();


        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Captcha()", true);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //if (int.Parse(wrongCount.Value) >= 3)
        //{
        //    if (txtCaptcha.Text.ToString() == this.Session["CaptchaImageText"].ToString())
        //    {
        //        PostString = "YES";
        //    }
        //    else
        //    {
        //        PostString = "NO";
        //    }
        //}
        //else
        //{
        //    PostString = "YES";
        //}

        if (txtCaptcha.Text.ToString() == this.Session["CaptchaImageText"].ToString())
        {
            PostString = "YES";
        }
        else
        {
            PostString = "NO";
        }


        if (PostString == "YES")
        {
            BLL_Default obj = new BLL_Default();
            obj.Userid = txtloginID.Text.Replace("'", "''");
            obj.pwd = txtPassword.Text.Replace("'", "''");
            //obj.pwd = apeda.Value.Replace("'", "''");

            DataSet ds = obj.BindLoginInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Session["ActiveFlag"] = ds.Tables[0].Rows[0]["ImporterActiveFlag"].ToString();
                Session["UserID"] = ds.Tables[0].Rows[0]["ImporterID"].ToString();
                Session["ProductID"] = "PRD001";
                Session["ImporterLoginID"] = ds.Tables[0].Rows[0]["ImporterLoginID"].ToString();
                Session["FinancialYear"] = DateTime.Today.Year.ToString();
                Session["Report1"] = ds.Tables[0].Rows[0]["Report1"].ToString();
                Session["Report2"] = ds.Tables[0].Rows[0]["Report2"].ToString();
                Session["Report3"] = ds.Tables[0].Rows[0]["Report3"].ToString();
                Session["Report4"] = ds.Tables[0].Rows[0]["Report4"].ToString();
                Session["Module"] = "IMP";

                Session["IMPNAME"] = ds.Tables[0].Rows[0]["ImporterFirstName"].ToString();
                Session["IMPADD"]= ds.Tables[0].Rows[0]["ImporterAddress"].ToString();
                Session["IMPCITY"]= ds.Tables[0].Rows[0]["ImporterCity"].ToString();
                Session["IMPEMAIL"] = ds.Tables[0].Rows[0]["ImporterEmail"].ToString();



                Response.Redirect("HomeImp.aspx");


            }
            else
            {
                if (ViewState["UserName"].ToString() == txtloginID.Text.ToString().Replace("'", "''"))
                {
                    ViewState["countlogin"] = int.Parse(ViewState["countlogin"].ToString()) + 1;
                }
                else
                {
                    ViewState["countlogin"] = "0";
                }

                ViewState["UserName"] = txtloginID.Text.ToString().Replace("'", "''");
                lblmessage.Text = "Login Failed !!!. Please try again.";
                txtCaptcha.Text = "";
    
                wrongCount.Value = ViewState["countlogin"].ToString();

                if (int.Parse(ViewState["countlogin"].ToString()) == 3)
                {
                    
                    tblCatcha.Visible = true;
                    this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();//GenerateRandomCode();

                    ViewState["countlogin"] = "0";
                }
            }
        }

        else
        {
            if (txtCaptcha.Text.ToString() == "")
            {
                this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();//GenerateRandomCode();
                lblmessage.Text = "Please enter captcha !";
                txtCaptcha.Text = "";
            }
            else
            {
                this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();//GenerateRandomCode();
                lblmessage.Text = "Characters you type and Characters in the picture  are not same";
                txtCaptcha.Text = "";
            }
        }
    }

    //private string GenerateRandomCode()
    //{
    //    string s = "";
    //    for (int i = 0; i < 6; i++)
    //        s = String.Concat(s, this.random.Next(10).ToString());
    //    return s;
    //}

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Exp")
            Response.Redirect("defaultexp.aspx");
    }
}
