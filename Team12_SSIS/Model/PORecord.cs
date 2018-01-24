namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PORecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PORecord()
        {
            GoodReceipts = new HashSet<GoodReceipt>();
            PORecordDetails = new HashSet<PORecordDetail>();
        }

        [Key]
        public int PONumber { get; set; }

        public DateTime? DateRequested { get; set; }

        [StringLength(255)]
        public string RecipientName { get; set; }

        [StringLength(255)]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierID { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime? DateProcessed { get; set; }

        public DateTime? ExpectedDelivery { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [StringLength(255)]
        public string HandledBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodReceipt> GoodReceipts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORecordDetail> PORecordDetails { get; set; }

        public virtual SupplierList SupplierList { get; set; }
    }
}
