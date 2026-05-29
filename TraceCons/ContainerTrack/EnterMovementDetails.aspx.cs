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

public partial class ContainerTrack_EnterMovementDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
         string ConsignmentID;
         if (Request.QueryString["customid"] != null)
         {
             ConsignmentID = Request.QueryString["customid"].ToString();
         }
         else
         { ConsignmentID = "0"; }

         if (!IsPostBack)
         {
             ViewState["ConsignmentID"] = ConsignmentID;
             BindPSCDetails(ViewState["ConsignmentID"].ToString());
             BindContainerDetails(ViewState["ConsignmentID"].ToString());
         }
         

    }

    void BindPSCDetails(string ConsignmentID)
    {
        BLL_Operator obj = new BLL_Operator();
        obj.ConsignmentID = ConsignmentID;
        obj.ProductID = Session["ProductID"].ToString();

        DataSet ds = obj.BindPSCData();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
        else
        {
            GridView1.Visible = false;
        }
    }

    void BindContainerDetails(string ConsignmentID)
    {
        BLL_Operator obj = new BLL_Operator();
        obj.ConsignmentID = ConsignmentID;
        obj.ProductID = Session["ProductID"].ToString();
        DataSet ds = obj.BindContainerData();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds;
            GridView2.DataBind();
            GridView2.Visible = true;
        }
        else
        {
            GridView2.Visible = false;
        }
    }





    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtPortName.Text.Length != 0 && txtCheckInDate.Text.Length != 0 && txtCheckOutDate.Text.Length != 0)
        {
            BLL_Operator obj = new BLL_Operator();
            obj.PortName = txtPortName.Text.Replace("'", "''");
            obj.CheckInDate = txtCheckInDate.Text.Replace("'", "''");
            obj.CheckOutDate = txtCheckOutDate.Text.Replace("'", "''");
            obj.OPTID = Session["OPTID"].ToString();
            obj.ProductID = Session["ProductID"].ToString();
            obj.ConsignmentID = ViewState["ConsignmentID"].ToString();
            try
            {
                int i = obj.AddData();
                txtPortName.Text = "";
                txtCheckInDate.Text = "";
                txtCheckOutDate.Text = "";
                BindContainerDetails(ViewState["ConsignmentID"].ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
        else
        {

        }

    }
}
