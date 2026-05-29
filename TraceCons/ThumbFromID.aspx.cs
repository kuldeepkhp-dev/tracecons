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
using System.IO;
using System.Drawing;

public partial class ThumbFromID : System.Web.UI.Page
{
    #region Instance Fields
    // constants used to create URLs to this page
    public const String PAGE_NAME = "ThumbFromID.aspx";
    //the image primary key for use when getting image data from database
    public const String IMAGE_ID = "img_pk";
    public const String LAB_ID = "Lid";
    // height of the thumbnail created from the original image
    public static int THUMBNAIL_SIZE;
    // true if using thumbnail THUMBNAIL_SIZE for height, else it is used for width
    public static bool USE_SIZE_FOR_HEIGHT;
    #endregion

    /// <summary>
    /// Retrieves a binary array from the SQL Server database by the use of the
    /// <see dbAccess>dbAccess</see>class. Once this binary
    /// array is retrtieved from the database, it is written to a memory stream
    /// which is then written to the standard Html Response stream, this binary data represents
    /// an image from the database, which has been scaled using the fields within this class
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        byte[] imageData = null;
        System.IO.MemoryStream ms = null;
        System.Drawing.Image fullsizeImage = null;
        String imageID = null;
        string labid = null, Userid=null;

        if (!Page.IsPostBack)
        {
            try
            {
                // get the ID of the image to retrieve from the database
                imageID = Request.QueryString["IMAGE_ID"];
                labid = Request.QueryString["LAB_ID"];
                Userid = Request.QueryString["Userid"];
     
                BLL_Edit_User_Detail obj = new BLL_Edit_User_Detail();
                obj.labid = labid;
                obj.Userid = Userid;
                byte[] imgdata = (byte[])obj.BindImages();

                // create an image from the byte array
                ms = new System.IO.MemoryStream(imgdata);
                fullsizeImage =System.Drawing.Image.FromStream(ms);

                Response.ContentType = "image/Jpeg";
                
                fullsizeImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message, ex);
            }
            finally
            {
                ms.Close();
            }
        }
    }


    void getImageFromDB()
    {
        BLL_Edit_User_Detail obj = new BLL_Edit_User_Detail();
          //imageID = Request.QueryString[IMAGE_ID];
          //      labid = Request.QueryString[LAB_ID];
          //      Userid = Request.QueryString["Userid"];
       

    }




}
