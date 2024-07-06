using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class LocalBank
    {
        [Required(ErrorMessage ="Select Bank")]
        public string BankCode { get; set; } 
        public string? BankName { get; set; } = "";
        [Required(ErrorMessage ="Select Currency")]
        public string CurCode { get; set; } 
        public string? BankLedgerName { get; set; } = "";
        public string BankLedgerCode { get; set; } = "";
        public string? BankchargeAcccount { get; set; } = "";
    }
}
