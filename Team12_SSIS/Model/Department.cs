namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            DDelegateDetails = new HashSet<DDelegateDetail>();
            DisbursementLists = new HashSet<DisbursementList>();
            InventoryRetrievalLists = new HashSet<InventoryRetrievalList>();
            RequisitionRecords = new HashSet<RequisitionRecord>();
        }

        [Key]
        [StringLength(50)]
        public string DeptID { get; set; }

        [StringLength(255)]
        public string DepartmentName { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        public int? TelephoneNo { get; set; }

        public int? FaxNo { get; set; }

        [StringLength(255)]
        public string DeptHeadName { get; set; }

        public int HasDelegate { get; set; }

        [StringLength(255)]
        public string RepresentativeName { get; set; }

        public int CollectionPointID { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DDelegateDetail> DDelegateDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementList> DisbursementLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryRetrievalList> InventoryRetrievalLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionRecord> RequisitionRecords { get; set; }
    }
}
