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
/// Summary description for BLL_HomeImp
/// </summary>
public class BLL_HomeImp
{
    private string _UserID;
    private string _Module;
    private string _ImporterLoginID;
    private char _Report1;
    private char _Report2;
    private char _Report3;
    private char _Report4;


    private string _ActivFlag;
    public string ActivFlag
    {
        get { return _ActivFlag; }
        set { _ActivFlag = value; }
    }
    private string _ModuleID;
    public string ModuleID
    {
        get { return _ModuleID; }
        set { _ModuleID = value; }
    }
    private string _EPGTxnId;
    public string EPGTxnId
    {
        get { return _EPGTxnId; }
        set { _EPGTxnId = value; }
    }
    private string _RespMessage;
    public string RespMessage
    {
        get { return _RespMessage; }
        set { _RespMessage = value; }
    }
    private string _BGAmount;
    public string BGAmount
    {
        get { return _BGAmount; }
        set { _BGAmount = value; }
    }
    private string _ImpNo;
    public string ImpNo
    {
        get { return _ImpNo; }
        set { _ImpNo = value; }
    }



    public char Report1
    {
        get { return _Report1; }
        set { _Report1 = value; }
    }

    public char Report2
    {
        get { return _Report2; }
        set { _Report2 = value; }
    }

    public char Report3
    {
        get { return _Report3; }
        set { _Report3 = value; }
    }

    public char Report4
    {
        get { return _Report4; }
        set { _Report4 = value; }
    }


    public string Module
    {
        get { return _Module; }
        set { _Module = value; }

    }
    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }

    }

    public string ImporterLoginID
    {
        get { return _ImporterLoginID; }
        set { _ImporterLoginID = value; }

    }


	public BLL_HomeImp()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindInfoIMP()
    {
        DAL_HomeImp obj = new DAL_HomeImp();
        return obj.BindInfoIMP(this);
    }

    public DataTable BindInfoEXP()
    {
        DAL_HomeImp obj = new DAL_HomeImp();
        return obj.BindInfoEXP(this);
    }

    public int InsertSubsEXP()
    {
        DAL_HomeImp obj = new DAL_HomeImp();
        return obj.InsertSubsEXP(this);
    }

    public int InsertSubsIMP()
    {
        DAL_HomeImp obj = new DAL_HomeImp();
        return obj.InsertSubsIMP(this);
    }

    public int UpdatePaymentResponse()
    {
        DAL_HomeImp obj = new DAL_HomeImp();
        return obj.UpdatePaymentResponse(this);
    }

}
