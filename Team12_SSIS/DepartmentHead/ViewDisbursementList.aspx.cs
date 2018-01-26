using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewDisbursementList : System.Web.UI.Page
    {
        List<Object> detailList;
     DisbursementList detail;
        CollectionPoint cdetail;
        DisbursementLogic logic = new DisbursementLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(Session["dId"]);
            int DisbursementID = Convert.ToInt32(id);
            LblIdD.Text = id;

            detail = logic.GetDisbursementtextDetails(DisbursementID);
            LblRepresentativeNameD.Text = detail.RepresentativeName;

           
                DateTime collectionDate=(DateTime) detail.CollectionDate;
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