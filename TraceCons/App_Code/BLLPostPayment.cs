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
/// Summary description for BLLPostPayment
/// </summary>
public class BLLPostPayment
{
    private string _Module, _userID;
    public string Module
    {
        set { _Module = value; }
        get { return _Module; }
    }

    public string UserID
    {
        set { _userID = value; }
        get { return _userID; }
    }
	public BLLPostPayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPayInfo()
    {
        DALPostPayment objdal = new DALPostPayment();
        return objdal.GetPayInfo(this);
    }
}
