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
using System.Text.RegularExpressions;
public partial class _Default : System.Web.UI.Page
{
    string PostString = "YES";
    private Random random = new Random();
    URLRandomNumbers randomnumber = new URLRandomNumbers();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogin.Attributes.Add("onClick", "return convertTosha512GrapesExporter();");
        if (!IsPostBack)
        {
            
            if (Session["UserID"] != null)
                Response.Redirect("HomeImp.aspx");
            this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();// GenerateRandomCode();

            {
                
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
        //if (txtRCMCNo.Text != "")
        //{
        //    Regex regex = new Regex("^[0-9]*$");

        //    if (regex.IsMatch(txtRCMCNo.Text))
        //    {
        //        if (int.Parse(wrongCount.Value) >= 3)
        //        {
        //            if (txtCaptcha.Text.ToString() == this.Session["CaptchaImageText"].ToString())
        //            {
        //                PostString = "YES";
        //            }
        //            else
        //            {
        //                PostString = "NO";
        //            }
        //        }
        //        else
        //        {
        //            PostString = "YES";
        //        }

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
            obj.RCMCNo = txtRCMCNo.Text.Replace("'", "''");
            DataSet ds = obj.BindLoginInfoExp();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["FinancialYear"] = DateTime.Today.Year.ToString();
                Session["ActiveFlag"] = "Y";
                Session["ProductID"] = "PRD001";
                Session["RCMCNo"] = ds.Tables[0].Rows[0]["RcmcNo"].ToString();
                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                Session["Exporter"] = ds.Tables[0].Rows[0]["Exp_Name"].ToString();
                Session["IECODE"] = ds.Tables[0].Rows[0]["iecode"].ToString();
                Session["Report1"] = ds.Tables[0].Rows[0]["Report1"].ToString();
                Session["Report2"] = ds.Tables[0].Rows[0]["Report2"].ToString();
                Session["Report3"] = ds.Tables[0].Rows[0]["Report3"].ToString();
                Session["Report4"] = ds.Tables[0].Rows[0]["Report4"].ToString();
                Session["ActiveFlag"] = ds.Tables[0].Rows[0]["ExporterActiveFlag"].ToString();

                Session["IMPNAME"] = ds.Tables[0].Rows[0]["Exp_Name"].ToString();
                Session["IMPADD"] = ds.Tables[0].Rows[0]["Exp_address"].ToString();
                Session["IMPCITY"] = " ";
                Session["IMPEMAIL"] = ds.Tables[0].Rows[0]["Email"].ToString();

                Session["Module"] = "EXP";
                if (Session["ActiveFlag"].ToString() == "Y")
                {
                    //Response.Redirect("expseccode.aspx"); //-- to validate with security code

                    Response.Redirect("HomeImp.aspx");
                }
                else
                {
                    Response.Redirect("HomeImp.aspx");
                }



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
                    this.Session["CaptchaImageText"] = randomnumber.GenerateRandomCodes();// GenerateRandomCode();

                    //ViewState["countlogin"] = "0";
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
        //            }
        //            else
        //                mymsg("Enter Valid RCMC Number!!!");
        //        }
        //    }
        //}

      
    }

    void mymsg(string showamessage)
    {
        string alertScript = "<script language=JavaScript>";
        alertScript = alertScript + "alert('" + showamessage + "')";
        alertScript = alertScript + "</script" + "> ";

        if (!IsClientScriptBlockRegistered("alert"))
        {
            this.RegisterClientScriptBlock("alert", alertScript);
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
        if (RadioButtonList1.SelectedValue == "Imp")
            Response.Redirect("default.aspx");
    }
}
