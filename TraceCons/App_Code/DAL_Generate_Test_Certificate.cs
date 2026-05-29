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
/// Summary description for DAL_Generate_Test_Certificate
/// </summary>
public class DAL_Generate_Test_Certificate
{

    CL_Connection objcon = new CL_Connection();
	public DAL_Generate_Test_Certificate()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public DataSet Bind(BLL_Generate_Test_Certificate objBLL)
    {
        string sql = "";

        sql = sql + " select a.FarmerName,a.Farmeraddress,f.Exporter_name,b.FarmRegNo,b.Area_Per_Plot,j.Total_Production_MT, ";
             sql = sql + " d.varietyName,convert(char(10),e.Sample_Drawl_date,103) as sampledrawDate,e.wt_sample_drawn,";
             sql = sql + " e.sample_slipl_no,e.Person_Draw_sample,convert(char(10),f.Sample_Receipt_date,103) as sampleReceiptDate, ";
             sql = sql + " convert(char(10),h.TestEndingDate,103) as CompletionAnalysis,g.LabName,g.LabAddress,g.LogoLocation,g.labCity,g.LabState,g.LABPIN,i.SampleTypeName,h.Result_Desc ";

             sql = sql + " from " + objcon.schemaName + "LS_FarmerDetail a," + objcon.schemaName + "LS_FarmRegDetail b ";
             sql = sql + " ," + objcon.schemaName + "LS_Farm_Variety c," + objcon.schemaName + "LS_ProdtVMaster d," + objcon.schemaName + "LS_Laboratory_Sample e," + objcon.schemaName + "LS_Laboratory_Receiv f ";
             sql = sql + " ," + objcon.schemaName + "LS_Laboratory_Master g," + objcon.schemaName + "LS_Lab_PrdTestMaster h," + objcon.schemaName + "LS_LabSampleTMaster i," + objcon.schemaName + "LS_Lab_Test_Payment j ";

             sql = sql + " where a.FarmerID=b.FarmerID and b.FarmRegNo=c.FarmRegNo  ";
             sql = sql + " and c.Varietyid =d.Varietyid and d.ProductID=b.ProductID and b.FarmRegNo=e.FarmRegNo ";
             sql = sql + " and e.FinancialYear= b.FinancialYear";
             sql = sql + " and e.SampleTypeID=i.SampleTypeID and e.sample_slipl_no=f.sample_slipl_no and ";
             sql = sql + " f.lab_Code_No='" + objBLL.lab_Code_No+ "' and e.labid=g.labid and f.lab_Code_No=h.lab_Code_No ";
             sql = sql + " and j.lab_Code_no=f.lab_Code_No and h.lab_Code_No =j.lab_Code_no ";


             DataSet ds = new DataSet();
             return ds = objcon.ExecuteDataSet(sql);


            
  
    
    }



    public DataSet BindMRLValues(BLL_Generate_Test_Certificate objbll)
    {
        int i = 0, k = 0;
        string sql = "", sql1 = "";

        DataSet ds1 = new DataSet();
        ds1 = null;

        //-- Find Country for MRL values order wise

        sql = "select Country_Code ";
        sql = sql + "FROM " + objcon.schemaName + "LS_PestCountryMaster";
        sql = sql + " where ProductID='" + objbll.ProductID.ToString() + "'";
        sql = sql + " order by DisplayOrder ";

        DataSet ds = new DataSet();
        ds = objcon.ExecuteDataSet(sql);
        int j = ds.Tables[0].Rows.Count;
        string[] ArrayCountry = new string[j];

        if (ds.Tables[0].Rows.Count > 0)
        {
            //i = ds.Tables[0].Rows.Count;
            while (i <= ds.Tables[0].Rows.Count - 1)
            {
                ArrayCountry[i] = ds.Tables[0].Rows[i]["Country_Code"].ToString();
                i++;
            }


            // === Bind all MRL values details Country wise

            sql1 = " select d.PGName,b.pcode,b.Pname,b.LOD  ";

            for (k = 0; k <= ArrayCountry.Length - 1; k++)
            {
                sql1 = sql1 + " ,Max(case when c.Country_Code='" + ArrayCountry.GetValue(k).ToString() + "' then isnull(c.MRLValueMgPerKg,'#') end ) as MRL" + ArrayCountry.GetValue(k).ToString();

            }

            sql1 = sql1 + " ,b.MOA,b.MRLValueEntered as residue_content,c.range_Lowest ";
            sql1 = sql1 + " from " + objcon.schemaName + "LS_Lab_PrdTestMaster a," + objcon.schemaName + "LS_Lab_PRDTestdetails b," + objcon.schemaName + "LS_PrdPesticide_Details c ," + objcon.schemaName + "LS_Lab_PesticideGroup d ";
            sql1 = sql1 + " where a.lab_Code_no='" + objbll.lab_Code_No.ToString().Trim() + "' ";
            sql1 = sql1 + " and a.TID=b.TID and b.Pcode = c.pcode "; 
            sql1 = sql1 + " and d.PGCode =c.PGCode and c.Productid=d.ProductID AND c.ProductID='" + objbll.ProductID.ToString() + "' ";
            sql1 = sql1 + "  group by b.PCode,b.PName,b.LOD,b.MOA,b.MRLValueEntered,c.range_Lowest,d.PGName ";
            sql1 = sql1 + " order by b.PCode ";

            ds1 = objcon.ExecuteDataSet(sql1);


        }




        //countryall = ArrayCountry;
        return ds1;

    }







}
