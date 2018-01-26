﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

namespace Team12_SSIS.BusinessLogic
{
    //Yishu Line 15 to 315
    //Khair Line 316 to 616
    //Naing Line 617 to 917
    //Thanisha 1218 to 1518
    //Chang Siang Line 1519 to 1820
    public class InventoryLogic
    {

        public static List<InventoryCatalogue> ListCatalogues()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.ToList<InventoryCatalogue>();
            }
        }

        public static void UpdateCatalogue(string ItemID, string Description,string CategoryID,string BIN, string Shelf, int Level, int ReorderLevel, int ReorderQty, string UOM, string Discontinued)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue catalogue = entities.InventoryCatalogues.Where(c => c.ItemID == ItemID).First<InventoryCatalogue>();
                catalogue.Description = Description;
                catalogue.CategoryID = CategoryID;
                catalogue.BIN = BIN;
                catalogue.Shelf = Shelf;
                catalogue.Level = Level;
                catalogue.ReorderLevel = ReorderLevel;
                catalogue.ReorderQty = ReorderQty;
                catalogue.UOM = UOM;
                catalogue.Discontinued = Discontinued;
                entities.SaveChanges();
            }
        }

        public static List<CatalogueCategory> CategoryID()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.CatalogueCategories.ToList<CatalogueCategory>();
            }
        }

        public static void AddCatalogue(string ItemID, string BIN, string Shelf, int Level, string CategoryID, string Description, int ReorderLevel, int ReorderQty, string UOM, string Discontinued)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue inventoryCatalogue = new InventoryCatalogue();
                inventoryCatalogue.ItemID = ItemID;
                inventoryCatalogue.BIN = BIN;
                inventoryCatalogue.Shelf = Shelf;
                inventoryCatalogue.Level = Level;
                inventoryCatalogue.CategoryID = CategoryID;
                inventoryCatalogue.Description = Description;
                inventoryCatalogue.ReorderLevel = ReorderLevel;
                inventoryCatalogue.ReorderQty = ReorderQty;
                inventoryCatalogue.UOM = UOM;
                inventoryCatalogue.Discontinued = Discontinued;
                entities.InventoryCatalogues.Add(inventoryCatalogue);
                entities.SaveChanges();
            }
        }

        public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.Description.Contains(value) || i.CategoryID.Contains(value)).ToList();
            }
        }

        public static string GetCatalogueName(string CategoryID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.CatalogueCategories.Where(x => x.CategoryID == CategoryID).Select(x => x.CatalogueName).First();
            }
        }









































































































































































































































        
        //----------------------------         KHAIR's               ----------------------------// 

        // Retrieve ALL items
        public List<InventoryCatalogue> ListAllItems()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.InventoryCatalogues.ToList<InventoryCatalogue>();
            }
        }

        // Retrieve ALL items by 
        public static InventoryCatalogue FindItemByItemID(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.InventoryCatalogues.Where(x => x.ItemID == itemID).First();
            }
        }

        // Retrieve specific item name
        public string GetItemDescription(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                InventoryCatalogue temp = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                return temp.Description.ToString();
            }
        }

        // Retrieving status for each reqrecorddetails item
        public static int GetQuantity(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                InventoryCatalogue ic = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                return (int)ic.UnitsInStock;
            }
        }

        // Retrieve specific item units of measure
        public string GetUnitsOfMeasure(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                InventoryCatalogue temp = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                return temp.UOM.ToString();
            }
        }

        // Checks if the current inventory is sufficient for the qty specified to be withdrawn by the user.
        public bool CheckAgainstInventoryQty(string itemID, int neededQty)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                InventoryCatalogue temp = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                if (temp.UnitsInStock >= neededQty) return true;
                else return false;
            }
        }

        // Inventory retrieval processes
        public string CreateNewInventoryRetrievalEntry(int reqID, int reqDetailID, string itemID, string deptID, int reqQty, int actQty, bool isOverride)
        {
            bool isFulfilled = true;
            bool isEnough = true;
            using (SA45Team12AD context = new SA45Team12AD())
            {
                InventoryRetrievalList i = new InventoryRetrievalList();
                InventoryCatalogue ic = context.InventoryCatalogues.Where(x => x.ItemID == itemID).First();

                //Check if there is insufficient quantity in the inventory
                if (ic.UnitsInStock < reqQty || ic.UnitsInStock < actQty)
                {
                    isEnough = false;

                    if (!isEnough && ic.UnitsInStock < actQty)
                    {
                        return (itemID + ": There are insufficient quantity in the inventory for this item.").ToString();
                    }
                }

                //If inventory is not enough and isOverride is true
                if (isOverride && ic.UnitsInStock > actQty)
                {
                    isEnough = false;
                }

                //Check if user is withdrawing more than requested 
                if (reqQty < actQty)
                {
                    return (itemID + ": You are not allowed to withdraw beyond the requested quantity.\nPlease seek assistance from the warehouse supervisor. Thank you.").ToString();
                }

                //Check if user is withdrawing less than requested despite having enough in the inventory
                if (isEnough && reqQty > actQty && !isOverride)
                {
                    return (itemID + ": You are not allowed to withdraw below the requested quantity.\nPlease seek assistance from the warehouse supervisor. Thank you.").ToString();
                }

                try
                {
                    //Creating a new entry in inventory retrieval list    ---    Only insider 
                    i.ItemID = itemID;
                    i.DepartmentID = deptID;
                    i.RequestedQuantity = reqQty;
                    i.ActualQuantity = actQty;
                    i.DateRetrieved = DateTime.Now;
                    if (!isEnough && reqQty > actQty)   // Not enough in inventory and actualqty is less than reqqty
                    {
                        i.Status = "Unfulfilled";
                        isFulfilled = false;
                    }
                    else
                    {
                        i.Status = "Fulfilled";
                    }
                    context.InventoryRetrievalLists.Add(i);

                    //Reducing overall qty in the inventorycatelogue table
                    int currentQty = ic.UnitsInStock;
                    ic.UnitsInStock = currentQty - actQty;     //New qty

                    //Updating the requsitionrecord table   --   Need to check if there are any 'approved' item requests under this requestID
                    RequisitionRecordDetail rr = context.RequisitionRecordDetails.Where(x => x.RequestDetailID == reqDetailID).First();
                    rr.Status = "Processed";

                    // Checking whether req qty is fulfilled   -   Separate this shit out  [Creating requisition records and details]
                    if (isFulfilled == false)
                    {
                        try
                        {
                            AutoCreateRR(reqID);
                            AutoCreateRRDetails(itemID, (reqQty - actQty));
                        }
                        catch (Exception)
                        {
                            return (itemID + ": Automated requisition record creation was not succesfully carried out.").ToString();
                        }
                    }

                    //Performing check through the MRP model [Create entry in the reorder record table]
                    //MRPInitialize(itemID);


                    //Completing changes to the DB
                    context.SaveChanges();

                    // Final ;)
                    return (actQty + " amount of " + itemID + " was successfully withdrawn.").ToString();
                }
                catch (Exception)
                {
                    return (actQty + " amount of " + itemID + " was unsuccessfully withdrawn from the inventory.").ToString();
                }
            }
        }

        // Creating a new req record - auto by the system
        public void AutoCreateRR(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    // Old req record
                    RequisitionRecord oldReq = context.RequisitionRecords.Where(x => x.RequestID == reqID).First();

                    // Gotta create a new req request and its relevant details
                    RequisitionRecord newReq = new RequisitionRecord();
                    newReq.RequestDate = DateTime.Now;
                    newReq.DepartmentID = oldReq.DepartmentID;
                    newReq.RequestorName = "System-generated";
                    newReq.ApproverName = "System-generated";
                    newReq.ApprovedDate = DateTime.Now;
                    newReq.Remarks = ("Previous request unfulfilled, RQ" + (oldReq.RequestID).ToString()).ToString();
                    context.RequisitionRecords.Add(newReq);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Creating a new req record details - auto by the system
        public void AutoCreateRRDetails(string itemID, int newReqQty)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    // Finding the newly created req record
                    RequisitionRecord newReq = context.RequisitionRecords.OrderByDescending(x => x.RequestID).First();

                    // Creating our new RRDetails entry
                    RequisitionRecordDetail nd = new RequisitionRecordDetail();
                    nd.RequestID = newReq.RequestID;
                    nd.ItemID = itemID;
                    nd.RequestedQuantity = newReqQty;
                    nd.Status = "Approved";
                    nd.Priority = "Yes";
                    context.RequisitionRecordDetails.Add(nd);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Materials Resource Planning (MRP) model processes    -    Always using the top priority supplier
        public void MRPInitialize(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                // Finding the week no for the year (aka our period currently)
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                //Uncomment for final ver: int currentPeriod = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                DateTime date1 = new DateTime(2018, 1, 2);
                int currentPeriod = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);


                // Init the diff tables to retrieve the required variables
                InventoryCatalogue item = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                SupplierCatalogue supCat = context.SupplierCatalogues.Where(x => x.ItemID.Equals(itemID)).Where(y => y.Priority == 1).First();
                SupplierList supp = context.SupplierLists.Where(x => x.SupplierID.Equals(supCat.SupplierID)).First();
                List<ForecastedData> prediction = context.ForecastedDatas.Where(x => x.ItemID.Equals(itemID)).Where(y => y.Season == DateTime.Now.Year).Where(z => z.Period > currentPeriod).ToList();


                // Declare all our req variables
                int existingQty = (int)item.UnitsInStock;
                int unitsOnOrder = (int)item.UnitsOnOrder;
                int reorderQty = (int)item.ReorderQty;    // aka min qty to make an order for the item
                int bufferStock = (int)item.BufferStockLevel;
                int orderLeadTime = (int)supp.OrderLeadTime;


                // Since our order of operations is in weeks, gotta convert order lead time to weeks (ideally would be in days tho so no need convert :P)
                int convertedOLT = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(orderLeadTime) / 7.0) + 1);     // We add '1' cos we are looking up to the week after it.

                // List to store our forecasted values according to their point of occurence
                List<int> forecastList = new List<int>();

                // Populating our list with the relevant forecasted value
                for (int i = 0; i < convertedOLT; i++)
                {
                    forecastList.Add(prediction[i].ForecastedDemand);
                }

                // Det the total expected demand up till our forcasting week
                int totalDd = 0;
                foreach (var d in forecastList)
                {
                    totalDd += d;
                }

                // Send an order request if incapable of supporting of meeting the forecasted demand for the week after next
                if (forecastList[forecastList.Count - 1] >= ((existingQty - bufferStock) - totalDd))
                {
                    // Det how much to order
                    int orderQty = (forecastList[forecastList.Count - 1] - ((existingQty - bufferStock) - totalDd));

                    ReorderRecord r = new ReorderRecord();
                    r.ItemID = itemID;
                    r.SupplierID = supCat.SupplierID;

                    if (orderQty > reorderQty)
                    {
                        r.OrderedQuantity = orderQty;
                    }
                    else   // If unable to satisfy the minimum qty in order to make an order for the item, must use the min qty instead lol
                    {
                        r.OrderedQuantity = reorderQty;
                    }

                    context.ReorderRecords.Add(r);
                    context.SaveChanges();
                }
                // If able to meet the demand, then no need do anything liao :)
            }
        }

        // Retrieve RRDetails that are relevant to the inventory retrieval process
        public static List<RequisitionRecordDetail> GetRelevantDetailList()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {

                List<RequisitionRecordDetail> tempListDetails = new List<RequisitionRecordDetail>();
                List<int> currentReqIDs = new List<int>();
                List<RequisitionRecord> tempReqList = new List<RequisitionRecord>();

                // Retrieve all the req IDs of all current requisition orders
                tempReqList = RequisitionLogic.ListCurrentRequisitionRecord();

                foreach (var item in tempReqList)
                {
                    currentReqIDs.Add(item.RequestID);
                }


                // Retrieve list of all the chosen req details
                foreach (var item in currentReqIDs)
                {
                    tempListDetails.AddRange(RequisitionLogic.RetrieveRequisitionRecordDetails(item, "Approved"));
                }

                return tempListDetails;
            }
        }

        // Building our custom item list for inventory retrieval process
        public static List<InventoryCatalogue> GetRelevantItemList(List<RequisitionRecordDetail> tempListDetails)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<InventoryCatalogue> tempListItems = new List<InventoryCatalogue>();

                // From our details list, extract its itemID and retrieve the list of items
                foreach (var item1 in tempListDetails)
                {
                    bool check = false;

                    // Check if there is a similar item in tempListItems
                    foreach (var item2 in tempListItems)
                    {
                        if (item2.ItemID == item1.ItemID)
                        {
                            check = true;
                            break;
                        }
                    }

                    // only add if there are no similar item in the list
                    if (check == false)
                    {
                        tempListItems.Add(FindItemByItemID(item1.ItemID));
                    }
                }
                return tempListItems;
            }
        }

        // Calculating the total qty needed per item for inventory retrieval
        public static int GetTotalQtyNeeded(string itemID)
        {
            List<RequisitionRecordDetail> tempListDetails = GetRelevantDetailList();
            int tqNeeded = 0;

            // Taking the requested quantity only for those selected items
            foreach (var item in tempListDetails)
            {
                if (item.ItemID == itemID)
                {
                    tqNeeded += Convert.ToInt32(item.RequestedQuantity);
                }
            }
            return tqNeeded;
        }

        // Segregating our per item for retrieval by dept and generating the tempList
        public static List<TempInventoryRetrieval> RetrieveTempInventoryList(string itemID)
        {
            // Intialize our list
            List<RequisitionRecordDetail> tempList = new List<RequisitionRecordDetail>();
            List<TempInventoryRetrieval> ti = new List<TempInventoryRetrieval>();

            int totalAct = 0;

            // Creating our ReqRecord list that is relevant to this "main" row.
            foreach (var item in GetRelevantDetailList())
            {
                if (item.ItemID == itemID)
                {
                    tempList.Add(RequisitionLogic.FindRequisitionRecordDetails(item.RequestDetailID));
                }
            }

            // Creating our TempInvRetrieval list with the needed quantities
            ti = RequisitionLogic.CreateTempList(tempList, itemID);

            // Setting the appropriate isOverride value for each item using to diff sets of foreach
            // This takes the overall qty requested per item (combines all relevant req together) and compares it to the existing inventory
            foreach (var item in ti)
            {
                totalAct += item.ActualQty;
            }
            foreach (var item in ti)
            {
                if (totalAct <= GetQuantity(itemID))
                {
                    item.IsOverride = true;
                }
                else
                {
                    item.IsOverride = false;
                }
            }

            return ti;
        }




































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































        //----Thanisha-------------------------View Stock Card details-----------------------------------------------//
        //------------------------------getting stock card details(ItemID,Date of transaction,Description,UOM,transaction type,quantity,balance)-------------//

        public List<Object> GetStockCardList(string itemid)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                var q = entity.StockCards.
                Select(x => new { x.ItemID, x.Date, x.Description, x.Type, x.Quantity, x.Balance }).Where(x => x.ItemID == itemid);
                List<Object> sList = q.ToList<Object>();
                return sList;
            }
        }
        //------------------------get all stockcarditems----------------------------------------//
        public List<Object> GetAllStockCardList()
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                var q = entity.StockCards.
                Select(x => new { x.ItemID, x.Date, x.Description, x.Type, x.Quantity, x.Balance });
                List<Object> sList = q.ToList<Object>();
                return sList;
            }
        }

        public List<StockCard> GetAllStockCard()
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                     return entity.StockCards.ToList<StockCard>();
            }
        }
        public List<StockCard> GetStockcardByItemId(string id)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.StockCards.Where(x => x.ItemID == id).ToList<StockCard>();
            }
        }

        //-------------------------(BIN,Description,UOM)------------------------------//
        public InventoryCatalogue getInventoryDetails(string itemid)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.InventoryCatalogues.Where(s => s.ItemID == itemid).ToList().First<InventoryCatalogue>();
            }
        }
        //-------------------------- (Supplier details)---------------------------------------//
        public List<SupplierCatalogue> getSCatalogueDetails(string itemid)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.SupplierCatalogues.Where(s => s.ItemID == itemid).ToList<SupplierCatalogue>();
            }
        }




        //-------------------------------------------------View InventoryList-----------------------------------------//

        //-----------------------------------get Catalogue Name in  dropdown list---------------------------//
        public List<CatalogueCategory> getCatalogue()
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.CatalogueCategories.ToList<CatalogueCategory>();
            }
        }

        //-----------------------------------get inventory catalogue record based on itemcode in gridview---------------------------//
        public List<InventoryCatalogue> getInventoryByItemcode(string itemcode)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.InventoryCatalogues.Where(x => x.ItemID == itemcode).ToList<InventoryCatalogue>();
            }
        }

        public List<InventoryCatalogue> getInventoryByCatagory(string catagory)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                CatalogueCategory catalogue = getCatalogue(catagory);
                return entity.InventoryCatalogues.Where(x => x.CategoryID == catalogue.CategoryID).ToList<InventoryCatalogue>();
            }
        }
        public List<InventoryCatalogue> GetAllCatalogue()
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.InventoryCatalogues.ToList<InventoryCatalogue>();
            }
        }
        public CatalogueCategory getCatalogue(string catagory)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.CatalogueCategories.Where(x => x.CatalogueName == catagory).First<CatalogueCategory>();

            }
        }

        public static List<InventoryCatalogue> GetInventoryByIdandCategory(string id,string category)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                CatalogueCategory cat = entity.CatalogueCategories.Where(x => x.CatalogueName == category).ToList<CatalogueCategory>().First();
                string catId = cat.CategoryID;
                var q = (from di in entity.InventoryCatalogues
                             join de in entity.CatalogueCategories on di.CategoryID equals de.CategoryID
                             where di.ItemID == id && di.CategoryID == catId
                         select di);

                return q.ToList<InventoryCatalogue>();
            }
        }


            //---------------------------------AdjustmentVoucher--------------------------------------------------------//

            public static List<AVRequest> GetadvReq(string id)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.AVRequests.Where(x => x.HandledBy == id & x.Status == "Pending").ToList<AVRequest>();
            }
               
        }
        //--------------------Adjustment voucher request approval---status changes to approved-------//

        public static  void ApproveAvRequest(int id,string remarks)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                AVRequest avReq = entity.AVRequests.Where(x => x.AVRID == id).First<AVRequest>();
              List<AVRequestDetail> avReqDetail= entity.AVRequestDetails.Where(x => x.AVRID == id).ToList<AVRequestDetail>();

                //--------------------Iterating through each item in the adjustment voucher request to adjust the inventory stock------//
                for (int i = 0; i < avReqDetail.Count; i++)
                {
                    string type = avReqDetail[i].Type;
                    int quantity = (int)avReqDetail[i].Quantity;
                    string itemId = avReqDetail[i].ItemID;
                    string UOM = avReqDetail[i].UOM;
                    InventoryCatalogue inventory = entity.InventoryCatalogues.Where(X => X.ItemID == itemId).First<InventoryCatalogue>();
                    int stock = inventory.UnitsInStock;
                    string Stockcarddescription = "Stock Adjustment";
                    switch (type)
                    {

                        case ("Add"):
                            {
                                stock = stock + quantity;
                                break;
                            }
                        case ("Minus"):
                            {
                                stock = stock - quantity;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    inventory.UnitsInStock = stock;
                    entity.SaveChanges();
                    //-----------------------------add the transaction to stock card-----------------------------------//
                    CreatestockCard(itemId, DateTime.Today, Stockcarddescription, type, quantity, UOM, stock);

                }

                avReq.Status = "Approved";
                avReq.DateProcessed = DateTime.Today;
                avReq.Remarks = remarks;
                entity.SaveChanges();
            }
        }


        //---------------------------------------------Create stockCard-----------------------------------------------------

        public static void CreatestockCard(string itemid, DateTime transactionDate,string description,string type,int quantity,string uom,int balance)
        {
            using (SA45Team12AD entitiy = new SA45Team12AD())
            {
                StockCard stockcard = new StockCard
                {
                    ItemID= itemid,
                    Date= transactionDate,
                    Description= description,
                    Type= type,
                    Quantity= quantity,
                    UOM=uom,
                    Balance= balance

                };
                entitiy.StockCards.Add(stockcard);
                entitiy.SaveChanges();
              
            }
        }

        //--------------------Adjustment voucher request rejection---status changes to rejected-------//

        public static void RejectAvRequest(int id, string remarks)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                AVRequest avReq = entity.AVRequests.Where(x => x.AVRID == id).First<AVRequest>();
                avReq.Status = "Rejected";
                avReq.DateProcessed = DateTime.Today;
                avReq.Remarks = remarks;
                entity.SaveChanges();
            }
        }

        






        //---- Chang Siang
        public static string GetItemName(string ItemID)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.InventoryCatalogues.Where(x => x.ItemID == ItemID).Select(x => x.Description).First();
            }
        }

        //---- Update Inventory Quantity (Temporary Method until Khair's method is available)
        public void AddInventoryQuantity(int quantity, string itemID)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryCatalogue ic = ctx.InventoryCatalogues.Where(x => x.ItemID == itemID).First();
                ic.UnitsInStock += quantity;
                ctx.SaveChanges();
            }
        }

        public void MinusInventoryQuantity(int quantity, string itemID)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryCatalogue ic = ctx.InventoryCatalogues.Where(x => x.ItemID == itemID).First();
                ic.UnitsInStock -= quantity;
                ctx.SaveChanges();
            }
        }

        //---- Update Stock Card
        public void UpdateStockCard(string description, string itemID, DateTime date, string type, int quantity, string uom)
        {
            StockCard sc = new StockCard();
            sc.ItemID = itemID;
            sc.Date = date;
            sc.Description = description;
            sc.Type = type;
            sc.Quantity = quantity;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                int unitInStock = ctx.InventoryCatalogues.Where(x => x.ItemID == itemID).Select(x => x.UnitsInStock).First();
                switch (type)
                {
                    case ("Add"):
                        sc.Balance = unitInStock + quantity;
                        AddInventoryQuantity(quantity, itemID);
                        break;
                    case ("Minus"):
                        sc.Balance = unitInStock - quantity;
                        MinusInventoryQuantity(quantity, itemID);
                        break;
                }
                ctx.StockCards.Add(sc);
                ctx.SaveChanges();
            }
        }

        public static double GetInventoryPrice(string itemID)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return (double) ctx.SupplierCatalogues.Where(x => x.ItemID == itemID).Where(x => x.Priority == 1).Select(x => x.Price).FirstOrDefault();
            }
        }

        public static InventoryCatalogue GetInventoryItem(string itemID)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.InventoryCatalogues.FirstOrDefault(x => x.ItemID == itemID);
            }
        }

        public static int CreateAdjustmentVoucherRequest(string clerkName, DateTime dateRequested)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                AVRequest aVRequest = new AVRequest
                {
                    RequestedBy = clerkName,
                    DateRequested = dateRequested,
                    Status = "Pending"
                };
                ctx.AVRequests.Add(aVRequest);
                ctx.SaveChanges();             
                return aVRequest.AVRID;
            }
        }
        public static void CreateAdjustmentVoucherRequestDetails(int avrId, string itemId, string type, int quantity, string uom, string reason, double unitPrice)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                AVRequestDetail aVRequestDetail = new AVRequestDetail
                {
                    AVRID = avrId,
                    ItemID = itemId,
                    Type = type,
                    Quantity = quantity,
                    UOM = uom,
                    Reason = reason,
                    UnitPrice = unitPrice
                };
                ctx.AVRequestDetails.Add(aVRequestDetail);
                ctx.SaveChanges();
            }
        }

        public static AVRequest GetAdjustmentVoucherRequest(int avRId)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.AVRequests.FirstOrDefault(x => x.AVRID == avRId);
            }
        }

        public static List<AVRequest> GetListOfAdjustmentRequests()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.AVRequests.ToList();
            }
        }

        public static List<AVRequest> GetListOfAdjustmentRequests(string status)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.AVRequests.Where(x => x.Status == status).ToList();
            }
        }

        public static List<AVRequestDetail> GetAdjustmentVoucherDetailsList(int avRId)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.AVRequestDetails.Where(x => x.AVRID == avRId).ToList();
            }
        }

        public static int GetAdjustmentVoucherApproveID (int avRId)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.AdjustmentVouchers.Where(x => x.AVRID == avRId).Select(x => x.AVID).FirstOrDefault();
            }
        }

        public static bool CancelAdjustmentVoucherRequest(int avRId)
        {
            bool success = false;
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                AVRequest aVRequest = ctx.AVRequests.FirstOrDefault(x => x.AVRID == avRId);
                aVRequest.Status = "Cancelled";
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }

        public static void SendAdjRequentEmail(int avRId, bool isAbove250, string clerkName)
        {
            List<MembershipUser> userList = Utility.Utility.GetListOfMembershipUsers();
            string[] approveAuthList = isAbove250 ? Roles.GetUsersInRole("Manager") : Roles.GetUsersInRole("Supervisor");
            UpdateAdjustmentVoucherApprovingOfficer(avRId, isAbove250);
            foreach (string s in approveAuthList)
            {
                var User = userList.Find(x => x.UserName == s);

                using (EmailControl em = new EmailControl())
                {
                    em.NewAdjustmentVoucherRequestNotification(User.Email.ToString(), avRId.ToString(), clerkName);
                }
            }
        }

        private static void UpdateAdjustmentVoucherApprovingOfficer(int avRId, bool isAbove250)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                AVRequest avR = ctx.AVRequests.Where(x => x.AVRID == avRId).FirstOrDefault();
                avR.HandledBy = isAbove250 ? "Manager" : "Supervisor";
                ctx.SaveChanges();
            }
        }

        public static List<InventoryRetrievalList> GetListOfInventoryRetrival()
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.InventoryRetrievalLists.ToList();
            }

        }

        public static List<InventoryRetrievalList> GetListOfInventoryRetrival(string deptId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.InventoryRetrievalLists.Where(x => x.DepartmentID == deptId).Where(x => x.Status == "fulfilled" || x.Status == "unfulfilled").ToList();
            }
        }

        public static bool UpdateInventoryRetrivalStatus(int retrievalId, string status)
        {
            bool success = false;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryRetrievalList iRL = ctx.InventoryRetrievalLists.Where(x => x.RetrievalID == retrievalId).FirstOrDefault();
                iRL.Status = status;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }


        public static bool LessUnitsOnOrder(string itemId, int quantity)          
        {
            bool success = false;
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryCatalogue ic = ctx.InventoryCatalogues.Where(x => x.ItemID == itemId).FirstOrDefault();
                ic.UnitsOnOrder -= quantity;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }

        public static bool UpdateUnitsOnOrder(string itemId, int quantity)
        {
            bool success = false;
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryCatalogue ic = ctx.InventoryCatalogues.Where(x => x.ItemID.Equals(itemId)).FirstOrDefault();
                ic.UnitsOnOrder += quantity;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }
      
        public static bool IsUnitsInStock(string itemId, int quantity)
        {
            bool isInStock = true;
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                InventoryCatalogue ic = ctx.InventoryCatalogues.Where(x => x.ItemID == itemId).FirstOrDefault();
                if(ic.UnitsInStock < quantity)
                {
                    isInStock = false;
                    return isInStock;
                }
            }
            return isInStock;
        }
    }
}