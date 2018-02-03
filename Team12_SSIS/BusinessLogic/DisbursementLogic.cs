using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

namespace Team12_SSIS.BusinessLogic
{

    //Yishu Line 15 to 315
    //thanisha Line 316 to 616
    //Jane Line 617 to 917
    //Naing Line 1218 to 1518
    //Pradeep Line 1519 to 1820
    public class DisbursementLogic
    {
        //-------------------- VALLIYODAN THANISHA Code Starts Here-------------------------//
        //-------------------------Getting disbursement details------------------------------//
        //-----------------------Entire disbursement List------------------------------------//
        public static List<DisbursementList> GetDisbursementForm()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string departmentId = GetCurrentDep();
                return entities.DisbursementLists.Where(x => x.DepartmentID == departmentId).ToList<DisbursementList>();
            }
        }


        //-------------------------------Filter the disbursement details  by date range-------------------------------------------------------------------//
        public static List<DisbursementList> GetDisbursementByDate(DateTime startDate, DateTime enddate)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string departmentId = GetCurrentDep();
                var q = (from di in entities.DisbursementLists
                         where di.CollectionDate >= startDate && di.CollectionDate <= enddate && di.DepartmentID == departmentId
                         select di);

                List<DisbursementList> dList = q.ToList<DisbursementList>();
                return dList;
            }
        }

        //-------------------------------Filter the disbursement details  by rep-------------------------------------------------------------------//
        public static List<DisbursementList> GetDisbursementByRep(string rep)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string departmentId = GetCurrentDep();
                var q = (from di in entities.DisbursementLists
                         where di.RepresentativeName.Contains(rep) && di.DepartmentID == departmentId
                         select di);
                List<DisbursementList> dList = q.ToList<DisbursementList>();
                return dList;
            }
        }

        //-------------------------------get departments()-------------------------------------------------------------------//

        public static List<Department> GetDepartmentList()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.Departments.ToList<Department>();
            }
        }

        //-------------------------------filter disbursement by department------------------------------------------------------------------//

        public static List<DisbursementList> GetDisbursementmentListByDep(string dep)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from di in entities.DisbursementLists
                         join de in entities.Departments on di.DepartmentID equals de.DeptID
                         where de.DepartmentName == dep
                         select di);
                return q.ToList<DisbursementList>();
            }
        }




        //----------------------------------for Disbursement Details page--------------------------//

        public static List<Object> GetDisbursementDetails(int id)
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
                             Remarks = dl.Remarks
                         });
                List<Object> dList = q.ToList<Object>();
                return dList;
            }
        }

        public static DisbursementList GetDisbursementtextDetails(int id)
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = (from df in entities.DisbursementLists
                         join co in entities.CollectionPoints on df.CollectionPointID equals co.CollectionPointID
                         where df.DisbursementID == id
                         select df);
                DisbursementList ddetail = q.First<DisbursementList>();
                return ddetail;
            }
        }

        public static CollectionPoint GetDisbursementCollectionDetails(int id)
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

        //-------------------- VALLIYODAN THANISHA Code Ends Here-------------------------//




        //-------------------- Lim Chang Siang Start here -------------------------------//
        public static List<Department> GetListofDepartments()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.Departments.ToList();
            }
        }

        public static List<CollectionPoint> GetListofColPoint()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.CollectionPoints.ToList();
            }
        }

        public int CreateDisbursementList(string deptId, int collectPtId, DateTime collectionDate, string deptRep)
        {
            DisbursementList dList = new DisbursementList();
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                dList.DepartmentID = deptId;
                dList.CollectionPointID = collectPtId;
                dList.CollectionDate = collectionDate;
                dList.RepresentativeName = deptRep;
                dList.Status = "Pending Collection";
                ctx.DisbursementLists.Add(dList);
                ctx.SaveChanges();
            }
            using (EmailControl em = new EmailControl())
            {
                em.NewStationeryCollectionNotification(Utility.Utility.GetEmailAddressByName(deptRep), GetCurrentCPWithTimeByID(collectPtId), collectionDate.ToString("d"));
            }
            return dList.DisbursementID;
        }

        public void CreateDisbursementListDetails(int disbursementId, string itemId, int actualQuantity, int quantityRequested, int quantityCollected, string uom, string remarks)
        {
            DisbursementListDetail dListDetails = new DisbursementListDetail();
            dListDetails.DisbursementID = disbursementId;
            dListDetails.ItemID = itemId;
            dListDetails.ActualQuantity = actualQuantity;
            dListDetails.QuantityRequested = quantityRequested;
            dListDetails.QuantityCollected = quantityCollected;
            dListDetails.UOM = uom;
            dListDetails.Remarks = remarks;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.DisbursementListDetails.Add(dListDetails);
                ctx.SaveChanges();
            }
        }

        public bool UpdateDisbursementListDetails(int id, int quantityCollected, string remarks)
        {
            bool success = false;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                DisbursementListDetail dListDetails = ctx.DisbursementListDetails.Where(x => x.ID == id).FirstOrDefault();
                CheckForOutstandingItem(quantityCollected, dListDetails, remarks);
                dListDetails.QuantityCollected = quantityCollected;
                dListDetails.Remarks = remarks;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }

        public int CreateSystemStationeryRequest(DateTime requestDate, string deptId, string remarks)
        {
            RequisitionRecord rRecord = new RequisitionRecord();
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                rRecord.DepartmentID = deptId;
                rRecord.Remarks = remarks;
                rRecord.RequestorName = "DisbursementLogic";
                rRecord.RequestDate = DateTime.Now.Date;
                rRecord.ApprovedDate = DateTime.Now.Date;
                rRecord.ApproverName = "System Generated Request";
                ctx.RequisitionRecords.Add(rRecord);
                ctx.SaveChanges();
                return rRecord.RequestID;
            }
        }

        public void CreateStationeryRequestDetails(int requestId, string itemId, int requestedQuantity)
        {
            RequisitionRecordDetail rRDetails = new RequisitionRecordDetail();
            rRDetails.RequestID = requestId;
            rRDetails.ItemID = itemId;
            rRDetails.RequestedQuantity = requestedQuantity;
            rRDetails.Status = "Approved";
            rRDetails.Priority = "Yes";
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.RequisitionRecordDetails.Add(rRDetails);
                ctx.SaveChanges();
            }
        }

        private void CheckForOutstandingItem(int quantityCollected, DisbursementListDetail dListDetails, string remarks)
        {
            string departmentId;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                departmentId = ctx.DisbursementLists.Where(x => x.DisbursementID == dListDetails.DisbursementID).Select(x => x.DepartmentID).FirstOrDefault();
            }
            if (quantityCollected < dListDetails.ActualQuantity)
            {
                int Reqid = CreateSystemStationeryRequest(DateTime.Now.Date, departmentId, ("DisbursementLogic for: DL" + dListDetails.DisbursementID.ToString("0000")));
                CreateStationeryRequestDetails(Reqid, dListDetails.ItemID, (int)dListDetails.ActualQuantity - quantityCollected);
            }
        }

        public static DisbursementList GetDisbursementList(int disbursementId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.Where(x => x.DisbursementID == disbursementId).FirstOrDefault();
            }
        }

        public static List<DisbursementList> GetDisbursementList()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.ToList();
            }
        }

        public static List<DisbursementListDetail> GetDisbursementListDetails()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementListDetails.ToList();
            }
        }

        public static List<DisbursementListDetail> GetDisbursementListDetails(int disbursementId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementListDetails.Where(x => x.DisbursementID == disbursementId).ToList();
            }
        }

        public static bool UpdateDisbursementStatus(int disbursementId, string status)
        {
            string email;
            string collectPoint;
            string dateTime;
            bool success = false;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                DisbursementList dL = ctx.DisbursementLists.Where(x => x.DisbursementID == disbursementId).FirstOrDefault();
                email = Utility.Utility.GetEmailAddressByName(dL.RepresentativeName);
                collectPoint = GetCurrentCPWithTimeByID(dL.CollectionPointID);
                dateTime = ((DateTime)dL.CollectionDate).ToString("d");
                dL.Status = status;
                ctx.SaveChanges();
                success = true;
            }
            if (status == "Cancelled")
                using (EmailControl em = new EmailControl())
                {
                    em.CancelStationeryCollectionNotification(email, collectPoint, dateTime);
                }

            return success;
        }

        public static List<DisbursementList> GetListOfDisbursements()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.ToList();
            }
        }

        public static List<DisbursementList> GetListOfDisbursements(string columnName, string query)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                switch (columnName)
                {
                    case ("DepartmentID"):
                        return ctx.DisbursementLists.Where(x => x.DepartmentID == query).ToList();
                    case ("Status"):
                        return ctx.DisbursementLists.Where(x => x.Status == query).ToList();
                    default:
                        return ctx.DisbursementLists.ToList();
                }
            }
        }

        //Send reminder email to department rep 2 days before the collection date
        public static void SendCollectionReminder(DateTime date)
        {
            string email;
            string collectPoint;
            string dateTime;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                List<DisbursementList> dList = ctx.DisbursementLists.Where(x => x.CollectionDate == date.Add(TimeSpan.FromDays(2))).ToList();
                foreach (DisbursementList d in dList)
                {
                    email = Utility.Utility.GetEmailAddressByName(d.RepresentativeName);
                    collectPoint = GetCurrentCPWithTimeByID(d.CollectionPointID);
                    dateTime = ((DateTime)d.CollectionDate).ToString("d");
                    using (EmailControl em = new EmailControl())
                    {
                        em.RemindStationeryCollectionNotification(email, collectPoint, dateTime);
                    }
                }
            }
        }

        //-------------------- Lim Chang Siang ends here -------------------------------//

        //------ Predeep Code Starts Here--------------------//

        public static List<CollectionPoint> ListCollectionPoints()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.CollectionPoints.ToList();
            }
        }

        public static List<string> ListCollectionPointsWithTime()
        {
            List<CollectionPoint> cpList = new List<CollectionPoint>();
            cpList = DisbursementLogic.ListCollectionPoints();
            List<string> cpWithTimeList = new List<string>();
            foreach (CollectionPoint C in cpList)
            {
                string s = C.CollectionPoint1;
                cpWithTimeList.Add(s);
            }
            return cpWithTimeList;
        }

        public static string GetCurrentDep()
        {
            return HttpContext.Current.Profile.GetPropertyValue("department").ToString();
        }

        public static string GetDepNameByDepID(string depid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.Departments.Where(x => x.DeptID == depid).Select(x => x.DepartmentName).Single().ToString();
            }
        }

        public static string GetCurrentCPIDByDep(string dep)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.Departments.Where(x => x.DeptID == dep).Select(x => x.CollectionPointID).Single().ToString();

            }
        }

        public static string GetCurrentCPWithTimeByID(int id)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.CollectionPoints.Where(x => x.CollectionPointID == id).Select(x => x.CollectionPoint1).Single().ToString();

            }
        }

        public static void UpdateCollectionPoint(string depid, int cpid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                Department department = entities.Departments.Where(p => p.DeptID == depid).First<Department>();
                department.CollectionPointID = cpid;
                entities.SaveChanges();
            }
            Thread collectPointThread = new Thread(delegate ()
            {
                using (EmailControl em = new EmailControl())
                {

                    List<string> clerkemails = Utility.Utility.GetClerksEmailAddressList();
                    string newCPID = GetCurrentCPIDByDep(depid);
                    string newCPName = GetCurrentCPWithTimeByID(Int32.Parse(newCPID));
                    em.DisburstmentPointChangeNotification(clerkemails, GetDepNameByDepID(depid), GetDeptRepFullName(depid), newCPName);
                }
            });
            collectPointThread.Start();
        }

        public static List<MembershipUser> GetUsersFromDept(string dept)
        {
            List<MembershipUser> currentdepusers = new List<MembershipUser>();
            var users = Membership.GetAllUsers();

            foreach (MembershipUser u in users)
            {


                ProfileBase profile = ProfileBase.Create(u.UserName);
                if (profile.GetPropertyValue("department").ToString() == dept)
                {
                    currentdepusers.Add(u);
                }


            }


            return currentdepusers;
        }
        public static List<String> GetFullNamesFromDept(string dept)
        {
            List<String> currentdep = new List<String>();
            var users = Membership.GetAllUsers();

            foreach (MembershipUser u in users)
            {


                ProfileBase profile = ProfileBase.Create(u.UserName);
                if (profile.GetPropertyValue("department").ToString() == dept)
                {
                    currentdep.Add(profile.GetPropertyValue("fullname").ToString());
                }


            }


            return currentdep;
        }

        public static List<String> GetAllEmployeeFullNamesFromDept(string dept)
        {
            String employeeFullName = "";
            List<MembershipUser> users = GetUsersFromDept(dept);
            List<String> repusers = Roles.GetUsersInRole("Employee").ToList();
            List<string> employees = new List<string>();
            foreach (MembershipUser u in users)
            {
                foreach (string username in repusers)
                {
                    if (u.UserName == username)
                    {
                        ProfileBase p = ProfileBase.Create(username);
                        employeeFullName = p.GetPropertyValue("fullname").ToString();
                        employees.Add(employeeFullName);


                    }
                }
            }

            return employees;
        }
        public static string GetDeptRepFullName(String dept)
        {
            String repFullName = "";
            List<MembershipUser> users = GetUsersFromDept(dept);
            List<String> repusers = Roles.GetUsersInRole("Rep").ToList();
            foreach (MembershipUser u in users)
            {
                foreach (string username in repusers)
                {
                    if (u.UserName == username)
                    {
                        ProfileBase p = ProfileBase.Create(username);
                        repFullName = p.GetPropertyValue("fullname").ToString();

                    }
                }
            }

            return repFullName;
        }

        public static string GetDeptRepUserName(String dept)
        {

            List<MembershipUser> users = GetUsersFromDept(dept);
            List<String> repusers = Roles.GetUsersInRole("Rep").ToList();
            foreach (MembershipUser u in users)
            {
                foreach (string username in repusers)
                {
                    if (u.UserName == username)
                    {
                        return u.UserName;

                    }
                }
            }

            return null;
        }

        public static string GetUserName(String fullname, String dept)
        {

            List<MembershipUser> users = GetUsersFromDept(dept);
            foreach (MembershipUser u in users)
            {
                ProfileBase p = ProfileBase.Create(u.UserName);
                if (p.GetPropertyValue("fullname").ToString() == fullname)
                {
                    return u.UserName;
                }
            }
            return null;
        }

        public static void UpdateDeptRep(String newrepfullname, String dept)
        {
            Roles.AddUserToRole(GetDeptRepUserName(GetCurrentDep()), "Employee");
            Roles.RemoveUserFromRole(GetDeptRepUserName(GetCurrentDep()), "Rep");
            Roles.AddUserToRole(GetUserName(newrepfullname, dept), "Rep");
            Roles.RemoveUserFromRole(GetUserName(newrepfullname, dept), "Employee");
           
                using (SA45Team12AD entities = new SA45Team12AD())
                {
                    Department department = entities.Departments.Where(x => x.DeptID == dept).FirstOrDefault();
                    department.RepresentativeName = newrepfullname;
                    entities.SaveChanges();
                }
           
                //Chang Siang suggested using Thread function here
                Thread bgThread = new Thread(delegate ()
                {
                    using (EmailControl em = new EmailControl())
                    {
                        List<string> allemails = new List<string>();
                        List<string> clerkemails = Utility.Utility.GetClerksEmailAddressList();
                        List<string> depusersemails = Utility.Utility.GetAllUserEmailAddressListForDept(dept);
                        foreach (string s in clerkemails)
                        {
                            allemails.Add(s);
                        }
                        foreach (string s in depusersemails)
                        {
                            allemails.Add(s);
                        }

                        em.CollectionRepChangeNotification(allemails, GetDepNameByDepID(dept), newrepfullname);
                    }
                });
            bgThread.Start();

        }
        //------ Predeep Code Ends Here--------------------//
    }

}