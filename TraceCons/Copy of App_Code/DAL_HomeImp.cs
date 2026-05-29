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
/// Summary description for DAL_HomeImp
/// </summary>
public class DAL_HomeImp
{
    CL_Connection objcon = new CL_Connection();
	public DAL_HomeImp()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindInfoIMP(BLL_HomeImp objbll)
    {

        string sql = "";
        DataTable dt;

        sql = " select *,cast(SubscriptionYear as int)*OneYearCost as TotalCost from " + objcon.schemaName + "LS_Importer_CostMaster a, " + objcon.schemaName + "LS_Importer_Login b," + objcon.schemaName + "LS_SubscriptionIMP c ";
        sql = sql + " where b.ImporterID=c.ImporterID and a.costYear = Year(b.Created_on) ";
            sql = sql + " and b.ImporterID='" + objbll.UserID + "' and b.ImporterLoginID='" + objbll.ImporterLoginID + "' ";

            dt = objcon.ExecuteDataTable(sql);
               
        return dt;
                
    }

    public DataTable BindInfoEXP(BLL_HomeImp objbll)
    {

        string sql = "";
        DataTable dt;
        
            sql = " select * from " + objcon.schemaName + "LS_SubscriptionEXP ";
            sql = sql + " where RcMCNo='" + objbll.UserID + "' ";

            dt = objcon.ExecuteDataTable(sql);
       
        return dt;

    }

    public int InsertSubsEXP(BLL_HomeImp objbll)
    {
        int i = 0;
        string sql = "";
        string year = DateTime.Today.Year.ToString();
        sql = "Select * from " + objcon.schemaName + "LS_SubscriptionEXP Where RCMCNo ='" + objbll.UserID + "' AND Subscriptionyear=year(getdate())";
        DataTable dt = objcon.ExecuteDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            sql = "";
            sql = sql + " Update " + objcon.schemaName + "LS_SubscriptionEXP Set Report1 ='" + objbll.Report1 + "', ";
            sql = sql + " Report2='" + objbll.Report2 + "', ";
            sql = sql + " Report3='" + objbll.Report3 + "', ";
            sql = sql + " Report4='" + objbll.Report4 + "', ";
            sql = sql + " SubscriptionDate=getdate(), ";
            sql = sql + " ExpiryDate='12/31/" + year + "', ";
            sql = sql + " Subscriptionyear='" + year + "', ";
            sql = sql + " UpdatedOn = getdate()";
            sql = sql + " Where RCMCNo='" + objbll.UserID + "' AND Subscriptionyear=year(getdate())";
            i = objcon.InsertUpdateCommand(sql);
        }
        return i;
    }

    public int InsertSubsIMP(BLL_HomeImp objbll)
    {
        int i = 0;
        string year = DateTime.Today.Year.ToString();
        string sql = "";
        sql = "Select * from " + objcon.schemaName + "LS_SubscriptionIMP Where ImporterID ='" + objbll.UserID + "' AND Subscriptionyear=year(getdate())";
        DataTable dt = objcon.ExecuteDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            sql = "";
            sql = sql + " Update " + objcon.schemaName + "LS_SubscriptionIMP Set Report1 ='" + objbll.Report1 + "', ";
            sql = sql + " Report2='" + objbll.Report2 + "', ";
            sql = sql + " Report3='" + objbll.Report3 + "', ";
            sql = sql + " Report4='" + objbll.Report4 + "', ";
            sql = sql + " SubscriptionDate=getdate(), ";
            sql = sql + " ExpiryDate='12/31/" + year + "', ";
            sql = sql + " Subscriptionyear='" + year + "', ";
            sql = sql + " UpdatedOn = getdate()";
            sql = sql + " Where ImporterID ='" + objbll.UserID + "' AND Subscriptionyear=year(getdate())";
            i = objcon.InsertUpdateCommand(sql);
        }
        return i;
    }


    public int UpdatePaymentResponse(BLL_HomeImp objbll)
    {
        int i = 0;
        string sql = "";
               
        if (objbll.ModuleID =="IMP")
        {
             sql = sql + "  update APEDA.LS_SubscriptionIMP set  TransactionID ='" + objbll.EPGTxnId +"',SubscriptionAmount='"+ objbll.BGAmount +"', ImporterActiveFlag='"+ objbll.ActivFlag +"'" ;
             sql = sql + "   , reasoniffail='" + objbll.RespMessage +"'";
             sql = sql + "    Where ImporterID='" + objbll.ImpNo + "'  AND Subscriptionyear = year(getdate())";

            i = objcon.InsertUpdateCommand(sql);
        }
        else
        {
            sql = sql + "  update APEDA.LS_SubscriptionEXP set  TransactionID ='" + objbll.EPGTxnId + "',SubscriptionAmount='" + objbll.BGAmount + "', ExporterActiveFlag='" + objbll.ActivFlag + "'";
            sql = sql + "   , reasoniffail='" + objbll.RespMessage + "'";
            sql = sql + "    Where RCMCNo='" + objbll.ImpNo + "' AND Subscriptionyear = year(getdate())";
            i = objcon.InsertUpdateCommand(sql);
        }
        return i;
    }

}
