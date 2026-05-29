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
/// Summary description for BLL_PlotDetails
/// </summary>
public class BLL_PlotDetails
{
    private string _Farmregno;
    private string _fiscalyear;
    private int _agencyid;

    public string Farmregno
    {
        get { return _Farmregno; }
        set { _Farmregno = value; }
    }

    public string fiscalyear
    {
        get { return _fiscalyear; }
        set { _fiscalyear = value; }
    }

    public int agencyid
    {
        get { return _agencyid; }
        set { _agencyid = value; }
    }

	public BLL_PlotDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet BindDetails()
    {
        DAL_PlotDetails obj = new DAL_PlotDetails();
        return obj.BindData(this);
    }


}
