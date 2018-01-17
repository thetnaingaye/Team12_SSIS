using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Team12_SSIS.Utility.Validator;


namespace Team12_SSIS.StoreManager
{
    public partial class CreateCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IsPositiveInteger(2);
        }
    }
}