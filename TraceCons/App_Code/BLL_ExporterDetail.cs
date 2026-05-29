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
/// Summary description for BLL_ExporterDetail
/// </summary>
public class BLL_ExporterDetail
{
    private string _iecode;

    public string IECODE
    {
        get { return _iecode; }
        set { _iecode = value; }
    }

	public BLL_ExporterDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindExporter()
    {

        DAL_ExporterDetail obj = new DAL_ExporterDetail();
        return obj.BindExporter(this);
    }




}
