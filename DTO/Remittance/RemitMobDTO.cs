namespace ForexModel
{
    public class RemitMobDTO
    {
        public string OrgCode { get; set; } = SD.OrgCode;
        public string? BranchCode { get; set; } = "00000";
        public string RefNo { get; set; } = "";
        public string ServiceServiceName { get; set; } = "";
        public string ServiceServiceCode { get; set; } = "";
        public string ServiceCurrency { get; set; } = "";
        public string ServiceCurrencyCode { get; set; } = "";

        public string CustCode { get; set; } = "";
        public string BenefFullName { get; set; } = "";
        public string BenefCell1 { get; set; } = "";
        public string BenefBankCode { get; set; } = "";
        public string BenefBankName { get; set; } = "";
        public string BenefBankBranchCode { get; set; } = "";
        public string BenefBankBranchName { get; set; } = "";
        public string BenefAccountNo { get; set; } = "";
        
        public string BenefNationCode { get; set; } = "";
        public string BenefNationality { get; set; } = "";
       
        public string BenefConcode { get; set; } = "";
        public string BenefCountry { get; set; } = "";
        public decimal FcyAmount { get; set; } = 0;
        public string? PayMode { get; set; } = "";
        public string PaidFlag { get; set; } = "N";
        public string UserId { get; set; } = "";
        public DateTime Trandate { get; set; } = System.DateTime.Now;
        public string Purpose { get; set; } = "";
        public string Source { get; set; } = "";
        public string OfferCode { get; set; } = "";
    }
}
