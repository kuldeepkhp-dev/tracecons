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
/// Summary description for DAL_NoofAgmarkIssued
/// </summary>
public class DAL_NoofAgmarkIssued
{
    CL_Connection objcon = new CL_Connection();

	public DAL_NoofAgmarkIssued()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindTotalQty(BLL_NoofAgmarkIssued objbll)
    {
        string sql = "";
        sql = " select  cast(isnull(Sum(Qty_adjusted),0) as decimal(38,4)) as QtyinMT ";
        sql = sql + " from  apeda.LS_AG_Certificate a, apeda.LS_ExpConsignMaster b, apeda.LS_ExpConsignDetails c,apeda.LS_ExpLot_Details d ";
        sql=sql+" where a.Consignmentid=b.consignmentid and b.consignmentid=c.consignmentid and c.lotid=d.lotid ";
        sql=sql+" and a.Consignmentid not in(select Consignmentid from apeda.LS_PSC_Certificate) ";
        sql=sql+" and a.created_on >=convert(datetime,'"+objbll.DateReq+"',103)-7 ";

        DataTable dt = objcon.ExecuteDataTable(sql);
        return dt;

        //return null;
    }
    public DataTable BindTotalConsignment(BLL_NoofAgmarkIssued objbll)
    {
        string sql = "";
        sql = " select  count(*) as TotCons ";
        sql=sql+" from  apeda.LS_AG_Certificate a, apeda.LS_ExpConsignMaster b, apeda.LS_ExpConsignDetails c,apeda.LS_ExpLot_Details d ";
        sql=sql+" where a.Consignmentid=b.consignmentid and b.consignmentid=c.consignmentid and c.lotid=d.lotid ";
        sql = sql + " and a.Consignmentid not in(select Consignmentid from apeda.LS_PSC_Certificate) ";
        sql = sql + " and a.created_on >=convert(datetime,'" + objbll.DateReq + "',103)-7 ";
        DataTable dt = objcon.ExecuteDataTable(sql);
        return dt;
    }

    public DataTable BindTotal(BLL_NoofAgmarkIssued objbll)
    {
        string sql = "";
        sql = " select  convert(char(10),a.Created_On,103) as CreatedOn,Count(*) As Cnt,a.Consignee_Country,   ";
        sql = sql + " (Select cast(isnull(Sum(Qty_adjusted),0) as decimal(38,4)) from APEDA.LS_ExpLot_Details b,APEDA.LS_ExpConsignDetails c where  ";
        sql = sql + " c.lotid=b.lotid and c.consignmentid in(Select d.Consignmentid from APEDA.LS_AG_Certificate d ";
        sql = sql + " where (a.Consignee_Country=d.Consignee_Country or d.Consignee_Country is null) And c.Consignmentid not in (select Consignmentid from apeda.LS_PSC_Certificate)  AND convert(char(10),d.Created_On,103)=convert(char(10),a.Created_On,103))) as QtyinMT";
        sql = sql + " from  apeda.LS_AG_Certificate a, apeda.LS_AG_PaymentCert b ";
        sql = sql + " where ";
        sql = sql + " a.Consignmentid =b.Consignmentid and";
        sql = sql + " convert(datetime,a.created_on,103) >=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103) AND convert(datetime,a.created_on,103) <=convert(datetime,'" + DateTime.Today.AddDays(1.0).ToString("dd/MM/yyyy") + "',103) and b.ProductID='" + objbll.ProductID + "' ";
        sql = sql + " Group by convert(char(10),a.Created_On,103),a.Consignee_Country order by a.Consignee_Country";


        sql = "";
        sql = " select  convert(char(10),a.Created_On,103) as CreatedOn,Count(*) As Cnt,a.Consignee_Country,   ";
        sql = sql + " (Select cast(isnull(Sum(Qty_adjusted),0) as decimal(38,4)) from APEDA.LS_ExpLot_Details b,APEDA.LS_ExpConsignDetails c where  ";
        sql = sql + " c.lotid=b.lotid and c.consignmentid in(Select d.Consignmentid from APEDA.LS_AG_Certificate d ";
        sql = sql + " where (a.Consignee_Country=d.Consignee_Country or d.Consignee_Country is null)  AND convert(char(10),d.Created_On,103)=convert(char(10),a.Created_On,103))) as QtyinMT";
        sql = sql + " from  apeda.LS_AG_Certificate a, apeda.LS_AG_PaymentCert b ";
        sql = sql + " where ";
        sql = sql + " a.Consignmentid =b.Consignmentid and";
        sql = sql + " convert(datetime,a.created_on,103) >=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103) AND convert(datetime,a.created_on,103) <=convert(datetime,'" + DateTime.Today.AddDays(1.0).ToString("dd/MM/yyyy") + "',103) and b.ProductID='" + objbll.ProductID + "' ";
        sql = sql + " Group by convert(char(10),a.Created_On,103),a.Consignee_Country order by a.Consignee_Country";
        DataTable dt = objcon.ExecuteDataTable(sql);
        return dt;
    }
}
