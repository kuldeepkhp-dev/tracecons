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
/// Summary description for DAL_PackHouses
/// </summary>
public class DAL_PackHouses
{
    CL_Connection objcon = new CL_Connection();
	public DAL_PackHouses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindPackHouse()
    {
        string sql = "";
        sql = "select packHouseNo,(isnull(PackHouseName,'')+' -'+isnull(Distt,'')) as packHouseName from "+objcon.schemaName+"LS_PackHousemaster ";
        sql = sql + " where (PackHouseName is not null or PackHouseName<>'') order by PackHouseName";
        return objcon.ExecuteDataTable(sql);

    }
    public DataTable BindPackHouseDetails(BLL_PackHouses objbll)
    {
        string sql = "";
        sql = "select * ,Convert(char(10),dateofIssue,103)as IssueDate,convert(char(10),DateofExpiry,103)as ValidityDate from " + objcon.schemaName + "LS_PackHousemaster ";
        sql = sql + " where packHouseNo='"+objbll.PackHouseCode+"' order by PackHouseName";
        return objcon.ExecuteDataTable(sql);
    }
}
