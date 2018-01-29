using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Taken from kiong.com DipSA Android Module. Media and Playback topic....
/// </summary>
namespace Team12_SSIS.WebServices
{
    public partial class FormUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string output = "";
            Response.Clear();
            Response.CacheControl = "no-cache";
            Response.ContentType = "text/xml";
            Response.ContentType = "application/json";

            if(Request.Files["file"] != null)
            {
                HttpPostedFile file = Request.Files["Files"];
                string TargetLocation = Server.MapPath("~/Team12_SSIS/images/");
                try
                {
                    if(file.ContentLength > 0)
                    {
                        //filename
                        string filename = file.FileName;
                        //file size
                        int fileSize = file.ContentLength;
                        //Create a byte array corrosponding to file size
                        byte[] fileByteArray = new byte[fileSize];
                        //push file into byte array
                        file.InputStream.Read(fileByteArray, 0, fileSize);
                        //Uploading properly format file to server
                        file.SaveAs(TargetLocation + filename);

                        output = String.Format("{{\"file\":\"{0}\", \"caption\":\"{1}\",\"location\":\"{2}\"}}", TargetLocation + filename, Request.Params["caption"], Request.Params["location"]);
                    }
                    
                }catch(Exception ex)
                {
                    output = String.Format("\"{0}\"", ex.ToString());
                }
            }
            Response.Write(output);
            Response.End();
        }
    }
}