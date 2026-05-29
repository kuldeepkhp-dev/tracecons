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
/// Summary description for DALPostPayment
/// </summary>
public class DALPostPayment
{
    CL_Connection objcon = new CL_Connection();
	public DALPostPayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable GetPayInfo(BLLPostPayment objbll)
    {
        string sql = "";
        if(objbll.Module == "IMP")
        {
            sql = " Select * from " + objcon.schemaName + "LS_SubscriptionIMP Where ImporterID ='" + objbll.UserID + "' and Subscriptionyear = year(getdate()) ";
        }
        else
        {
            sql = " Select * from " + objcon.schemaName + "LS_SubscriptionEXP Where RCMCNo ='" + objbll.UserID + "'  and Subscriptionyear = year(getdate()) ";
        }

        return objcon.ExecuteDataTable(sql);
    }
}
