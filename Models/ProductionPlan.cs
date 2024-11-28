using System.ComponentModel.DataAnnotations.Schema;

namespace RencanaProduksiSoalDua.Models
{
    [Table("ProductionPlan")]
    public class ProductionPlan
    {
        public int Id { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public int? AdjustedMonday { get; set; }
        public int? AdjustedTuesday { get; set; }
        public int? AdjustedWednesday { get; set; }
        public int? AdjustedThursday { get; set; }
        public int? AdjustedFriday { get; set; }
        public int? AdjustedSaturday { get; set; }
        public int? AdjustedSunday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
