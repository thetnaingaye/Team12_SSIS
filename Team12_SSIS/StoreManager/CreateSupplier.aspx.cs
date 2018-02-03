//-- Author: Yuan Yishu
using System;
using System.Collections.Generic;
using System.Drawing;
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
                string Discontinued = "No";
                BusinessLogic.PurchasingLogic.AddSupplier(SupplierID, SupplierName, GSTRegistrationNo, ContactName, PhoneNo, FaxNo, Address, OrderLeadTime, Discontinued);
                Response.Redirect("ViewSupplierList.aspx");
            }
        }

        protected void TxtSupplierID_TextChanged(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string input = TxtSupplierID.Text;
                bool Exist = entities.SupplierCatalogues.Any(i => i.SupplierID == input);
                if (Exist)
                {
                    LblExist.Visible = true;
                    LblExist.Text = "Supplier ID Already Exist!";
                    LblExist.ForeColor = Color.Red;
                    TxtSupplierID.Text = string.Empty;
                }
                else
                {
                    LblExist.Visible = false;
                }
            }
        }
    }
}