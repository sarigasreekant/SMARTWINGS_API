using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class Remittance
    {
        public string OrgCode { get; set; } = SD.OrgCode;
        public string BranchCode { get; set; } = "";
        public string RefNo { get; set; } = "";
        public string TTNo { get; set; } = "";
        public string ServiceCountry { get; set; } = "";
        public string ServiceCountryCode { get; set; } = "";
        public string ServiceCurrency { get; set; } = "";
        public string ServiceCurrencyCode { get; set; } = "";
        public string ServiceServiceName { get; set; } = "";
        public string ServiceServiceCode { get; set; } = "";    
        public string ServiceCorresOrgcode { get; set; } = "";
        public string ServiceCorresName { get; set; } = "";
        public string CorrCode { get; set; }
        public string CustCode { get; set; } = "";
        public string CustType { get; set; } = "I";
        public string Name1 { get; set; } = "";
        public string Name2 { get; set; } = "";
        public string Name3 { get; set; } = "";
        public string Name4 { get; set; } = "";
        public string Cell1 { get; set; } = ""; 
        public string Cell2 { get; set; } = "";             
        public string Phone { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime? Dob { get; set; } 
        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Place { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string Country { get; set; } = "";
        public string Pobox { get; set; } = "";
        public string Nationcode { get; set; } = "";
        public string Nationality { get; set; } = "";
        public string Profession { get; set; } = "";
        public string Mail { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Company { get; set; } = "";
        public string Photo { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string IdType { get; set; } = "";
        public string IdNo { get; set; } = "";
        public DateTime? IssueDate { get; set; } 
        public DateTime? ExpDate { get; set; } 
        public string Issueplace { get; set; } = "";
        public string IdIssueCountry { get; set; } = "";
        public string IdImageFront { get; set; } = "";
        public string IdImageBack { get; set; } = "";
        public string OtherDocument1 { get; set; } = "";
        public string OtherDocument2 { get; set; } = "";
        public string IssueContcode { get; set; } = "";
        public string IdRemarks { get; set; } = "";
        public int SerProfCode { get; set; } = 0;
        public string BenefName1 { get; set; } = "";
        public string BenefName2 { get; set; } = "";
        public string BenefName3 { get; set; } = "";
        public string BenefName4 { get; set; } = "";
        public string BenefCell1 { get; set; } = "";
        public string BenefCell2 { get; set; } = "";
        public string BenefPhone { get; set; } = "";
        public string BenefGender { get; set; } = "";
        public DateTime? BenefDob { get; set; } 
        public string BenefAddress1 { get; set; } = "";
        public string BenefAddress2 { get; set; } = "";
        public string BenefPlace { get; set; } = "";
        public string BenefStreet { get; set; } = "";
        public string BenefCity { get; set; } = "";
        public string BenefState { get; set; } = "";
        public string BenefConcode { get; set; } = "";
        public string BenefCountry { get; set; } = "";
        public string BenefPobox { get; set; } = "";
        public string BenefNationCode { get; set; } = "";
        public string BenefNationality { get; set; } = "";
        public string BenefProfession { get; set; } = "";
        public string BenefMail { get; set; } = "";
        public string BenefFax { get; set; } = "";
        public string BenefIdType { get; set; } = "";
        public string BenefIdNo { get; set; } = "";
        public string BenefBankCode { get; set; } = "";
        public string BenefBankName { get; set; } = "";
        public string BenefBankBranchCode { get; set; } = "";
        public string BenefBankBranchName { get; set; } = "";
        public string BenefIFSC { get; set; } = "";
        public string BenefAccountNo { get; set; } = "";
        public string BenfBankAddress { get; set; } = "";
        public string BenefBankCity { get; set; } = "";
        public string BenfRemarks { get; set; } = "";
        public decimal FcyAmount { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public decimal LcyAmount { get; set; } = 0;
        public decimal CommUSD { get; set; } = 0;
        public decimal CommLcy { get; set; } = 0;
        public decimal TaxUSD { get; set; } = 0;
        public decimal TaxLcy { get; set; } = 0;
        public decimal OtherTaxUSD { get; set; } = 0;
        public decimal OtherTaxLcy { get; set; } = 0;
        public decimal TotalUSD { get; set; } = 0;
        public decimal TotalLcy { get; set; } = 0;
        public decimal USDRate { get; set; } = 0;
        public decimal CostRate { get; set; } = 0;
        public decimal OriginalSellRate { get; set; } = 0;
        public decimal MinSellRate { get; set; } = 0;
        public decimal MaxSellRate { get; set; } = 0;
        public decimal MinCommn { get; set; } = 0;
        public decimal MaxCommn { get; set; } = 0;        
        public string PaidFlag { get; set; } = "Y";
        public string UserId { get; set; }
        public DateTime Trandate { get; set; } = System.DateTime.Now;
        public string CashierCode { get; set; } = "";
        public int CancelID { get; set; } = 0;
        public string CancelUser { get; set; } = "";
        public DateTime CancelDate { get; set; } = System.DateTime.Now;
        public string CancelAuthUser { get; set; } = "";
        public string CancelRemarks { get; set; } = "";
        public DateTime CancelAuthDate { get; set; } = System.DateTime.Now;
        public string IsPaidFullCancel { get; set; } = "";
        public string Code { get; set; } = "";
        public string TokenNo { get; set; } = "";
        public string AuthFlag { get; set; } = "Y";
        public string BranchAuthUser { get; set; } = "";
        public DateTime BranchAuthDate { get; set; } = System.DateTime.Now;
        public string HOAuthUser { get; set; } = "";
        public DateTime HOAuthDate { get; set; } = System.DateTime.Now;
        public string Occupation { get; set; } = "";
        public string Residence { get; set; } = "";
        public string Purpose { get; set; } = "";
        public string Source { get; set; } = "";
        public string PurposeDtl { get; set; } = "";
        public string SourceDtl { get; set; } = "";
        public string RoutingBankCode { get; set; } = "";
        public string RoutingBankName { get; set; } = "";
        public string LocCountry { get; set; } = SD.Concode;

        public int RepId { get; set; } = 0;
        public string RepName { get; set; } = String.Empty;
        public string RepRelation { get; set; } = String.Empty;
        public string RepMessage { get; set; } = String.Empty;  
        public string RefferBy { get; set; } = String.Empty;
        public DateTime? ReferDate { get; set; } 
        public string UBOName { get; set; } = String.Empty;
        public bool? Suspicious { get; set; } = false;
    }

    //public class RemittanceValidator : AbstractValidator<Remittance>
    //{
    //    private readonly IServiceRulesDataService _serviceRulesDataService;        
    //    public RemittanceValidator()
    //    {            
    //        RuleFor(Remittance => Remittance.ServiceCountryCode).NotEmpty().WithMessage("Please select Country");
    //        RuleFor(Remittance => Remittance.ServiceCurrencyCode).NotEmpty().WithMessage("Please select Currency");
    //        RuleFor(Remittance => Remittance.ServiceServiceCode).NotEmpty().WithMessage("Please select Service ");
    //        RuleFor(Remittance => Remittance.CorrCode).NotEmpty().WithMessage("Please select Correspondent");

    //        RuleFor(Remittance => Remittance.BenefName1).NotEmpty().WithMessage("Please enter Name");
    //        //RuleFor(Remittance => Remittance.BenefDob).NotEmpty().WithMessage("Please select Dob");
    //        RuleFor(Remittance => Remittance.BenefCell1).NotEmpty().WithMessage("Please enter Mobile No");
    //        RuleFor(Remittance => Remittance.BenefConcode).NotEmpty().WithMessage("Please select Country");
    //        RuleFor(Remittance => Remittance.BenefGender).NotEmpty().WithMessage("Please select Gender");
    //        RuleFor(Remittance => Remittance.BenefIdType).NotEmpty().WithMessage("Please select IdType");
    //        RuleFor(Remittance => Remittance.BenefIdNo).NotEmpty().WithMessage("Please enter IdNumber ");            

    //    }       
    //}
    //public class RemitCustValidator : AbstractValidator<Customer_mst>
    //{
    //    public RemitCustValidator()
    //    {

    //    }
    //}
}
