namespace ForexModel
{
    public class ServiceProfileDTO
    {
        public string OrgCode { get; set; } = SD.OrgCode;
        public string BranchCode { get; set; } = "";
        public string CustCode { get; set; } = "";
        public string SerProfCode { get; set; } = "";
        public string BenefFullName { get; set; } = "";
        public string BenefCell1 { get; set; } = "";
        public string BenefAccountNo { get; set; } = "";
        public string? Relation { get; set; } = "";
        public string BenefNationCode { get; set; } = "";
        public string? BenefType { get; set; } = "I";
        public string BenefCountry { get; set; } = "";
       
        public string ServiceServiceCode { get; set; } = "";
        public string? ServiceName { get; set; } = "";
        public string BenefBankCode { get; set; } = "";
       
        public string BenefBankBranchCode { get; set; } = "";
        public string? UserCode { get; set; } = "";
        public DateTime? CreatedDate { get; set; }= DateTime.Now;
        public string? ActiveFlag { get; set; } = "Y";
    }
}
