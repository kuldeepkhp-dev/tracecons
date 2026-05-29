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
/// Summary description for BLL_Generate_Test_Certificate
/// </summary>
public class BLL_Generate_Test_Certificate
{

    private string _ProductID;
    private string _FinancialYear;
    private string _lab_Code_No;
    private string _labid;

    public string Labid
    {
        get { return _labid; }
        set { _labid = value; }
    }
    public string ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }
    public string FinancialYear
    {
        get { return _FinancialYear; }
        set { _FinancialYear = value; }
    }
    public string  lab_Code_No
    {
        get { return _lab_Code_No; }
        set { _lab_Code_No = value; }
    }



	public BLL_Generate_Test_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet Bind()
    {
        DAL_Generate_Test_Certificate obj = new DAL_Generate_Test_Certificate();
        return obj.Bind(this);
    
    }
    public DataSet BindMRL()
    {
        DAL_Generate_Test_Certificate obj = new DAL_Generate_Test_Certificate();
        return obj.BindMRLValues(this);
    }

}
