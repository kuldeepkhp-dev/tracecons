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

public partial class ViewCons : System.Web.UI.Page
{
    //BLL_Search_PSC_Issuedexp objbll = new BLL_Search_PSC_Issuedexp();
    BLL_Search_PSC_Issuedexp objbll = new BLL_Search_PSC_Issuedexp();
    DataTable dtAimid, dtCagid, dtDetail;
    private Random random = new Random();
    DataTable dtDet;
    public string consid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["ProductID"] = "PRD001";
        //Session["UserID"] = "UVIJDX";
        //if (Session["UserID"] == null)
        //    Response.Redirect("Default.aspx");
        //consid = "020254288159";// Request.QueryString["ConsID"].Replace("'","");
        
        //tblData.Style.Add("display", "none");
        //tbtNoData.Style.Add("display", "none");
        //BindConsignmentN();
        //if(!IsPostBack)
        //    Session["CaptchaImageText"] = GenerateRandomCode();
    }

    void BindConsignmentN()
    {
        BLL_Search_PSC_Issuedexp objbll = new BLL_Search_PSC_Issuedexp();
        objbll.ConsignmentID = consid;
        objbll.ProductID = Session["ProductID"].ToString();
        dtCagid = objbll.CountryWiseDetailPscCertificate();

        if (dtCagid.Rows.Count > 0)
        {
            tblData.Style.Add("display", "");
            tbtNoData.Style.Add("display", "none");
            Datalist1.DataSource = dtCagid;
            Datalist1.DataBind();
            Datalist1.Visible = true;
         }
        else
        {
            tblData.Style.Add("display", "none");
            tbtNoData.Style.Add("display", "");
        }
    }

    


    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["ProductID"] = "PRD001";
        Session["UserID"] = "ABCD";
        consid = txtConsignmentID.Text;

        tblData.Style.Add("display", "none");
        tbtNoData.Style.Add("display", "none");
        BindConsignmentN();
    }
    
    
}
