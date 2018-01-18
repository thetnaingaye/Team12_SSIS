namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AVRequestDetail
    {
        public int ID { get; set; }

        public int AVRID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string UOM { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        public double? UnitPrice { get; set; }

        public virtual AVRequest AVRequest { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
