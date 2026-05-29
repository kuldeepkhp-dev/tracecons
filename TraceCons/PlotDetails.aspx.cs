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

public partial class PlotDetails : System.Web.UI.Page
{
    public string FarmRegNo;
    public string FinancialYear;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        FarmRegNo = Request.QueryString["frm"].ToString().Replace("'", "");
        FinancialYear = Convert.ToString( DateTime.Today.Year-1);
        HyperLink1.Attributes.Add("href", "javascript:OpenWindowBig('CertificateIssue.aspx?frm=" + FarmRegNo + "&fny=" + FinancialYear + "','REGCert')");
        if (!IsPostBack)
        {
            BindFarmer();
        }
    
    }

    public void BindFarmer()
    {
        BLL_PlotDetails obj = new BLL_PlotDetails();
        //obj.agencyid = int.Parse(Session["StateAgencyID"].ToString());
        obj.Farmregno = FarmRegNo;
        obj.fiscalyear = FinancialYear;

        DataSet ds = new DataSet();
        ds = obj.BindDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblFName.Text = ds.Tables[0].Rows[0]["FarmerName"].ToString();
            lblFaddress.Text = ds.Tables[0].Rows[0]["FarmerAddress"].ToString();
            lblRegNo.Text = ds.Tables[0].Rows[0]["FarmRegNo"].ToString();
            lblpin.Text = ds.Tables[0].Rows[0]["FarmerPin"].ToString();
            lblGat.Text = ds.Tables[0].Rows[0]["Survey_no"].ToString();
            lblVariety.Text = ds.Tables[0].Rows[0]["VarietyName"].ToString();
            lblArea.Text = ds.Tables[0].Rows[0]["Area_Per_Plot"].ToString();
            lblDAteOfReg.Text = ds.Tables[0].Rows[0]["dtofreg"].ToString();
            lblSate.Text = ds.Tables[0].Rows[0]["state_Name"].ToString();
            lblDistrict.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
            lblTaluk.Text = ds.Tables[0].Rows[0]["Talukmandalname"].ToString();


        }
        else
        {
            lblerrorMsg.Text = "Sorry! No Record Found";
        }



    }

//    select b.FarmRegNo,a.FarmerName,a.FarmerAddress,a.FarmerPin,a.FarmerTelePhone,
//b.Area_Per_Plot,b.Survey_no,d.VarietyName,
//convert(char(10),b.DateofRegistration,103) as dtofreg,e.state_Name,f.District_name,g.Talukmandalname
// from " + objcon.schemaName + "LS_FarmerDetail a, " + objcon.schemaName + "LS_FarmRegDetail b," + objcon.schemaName + "LS_Farm_Variety c," + objcon.schemaName + "LS_ProdtVMaster d
//," + objcon.schemaName + "LS_State_Master e," + objcon.schemaName + "LS_Distt_Master f, " + objcon.schemaName + "LS_Taluk_Master g
// where a.Farmerid=b.farmerid  and b.FarmRegNo=c.FarmRegNo
//and b.Productid =c.productid and b.FarmRegNo='mh1107029501'
//and b.FinancialYear=c.FinancialYear and b.FinancialYear='2007'  and a.stateagencyid='27'
//and d.Productid=b.Productid and c.VarietyID=d.VarietyID
//and e.state_code=f.state_code and f.district_code= g.district_code and e.state_code=g.state_code
//and substring(b.FarmRegNo,1,2)=e.state_code and substring(b.FarmRegNo,3,2)=f.district_code 
//and substring(b.FarmRegNo,5,2)=g.talukmandalcode




     //   select b.FarmRegNo,a.FarmerName,a.FarmerAddress,a.FarmerPin,a.FarmerTelePhone,
     //b.Area_Per_Plot,b.Survey_no,d.VarietyName,
     //convert(char(10),b.DateofRegistration,103) as dtofreg,e.state_Name,f.District_name,g.Talukmandalname,
     //h.villagename
     //from " + objcon.schemaName + "LS_FarmerDetail a, " + objcon.schemaName + "LS_FarmRegDetail b," + objcon.schemaName + "LS_Farm_Variety c," + objcon.schemaName + "LS_ProdtVMaster d
     //," + objcon.schemaName + "LS_State_Master e," + objcon.schemaName + "LS_Distt_Master f, " + objcon.schemaName + "LS_Taluk_Master g, " + objcon.schemaName + "LS_VillagMaster h
     //where a.Farmerid=b.farmerid  and b.FarmRegNo=c.FarmRegNo
     //and b.Productid =c.productid and b.FarmRegNo='mh1107029501'
     //and b.FinancialYear=c.FinancialYear and b.FinancialYear='2007'  and a.stateagencyid='27'
     //and d.Productid=b.Productid and c.VarietyID=d.VarietyID
     //and e.state_code=f.state_code and f.district_code= g.district_code and e.state_code=g.state_code
     //and g.talukmandalcode =h.talukmandalCode and f.state_code=h.state_code and f.district_code=h.district_code
     //and substring(b.FarmRegNo,1,2)=e.state_code and substring(b.FarmRegNo,3,2)=f.district_code and 
     //substring(b.FarmRegNo,5,2)=h.talukmandalcode and a.VillageCode=h.VillageCode








    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CertificateIssue.aspx?frm=" + FarmRegNo + "&fny="+Convert.ToString(DateTime.Today.Year - 1));
    }
}




