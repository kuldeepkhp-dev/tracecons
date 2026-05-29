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
/// Summary description for DAL_ExporterConsignment
/// </summary>
public class DAL_ExporterConsignment
{
    CL_Connection objcon = new CL_Connection();
	public DAL_ExporterConsignment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetExporterConsignment(BLL_ExporterConsignment objbll)
    {
        string sql = "";
        sql = " Select a.country_to_export,c.Importer_Name, Count(*) as cnt, sum(cast(c.Quantity_Declared as decimal(38,3)) ) as qty from " + objcon.schemaName + "LS_PSC_Certificate a," + objcon.schemaName + "LS_ExpConsignMaster b," + objcon.schemaName + "LS_ExpApplyPSCCert c ";
        sql = sql + " Where a.ConsignmentID = b.ConsignmentID and a.ConsignmentID = c.ConsignmentID and b.IECODE='" + objbll.IECODE + "' and year(a.Date_of_Issue) ='" + DateTime.Today.Year.ToString() + "'";
        sql = sql + " group by a.country_to_export,c.Importer_Name";
        sql = sql + " Order by a.country_to_export, c.Importer_Name";
        return objcon.ExecuteDataTable(sql);
    }
}
