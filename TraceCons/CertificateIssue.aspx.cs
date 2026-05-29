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
using System.Globalization;

public partial class CertificateIssue : System.Web.UI.Page
{
    public string farmregno;
    public string Financialyear;
    public string issudedate;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Certificate";
        if (Session["StateAgencyID"] == null && Session["userid"] == null)
        {
            Response.Redirect("default.aspx");
        }
        
        if (!IsPostBack)
        {
            farmregno = Request.QueryString["frm"].ToString().Replace("'", "");
            Financialyear = Request.QueryString["fny"].ToString().Replace("'", "");
            //issudedate = Request.QueryString["issuedate"].ToString().Replace("'", "");
            
            //-- Check For date
            //string stringA = issudedate;
            //DateTimeFormatInfo formatA = new DateTimeFormatInfo();
            //formatA.ShortDatePattern = "dd/MM/yyyy";

            //string stringB = DateTime.Today.ToString("dd/MM/yyyy");
            //DateTimeFormatInfo formatB = new DateTimeFormatInfo();
            //formatB.ShortDatePattern = "dd/MM/yyyy";

            //DateTime dateA = DateTime.Parse(stringA, formatA);
            //DateTime dateB = DateTime.Parse(stringB, formatB);
            ////frm -- fny 

            //if (dateA > dateB)
            //{
            //    Response.Redirect("Certificate.aspx?frm=" + farmregno + "&fny=" + Financialyear );
            //}


            BindData();
        }
    }

    public void BindData()
    {
        BLL_CertificateIssue obj = new BLL_CertificateIssue();
        //obj.agencyid = int.Parse(Session["StateAgencyID"].ToString());
        obj.farmregno = farmregno;
        obj.ProductID = Session["ProductID"].ToString();
        obj.Financialyear = Financialyear;
        DataSet ds = new DataSet();
        ds = obj.CertiData();

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblState.Text = ds.Tables[0].Rows[0]["state_Name"].ToString().ToUpper();
            lblFarmerName.Text = ds.Tables[0].Rows[0]["FarmerName"].ToString();
            lbldistrict1.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
            lblDistrict2.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
            lblyear.Text = Financialyear.ToString();
            if (Financialyear == "2005")
            {
                lblIssueDate.Text = " 19th Sep 2005";
            }
            else
            {
                lblIssueDate.Text = " 25th Oct, 2006";
            }

            //19th Sep 2005.
            //25th Oct, 2006.
           // lblIssueDate.Text = issudedate.ToString();
            if (ds.Tables[0].Rows[0]["VillageCode"].ToString() == "0")
            {
                lblVillage.Text = "";
            }
            else
            {
                lblVillage.Text = ds.Tables[0].Rows[0]["villagename"].ToString();
            }
            lblrapeGroverName.Text = ds.Tables[0].Rows[0]["FarmerName"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["FarmerAddress"].ToString();
            lblTaluk.Text = ds.Tables[0].Rows[0]["Talukmandalname"].ToString();
            lblDistrict.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
            lblSn.Text = "1";
            lblGat.Text = ds.Tables[0].Rows[0]["Survey_no"].ToString();

            lblPlotNo.Text = ds.Tables[0].Rows[0]["FarmRegNo"].ToString().Substring(ds.Tables[0].Rows[0]["FarmRegNo"].ToString().Length - 2, 2);

            lblVariety.Text = ds.Tables[0].Rows[0]["VarietyName"].ToString();
            lblArea.Text = ds.Tables[0].Rows[0]["Area_Per_Plot"].ToString();
            lblFarmNo.Text = ds.Tables[0].Rows[0]["FarmRegNo"].ToString();
            //lblValidDate.Text = "30/11/" + Convert.ToString(int.Parse(Financialyear) + 1);
            lblValidDate.Text = "30/11/" + Convert.ToString(int.Parse(ds.Tables[0].Rows[0]["dtofreg"].ToString().Substring(6))+1);
                        
            lblPlace.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
            lblDate.Text = ds.Tables[0].Rows[0]["dtofreg"].ToString();

            barcode.Src = "http://" + Request.ServerVariables["SERVER_NAME"] + "/scripts/idalin.ASP?HEIGHT=80&WIDTH=300&BARCODE=" + farmregno.ToString().ToUpper() + "&Code_Type=16&BAR_HEIGHT=1.2&LEFT_MARGIN=2";

             }
            else
            {

             }

           }


}
