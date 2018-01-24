namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActualData")]
    public partial class ActualData
    {
        [Key]
        public int AID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemID { get; set; }

        public int Season { get; set; }

        public int Period { get; set; }

        public int ActualDemand { get; set; }

        public virtual InventoryCatalogue InventoryCatalogue { get; set; }
    }
}
