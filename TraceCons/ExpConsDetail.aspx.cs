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

public partial class ExpConsDetail : System.Web.UI.Page
{
    BLL_ExpConsDetail objbll = new BLL_ExpConsDetail();
    decimal qty=0, total=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objbll.IECODE = Session["IECODE"].ToString();
            objbll.ImportCountry = Request.QueryString["icntry"].ToString();
            objbll.ImporterName = Request.QueryString["imp"].ToString().Replace("'","").Replace("~~","&");
            Label1.Text = objbll.ImportCountry;
            lblExporter.Text = Session["Exporter"].ToString();
            DataTable dt = objbll.BindDetailCons();
            
            if (dt.Rows.Count > 0)
            {
                GV_PSCIssued.DataSource = dt;
                GV_PSCIssued.DataBind();
            }
        }
    }
    protected void GV_PSCIssued_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            qty = qty + Convert.ToDecimal(e.Row.Cells[2].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = qty.ToString();
        }

    }

   
}
