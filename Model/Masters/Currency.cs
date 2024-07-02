using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class Currency
    {
        [Required]
        [StringLength(7)]
        public string CurCode { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string CurrencyName { get; set; } = "";
        public int? CurDecimal { get; set; } = 2;
        [StringLength(50)]
        public string? Groupcountry { get; set; } 
        [StringLength(3)]
        public string? Display { get; set; } = "Y";
        [StringLength(50)]
        public string? CBCurcode { get; set; } = "";
        [StringLength(10)]
        public string? OTCurocde { get; set; } = "";
        public string? RateMaskM { get; set; } = "";
        public string? RateMaskD { get; set; } = "";
        public string? RateFactor { get; set; } = "D";
        public string? Activeflag { get; set; } = "Y";
        public string? ShowRatesheet { get; set; } = "Y";
        public string LedgerAccode { get; set; } = "";
        public string TransitAccode { get; set; } = "";
        public string ExchangeVariAccode { get; set; } = "";
        public string DealingAccode { get; set; } = "";
    }
}