namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AVRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AVRequest()
        {
            AdjustmentVouchers = new HashSet<AdjustmentVoucher>();
            AVRequestDetails = new HashSet<AVRequestDetail>();
        }

        [Key]
        public int AVRID { get; set; }

        [StringLength(255)]
        public string RequestedBy { get; set; }

        public DateTime? DateRequested { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [StringLength(255)]
        public string HandledBy { get; set; }

        public DateTime? DateProcessed { get; set; }

        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjustmentVoucher> AdjustmentVouchers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVRequestDetail> AVRequestDetails { get; set; }
    }
}
