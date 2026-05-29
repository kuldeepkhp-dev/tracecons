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
/// Summary description for BLL_AGMARK_Inspection_Report_FO
/// </summary>
public class BLL_AGMARK_Inspection_Report_FO
{
    private string _aimid;
    public string AIMID
    {
        set { _aimid = value; }
        get { return _aimid; }
    }
	public BLL_AGMARK_Inspection_Report_FO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindReport()
    {
        DAL_AGMARK_Inspection_Report_FO objdal = new DAL_AGMARK_Inspection_Report_FO();
        return objdal.BindReport(this);
    }

    public DataTable BindBoxes()
    {
        DAL_AGMARK_Inspection_Report_FO objdal = new DAL_AGMARK_Inspection_Report_FO();
        return objdal.BindBoxes(this);
    }



    public DataTable BindReportLO()
    {
        DAL_AGMARK_Inspection_Report_FO objdal = new DAL_AGMARK_Inspection_Report_FO();
        return objdal.BindReportLO(this);
    }

    public DataTable BindReportAO()
    {
        DAL_AGMARK_Inspection_Report_FO objdal = new DAL_AGMARK_Inspection_Report_FO();
        return objdal.BindReportAO(this);
    }


}
