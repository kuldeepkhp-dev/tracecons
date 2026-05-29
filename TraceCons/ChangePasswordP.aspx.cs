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

public partial class ChangePasswordP : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        BtnChangePassword.Attributes.Add("onclick", "return convertToMD5();");

        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            lblUserName.Text = Session["ImporterLoginID"].ToString();
        }
    }



    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        string oldpassword = txtOldPassword.Text.ToString().Replace("'","''");
        string newpassword = txtNewPassword.Text.ToString().Replace("'", "''");
        string confirmpassword = txtConfirmPassword.Text.ToString().Replace("'", "''");

        if (txtNewPassword.Text.ToString().Replace("'", "''") == txtConfirmPassword.Text.ToString().Replace("'", "''"))
        {

            string pwd;
            BAL_changepassword objBAL_changepassword = new BAL_changepassword();
            objBAL_changepassword.USERID = Session["UserID"].ToString();
            DataSet ds = new DataSet();
            ds = objBAL_changepassword.PasswordChange();
            if (ds.Tables[0].Rows.Count > 0)
            {
                pwd = ds.Tables[0].Rows[0]["ImporterPassword"].ToString();
                if (pwd == txtOldPassword.Text)
                {
                    objBAL_changepassword.newpassword = txtNewPassword.Text.ToString();
                    int iflag;
                    iflag = objBAL_changepassword.updatepassword();
                    if (iflag > 0)
                    {
                        lblmsg.Text = "password changed";
                    }
                }
                else
                {
                    lblmsg.Text = " Wrong Password! Try again";
                    //-- error wrong password
                }
            }
        }
        else
        {
            lblmsg.Text = "New password and confirm password should be equal";
        }


    }
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Response.Close();
    }



}
