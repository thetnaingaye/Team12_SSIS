namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DisbursementList")]
    public partial class DisbursementList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisbursementList()
        {
            DisbursementListDetails = new HashSet<DisbursementListDetail>();
            OutstandingDisbursements = new HashSet<OutstandingDisbursement>();
        }

        [Key]
        public int DisbursementID { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentID { get; set; }

        public int CollectionPointID { get; set; }

        public DateTime? CollectionDate { get; set; }

        [StringLength(255)]
        public string RepresentativeName { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementListDetail> DisbursementListDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutstandingDisbursement> OutstandingDisbursements { get; set; }
    }
}
