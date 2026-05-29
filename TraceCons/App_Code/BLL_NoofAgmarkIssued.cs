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
/// Summary description for BLL_NoofAgmarkIssued
/// </summary>
public class BLL_NoofAgmarkIssued
{
    private string _DateReq,_productID;
    public string DateReq
    {
        get { return _DateReq; }
        set { _DateReq = value; }
    }

    public string ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }
    
    public BLL_NoofAgmarkIssued()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindTotalConsignment()
    {
        DAL_NoofAgmarkIssued obj = new DAL_NoofAgmarkIssued();
        return obj.BindTotalConsignment(this);
    }
    public DataTable BindTotalQty()
    {
        DAL_NoofAgmarkIssued obj = new DAL_NoofAgmarkIssued();
        return obj.BindTotalQty(this);
    }
    public DataTable BindTotal()
    {
        DAL_NoofAgmarkIssued obj = new DAL_NoofAgmarkIssued();
        return obj.BindTotal(this);
    }

}
