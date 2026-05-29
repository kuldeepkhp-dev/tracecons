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

public partial class ShiippDetail : System.Web.UI.Page
{
    decimal qty = 0, total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            BLL_NoofPSCIssued obj = new BLL_NoofPSCIssued();
            obj.year = DateTime.Today.Year.ToString();
            obj.Country = Request.QueryString["c"].ToString();
            obj.ProductID = Session["ProductID"].ToString();
            Label1.Text = obj.Country;
            DataSet dt = obj.ToTBindPSCIssuedDetailed();
            GV_PSCIssued.DataSource = dt;
            GV_PSCIssued.DataBind();
        }
    }
    protected void GV_PSCIssued_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            total = total + Convert.ToDecimal(e.Row.Cells[1].Text);
            qty = qty + Convert.ToDecimal(e.Row.Cells[2].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = total.ToString();
            e.Row.Cells[2].Text = qty.ToString();
        }
    }
}
