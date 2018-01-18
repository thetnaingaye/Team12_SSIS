namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockCard")]
    public partial class StockCard
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string UOM { get; set; }

        public int? Balance { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
