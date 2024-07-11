using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class CustomerIdDetails
    {

        [StringLength(30)]
       
        public string Custcode { get; set; } = string.Empty;

        [StringLength(10)]

        public string IdTypeCode { get; set; } = string.Empty;

        [StringLength(50)]
     
        public string IdType { get; set; } = string.Empty;
        [StringLength(50)]
       
        public string IdNo { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }=DateTime.Now;
     
        public DateTime? ExpDate { get; set; }
        [StringLength(100)]
      
        public string Issueplace { get; set; } = string.Empty;

        [StringLength(200)]
        public string ImageFront { get; set; }   = string.Empty;

        [StringLength(200)]
        public string ImageBack { get; set; } = string.Empty;
        [StringLength(2)]
        public string Activeflg { get; set; } = "Y";
        [StringLength(2)]

        public string IssueContcode { get; set; } = string.Empty;
        [StringLength(200)]
        public string Remarks { get; set; } = string.Empty;
        [StringLength(2)]
        public string Idcollected { get; set; } = "Y";
        public string ImageFrontUrl { get; set; } = string.Empty;
        public string ImageImageBackUrl { get; set; } = string.Empty;
        public string Primary_Id { get; set; } = "Y";

    }
    public class CustIDValidator : AbstractValidator<CustomerIdDetails>
    {

        public CustIDValidator()
       {
        //        RuleFor(CustomerIdDetails => CustomerIdDetails.IdTypeCode).NotEmpty().WithMessage("Please enter the First Name");
        //        RuleFor(CustomerIdDetails => CustomerIdDetails.IdNo).NotEmpty().WithMessage("Please enter the Second Name");
        //        RuleFor(CustomerIdDetails => CustomerIdDetails.IssueDate).NotEmpty().WithMessage("Please enter the Mobile No ");
        //        RuleFor(CustomerIdDetails => CustomerIdDetails.ExpDate).NotEmpty().WithMessage("Please enter the Address");
        //        RuleFor(CustomerIdDetails => CustomerIdDetails.IssueContcode).NotEmpty().WithMessage("Please select Nationality");
                

            
        }
    }
}
