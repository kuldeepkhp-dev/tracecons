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

public partial class PackhouseCertificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPackHouseDetails(Request.QueryString["packhouse"].ToString());
            //tblDisplay.Visible = false;
        }
    }

    void BindPackHouseDetails(string packHousecode)
    {
        BLL_PackHouses obj = new BLL_PackHouses();
        obj.PackHouseCode = packHousecode;
        DataTable dt = obj.BindPackHouseDetails();

        if (dt.Rows.Count > 0)
        {
            lblCertificate.Text = dt.Rows[0]["packHouseNo"].ToString();
            //lblgs.Text = dt.Rows[0]["GS_Registration"].ToString();
            lblExporter.Text = dt.Rows[0]["PackHouseName"].ToString();
            //lblemail.Text = dt.Rows[0]["Email"].ToString();
            lblAdd.Text = dt.Rows[0]["address"].ToString();
            lblLoaction.Text = dt.Rows[0]["address"].ToString();
            //lbltaluk.Text = dt.Rows[0]["taluk"].ToString();
            //lbldistt.Text = dt.Rows[0]["distt"].ToString();
            //lblpin.Text = dt.Rows[0]["pin"].ToString();
            //lblstate.Text = dt.Rows[0]["state"].ToString();
            //lblContactP.Text = dt.Rows[0]["Contact_person"].ToString();
            if (dt.Rows[0].IsNull("PreCoolingCapacity") == false)
                lblPreCoolCap.Text = dt.Rows[0]["PreCoolingCapacity"].ToString()+ " MT";
            else
                lblPreCoolCap.Text = "--";
        if (dt.Rows[0].IsNull("ColdStoreCapacity") == false)
            lblStoreCap.Text = dt.Rows[0]["ColdStoreCapacity"].ToString() + " MT";
        else
            lblStoreCap.Text = "--";
            //lblPhone.Text = dt.Rows[0]["phone"].ToString();
            //lblFAX.Text = dt.Rows[0]["Fax"].ToString();
            lblDate.Text = dt.Rows[0]["IssueDate"].ToString();
            lblValid.Text = dt.Rows[0]["ValidityDate"].ToString();
        }
    }

}
