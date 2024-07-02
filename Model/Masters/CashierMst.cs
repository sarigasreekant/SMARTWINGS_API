using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class CashierMst
    {

        [StringLength(10)]
        public string? CashierCode { get; set; } = "";
      
        public string OrgCode { get; set; } = "00001";
        [Required]
        [StringLength(10)]


        public string BranchCode { get; set; }

        [Required]
        [StringLength(30)]

        public string CashierName { get; set; }

        [StringLength(20)]
        public string? UserId { get; set; } = "";
        public DateTime? CREATEDATE { get; set; } = System.DateTime.Now;
        [StringLength(5)]
        public string? ActiveFlg { get; set; } = "Y";
        [StringLength(5)]
        public string? STKEQVFLG { get; set; } = "";
        [StringLength(5)]
        public string? STKFXFLG { get; set; } = "";
        [StringLength(5)]
        public string? FUNCTIONFLG { get; set; } = "";
        [StringLength(20)]
        public string? CASHIERACNTCODE { get; set; } = "";
        [StringLength(20)]
        public string IDENTITYFLG { get; set; } = "";
        [StringLength(20)]
        public string? MAINCASHIER { get; set; } = "";
        [StringLength(20)]
        public string? EXESSACC { get; set; } = "";
    }
}
