namespace Team12_SSIS.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SA45Team12AD : DbContext
    {
        public SA45Team12AD()
            : base("name=SA45Team12AD")
        {
        }

        public virtual DbSet<ActualData> ActualDatas { get; set; }
        public virtual DbSet<AdjustmentVoucher> AdjustmentVouchers { get; set; }
        public virtual DbSet<AVRequestDetail> AVRequestDetails { get; set; }
        public virtual DbSet<AVRequest> AVRequests { get; set; }
        public virtual DbSet<CatalogueCategory> CatalogueCategories { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<DDelegateDetail> DDelegateDetails { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DisbursementList> DisbursementLists { get; set; }
        public virtual DbSet<DisbursementListDetail> DisbursementListDetails { get; set; }
        public virtual DbSet<ForecastedData> ForecastedDatas { get; set; }
        public virtual DbSet<GoodReceiptDetail> GoodReceiptDetails { get; set; }
        public virtual DbSet<GoodReceipt> GoodReceipts { get; set; }
        public virtual DbSet<InventoryCatalogue> InventoryCatalogues { get; set; }
        public virtual DbSet<InventoryRetrievalList> InventoryRetrievalLists { get; set; }
        public virtual DbSet<OutstandingDisbursement> OutstandingDisbursements { get; set; }
        public virtual DbSet<PORecordDetail> PORecordDetails { get; set; }
        public virtual DbSet<PORecord> PORecords { get; set; }
        public virtual DbSet<ReorderRecord> ReorderRecords { get; set; }
        public virtual DbSet<RequisitionRecordDetail> RequisitionRecordDetails { get; set; }
        public virtual DbSet<RequisitionRecord> RequisitionRecords { get; set; }
        public virtual DbSet<StockCard> StockCards { get; set; }
        public virtual DbSet<SupplierCatalogue> SupplierCatalogues { get; set; }
        public virtual DbSet<SupplierList> SupplierLists { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AVRequest>()
                .HasMany(e => e.AdjustmentVouchers)
                .WithRequired(e => e.AVRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AVRequest>()
                .HasMany(e => e.AVRequestDetails)
                .WithRequired(e => e.AVRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogueCategory>()
                .HasMany(e => e.InventoryCatalogues)
                .WithRequired(e => e.CatalogueCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CollectionPoint>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.CollectionPoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CollectionPoint>()
                .HasMany(e => e.DisbursementLists)
                .WithRequired(e => e.CollectionPoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.DDelegateDetails)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.DisbursementLists)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.InventoryRetrievalLists)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.RequisitionRecords)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DisbursementList>()
                .HasMany(e => e.DisbursementListDetails)
                .WithRequired(e => e.DisbursementList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DisbursementList>()
                .HasMany(e => e.OutstandingDisbursements)
                .WithRequired(e => e.DisbursementList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoodReceipt>()
                .HasMany(e => e.GoodReceiptDetails)
                .WithRequired(e => e.GoodReceipt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.ActualDatas)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.AVRequestDetails)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.DisbursementListDetails)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.ForecastedDatas)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.GoodReceiptDetails)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.InventoryRetrievalLists)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.OutstandingDisbursements)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.PORecordDetails)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.ReorderRecords)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.RequisitionRecordDetails)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.StockCards)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCatalogue>()
                .HasMany(e => e.SupplierCatalogues)
                .WithRequired(e => e.InventoryCatalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PORecord>()
                .HasMany(e => e.GoodReceipts)
                .WithRequired(e => e.PORecord)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PORecord>()
                .HasMany(e => e.PORecordDetails)
                .WithRequired(e => e.PORecord)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequisitionRecord>()
                .HasMany(e => e.RequisitionRecordDetails)
                .WithRequired(e => e.RequisitionRecord)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierList>()
                .HasMany(e => e.PORecords)
                .WithRequired(e => e.SupplierList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierList>()
                .HasMany(e => e.ReorderRecords)
                .WithRequired(e => e.SupplierList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierList>()
                .HasMany(e => e.SupplierCatalogues)
                .WithRequired(e => e.SupplierList)
                .WillCascadeOnDelete(false);
        }
    }
}
