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

public partial class ExporterDetails : System.Web.UI.Page
{
    public string IECODE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["IECODE"].Length > 0)
        {
            IECODE = Request.QueryString["IECODE"].ToString();
        }

        if (!IsPostBack)
        {
            BindExporterInfo(IECODE);
        }

    }



    public void BindExporterInfo(string IECODE)
    {
        BLL_ExporterDetail obj = new BLL_ExporterDetail();
        obj.IECODE = IECODE.ToString().Replace("'", "");
        DataSet ds = obj.BindExporter();

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Session["Module"] == "IMP")
            {
                lblIecode.Text = "Confidential";
                lblRcmcNo.Text = "Confidential";
            }
            else
            {
                lblIecode.Text = ds.Tables[0].Rows[0]["Iecode"].ToString();
                lblRcmcNo.Text = ds.Tables[0].Rows[0]["RcmcNo"].ToString();
            }
            lblExp_name.Text = ds.Tables[0].Rows[0]["Exp_name"].ToString();
            lblExp_address.Text = ds.Tables[0].Rows[0]["Exp_address"].ToString();
            lblStatename.Text = ds.Tables[0].Rows[0]["Statename"].ToString();
            lblPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
            lblTelePhone.Text = ds.Tables[0].Rows[0]["TelePhone"].ToString();
            lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        }
        else
        {
            lblIecode.Text = "";
            lblRcmcNo.Text = "";
            lblExp_name.Text = "";
            lblExp_address.Text = "";
            lblStatename.Text = "";
            lblPin.Text = "";
            lblTelePhone.Text = "";
            lblFax.Text = "";
            lblEmail.Text = "";
        }

    }









}
