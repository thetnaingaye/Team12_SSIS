﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Yishu Line 15 to 315
    //Khair Line 316 to 616
    //Naing Line 617 to 917
    //Thanisha 1218 to 1518
    //Chang Siang Line 1519 to 1820
    public class InventoryLogic
    {






















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































        //----Thanisha-------------------------View Stock Card details-----------------------------------------------//
        //------------------------------getting stock card details(ItemID,Date of transaction,Description,UOM,transaction type,quantity,balance)-------------//

        public List<Object> getStockCardList(string itemid)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                var q = entity.StockCards.
                Select(x => new { x.ItemID, x.Date, x.Description, x.Type, x.Quantity, x.Balance }).Where(x => x.ItemID == itemid);
                List<Object> sList = q.ToList<Object>();
                return sList;
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
        public CatalogueCategory getCatalogue(string catagory)
        {
            using (SA45Team12AD entity = new SA45Team12AD())
            {
                return entity.CatalogueCategories.Where(x => x.CatalogueName == catagory).First<CatalogueCategory>();


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

        public int CreateAdjustmentVoucherRequest(string clerkName, DateTime dateRequested)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
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
        public void CreateAdjustmentVoucherRequestDetails(int avrId, string itemId, string type, int quantity, string uom, string reason, double unitPrice)
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
    }
}