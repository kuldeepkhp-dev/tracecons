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

public partial class TraceCons : System.Web.UI.Page
{
    BLL_Search_PSC_Issuedexp objbll = new BLL_Search_PSC_Issuedexp();
    DataTable dtAimid, dtCagid, dtDetail;
    DataTable dtDet, dtCert;
    double total = 0;
    private Random random = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RcmcNo"] != null)
            if (Session["SecCode"] == null)
                Response.Redirect("expseccode.aspx");
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        tblData.Style.Add("display", "none");
        tbtNoData.Style.Add("display", "none");
        if(!IsPostBack)
            Session["CaptchaImageText"] = RandomString();
    }

    private string RandomString()
    {
        int i, r;
        Random ran = new Random();
        string randomString, values = "";
        for (i = 0; i < 6; i++)
        {

            r = Convert.ToInt32((ran.Next(62)));
            if (r < 10)
                r = r + 48;
            else if (r < 36)
                r = (r - 10) + 65;
            else
                r = (r - 10 - 26) + 97;
            char c = (char)(r);
            values = values + c;
        }
        randomString = values;
        return randomString;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (Session["CaptchaImageText"].ToString().ToLower() == txtCaptcha.Text.ToLower())
        {
            if (txtCAGID.Text.Length == 0 && txtPSCCertificate.Text.Length == 0)
            {
                Errmsg.Text = "Please enter Container Number and CAG ID";
            }
            else if(txtCAGID.Text.Length == 0)
            {
                Errmsg.Text = "Please enter CAG ID";
            }
            else if (txtPSCCertificate.Text.Length == 0)
            {
                Errmsg.Text = "Please enter Container Number";
            }
            else
            {
                objbll.ConsignmentID = txtPSCCertificate.Text.Replace("'", "''");
                objbll.CAGID = txtCAGID.Text.Replace("'", "");
                objbll.ProductID = Session["ProductID"].ToString();
                dtCagid = objbll.TracePscCertificate();

                if (dtCagid.Rows.Count > 0)
                {
                    tblInp.Style.Add("display", "none");
                    tblmessage.Style.Add("display", "none");
                    tblData.Style.Add("display", "");
                    tbtNoData.Style.Add("display", "none");
                    dlBot.DataSource = dtCagid;
                    dlBot.DataBind();
                    Datalist1.DataSource = dtCagid;
                    Datalist1.DataBind();
                    Datalist1.Visible = true;
                }
                else
                {
                    tblData.Style.Add("display", "none");
                    tbtNoData.Style.Add("display", "");
                }
                Errmsg.Text = "";
                txtCaptcha.Text = "";
                txtPSCCertificate.Text = "";
                txtCAGID.Text = "";
                Session["CaptchaImageText"] = RandomString();
            }
        }
        else
        {
            Session["CaptchaImageText"] = RandomString();
            Errmsg.Text = "Enter the letters as they are shown in the image above.";
        }
    }


    protected void DataGrid1_OnItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl = new Label();
            lbl = (Label)e.Item.FindControl("lblLot");
            objbll.LotID = lbl.Text.Trim();
            objbll.ProductID = Session["ProductID"].ToString();
            objbll.FinancialYear = Convert.ToString(DateTime.Today.Year - 1);
            DataTable dtBox = objbll.BindBoxDetail();
            DataList dl = new DataList();
            dl = (DataList)e.Item.FindControl("dlBox");
            if (dtBox.Rows.Count > 0)
            {
                dl.DataSource = dtBox;
                dl.DataBind();
            }
        }
    }

    protected void dlView_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataGrid dg = new DataGrid();
            dg = (DataGrid)e.Item.FindControl("DataGrid1");
            dg.DataSource = dtDet;
            dg.DataBind();
        }
    }

    protected void Datalist1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //((Label)e.Item.FindControl("lblSrNo")).Text = Convert.ToString(e.Item.ItemIndex + 1) + ".";
            DataList dl = new DataList();
            dl = (DataList)e.Item.FindControl("dlView");
            Label lb = new Label();
            lb = (Label)e.Item.FindControl("lblCAG");
            objbll.CAGID = lb.Text;
            dtDet = objbll.GetCertificateDetail();
            DataTable dtlist = objbll.GetCertificateDetailList();
            dl.DataSource = dtlist;
            dl.DataBind();
        }
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        tblInp.Style.Add("display", "");
        tblmessage.Style.Add("display", "");
        tblData.Style.Add("display", "none");
        tbtNoData.Style.Add("display", "none");
    }
    protected void dlBot_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl = new Label();
            Label lblDate = new Label();
            Label lblCAG = new Label();
            lbl = (Label)e.Item.FindControl("lbl");
            lblDate = (Label)e.Item.FindControl("lblPDate");
            lblCAG = (Label)e.Item.FindControl("lblCAG");

            DateTime pdt = Convert.ToDateTime(lblDate.Text);
            DateTime Sdt = pdt.AddDays(3.0);
            string sdate = Sdt.ToString("dd/MM/yyyy");
            if (pdt < DateTime.Now.AddDays(-3.0))
            {
                lbl.Text = "The container with CAG ID " + lblCAG.Text + " might have been shipped on or around " + sdate;
                
            }
            else
            {
                lbl.Text = "The container with CAG ID " + lblCAG.Text + " might be shipped on or around " + sdate;
            }

        }
    }
}
