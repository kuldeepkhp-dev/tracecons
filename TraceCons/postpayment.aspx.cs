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

public partial class postpayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BLLPostPayment objbll=new BLLPostPayment();
        if (!IsPostBack)
        {
            string str = Request.QueryString["q"];
            if (str == "4")
                lnkLogin.Visible = true;
            else
                lnkLogin.Visible = false;
            objbll.Module = Session["Module"].ToString();
            if (Session["Module"].ToString() == "IMP")
                objbll.UserID = Session["UserID"].ToString();
            else
                objbll.UserID = Session["RCMCNo"].ToString();
            DataTable dt = objbll.GetPayInfo();
            if (str == "1")
            {
                lblMsg.Text = "Payment Unsuccessful- Rejected by the switch";
                if (dt.Rows[0].IsNull("Reasoniffail") == false)
                    lblResponseMsg.Text = "Message : " + dt.Rows[0]["Reasoniffail"].ToString();
                if (dt.Rows[0].IsNull("TransactionID") == false)
                    lblTranID.Text = "Transaction ID : " + dt.Rows[0]["TransactionID"].ToString();

            }
            else if (str == "2")
            {
                lblMsg.Text = "Payment Unsuccessful- Rejected by the Payment Gateway";
                if (dt.Rows[0].IsNull("Reasoniffail") == false)
                    lblResponseMsg.Text = "Message : " + dt.Rows[0]["Reasoniffail"].ToString();
                if (dt.Rows[0].IsNull("TransactionID") == false)
                    lblTranID.Text = "Transaction ID : " + dt.Rows[0]["TransactionID"].ToString();
            }
            else if (str == "3")
            {
                lblMsg.Text = "Payment Unsuccessful";
                if (dt.Rows[0].IsNull("Reasoniffail") == false)
                    lblResponseMsg.Text = "Message : " + dt.Rows[0]["Reasoniffail"].ToString();
                if (dt.Rows[0].IsNull("TransactionID") == false)
                    lblTranID.Text = "Transaction ID : " + dt.Rows[0]["TransactionID"].ToString();
            }
            else if (str == "4")
            {
                lblMsg.Text = "Payment Successful";
                if (dt.Rows[0].IsNull("Reasoniffail") == false)
                    lblResponseMsg.Text = "Message : " + dt.Rows[0]["Reasoniffail"].ToString();
                if (dt.Rows[0].IsNull("TransactionID") == false)
                    lblTranID.Text = "Transaction ID : " + dt.Rows[0]["TransactionID"].ToString();
            }

        }
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logimpout.aspx");
    }
}
