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
        public WCF_InventoryCatalogue()
        {
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