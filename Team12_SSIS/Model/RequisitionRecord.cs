namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequisitionRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequisitionRecord()
        {
            RequisitionRecordDetails = new HashSet<RequisitionRecordDetail>();
        }

        [Key]
        public int RequestID { get; set; }

        public DateTime? RequestDate { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentID { get; set; }

        [StringLength(255)]
        public string RequestorName { get; set; }

        public DateTime? ApprovedDate { get; set; }

        [StringLength(255)]
        public string ApproverName { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionRecordDetail> RequisitionRecordDetails { get; set; }
    }
}
