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
/// Summary description for BLL_Search_PSC_Issuedexp
/// </summary>
public class BLL_Search_PSC_Issuedexp
{
    private string _iecode, _psccert, _aimid, _cagid,_productid,_lotid,_fin;

    public string FinancialYear
    {
        set { _fin = value; }
        get { return _fin; }
    }
    public string LotID
    {
        set { _lotid = value; }
        get { return _lotid; }
    }
    public string ProductID
    {
        set { _productid = value; }
        get { return _productid; }
    }
    public string CAGID
    {
        set { _cagid = value; }
        get { return _cagid; }
    }
    public string AIMID
    {
        set { _aimid = value; }
        get { return _aimid; }
    }
    public string ConsignmentID
    {
        set { _psccert = value; }
        get { return _psccert; }
    }
    public string IECODE
    {
        set { _iecode = value; }
        get { return _iecode; }
    }

	public BLL_Search_PSC_Issuedexp()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAIMID()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.GetAIMID(this);
    }
    public DataTable GetAIMIDDetail()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.GetAIMIDDetail(this);
    }
    public DataTable GetConsignmentID()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.GetConsignmentID(this);
    }

    public DataTable CountryWiseDetailPscCertificate()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.CountryWiseDetailPscCertificate(this);
    }
    public DataTable TracePscCertificate()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.TracePscCertificate(this);
    }

    
    public DataTable GetCertificateDetailList()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.GetCertificateDetailList(this);
    }

    public DataTable GetCertificateDetail()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.GetCertificateDetail(this);
    }

    public DataTable BindBoxDetail()
    {
        DAL_Search_PSC_Issuedexp objdal = new DAL_Search_PSC_Issuedexp();
        return objdal.BindBoxDetail(this);
    }

}
