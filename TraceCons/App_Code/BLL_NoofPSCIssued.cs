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
/// Summary description for BLL_NoofPSCIssued
/// </summary>
public class BLL_NoofPSCIssued
{
    private string _year;
    private string _cntry,_productID;


    public string year
    {
        get { return _year; }
        set { _year = value; }
    }

    public string Country
    {
        get { return _cntry; }
        set { _cntry = value; }
    }

    public string ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }




	public BLL_NoofPSCIssued()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BindPSCIssued()
    {
        DLL_NoofPSCIssued objdal = new DLL_NoofPSCIssued();
        return objdal.BindPSCIssued(this);
    }

    public DataSet ToTBindPSCIssued()
    {
        DLL_NoofPSCIssued objdal = new DLL_NoofPSCIssued();
        return objdal.ToTBindPSCIssued(this);
    }



    public DataSet ToTBindPSCIssuedDetailed()
    {
        DLL_NoofPSCIssued objdal = new DLL_NoofPSCIssued();
        return objdal.ToTBindPSCIssuedDetailed(this);
    }



}
