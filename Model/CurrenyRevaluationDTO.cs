using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CurrenyRevaluationDTO
    {
        public string currencyname { get; set; } = "";
        public string Curcode { get; set; } = "";
        public string BranchCode { get; set; } = "";
        public string CashierCode { get; set; } = "";
        public string UserId { get; set; } = "";
        public decimal fcyAmount { get; set; } = 0;
        public decimal lcyAmount { get; set; } = 0;
        public decimal RevalRate { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public decimal Profit { get; set; } = 0;
        public decimal Total { get; set; } = 0;
    }
}
