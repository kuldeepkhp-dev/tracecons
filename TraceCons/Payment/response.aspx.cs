using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

using System.Configuration;

public partial class response : System.Web.UI.Page
{

  
    Hashtable hs = new Hashtable();
    string hashData = "";
    string secureHash = "";
    string paymentStatus = "";
    internal SortedDictionary<string, string> confirmData = new SortedDictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageNoCache();

        if (!string.IsNullOrEmpty(Request["secretkey"]))
            Session["SECRET_KEY"] = Request["secretkey"];
        else
            Session["SECRET_KEY"] = Common.GetAppConfig("SECRET_KEY", "");

        hashData = (Session["SECRET_KEY"] + "").ToString();

        NameValueCollection nameValue = (Request.QueryString.Count > 0) ? Request.QueryString : Request.Form;

        //Create sorted dictionary to sort the request query string
        //uses linq extension
        //SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>(nameValue.AllKeys.ToDictionary(k => k, k => nameValue[k]));
        //uses non linq function
        SortedDictionary<string, string> sortedDict = Common.SortNameValueCollection(nameValue);

        foreach (KeyValuePair<string, string> p in sortedDict)
        {
            if (p.Value.ToString() != null && p.Value.ToString().Length > 0 && p.Key.ToString().ToLower() != "secretkey" && p.Key.ToString() != "SecureHash" && p.Key.ToString() != "submitted" && !p.Key.ToString().ToLower().StartsWith("__"))
            {
                hashData += "|" + p.Value.ToString();
            }
        }

        if (!string.IsNullOrEmpty(hashData) && hashData.Length > 0)
        {
            secureHash = Crypto.GenerateHashString(hashData, Common.GetConfigAlgorithm("Algorithm"), Crypto.EncodingType.HEX).ToUpper();
            if (secureHash == Request["SecureHash"])
            {
                if (!string.IsNullOrEmpty(Request["ResponseCode"]))
                {
                    int ResponseCode = -1;
                    int.TryParse(Request["ResponseCode"], out ResponseCode);
                    if (ResponseCode == 0)
                    {
                        // update response and the order's payment status as SUCCESS in to database

                        //for demo purpose, its stored in session
                        paymentStatus = "SUCCESS";
                        Session["paymentResponse"] = Request;
                    }
                    else
                    {
                        paymentStatus = "FAILED";
                        Session["paymentResponse"] = Request;
                    }
                    //for demo purpose, its stored in session
                    Session["paymentStatus"] = paymentStatus;
                    Session["PaymentID"] = (Request["PaymentID"] + "").ToString();

                    // Redirect to confirm page with reference.
                    confirmData.Add("PaymentID", Request["PaymentID"]);
                    confirmData.Add("Status", paymentStatus);
                    confirmData.Add("Amount", Request["Amount"]);

                    hashData = (Session["SECRET_KEY"] + "").ToString();
                    foreach (KeyValuePair<string, string> p in confirmData)
                    {
                        if (!string.IsNullOrEmpty(p.Value) && (p.Value + "").ToString().Length > 0)
                        {
                            hashData += "|" + (p.Value + "").ToString();
                        }
                    }
                    if (hashData != null && hashData.Length > 0)
                    {
                        SecureHash.Value = Crypto.GenerateHashString(hashData, Common.GetConfigAlgorithm("Algorithm"), Crypto.EncodingType.HEX).ToUpper();
                    }

                    InsertIntoDATABASE();


                }
            }
            else
            {
                Response.Write("<h1>Error!!</h1>");
                Response.Write("<p>Hash validation failed</p>");
            }
        }
        else
        {
            Response.Write("<h1>Error!</h1>");
            Response.Write("<p>Invalid response</p>");
        }
    }

    public void SetPageNoCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
    }

    void InsertIntoDATABASE()
    {
        string respcd = Session["PaymentID"].ToString();
        string respmsg = paymentStatus.ToString(); ;

        string ActivFlag = "N";

        if (respmsg == "SUCCESS")
        {

            ActivFlag = "Y";
        }
       

        string ModuleID = Session["Module"].ToString();

        string EPGTxnId = respcd;
        string RespMessage = respmsg;
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
        if (!string.IsNullOrEmpty(respcd))
        {
            Response.Redirect("~/PayResponce.aspx?TrId=" + respcd + "&respmsg=" + respmsg);
        }
        else
        {

            Response.Redirect("~/PayResponce.aspx??TrId=NA&respmsg=" + respmsg);
        }


    }

}
