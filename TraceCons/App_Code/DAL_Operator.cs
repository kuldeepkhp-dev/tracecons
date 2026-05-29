using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL_Operator
/// </summary>
public class DAL_Operator
{
   // SqlConnection conn;
    CL_Connection objcon = new CL_Connection();
	public DAL_Operator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet BindloginInfo(BLL_Operator objbll)
    {
        string sql = "";
        sql = " select * from " + objcon.schemaName + "LS_Operator_Logon  where OPT_UserID ='" + objbll.Userid.Replace("'", "''") + "' and OPT_Password='" + objbll.pwd.Replace("'", "''") + "' ";
       
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }

    public DataSet BindPSCData(BLL_Operator objbll)
    {
        string sql = "";
        sql = sql + " select ";
        sql = sql + " a.ConsignmentID,a.Certificate_No, b.Container_No,c.Exp_name,(c.Exp_address + ' - '+ d.State_Name) as address, ";
        sql = sql + " a.Country_TO_Export as DestinationCountry,b.Port_of_Unloading as destinationPort, b.Port_of_loading as OriginPort ";
        sql = sql + " from " + objcon.schemaName + "LS_PSC_Certificate a, " + objcon.schemaName + "LS_ExpApplyPSCCert b," + objcon.schemaName + "LS_ExporterMaster c," + objcon.schemaName + "LS_State_Master d ";
        sql = sql + " where a.ConsignmentID=b.ConsignmentID and b.IECODE=c.IECODE and c.state_code=d.state_code ";
        sql = sql + " and a.consignmentID in(select ConsignmentID from apeda.LS_ExpConsignMaster where ProductID='"+ objbll.ProductID+"') ";
        if (objbll.ConsignmentID != null)
        {
            sql = sql + " and a.ConsignmentID='" + objbll.ConsignmentID + "' ";
        }
       
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }
    public DataSet BindContainerData(BLL_Operator objbll)
    {
        string sql = "";
        sql = sql + " select * from " + objcon.schemaName + "LS_Operator_Data ";
        sql = sql + "  where consignmentID='" + objbll.ConsignmentID + "' and ProductID='"+ objbll.ProductID+"' ";
        sql = sql + " order by created_on desc ";
  
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }


    public int AddData(BLL_Operator objbll)
    {
        string sql = "";
        sql = " INSERT INTO APEDA.LS_Operator_Data ";
        sql = sql + " (ProductID,ConsignmentID, PortName, CheckInDate, CheckOutDate, Created_On, OPTID) ";
        sql = sql + " VALUES ('" + objbll.ProductID + "','" + objbll.ConsignmentID + "','" + objbll.PortName + "',convert(datetime,'" + objbll.CheckInDate + "',103),convert(datetime,'" + objbll.CheckOutDate + "',103),getdate(),'" + objbll.OPTID + "')";

        int i = objcon.InsertUpdateCommand(sql);
        return i;
    }
    
}

