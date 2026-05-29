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
/// Summary description for DAL_Default
/// </summary>
public class DAL_Default
{
    SqlConnection conn;
    CL_Connection objcon = new CL_Connection();
	public DAL_Default()
	{
		//
		// TODO: Add constructor logic here
		//
	}




    public DataTable GetUserPassword(BLL_Default objbll)
    {
        string sql = "";
        sql = " select * from " + objcon.schemaName + "LS_Importer_Login Where ImporterLoginID = '" + objbll.Userid + "'";
        return objcon.ExecuteDataTable(sql);
    }

    public DataSet BindCountry(BLL_Default objbll)
    {
        string sql = "";
        sql = " select Country_Code,upper(Country_Name) as Country_Name from " + objcon.schemaName + "LS_CountryMaster order by Country_Name asc ";
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }

    public DataSet BindLoginInfoExp(BLL_Default objbll)
    {

        string sql = "";
        string year = DateTime.Today.Year.ToString();
        sql = " select * from " + objcon.schemaName + "LS_SubscriptionEXP Where RcmcNo ='" + objbll.RCMCNo.Replace("'", "''") + "' AND  Subscriptionyear='" + year + "'";
        DataTable dt = objcon.ExecuteDataTable(sql);
        if (dt.Rows.Count == 0)
        {
            sql = "";
            sql = " Insert Into " + objcon.schemaName + "LS_SubscriptionEXP(RCMCNo,Report1,Report2,Report3,Report4,ExporterActiveFlag,Subscriptionyear,SubscriptionDate,ExpiryDate,Created_On,CreatedBy) values('" + objbll.RCMCNo + "','N','N','N','N','N','" + year + "',getdate(),'12/31/" + year + "',getdate(),'" + objbll.RCMCNo + "')";
            objcon.InsertUpdateCommand(sql);
        }
        sql = " ";
        sql = " select a.*,b.Exp_name,b.Iecode,b.Exp_address,b.Email,c.* from " + objcon.schemaName + "LS_Exporter_Login a," + objcon.schemaName + "LS_ExporterMaster b," + objcon.schemaName + "LS_SubscriptionEXP c where a.RcmcNo ='" + objbll.RCMCNo.Replace("'", "''") + "' and a.USerID ='" + objbll.Userid.Replace("'", "''") + "' and a.Password=substring(substring('" + objbll.pwd + "',9," + objbll.pwd.Length + "),1," + Convert.ToString(objbll.pwd.Length - 16) + ") ";
        sql = sql + " and a.RcmcNo=b.RcmcNo and b.DeRegFlag ='R' and a.RcmcNo=c.RcmcNo and (getdate() between SubscriptionDate and ExpiryDate)";
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }

    public DataSet BindloginInfo(BLL_Default objbll)
    {
        string sql = "";
        sql = " select * from " + objcon.schemaName + "LS_Importer_Login a," + objcon.schemaName + "LS_SubscriptionIMP b where a.ImporterID=b.ImporterID AND ImporterLoginID ='" + objbll.Userid.Replace("'", "''") + "' and ImporterPassword=substring(substring('" + objbll.pwd + "',9," + objbll.pwd.Length + "),1," + Convert.ToString(objbll.pwd.Length - 16) + ") ";
        sql = sql + " and (getdate() between SubscriptionDate and ExpiryDate) ";
        DataSet ds = objcon.ExecuteDataSet(sql);
        return ds;
    }


    public int CreateImporterAccount(BLL_Default objbll)
    {
        int i = 0;
        string ImpID;
        string year = DateTime.Today.Year.ToString();
        string sql = "";
        sql = "select * from " + objcon.schemaName + "LS_Importer_Login Where ImporterLoginID = '" + objbll.ImporterLoginID + "' ";
        DataTable dt = objcon.ExecuteDataTable(sql);
        if (dt.Rows.Count == 0)
        {

            sql = "";
            sql = "select max(cast(ImporterID as int))+1 as impID from " + objcon.schemaName + "LS_Importer_Login ";


            DataSet ds = objcon.ExecuteDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ImpID = ds.Tables[0].Rows[0]["impID"].ToString();
            }
            else
            {
                ImpID = "1";
            }

            sql = "";
            sql = " Insert Into " + objcon.schemaName + "LS_SubscriptionIMP(ImporterID,Report1,Report2,Report3,Report4,SubscriptionDate,ExpiryDate,ImporterActiveFlag,Subscriptionyear,Created_On,CreatedBy) values('" + ImpID + "','N','N','N','N',getdate(),'12/31/" + year + "','N','" + year + "',getdate(),'" + ImpID + "')";
            objcon.InsertUpdateCommand(sql);


            sql = "";
            sql = " INSERT INTO " + objcon.schemaName + "LS_Importer_Login ";
            sql = sql + " (ImporterID, ImporterFirstName, ImporterLastName, ImporterAddress, ImporterCity, ImporterState, ImporterCountry, ImporterZip, ImporterEmail, ";
            sql = sql + "  ImporterCompanyname, ImporterOccupation, ImporterDesig, ImporterTelePhone, ImporterMobile, ImporterTeleFax, ImporterLoginID, ImporterPassword,  ";
            sql = sql + "   Created_On, CreatedBy,InfoYourpd  ";
            sql = sql + "   ) ";
            sql = sql + "  VALUES     ( ";
            sql = sql + " '" + ImpID + "','" + objbll.ImporterFirstName + "','" + objbll.ImporterLastName + "','" + objbll.ImporterAddress + "', '" + objbll.ImporterCity + "', '', '" + objbll.ImporterCountry + "', '', '" + objbll.ImporterEmail + "', ";
            sql = sql + "  '" + objbll.ImporterCompanyname + "', '" + objbll.ImporterOccupation + "', '" + objbll.ImporterDesig + "', '" + objbll.ImporterTelePhone + "', '" + objbll.ImporterMobile + "', '" + objbll.ImporterTeleFax + "', '" + objbll.ImporterLoginID + "', substring(substring('" + objbll.ImporterPassword + "',9," + objbll.ImporterPassword.Length + "),1," + Convert.ToString(objbll.ImporterPassword.Length - 16) + "),  ";
            sql = sql + "   getdate(), '" + objbll.CreatedBy + "','"+objbll.hiddenpwd+"' ";
            sql = sql + "    ) ";

            i = objcon.InsertUpdateCommand(sql);
        }
        else
        {
            i = 2;
        }
        return i;
    }
}
