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
/// Summary description for CL_Connection
/// </summary>
public class CL_Connection
{
    public string strConn;
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;
   
    string Constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
    public string schemaName = ConfigurationManager.AppSettings["schemaName"].ToString();
    public CL_Connection()
	{
        //conn = new SqlConnection(ConvertToString(Constr));

        conn = new SqlConnection(Constr);
       	//
		// TODO: Add constructor logic here
		//
	}

    


    #region to Encript Connection string

    public void ToByteArray(string a)
    {
        string str;
        str = "user id=sa;password=sa;data source=.;initial catalog=TraceNet";
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);
        string abc = Convert.ToBase64String(bytes);
    }

    #endregion

    #region to decript Connection string
    public string ConvertToString(string Constr)
    {
        byte[] bytes = Convert.FromBase64String(Constr);
        strConn = System.Text.ASCIIEncoding.ASCII.GetString(bytes);
        return strConn;
    }
    #endregion

    #region openConnection
    private void OpenConn()
    {
        if (conn.State == ConnectionState.Closed)
            conn.Open();
    }

    #endregion

    #region EndConnection

    private void CloseConn()
    {
        if (conn.State == ConnectionState.Open)
            conn.Close();
    }
    #endregion

    # region Select Command
    public DataSet ExecuteDataSet(string query)
    {
        OpenConn();
        ds = new DataSet();
        da = new SqlDataAdapter(query,conn);
        da.Fill(ds);
        CloseConn();
        return ds;
    }

    public DataTable ExecuteDataTable(string query)
    {
        OpenConn();
        dt = new DataTable();
        da = new SqlDataAdapter(query, conn);
        da.Fill(dt);
        CloseConn();
        return dt;
    }
    #endregion

    #region Insert Update Command
    public int InsertUpdateCommand(string query)
    {
        int i;
        try
        {
            OpenConn();
            cmd = new SqlCommand(query, conn);
            i = cmd.ExecuteNonQuery();
            CloseConn();
        }
        catch(SqlException ex)
        {
            i = ex.Number;

        ////  4060-4 - could not open database
        //// 18450 - 18461 - login failed
        //// 18482,3,5 - could not connect to server
        //// 547 - foriegn key violation
        //// 2627 - Unique Index/Constraint violation
        //// 2601 - Unique Index/Constraint violation
        //// 1201 - 1223 locks
        //// 2502 - could not start transaction
        //// 2520-5 - could not find database

        }
        return i;
    }
    #endregion




    //ambarish

    #region ExecuteScaler
    public byte[] Images(string query)
    {
        byte[] imgdata ={ };
        int i;
        try
        {
            OpenConn();
            cmd = new SqlCommand(query, conn);
            //i = cmd.ExecuteNonQuery();
            imgdata = (byte[])(cmd.ExecuteScalar());
            CloseConn();
        }
        catch (SqlException ex)
        {
            i = ex.Number;
        }
        return imgdata;
    }
    #endregion

    #region Execute_SP to update user with images
    public int SP_UpdateLabUserDetails(BLL_Edit_User_Detail objbll)
    {
        SqlCommand command = new SqlCommand("APEDA.sp_UpdateUserWithImages", conn);
        command.CommandType = CommandType.StoredProcedure;
        //build params

        SqlParameter param0 = new SqlParameter("@Userid", SqlDbType.Int);
        param0.Value = int.Parse(objbll.Userid.ToString());
        command.Parameters.Add(param0);

        SqlParameter param1 = new SqlParameter("@PhotoSignature", SqlDbType.Image);
        param1.Value = objbll.Image;
        command.Parameters.Add(param1);

        //SqlParameter param2 = new SqlParameter("@UserName", SqlDbType.VarChar);
        //param2.Value = objbll.username;
        //command.Parameters.Add(param2);


        //SqlParameter param3 = new SqlParameter("@Password", SqlDbType.VarChar);
        //param3.Value = objbll.Password;
        //command.Parameters.Add(param3);


        //SqlParameter param4 = new SqlParameter("@email", SqlDbType.VarChar);
        //param4.Value = objbll.EmailAddress;
        //command.Parameters.Add(param4);

        //SqlParameter param5 = new SqlParameter("@UserTypeID", SqlDbType.VarChar);
        //param5.Value = objbll.usertype;
        //command.Parameters.Add(param5);


        SqlParameter param6 = new SqlParameter("@labid", SqlDbType.VarChar);
        param6.Value = objbll.labid;
        command.Parameters.Add(param6);


        //open connection, and execute stored procedure
        conn.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        conn.Close();
        //set the ref parameter and return value

        //return the rows affected
        return numRowsAffected;
    }
    #endregion


    #region Execute_SP to update user
    public int SP_UpdateLabUser(BLL_Edit_User_Detail objbll)
    {
        SqlCommand command = new SqlCommand("APEDA.sp_UpdateUser", conn);
        command.CommandType = CommandType.StoredProcedure;
        //build params

        SqlParameter param0 = new SqlParameter("@Userid", SqlDbType.Int);
        param0.Value = int.Parse(objbll.Userid.ToString());
        command.Parameters.Add(param0);

        //SqlParameter param1 = new SqlParameter("@PhotoSignature", SqlDbType.Image);
        //param1.Value = objbll.Image;
        //command.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("@UserName", SqlDbType.VarChar);
        param2.Value = objbll.username;
        command.Parameters.Add(param2);


        SqlParameter param3 = new SqlParameter("@Password", SqlDbType.VarChar);
        param3.Value = objbll.Password;
        command.Parameters.Add(param3);


        SqlParameter param4 = new SqlParameter("@email", SqlDbType.VarChar);
        param4.Value = objbll.EmailAddress;
        command.Parameters.Add(param4);

        SqlParameter param5 = new SqlParameter("@UserTypeID", SqlDbType.VarChar);
        param5.Value = objbll.usertype;
        command.Parameters.Add(param5);


        SqlParameter param6 = new SqlParameter("@labid", SqlDbType.VarChar);
        param6.Value = objbll.labid;
        command.Parameters.Add(param6);


        //open connection, and execute stored procedure
        conn.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        conn.Close();
        //set the ref parameter and return value

        //return the rows affected
        return numRowsAffected;
    }
    #endregion



    //#region Execute_SP to Add User
    //public int SP_AddLabUser(BAL_Add_User_Detail objbll)
    //{
    //    SqlCommand command = new SqlCommand("APEDA.sp_AddNewUserWithImages", conn);
    //    command.CommandType = CommandType.StoredProcedure;
    //    //build params

    //    SqlParameter param0 = new SqlParameter("@Userid", SqlDbType.Int);
    //    param0.Value = int.Parse(objbll.UserID.ToString());
    //    command.Parameters.Add(param0);

    //    //SqlParameter param1 = new SqlParameter("@PhotoSignature", SqlDbType.Image);
    //    //param1.Value = objbll.Image;
    //    //command.Parameters.Add(param1);

    //    SqlParameter param2 = new SqlParameter("@UserName", SqlDbType.VarChar);
    //    param2.Value = objbll.username;
    //    command.Parameters.Add(param2);


    //    SqlParameter param3 = new SqlParameter("@Password", SqlDbType.VarChar);
    //    param3.Value = objbll.Password;
    //    command.Parameters.Add(param3);


    //    SqlParameter param4 = new SqlParameter("@email", SqlDbType.VarChar);
    //    param4.Value = objbll.EmailID;
    //    command.Parameters.Add(param4);

    //    SqlParameter param5 = new SqlParameter("@UserTypeID", SqlDbType.VarChar);
    //    param5.Value = objbll.UserType;
    //    command.Parameters.Add(param5);


    //    SqlParameter param6 = new SqlParameter("@labid", SqlDbType.VarChar);
    //    param6.Value = objbll.LabID;
    //    command.Parameters.Add(param6);

    //    SqlParameter param7 = new SqlParameter("@LoginName", SqlDbType.VarChar);
    //    param7.Value = objbll.LoginName;
    //    command.Parameters.Add(param7);

    //    SqlParameter param8 = new SqlParameter("@createdby", SqlDbType.VarChar);
    //    param8.Value = objbll.CreatedBy;
    //    command.Parameters.Add(param8);

    //    SqlParameter param9 = new SqlParameter("@activ", SqlDbType.VarChar);
    //    param9.Value = "Y";
    //    command.Parameters.Add(param9);

    //    //open connection, and execute stored procedure
    //    conn.Open();
    //    int numRowsAffected = command.ExecuteNonQuery();
    //    conn.Close();
    //    //set the ref parameter and return value

    //    //return the rows affected
    //    return numRowsAffected;
    //}
    //#endregion


    


    //End

}
