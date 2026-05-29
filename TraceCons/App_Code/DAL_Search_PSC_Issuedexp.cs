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
/// Summary description for DAL_Search_PSC_Issuedexp
/// </summary>
public class DAL_Search_PSC_Issuedexp
{
    CL_Connection objcon = new CL_Connection();
    public DAL_Search_PSC_Issuedexp()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCertificateDetail(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select distinct a.IECode,a.lotid,ls.FarmRegNo,ed.Lab_Code_no,p.certificate_no as pscCertificate, a.labid," + objbll.CAGID + " as Consignmentid,QtyInBox_MT as qty, l.labname , a.Received_on,convert(char(10),a.Received_on,103) as Foreward_Date, ";
        sql = sql + " a.aimid,a.aoid,pc.Country_name , pm.packhousename,pm.Address, ";
        sql = sql + " a.PackhouseNo, a.Exp_name,a.date_of_inspection, a.date_of_inspection, ";
        sql = sql + " convert(char(10),a.date_of_inspection,103) as InspectionDate , a.qp_grade_assigned ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_AO a , " + objcon.schemaName + "LS_Laboratory_Master l ," + objcon.schemaName + "LS_PestCountryMaster pc," + objcon.schemaName + "LS_PackHousemaster pm, " + objcon.schemaName + "LS_AG_Insp_Master IM," + objcon.schemaName + "LS_PSC_Certificate p,   ";
        sql = sql + " " + objcon.schemaName + "LS_ExpLot_Details ED , " + objcon.schemaName + "LS_Laboratory_Receiv lr, " + objcon.schemaName + "LS_Laboratory_Sample ls ";
        sql = sql + " where a.labid = l.labid ";
        sql = sql + " and pc.country_code=a.country_code ";
        sql = sql + " and pm.packhouseno=a.packhouseno and p.consignmentid = '" + objbll.CAGID + "'";
        sql = sql + " and a.aimid in (select AIMID from " + objcon.schemaName + "LS_AG_ConsignDetails where consignmentid='" + objbll.CAGID + "') ";
        sql = sql + " and a.qp_Recomended_Grading='Y' ";
        sql = sql + " and a.aimid=IM.aimid and a.lotid=ed.lotid and ed.lab_code_no=lr.lab_code_no and lr.sample_slipl_no=ls.sample_slipl_no ";
        sql = sql + " order by a.Received_on desc ";

        return objcon.ExecuteDataTable(sql);
    }
    public DataTable GetCertificateDetailList(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select distinct p.certificate_no as pscCertificate, " + objbll.CAGID + " as Consignmentid  ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_AO a , " + objcon.schemaName + "LS_Laboratory_Master l ," + objcon.schemaName + "LS_PestCountryMaster pc," + objcon.schemaName + "LS_PackHousemaster pm, " + objcon.schemaName + "LS_AG_Insp_Master IM," + objcon.schemaName + "LS_PSC_Certificate p   ";
        sql = sql + " where a.labid = l.labid ";
        sql = sql + " and pc.country_code=a.country_code ";
        sql = sql + " and pm.packhouseno=a.packhouseno and p.consignmentid = '" + objbll.CAGID + "'";
        sql = sql + " and a.aimid in (select AIMID from " + objcon.schemaName + "LS_AG_ConsignDetails where consignmentid='" + objbll.CAGID + "') ";
        sql = sql + " and a.qp_Recomended_Grading='Y' ";
        sql = sql + " and a.aimid=IM.aimid ";


        return objcon.ExecuteDataTable(sql);
    }

    public DataTable CountryWiseDetailPscCertificate(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";

        sql = sql + " select distinct p.Container_No,p.certificate_no as pscCertificate,p.date_of_issue as date_of_issue_psc, fo.ConsignmentID, am.labid, am.AOID, am.Country_code, ";
        sql = sql + " pcm.country_name,phm.packhousename, phm.Address,  am.PackhouseNo, ";
        sql = sql + " am.Exp_name, ac.ConsignmentID, ac.pscid, ac.certificate_no, convert(char(10),ac.date_of_issue,103) as date_of_issue, ";
        sql = sql + " po.pscid,po.aoid ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_ConsignMaster fo,  " + objcon.schemaName + "LS_AG_ConsignDetails fd, " + objcon.schemaName + "LS_Laboratory_Master lm, ";
        sql = sql + " " + objcon.schemaName + "LS_AG_Insp_AO am, " + objcon.schemaName + "LS_AG_Certificate ac, " + objcon.schemaName + "LS_PSC_Certificate p, " + objcon.schemaName + "LS_PestCountryMaster pcm, ";
        sql = sql + " " + objcon.schemaName + "LS_PackHousemaster phm,";
        sql = sql + " " + objcon.schemaName + "LS_PSC_Office po ";
        sql = sql + " where fo.ConsignmentID = ac.ConsignmentID ";
        sql = sql + " and fo.ConsignmentID = fd.ConsignmentID ";
        sql = sql + " and phm.packhouseNo = am.packhouseno ";
        sql = sql + " and am.Country_code=pcm.Country_code ";
               sql = sql + " and fo.labID=am.labID ";
        //sql = sql + " and fo.labID=lm.labID ";
        sql = sql + " and fd.aimid = am.aimid ";
        sql = sql + " and po.pscid = ac.pscid  ";
        sql = sql + " and po.aoid = am.aoid ";
        sql = sql + " and ac.certificate_issued='Y' ";
        sql = sql + " and (p.consignmentid = '" + objbll.ConsignmentID + "' or p.Container_No = '" + objbll.ConsignmentID + "')";
        sql = sql + " and fo.ConsignmentID IN ( select ConsignmentID  from " + objcon.schemaName + "LS_AG_Certificate ";
        sql = sql + " where certificate_issued='Y' ) ";
        sql = sql + " and fo.ConsignmentID =p.ConsignmentID ";
        sql = sql + " and fo.productid='" + objbll.ProductID + "'";
        //sql = sql + " and year(p.created_on)=year(getdate()) ";
        sql = sql + " order by p.date_of_issue desc ";
        return objcon.ExecuteDataTable(sql);
    }


    public DataTable TracePscCertificate(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";

        sql = sql + " select distinct p.Container_No,p.certificate_no as pscCertificate,p.date_of_issue as date_of_issue_psc, fo.ConsignmentID, am.labid, am.AOID, am.Country_code, ";
        sql = sql + " pcm.country_name,phm.packhousename, phm.Address,  am.PackhouseNo, ";
        sql = sql + " am.Exp_name, ac.ConsignmentID, ac.pscid, ac.certificate_no, convert(char(10),ac.date_of_issue,103) as date_of_issue, ";
        sql = sql + " po.pscid,po.aoid ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_ConsignMaster fo,  " + objcon.schemaName + "LS_AG_ConsignDetails fd, " + objcon.schemaName + "LS_Laboratory_Master lm, ";
        sql = sql + " " + objcon.schemaName + "LS_AG_Insp_AO am, " + objcon.schemaName + "LS_AG_Certificate ac, " + objcon.schemaName + "LS_PSC_Certificate p, " + objcon.schemaName + "LS_PestCountryMaster pcm, ";
        sql = sql + " " + objcon.schemaName + "LS_PackHousemaster phm,";
        sql = sql + " " + objcon.schemaName + "LS_PSC_Office po ";
        sql = sql + " where fo.ConsignmentID = ac.ConsignmentID ";
        sql = sql + " and fo.ConsignmentID = fd.ConsignmentID ";
        sql = sql + " and phm.packhouseNo = am.packhouseno ";
        sql = sql + " and am.Country_code=pcm.Country_code ";
        sql = sql + " and fo.labID=am.labID ";
        sql = sql + " and fo.labID=lm.labID ";
        sql = sql + " and fd.aimid = am.aimid ";
        sql = sql + " and po.pscid = ac.pscid  ";
        sql = sql + " and po.aoid = am.aoid ";
        sql = sql + " and ac.certificate_issued='Y' ";
        sql = sql + " and ((p.consignmentid = '" + objbll.CAGID + "' or p.certificate_no ='" + objbll.CAGID + "') or p.Container_No = '" + objbll.ConsignmentID + "'  )";
        sql = sql + " and fo.ConsignmentID IN ( select ConsignmentID  from " + objcon.schemaName + "LS_AG_Certificate ";
        sql = sql + " where certificate_issued='Y' ) ";
        sql = sql + " and fo.ConsignmentID =p.ConsignmentID ";
        sql = sql + " and fo.productid='" + objbll.ProductID + "'";
        //sql = sql + " and year(p.created_on)=year(getdate()) ";
        sql = sql + " order by p.date_of_issue desc ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetConsignmentID(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select distinct p.certificate_no as pscCertificate, fo.consignmentid, ac.certificate_no ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_ConsignMaster fo,  " + objcon.schemaName + "LS_AG_ConsignDetails fd, ";
        sql = sql + " " + objcon.schemaName + "LS_AG_Insp_AO am, " + objcon.schemaName + "LS_AG_Certificate ac, " + objcon.schemaName + "LS_PSC_Certificate p, ";
        sql = sql + " " + objcon.schemaName + "LS_PSC_Office po," + objcon.schemaName + "LS_Laboratory_Master lm ";
        sql = sql + " where fo.consignmentid = ac.consignmentid "; 
        sql = sql + " and fo.consignmentid = fd.consignmentid ";
        sql = sql + " and fd.aimid = am.aimid ";
        sql = sql + " and po.pscid = ac.pscid ";
        sql = sql + " and po.aoid = am.aoid ";
        sql = sql + " and fo.labid=am.labid ";
        sql = sql + " and fo.labid =lm.labid ";
        sql = sql + " and (p.consignmentid = '" + objbll.ConsignmentID + "' or p.Container_No = '" + objbll.ConsignmentID + "')";
        sql = sql + " and ac.certificate_issued='Y' ";
        sql = sql + " and fo.consignmentid IN ( select consignmentid  from " + objcon.schemaName + "LS_AG_Certificate where certificate_issued='Y' ) ";
        sql = sql + " and fo.consignmentid =p.consignmentid ";

        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetAIMID(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select AIMID from " + objcon.schemaName + "LS_AG_ConsignDetails fd where consignmentid='"+objbll.CAGID+"' ";
        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetAIMIDDetail(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select distinct a.labid, l.labname ,a.packhouseno, im.QtyInBox_MT,a.Received_on,convert(char(10),a.Received_on,103) as Foreward_Date, ";
        sql = sql + " a.aimid,a.aoid, pc.Country_name , ";
        sql = sql + " ph.packhousename, ph.Address, ";
        sql = sql + " a.PackhouseNo, a.Exp_name,a.date_of_inspection, a.date_of_inspection, ";
        sql = sql + " convert(char(10),a.date_of_inspection,103) as InspectionDate ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Insp_AO a , " + objcon.schemaName + "LS_Laboratory_Master l ," + objcon.schemaName + "LS_PackHousemaster ph," + objcon.schemaName + "LS_PestCountryMaster pc," + objcon.schemaName + "LS_AG_Insp_Master im ";
        sql = sql + " where a.labid = l.labid ";
        sql = sql + " and a.aimid in (" + objbll.AIMID + ") ";
        sql = sql + " and a.qp_Recomended_Grading='Y' ";
        sql = sql + " and pc.country_code=a.country_code ";
        sql = sql + " and a.aimid=im.aimid ";
        sql = sql + " and ph.packhouseno=a.packhouseno ";
        sql = sql + " order by a.Received_on desc ";
        return objcon.ExecuteDataTable(sql);
    }


    public DataTable BindBoxDetail(BLL_Search_PSC_Issuedexp objbll)
    {
        string sql = "";
        sql = sql + " select Noofbox,QtyinBox_kg  as QtyinBox_kg,Total_Qty as Total_Qty , d.VarietyName,e.qp_Grade_Assigned";
        sql = sql + " from " + objcon.schemaName + "LS_ExpBoxDetails  a, " + objcon.schemaName + "LS_ExpLot_Master b, " + objcon.schemaName + "LS_Farm_Variety c, " + objcon.schemaName + "LS_ProdtVMaster d," + objcon.schemaName + "LS_AG_Insp_AO e ";
        sql = sql + " where a.LotID = '" + objbll.LotID + "' and a.LotID=b.LotID and b.farmregno = c.farmregno and c.Varietyid = d.Varietyid ";
        sql = sql + " and c.productId= '" + objbll.ProductID + "' and c.productId=d.productId and c.FinancialYear='" + objbll.FinancialYear + "' and e.lotid=a.lotid";
        sql = sql + " order by BoxSNo ";

        return objcon.ExecuteDataTable(sql);
    }

}
