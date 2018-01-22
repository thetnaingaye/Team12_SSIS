using System;
using System.Collections.Generic;
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

        public static void DeleteCatalogue(string ItemID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue catalogue = entities.InventoryCatalogues.Where(c => c.ItemID == ItemID).First<InventoryCatalogue>();
                entities.InventoryCatalogues.Remove(catalogue);
                entities.SaveChanges();
            }
        }

        public static void UpdateCatalogue(string ItemID, string Description, int ReorderLevel, int ReorderQty, string UOM)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue catalogue = entities.InventoryCatalogues.Where(c => c.ItemID == ItemID).First<InventoryCatalogue>();
                catalogue.Description = Description;
                catalogue.ReorderLevel = ReorderLevel;
                catalogue.ReorderQty = ReorderQty;
                catalogue.UOM = UOM;
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

        public static void AddCatalogue(string ItemID, string CategoryID, string Description, int ReorderLevel, int ReorderQty, string UOM)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                InventoryCatalogue inventoryCatalogue = new InventoryCatalogue();
                inventoryCatalogue.ItemID = ItemID;
                inventoryCatalogue.CategoryID = CategoryID;
                inventoryCatalogue.Description = Description;
                inventoryCatalogue.ReorderLevel = ReorderLevel;
                inventoryCatalogue.ReorderQty = ReorderQty;
                inventoryCatalogue.UOM = UOM;
                entities.InventoryCatalogues.Add(inventoryCatalogue);
                entities.SaveChanges();
            }
        }

        public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.CategoryID.Contains(value)).ToList();
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
            using(SA45Team12AD ctx = new SA45Team12AD())
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

        public int CreateAdjustmentVoucherRequest(string clerkName, DateTime dateRequested)
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

        public void SendAdjRequentEmail(int avRId, bool isAbove250, string clerkName)
        {
            List<MembershipUser> userList = Utility.Utility.GetListOfMembershipUsers();
            string[] approveAuthList = isAbove250 ? Roles.GetUsersInRole("Manager") : Roles.GetUsersInRole("Supervisor");
            foreach (string s in approveAuthList)
            {
                var User = userList.Find(x => x.UserName == s);

                using (EmailControl em = new EmailControl())
                {
                    em.NewAdjustmentVoucherRequestNotification(User.Email.ToString(), avRId.ToString(), clerkName);
                }
            }

        }
    }
}

























