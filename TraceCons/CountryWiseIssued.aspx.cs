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

public partial class CountryWiseIssued : System.Web.UI.Page
{
    decimal sum = 0;
    decimal sumcont = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RcmcNo"] != null)
            if (Session["SecCode"] == null)
                Response.Redirect("expseccode.aspx");
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        BindPSCIssued();
    }


    public void BindPSCIssued()
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        BLL_NoofPSCIssued objbll = new BLL_NoofPSCIssued();
        objbll.year = DateTime.Today.Year.ToString();
        objbll.ProductID = Session["ProductID"].ToString();
        DataSet ds = objbll.ToTBindPSCIssued();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GV_PSCIssued.DataSource = ds;
            GV_PSCIssued.DataBind();
            GV_PSCIssued.Visible = true;
        }
        else
        {
            GV_PSCIssued.Visible = false;

        }



    }


    protected void GV_PSCIssued_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow )
        {
            sumcont = sumcont + Convert.ToDecimal(((Label)e.Row.FindControl("lbl")).Text);
            //sumcont = sumcont + Convert.ToDecimal(e.Row.Cells[2].Text);
            sum = sum + Convert.ToDecimal(e.Row.Cells[3].Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[2].Text = sumcont.ToString();
            e.Row.Cells[3].Text = sum.ToString();
        }
    }
}
