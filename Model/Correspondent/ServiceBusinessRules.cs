using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceBusinessRules
    {
        public string? ConfigCode { get; set; } = string.Empty;
        public string? ServOrgCode { get; set; } = string.Empty;
        public string? CurCode { get; set; } = string.Empty;
        public string? ServCode { get; set; } = string.Empty;        
        public string OrgCode { get; set; } = SD.OrgCode;
        public string? PortalCode { get; set; } = "00001";
        public string? UserCode { get; set; } = string.Empty;
        public bool? AuthReqd { get; set; } = false;
        public bool? BypassGlobalSettings { get; set; } = false;
        public bool? BranchLevel { get; set; } = false;
        public decimal BrnchAmountLimit { get; set; } = 0;
        public bool IndividualBranchLimit { get; set; } = false;
        public bool HOLevel { get; set; } = false;
        public decimal AuthHOlimit { get; set; } = 0;
        public bool FundSetmntRequired { get; set; } 
        public bool ValidLedgerBal { get; set; } 
        public bool TransitRequired { get; set; } 
        public bool ChequeNo { get; set; } = false;
        public string ChequeNoSts { get; set; } = string.Empty;
        public bool BankList { get; set; }
        public bool BranchList { get; set; } 
        public bool TestKey { get; set; } = false;
        public string TestKeySts { get; set; } = string.Empty;
        public bool CancellationAllowed { get; set; } = false;
        public bool NoValueTrans { get; set; } = false;
        public bool BlockDecimal { get; set; } = false;
        public bool BlockLC { get; set; } = false;
        public bool BlockFC { get; set; } = false;
        public bool RateEditable { get; set; } = false;

        public bool BlockCorporate { get; set; } = false;
        public bool BlockIndividual { get; set; } = false;
        public bool ShowSameBank { get; set; } = false;
        public bool AgentBankList { get; set; } = false;
        public bool OnlineAMLNotRqd { get; set; } = false;
        public bool BankExpAccRqd { get; set; } = false;
        public bool BankDetails { get; set; } = false;
        public bool SpotRate { get; set; } = false;
        public bool NoExchvar { get; set; } = false;
        public bool DispClientRefno { get; set; } = false;
        public bool AvoidRoundOff { get; set; } = false;
        public bool ValidateAMCash { get; set; } = false;
        public bool SendSMS { get; set; } = false;
        public string SMSFrom { get; set; } = string.Empty;
        public bool BatchingRqd { get; set; } = false;
        public string BatchingOn { get; set; } = string.Empty;
        public bool PreDfndCustcode { get; set; } = false;
        public string PreDfndCustcodetxt { get; set; } = string.Empty;
        public bool DOBValidation { get; set; } = false;
        public string DOBYear { get; set; } = string.Empty;
        public string TranType { get; set; } = string.Empty;
        public string PayCode { get; set; } = string.Empty;
        public string CustSMS { get; set; } = string.Empty;
        public bool AgentCommission { get; set; } = false;
        public bool BranchAcntVal { get; set; } = false;
        public bool AutoClientRef { get; set; } = false;

    }
}
