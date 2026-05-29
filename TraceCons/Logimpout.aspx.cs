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
using System.Collections.Generic;

public partial class Logimpout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
            Response.Redirect("Default.aspx");
        
                Session.RemoveAll();
                Session.Abandon();

                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Cookies.Clear();

                HttpCookie httpCookie;

                int iCookieCount = HttpContext.Current.Request.Cookies.Count;

                for (int i = 0; i < iCookieCount; i++)
                {

                    httpCookie = new HttpCookie(HttpContext.Current.Request.Cookies[i].Name);
                    httpCookie.Expires = DateTime.Now.AddDays(-1);
                    httpCookie.Path = HttpContext.Current.Request.Cookies[i].Path;
                    httpCookie.Domain = HttpContext.Current.Request.Cookies[i].Domain;
                    httpCookie.Values.Clear();
                    HttpContext.Current.Response.Cookies.Add(httpCookie);

                }

                ClearApplicationCache();
                Response.Redirect("default.aspx");
        
       
    }


    public void ClearApplicationCache()
    {

        List<string> keys = new List<string>();



        // retrieve application Cache enumerator

        IDictionaryEnumerator enumerator = Cache.GetEnumerator();



        // copy all keys that currently exist in Cache

        while (enumerator.MoveNext())
        {

            keys.Add(enumerator.Key.ToString());

        }



        // delete every key from cache

        for (int i = 0; i < keys.Count; i++)
        {

            Cache.Remove(keys[i]);

        }

    }
    
}
