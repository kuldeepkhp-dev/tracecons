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
/// Summary description for BLL_SecurityCheck
/// </summary>
public class BLL_SecurityCheck
{
    private string _SecCode;
    private string _UserID;
    private string _RCMCNo;

    public string UserID
    {
        set { _UserID = value; }
        get { return _UserID; }
    }
    public string RcmcNo
    {
        set { _RCMCNo = value; }
        get { return _RCMCNo; }
    }
    public string SecurityCode
    {
        set { _SecCode = value; }
        get { return _SecCode; }
    }

	public BLL_SecurityCheck()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable CheckSecurityCode()
    {
        DAL_SecurityCheck objdal = new DAL_SecurityCheck();
        return objdal.GetSecurityCode(this);
    }

    public DataTable GetSecurityCodeOnLoad()
    {
        DAL_SecurityCheck objdal = new DAL_SecurityCheck();
        return objdal.GetSecurityCodeOnLoad(this);
    }

    public int UpdateSecurityCode()
    {
        DAL_SecurityCheck objdal = new DAL_SecurityCheck();
        return objdal.UpdateSecurityCode(this);
    }

    public DataTable GetEmailID()
    {
        DAL_SecurityCheck objdal = new DAL_SecurityCheck();
        return objdal.GetEmailID(this);
    }
}
