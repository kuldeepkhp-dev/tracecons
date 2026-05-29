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
/// Summary description for DLL_Edit_User_Detail
/// </summary>
public class DLL_Edit_User_Detail
{
      
    
    CL_Connection objcon = new CL_Connection();


	public DLL_Edit_User_Detail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet Bindusertype(BLL_Edit_User_Detail objBLL)
    {
        string sql = "";
        sql = "select * from " + objcon.schemaName + "LS_Lab_UsrTypeMaster order by UserTypeName desc ";
        
        DataSet ds = new DataSet();
        return ds = objcon.ExecuteDataSet(sql);
          
        
        
    }

    public DataSet CheckUser(BLL_Edit_User_Detail objBLL)
    {
        string sql = "";
        sql = "select * from " + objcon.schemaName + "LS_LaboratoryUMaster ";
        sql = sql + " where labid='"+objBLL.labid+"' ";
        sql = sql + " and Userid='"+objBLL.Userid+"' ";
        

        DataSet ds = new DataSet();
        return ds = objcon.ExecuteDataSet(sql);
    }


    public DataSet DataSave(BLL_Edit_User_Detail obj_BLL_Edit)
    {

        string sql = "";
        sql = "Select * from " + objcon.schemaName + "LS_LaboratoryUMaster ";
        sql = sql + " where LoginName = '" + obj_BLL_Edit.LoginName.ToString() + "'";
        DataSet ds = new DataSet();
        
        
               
        
        if (ds.Tables[0].Rows.Count==0) //(dt.Rows.Count == 0)
        {
            sql = "";
            sql = sql + "select max(userid)+1 As UserID from " + objcon.schemaName + "LS_LaboratoryUMaster";
            ds = new DataSet();
            ds = objcon.ExecuteDataSet(sql);
            
            int uid = 0;
            if (ds.Tables[0].Rows.Count>0)
            { 
                uid= Convert.ToInt32(ds.Tables["userid"].ToString());
            }
                
                //(dt.Rows.Count > 0)
               // uid = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            else
                uid = 1;

            //qry = "insert into " + obj_CL_Connection.schemaName + "LS_LaboratoryUMaster(Labid,Userid,UserName,LoginName,Password,EmailID,UserTypeID,PhotoSignature,ANFlag,Activate_Flag,CreatedOn,CreatedBy) ";
            //qry = qry + " values('" + obj_Bal_Add.LabID + "',";
            ////qry = qry + "'" + obj_Bal_Add.username + "'";
            //qry = qry + "'" + uid + "',";
            //qry = qry + "'" +obj_Bal_Add.username.ToString() + "',";
            ////Add 
            //qry = qry + "'" +obj_Bal_Add.LoginName.ToString() + "',";
            //qry = qry + "'" +obj_Bal_Add.Password.ToString() + "',";
            //qry = qry + "'" +obj_Bal_Add.EmailID.ToString() + "',";
            //qry = qry + "null,";
            //qry = qry + "'" +obj_Bal_Add.UserType.ToString() + "',";
            //qry = qry + "'b ',";
            //qry = qry + "'Y',";
            //qry = qry + "getdate(),";
            //qry = qry + "'administrator')";
        }
        ds = new DataSet();
        return ds = objcon.ExecuteDataSet(sql);
        
       
       

    }


    public DataSet EditUser(BLL_Edit_User_Detail obj_BLL_Edit)
    {
        string sql = "";
        sql = " select a.UserTypeID,a.username, a.loginname, a.emailID, b.userTypeName ";
        sql = sql + " from " + objcon.schemaName + "LS_LaboratoryUMaster a, " + objcon.schemaName + "LS_Lab_UsrTypeMaster b  ";
        sql = sql + " where a.usertypeID=b.usertypeID  and a.Userid='" + obj_BLL_Edit.Userid + "' ";
        sql = sql + " and labid='"+obj_BLL_Edit.labid+"' ";
        
        DataSet ds = new DataSet();
        return ds = objcon.ExecuteDataSet(sql);
        

    }


    public int SaveUserData(BLL_Edit_User_Detail obj)
    {
        //string sql = "";
        //sql = "  update " + objcon.schemaName + "LS_LaboratoryUMaster ";
        //sql = sql + " set UserName='"+obj.username+"',Password='"+obj.Password.ToString()+"', ";
        //sql = sql + "  EmailID='"+obj.EmailAddress+"',UserTypeID='"+obj.usertype+"',PhotoSignature="+obj.Image+" ";
        //sql = sql + " where Userid='"+obj.Userid+"' and labid='"+obj.labid+"' ";

        //return objcon.InsertUpdateCommand(sql);

        //return objcon.SP_UpdateLabUser(BLL_Edit_User_Detail obj);
        return 0;
    }


    public byte[] BindImages(BLL_Edit_User_Detail obj)
    {
        string sql = "";
        sql = "Select PhotoSignature from " + objcon.schemaName + "LS_LaboratoryUMaster ";
        sql = sql + "where Userid='" + obj.Userid + "' and labid='" + obj.labid + "' ";

        return objcon.Images(sql);
    }
}
