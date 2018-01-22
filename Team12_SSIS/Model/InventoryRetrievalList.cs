namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryRetrievalList")]
    public partial class InventoryRetrievalList
    {
        [Key]
        public int RetrievalID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentID { get; set; }

        public int? RequestedQuantity { get; set; }

        public int? ActualQuantity { get; set; }

        public DateTime? DateRetrieved { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Department Department { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
