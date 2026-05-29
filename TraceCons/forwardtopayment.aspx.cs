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

public partial class forwardtopayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IECODE"] != null)
            {
                SendToICICIPayment();
            }
        }
    }


    public string getRemoteAddr()
    {
        string UserIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (UserIPAddress == null)
        {
            UserIPAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        return UserIPAddress;
    }
    public string getSecureCookie(HttpRequest Request)
    {

        HttpCookie secureCookie = Request.Cookies["vsc"];
        if (secureCookie != null)
        {
            return secureCookie.ToString();
        }
        else
        {
            return "";
        }


    }

    public void SendToICICIPayment()
    {
        PGResponse objPGResponse = new PGResponse();
        CustomerDetails oCustomer = new CustomerDetails();
        SessionDetail oSession = new SessionDetail();
        AirLineTransaction oAirLine = new AirLineTransaction();
        MerchanDise oMerchanDise = new MerchanDise();

        SFA.CardInfo objCardInfo = new SFA.CardInfo();

        SFA.Merchant objMerchant = new SFA.Merchant();

        ShipToAddress objShipToAddress = new ShipToAddress();
        BillToAddress oBillToAddress = new BillToAddress();
        ShipToAddress oShipToAddress = new ShipToAddress();
        MPIData objMPI = new MPIData();
        PGReserveData oPGreservData = new PGReserveData();
        Address oHomeAddress = new Address();
        Address oOfficeAddress = new Address();
        // For getting unique MerchantTxnID 
        // Only for testing purpose. 
        // In actual scenario the merchant has to pass his transactionID
        DateTime oldTime = new DateTime(1970, 01, 01, 00, 00, 00);
        DateTime currentTime = DateTime.Now;
        TimeSpan structTimespan = currentTime - oldTime;
        string lMrtTxnID = ((long)structTimespan.TotalMilliseconds).ToString();
              
       string iecode = Session["IECODE"].ToString();
       string APP_form_no = Session["APP_FORM_NO"].ToString();
       string exp_name = Session["EXP_NAME"].ToString();
       string Invoice_number = "APEDA/INV/" + Session["APP_FORM_NO"].ToString();

       string Response_url = "http://traceability.apeda.gov.in/grapenet/tracecons/PaymentResponse.aspx";

       string Order_number = "APEDA/ORD/" + Session["APP_FORM_NO"].ToString();
       string purchase_Amount = Session["BGAmount"].ToString();
       string Address =  Session["ADDRESS"].ToString();
       string exp_add1 = iecode;
       string exp_add2 = "IMPORTER";
       string exp_add3 = "IMPORTER";
       string exp_City = Session["CITY"].ToString();
       string exp_state =  Session["STATE"].ToString();
       string exp_pin = "111111";
       string exp_email = Session["IMPEMAIL"].ToString();
        

       
        //Setting Merchant Details
       objMerchant.setMerchantDetails("00001133", "00001133", "00001133", "", lMrtTxnID, Order_number, Response_url, "POST", "INR", Invoice_number, "req.Preauthorization", purchase_Amount, "GMT+05:30", iecode, "true", "PWD", APP_form_no, exp_name);

        // Setting BillToAddress Details
       oBillToAddress.setAddressDetails(APP_form_no, exp_name, exp_add1, exp_add2, exp_add3, exp_City, exp_state, exp_pin, "IND", exp_email);

        // Setting ShipToAddress Details
       oShipToAddress.setAddressDetails(exp_add1, exp_add2, exp_add3, exp_City, exp_state, exp_pin, "IND", exp_email);

        //Setting MPI datails.
        string Amount =string.Concat("INR",purchase_Amount.ToString());
        
        objMPI.setMPIRequestDetails(purchase_Amount, Amount, "356", "2", "RCMC", "", "", "", "0", "", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*", "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)");

        //  SFAClient objSFAClient=new SFAClient("F:\\E\\APEDA-DEV\\GrapenetCurrent\\TraceConsignment\\Config\\");;

        SFAClient objSFAClient=new SFAClient("D:\\APEDA_Applications\\GrapeNet\\TraceCons\\Config\\");
       
        //string mypath = Server.MapPath("Config") + "\\";
        //SFAClient objSFAClient = new SFAClient(mypath);

         ////// objPGResponse = objSFAClient.postSSL(objMPI, objMerchant, oBillToAddress, oShipToAddress, oPGreservData, oCustomer, oSession, oAirLine, oMerchanDise);

        objPGResponse = objSFAClient.postSSL(objMPI, objMerchant, oBillToAddress, oShipToAddress, null, null, oSession, null, null);

        if (objPGResponse.RedirectionUrl != "" & objPGResponse.RedirectionUrl != null)
        {
            string strResponseURL = objPGResponse.RedirectionUrl;
            Response.Redirect(strResponseURL);
        }
        else
        {
            //ErrorMessagePayment.aspx
           // Response.Write("Response Code:" + objPGResponse.RespCode);
           // Response.Write("Response message:" + objPGResponse.RespMessage);
            Response.Redirect("ErrorMessagePayment.aspx?Code=" + objPGResponse.RespCode + "&message=" + objPGResponse.RespMessage);
        }


        //responselbl.Text=response;

    }
}
