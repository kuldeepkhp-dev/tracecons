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
/// Summary description for BAL_changepassword
/// </summary>
public class BAL_changepassword
{
   
    private string _UID;

    private string _newpassword;
    
    public string USERID
    {
        get
        {
            return _UID;
        }
        set
        {

            _UID = value;
        }
    }
   

    public string newpassword
    {
        get
        {
            return _newpassword;
        }
        set
        {

            _newpassword = value;
        }
    }


    public BAL_changepassword()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet PasswordChange()
    {
        DAL_changepassword objDAL_changepassword = new DAL_changepassword();
        return objDAL_changepassword.BindPassword(this);
    }

    public int updatepassword()
    {
        DAL_changepassword objDAL_changepassword = new DAL_changepassword();
        return objDAL_changepassword.updatePassword(this);
    }
}
