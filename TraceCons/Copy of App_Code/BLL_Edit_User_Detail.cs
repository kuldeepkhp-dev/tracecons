using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Summary description for BLL_Edit_User_Detail
/// </summary>
public class BLL_Edit_User_Detail
{
    
    
    private string _UserName;
    private string _LoginName;
    private string _Password;
    private string _EmailAddress;
    private string _scanSignature;
    private string _LabID;
    private string _Usertype; 
    private string _Userid;
    private byte[] _img;

    

    #region properties

    public byte[] Image
    {
        get { return _img; }
        set { _img = value; }
    }


    public string Userid
    {
        get { return _Userid; }
        set { _Userid = value; }
    }

    public string usertype
    {
        get { return _Usertype; }
        set { _Usertype = value; }
    }

    public string labid
    {
        get
        { return _LabID; }
        set
        { _LabID = value; }
    }

    public string username
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }
    public string LoginName
    {
        get
        {
            return _LoginName;
        }
        set
        {
            _LoginName = value;
        }
    }
    public string Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }
    public string EmailAddress
    {
        get
        {
            return _EmailAddress;
        }
        set
        {
            _EmailAddress = value;
        }
    }

    public string scanSignature
    {
        get
        {
            return _scanSignature;
        }
        set
        {
            _scanSignature = value;
        }
    }


    #endregion


    public BLL_Edit_User_Detail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet DataSave()
    {
        DLL_Edit_User_Detail obj_DLL_Edit_User_Detail = new DLL_Edit_User_Detail();
        return obj_DLL_Edit_User_Detail.DataSave(this);


    }
    public DataSet EditUser()
    {
        DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        return obj.EditUser(this);
    }
    public DataSet Bindusertype()
    {
        DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        return obj.Bindusertype(this);
    }

    public int UpdateUserData()
    {
        //DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        //return obj.SaveUserData(this);
        CL_Connection obj = new CL_Connection();
        return obj.SP_UpdateLabUser(this); // get from connection file

    }

    public int UpdateUserImages()
    {
        //DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        //return obj.SaveUserData(this);
        CL_Connection obj = new CL_Connection();
        return obj.SP_UpdateLabUserDetails(this); // get from connection file

    }

    public byte[] BindImages()
    {
        DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        return obj.BindImages(this);
    }


    public DataSet CheckUser()
    {
        DLL_Edit_User_Detail obj = new DLL_Edit_User_Detail();
        return obj.CheckUser(this);
    }
    

}
