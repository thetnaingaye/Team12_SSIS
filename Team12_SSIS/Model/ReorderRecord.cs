namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReorderRecord
    {
        [Key]
        public int ReorderID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierID { get; set; }

        public int? OrderedQuantity { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }

        public virtual SupplierList SupplierList { get; set; }
    }
}
