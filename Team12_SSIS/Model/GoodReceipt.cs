namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoodReceipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodReceipt()
        {
            GoodReceiptDetails = new HashSet<GoodReceiptDetail>();
        }

        [Key]
        public int GRNumber { get; set; }

        public int PONumber { get; set; }

        public DateTime? DateProcessed { get; set; }

        [StringLength(255)]
        public string ReceivedBy { get; set; }

        [Required]
        [StringLength(255)]
        public string DONumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodReceiptDetail> GoodReceiptDetails { get; set; }

        public virtual PORecord PORecord { get; set; }
    }
}
