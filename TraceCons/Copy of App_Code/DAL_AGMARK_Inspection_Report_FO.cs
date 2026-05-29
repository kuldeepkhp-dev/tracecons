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
/// Summary description for DAL_AGMARK_Inspection_Report_FO
/// </summary>
public class DAL_AGMARK_Inspection_Report_FO
{
    CL_Connection objcon = new CL_Connection();
	public DAL_AGMARK_Inspection_Report_FO()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable BindReport(BLL_AGMARK_Inspection_Report_FO objbll)
    {
        string sql = "";
        sql = sql + " select a.lotid,a.labid,a.Created_by as Userid,b.name,b.Designation,(isnull(b.address1,'')+ isnull(b.address2,'')+ isnull(b.address3,'')) as addressAgmark, ";
        sql = sql + " b.State,b.Pin,b.Telephone,'FRESH GRAPES' as commodityName,c.PackHousename,a.aimid,c.address as addressPackhouse, ";
        sql = sql + " c.PackhouseNo,Convert(char(10),dateofExpiry,103) as PackHouseValidityDate,a.Shipping_Mark, ";
        sql = sql + " a.Exp_name,a.Exp_email,qp_Cleanliness,qp_Soundness,qp_Foreign_Matter,qp_Pests,qp_General_Apperance, ";
        sql = sql + " qp_Damage_Caused_by_Pests_Disease,qp_Abnormal_Moisture,qp_Foreign_Smell,qp_Damage_Temperature_High_Low, ";
        sql = sql + " qp_Visible_Trace,qp_Condition_berries,qp_Berri_Size,qp_Total_Soluble_Solids,qp_Sugar_Acid_Ratio, ";
        sql = sql + " qp_Defects_in_Shape,qp_Defects_in_Color,qp_Defects_in_Skin,qp_Bruising,qp_Skin_Defects,qp_Size, ";
        sql = sql + " qp_Percentage_Grade_Tolerance,qp_Brightness,qp_Handling_Conditions,qp_Remarks,qp_Grade_Assigned, ";
        sql = sql + " qp_Recomended_Grading,qp_Recomended_Grading_Remarks,qp_OfficerName,qp_Designation,Date_of_Inspection,convert(char(10), created_on,103) as created_on ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_FO a," + objcon.schemaName + "LS_AG_Master  b," + objcon.schemaName + "LS_PackHousemaster c ";
        sql = sql + " where a.aoid=b.aoid and a.PackHouseID=c.PackHouseID and ";
        sql = sql + " Cancellation_Flag='N' and a.aimid=" + objbll.AIMID;
        return objcon.ExecuteDataTable(sql);
    }


    public DataTable BindBoxes(BLL_AGMARK_Inspection_Report_FO objbll)
    {
        string sql = "";
        sql = sql + " select * ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_BOXDetails ";
        sql = sql + " where aimid=" + objbll.AIMID;
        return objcon.ExecuteDataTable(sql);
    }


    public DataTable BindReportLO(BLL_AGMARK_Inspection_Report_FO objbll)
    {
        string sql = "";
        sql = sql + " select a.lotid,a.labid,a.UserID as LOUserid,d.Created_By as FOUserid, b.name,b.Designation,(isnull(b.address1,'')+ isnull(b.address2,'')+ isnull(b.address3,'')) as addressAgmark, ";
        sql = sql + " b.State,b.Pin,b.Telephone,'FRESH GRAPES' as commodityName,c.PackHousename,a.aimid,c.address as addressPackhouse, ";
        sql = sql + " c.PackhouseNo,Convert(char(10),dateofExpiry,103) as PackHouseValidityDate,a.Shipping_Mark, ";
        sql = sql + " a.Exp_name,a.Exp_email,a.qp_Cleanliness,a.qp_Soundness,a.qp_Foreign_Matter,a.qp_Pests,a.qp_General_Apperance, ";
        sql = sql + " a.qp_Damage_Caused_by_Pests_Disease,a.qp_Abnormal_Moisture,a.qp_Foreign_Smell,a.qp_Damage_Temperature_High_Low, ";
        sql = sql + " a.qp_Visible_Trace,a.qp_Condition_berries,a.qp_Berri_Size,a.qp_Total_Soluble_Solids,a.qp_Sugar_Acid_Ratio, ";
        sql = sql + " a.qp_Defects_in_Shape,a.qp_Defects_in_Color,a.qp_Defects_in_Skin,a.qp_Bruising,a.qp_Skin_Defects,a.qp_Size, ";
        sql = sql + " a.qp_Percentage_Grade_Tolerance,a.qp_Brightness,a.qp_Handling_Conditions,a.qp_Remarks,a.qp_Grade_Assigned, ";
        sql = sql + " a.qp_Recomended_Grading,a.qp_Recomended_Grading_Remarks,a.qp_OfficerName,a.qp_Designation,a.Date_of_Inspection,convert(char(10), a.Received_on,103) as created_on ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_LO a," + objcon.schemaName + "LS_AG_Master  b," + objcon.schemaName + "LS_PackHousemaster c ";
        sql = sql + ", " + objcon.schemaName + "LS_AG_Insp_FO d ";
        sql = sql + " where a.aoid=b.aoid and a.PackHouseID=c.PackHouseID and ";
        sql = sql + " a.aimid =d.aimid ";
        sql = sql + " and a.Cancellation_Flag='N' and a.aimid=" + objbll.AIMID;
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable BindReportAO(BLL_AGMARK_Inspection_Report_FO objbll)
    {
        string sql = "";
        sql = sql + " select a.lotid,a.labid,isnull(a.UserID,0) as AOUserid,d.Created_By as FOUserid,e.UserID as LOUserid,b.name,b.Designation,(isnull(b.address1,'')+ isnull(b.address2,'')+ isnull(b.address3,'')) as addressAgmark, ";
        sql = sql + " b.State,b.Pin,b.Telephone,'FRESH GRAPES' as commodityName,c.PackHousename,a.aimid,c.address as addressPackhouse, ";
        sql = sql + " c.PackhouseNo,Convert(char(10),dateofExpiry,103) as PackHouseValidityDate,a.Shipping_Mark, ";
        sql = sql + " a.Exp_name,a.Exp_email,a.qp_Cleanliness,a.qp_Soundness,a.qp_Foreign_Matter,a.qp_Pests,a.qp_General_Apperance, ";
        sql = sql + " a.qp_Damage_Caused_by_Pests_Disease,a.qp_Abnormal_Moisture,a.qp_Foreign_Smell,a.qp_Damage_Temperature_High_Low, ";
        sql = sql + " a.qp_Visible_Trace,a.qp_Condition_berries,a.qp_Berri_Size,a.qp_Total_Soluble_Solids,a.qp_Sugar_Acid_Ratio, ";
        sql = sql + " a.qp_Defects_in_Shape,a.qp_Defects_in_Color,a.qp_Defects_in_Skin,a.qp_Bruising,a.qp_Skin_Defects,a.qp_Size, ";
        sql = sql + " a.qp_Percentage_Grade_Tolerance,a.qp_Brightness,a.qp_Handling_Conditions,a.qp_Remarks,a.qp_Grade_Assigned, ";
        sql = sql + " a.qp_Recomended_Grading,a.qp_Recomended_Grading_Remarks,a.qp_OfficerName,a.qp_Designation,a.Date_of_Inspection,convert(char(10), a.Received_on,103) as created_on,year(a.Received_On) as yr ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_AO a," + objcon.schemaName + "LS_AG_Master  b," + objcon.schemaName + "LS_PackHousemaster c ";
        sql = sql + ", " + objcon.schemaName + "LS_AG_Insp_FO d, " + objcon.schemaName + "LS_AG_Insp_LO e ";
        sql = sql + " where a.aoid=b.aoid and a.PackHouseID=c.PackHouseID and ";

        sql = sql + " a.aimid =d.aimid ";
        sql = sql + " and d.aimid =e.aimid ";

        sql = sql + " and a.Cancellation_Flag='N' and a.aimid='"+objbll.AIMID+"' " ;
        return objcon.ExecuteDataTable(sql);
    }





}
