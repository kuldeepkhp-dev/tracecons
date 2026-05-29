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
/// Summary description for BLL_Default
/// </summary>
public class BLL_Default
{
    #region Declare property
    private string _ImporterID;
    private string _ImporterFirstName;
    private string _ImporterLastName;
    private string _ImporterAddress;
    private string _ImporterCity;
    private string _ImporterState;
    private string _ImporterCountry;
    private string _ImporterZip;
    private string _ImporterEmail;
    private string _ImporterCompanyname;
    private string _ImporterOccupation;
    private string _ImporterDesig;
    private string _ImporterTelePhone;
    private string _ImporterMobile;
    private string _ImporterTeleFax;
    private string _ImporterLoginID;
    private string _ImporterPassword;
    private string _ImporterSubscriptionDate;
    private string _ImporterSubscriptionyear;
    private string _ImporterSubscriptionAmount;
    private string _ImporterActiveFlag;
    private string _Created_On;
    private string _CreatedBy;
    private string _Updated_on;
    private string _ImporterTransactionID;

    private string _Userid;

    private string _pwd,_hiddenpwd;
    private string _rcmc;
    private string _ImporterExpiryDate;



    #endregion

    #region defination of Variable

    public string hiddenpwd
    {
        get { return _hiddenpwd; }
        set { _hiddenpwd = value; }
    }



    public string ImporterExpiryDate
    {
        get { return _ImporterExpiryDate; }
        set { _ImporterExpiryDate = value; }
    }

    public string RCMCNo
    {
        get { return _rcmc; }
        set { _rcmc = value; }
    }

    public string Userid
    {
        get { return _Userid; }
        set { _Userid = value; }
    }

    public string pwd
    {
        get { return _pwd; }
        set { _pwd = value; }
    }




    public string ImporterTransactionID
    {
        get { return _ImporterTransactionID; }
        set { _ImporterTransactionID = value; }
    }

    public string Updated_on
    {
        get { return _Updated_on; }
        set { _Updated_on = value; }
    }
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    public string ImporterActiveFlag
    {
        get { return _ImporterActiveFlag; }
        set { _ImporterActiveFlag = value; }
    }
    public string ImporterSubscriptionAmount
    {
        get { return _ImporterSubscriptionAmount; }
        set { _ImporterSubscriptionAmount = value; }
    }

    public string ImporterSubscriptionyear
    {
        get { return _ImporterSubscriptionyear; }
        set { _ImporterSubscriptionyear = value; }
    }
    public string ImporterSubscriptionDate
    {
        get { return _ImporterSubscriptionDate; }
        set { _ImporterSubscriptionDate = value; }
    }
    public string ImporterPassword
    {
        get { return _ImporterPassword; }
        set { _ImporterPassword = value; }
    }
    public string ImporterLoginID
    {
        get { return _ImporterLoginID; }
        set { _ImporterLoginID = value; }
    }
    public string ImporterTeleFax
    {
        get { return _ImporterTeleFax; }
        set { _ImporterTeleFax = value; }
    }

    public string ImporterMobile
    {
        get { return _ImporterMobile; }
        set { _ImporterMobile = value; }
    }
    public string ImporterTelePhone
    {
        get { return _ImporterTelePhone; }
        set { _ImporterTelePhone = value; }
    }
    public string ImporterDesig
    {
        get { return _ImporterDesig; }
        set { _ImporterDesig = value; }
    }
    public string ImporterOccupation
    {
        get { return _ImporterOccupation; }
        set { _ImporterOccupation = value; }
    }
    public string ImporterCompanyname
    {
        get { return _ImporterCompanyname; }
        set { _ImporterCompanyname = value; }
    }
    public string ImporterEmail
    {
        get { return _ImporterEmail; }
        set { _ImporterEmail = value; }
    }
    public string ImporterZip
    {
        get { return _ImporterZip; }
        set { _ImporterZip = value; }
    }
    public string ImporterCountry
    {
        get { return _ImporterCountry; }
        set { _ImporterCountry = value; }
    }
    public string ImporterState
    {
        get { return _ImporterState; }
        set { _ImporterState = value; }
    }
    public string ImporterCity
    {
        get { return _ImporterCity; }
        set { _ImporterCity = value; }
    }

    public string ImporterAddress
    {
        get { return _ImporterAddress; }
        set { _ImporterAddress = value; }
    }
    public string ImporterLastName
    {
        get { return _ImporterLastName; }
        set { _ImporterLastName = value; }
    }
    public string ImporterFirstName
    {
        get { return _ImporterFirstName; }
        set { _ImporterFirstName = value; }
    }
    public string ImporterID
    {
        get { return _ImporterID; }
        set { _ImporterID = value; }
    }

    #endregion

    public BLL_Default()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertImporterInfo()
    {
        DAL_Default objdal = new DAL_Default();
        return objdal.CreateImporterAccount(this);
    }


    public DataSet BindLoginInfo()
    {
        DAL_Default obj = new DAL_Default();

        return obj.BindloginInfo(this);
    }
    public DataSet BindLoginInfoExp()
    {
        DAL_Default obj = new DAL_Default();

        return obj.BindLoginInfoExp(this);
    }

    public DataSet BindCountry()
    {
        DAL_Default obj = new DAL_Default();
        return obj.BindCountry(this);
    }


    public DataTable GetUserPassword()
    {
        DAL_Default obj = new DAL_Default();
        return obj.GetUserPassword(this);
    }
}
