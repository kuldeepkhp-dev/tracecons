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

public partial class PayAOther_PackHouses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            BindPackHouseDetails(Request.QueryString["packhouse"].ToString());
            //tblDisplay.Visible = false;
        }
        HyperLink1.Attributes.Add("href", "javascript:OpenWindowBig('PackhouseCertificate.aspx?packhouse=" + Request.QueryString["packhouse"].ToString() + "','PackCert')");
    }

   
   


    void BindPackHouseDetails(string packHousecode)
    {
        BLL_PackHouses obj = new BLL_PackHouses();
        obj.PackHouseCode = packHousecode;
        DataTable dt = obj.BindPackHouseDetails();

        if (dt.Rows.Count > 0)
        {
            lblpackhouse.Text = dt.Rows[0]["packHouseNo"].ToString();
            lblgs.Text = dt.Rows[0]["GS_Registration"].ToString();
            lblpacker.Text = dt.Rows[0]["PackHouseName"].ToString();
            lblemail.Text = dt.Rows[0]["Email"].ToString();
            lbladdress.Text = dt.Rows[0]["address"].ToString();
            lbltaluk.Text = dt.Rows[0]["taluk"].ToString();
            lbldistt.Text = dt.Rows[0]["distt"].ToString();
            lblpin.Text = dt.Rows[0]["pin"].ToString();
            lblstate.Text = dt.Rows[0]["state"].ToString();
            lblContactP.Text = dt.Rows[0]["Contact_person"].ToString();

            lblPhone.Text = dt.Rows[0]["phone"].ToString();
           // lblMobile.Text = "";
            lblFAX.Text = dt.Rows[0]["Fax"].ToString();
            lblDateofIssue.Text = dt.Rows[0]["IssueDate"].ToString();
            lblvalidityDate.Text = dt.Rows[0]["ValidityDate"].ToString();
            tblDisplay.Visible = true;

        }
        else
        {
            tblDisplay.Visible = false;
        }





    }






}
