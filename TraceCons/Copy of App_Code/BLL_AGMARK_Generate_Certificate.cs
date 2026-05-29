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
/// Summary description for BLL_AGMARK_Generate_Certificate
/// </summary>
public class BLL_AGMARK_Generate_Certificate
{
    private string _consignmentid;
    private string _iecode;
    private string _aimid;

    private string _labid,_userid;

    public string Labid
    {
        set { _labid = value; }
        get { return _labid; }
    }
    public string Userid
    {
        set { _userid = value; }
        get { return _userid; }
    }
    public string AIMID
    {
        set { _aimid = value; }
        get { return _aimid; }
    }
    public string IECODE
    {
        set { _iecode = value; }
        get { return _iecode; }
    }
    public string ConsignmentID
    {
        set { _consignmentid = value; }
        get { return _consignmentid; }
    }
	public BLL_AGMARK_Generate_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindDetail()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.BindDetail(this);
    }

    public DataTable BindExpDetail()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.BindExpDetail(this);
    }

    public DataTable BindVareityDetail()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.BindVareityDetail(this);
    }
    public DataTable BindGradeDetail()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.BindGradeDetail(this);
    }
    public DataTable BindBoxDetail()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.BindBoxDetail(this);
    }

    public DataTable GetLabDetails()
    {
        DAL_AGMARK_Generate_Certificate objdal = new DAL_AGMARK_Generate_Certificate();
        return objdal.GetLabDetails(this);
    }
}
