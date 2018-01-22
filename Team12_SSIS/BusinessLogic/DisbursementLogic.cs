using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{

    //Yishu Line 15 to 315
    //thanisha Line 316 to 616
    //Jane Line 617 to 917
    //Naing Line 1218 to 1518
    //Pradeep Line 1519 to 1820
    public class DisbursementLogic
    {












































































































































































































































































































        //-------------------------Getting disbursement details------------------------------//

        //-----------------------------using join to get disbursement form details from 3 tables:1)DisbursementLists 2)Departments 3)CollectionPoints --------//
        public List<Object> GetDisbursementForm()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from di in entities.DisbursementLists
                         join de in entities.Departments on di.DepartmentID equals de.DeptID
                         join co in entities.CollectionPoints on di.CollectionPointID equals co.CollectionPointID
                         select new
                         {
                             DisbursementID = di.DisbursementID,
                             DepartmentName = de.DepartmentName,
                             CollectionDate=di.CollectionDate,
                             CollectionPoint = co.CollectionPoint1,
                             RepresentativeName = di.RepresentativeName,
                             status = di.Status
                         });
                List<Object> dList = q.ToList<Object>();
                return dList;
            }
        }

        public List<Object> GetDisbursementByRep(string rep)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                         var q = (from di in entities.DisbursementLists
                         join de in entities.Departments on di.DepartmentID equals de.DeptID
                         join co in entities.CollectionPoints on di.CollectionPointID equals co.CollectionPointID
                         where di.RepresentativeName == rep
                         select new
                         {
                             DisbursementID = di.DisbursementID,
                             DepartmentName = de.DepartmentName,
                             CollectionDate = di.CollectionDate,
                             CollectionPoint = co.CollectionPoint1,
                             RepresentativeName = di.RepresentativeName,
                             status = di.Status
                         });
                List<Object> dList = q.ToList<Object>();
                return dList;
            }
        }

        //-----------------------------using join to get disbursement form details from 3 tables:1). DisbursementLists 2).Departments 3).CollectionPoints----------------//
        //-------------------------------Filter the disbursement details  by date range-------------------------------------------------------------------//
        public List<Object> GetDisbursementByDate(DateTime startDate, DateTime enddate)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from di in entities.DisbursementLists
                         join de in entities.Departments on di.DepartmentID equals de.DeptID
                         join co in entities.CollectionPoints on di.CollectionPointID equals co.CollectionPointID
                         where di.CollectionDate >= startDate && di.CollectionDate <= enddate
                         select new
                         {
                             DisbursementID = di.DisbursementID,
                             DepartmentName = de.DepartmentName,
                             CollectionDate = di.CollectionDate,
                             CollectionPoint = co.CollectionPoint1,
                             RepresentativeName = di.RepresentativeName,
                             status = di.Status
                         });
                List<Object> dList = q.ToList<Object>();
                return dList;
            }
        }

        //----------------------------------for Disbursement Details page--------------------------//

        public List<Object> GetDisbursementDetails(int id)
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from dl in entities.DisbursementListDetails
                         join i in entities.InventoryCatalogues on dl.ItemID equals i.ItemID
                         where dl.DisbursementID == id

                         select new
                         {
                             ItemDescription = i.Description,
                             QuantityRequested = dl.QuantityRequested,
                             QuantityCollected = dl.QuantityCollected,
                             UnitOfMeasurement = dl.UOM,
                             status = dl.Remarks
                         });
                List<Object> dList = q.ToList<Object>();
                return dList;
            }
        }

        public DisbursementList GetDisbursementtextDetails(int id)
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from df in entities.DisbursementLists
                         join co in entities.CollectionPoints on df.CollectionPointID equals co.CollectionPointID
                         where df.DisbursementID == id select df);
                DisbursementList ddetail = q.First<DisbursementList>();
                return ddetail;
            }
        }

        public CollectionPoint GetDisbursementCollectionDetails(int id)
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from df in entities.DisbursementLists
                         join co in entities.CollectionPoints on df.CollectionPointID equals co.CollectionPointID
                         where df.DisbursementID == id
                         select co);
                CollectionPoint ddetail = q.First<CollectionPoint>();
                return ddetail;
            }
        }

















































































































































































































































































    }
}