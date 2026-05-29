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
/// Summary description for DAL_AGMARK_Generate_Certificate
/// </summary>
public class DAL_AGMARK_Generate_Certificate
{
    CL_Connection objcon = new CL_Connection();
	public DAL_AGMARK_Generate_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BindDetail(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select pm.address,ao.shipping_mark,pm.packhousename,fo.consignmentid,ac.Certificate_No, fd.aimid,ao.labid,Otherthan_Authorised_Packer, ";
        sql = sql + " Packages_Type_Identification,iecode,ao.PackhouseNo,Exp_name,Exp_email,pm.DateofExpiry,ao.lotid, ";
        sql = sql + " ac.Validity_Period, convert(char(10),ac.Date_of_Issue,103) as Date_of_Issue, ac.Digital_Signature , ";
        sql = sql + " ao.qp_grade_assigned,ac.Consignee_Destination,ac.Transport_Mode,ac.comments,ac.Certificate_No,ac.Created_by as Userid,ac.Labid as labid ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_ConsignMaster fo, " + objcon.schemaName + "LS_AG_ConsignDetails fd, " + objcon.schemaName + "LS_AG_Certificate ac,  ";
        sql = sql + " " + objcon.schemaName + "LS_AG_Insp_AO ao , " + objcon.schemaName + "LS_PackHousemaster pm ";
        sql = sql + " where fo.consignmentid = fd.consignmentid  ";
        sql = sql + " and ac.consignmentid = fo.consignmentid  ";
        sql = sql + " and ac.consignmentid = fd.consignmentid  ";
        sql = sql + " and ao.AIMID = fd.aimid  ";
        sql = sql + " and pm.PackhouseNo=ao.PackhouseNo ";
        sql = sql + " and ac.consignmentid= '"+objbll.ConsignmentID+"' ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable BindExpDetail(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select a.*,b.state_name from " + objcon.schemaName + "LS_ExporterMaster a," + objcon.schemaName + "LS_State_Master b ";
        sql = sql + " where a.state_code=b.state_code and iecode= '" + objbll.IECODE + "' ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable BindGradeDetail(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select * from " + objcon.schemaName + "LS_AG_Insp_AO ";
        sql = sql + " where aimid in(select b.aimid from " + objcon.schemaName + "LS_AG_ConsignMaster a, ";
        sql = sql + " " + objcon.schemaName + "LS_AG_ConsignDetails b where a.consignmentid= b.consignmentid ";
        sql = sql + " and  b.consignmentid='" + objbll.ConsignmentID + "') order by aimid ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable BindVareityDetail(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " Select distinct ad.aimid, cd.consignmentid,fv.varietyid,lm.farmregno,pv.VarietyName ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_AO ad, " + objcon.schemaName + "LS_AG_ConsignDetails cd, " + objcon.schemaName + "LS_Farm_Variety fv , ";
        sql = sql + " " + objcon.schemaName + "LS_ExpLot_Master LM," + objcon.schemaName + "LS_ExpConsignDetails ec," + objcon.schemaName + "LS_ProdtVMaster pv ";
        sql = sql + " where ad.aimid in (select b.aimid from " + objcon.schemaName + "LS_AG_ConsignMaster a, " + objcon.schemaName + "LS_AG_ConsignDetails b ";
        sql = sql + " where a.consignmentid= b.consignmentid and  b.consignmentid='" + objbll.ConsignmentID + "') ";
        sql = sql + " and ec.consignmentid = '"+objbll.ConsignmentID+"' ";
        sql = sql + " and lm.lotid=ec.lotid ";
        sql = sql + " and lm.farmregno=fv.farmregno ";
        sql = sql + " and fv.varietyid=pv.varietyid ";
        sql = sql + " and fv.productid=pv.productid ";
        sql = sql + " and fv.financialyear = '"+ Convert.ToString(DateTime.Now.Year - 1)+"' ";
        sql = sql + " and ad.aimid = cd.aimid ";
        sql = sql + " and lm.lotid = cd.lotid ";
        sql = sql + " order by ad.aimid ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable BindBoxDetail(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select aimid,Noofbox,cast(QtyinBox_kg  as decimal(38,2))as QtyinBox_kg,cast(Total_Qty as decimal(38,2)) as Total_Qty from " + objcon.schemaName + "LS_AG_BOXDetails ";
        sql = sql + " where aimid in(select b.aimid from " + objcon.schemaName + "LS_AG_ConsignMaster a, ";
        sql = sql + " " + objcon.schemaName + "LS_AG_ConsignDetails b where a.consignmentid= b.consignmentid ";
        sql = sql + " and  b.consignmentid='" + objbll.ConsignmentID + "') order by aimid ";

        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetLabDetails(BLL_AGMARK_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select *  ";
        sql = sql + " from " + objcon.schemaName + "LS_Laboratory_Master a, " + objcon.schemaName + "LS_LaboratoryUMaster b, ";
        sql = sql + " " + objcon.schemaName + "LS_Lab_UsrTypeMaster c ";
        sql = sql + " where a.labid=b.labid and  ";
        sql = sql + " b.Userid='"+objbll.Userid+"' and b.Labid='"+objbll.Labid+"' ";
        sql = sql + " and b.UserTypeID=c.UserTypeID ";
             

        return objcon.ExecuteDataTable(sql);
    }

    
}
