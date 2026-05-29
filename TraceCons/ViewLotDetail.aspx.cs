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

public partial class FA_ViewLotDetail : System.Web.UI.Page
{
    BLL_ListPacking objbll = new BLL_ListPacking();
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("Default.aspx");
            objbll.LotID = Request.QueryString["lot"].Replace("'", "").Replace("%20", "");
            objbll.FinancialYear =Convert.ToInt32(Request.QueryString["fny"].Replace("'", "").Replace("%20", ""));
            Session["FinancialYear"] = objbll.FinancialYear - 1;
            objbll.FinancialYear = objbll.FinancialYear - 1;
            BindLotGrid();
        }
    }

    void BindLotGrid()
    {
        dt = objbll.BindLotDetailOf_A_Lot();
        if (dt.Rows.Count > 0)
        {
            GD.DataSource = dt;
            GD.DataBind();
           
        }
        
    }
}
