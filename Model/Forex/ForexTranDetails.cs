using System.ComponentModel.DataAnnotations;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTranDetails
    {

        [StringLength(10)]
        public string OrgCode { get; set; } = "00001";


        public string Refno { get; set; } = "";
        [StringLength(10)]
        public string Branchcode { get; set; } = "";

        [StringLength(26)]
        public string SerNo { get; set; } = "";
        public DateTime Trandate { get; set; } = DateTime.Now;

        [StringLength(26)]
        public string UserId { get; set; } = "";

        [StringLength(26)]
        public string CashierCode { get; set; } = "";
        [StringLength(10)]
        [Required]

        public string TranType { get; set; }

        [StringLength(10)]
        [Required]

        public string CurCode { get; set; }

        [Required]
        public decimal FxAmnt { get; set; }

        [Required]
        public decimal Rate { get; set; }
        [Required]
        public decimal EquvAmnt { get; set; }
        public decimal Profit { get; set; } = 0;
        public decimal AvgRate { get; set; } = 0;
        public decimal CostRate { get; set; } = 0;
        public string MinMax { get; set; } = "";
        public int Slno { get; set; } = 0;
        public string? BranchName { get; set; } = "";

    }
}
