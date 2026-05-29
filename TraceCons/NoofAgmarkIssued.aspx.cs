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

public partial class NoofAgmarkIssued : System.Web.UI.Page
{
    double cnt = 0, qnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RcmcNo"] != null)
            if (Session["SecCode"] == null)
                Response.Redirect("expseccode.aspx");
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        BindDateWiseConsignment();
    }
  



    public void BindDateWiseConsignment()
    {
        BLL_NoofAgmarkIssued obj = new BLL_NoofAgmarkIssued();
        obj.DateReq = DateTime.Now.ToString("dd/MM/yyyy");
        obj.ProductID = Session["ProductID"].ToString();

        DataTable dttot = obj.BindTotal();

       
        if (dttot.Rows.Count > 0)
        {
            GV_AGIssued.DataSource = dttot;
            GV_AGIssued.DataBind();
            GV_AGIssued.Visible = true;
        }
        else
        {
            GV_AGIssued.Visible = false;
            lblMsg.Text = "Sorry! No information available for the container to be shipped in next one week.";
            lblDisccl.Text = "";

        }

    }


    
    protected void GV_AGIssued_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            cnt = cnt + Convert.ToDouble(e.Row.Cells[2].Text);
            qnt = qnt + Convert.ToDouble(e.Row.Cells[3].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "TOTAL";
            e.Row.Cells[2].Text = cnt.ToString();
            e.Row.Cells[3].Text = qnt.ToString();
        }
    }
}
