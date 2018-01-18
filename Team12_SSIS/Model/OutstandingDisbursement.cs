namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutstandingDisbursement")]
    public partial class OutstandingDisbursement
    {
        public int ID { get; set; }

        public int DisbursementID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int? OutstandingQty { get; set; }

        public virtual DisbursementList DisbursementList { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
