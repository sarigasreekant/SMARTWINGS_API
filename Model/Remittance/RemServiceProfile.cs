using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class RemServiceProfile
    {
        public int SerProfCode { get; set; }        
        public string CustCode { get; set; }
        public string ContCode { get; set; }
        public string Country { get; set; }
        public string CurCode { get; set; }
        public string Currency { get; set; }
        public string ServCode { get; set; }       
        public string ServiceName { get; set; }
        public string CorrOrgCode { get; set; }
        public string CorresOrgName { get; set; }
        public string CorrBranchCode { get; set; }
        public string SubCorrOrgCode { get; set; }
        public string SubCorrBranchCode { get; set; }
        public string CorrCode { get; set; }
        public string BenefFullName { get; set; }
        public string BenefName1 { get; set; }
        public string BenefName2 { get; set; }      
        public string BenefName3 { get; set; }
        public string BenefName4 { get; set; }
        public string BenefGender { get; set; }
        public DateTime BenefDob { get; set; }
        public string BenefCell1 { get; set; }
        public string BenefCell2 { get; set; }
        public string BenefPhone1 { get; set; }
        public string BenefPhone2 { get; set; }
        public string BenefAddress1 { get; set; }
        public string BenefAddress2 { get; set; }
        public string BenefPlace { get; set; } 
        public string BenefStreet { get; set; } 
        public string BenefCity { get; set; } 
        public string BenefState { get; set; } 
        public string BenefPobox { get; set; } 
        public string BenefConcode { get; set; }
        public string BenefCountry { get; set; }
        public string BenefNationcode { get; set; }
        public string BenefNationality { get; set; }
        public string BenefDialCode { get; set; }
        
        public string BenefPOB { get; set; }
        public string BenefIdType { get; set; }

        public string BenefIdNo { get; set; }
        public string BenefBankCode { get; set; }
        public string BenefBankName { get; set; }
        public string BenefBankBranchCode { get; set; }
        public string BenefBankBranchName { get; set; }
        public string BenefIFSC { get; set; }
        public string BenefAccountNo { get; set; }
        public string BenfBankAddress { get; set; }
        public string BenefBankCity { get; set; }
        public string BenfRemarks { get; set; }
        public string MTCustCode { get; set; }
        public string RecvrName { get; set; }
        public string RecvrAddress { get; set; }
        public string LiasCode { get; set; }
        public string IdCode { get; set; }
        public string AcntTypeCode { get; set; }
        public string AcntTypeDesc { get; set; }
        public string OrgCode { get; set; }
        public string LangCode { get; set; }
        public string ActiveFlag { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MUserCode { get; set; }
        public DateTime Modified_Dt { get; set; }
        public string RoutingBankCode { get; set; }
        public string RoutingBankName { get; set; }
       
    }
}
