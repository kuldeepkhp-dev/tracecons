using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Exporter_Payment_PSC_Generate_Certificate : System.Web.UI.Page
{
    BLL_PSC_Generate_Certificate objbll = new BLL_PSC_Generate_Certificate();
    DataTable dtExp, dtImp, dtCert;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {

            objbll.ConsignmentID = Request.QueryString["cagid"].ToString();
            dtExp = objbll.GetExporter();
            objbll.IECODE = dtExp.Rows[0]["iecode"].ToString();
            dtImp = objbll.GetImporter();
            dtCert = objbll.GetCertificate();
            lblAdditionalDec.Text = dtCert.Rows[0]["Additional_Declaration"].ToString();
            lblAdditionalInfo.Text = dtCert.Rows[0]["Additional_Information"].ToString();
            lblAddress.Text = dtCert.Rows[0]["address"].ToString();
            lblCertificateNo.Text = dtCert.Rows[0]["PCertificateNo"].ToString();
            lblChemical.Text = dtCert.Rows[0]["Chemical_Ingrediants"].ToString();
            lblCodeNo.Text = dtCert.Rows[0]["Code_No"].ToString();
            lblConcentration.Text = dtCert.Rows[0]["Concentration"].ToString();
            lblContainerNo.Text = dtCert.Rows[0]["Container_No"].ToString();
            lblDesignation.Text = dtCert.Rows[0]["Designation"].ToString();
            lblDistinguishMark.Text = dtCert.Rows[0]["Distinguising_Marks"].ToString();
            lblDurationTemp.Text = dtCert.Rows[0]["Duration_Temperature"].ToString();
            lblE_RegnNo.Text = dtCert.Rows[0]["E_Regn_No"].ToString();
            lblExpAddress.Text = dtExp.Rows[0]["exp_address"].ToString();
            lblExpName.Text = dtExp.Rows[0]["exp_name"].ToString();
            lblImpAddress.Text = dtImp.Rows[0]["Importer_Address"].ToString();
            lblImpCountry.Text = dtCert.Rows[0]["Country_To_Export"].ToString();
            lblImpName.Text = dtImp.Rows[0]["Importer_Name"].ToString();
            lblLocation.Text = dtCert.Rows[0]["district_name"].ToString();
            lblLocation1.Text = dtCert.Rows[0]["district_name"].ToString();
            lblModeOfShipment.Text = dtCert.Rows[0]["Transport_Mode"].ToString();
            lblName.Text = dtCert.Rows[0]["name"].ToString();
            lblPackageTypeIdentification.Text = dtCert.Rows[0]["Packages_Type_Identification"].ToString();
            lblPIN.Text = dtExp.Rows[0]["pin"].ToString();
            lblPortofEntry.Text = dtCert.Rows[0]["Declared_Portof_Entry"].ToString();
            lblPSCCertificateDate.Text = dtCert.Rows[0]["Psc_Certificate_Date"].ToString();
            lblQuuntity.Text = dtCert.Rows[0]["Quantity_Declared"].ToString();
            lblState.Text = dtExp.Rows[0]["state_name"].ToString();
            lblTreatment.Text = dtCert.Rows[0]["Treatment"].ToString();
            lblTreatmentDate.Text = dtCert.Rows[0]["Treatment_Date"].ToString();
        }
    }
}
