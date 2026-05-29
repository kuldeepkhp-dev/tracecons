using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Linq;
using System.Web.UI.HtmlControls;

public partial class _Post : System.Web.UI.Page
{
    internal string hashData = "";
    internal string secureHash = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageNoCache();

        //string HASHING_METHOD = "sha512";//md5,sha1
        payment.Action = Common.GetAppConfig("PAYMENT_URL");
        if (string.IsNullOrEmpty(Request["secretkey"]))
            Session["SECRET_KEY"] = Request["secretkey"];
        else
            Session["SECRET_KEY"] = Common.GetAppConfig("SECRET_KEY", "");

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
    #endregion
}