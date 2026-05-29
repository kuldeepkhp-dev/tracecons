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
/// Summary description for DAL_ExpConsDetail
/// </summary>
public class DAL_ExpConsDetail
{
    CL_Connection objcon = new CL_Connection();
	public DAL_ExpConsDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindDetail(BLL_ExpConsDetail objbii)
    {
        string sql = "";
        sql = sql + " select convert(varchar(10),a.Date_of_Issue,103) AS pdate,a.Container_No,b.Quantity_Declared,convert(datetime,convert(char(10),a.Created_On,103),103)  ";
        sql = sql + " from APEDA.LS_PSC_Certificate a,APEDA.LS_ExpApplyPSCCert b ";
        sql = sql + " where a.consignmentID = b.ConsignmentID  ";
        sql = sql + " and b.iecode = '" + objbii.IECODE + "' ";
        sql = sql + " and b.Importer_name = '" + objbii.ImporterName + "' ";
        sql = sql + " and a.country_to_export='" + objbii.ImportCountry + "' and year(a.created_on)=year(getdate())";
        sql = sql + " order by convert(datetime,convert(char(10),a.Created_On,103),103) desc ";

        return objcon.ExecuteDataTable(sql);
    }
}
