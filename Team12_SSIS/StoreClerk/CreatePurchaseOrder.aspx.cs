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
            Populate();
            string[] supplierID = { "ALPA", "CHEP", "BANE" };
            if (!IsPostBack)
            {
                ddlSli.DataSource = supplierID;
                ddlSli.DataBind();
            }
        }
        protected void Populate()
        {
            PODateLbl.Text = DateTime.Today.ToString();
            string user = RequestLbl.Text;
            string deliverTo = txtDlt.Text;
            int id = ddlSli.SelectedIndex;
            string address = txtAds.Text;
            string order = txtord.Text;

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
            if (!IsPostBack)
            {
                List<PORecordDetail> emptyPO = new List<PORecordDetail>();
                PORecordDetail p = new PORecordDetail();
                emptyPO.Add(p);
                GridView1.DataSource = emptyPO;
                GridView1.DataBind();
            }
            int ItemId = txtitemid.Text;
        
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();


        }
    }
}