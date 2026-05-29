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
/// Summary description for DLL_NoofPSCIssued
/// </summary>
public class DLL_NoofPSCIssued
{
    CL_Connection objcon = new CL_Connection();

	public DLL_NoofPSCIssued()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindPSCIssued(BLL_NoofPSCIssued objbll)
    {
        string year = objbll.year;

        string sql = "";
        sql = " Select Country_to_export,convert(char(10),a.Created_On,103) as DateofConsignment,isnull(sum(cast(Quantity_Declared as decimal(38,4))),0)as QtyInMT,count(*) as cnt from apeda.LS_PSC_Certificate a ";
        sql = sql + " where year(a.Created_On)='" + year + "' and  convert(datetime,a.Created_On,103) >= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy") + "',103) and  convert(datetime,a.Created_On,103) <= convert(datetime,'" + DateTime.Now.AddDays(1.0).ToString("dd/MM/yyyy") + "',103)";
        sql = sql + " group by Country_to_export ,convert(char(10),a.Created_On,103)";
        sql = sql + " order by Country_to_export";
        

        return objcon.ExecuteDataSet(sql);
    }


    public DataSet ToTBindPSCIssued(BLL_NoofPSCIssued objbll)
    {
        string year = objbll.year;

        string sql = "";
        //sql = " select Country_to_export,Count(*) as TotalConsignment,isnull(sum(cast(Quantity_Declared as decimal(38,4))),0)as QtyInMT from apeda.LS_PSC_Certificate a ";
        ////sql = sql + " where year(a.Created_On)=year(getdate()) ";
        //sql = sql + " where year(a.Created_On)='"+year+"' ";
        ////sql = sql + " AND a.Created_On <= getdate()-365 ";
        //sql = sql + " group by Country_to_export ";
        //sql = sql + " order by Country_to_export";


        sql = sql + " select Country_to_export,Count(*) as TotalConsignment ";
        sql = sql + " ,sum(QtyInMT) as QtyInMT ";
        sql = sql + " from  LS_TraceCons ";
        sql = sql + " where CreatedYear='" + year + "' and ProductID='" + objbll.ProductID + "' And createdon<=convert(datetime,'" + DateTime.Today.AddDays(1.0).ToString("dd/MM/yyyy") + "',103) ";
        sql = sql + " group by Country_to_export  ";
        sql = sql + " order by Country_to_export";

        return objcon.ExecuteDataSet(sql);
    }


    public DataSet ToTBindPSCIssuedDetailed(BLL_NoofPSCIssued objbll)
    {
        string year = objbll.year;

        string sql = "";
        //sql = " select Country_to_export,count(*) as cnt, convert(datetime,convert(char(10),a.Created_On,103),103),convert(varchar(10),a.Created_On,103) as DateofConsignment,isnull(sum(cast(Quantity_Declared as decimal(38,4))),0)as QtyInMT ";
        //sql = sql + " from apeda.LS_PSC_Certificate a, apeda.LS_AG_PaymentCert b ";
        //sql = sql + " where a.ConsignmentID=b.ConsignmentID and b.ProductID='"+objbll.ProductID+"' and year(a.Created_On)='" + year + "' and   a.Country_to_export = '" + objbll.Country + "'";
        //sql = sql + " group by Country_to_export,convert(varchar(10),a.Created_On,103), convert(datetime,convert(char(10),a.Created_On,103),103) ";
        //sql = sql + " order by  convert(datetime,convert(char(10),a.Created_On,103),103) desc";

        sql = sql + " select Country_to_export,count(*) as cnt, ";
        sql = sql + " convert(datetime,convert(char(10),CreatedOn,103),103) ";
        sql = sql + " ,convert(varchar(10),CreatedOn,103) as DateofConsignment ";
        sql = sql + " ,sum(QtyInMT)as QtyInMT  ";
        sql = sql + "  from LS_TraceCons where ProductID='" + objbll.ProductID + "' and year(CreatedOn)='" + year + "' and CreatedOn <= Convert(dateTime,'" + DateTime.Today.AddDays(1.0).ToString("dd/MM/yyyy") + "',103) and  Country_to_export = '" + objbll.Country + "' ";
        sql = sql + " group by  Country_to_export, ";
        sql = sql + " convert(datetime,convert(char(10),CreatedOn,103),103) ";
        sql = sql + " ,convert(varchar(10),CreatedOn,103) ";
        sql = sql + " order by  convert(datetime,convert(char(10),CreatedOn,103),103) desc";
        
        return objcon.ExecuteDataSet(sql);
    }
}
