namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdjustmentVoucher")]
    public partial class AdjustmentVoucher
    {
        [Key]
        public int AVID { get; set; }

        public int AVRID { get; set; }

        public DateTime? Date { get; set; }

        public virtual AVRequest AVRequest { get; set; }
    }
}
