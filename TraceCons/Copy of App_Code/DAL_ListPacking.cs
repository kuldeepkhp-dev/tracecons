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
/// Summary description for DAL_ListPacking
/// </summary>
public class DAL_ListPacking
{
    CL_Connection objcon = new CL_Connection();
	public DAL_ListPacking()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Find_IECode
    public DataTable Find_IECode(BLL_ListPacking objBLL)
    {
        objcon = new CL_Connection();
        string sql = "select * from " + objcon.schemaName + "LS_ExporterMaster where rcmcno='" + objBLL.AppFormNo + "'";
        return objcon.ExecuteDataTable(sql);
    }
    #endregion


    #region Bind_Detail
    public DataTable BindLotDetail(BLL_ListPacking objBLL)
    {
        objcon = new CL_Connection();
        string sql = " select a.LotID,a.iecode,a.financialyear,a.farmregno, b.lab_code_no,b.qty_adjusted as qty,c.result_desc ";
        sql = sql + " from " + objcon.schemaName + "LS_ExpLot_Master a," + objcon.schemaName + "LS_ExpLot_Details b," + objcon.schemaName + "LS_Lab_PrdTestMaster c where a.iecode='" + objBLL.IECode + "'";
        sql = sql + " and a.LotID=b.LotID and a.financialyear='"+objBLL.FinancialYear+"' and ";
        sql = sql + " cancellation_flag='N' and a.LotID not in( select LotID from " + objcon.schemaName + "LS_ExpBoxDetails) and c.lab_code_no=b.lab_code_no and a.ProductId='"+objBLL.ProductID+"'";
        return objcon.ExecuteDataTable(sql);
    }
    #endregion

    public DataTable BindLotDetailOf_A_Lot(BLL_ListPacking objBLL)
    {
        objcon = new CL_Connection();
        string sql = " select a.LotID,a.iecode,a.financialyear,a.farmregno, b.lab_code_no,b.qty_adjusted as qty,c.result_desc ";
        sql = sql + " from " + objcon.schemaName + "LS_ExpLot_Master a," + objcon.schemaName + "LS_ExpLot_Details b," + objcon.schemaName + "LS_Lab_PrdTestMaster c where ";
        sql = sql + " a.LotID=b.LotID and a.financialyear='" + objBLL.FinancialYear + "' and a.LotID='" + objBLL.LotID + "' and ";
        sql = sql + " cancellation_flag='N' and c.lab_code_no=b.lab_code_no ";
        return objcon.ExecuteDataTable(sql);
    }


    #region Delete_Detail
    public int DeleteLotDetail(BLL_ListPacking objBLL)
    {
        objcon = new CL_Connection();
        int i = 0;

        string sql = " Update " + objcon.schemaName + "LS_ExpLot_Master set cancellation_Flag ='Y',Cancelled_On =getdate(),Cancelled_by='" + objBLL.User + "' Where Lotid='" + objBLL.LotID + "'";
        i =  objcon.InsertUpdateCommand(sql);
        return i;
    }
    #endregion
}
