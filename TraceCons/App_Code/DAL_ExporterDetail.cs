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
/// Summary description for DAL_ExporterDetail
/// </summary>
public class DAL_ExporterDetail
{
    CL_Connection objcon = new CL_Connection();
	public DAL_ExporterDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindExporter(BLL_ExporterDetail objbll)
    {
        string sql = " select a.*, (select State_NAME from  " + objcon.schemaName + "LS_State_Master where State_Code=a.State_Code ) as Statename from " + objcon.schemaName + "LS_ExporterMaster a where IECODE='" + objbll.IECODE.ToString().Replace("'", "").Trim() + "'";

        DataSet ds = new DataSet();
        return ds = objcon.ExecuteDataSet(sql);
         
    }


}
