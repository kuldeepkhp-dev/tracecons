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

public partial class yourcont : System.Web.UI.Page
{
    BLL_ExporterConsignment objbll = new BLL_ExporterConsignment();
    decimal sum = 0;
    decimal sumcont = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["RcmcNo"] != null)
                if (Session["SecCode"] == null)
                    Response.Redirect("expseccode.aspx");
            if (Session["UserID"] == null)
                Response.Redirect("Default.aspx");

            lblExporter.Text = Session["Exporter"].ToString();
            ExporterContainer();

        }
    }

    void ExporterContainer()
    {
        objbll.IECODE = Session["IECODE"].ToString();
        DataTable dt = objbll.GetExporterConsignment();
        if (dt.Rows.Count > 0)
        {
            DataGrid1.DataSource = dt;
            DataGrid1.DataBind();
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl = (Label)e.Item.FindControl("lbl");
            sumcont = sumcont + Convert.ToDecimal(lbl.Text);
            sum = sum + Convert.ToDecimal(e.Item.Cells[3].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = "Total";
            e.Item.Cells[2].Text = sumcont.ToString();
            e.Item.Cells[3].Text = sum.ToString();
        }
    }
}
