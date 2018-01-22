using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {


        public List<string> GetUsersFromDept(string dept)
        {
            return DisbursementLogic.GetFullNamesFromDept(dept);        
             
        }


        public List<WCF_DisbursementList> GetDisbursementList()
        {

            List<DisbursementList> dlist = new DisbursementLogic().getDisbursement();
            List<WCF_DisbursementList> wcf_dlist = new List<WCF_DisbursementList>();
        

            foreach(DisbursementList d in dlist)
            {



                string d_id = d.DisbursementID.ToString();
                string d_deptId = d.DepartmentID.ToString();
                string d_collectionPointId = d.CollectionPointID.ToString();
                string d_collectionDate = d.CollectionDate.ToString();
                string d_repName = d.RepresentativeName.ToString();
                string status = (d.Status == null) ? "": d.Status.ToString();
                WCF_DisbursementList newWCF_dlist = new WCF_DisbursementList(d_id, d_deptId, d_collectionPointId, d_collectionDate, d_repName, status);

                //List<WCF_DisbursementListDetail> w = new List<WCF_DisbursementListDetail>();



                //foreach (DisbursementListDetail d_details in d.DisbursementListDetails)
                //{

                //    string id = d_details.ID.ToString();
                //    string disbursementID = d_details.DisbursementID.ToString();
                //    string itemID = d_details.ItemID.ToString();
                //    string actualQty = d_details.ActualQuantity.ToString();
                //    string qtyRequested = d_details.QuantityRequested.ToString();
                //    string qtyCollected = d_details.QuantityCollected.ToString();
                //    string uom = d_details.UOM.ToString();
                //    string remarks = d_details.Remarks.ToString();
                //    WCF_DisbursementListDetail newWCF_D_Details = new WCF_DisbursementListDetail(id, disbursementID, itemID, actualQty, qtyRequested, qtyCollected, uom, remarks);
                //    newWCF_dlist.WCF_DisbursementListDetails.Add(newWCF_D_Details);

                //}
                wcf_dlist.Add(newWCF_dlist);
                    
              
            }
            return wcf_dlist;
        }
    }
}
