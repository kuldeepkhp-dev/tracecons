using log4net.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

public partial class Payment_ReponseYes : System.Web.UI.Page
{
    Hashtable hs = new Hashtable();
    string hashData = "";
    string secureHash = "";
    string paymentStatus = "";
    internal SortedDictionary<string, string> confirmData = new SortedDictionary<string, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageNoCache();

        if (Request.QueryString["payload"] != null && Request.QueryString["payload"] != string.Empty)
        {
			try{
            
            string encryptedPayload = Request.QueryString["payload"];

            // string decryptedPayload = Decrypt(encryptedPayload, "IX6UYFXBEYYVL4FJ", "A97PJEJ7TJSBHRG9");

            string decryptedPayload = Decrypt(encryptedPayload, "VYGV4DFZIRH5PDQX", "ZY31M82COAD5OIH0");
       
            var responseDictionary = new Dictionary<string, string>();
            foreach (string a in decryptedPayload.Split('|'))
            {
                string[] b = a.Split('=');
                responseDictionary[b[0]] = b[1];
            }

            string paymentStatus = responseDictionary["result"];
            string errorCode = responseDictionary["errorCode"];
            string amount = responseDictionary["amount"];
            string paymentMode = responseDictionary["paymentMode"];
            string OrderId = responseDictionary["udf_3"];
            string TransactionNo = responseDictionary["paymentId"];
            string transactionDate = responseDictionary["udf_1"];
            string ApplicationNo = responseDictionary["udf_2"];
            string originalString = responseDictionary["udf_2"];
            string AppNo = originalString.Replace("Garpenet/", "");

            string NewAmount = responseDictionary["udf_5"];

            Session["NewAmount"] = NewAmount;

            Session["RCMCNO"] = AppNo;

            // Now, 'replacedString' will contain '182382'

            Session["ApplicationId"] = ApplicationNo;
            Session["PaymentID"] = TransactionNo;
            Session["paymentStatus"] = paymentStatus;
            Session["order_id"] = OrderId;

            ViewState["PaymentID"] = TransactionNo;

            if (paymentStatus.ToUpper() == "ERROR")
            {
                paymentStatus = "Fail";
            }

            Session["paymentStatus"] = paymentStatus;

            InsertIntoDATABASE();
			
			}
			
	    catch (Exception exception)
        {
            Console.Write("Exception occured while connection." + exception);
        }
        }
    }


    private void SetPageNoCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
    }

    private void InsertIntoDATABASE()
    {
        string respcd = Session["PaymentID"].ToString();
        string respmsg = Session["paymentStatus"].ToString();

        string ActivFlag = respmsg == "SUCCESS" ? "Y" : "N";

        //string ModuleID = Session["Module"].ToString();

        string ModuleID = "Exp";
        string EPGTxnId = respcd;
        string RespMessage = respmsg;
        // string BGAmount = Session["BGAmount"].ToString();

        string BGAmount = Session["NewAmount"].ToString();

        // string ImpNo = Session["APP_FORM_NO"].ToString();

        string ImpNo = Session["RCMCNO"].ToString();
       

        string ApplicationNo = Session["ApplicationId"].ToString();

        string OrderId = Session["order_id"].ToString();

        string TransactionNo = respcd;

        string Status = respmsg;




        BLL_HomeImp obj = new BLL_HomeImp();
        obj.ModuleID = ModuleID;
        obj.RespMessage = RespMessage;
        obj.EPGTxnId = EPGTxnId;
        obj.BGAmount = BGAmount;
        obj.ImpNo = ImpNo;
        obj.ActivFlag = ActivFlag;
        obj.UserID = Session["RCMCNO"].ToString();

        DataSet ds = obj.UpdatePaymentResponse();

        //Session["RCMCnoGet"] = ds.ToString();


        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // Get the value from the first row of the first table and store it in the session
            object rcmcnoGetValue = ds.Tables[0].Rows[0]["Exp_name"];
            if (rcmcnoGetValue != null && rcmcnoGetValue != DBNull.Value)
            {
                Session["RCMCnoGet"] = rcmcnoGetValue.ToString();
            }
        }




        if (Session["paymentStatus"].ToString() == "SUCCESS")

        {




            UpdatePaymentDetailLog(ApplicationNo, OrderId, TransactionNo, Status);


        }
        else
        {
            UpdatePaymentDetailLog(ApplicationNo, OrderId, TransactionNo, Status);

        }


        if (!string.IsNullOrEmpty(respcd))
        {

            if (respmsg == "SUCCESS")
            {
                try
                {
                    // Response.Redirect("~/PayResponce.aspx?TrId=" + respcd + "&respmsg=" + respmsg);

                    Response.Redirect("~/HomeImp.aspx?Msg=" + respmsg);
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }

            }
            else
            {
                try
                {
                    // Response.Redirect("~/PayResponce.aspx?TrId=NA&respmsg=" + respmsg);

                    Response.Redirect("~/HomeImp.aspx?Msg=" + respmsg);
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }

            }


        }
        else
        {
            Response.Redirect("~/PayResponce.aspx?TrId=NA&respmsg=" + respmsg);
        }
    }

    public string Decrypt(string strToDecrypt, string secret, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            strToDecrypt = strToDecrypt.Replace('-', '+');
            strToDecrypt = strToDecrypt.Replace('_', '/');
            int strlen = strToDecrypt.Length;
            int pad = strlen % 4;
            if (pad > 0)
            {
                pad = 4 - pad;
            }
            string concat = new String('=', pad);
            strToDecrypt = strToDecrypt = strToDecrypt + concat;
            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(secret));
            byte[] iv = Encoding.UTF8.GetBytes(salt);
            try
            {
                using (var rijndaelManaged = new RijndaelManaged
                {
                    Key = key,
                    IV = iv,
                    Mode =

                CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                using (var memoryStream =
                new MemoryStream(Convert.FromBase64String(strToDecrypt)))
                using (var cryptoStream =
                new CryptoStream(memoryStream,
                rijndaelManaged.CreateDecryptor(key, iv),
                CryptoStreamMode.Read))
                {
                    return new StreamReader(cryptoStream).ReadToEnd();
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
    }


    void UpdatePaymentDetailLog(string AppNo, string Order_ID, string APITransaction_ID, string status)
    {

      
        BLL_HomeImp obj = new BLL_HomeImp();

        //obj.ImpNo = AppNo;
		obj.ImpNo = Session["ApplicationId"].ToString();
        obj.Module = "Grapnet";
        obj.Orderid = Order_ID;
        obj.TransId = APITransaction_ID;
        obj.Status = status;
        //obj.UserID = Session["EXP_NAME"].ToString();

        obj.UserID = Session["RCMCnoGet"].ToString();
				

        DataSet ds = obj.UpdatePaymentDetailLog();


    }




}