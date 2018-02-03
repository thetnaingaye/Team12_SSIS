using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

namespace Team12_SSIS.BusinessLogic
{

    public class PurchasingLogic
    {

        //----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

        // Checks if the current inventory is sufficient for the qty specified to be withdrawn by the user.
        public static double FindTotalByPONum(int poNum)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                double opt = 0;
                List<PORecordDetail> temp = context.PORecordDetails.Where(x => x.PONumber == poNum).ToList();
                foreach (var item in temp)
                {
                    opt += (Convert.ToDouble(item.Quantity) * Convert.ToDouble(item.UnitPrice));
                }
                return opt;
            }
        }

        // Passess a completely organized list based on data from the ReorderRecord table
        public static List<ReorderRecord> PopulateReorderTable()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<ReorderRecord> opt;
                List<ReorderRecord> tempList;

                try
                {
                    opt = new List<ReorderRecord>();
                    tempList = context.ReorderRecords.ToList();

                    opt.Add(tempList[0]);

                    // Creating our opt list
                    for (int i = 1; i < tempList.Count; i++)
                    {
                        bool noDuplicates = true;   // There might be duplicates...
                        for (int j = 0; j < opt.Count; j++)
                        {
                            if (tempList[i].ItemID == opt[j].ItemID && tempList[i].SupplierID == opt[j].SupplierID)
                            {
                                opt[j].OrderedQuantity += tempList[i].OrderedQuantity;
                                noDuplicates = false;
                            }
                        }

                        if (noDuplicates)
                        {
                            opt.Add(tempList[i]);
                        }
                    }
                    return opt;
                }
                catch (Exception)
                {
                    return null;     // This is to capture instances whereby there are zero records in the reorder table.
                }
            }
        }

        // Retrieving supplier name
        public static string GetSuppilerName(string suppID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                SupplierList s = context.SupplierLists.Where(x => x.SupplierID.Equals(suppID)).First();
                return s.SupplierName;
            }
        }

        // Removing selected entries from the Reorder table
        public static void RemoveReorderRecord(string itemID, string suppID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<ReorderRecord> r = context.ReorderRecords.Where(x => x.ItemID.Equals(itemID)).Where(y => y.SupplierID.Equals(suppID)).ToList();

                // Remove everything retrieved in the list
                foreach (var item in r)
                {
                    context.ReorderRecords.Remove(item);
                }
                context.SaveChanges();
            }
        }

        // Create multiple PO from a list of reorder records
        public static string CreateMultiplePO(List<ReorderRecord> tempList)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    foreach (var item in tempList)
                    {
                        bool res1 = CreateSinglePO(item);
                        bool res2 = CreateSinglePODetails(item);

                        if (!res1 || !res2)
                        {
                            throw new Exception();
                        }


                        // Gotta clear all the reorder records that are in the db according to their itemid
                        List<ReorderRecord> rList = context.ReorderRecords.Where(x => x.ItemID.Equals(item.ItemID)).ToList();
                        foreach (var item1 in rList)
                        {
                            context.ReorderRecords.Remove(item1);
                        }
                        context.SaveChanges();
                    }
                    // Finall~
                    return "All purchase orders were successfully created and has been send to the supervisor for approval.";
                }
                catch (Exception)
                {
                    return "Failure to create all purchase orders.";
                }
            }
        }

        // Creating a single PO entry
        public static bool CreateSinglePO(ReorderRecord r)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    SupplierList s = context.SupplierLists.Where(x => x.SupplierID.Equals(r.SupplierID)).First();

                    PORecord p = new PORecord();
                    p.DateRequested = DateTime.Now;
                    p.RecipientName = "System-generated";
                    p.DeliveryAddress = "21 Lower Kent Ridge Rd, Singapore 119077";  // Default address
                    p.SupplierID = r.SupplierID;
                    p.CreatedBy = "Logic University Stationery Store";
                    p.ExpectedDelivery = DateTime.Now.AddDays(Convert.ToDouble(s.OrderLeadTime));
                    p.Status = "Pending";

                    context.PORecords.Add(p);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        // Creating a single PODetails entry
        public static bool CreateSinglePODetails(ReorderRecord r)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    // Finding the newly created PO record
                    PORecord pr = context.PORecords.OrderByDescending(x => x.PONumber).First();

                    // Req to populate the values for the new entry
                    InventoryCatalogue iv = context.InventoryCatalogues.Where(x => x.ItemID.Equals(r.ItemID)).First();  // To retrieve UOM
                    SupplierCatalogue sc = context.SupplierCatalogues.Where(x => x.ItemID.Equals(r.ItemID)).Where(y => y.SupplierID.Equals(r.SupplierID)).First();  // TO retrieve price

                    // Creating our new entry...
                    PORecordDetail pd = new PORecordDetail();
                    pd.PONumber = pr.PONumber;
                    pd.ItemID = r.ItemID;
                    pd.Quantity = r.OrderedQuantity;
                    pd.UOM = iv.UOM;
                    pd.UnitPrice = sc.Price;

                    context.PORecordDetails.Add(pd);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        // Setting a proportional level for buffer stock
        public static void SetProportionalBFS(string itemID, int propValue)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                // Finding the week no for the year (aka our period currently)
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int currentPeriod = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                // Creating our obj from DB
                ForecastedData f = context.ForecastedDatas.Where(x => x.ItemID.Equals(itemID)).Where(y => y.Season == DateTime.Now.Year).Where(z => z.Period == currentPeriod + 1).First();  // +1 to capture the next period
                InventoryCatalogue i = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();

                // Changing our values
                i.BFSProportion = propValue;
                i.BufferStockLevel = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(propValue) * Convert.ToDouble(f.ForecastedDemand)) / 100));

                context.SaveChanges();
            }
        }

        //------------ Lim Chang Siang's Code Start Here-------------------------------//
        //This method Returns a list of PO details for Goods Receipt
        public List<PORecordDetail> GetPurchaseOrdersForGR(int POnumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                //Get a existing list of Order details
                List<PORecordDetail> poDetailList = ctx.PORecordDetails.Where(x => x.PONumber == POnumber).ToList();
                //fresh list to record updated list of Order details
                List<PORecordDetail> poDetailListWithGR = new List<PORecordDetail>();
                //Create a joined table GoodReceipt with GoodsReceiptDetails to check if the item has existing GR record
                var grRecords = ctx.GoodReceipts.Join(ctx.GoodReceiptDetails,
                    gr => gr.GRNumber,
                    grd => grd.GRNumber,
                    (gr, grd) => new
                    {
                        PONumber = gr.PONumber,
                        ItemID = grd.ItemID,
                        Quantity = grd.Quantity,
                        GRNumber = gr.GRNumber,
                    }).Where(x => x.PONumber == POnumber).ToList();

                //Check for remaiaing GR quantity
                foreach (PORecordDetail orderedItem in poDetailList)
                {
                    //Add the updated Order detail into the fresh list.
                    PORecordDetail prd = CheckForGRQuantity(grRecords, orderedItem);
                    if (prd.Quantity > 0)
                        poDetailListWithGR.Add(prd);
                }
                try
                {
                    //Check for PO completion and if yes, change the PO Status
                    IsPOCompleted(poDetailListWithGR.Count, POnumber);
                }
                catch (Exception ex)
                {
                    //Exception will be thrown if an invalid PO number is entered, returning null value;
                    Console.WriteLine(ex.ToString());
                }
                //Return the Order list that has the updated reamining quantity.
                return poDetailListWithGR;
            }
        }

        internal static PORecord GetPurchaseOrderRecord(object poNo)
        {
            throw new NotImplementedException();
        }

        private bool IsPOCompleted(int itemCount, int poNumber)
        {
            bool isCompleted = false;
            if (itemCount == 0)
            {
                using (SA45Team12AD ctx = new SA45Team12AD())
                {
                    PORecord poR = ctx.PORecords.Where(x => x.PONumber == poNumber).FirstOrDefault();
                    poR.Status = "Completed";
                    ctx.SaveChanges();

                    isCompleted = true;
                    return isCompleted;
                }
            }
            return isCompleted;
        }

        private PORecordDetail CheckForGRQuantity(dynamic grRecords, PORecordDetail orderedItem)
        {
            //for each GR record, check if the ItemID matches with the Order item ItemID
            foreach (var received in grRecords)
            {
                if (orderedItem.ItemID == received.ItemID)
                {
                    //Minus ordered quantity with received quantity
                    int qty = (int)orderedItem.Quantity - (int)received.Quantity;
                    orderedItem.Quantity = qty;
                }
            }
            return orderedItem;
        }

        //Method for Posting GR
        public int CreateGoodsReceipt(DateTime dateProcessed, int poNumber, string receivedBy, string doNumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                GoodReceipt goodReceipt = new GoodReceipt
                {
                    PONumber = poNumber,
                    ReceivedBy = receivedBy,
                    DateProcessed = dateProcessed,
                    DONumber = doNumber
                };
                ctx.GoodReceipts.Add(goodReceipt);
                ctx.SaveChanges();
                return goodReceipt.GRNumber;
            }

        }

        public PORecord GetPORecords(int poNumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
                return ctx.PORecords.FirstOrDefault(x => x.PONumber == poNumber);
        }

        public void CreateGoodsReceiptDetails(int grNumber, string itemID, int quantity, string uom, string remarks)
        {
            GoodReceiptDetail grd = new GoodReceiptDetail();
            grd.GRNumber = grNumber;
            grd.ItemID = itemID;
            grd.Quantity = quantity;
            grd.UOM = uom;
            grd.Remarks = remarks;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.GoodReceiptDetails.Add(grd);
                ctx.SaveChanges();
            }
            InventoryLogic.LessUnitsOnOrder(itemID, quantity);
        }

        public GoodReceipt GetGoodsReceipt(int goodReceiptNumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.GoodReceipts.FirstOrDefault(x => x.GRNumber == goodReceiptNumber);
            }
        }

        public List<GoodReceiptDetail> GetGoodsReceiptDetails(int goodReceiptNumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.GoodReceiptDetails.Where(x => x.GRNumber == goodReceiptNumber).ToList();
            }
        }
        //------------ Lim Chang Siang's Code Ends Here-------------------------------//



        //------ Li Jianing'S Code start Here------------------------------//
        public static int AddText(string Deliverto, string Address, string SupplierID, DateTime RequestedDate, string userName, DateTime ExpectedBy)
        {
            //Put here so other methods can use even after the EF object is disposed.
            PORecord poRecord;

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                poRecord = new PORecord();
                poRecord.RecipientName = Deliverto;
                poRecord.DeliveryAddress = Address;
                poRecord.SupplierID = SupplierID;
                poRecord.Status = "Pending";
                poRecord.DateRequested = RequestedDate;
                poRecord.CreatedBy = userName;
                poRecord.ExpectedDelivery = ExpectedBy;
                entities.PORecords.Add(poRecord);
                entities.SaveChanges();
            }
            //Using System.Web.Security feature.
            List<MembershipUser> userList = Utility.Utility.GetListOfMembershipUsers();
            string[] approveAuthList = Roles.GetUsersInRole("Supervisor");
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            foreach (string s in approveAuthList)
            {
                var User = userList.Find(x => x.UserName == s);
                using (EmailControl em = new EmailControl())
                {
                    em.NewPurchaseOrderForApprovalNotification(User.Email.ToString(), clerkName, poRecord.PONumber.ToString(), DateTime.Now.Date.ToString("d"));
                }
            }
            //Return the new PONumber.
            return poRecord.PONumber;
        }
        public static void AddItem(string ItemID, int Quantity, string UOM, double UnitPrice)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                PORecordDetail poRecordDetails = new PORecordDetail();
                poRecordDetails.ItemID = ItemID;
                poRecordDetails.Quantity = Quantity;
                poRecordDetails.UOM = UOM;
                poRecordDetails.UnitPrice = UnitPrice;
                entities.PORecordDetails.Add(poRecordDetails);
                entities.SaveChanges();
            }
        }
        public static double GetUnitPrice(string ItemID, string supplierId)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return (double)entities.SupplierCatalogues.Where(x => x.ItemID == ItemID).Where(x => x.SupplierID == supplierId).Select(x => x.Price).FirstOrDefault();

            }
        }
        public static string GetUOM(string ItemID, string supplierId)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return (string)entities.SupplierCatalogues.Where(x => x.ItemID == ItemID).Where(x => x.SupplierID == supplierId).Select(x => x.UOM).FirstOrDefault();
            }
        }
        public static List<PORecord> ListPORecords()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecords.ToList();

            }
        }

        public void CreatePurchaseOrderDetails(int poNumber, string itemId, int quantity, string uom, double unitPrice)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                PORecordDetail poRecordDetail = new PORecordDetail
                {
                    PONumber = poNumber,

                    ItemID = itemId,

                    Quantity = quantity,
                    UOM = uom,
                    UnitPrice = unitPrice,
                };
                entities.PORecordDetails.Add(poRecordDetail);
                entities.SaveChanges();
            }
        }
        public static void UpdatePurchaseOrderStatus(int poNumber, string status, DateTime dateProcessed, string handledBy)
        {
            PORecord po;
            string email = "";
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                po = entities.PORecords.Where(x => x.PONumber == poNumber).FirstOrDefault();
                po.Status = status;
                po.DateProcessed = dateProcessed;
                po.HandledBy = handledBy;
                entities.SaveChanges();
                email = Utility.Utility.GetUserEmailAddress(po.CreatedBy);
            }
            if (status == "Approved")
                PurchaseOrderIsApproved(poNumber);

            using (EmailControl em = new EmailControl())
            {
                em.ChangeInPurchaseOrderStatusNotification(email, poNumber.ToString(), dateProcessed.ToString("d"), status);
            }

        }

        static void PurchaseOrderIsApproved(int poNumber)
        {
            PORecord po;
            double totalPrice = 0;
            string supplierEmail;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                po = ctx.PORecords.Where(x => x.PONumber == poNumber).FirstOrDefault();
                supplierEmail = ctx.SupplierLists.Where(x => x.SupplierID == po.SupplierID).Select(x => x.EmailAddress).FirstOrDefault();
                List<PORecordDetail> poDList = ctx.PORecordDetails.Where(x => x.PONumber == poNumber).ToList();
                foreach (PORecordDetail p in poDList)
                {
                    InventoryLogic.UpdateUnitsOnOrder(p.ItemID, (int)p.Quantity);
                    totalPrice += (double)(p.UnitPrice * p.Quantity);
                }
            }
            //Creating a thread to send the PDF email in background to prevent lagging the Website.
            Thread bgThread = new Thread(delegate ()
            {
                using (EmailControl em = new EmailControl())
                {
                    em.SendPurchaseOrder(supplierEmail, po.PONumber, po.RecipientName, po.DeliveryAddress, GetSuppilerName(po.SupplierID), (DateTime)po.ExpectedDelivery, totalPrice);
                }
            });
            bgThread.Start();
        }

        public static PORecord GetPurchaseOrderRecord(int poNo)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecords.FirstOrDefault(x => x.PONumber == poNo);
            }
        }
        public static List<PORecord> GetListOfPurchaseOrder()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecords.ToList();

            }
        }
        public static List<PORecord> GetListOfPurchaseOrder(string status)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecords.Where(x => x.Status == status).ToList();


            }
        }
        public static List<PORecordDetail> GetListOfPORecorDetails(int poNo)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecordDetails.Where(x => x.PONumber == poNo).ToList();
            }
        }



        public static List<PORecordDetail> GetListOfPurchaseOrderDetails()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecordDetails.ToList();


            }
        }
        public static int GetPORecordApproveID(int poNo)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.PORecordDetails.Where(x => x.PONumber == poNo).Select(x => x.ID).FirstOrDefault();
            }
        }

        public static bool Submitforapproval(int poNo)
        {
            bool success = true;
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                PORecord poRecord = entities.PORecords.FirstOrDefault(x => x.PONumber == poNo);

                entities.SaveChanges();
                success = true;
            }
            return success;
        }

        public static bool CancelPORecordRequest(int poNo)
        {
            bool success = false;
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                PORecord poRecord = entities.PORecords.FirstOrDefault(x => x.PONumber == poNo);
                poRecord.Status = "Cancelled";
                entities.SaveChanges();
                success = true;
            }
            return success;
        }
        //------ Li Jianing'S Code end Here------------------------------//



//--------- Yuan Yishu's Code Starts Here-----------------//
        public static List<SupplierList> ListSuppliers()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.SupplierLists.ToList();
            }
        }

	

		public static void UpdateOrderLeadTime(int orderLeadTime, string supplierID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                SupplierList supplier = entities.SupplierLists.Where(p => p.SupplierID == supplierID).First<SupplierList>();
                supplier.OrderLeadTime = orderLeadTime;
                entities.SaveChanges();
            }
        }


        public static int GetCurrentBufferStock(string itemid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                if (entities.InventoryCatalogues.Where(x => x.ItemID == itemid).Select(x => x.BufferStockLevel).Single() != null)
                {
                    return (int)entities.InventoryCatalogues.Where(x => x.ItemID == itemid).Select(x => x.BufferStockLevel).Single();
                }
                else
                {
                    return -1;
                }
            }
        }
        public static string GetCurrentAutomationStatus(string itemid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue inventory = entities.InventoryCatalogues.Where(x => x.ItemID == itemid).First<InventoryCatalogue>();
                if (inventory.BufferStockLevel == null)
                {
                    return "The buffer stock level is currently calculated automatically for the current item.";
                }
                else
                {
                    return "The buffer stock level for the current item is " + inventory.BufferStockLevel.ToString();
                }
            }
        }

        public static void UpdateBufferStockLevel(string itemid, int newbufferstocklevel)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue inventory = entities.InventoryCatalogues.Where(x => x.ItemID == itemid).Single();
                inventory.BufferStockLevel = newbufferstocklevel;
                inventory.BFSProportion = 0;
                entities.SaveChanges();
            }
        }

        public static int GetCurrentOrderLeadTime(string supplierid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                SupplierList supplier = entities.SupplierLists.Where(x => x.SupplierID == supplierid).First<SupplierList>();
                return (int)supplier.OrderLeadTime;
            }
        }

        //--------- Yuan Yishu's Code Ends Here-----------------//


        //--------------- THET NAING AYE Starts Here-----------------------//
        public static List<PORecord> GetListOfPO(String status)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.PORecords.Where(x => x.Status == status).ToList();
            }
        }


        public static List<PORecord> GetListOfPO()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.PORecords.ToList();
            }
        }
        //--------------- THET NAING AYE Ends Here-----------------------//


//------------- Yuan Yishu's Code Starts Here----------------------//
        public static void DeleteSupplier(string SupplierID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                SupplierList supplier = entities.SupplierLists.Where(s => s.SupplierID == SupplierID).First<SupplierList>();
                entities.SupplierLists.Remove(supplier);
                entities.SaveChanges();
            }
        }

        public static void UpdateSupplier(string SupplierID, string SupplierName, string GSTRegistrationNo, string ContactName, int PhoneNo, int FaxNo, string Address, int OrderLeadTime, string Discontinued)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                SupplierList supplier = entities.SupplierLists.Where(s => s.SupplierID == SupplierID).First<SupplierList>();
                supplier.SupplierName = SupplierName;
                supplier.GSTRegistrationNo = GSTRegistrationNo;
                supplier.ContactName = ContactName;
                supplier.PhoneNo = PhoneNo;
                supplier.FaxNo = FaxNo;
                supplier.Address = Address;
                supplier.OrderLeadTime = OrderLeadTime;
                supplier.Discontinued = Discontinued;
                entities.SaveChanges();
            }
        }

        public List<SupplierList> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.SupplierLists.Where(s => s.SupplierID.Contains(value) || s.SupplierName.Contains(value)).ToList();
            }
        }

        public static void AddSupplier(string SupplierID, string SupplierName, string GSTRegistrationNo, string ContactName, int PhoneNo, int FaxNo, string Address, int OrderLeadTime, string Discontinued)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                SupplierList supplier = new SupplierList();
                supplier.SupplierID = SupplierID;
                supplier.SupplierName = SupplierName;
                supplier.GSTRegistrationNo = GSTRegistrationNo;
                supplier.ContactName = ContactName;
                supplier.PhoneNo = PhoneNo;
                supplier.FaxNo = FaxNo;
                supplier.Address = Address;
                supplier.OrderLeadTime = OrderLeadTime;
                supplier.Discontinued = Discontinued;
                entities.SupplierLists.Add(supplier);
                entities.SaveChanges();
            }
        }
        //------------- Yuan Yishu's Ends Starts Here----------------------//

    }
}