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
/// Summary description for BLL_Operator
/// </summary>
public class BLL_Operator
{

    #region Property

        private string _Userid;
        private string _pwd, _hiddenpwd;
        private string _ConsignmentID;
        private string _PortName,_CheckInDate,_CheckOutDate;
        private string _OPTID,_ProductID;
        
    #endregion

    #region defination of Variable
     public string ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string OPTID
        {
            get { return _OPTID; }
            set { _OPTID = value; }
        }
        public string CheckOutDate
        {
            get { return _CheckOutDate; }
            set { _CheckOutDate = value; }
        }
        public string CheckInDate
        {
            get { return _CheckInDate; }
            set { _CheckInDate = value; }
        }

        public string PortName
        {
            get { return _PortName; }
            set { _PortName = value; }
        }
    
        public string ConsignmentID
        {
            get { return _ConsignmentID; }
            set { _ConsignmentID = value; }
        }
        public string hiddenpwd
        {
            get { return _hiddenpwd; }
            set { _hiddenpwd = value; }
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
    #endregion

    public BLL_Operator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet BindLoginInfo()
    {
        DAL_Operator obj = new DAL_Operator();

        return obj.BindloginInfo(this);
    }

    public DataSet BindPSCData()
    {
        DAL_Operator obj = new DAL_Operator();

        return obj.BindPSCData(this);
    }

    public DataSet BindContainerData()
    {
        DAL_Operator obj = new DAL_Operator();

        return obj.BindContainerData(this);
    }

    public int AddData()
    {
        DAL_Operator obj = new DAL_Operator();

        return obj.AddData(this);
    }

}
