namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryCatalogue")]
    public partial class InventoryCatalogue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryCatalogue()
        {
            ActualDatas = new HashSet<ActualData>();
            AVRequestDetails = new HashSet<AVRequestDetail>();
            DisbursementListDetails = new HashSet<DisbursementListDetail>();
            ForecastedDatas = new HashSet<ForecastedData>();
            GoodReceiptDetails = new HashSet<GoodReceiptDetail>();
            InventoryRetrievalLists = new HashSet<InventoryRetrievalList>();
            OutstandingDisbursements = new HashSet<OutstandingDisbursement>();
            PORecordDetails = new HashSet<PORecordDetail>();
            ReorderRecords = new HashSet<ReorderRecord>();
            RequisitionRecordDetails = new HashSet<RequisitionRecordDetail>();
            StockCards = new HashSet<StockCard>();
            SupplierCatalogues = new HashSet<SupplierCatalogue>();
        }

        [Key]
        [StringLength(50)]
        public string ItemID { get; set; }

        [StringLength(255)]
        public string BIN { get; set; }

        [StringLength(255)]
        public string Shelf { get; set; }

        public int? Level { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? ReorderLevel { get; set; }

        public int UnitsInStock { get; set; }

        public int? ReorderQty { get; set; }

        [StringLength(255)]
        public string UOM { get; set; }

        [StringLength(255)]
        public string Discontinued { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? BufferStockLevel { get; set; }

        public int? BFSProportion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActualData> ActualDatas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVRequestDetail> AVRequestDetails { get; set; }

        public virtual CatalogueCategory CatalogueCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementListDetail> DisbursementListDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForecastedData> ForecastedDatas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodReceiptDetail> GoodReceiptDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryRetrievalList> InventoryRetrievalLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutstandingDisbursement> OutstandingDisbursements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORecordDetail> PORecordDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReorderRecord> ReorderRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionRecordDetail> RequisitionRecordDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockCard> StockCards { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCatalogue> SupplierCatalogues { get; set; }
    }
}
