using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_InventoryCatalogue
    {
        public static WCF_InventoryCatalogue Create
            (string itemId, string bin, string shelf, int level, 
            string categoryId, string description, int reOrderLvl, int unitInStock,
            int reOrderQty, string uom, string discontinued, int unitOnOrder, int bufferStockLevel)
        {
            WCF_InventoryCatalogue w = new WCF_InventoryCatalogue();
            w.ItemID = itemId;
            w.BIN = bin;
            w.Shelf = shelf;
            w.Level = level;
            w.CategoryID = categoryId;
            w.Description = description;
            w.ReorderLevel = reOrderLvl;
            w.UnitsInStock = unitInStock;
            w.ReorderQty = reOrderLvl;
            w.UOM = uom;
            w.Discontinued = discontinued;
            w.UnitsOnOrder = unitOnOrder;
            w.BufferStockLevel = bufferStockLevel;
            return w;
        }


        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public string BIN { get; set; }

        [DataMember]
        public string Shelf { get; set; }
        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public string CategoryID { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ReorderLevel { get; set; }
        [DataMember]
        public int UnitsInStock { get; set; }
        [DataMember]
        public int ReorderQty { get; set; }
        [DataMember]
        public string UOM { get; set; }
        [DataMember]
        public string Discontinued { get; set; }
        [DataMember]
        public int UnitsOnOrder { get; set; }
        [DataMember]
        public int BufferStockLevel { get; set; }
    }
}