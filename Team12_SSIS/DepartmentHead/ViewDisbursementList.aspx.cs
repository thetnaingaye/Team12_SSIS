
//-----------------------------------------------Written by Thanisha------------------------------------------------//

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
      

        protected void Page_Load(object sender, EventArgs e)
        {
//--------------------------------Getting Disbursement id from session-------------------------------------------------//
            string id = Convert.ToString(Session["dId"]);           

            int DisbursementID = Convert.ToInt32(id);
            LblIdD.Text = "DL" + DisbursementID.ToString("0000");
            DisbursementList dL = DisbursementLogic.GetDisbursementList(DisbursementID);
            DisplaySignature(dL.Status, DisbursementID);
//------------------------Getting RepresentaTive name------------------------------------------------------------------//

            detail = DisbursementLogic.GetDisbursementtextDetails(DisbursementID);
            LblRepresentativeNameD.Text = detail.RepresentativeName;

//------------------------------Getting collectin point and date information-----------------------------------------//           
                DateTime collectionDate=(DateTime) detail.CollectionDate;
            LblCollectionDateD.Text = collectionDate.ToString("dd/MM/yyyy");

 
            cdetail = DisbursementLogic.GetDisbursementCollectionDetails(DisbursementID);
            LblCollectionPointD.Text = cdetail.CollectionPoint1;
            
//----------------------------------Binding datagridview with disbursement details------------------------------------//
            detailList = DisbursementLogic.GetDisbursementDetails(DisbursementID);
            GridViewDisbursementDetails.DataSource = detailList;
            GridViewDisbursementDetails.DataBind();
          
        }

        void DisplaySignature(string status, int disbursementID)
        {
            if(status == "Collected")
            {
                LblCollectedBy.Visible = true;
                ImgSignature.ImageUrl = "http://localhost/Team12_SSIS/Images/" + "DL" + disbursementID + ".jpg";
                ImgSignature.Visible = true;
            }
        }

       
    }
}