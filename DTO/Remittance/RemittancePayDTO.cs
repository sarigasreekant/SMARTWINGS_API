using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class RemittancePayDTO
    {
        public string PortalCode { get; set; } = "";
        public string OrgCode { get; set; } = "";
        public string MenuCode { get; set; } = "";
        public string RefNo { get; set; } = "";
        public string PayRefNo { get; set; } = "";
        public DateTime? TranDate { get; set; }
        public string UserCode { get; set; } = "";
        public string PayCode { get; set; } = "";
        public string AccountCode { get; set; } = "";
        public string PayCurCode { get; set; } = "";
        public decimal PayAmount { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal BalAmount { get; set; } = 0;

        public int Pay_ID { get; set; } = 0;
        public string PayCodeName { get; set; } = "";
        public string BankCode { get; set; } = "";
        public string BankName { get; set; } = "";
        public decimal CardCharge { get; set; } = 0;
        public DateTime? CheqDt { get; set; } = DateTime.Now;
        public decimal USDAmount { get; set; } = 0;

        public string PayCurName { get; set; } = "";
        public decimal USDBalAmount { get; set; } = 0;
        public bool IsDenoRqd { get; set; } = false;
        public decimal USDRate { get; set; } = 0;
        public bool IsUSDRqd { get; set; } = false;

        public decimal TotalDeno { get; set; } = 0;
        public decimal TotalDenoAmt { get; set; } = 0;
        public decimal TotalCash { get; set; } = 0;
        public decimal BalanceCashPay { get; set; } = 0;
    }
}
