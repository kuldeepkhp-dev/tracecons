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
/// Summary description for BLL_ListPacking
/// </summary>
public class BLL_ListPacking
{
    private string _iecode, _appFormno,_lotid,_user,_productID;
    private int _finyear;

    public string ProductID
    {
        set { _productID = value; }
        get { return _productID; }
    }
    public string User
    {
        set { _user = value; }
        get { return _user; }
    }
    public string LotID
    {
        set { _lotid = value; }
        get { return _lotid; }
    }
    public int FinancialYear
    {
        set { _finyear = value; }
        get { return _finyear; }
    }

    public string IECode
    {
        set { _iecode = value; }
        get { return _iecode; }
    }


    public string AppFormNo
    {
        set { _appFormno = value; }
        get { return _appFormno; }
    }

	public BLL_ListPacking()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable Find_IECode()
    {
        DAL_ListPacking objdal = new DAL_ListPacking();
        return objdal.Find_IECode(this);
    }

    public DataTable BindLotDetail()
    {
        DAL_ListPacking objdal = new DAL_ListPacking();
        return objdal.BindLotDetail(this);
    }

    public DataTable BindLotDetailOf_A_Lot()
    {
        DAL_ListPacking objdal = new DAL_ListPacking();
        return objdal.BindLotDetailOf_A_Lot(this);
    }

    public int DeleteLotDetail()
    {
        DAL_ListPacking objdal = new DAL_ListPacking();
        return objdal.DeleteLotDetail(this);
    }
}
