using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewPurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string temp = Request.QueryString["POnumber"];
            LblNumber.Text = temp;
            string req = Request.QueryString["userName"];
            LblRst.Text = req;
            string sli = Request.QueryString["SupplierID"];
            LblCode.Text = sli;
            string dto = Request.QueryString["Deliverto"];
            LblDeliver.Text = dto;
            string add = Request.QueryString["Address"];
            LblAddress.Text = add;
            string sid = Request.QueryString["SelectedDate"];
            LblSib.Text = sid;




        }
        
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
   
       }

        protected string GetTotal()
        {
            PurchasingLogic p = new PurchasingLogic();
            int temp = Convert.ToInt32(LblNumber.Text);
            double res = p.FindTotalByPONum(temp);
            return res.ToString("C0");
        }

    }
    }


        