using System.ComponentModel.DataAnnotations;

namespace SMARTWINGS_API.Model.Rate
{
    public class Journal
    {
        [StringLength(10)]
        public string ORGCODE { get; set; } = "00001";
        [StringLength(10)]
        public string BRANCHCODE { get; set; } = "";
        [Required]
        public DateTime TRANDATE { get; set; } = DateTime.Now;
        [Required]
        [StringLength(20)]
        public string JVDOCNO { get; set; } = "";
        [Required]
        [StringLength(7)]
        public string JVSERNO { get; set; } = "";
        [StringLength(15)]
        public string ACCCODE { get; set; } = "";
        [StringLength(300)]
        public string NARRATION { get; set; } = "";
        [StringLength(1)]
        public string TRANTYPE { get; set; } = "";
        [StringLength(20)]
        public string REFNO { get; set; } = "";
        public decimal RATE { get; set; } = 0;
        public decimal FXAMT { get; set; } = 0;
        public decimal EQUVAMT { get; set; } = 0;
        [StringLength(16)]
        public string CUSTCODE { get; set; } = "";
        [StringLength(10)]
        public string USERID { get; set; } = "";
        [Required]
        public int SERVTYPE { get; set; } = 0;
        [StringLength(1)]
        public string REVFLG { get; set; } = "N";
        [StringLength(5)]
        public string CASHIERCODE { get; set; } = "";
        public int ISCASHACNT { get; set; } = 0;
        public string AccountsName { get; set; } = "";
        public string BrachName { get; set; } = "";
    }
}
