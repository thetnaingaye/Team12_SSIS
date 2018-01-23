using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewDisbursementList1 : System.Web.UI.Page
    {
      
            List<Object> detailList;
            DisbursementList detail;
            CollectionPoint cdetail;
            DisbursementLogic logic = new DisbursementLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(Request.QueryString["DisbursementID"]);
            int DisbursementID = Convert.ToInt32(id);
            LblIdD.Text = "DL00"+id;

            detail = logic.GetDisbursementtextDetails(DisbursementID);
            LblRepresentativeNameD.Text = detail.RepresentativeName;


            DateTime collectionDate = (DateTime)detail.CollectionDate;
            LblCollectionDateD.Text = collectionDate.ToString("MM/dd/yyyy");

            cdetail = logic.GetDisbursementCollectionDetails(DisbursementID);
            LblCollectionPointD.Text = cdetail.CollectionPoint1;

            //------------------------Binding datagridview with disbursement details----//
            detailList = logic.GetDisbursementDetails(DisbursementID);
            GridViewDisbursementDetails.DataSource = detailList;
            GridViewDisbursementDetails.DataBind();


        }


    }
}
    