namespace Team12_SSIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DDelegateDetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentID { get; set; }

        [StringLength(255)]
        public string DepartmentHeadDelegate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Department Department { get; set; }
    }
}
