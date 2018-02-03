//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS.WebServices
{
    public partial class FormUpload : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = "";
            string fileExtension = ".jpg";
            string FilePath = Server.MapPath("~/Images/");

            if (!string.IsNullOrEmpty(Request.Form["id"]))
            {
                id = Request.Form["id"];
            }

            HttpFileCollection MyFileCollection = Request.Files;
            if (MyFileCollection.Count > 0)
            {
                // Save the File
                MyFileCollection[0].SaveAs(FilePath + "DL" + id + fileExtension);
            }
        }
    }
    }
