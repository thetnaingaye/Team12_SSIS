namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PORecordDetail
    {
        public int ID { get; set; }

        public int PONumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string UOM { get; set; }

        public double? UnitPrice { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }

        public virtual PORecord PORecord { get; set; }
    }
}
