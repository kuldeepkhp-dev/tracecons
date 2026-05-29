using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageNoCache();
        secretkey.Value = Common.GetAppConfig("SECRET_KEY", "");
        account_id.Value = Common.GetAppConfig("ACCOUNT_ID", "");

	BindExpPaymentDetails();

    }

    public void SetPageNoCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
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
       return_url.Value = Common.GetAppConfig("PAYMENTRESPONSE", "") + "response.aspx";
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
}