using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Linq;

public partial class comfirm : System.Web.UI.Page
{
    internal string hashData = "";
    internal string secureHash = "";
    internal string paymentStatus = "";
    internal HttpRequest req = null;
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
        SortedDictionary<string, string> sortedDict = Common.SortNameValueCollection(nameValue);

        foreach (KeyValuePair<string, string> p in sortedDict)
        {
            if (p.Value.ToString() != null && p.Value.ToString().Length > 0 && p.Key.ToString() != "secretkey" && p.Key.ToString().ToLower() != "securehash" && p.Key.ToString() != "submitted" && !p.Key.ToString().ToLower().StartsWith("__"))
            {
                hashData += "|" + p.Value.ToString();
            }
        }
        if (!string.IsNullOrEmpty(hashData) && hashData.Length > 0)
        {
            secureHash = Crypto.GenerateHashString(hashData, Common.GetConfigAlgorithm("Algorithm"), Crypto.EncodingType.HEX).ToUpper();
            if (secureHash != Request["SecureHash"])
            {
                Response.Write("<h1>Error!!</h1>");
                Response.Write("<p>Hash validation failed</p>");
            }
            else
            {
                req = (HttpRequest)Session["paymentResponse"];
                //$response = $_SESSION['paymentResponse'][$_REQUEST['PaymentID']];
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
}