using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class PayResponce : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["TrId"].ToString() != "NA")
        {
            lblTransactionID.Text = Request.QueryString["TrId"].ToString();
            //lblApplNo.Text = Session["IECODE"].ToString();  //  .ToString();
            lblappDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            lblStatus.Text = Request.QueryString["respmsg"].ToString();
            lblOrderNo.Text = Session["Order_number"].ToString();
            lblMsg.Text = "Your online transaction completed successfully";
           
        }
        else
        {
            lblMsg.Text = "Your online transaction was not successfully.So please try again";
            lblStatus.Text = Request.QueryString["respmsg"].ToString();
            lblTransactionID.Text = "";
            lblOrderNo.Text = Session["Order_number"].ToString(); ;
            //lblApplNo.Text = Session["IECODE"].ToString();  //  .ToString();
            lblappDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
          
           
        }

    }
}
