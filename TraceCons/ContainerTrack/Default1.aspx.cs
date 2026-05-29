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

public partial class ContainerTrack_Default1 : System.Web.UI.Page
{
    string PostString = "YES";
    private Random random = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
       // btnSignin.Attributes.Add("onClick", "return convertTomd5();");

        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
                Response.Redirect("HomeImp.aspx");

            {
                ViewState["countlogin"] = "0";
                ViewState["UserName"] = "";
                tblCatcha.Visible = false;
            }
        }
    }
    protected void btnSignin_Click(object sender, EventArgs e)
    {
        if (int.Parse(wrongCount.Value) >= 3)
        {
            if (txtCaptcha.Text.ToString() == this.Session["CaptchaImageText"].ToString())
            {
                PostString = "YES";
            }
            else
            {
                PostString = "NO";
            }
        }
        else
        {
            PostString = "YES";
        }


        if (PostString == "YES")
        {
            BLL_Operator obj = new BLL_Operator();
            obj.Userid = txtloginID.Text.Replace("'", "''");
            obj.pwd = txtPassword.Text.Replace("'", "''");
           // obj.pwd = apeda.Value.Replace("'", "''");

            DataSet ds = obj.BindLoginInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {

                //Session["ActiveFlag"] = ds.Tables[0].Rows[0]["ImporterActiveFlag"].ToString();
                Session["OPTID"] = ds.Tables[0].Rows[0]["OPTID"].ToString();
                Session["ProductID"] = "PRD001";
                //Session["ImporterLoginID"] = ds.Tables[0].Rows[0]["ImporterLoginID"].ToString();
                //Session["FinancialYear"] = DateTime.Today.Year.ToString();
                //Session["Report1"] = ds.Tables[0].Rows[0]["Report1"].ToString();
                //Session["Report2"] = ds.Tables[0].Rows[0]["Report2"].ToString();
                //Session["Report3"] = ds.Tables[0].Rows[0]["Report3"].ToString();
                //Session["Report4"] = ds.Tables[0].Rows[0]["Report4"].ToString();
                //Session["Module"] = "IMP";

                Response.Redirect("InputForm.aspx");


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
                    this.Session["CaptchaImageText"] = GenerateRandomCode();

                    ViewState["countlogin"] = "0";
                }
            }
        }

        else
        {
            this.Session["CaptchaImageText"] = GenerateRandomCode();
            lblPwd.Text = "Characters you type and Characters in the picture  are not same";
            txtCaptcha.Text = "";
        }
    }

    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }


}
