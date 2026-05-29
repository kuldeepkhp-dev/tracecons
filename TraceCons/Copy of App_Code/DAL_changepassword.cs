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
/// Summary description for DAL_changepassword
/// </summary>
public class DAL_changepassword
{

    CL_Connection obj_CL_Connection = new CL_Connection();

    
	public DAL_changepassword()
	{
        
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindPassword(BAL_changepassword objBAL_changepassword)
    {
   
        string sql;

        sql = " select ImporterPassword From  " + obj_CL_Connection.schemaName + "LS_Importer_Login ";
        sql = sql + " where ImporterID='" + objBAL_changepassword.USERID + "' ";
  
        DataSet ds ;
        return ds = obj_CL_Connection.ExecuteDataSet(sql);

    }


    public int updatePassword(BAL_changepassword objBAL_changepassword)
    {
        
        string sql;

        sql = " update " + obj_CL_Connection.schemaName + "LS_Importer_Login ";
        sql = sql + " set ImporterPassword ='" + objBAL_changepassword.newpassword.ToString() + "'";
        sql = sql + " where ImporterID='" + objBAL_changepassword.USERID + "'";

        int ds;
        return ds = obj_CL_Connection.InsertUpdateCommand(sql);


    }

}
