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

public partial class AgamrkInspection_AGMARK_Generate_Certificate : System.Web.UI.Page
{
    BLL_AGMARK_Generate_Certificate objbll = new BLL_AGMARK_Generate_Certificate();
    DataTable dtDet,dtExp,dtVar,dtGrd,dtBox;
    double totBox, qty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("Default.aspx");


            ViewState["cagid"] = Request.QueryString["cagid"].ToString().Replace("'", "");
            objbll.ConsignmentID = ViewState["cagid"].ToString();
            dtDet = objbll.BindDetail();

            //-- for signature-----
            ViewState["LabID"] = dtDet.Rows[0]["labid"].ToString();
            ViewState["Userid"] = dtDet.Rows[0]["Userid"].ToString();

            ViewState["Date_of_Issue"] = dtDet.Rows[0]["Date_of_Issue"].ToString();

            lblCAGID.Text = "CAGID : "+objbll.ConsignmentID;
            lblCertificateNo.Text = dtDet.Rows[0]["Certificate_No"].ToString();
            lblComments.Text = dtDet.Rows[0]["comments"].ToString();
            lblDestination.Text = dtDet.Rows[0]["Consignee_Destination"].ToString();
            lblMode.Text = dtDet.Rows[0]["Transport_Mode"].ToString();
            lblPackageNo.Text = dtDet.Rows[0]["Packages_Type_Identification"].ToString();
            lblPackHouse.Text = dtDet.Rows[0]["packhousename"].ToString() + "<br>" + dtDet.Rows[0]["packhouseno"].ToString() + ",<br>" + dtDet.Rows[0]["address"].ToString();
            lblSippingMark.Text = dtDet.Rows[0]["shipping_mark"].ToString();
            lblValidity.Text = dtDet.Rows[0]["Validity_Period"].ToString() + " days from the date of issue.";
            objbll.IECODE = dtDet.Rows[0]["iecode"].ToString();

            dtExp = objbll.BindExpDetail();
            lblRCAC.Text = dtExp.Rows[0]["RcmcNo"].ToString();
            lblExporterName.Text = dtExp.Rows[0]["Exp_name"].ToString();
            lblExpAddress.Text = dtExp.Rows[0]["Exp_address"].ToString() + "<br>" + dtExp.Rows[0]["State_name"].ToString() + "<br> Tel:-" + dtExp.Rows[0]["TelePhone"].ToString() + "<br> PIN:-" + dtExp.Rows[0]["Pin"].ToString();
            dtVar = objbll.BindVareityDetail();
            dlVar.DataSource = dtVar;
            dlVar.DataBind();
            dtGrd = objbll.BindGradeDetail();
            dlGRADE.DataSource = dtGrd;
            dlGRADE.DataBind();
            dtBox = objbll.BindBoxDetail();
            dlBox.DataSource = dtBox;
            dlBox.DataBind();

            Image1.ImageUrl = "ThumbFromID.aspx?IMAGE_ID=" + ViewState["Userid"].ToString() + "&LAB_ID=" + ViewState["LabID"].ToString() + "&Userid=" + ViewState["Userid"].ToString();

            GetLabDetails(ViewState["LabID"].ToString(), ViewState["Userid"].ToString());
        }
    }

    void GetLabDetails(string LABID,string USERID)
    {
        objbll.Labid = LABID;
        objbll.Userid = USERID;
        DataTable dt = objbll.GetLabDetails();
        if (dt.Rows.Count > 0)
        {
            lblLabName.Text = dt.Rows[0]["LabName"].ToString();
            lblUserName.Text = dt.Rows[0]["UserName"].ToString();
            lblPlaceDate.Text = dt.Rows[0]["LabCity"].ToString()+" , "+ViewState["Date_of_Issue"].ToString();
        }

    }


    protected void dlBox_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            totBox = totBox + double.Parse(((Label)e.Item.FindControl("lblNoofBox")).Text);
             
            qty = qty + double.Parse(((Label)e.Item.FindControl("lblTotalQty")).Text);
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            ((Label)e.Item.FindControl("lblTotBox")).Text = totBox.ToString();
            ((Label)e.Item.FindControl("lblTotQty")).Text = qty.ToString();
            ((Label)e.Item.FindControl("lblInMT")).Text = (qty/1000).ToString();
        }
    }
}
