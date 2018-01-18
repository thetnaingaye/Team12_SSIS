namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplierCatalogue")]
    public partial class SupplierCatalogue
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public double? Price { get; set; }

        public int? Priority { get; set; }

        [StringLength(255)]
        public string UOM { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }

        public virtual SupplierList SupplierList { get; set; }
    }
}
