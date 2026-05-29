using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SFA;

public partial class PaymentResponse : System.Web.UI.Page
{
    string respcd = "";
    string respmsg = "";
    string astrResponseData = "";
    string strMerchantId, astrFileName = "";
    string strKey = "";
    string strDigest = "";
    string astrsfaDigest = "";
    PGResponse oPgResp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
        }
    }

    public void display()
    {

        oPgResp = new PGResponse();
        EncryptionUtil lEncUtil = new EncryptionUtil();
        

       // string mypathC = Server.MapPath("Config") + "\\00001133.key";
       
       // string mypathC = "F:\\E\\APEDA-DEV\\GrapenetCurrent\\TraceConsignment\\00001133.key";

        string mypathC = " D:\\APEDA_Applications\\GrapeNet\\TraceCons\\00001133.key";
        strMerchantId = "00001133";
        astrFileName = mypathC.ToString();

        if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
        {

            astrResponseData = Request.Form["DATA"];
            strDigest = Request.Form["EncryptedData"];
            astrsfaDigest = lEncUtil.getHMAC(astrResponseData, astrFileName, strMerchantId);

            if (strDigest.Equals(astrsfaDigest))
            {
                oPgResp.getResponse(astrResponseData);
                respcd = oPgResp.RespCode;
                respmsg = oPgResp.RespMessage;
                
            }
        }

         InsertIntoDATABASE();

        

        if (oPgResp.RespCode == "1")
        {
		    Response.Write("Payment Unsuccessful- Rejected by the switch <br>");
            Response.Write("Message : " + oPgResp.RespMessage + "<br>");
            Response.Write("Transaction ID : " + oPgResp.EPGTxnId + "<br>");
            Response.End();
		    
        }
        else if (oPgResp.RespCode == "2")
            {
		         Response.Write("Payment Unsuccessful- Rejected by the Payment Gateway <br>");
                 Response.Write("Message : " + oPgResp.RespMessage + "<br>");
                 Response.Write("Transaction ID : " + oPgResp.EPGTxnId + "<br>");
                 Response.End();
    		    
            }
            else if (oPgResp.RespCode == "")
            {

                Response.Write("Payment Unsuccessful");
                Response.End();


            }
            else
            {
                Response.Redirect("postpayment.aspx?q=4");
            }

            
       

    }


    void InsertIntoDATABASE()
    {
        
        string ActivFlag ="N";

        if (oPgResp.RespCode == "1")
        {

            ActivFlag = "N";
        }
        else if (oPgResp.RespCode == "2")
        {
            ActivFlag = "N";
        }

        else if (oPgResp.RespCode == "")
        {
            ActivFlag = "N";
        }
        else
        {
            ActivFlag = "Y";
        }

        string ModuleID = Session["Module"].ToString();

        string EPGTxnId = oPgResp.EPGTxnId;
        string RespMessage = oPgResp.RespMessage;
        string BGAmount = Session["BGAmount"].ToString();
        string ImpNo = Session["APP_FORM_NO"].ToString();
        BLL_HomeImp obj = new BLL_HomeImp();
        obj.ModuleID = ModuleID;
        obj.RespMessage = RespMessage;
        obj.EPGTxnId = EPGTxnId;
        obj.BGAmount = BGAmount;
        obj.ImpNo = ImpNo;
        obj.ActivFlag = ActivFlag;

        int i = obj.UpdatePaymentResponse();

        

    }


}
