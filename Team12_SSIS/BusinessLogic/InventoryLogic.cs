using System;
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

    }
}