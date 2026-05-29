using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DAL_PlotDetails
/// </summary>
public class DAL_PlotDetails
{
    CL_Connection objcon = new CL_Connection();
	public DAL_PlotDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindData(BLL_PlotDetails objbll)
    {
        string sql = "";
        sql = " select b.FarmRegNo,a.FarmerName,a.FarmerAddress,a.FarmerPin,a.FarmerTelePhone, ";
        sql = sql + " b.Area_Per_Plot,b.Survey_no,d.VarietyName, ";
        sql = sql + " convert(char(10),b.DateofRegistration,103) as dtofreg,e.state_Name,f.District_name,g.Talukmandalname ";
        sql = sql + " from " + objcon.schemaName + "LS_FarmerDetail a, " + objcon.schemaName + "LS_FarmRegDetail b," + objcon.schemaName + "LS_Farm_Variety c," + objcon.schemaName + "LS_ProdtVMaster d ";
        sql = sql + " ," + objcon.schemaName + "LS_State_Master e," + objcon.schemaName + "LS_Distt_Master f, " + objcon.schemaName + "LS_Taluk_Master g ";
        sql = sql + " where a.Farmerid=b.farmerid  and b.FarmRegNo=c.FarmRegNo ";
        sql = sql + " and b.Productid =c.productid and b.FarmRegNo='"+objbll.Farmregno.ToString()+"' ";
        sql = sql + " and b.FinancialYear=c.FinancialYear and b.FinancialYear='"+objbll.fiscalyear.ToString()+"' " ;
        sql = sql + " and d.Productid=b.Productid and c.VarietyID=d.VarietyID ";
        sql = sql + " and e.state_code=f.state_code and f.district_code= g.district_code and e.state_code=g.state_code ";
        sql = sql + " and substring(b.FarmRegNo,1,2)=e.state_code and substring(b.FarmRegNo,3,2)=f.district_code  ";
        sql = sql + " and substring(b.FarmRegNo,5,2)=g.talukmandalcode ";
        

        DataSet ds = new DataSet();
        return ds=objcon.ExecuteDataSet(sql);


    }
}
