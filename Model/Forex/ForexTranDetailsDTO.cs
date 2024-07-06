using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTranDetailsDTO
    {

        public string? OrgCode { get; set; }
        public string? Refno { get; set; }
        public string? Branchcode { get; set; }
        public string? SerNo { get; set; }
        public DateTime? Trandate { get; set; }
        public string? UserId { get; set; }
        public string? CashierCode { get; set; }
        public string? TranType { get; set; }
        public string? CurCode { get; set; }
        public decimal FxAmnt { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public decimal EquvAmnt { get; set; } = 0;
        public decimal Profit { get; set; } = 0;
        public decimal AvgRate { get; set; } = 0;
        public decimal CostRate { get; set; } = 0;
        public string? MinMax { get; set; }
        public int Slno { get; set; } = 0;
    }
}
