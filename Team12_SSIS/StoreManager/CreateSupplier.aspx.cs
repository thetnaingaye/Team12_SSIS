using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager
{
    public partial class CreateSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string SupplierID = TxtSupplierID.Text;
                string SupplierName = TxtSupplierName.Text;
                string GSTRegistrationNo = TxtGSTRegistrationNo.Text;
                string ContactName = TxtContactName.Text;
                int PhoneNo = Convert.ToInt32(TxtPhoneNo.Text);
                int FaxNo = Convert.ToInt32(TxtFaxNo.Text);
                string Address = TxtAddress.Text;
                int OrderLeadTime = Convert.ToInt32(TxtOrderLeadTime.Text);

                BusinessLogic.PurchasingLogic.AddSupplier(SupplierID, SupplierName, GSTRegistrationNo, ContactName, PhoneNo, FaxNo, Address, OrderLeadTime);
                Response.Redirect("ViewSupplierList.aspx");
            }
        }
    }
}