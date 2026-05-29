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
/// Summary description for BLL_ExporterConsignment
/// </summary>
public class BLL_ExporterConsignment
{
    private string _iecode;
    public string IECODE
    {
        set { _iecode = value; }
        get { return _iecode; }
    }

	public BLL_ExporterConsignment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetExporterConsignment()
    {
        DAL_ExporterConsignment objdal = new DAL_ExporterConsignment();
        return objdal.GetExporterConsignment(this);
    }
}
