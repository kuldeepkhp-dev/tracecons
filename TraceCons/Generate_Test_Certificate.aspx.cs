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

public partial class Residue_Analysis_Generate_Test_Certificate : System.Web.UI.Page
{
    string PgName="1";
    int  k;
    int totalPesticide;
   

    public string LabCodeNO;
    Table tbl;
    
    BLL_Generate_Test_Certificate obj = new BLL_Generate_Test_Certificate();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        ViewState["LabCodeNO"] = Request.QueryString["lcn"].ToString().Trim().Replace("'","''");
        if (!IsPostBack)
        {
            BindHeader();
            
        }
        BindMRL();
    }



    #region Bind Header Details
    void BindHeader()
    {
       

        obj.lab_Code_No = ViewState["LabCodeNO"].ToString();
        obj.ProductID = Session["ProductID"].ToString();
        //obj.FinancialYear = Session["FinancialYear"].ToString();

        DataSet ds = new DataSet();
        ds = obj.Bind();


        if (ds.Tables[0].Rows.Count > 0)
        {
            imgLogo.ImageUrl = ds.Tables[0].Rows[0]["LogoLocation"].ToString();
            lblLabAddress.Text = ds.Tables[0].Rows[0]["LabAddress"].ToString();
            lblLabName.Text = ds.Tables[0].Rows[0]["LabName"].ToString();
            lblLabCity.Text = ds.Tables[0].Rows[0]["LabCity"].ToString();
            lblLabState.Text = ds.Tables[0].Rows[0]["LabState"].ToString();
            lblLabPIN.Text = "PIN : " + ds.Tables[0].Rows[0]["LabPin"].ToString();


            lblSampleType.Text = ds.Tables[0].Rows[0]["SampleTypeName"].ToString();
            lblHReportNo.Text = ds.Tables[0].Rows[0]["sample_slipl_no"].ToString(); 
            lblHreportDate.Text = ds.Tables[0].Rows[0]["CompletionAnalysis"].ToString();  
            
            lblFarmerName.Text = ds.Tables[0].Rows[0]["FarmerName"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["Farmeraddress"].ToString();
            lblExpname.Text = ds.Tables[0].Rows[0]["Exporter_name"].ToString();
            lblFarmRegno.Text = ds.Tables[0].Rows[0]["FarmRegNo"].ToString();
            lblLocation.Text = ds.Tables[0].Rows[0]["Farmeraddress"].ToString();
            lblArea.Text = ds.Tables[0].Rows[0]["Area_Per_Plot"].ToString();
            lblProduction.Text = ds.Tables[0].Rows[0]["Total_Production_MT"].ToString();
            lblVariety.Text = ds.Tables[0].Rows[0]["varietyName"].ToString();
            lblSampleDraw.Text = ds.Tables[0].Rows[0]["sampledrawDate"].ToString();
            lblSampleQty.Text = ds.Tables[0].Rows[0]["wt_sample_drawn"].ToString();
            lblSample_CodeNo.Text = ds.Tables[0].Rows[0]["sample_slipl_no"].ToString();
            lblSample_draw.Text = ds.Tables[0].Rows[0]["Person_Draw_sample"].ToString();
            lblDateofDraw.Text = ds.Tables[0].Rows[0]["sampledrawDate"].ToString();    
            lbldateofreceive.Text = ds.Tables[0].Rows[0]["sampleReceiptDate"].ToString();    
            lblDateofCompletion.Text = ds.Tables[0].Rows[0]["CompletionAnalysis"].ToString();
                       
            lblFooterPlotNo.Text = ds.Tables[0].Rows[0]["FarmRegNo"].ToString();

            lblResultDesc.Text = ds.Tables[0].Rows[0]["Result_Desc"].ToString();
            lblFooterDate.Text = ds.Tables[0].Rows[0]["CompletionAnalysis"].ToString();
            lblFooterPlace.Text = ds.Tables[0].Rows[0]["LabCity"].ToString();


        }

    }

    #endregion

    #region Report Top Header
    void PageTopheader(string Ref_no, string ReportDate, string Page_no)
    {

        HtmlGenericControl br0 = new HtmlGenericControl("br");
        PHTop.Controls.Add(br0);
        // Generate Report Header MEssage

        
        tbl = new Table();
        tbl.Width = Unit.Percentage(100);
        tbl.CellSpacing = 0;
        tbl.CellPadding = 0;
        tbl.Attributes.Add("border", "0");

        TableRow tr = new TableRow();
        tr.Style.Add("face", "Verdana");
        tr.Style.Add("size", "1");


        TableCell tc1 = new TableCell();
        tc1.CssClass = "Cert";
        tc1.HorizontalAlign = HorizontalAlign.Left;
        tc1.Text = "Test Report No. " + Ref_no.ToString();
        tc1.Font.Bold = true;
        tr.Controls.Add(tc1);

        TableCell tc2 = new TableCell();
        tc2.CssClass = "Cert";
        tc2.HorizontalAlign = HorizontalAlign.Center;
        tc2.Text = "    Report Date :" + ReportDate.ToString();
        tc2.Font.Bold = true;
        tr.Controls.Add(tc2);

        TableCell tc3 = new TableCell();
        tc3.CssClass = "Cert";
        tc3.HorizontalAlign = HorizontalAlign.Right;
        tc3.Text = "Page " + Page_no.ToString() + " of 5 ";
        tc3.Font.Bold = true;
        tr.Controls.Add(tc3);

        tbl.Controls.Add(tr);
        PHTop.Controls.Add(tbl);
        // add break
        

    }
    #endregion

    #region Report Header
    void Pageheader(string Ref_no,string ReportDate,string Page_no)
    {
     
       // add break to report

        HtmlGenericControl br1 = new HtmlGenericControl("br");
        HtmlGenericControl br2 = new HtmlGenericControl("br");
        HtmlGenericControl br3 = new HtmlGenericControl("br");
        HtmlGenericControl br4 = new HtmlGenericControl("br");
        HtmlGenericControl br5 = new HtmlGenericControl("br");
        HtmlGenericControl br6 = new HtmlGenericControl("br");
     

        PH.Controls.Add(br1);
        PH.Controls.Add(br2);
        PH.Controls.Add(br3);
        PH.Controls.Add(br4);
        PH.Controls.Add(br5);
        PH.Controls.Add(br6);
  


        // Generate Report Header MEssage



        tbl = new Table();
        tbl.Width = Unit.Percentage(100);
        tbl.CellSpacing = 0;
        tbl.CellPadding = 0;
        tbl.Attributes.Add("border", "0");

        TableRow tr = new TableRow();
        tr.Style.Add("face", "Verdana");
        tr.Style.Add("size", "1");


        TableCell tc1 = new TableCell();
        tc1.CssClass = "Cert";
        tc1.HorizontalAlign = HorizontalAlign.Left;
        tc1.Text = "Test Report No. " + Ref_no.ToString();
        tc1.Font.Bold = true;
        tr.Controls.Add(tc1);

        TableCell tc2 = new TableCell();
        tc2.CssClass = "Cert";
        tc2.HorizontalAlign = HorizontalAlign.Center;
        tc2.Text = "    Report Date :"+ReportDate.ToString();
        tc2.Font.Bold = true;
        tr.Controls.Add(tc2);

        TableCell tc3 = new TableCell();
        tc3.CssClass = "Cert";
        tc3.HorizontalAlign = HorizontalAlign.Right;
        tc3.Text = "Page " + Page_no.ToString() + " of 5 ";
        tc3.Font.Bold = true;
        tr.Controls.Add(tc3);
       
        tbl.Controls.Add(tr);
        PH.Controls.Add(tbl);
        // add break
        HtmlGenericControl br0 = new HtmlGenericControl("br");
        PH.Controls.Add(br0);

    }
    #endregion

    #region Report Footer
    void PageFooter(string Ref_no, string ReportDate, string Page_no)
    {
        

        // Generate Report Header MEssage

        tbl = new Table();
        tbl.Width = Unit.Percentage(100);
        tbl.CellSpacing = 0;
        tbl.CellPadding = 0;
        tbl.Attributes.Add("border", "0");

        TableRow tr = new TableRow();
        tr.Style.Add("face", "Verdana");
        tr.Style.Add("size", "1");


        TableCell tc1 = new TableCell();
        tc1.CssClass = "Cert";
        tc1.HorizontalAlign = HorizontalAlign.Left;
        tc1.Text = "Test Report No. " + Ref_no.ToString();
        tc1.Font.Bold = true;
        tr.Controls.Add(tc1);

        TableCell tc2 = new TableCell();
        tc2.CssClass = "Cert";
        tc2.HorizontalAlign = HorizontalAlign.Center;
        tc2.Text = "    Report Date :" + ReportDate.ToString();
        tc2.Font.Bold = true;
        tr.Controls.Add(tc2);

        TableCell tc3 = new TableCell();
        tc3.CssClass = "Cert";
        tc3.HorizontalAlign = HorizontalAlign.Right;
        tc3.Text = "Page " + Page_no.ToString() + " of 5 ";
        tc3.Font.Bold = true;
        tr.Controls.Add(tc3);

        tbl.Controls.Add(tr);
        PHFooter.Controls.Add(tbl);
        // add break
        //HtmlGenericControl br0 = new HtmlGenericControl("br");
        //PHFooter.Controls.Add(br0);
    }

    #endregion

    #region Table Header
    void CreateHeader()
    {
		tbl = new Table();

        tbl.CellSpacing = 0;
        tbl.CellPadding = 0;
        tbl.Attributes.Add("border", "1");

		tbl.Width=Unit.Percentage(100);
        TableRow tr = new TableRow();

        tr.CssClass = "row1";
        TableCell tc1 = new TableCell();
        tc1.CssClass = "Cert";
        tc1.Font.Bold = true;
        tc1.HorizontalAlign = HorizontalAlign.Center;
        tc1.Text = "Sl. No.";
        tr.Controls.Add(tc1);

        TableCell tc2 = new TableCell();
        tc2.CssClass = "Cert";
        tc2.Font.Bold = true;
        tc2.Text = " Pesticides Name";
        tc2.HorizontalAlign = HorizontalAlign.Center;
        tr.Controls.Add(tc2);

        TableCell tc3 = new TableCell();
        tc3.CssClass = "Cert";
        tc3.Font.Bold = true;
        tc3.Text = "Residue Content(mg/kg)";
        tc3.HorizontalAlign = HorizontalAlign.Center;
        tr.Controls.Add(tc3);

        TableCell tc4 = new TableCell();
        tc4.CssClass = "Cert";
        tc4.Font.Bold = true;
        tc4.Text = "Limit of Quantification(LOQ)(mg/kg)";
        tc4.HorizontalAlign = HorizontalAlign.Center;
        tr.Controls.Add(tc4);

        TableCell tc5 = new TableCell();
        tc5.CssClass = "Cert";
        tc5.Font.Bold = true;
        tc5.Text = "Equipment Used";
        tc5.HorizontalAlign = HorizontalAlign.Center;
        tr.Controls.Add(tc5);

        TableCell tc6 = new TableCell();
        tc6.CssClass = "Cert";
        tc6.Font.Bold = true;
        tc6.Text = "MRLs as per EU(mg/kg)";
        tc6.HorizontalAlign = HorizontalAlign.Center;
        tr.Controls.Add(tc6);

        //TableCell tc7 = new TableCell();
        //tc7.CssClass = "Cert";
        //tc7.Font.Bold = true;
        //tc7.Text = "MRLs as per UK(mg/kg)";
        //tc7.HorizontalAlign = HorizontalAlign.Center;
        //tr.Controls.Add(tc7);

        //TableCell tc8 = new TableCell();
        //tc8.CssClass = "Cert";
        //tc8.Font.Bold = true;
        //tc8.Text = "MRLs as per NL(mg/kg)";
        //tc8.HorizontalAlign = HorizontalAlign.Center;
        //tr.Controls.Add(tc8);

        //TableCell tc9 = new TableCell();
        //tc9.CssClass = "Cert";
        //tc9.Font.Bold = true;
        //tc9.Text = "MRLs as per Germany(mg/kg)";
        //tc9.HorizontalAlign = HorizontalAlign.Center;
        //tr.Controls.Add(tc9);

        tbl.Controls.Add(tr);
        PH.Controls.Add(tbl);
    }
    #endregion

    #region Table Cell
    void Create_TD(int i)
    {
        
        TableRow tr = new TableRow();
        tr.Style.Add("face", "Verdana");
        tr.Style.Add("size", "1");


        TableCell tc1 = new TableCell();
        tc1.HorizontalAlign = HorizontalAlign.Center;
        Label lblSl = new Label();
        lblSl.CssClass = "Cert";

        lblSl.ID = "sl" + i;
        tc1.Controls.Add(lblSl);
        tr.Controls.Add(tc1);

        TableCell tc2 = new TableCell();
        //tc2.HorizontalAlign = HorizontalAlign.Center;

        Label lblPName = new Label();
        lblPName.CssClass = "Cert";
        lblPName.ID = "Pesticide" + i;
        tc2.Controls.Add(lblPName);
        tr.Controls.Add(tc2);

        TableCell tc10 = new TableCell();
        tc10.HorizontalAlign = HorizontalAlign.Center;
        Label txtResidue = new Label();

        txtResidue.CssClass = "Cert";


        txtResidue.ID = "residue" + i;
        

        txtResidue.Width = 50;
        tc10.Controls.Add(txtResidue);

        tr.Controls.Add(tc10);


        TableCell tc3 = new TableCell();
        tc3.HorizontalAlign = HorizontalAlign.Center;
        Label txtloq = new Label();
        txtloq.CssClass = "Cert";
        txtloq.ID = "LOD" + i;
        txtloq.Width = 50;
       
        tc3.Controls.Add(txtloq);
        tr.Controls.Add(tc3);


        TableCell tc4 = new TableCell();
        tc4.HorizontalAlign = HorizontalAlign.Center;
        Label txtmoa = new Label();
        txtmoa.CssClass = "Cert";
        txtmoa.ID = "Equipment" + i;
        //txtmoa.Width=50;
     
       
        tc4.Controls.Add(txtmoa);
        tr.Controls.Add(tc4);

        TableCell tc6 = new TableCell();
        tc6.HorizontalAlign = HorizontalAlign.Center;
        Label txtRangeEU = new Label();
        txtRangeEU.CssClass = "Cert";
        txtRangeEU.ID = "Range_EU" + i;
        txtRangeEU.Width = 50;
       
        tc6.Controls.Add(txtRangeEU);
        tr.Controls.Add(tc6);

        //TableCell tc7 = new TableCell();
        //tc7.HorizontalAlign = HorizontalAlign.Center;
        //Label txtRangeuk = new Label();
        //txtRangeuk.CssClass = "Cert";
        //txtRangeuk.ID = "Range_UK" + i;
        //txtRangeuk.Width = 50;
        
        //tc7.Controls.Add(txtRangeuk);
        //tr.Controls.Add(tc7);

        //TableCell tc8 = new TableCell();
        //tc8.HorizontalAlign = HorizontalAlign.Center;
        //Label txtRangenl = new Label();
        //txtRangenl.CssClass = "Cert";
        //txtRangenl.ID = "Range_NL" + i;
        //txtRangenl.Width = 50;
       
        //tc8.Controls.Add(txtRangenl);
        //tr.Controls.Add(tc8);

        //TableCell tc9 = new TableCell();
        //tc9.HorizontalAlign = HorizontalAlign.Center;
        //Label txtRangeger = new Label();
        //txtRangeger.CssClass = "Cert";
        //txtRangeger.ID = "Range_GER" + i;
        //txtRangeger.Width = 50;
        
        //tc9.Controls.Add(txtRangeger);
        //tr.Controls.Add(tc9);

        tbl.Controls.Add(tr);
        PH.Controls.Add(tbl);
    }
    #endregion


    #region Create PGCODE

    void PGCODEValues(int j)
    {
        if (PgName == "1")
        {
            TableRow trG = new TableRow();

            TableCell tcG = new TableCell();
            Label txtRangeger = new Label();
            txtRangeger.CssClass = "Cert";
            txtRangeger.Font.Bold = true;
            txtRangeger.ID = "PGCode" + j.ToString();
            tcG.ColumnSpan = 9;
            txtRangeger.Text = ViewState["PGName"].ToString();
            tcG.Controls.Add(txtRangeger);
            trG.Controls.Add(tcG);
            tbl.Controls.Add(trG);
            PH.Controls.Add(tbl);

            PgName = ViewState["PGName"].ToString();
        }
        else
        {
            if (PgName != ViewState["PGName"].ToString())
            {
                TableRow trG = new TableRow();

                TableCell tcG = new TableCell();
                Label txtRangeger = new Label();
                txtRangeger.CssClass = "Cert";
                txtRangeger.Font.Bold = true;
                txtRangeger.ID = "PGCode" + j.ToString();
                tcG.ColumnSpan = 9;
                txtRangeger.Text = ViewState["PGName"].ToString();
                tcG.Controls.Add(txtRangeger);
                trG.Controls.Add(tcG);
                tbl.Controls.Add(trG);
                PH.Controls.Add(tbl);

                PgName = ViewState["PGName"].ToString();
            }
        }
    }
#endregion

    #region Display(j)
    void Display(int j)
    {
        //string name = ViewState["PCode"].ToString();
        

        ((Label)this.FindControl("sl" + j)).Text = ViewState["PCode"].ToString();
        ((Label)this.FindControl("Pesticide" + j)).Text = ViewState["PName"].ToString();
        ((Label)this.FindControl("residue" + j)).Text = ViewState["Residue"].ToString();
        ((Label)this.FindControl("LOD" + j)).Text = ViewState["LOD"].ToString();
        ((Label)this.FindControl("Equipment" + j)).Text = ViewState["MOA"].ToString();
        ((Label)this.FindControl("Range_EU" + j)).Text = ViewState["Range_EU"].ToString();
        //((Label)this.FindControl("Range_UK" + j)).Text = ViewState["Range_UK"].ToString();
        //((Label)this.FindControl("Range_NL" + j)).Text = ViewState["Range_NL"].ToString();
        //((Label)this.FindControl("Range_GER" + j)).Text = ViewState["Range_GER"].ToString();
        
    }
    #endregion



    #region BindMRLFromm

    void BindMRL()
    {
       
        obj.ProductID = Session["ProductID"].ToString();
        //obj.Labid = Session["LABID"].ToString();
        obj.lab_Code_No = ViewState["LabCodeNO"].ToString().Replace("'", "''");

        DataSet ds = new DataSet();
        ds = obj.BindMRL();
        if (ds.Tables[0].Rows.Count > 0)
        {
            totalPesticide = ds.Tables[0].Rows.Count;
          
            if (ds.Tables[0].Rows.Count > 0)
            {
                PageTopheader(ViewState["LabCodeNO"].ToString(), lblDateofCompletion.Text, "1");

                Pageheader(ViewState["LabCodeNO"].ToString(), lblDateofCompletion.Text, "2");
                CreateHeader();

                //string name;
                int count = 0;
                int Page_count_value = 2;
                for (k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    if (count > 35)
                    {
                       
                        PH.Controls.Add(tbl);
                                                
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("class", "break");

                        PH.Controls.Add(div);


                        
                        Page_count_value=Page_count_value+1;

                        Pageheader(ViewState["LabCodeNO"].ToString(), lblDateofCompletion.Text, Page_count_value.ToString());

                        CreateHeader();
                        count = 0;
                    }

                    count++;


                    ViewState["PGName"] = ds.Tables[0].Rows[k]["PGName"].ToString();

                    PGCODEValues(k); // PGName
                    Create_TD(k);
                    
                    ViewState["PCode"] = ds.Tables[0].Rows[k]["PCode"].ToString();
                    ViewState["PName"] = ds.Tables[0].Rows[k]["PName"].ToString();
                    ViewState["LOD"] = ds.Tables[0].Rows[k]["LOD"].ToString();
                    ViewState["Range_Lowest"] = ds.Tables[0].Rows[k]["Range_Lowest"].ToString();
                    ViewState["Range_Codex"] = "";
                    ViewState["MOA"] = ds.Tables[0].Rows[k]["MOA"].ToString();
                    ViewState["Range_EU"] = ds.Tables[0].Rows[k]["MRLEU"].ToString();
                    ViewState["Range_UK"] = ds.Tables[0].Rows[k]["MRLUK"].ToString();
                    ViewState["Range_NL"] = ds.Tables[0].Rows[k]["MRLNL"].ToString();
                    ViewState["Range_GER"] = ds.Tables[0].Rows[k]["MRLGER"].ToString();
                    ViewState["Residue"] = ds.Tables[0].Rows[k]["residue_content"].ToString();

                    //name = ViewState["PCode"].ToString();
                    Display(k);

                    if (Page_count_value==3 && count == 31)
                    {

                        PH.Controls.Add(tbl);

                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("class", "break");

                        PH.Controls.Add(div);



                        Page_count_value = Page_count_value + 1;

                        Pageheader(ViewState["LabCodeNO"].ToString(), lblDateofCompletion.Text, Page_count_value.ToString());

                        CreateHeader();
                        count = 0;
                    }

                }

                PageFooter(ViewState["LabCodeNO"].ToString(), lblDateofCompletion.Text, Convert.ToString(Page_count_value + 1));

            }
        }
        else
        {
            // sorry no Temp values
        }


    }


    #endregion



}
