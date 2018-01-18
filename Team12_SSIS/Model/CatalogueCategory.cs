namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatalogueCategory")]
    public partial class CatalogueCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatalogueCategory()
        {
            InventoryCatalogues = new HashSet<InventoryCatalogue>();
        }

        [Key]
        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(255)]
        public string CatalogueName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryCatalogue> InventoryCatalogues { get; set; }
    }
}
