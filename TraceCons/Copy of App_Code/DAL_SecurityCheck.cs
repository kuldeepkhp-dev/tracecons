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
/// Summary description for DAL_SecurityCheck
/// </summary>
public class DAL_SecurityCheck
{
    CL_Connection objCon = new CL_Connection();
	public DAL_SecurityCheck()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSecurityCodeOnLoad(BLL_SecurityCheck objbll)
    {
        string sql = "";
        sql = sql + " Select * from " + objCon.schemaName + "LS_Exporter_Login Where RcmcNo='" + objbll.RcmcNo + "' ";
        sql = sql + " and UserID = '" + objbll.UserID + "' ";
        return objCon.ExecuteDataTable(sql);

    }

    public DataTable GetSecurityCode(BLL_SecurityCheck objbll)
    {
        string sql = "";
        sql = sql + " Select * from " + objCon.schemaName + "LS_Exporter_Login Where RcmcNo='" + objbll.RcmcNo + "' ";
        sql = sql + " and UserID = '" + objbll.UserID + "' and SecCode='" + objbll.SecurityCode + "' ";
        return objCon.ExecuteDataTable(sql);

    }

    public int UpdateSecurityCode(BLL_SecurityCheck objbll)
    {
        string sql = "";
        sql = sql + " UPDATE " + objCon.schemaName + "LS_Exporter_Login SET SecCode ='"+objbll.SecurityCode+"' Where RcmcNo='" + objbll.RcmcNo + "' ";
        sql = sql + " and UserID = '" + objbll.UserID + "' ";
        return objCon.InsertUpdateCommand(sql);

    }

    public DataTable GetEmailID(BLL_SecurityCheck objbll)
    {
        string sql = "";
        sql = sql + " Select * from " + objCon.schemaName + "LS_ExporterMaster Where RcmcNo='" + objbll.RcmcNo + "' ";
        return objCon.ExecuteDataTable(sql);

    }
}
