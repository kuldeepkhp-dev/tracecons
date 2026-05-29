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

public partial class HomeImp : System.Web.UI.Page
{


    public string ConversionRate = ConfigurationManager.AppSettings["ConvRate"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //lbl150.Text = Convert.ToString(150 * Convert.ToDouble(ConversionRate));
            //lbl50.Text = Convert.ToString(50 * Convert.ToDouble(ConversionRate));
            //lbl75.Text = Convert.ToString(75 * Convert.ToDouble(ConversionRate));

            if (Request.QueryString["Msg"] != null)
            {
                if (Request.QueryString["Msg"].ToString() == "SUCCESS")
                {
                    Session["ActiveFlag"] = "Y";




                }

                else
                {
                    Session["ActiveFlag"] = "N";

                }
                 

            }
            else
            {
                Session["ActiveFlag"] = "N";

            }

            string test = Session["UserID"].ToString();

            if (Session["UserID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (Session["ActiveFlag"].ToString() == "N")
            {
                tblActive.Visible = false;
                tblnotActive.Visible = true;
                if (Session["Module"].ToString() == "EXP")
                {
                    BindAmountInfoEXP();
                }
                else if (Session["Module"].ToString() == "IMP")
                {
                    BindAmountInfoIMP();
                }
            }
            else
            {
                tblActive.Visible = true;
                tblnotActive.Visible = false;
                if (Session["RcmcNo"] != null)
                {

                    //if (Session["SecCode"] == null)
                    //{
                    //    Response.Redirect("expseccode.aspx");
                    //}

                    Session["SecCode"] = "NOTNULL";
                    //Response.Redirect("HomeImp.aspx");
                }
            }
        

            if (Request.QueryString["Msg"] != null)
            {
                if (Request.QueryString["Msg"].ToString() == "SUCCESS")
                {

                    string alertMessage = "Your online transaction completed successfully";

                    string script = "alert('" + alertMessage + "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);


                    

                }

                else
                {
                    //string alertMessage = "Your online transaction was not successfully.So please try again";

                    //string script = "alert('" + alertMessage + "');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);


                    string alertMessage = "Your online transaction was not successfully. So please try again.";
                    string redirectUrl = "HomeImp.aspx";  // Replace with your desired redirect URL

                    string script = "alert('" + alertMessage + "'); window.location.href = '" + redirectUrl + "';";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);



                }
            }
        }
    }



    public void BindAmountInfoEXP()
    {
        BLL_HomeImp obj = new BLL_HomeImp();
        obj.UserID = Session["RCMCNo"].ToString();


        DataTable dt = obj.BindInfoEXP();
        if (dt.Rows.Count > 0)
        {
            tblErrorMessage.Visible = false;
            tblPayMessageExp.Visible = true;
            tblPayMessageImp.Visible = false;
            //ViewState["TotalCost"] = dt.Rows[0]["TotalCost"].ToString();
        }
        else
        {
            tblErrorMessage.Visible = true;
            tblPayMessageExp.Visible = false;
            tblPayMessageImp.Visible = false;
        }
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

    public void BindAmountInfoIMP()
    {
        BLL_HomeImp obj = new BLL_HomeImp();
        obj.UserID = Session["UserID"].ToString();
        obj.ImporterLoginID = Session["ImporterLoginID"].ToString();

        DataTable dt = obj.BindInfoIMP();
        if (dt.Rows.Count > 0)
        {
            tblErrorMessage.Visible = false;
            tblPayMessageImp.Visible = true;
            tblPayMessageExp.Visible = false;

        }
        else
        {
            //Response.Redirect("Default.aspx");
            tblErrorMessage.Visible = true;
            tblPayMessageImp.Visible = false;
            tblPayMessageExp.Visible = false;
        }
    }






    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        chkRep1.Checked = false;
        chkRep2.Checked = false;
        chkRep3.Checked = false;
        chkRep4.Checked = false;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

    }

    void UpdateImpInfo()
    {

    }

    void UpdateExpInfo()
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BLL_HomeImp objbll = new BLL_HomeImp();
        objbll.UserID = Session["UserID"].ToString();
        objbll.Report2 = 'N';
        objbll.Report3 = 'N';
        objbll.Report4 = 'N';
        objbll.Report1 = 'N';
        double amount = 0.0;
        bool flag = false;
        if (rdbAll.Checked == true)
        {
            amount = Convert.ToDouble(10000.00);
            //  amount = Convert.ToDouble(1.00);
            objbll.Report2 = 'Y';
            objbll.Report3 = 'Y';
            objbll.Report4 = 'Y';
            objbll.Report1 = 'Y';
            flag = true;
        }
        else
        {
            if (chkRep1.Checked == true)
            {
                objbll.Report1 = 'Y';

                amount = amount + Convert.ToDouble(3500.00);
                flag = true;
            }
            if (chkRep2.Checked == true)
            {
                amount = amount + Convert.ToDouble(3500.00);
                objbll.Report2 = 'Y';
                flag = true;
            }
            if (chkRep3.Checked == true)
            {
                amount = amount + Convert.ToDouble(3500.00);
                objbll.Report3 = 'Y';
                flag = true;
            }
            if (chkRep4.Checked == true)
            {
                amount = amount + Convert.ToDouble(5000.00);
                objbll.Report4 = 'Y';
                flag = true;
            }
        }
        amt.Value = amount.ToString();
        if (flag)
        {
            objbll.InsertSubsIMP();
            //Response.Redirect("http://apeda.com/trace/SSLTest.asp?id=" + Session["UserID"].ToString() + "&BGAmount=" + amount.ToString() + "&mdl=" + Session["Module"].ToString());


            Session["IECODE"] = Session["UserID"];
            Session["APP_FORM_NO"] = Session["UserID"];
            Session["RCMCNo"] = Session["UserID"];
            Session["BGAmount"] = amount.ToString();

            Session["EXP_NAME"] = Session["IMPNAME"].ToString();
            Session["ADDRESS"] = Session["IMPADD"].ToString();
            Session["CITY"] = Session["IMPCITY"].ToString();
            Session["STATE"] = "FROM GRAPENET ";
            Session["PIN"] = "000000 ";
            Session["EMAIL"] = Session["IMPEMAIL"].ToString();
            Session["ContactNo"] = "111111111";
            Session["description"] = "Grapenet Subscription Payment";
            //Response.Redirect("forwardtopayment.aspx");



            //Response.Redirect("~/Payment/Pay.aspx");

            Response.Redirect("~/Payment/PayYes.aspx");

        }
        else
            mymsg("Please select atleast one report to proceed.");
    }

    void CalculatePayment()
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndi.Checked = true;
        rdbAll.Checked = false;
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndi.Checked = true;
        rdbAll.Checked = false;
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndi.Checked = true;
        rdbAll.Checked = false;
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndi.Checked = true;
        rdbAll.Checked = false;
    }
    protected void btnPayExp_Click(object sender, EventArgs e)
    {
        BLL_HomeImp objbll = new BLL_HomeImp();
        objbll.UserID = Session["RCMCNo"].ToString();
        objbll.Report2 = 'N';
        objbll.Report3 = 'N';
        objbll.Report4 = 'N';
        objbll.Report1 = 'N';
        bool flag = false;
        double amount = 0.0;
        if (rdbAllExp.Checked == true)
        {
            amount = 7000.00;
            objbll.Report2 = 'Y';
            objbll.Report3 = 'Y';
            objbll.Report4 = 'Y';
            objbll.Report1 = 'Y';
            flag = true;
        }
        else
        {
            if (chkRep1Exp.Checked == true)
            {
                amount = amount + 2500.00;
                objbll.Report1 = 'Y';
                flag = true;
            }
            if (chkRep2Exp.Checked == true)
            {
                objbll.Report2 = 'Y';
                amount = amount + 2500.00;
                flag = true;
            }
            if (chkRep3Exp.Checked == true)
            {
                amount = amount + 2500.00;
                objbll.Report3 = 'Y';
                flag = true;
            }
            if (chkRep4Exp.Checked == true)
            {
                amount = amount + 3500.00;
                objbll.Report4 = 'Y';
                flag = true;
            }
        }
        amt.Value = amount.ToString();
        if (flag)
        {
            objbll.InsertSubsEXP();
            //Response.Redirect("http://apeda.com/trace/SSLTest.asp?id=" + Session["RCMCNo"].ToString() + "&BGAmount=" + amount.ToString() + "&mdl=" + Session["Module"].ToString());


            Session["IECODE"] = Session["UserID"];
            Session["APP_FORM_NO"] = Session["RCMCNo"];
            Session["RCMCNo"] = Session["RCMCNo"].ToString();
            Session["BGAmount"] = amount.ToString();

            Session["EXP_NAME"] = Session["IMPNAME"].ToString();
            Session["ADDRESS"] = Session["IMPADD"].ToString(); ;
            Session["CITY"] = "IMP";
            Session["STATE"] = "IMPADD";
            Session["PIN"] = "000000";
            Session["EMAIL"] = Session["IMPEMAIL"].ToString();
            Session["description"] = "Grapenet Subscription Payment";
            Session["ContactNo"] = "111111111";
            // Response.Redirect("forwardtopayment.aspx");
            // Response.Redirect("~/Payment/Pay.aspx");
            Response.Redirect("~/Payment/PayYes.aspx");



        }
        else
            mymsg("Please select atleast one report to proceed.");
    }
    protected void rdbAllExp_CheckedChanged(object sender, EventArgs e)
    {
        chkRep1Exp.Checked = false;
        chkRep2Exp.Checked = false;
        chkRep3Exp.Checked = false;
        chkRep4Exp.Checked = false;
    }
    protected void rdbIndiExp_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void chkRep1Exp_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndiExp.Checked = true;
        rdbAllExp.Checked = false;
    }
    protected void chkRep2Exp_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndiExp.Checked = true;
        rdbAllExp.Checked = false;
    }
    protected void chkRep3Exp_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndiExp.Checked = true;
        rdbAllExp.Checked = false;
    }
    protected void chkRep4Exp_CheckedChanged(object sender, EventArgs e)
    {
        rdbIndiExp.Checked = true;
        rdbAllExp.Checked = false;
    }
}
