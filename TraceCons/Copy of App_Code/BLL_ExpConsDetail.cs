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
/// Summary description for BLL_ExpConsDetail
/// </summary>
public class BLL_ExpConsDetail
{
    private string _impName, _country,_iecode;

    public string ImporterName
    {
        set { _impName = value; }
        get { return _impName; }
    }

    public string ImportCountry
    {
        set { _country = value; }
        get { return _country; }
    }

    public string IECODE
    {
        set { _iecode = value; }
        get { return _iecode; }
    }

	public BLL_ExpConsDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindDetailCons()
    {
        DAL_ExpConsDetail objdal = new DAL_ExpConsDetail();
        return objdal.BindDetail(this);
    }
}
