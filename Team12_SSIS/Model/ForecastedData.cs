namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ForecastedData")]
    public partial class ForecastedData
    {
        [Key]
        public int FID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public int Season { get; set; }

        public int Period { get; set; }

        public int ForecastedDemand { get; set; }

        public int? Low80 { get; set; }

        public int? High80 { get; set; }

        public int? Low95 { get; set; }

        public int? High95 { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
