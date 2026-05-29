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
/// Summary description for BLL_PSC_Generate_Certificate
/// </summary>
public class BLL_PSC_Generate_Certificate
{
    private string _iecode,_pscid,_codeNo,_consign;

    public string IECODE
    {
        set { _iecode = value; }
        get { return _iecode; }
    }
    public string PSCID
    {
        set { _pscid = value; }
        get { return _pscid; }
    }
    public string CodeNo
    {
        set { _codeNo = value; }
        get { return _codeNo; }
    }
    public string ConsignmentID
    {
        set { _consign = value; }
        get { return _consign; }
    }

	public BLL_PSC_Generate_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetExporter()
    {
        DAL_PSC_Generate_Certificate objdal = new DAL_PSC_Generate_Certificate();
        return objdal.GetExporter(this);
    }
    public DataTable GetImporter()
    {
        DAL_PSC_Generate_Certificate objdal = new DAL_PSC_Generate_Certificate();
        return objdal.GetImporter(this);
    }
    public DataTable GetCertificate()
    {
        DAL_PSC_Generate_Certificate objdal = new DAL_PSC_Generate_Certificate();
        return objdal.GetCertificate(this);
    }
}
