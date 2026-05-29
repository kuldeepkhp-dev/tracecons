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
/// Summary description for DAL_PSC_Generate_Certificate
/// </summary>
public class DAL_PSC_Generate_Certificate
{
    CL_Connection objcon = new CL_Connection();
	public DAL_PSC_Generate_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetExporter(BLL_PSC_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select fd.ConsignmentID, ao.aoid,ao.iecode,ao.country_code, em.exp_name, ao.exp_email, ";
        sql = sql + " ph.packhousename,ph.address,ao.packhouseno, ";
        sql = sql + " em.exp_address,em.pin,sm.state_name ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_ConsignDetails fd, " + objcon.schemaName + "LS_AG_Insp_AO ao , ";
        sql = sql + " " + objcon.schemaName + "LS_PackHousemaster ph ," + objcon.schemaName + "LS_ExporterMaster em , ";
        sql = sql + " " + objcon.schemaName + "LS_State_Master sm ";
        sql = sql + " where fd.aimid = ao.aimid ";
        sql = sql + " and ao.iecode = em.iecode  ";
        sql = sql + " and sm.state_code=em.state_code ";
        sql = sql + " and ph.packhouseid = ao.packhouseid "; 
        sql = sql + " and fd.ConsignmentID= '"+objbll.ConsignmentID+"' ";
        sql = sql + " group by fd.ConsignmentID, ao.aoid,ao.iecode,ao.country_code, em.exp_name, ao.exp_email, ";
        sql = sql + " ph.packhousename,ph.address,ao.packhouseno, ";
        sql = sql + " em.exp_address,em.pin,sm.state_name ";

        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetImporter(BLL_PSC_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select * from " + objcon.schemaName + "LS_ExpApplyPSCCert ";
        sql = sql + " where  iecode='"+objbll.IECODE+"' ";
        sql = sql + " and ConsignmentID='"+objbll.ConsignmentID+"' ";
        //sql = sql + " and year(created_on)=year(getdate()) ";

        return objcon.ExecuteDataTable(sql);
    }

    public DataTable GetCertificate(BLL_PSC_Generate_Certificate objbll)
    {
        string sql = "";
        sql = sql + " select ac.ConsignmentID, ac.Otherthan_Authorised_Packer, ac.CAG_EmailID, ";
        sql = sql + " ac.Consignee_Destination, ac.Transport_Mode, ";
        sql = sql + " ac.Packages_Type_Identification, ac.Product_Name_Variety, ";
        sql = sql + " ac.Comments, ac.Certificate_No, ac.Validity_Period, ";
        sql = sql + " ac.Date_of_Issue, ac.PSCID , ";
        sql = sql + " pc.ConsignmentID, pc.PSCID, pc.Country_To_Export, pc.E_Regn_No, ";
        sql = sql + " pc.Declared_Portof_Entry,pc.Container_No, ";
        sql = sql + " pc.Distinguising_Marks,pc.Botanical_Name, ";
        sql = sql + " pc.Quantity_Declared, convert(char(10),pc.Treatment_Date,103) as Treatment_Date , ";
        sql = sql + " pc.Treatment,pc.Pest_Controller_PPA, pc.Packages_Type_Identification , ";
        sql = sql + " pc.Chemical_Ingrediants,pc.Duration_Temperature, ";
        sql = sql + " pc.Concentration,pc.Additional_Information, ";
        sql = sql + " pc.Additional_Declaration,pc.Certificate_No as PCertificateNo, ";
        sql = sql + " convert(char(10),pc.Date_of_Issue,103) as Psc_Certificate_Date,  ";
        sql = sql + " convert(char(10),pc.Created_On,103) as Date_Created, ";
        sql = sql + " po.PSCID, pl.Code_No, po.district_name, pl.Name,pl.Designation, ";
        sql = sql + " po.address ";
        sql = sql + " from " + objcon.schemaName + "LS_AG_Certificate ac , " + objcon.schemaName + "LS_PSC_Certificate pc, " + objcon.schemaName + "LS_PSC_Logon pl ," + objcon.schemaName + "LS_PSC_Office po ";
        sql = sql + " where ac.ConsignmentID = pc.ConsignmentID ";
        sql = sql + " and ac.pscid=pc.pscid ";
        sql = sql + " and po.pscid=  pc.pscid ";
        sql = sql + " AND PO.PSCID=PL.PSCID and pl.psc_userID = pc.psc_userID ";
        sql = sql + " and pc.ConsignmentID ='"+objbll.ConsignmentID+"'";
        return objcon.ExecuteDataTable(sql);
    }



}
