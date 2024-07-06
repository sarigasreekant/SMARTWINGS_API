using ForexModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceAccounts
    {
        public string? ConfigCode { get; set; } = string.Empty;
        public string? ServOrgCode { get; set; } = string.Empty;
        public string? CurCode { get; set; } = string.Empty;
        public string? ServCode { get; set; } = string.Empty;
        public string OrgCode { get; set; } = SD.OrgCode;
        public string? PortalCode { get; set; } = "00001";
        public string? UserCode { get; set; } = "admin";

        public string ServName { get; set; } = string.Empty;
        public string ServOrgName { get; set; } = string.Empty;
        public string CurName { get; set; } = string.Empty;
        public string ShortLedgerName { get; set; } = string.Empty;
        public string LedgerCurCode { get; set; } = string.Empty;
        public bool CommCurwise { get; set; } = false;
        public bool ExchCurwise { get; set; } = false;
        public bool ChangeLedger { get; set; } = false;
        public string LedgerCurrency { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string BankNo { get; set; } = string.Empty;
        public string SwiftCode { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; } = 0;
        public string LedgerAC { get; set; } = string.Empty;
        public string TransitAC { get; set; } = string.Empty;
        public string CommisionAC { get; set; } = string.Empty;
        public string BankChargeAC { get; set; } = string.Empty;
        public string ExVariationAC { get; set; } = string.Empty;
        public string AccruedAC { get; set; } = string.Empty;
        public string SettlementAC { get; set; } = string.Empty;
        public string SettleService { get; set; } = string.Empty;
        public string SettleCurCode { get; set; } = string.Empty;
        public bool PostToSettAC { get; set; } = false;
        public string SettlementACName { get; set; } = string.Empty;

        public string LedgerACName { get; set; } = string.Empty;
        public string TransitACName { get; set; } = string.Empty;
        public string CommisionACName { get; set; } = string.Empty;
        public string BankChargeACName { get; set; } = string.Empty;
        public string ExVariationACName { get; set; } = string.Empty;
        public string AccruedACName { get; set; } = string.Empty;
        public int OrgType { get; set; } = 0;
    }
}
