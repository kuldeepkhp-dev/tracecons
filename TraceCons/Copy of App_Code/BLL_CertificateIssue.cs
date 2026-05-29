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
/// Summary description for BLL_CertificateIssue
/// </summary>
public class BLL_CertificateIssue
{
    #region Property Declaration
    private string _farmregno;
    private string _Financialyear;
    private string _issudedate;
    private string _productId;
    private int _agencyid;

    #endregion


    #region property defination
    public string ProductID
    {
        get { return _productId; }
        set { _productId = value; }

    }
    public string farmregno
    {
        get { return _farmregno; }
        set { _farmregno = value; }
    }
    public string Financialyear
    {
        get { return _Financialyear; }
        set { _Financialyear = value; }
    }
    public string issudedate
    {
        get { return _issudedate; }
        set { _issudedate = value; }
    }
    public int agencyid
    {
        get { return _agencyid; }
        set { _agencyid = value; }
    }

     #endregion



    public DataSet CertiData()
    {
        DAL_CertificateIssue obj = new DAL_CertificateIssue();
        return obj.BindCertData(this);
    }
	public BLL_CertificateIssue()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
