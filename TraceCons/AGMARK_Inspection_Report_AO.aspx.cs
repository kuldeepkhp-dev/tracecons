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

public partial class AgamrkInspection_AGMARK_Inspection_Report_FO : System.Web.UI.Page
{
    BLL_AGMARK_Inspection_Report_FO objbll = new BLL_AGMARK_Inspection_Report_FO();
    DataTable dt,dtBox;
    int noofbox;
    double qty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
      
        if (!IsPostBack)
        {
            string aimid = Request.QueryString["aimid"].ToString();
            objbll.AIMID = aimid;
            dt = objbll.BindReportAO();
            ViewState["lot"] = dt.Rows[0]["lotid"].ToString();
            lblAbnormalMoisture.Text = dt.Rows[0]["qp_Abnormal_Moisture"].ToString();
            lblAddress.Text = dt.Rows[0]["addressAgmark"].ToString();
            lblAgmarkID.Text = dt.Rows[0]["aimid"].ToString();
            lblBerrySize.Text = dt.Rows[0]["qp_Berri_Size"].ToString();
            lblBruishing.Text = dt.Rows[0]["qp_Bruising"].ToString();
            lblCity.Text = dt.Rows[0]["State"].ToString();
            lblCleanliness.Text = dt.Rows[0]["qp_Cleanliness"].ToString();
            lblConditionOfBerries.Text = dt.Rows[0]["qp_Condition_berries"].ToString();
            lblDamageCausedbyPests.Text = dt.Rows[0]["qp_Damage_Caused_by_Pests_Disease"].ToString();
            lblDamageCausedbyTemp.Text = dt.Rows[0]["qp_Damage_Temperature_High_Low"].ToString();
            lblDate.Text = dt.Rows[0]["created_on"].ToString();
            lblDefectInColor.Text = dt.Rows[0]["qp_Defects_in_Color"].ToString();
            lblDefectInShape.Text = dt.Rows[0]["qp_Defects_in_Shape"].ToString();
            lblDeffectinSkinbySun.Text = dt.Rows[0]["qp_Defects_in_Skin"].ToString();
            lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
            lblExporterEmail.Text = dt.Rows[0]["Exp_email"].ToString();
            lblExporterName.Text = dt.Rows[0]["Exp_name"].ToString();
            lblForeignMatter.Text = dt.Rows[0]["qp_Foreign_Matter"].ToString();
            lblForeignSmell.Text = dt.Rows[0]["qp_Foreign_Smell"].ToString();
            lblGeneralAppearance.Text = dt.Rows[0]["qp_General_Apperance"].ToString();
            lblGradeAssigned.Text = dt.Rows[0]["qp_Grade_Assigned"].ToString();
            lblName.Text = dt.Rows[0]["name"].ToString();
            lblNameofCommodity.Text = dt.Rows[0]["commodityName"].ToString();
            lblPacker.Text = dt.Rows[0]["PackHousename"].ToString();
            lblPackHouseAddress.Text = dt.Rows[0]["addressPackhouse"].ToString();
            lblPackHouseNo.Text = dt.Rows[0]["PackhouseNo"].ToString();
            lblPercentageGrade.Text = dt.Rows[0]["qp_Percentage_Grade_Tolerance"].ToString();
            lblPets.Text = dt.Rows[0]["qp_Pests"].ToString();
            lblPhone.Text = "Telephone No. :- " + dt.Rows[0]["Telephone"].ToString();
            lblPIN.Text = "Pincode - " + dt.Rows[0]["Pin"].ToString();
            lblProduct.Text = dt.Rows[0]["commodityName"].ToString();
            lblRecommendedCAG.Text = dt.Rows[0]["qp_Recomended_Grading_Remarks"].ToString();
            lblRemarks.Text = dt.Rows[0]["qp_Remarks"].ToString();
            lblShippingMark.Text = dt.Rows[0]["Shipping_Mark"].ToString();
            lblSize.Text = dt.Rows[0]["qp_Size"].ToString();
            lblSkinDefect.Text = dt.Rows[0]["qp_Skin_Defects"].ToString();
            lblSoundness.Text = dt.Rows[0]["qp_Soundness"].ToString();
            lblSugar.Text = dt.Rows[0]["qp_Sugar_Acid_Ratio"].ToString();
            
            lblTotalSolubleSolids.Text = dt.Rows[0]["qp_Total_Soluble_Solids"].ToString();
            lblValidityDate.Text = dt.Rows[0]["PackHouseValidityDate"].ToString();
            lblVisibleTrace.Text = dt.Rows[0]["qp_Visible_Trace"].ToString();
           
            
            ViewState["LOUserid"] = dt.Rows[0]["LOUserid"].ToString();
            ViewState["FOUserid"] = dt.Rows[0]["FOUserid"].ToString();
            ViewState["Labid"] = dt.Rows[0]["labid"].ToString();


            dtBox = objbll.BindBoxes();
            if (dtBox.Rows.Count > 0)
            {
                GV.Visible = true;
                GV.DataSource = dtBox;
                GV.DataBind();
                lblTotalQTY.Text = Convert.ToString(qty/1000);
            }


            //---
            Image1.ImageUrl = "ThumbFromID.aspx?IMAGE_ID=" + ViewState["FOUserid"].ToString() + "&LAB_ID=" + ViewState["Labid"].ToString() + "&Userid=" + ViewState["FOUserid"].ToString();
            Image2.ImageUrl = "ThumbFromID.aspx?IMAGE_ID=" + ViewState["LOUserid"].ToString() + "&LAB_ID=" + ViewState["Labid"].ToString() + "&Userid=" + ViewState["LOUserid"].ToString();

            GetLabDetailsFO(ViewState["Labid"].ToString(), ViewState["FOUserid"].ToString());
            GetLabDetailsLO(ViewState["Labid"].ToString(), ViewState["LOUserid"].ToString());

            //---


        }



        HyperLink1.Attributes.Add("href", "javascript:OpenWindowBig('ViewLotDetail.aspx?lot=" + ViewState["lot"].ToString().Trim() + "&fny=" + dt.Rows[0]["yr"] + "','Dettt')");
    }




    void GetLabDetailsFO(string LABID, string USERID)
    {
        BLL_AGMARK_Generate_Certificate_ao obj = new BLL_AGMARK_Generate_Certificate_ao();
        obj.Labid = LABID;
        obj.Userid = USERID;
        DataTable dt = obj.GetLabDetails();
        if (dt.Rows.Count > 0)
        {
            lblFO.Text = dt.Rows[0]["UserName"].ToString();

        }

    }
    void GetLabDetailsLO(string LABID, string USERID)
    {
        BLL_AGMARK_Generate_Certificate_ao obj = new BLL_AGMARK_Generate_Certificate_ao();
        obj.Labid = LABID;
        obj.Userid = USERID;
        DataTable dt = obj.GetLabDetails();
        if (dt.Rows.Count > 0)
        {
            lblLO.Text = dt.Rows[0]["UserName"].ToString();

        }

    }



    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
            noofbox = noofbox + Convert.ToInt32(e.Row.Cells[1].Text);
            qty = qty + Convert.ToDouble(e.Row.Cells[3].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = noofbox.ToString();
            e.Row.Cells[3].Text = qty.ToString();
        }
    }
    
}
