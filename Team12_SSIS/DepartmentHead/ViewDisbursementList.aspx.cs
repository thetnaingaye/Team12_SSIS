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
            detail = logic.GetDisbursementtextDetails(3);
            LblRepresentativeNameD.Text = detail.RepresentativeName;
           
                DateTime collectionDate=(DateTime) detail.CollectionDate;
            LblCollectionDateD.Text = collectionDate.ToString("MM/dd/yyyy");

            cdetail = logic.GetDisbursementCollectionDetails(3);
            LblCollectionPointD.Text = cdetail.CollectionPoint1;
            
            //------------------------Binding datagridview with disbursement details----//
            detailList = logic.GetDisbursementDetails(3);
            GridViewDisbursementDetails.DataSource = detailList;
            GridViewDisbursementDetails.DataBind();

        }
    }
}