namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequisitionRecordDetail
    {
        [Key]
        public int RequestDetailID { get; set; }

        public int RequestID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public int? RequestedQuantity { get; set; }

        public string Status { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }

        public virtual RequisitionRecord RequisitionRecord { get; set; }
    }
}
