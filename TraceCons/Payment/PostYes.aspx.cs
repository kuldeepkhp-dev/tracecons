using SFA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment_PostYes : System.Web.UI.Page
{
    internal string hashData = "";
    internal string secureHash = "";

    protected void Page_Load(object sender, EventArgs e)
    {


        SetPageNoCache();

        //string HASHING_METHOD = "sha512";//md5,sha1
        //payment.Action = Common.GetAppConfig("PAYMENT_URL");


        string Order_number = "Garpenet/" + Session["APP_FORM_NO"].ToString();
        //string Order_number = "122205454yt54";
        string purchase_Amount = Session["BGAmount"].ToString();
        Session["Order_number"] = Order_number;
        //int random = (int)(new Random().Next(100, 999));
        //string reference_no = random.ToString();
        //string amount = purchase_Amount.ToString();
        string amount = "10";
        string transactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");


        string name = Session["EXP_NAME"].ToString();

        string filteredName = RemoveSpecialCharacters(name);

        string Module = Session["Module"].ToString();
        string address = Session["ADDRESS"].ToString();
        string city = Session["CITY"].ToString();
        string state = Session["STATE"].ToString();
        string postal_code = Session["PIN"].ToString();
        string country = "IND";
        string email = Session["EMAIL"].ToString();
        string phone = Session["ContactNo"].ToString();
        string RecordId = Session["OrderId_New"].ToString();

        string reference_no = RecordId;



        string parameter = "merchant_unique_reference_number=" + reference_no + "|amount=" + amount + "|date=" + transactionDate + "|currency_code=INR|" +
            "customer_name=" + filteredName + "|customer_email=" + email + "|customer_number=" + phone + "|customer_address=" + address + "|" +
            "customer_city=" + city + "|customer_state=" + state + "|customer_country=" + country + "|customer_pincode=" + postal_code + "|return_url_code=|" +
            "udf_1=" + transactionDate + "|udf_2=" + Order_number + "|udf_3=" + RecordId.ToString() + "|udf_4=" + Module + "|udf_5=" + purchase_Amount.ToString() + "| udf_6=|udf_7=|udf_8=|udf_9=|udf_10=|" +

        //"return_url= http://192.168.120.15/tracecons/Payment/ReponseYes.aspx";

        "return_url=http://192.168.120.5/tracecons/Payment/ReponseYes.aspx";

        //string payload = Encrypt(parameter, "IX6UYFXBEYYVL4FJ", "A97PJEJ7TJSBHRG9");

        string payload = Encrypt(parameter, "VYGV4DFZIRH5PDQX", "ZY31M82COAD5OIH0");


        // string url = "https://www.eduqfix.com/checkout/integration/payment?merchantId=TERP00076&command=INITIATE&schemeCode=TERP00076_S1&payload=" + payload;

        string url = "https://www.eduqfix.com/checkout/integration/payment?merchantId=PERP00176&command=INITIATE&schemeCode=PERP00176_S1&payload=" + payload;

        HttpContext.Current.Response.Redirect(url, false);


        if (string.IsNullOrEmpty(Request["secretkey"]))
            Session["SECRET_KEY"] = Request["secretkey"];
        else
            //Session["SECRET_KEY"] = Common.GetAppConfig("SECRET_KEY", "");

            //Session["SECRET_KEY"] = "IX6UYFXBEYYVL4FJ";

            Session["SECRET_KEY"] = "VYGV4DFZIRH5PDQX";

        hashData = (Session["SECRET_KEY"] + "").ToString();

        //        NameValueCollection nameValue = (Request.Form.Count > 0) ? Request.Form : Request.QueryString;

        NameValueCollection nameValue = (NameValueCollection)Session["nameValueCollection"];

        //Create sorted dictionary to sort the request query string
        //uses linq extension
        //SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>(nameValue.AllKeys.ToDictionary(k => k, k => nameValue[k]));
        //uses non linq function
        SortedDictionary<string, string> sortedDict = Common.SortNameValueCollection(nameValue);

        foreach (KeyValuePair<string, string> p in sortedDict)
        {
            if (p.Value.ToString() != null && p.Value.ToString().Length > 0 && p.Key.ToString().ToLower() != "secretkey" && p.Key.ToString() != "submitted" && !p.Key.ToString().ToLower().StartsWith("__"))
            {
                hashData += "|" + p.Value.ToString();
            }
        }
        if (hashData != null && hashData.Length > 0)
        {
            secure_hash.Value = secureHash = Crypto.GenerateHashString(hashData, Common.GetConfigAlgorithm("Algorithm"), Crypto.EncodingType.HEX).ToUpper();
        }

        //Response.Write(hashData);
        //Response.End();

    }



    public void SetPageNoCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
    }

    #region Disable ViewState
    protected override void SavePageStateToPersistenceMedium(object viewState)
    {
    }

    protected override object LoadPageStateFromPersistenceMedium()
    {
        return null;
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

    static string RemoveSpecialCharacters(string input)
    {
        string pattern = "[^a-zA-Z0-9]";
        string replacement = "";

        Regex regex = new Regex(pattern);
        string result = regex.Replace(input, replacement);

        return result;
    }
    #endregion
}