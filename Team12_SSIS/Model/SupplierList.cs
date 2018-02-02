namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplierList")]
    public partial class SupplierList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierList()
        {
            PORecords = new HashSet<PORecord>();
            ReorderRecords = new HashSet<ReorderRecord>();
            SupplierCatalogues = new HashSet<SupplierCatalogue>();
        }

        [Key]
        [StringLength(50)]
        public string SupplierID { get; set; }

        [StringLength(255)]
        public string SupplierName { get; set; }

        [StringLength(255)]
        public string GSTRegistrationNo { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        public int? PhoneNo { get; set; }

        public int? FaxNo { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int? OrderLeadTime { get; set; }

        [StringLength(50)]
        public string Discontinued { get; set; }

        public string EmailAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORecord> PORecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReorderRecord> ReorderRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCatalogue> SupplierCatalogues { get; set; }
    }
}
