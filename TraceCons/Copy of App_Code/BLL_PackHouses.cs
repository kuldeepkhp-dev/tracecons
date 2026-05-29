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
/// Summary description for BLL_PackHouses
/// </summary>
public class BLL_PackHouses
{
    private string _packHouseCode;

    public string PackHouseCode
    {
        get { return _packHouseCode; }
        set { _packHouseCode = value; }
    }


	public BLL_PackHouses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindpackHouse()
    {
        DAL_PackHouses obj = new DAL_PackHouses();
        return obj.BindPackHouse();
    }


    public DataTable BindPackHouseDetails()
    {

        DAL_PackHouses obj = new DAL_PackHouses();
        return obj.BindPackHouseDetails(this);
    }









}
