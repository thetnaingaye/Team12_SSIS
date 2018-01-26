using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_StockCard
    {

        public static WCF_StockCard Create(int id, string itemId, string date, 
            string description, string type, int quantity, string uom, int balance)
        {
            WCF_StockCard s = new WCF_StockCard();
            s.ID = id;
            s.ItemID = itemId;
            s.Date = date;
            s.Description = description;
            s.Type = type;
            s.Quantity = quantity;
            s.UOM = uom;
            s.Balance = balance;
            return s;
        }

        public static WCF_StockCard Create(int id, string itemId, string date,
    string description, string type, int quantity, string uom, int balance, 
    WCF_InventoryCatalogue inventoryCatalogue)
        {
            WCF_StockCard s = new WCF_StockCard();
            s.ID = id;
            s.ItemID = itemId;
            s.Date = date;
            s.Description = description;
            s.Type = type;
            s.Quantity = quantity;
            s.UOM = uom;
            s.Balance = balance;
            s.WCF_InventoryCatalogue = inventoryCatalogue;
            return s;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string UOM { get; set; }
        [DataMember]
        public int Balance { get; set; }
        [DataMember]
        public virtual WCF_InventoryCatalogue WCF_InventoryCatalogue { get; set; }
    }
}