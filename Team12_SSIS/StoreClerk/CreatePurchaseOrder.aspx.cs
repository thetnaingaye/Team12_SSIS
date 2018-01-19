using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            PODateLbl.Text = DateTime.Today.ToString();
            if (!IsPostBack)
            {
                List<PORecordDetails> emptyPO = new List<PORecordDetails>();
                emptyPO.Add("");
                GridView1.DataSource = emptyPO;
                GridView1.DataBind();

            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtSid.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
       
        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}