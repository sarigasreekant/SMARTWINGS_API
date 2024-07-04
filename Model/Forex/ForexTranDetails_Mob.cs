using System.ComponentModel.DataAnnotations;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTranDetails_Mob
    {

        [StringLength(10)]
        public string OrgCode { get; set; } = "00001";


        public string Mob_Refno { get; set; } = "";

        public DateTime Trandate { get; set; } = DateTime.Now;


        public DateTime Pickup_Date { get; set; } = DateTime.Now;

        public DateTime Create_Date { get; set; } = DateTime.Now;

        public DateTime auth_date { get; set; } = DateTime.Now;


        [StringLength(26)]
        public string UserId { get; set; } = "";

        [StringLength(26)]
        public string Custcode { get; set; } = "";

        [StringLength(26)]
        public string CashierCode { get; set; } = "";
        [StringLength(10)]
        [Required]

        public string TranType { get; set; }
        [StringLength(10)]
        [Required]

        public string auth_flag { get; set; }
        [StringLength(10)]
        [Required]

        public string Paidflg { get; set; }
        [StringLength(10)]
        [Required]

        public string Activeflg { get; set; }

        [StringLength(10)]
        [Required]

        public string CurCode { get; set; }
        [StringLength(10)]
        [Required]

        public string auth_branch { get; set; }
        [StringLength(10)]
        [Required]

        public string auth_user { get; set; }

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
