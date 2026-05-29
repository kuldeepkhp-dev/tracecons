using SFA;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Payment_PayYes : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {


        SetPageNoCache();
        //secretkey.Value = Common.GetAppConfig("SECRET_KEY", "");
        //account_id.Value = Common.GetAppConfig("ACCOUNT_ID", "");


        //secretkey.Value = "TERP00076";
        //account_id.Value = "IX6UYFXBEYYVL4FJ";

        secretkey.Value = "PERP00176";

        account_id.Value = "VYGV4DFZIRH5PDQX";


        BindExpPaymentDetails();

        CheckAndInsertPaymentDetailLog(Session["APP_FORM_NO"].ToString());


       

    }


    void BindExpPaymentDetails()
    {
        //string APP_form_no = Session["APP_FORM_NO"].ToString();
        //string exp_name = Session["EXP_NAME"].ToString();

        string Order_number = "Garpenet/" + Session["APP_FORM_NO"].ToString();
        string purchase_Amount = Session["BGAmount"].ToString();
        Session["Order_number"] = Order_number;
        int random = (int)(new Random().Next(100, 999));
        reference_no.Value = Order_number.ToString();
        amount.Value = purchase_Amount.ToString();
        description.Value = Session["description"].ToString();
       // return_url.Value = Common.GetAppConfig("PAYMENTRESPONSE", "") + "response.aspx";
	    //return_url.Value = "http://192.168.120.5/Tracecons/Payment/ReponseYes.aspx";
        lblOrderNo.Text = Order_number;
        lblAmountPayable.Text = purchase_Amount;
        name.Value = Session["EXP_NAME"].ToString();
        address.Value = Session["ADDRESS"].ToString();
        city.Value = Session["CITY"].ToString();
        state.Value = Session["STATE"].ToString();
        postal_code.Value = Session["PIN"].ToString();
        country.Value = "IND";
        email.Value = Session["EMAIL"].ToString();
        phone.Value = Session["ContactNo"].ToString();


        string iecode = Session["IECODE"].ToString();
        NameValueCollection nameValue = new NameValueCollection();
        nameValue.Add("channel", "10");

        nameValue.Add("account_id", account_id.Value);
        nameValue.Add("secretkey", secretkey.Value);
        nameValue.Add("reference_no", reference_no.Value);
        nameValue.Add("amount", amount.Value);
        nameValue.Add("currency", "INR");

        nameValue.Add("display_currency", "GBP");
        //nameValue.Add("currency_code", "GBP");
        nameValue.Add("display_currency_rates", "1");

        nameValue.Add("description", description.Value);
        nameValue.Add("return_url", return_url.Value);
        nameValue.Add("mode", "LIVE");
        //nameValue.Add("payment_mode", "");
        //nameValue.Add("card_brand", "");
        //nameValue.Add("payment_option", "");
        // nameValue.Add("bank_code", "");
        // nameValue.Add("emi", "");
        nameValue.Add("page_id", "2652");
        nameValue.Add("name", name.Value);
        nameValue.Add("address", address.Value);
        nameValue.Add("city", city.Value);
        nameValue.Add("state", state.Value);
        nameValue.Add("postal_code", postal_code.Value);
        nameValue.Add("country", "IND");
        nameValue.Add("email", email.Value);
        nameValue.Add("phone", phone.Value);
        nameValue.Add("ship_name", "");
        nameValue.Add("ship_address", "");
        nameValue.Add("ship_city", "");
        nameValue.Add("ship_state", "");
        nameValue.Add("ship_postal_code", "");
        nameValue.Add("ship_country", "IND");
        nameValue.Add("ship_phone", "");

        Session["nameValueCollection"] = nameValue;


    }



    public void SetPageNoCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
    }




    void CheckAndInsertPaymentDetailLog(string ApplicationNo)
          {
        string ApplicationId = "Garpenet/" + Session["APP_FORM_NO"].ToString();


        BLL_HomeImp obj = new BLL_HomeImp();

        obj.ImpNo = "Garpenet/" + Session["APP_FORM_NO"].ToString();

        DataTable dataTable = obj.CheckAndInsertPayment();


        if (dataTable.Rows.Count > 0)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (CheckPaymentStatus(row["OrderId"].ToString()) == true)
                {
                    

                }
                else
                {
                    
                }
            }

            InsertPaymentDetailLog(ApplicationId, Session["BGAmount"].ToString());
        }

        else
        {
            InsertPaymentDetailLog(ApplicationId, Session["BGAmount"].ToString());
        }







    }


    bool CheckPaymentStatus(string ApplicationNo)
    {
        String decryptedPayload = "";
        bool Status = false;
        try
        {

            string OrderId_New = ApplicationNo;
            string order_status = "";

            Session["applicationno"] = ApplicationNo;

            string parameter = "merchantReferenceNumber=" + ApplicationNo + "|";


           // string payload = Encrypt(parameter, "IX6UYFXBEYYVL4FJ", "A97PJEJ7TJSBHRG9");

            string payload = Encrypt(parameter, "VYGV4DFZIRH5PDQX", "ZY31M82COAD5OIH0");

            string queryUrl = "https://www.eduqfix.com/erp/integration/verify";


            // string authQueryUrlParam = "merchantId=TERP00076&type=PIPE_SEPARATED&schemeCode=TERP00076_S1&encPayload=" + payload + "";

            string authQueryUrlParam = "merchantId=PERP00176&type=PIPE_SEPARATED&schemeCode=PERP00176_S1&encPayload=" + payload + "";

            String message = postPaymentRequestToGateway(queryUrl, authQueryUrlParam);



            NameValueCollection param = getResponseMap(message);
            String status = "";
            String RefNo = "";
            String encPayloadResp = "";
            String TrnsId = "";


            if (param != null && param.Count == 2)
            {
                for (int i = 0; i < param.Count; i++)
                {

                    if ("encPayload".Equals(param.Keys[i]))
                    {
                        encPayloadResp = param[i];

                    }
                }
                if (encPayloadResp != null && encPayloadResp != "")
                {
                   // decryptedPayload = Decrypt(encPayloadResp, "IX6UYFXBEYYVL4FJ", "A97PJEJ7TJSBHRG9");

                    decryptedPayload = Decrypt(encPayloadResp, "VYGV4DFZIRH5PDQX", "ZY31M82COAD5OIH0");


                    string[] ArrResString = decryptedPayload.Split('|');

                    if (ArrResString.Length >= 3) // Ensure there are at least three elements
                    {
                        order_status = ArrResString[1];
                        TrnsId = ArrResString[2];

                        // Split the key-value pairs
                        string[] splitStrStatus = order_status.Split('=');
                        string[] splitTrnsId = TrnsId.Split('=');

                        // Check if the split arrays have the expected structure
                        if (splitStrStatus.Length == 2 && splitTrnsId.Length == 2)
                        {
                            status = splitStrStatus[1];
                            TrnsId = splitTrnsId[1];

                            Session["TrnsId"] = TrnsId;
                            Session["paymentStatus"] = status;

                            // Now 'status' and 'TrnsId' contain the extracted values
                        }
                        else
                        {
                            // Handle the case where the split arrays don't have the expected structure
                            // Print an error message or log the issue
                        }
                    }
                    else
                    {
                        // Handle the case where there are not enough elements in ArrResString
                        // Print an error message or log the issue
                    }


                    if (status == "404")
                    {
                        Status = false;

                        //status = "No Record Found!";
                        //UpdatePaymentDetailLog(Session["ApplicationId"].ToString(), OrderId_New, RefNo, status, RefNo);
                        // status = "";
                        // RefNo = "";
                    }
                    else
                    {
                        string order_bank_ref_no = ArrResString[2];
                        string[] splitRefNo = order_bank_ref_no.Split('=');
                        RefNo = splitRefNo[1];

                        if (status.ToUpper() == "SUCCESS")
                        {
                            //  order_status = "Success";

                            Status = true;

                            UpdatePaymentDetailLog(ApplicationNo, OrderId_New, RefNo, status, RefNo);
                            //UpdateStatus(RefNo, status);

                        }
                        else
                        {
                            Status = false;

                            UpdatePaymentDetailLog(ApplicationNo, OrderId_New, RefNo, status, RefNo);
                        }
                    }

                    if(Status==true)
                    {
                        string respcd = Session["TrnsId"].ToString();
                        string respmsg = Session["paymentStatus"].ToString();

                        Response.Redirect("~/PayResponce.aspx?TrId=" + respcd + "&respmsg=" + respmsg);


                    }
                }
            }
        }
        catch (Exception ex)
        {
            Status = false;
            //Response.Write(decryptedPayload);

        }


        return Status;
    }

    public string Encrypt(string strToEncrypt, string secret, string salt)
    {
        string encrypted = null;
        using (var sha256 = SHA256.Create())
        {
            byte[] Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(secret));
            byte[] IV = Encoding.UTF8.GetBytes(salt);
            RijndaelManaged rj = new RijndaelManaged();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;
            rj.Padding = PaddingMode.PKCS7;
            try
            {
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(strToEncrypt);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);
                encrypted = encrypted.Replace('+', '-');
                encrypted = encrypted.Replace('/', '_');
                encrypted = encrypted.TrimEnd('=');
                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
        }
        return encrypted;
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


    private string postPaymentRequestToGateway(String queryUrl, String urlParam)
    {
        String message = "";
        try
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = 9999;
            StreamWriter myWriter = null;// it will open a http connection with provided url
            WebRequest objRequest = WebRequest.Create(queryUrl);//send data using objxmlhttp object
            objRequest.Method = "POST";
            //objRequest.ContentLength = TranRequest.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";//to set content type
            myWriter = new System.IO.StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(urlParam);//send data
            myWriter.Close();//closed the myWriter object

            // Getting Response
            System.Net.HttpWebResponse objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();//receive the responce from objxmlhttp object 
            using (System.IO.StreamReader sr = new System.IO.StreamReader(objResponse.GetResponseStream()))
            {
                message = sr.ReadToEnd();
                //Response.Write(message);
            }
        }
        catch (Exception exception)
        {
            Console.Write("Exception occured while connection." + exception);
        }
        return message;

    }
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
        // If the certificate is a valid, signed certificate, return true.
        if (error == System.Net.Security.SslPolicyErrors.None)
        {
            return true;
        }

        Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
            cert.Subject,
            error.ToString());

        return false;
    }
    private NameValueCollection getResponseMap(String message)
    {
        NameValueCollection Params = new NameValueCollection();
        if (message != null || !"".Equals(message))
        {
            string[] segments = message.Split('|');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }
        }
        return Params;
    }



    void InsertPaymentDetailLog(string ApplicationNo, string amount)
    {


        BLL_HomeImp obj = new BLL_HomeImp();

        obj.ImpNo = ApplicationNo;
        obj.Module = "Garpenet";
        obj.BGAmount= amount;
        obj.UserID = Session["EXP_NAME"].ToString();
        DataSet ds = obj.InsertPaymentDetailLog();


        if (ds.Tables.Count > 0)
        {
           // Session["OrderId_New"] = ds.Tables[0].Rows[0]["OrderID"].ToString();

            string orderid = ds.Tables[0].Rows[0]["OrderID"].ToString();

            Session["OrderId_New"] = orderid;

            BindExpPaymentDetails();




        }

    }

    void UpdatePaymentDetailLog(string AppNo, string Order_ID, string APITransaction_ID, string status, string Transaction_ID)
    {


        BLL_HomeImp obj = new BLL_HomeImp();
        obj.ImpNo = AppNo;
        obj.Module = "Grapnet";
        obj.Orderid = Order_ID;
        obj.TransId = APITransaction_ID;
        obj.Status = status;
        obj.UserID= Session["EXP_NAME"].ToString();





    }


}