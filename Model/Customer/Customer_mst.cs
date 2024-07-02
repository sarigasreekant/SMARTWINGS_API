using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class Customer_mst
    {
        public string Custcode { get; set; } = "";

        public string? Custtype { get; set; } = "I";
        public string CustomerGroup { get; set; } = "";

        public string Name1 { get; set; } = "";

        public string Name2 { get; set; } = "";

        public string Name3 { get; set; } = "";
        public string Name4 { get; set; } = "";
        public string Cell1 { get; set; } = "";

        public string Cell2 { get; set; } = "";

        public string Phone { get; set; } = "";

        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }

        public string Adrees1 { get; set; } = "";

        public string Adrees2 { get; set; } = "";

        public string Place { get; set; } = "";

        public string Street { get; set; } = "";

        public string City { get; set; } = "";

        public string State { get; set; } = "";

        public string? Concode { get; set; } 

        public string? Country { get; set; }

        public string Pobox { get; set; } = "";

        public string? Nationcode { get; set; } 

        public string? Nationality { get; set; }

        public string Profession { get; set; } = "";
        public string Occupation { get; set; } = "";
        public string Mail { get; set; } = "";

        public string Fax { get; set; } = "";

        public string Activeflg { get; set; } = "Y";

        public string Userid { get; set; } = "";


        public string Branchcode { get; set; } = "";

        public string Company { get; set; } = "";

        public string Photo { get; set; } = "";

        public string Amldoc_collected { get; set; } = "N";

        public string Risktype { get; set; } = "LOW";

        public string Amltype { get; set; } = "LOW";

        public string Aml_auth { get; set; } = "N";

        public string Aml_auth_user { get; set; } = "";

        public string Remarks { get; set; } = "";

        public string Remark2 { get; set; } = "";
        public DateTime? Regdate { get; set; } = System.DateTime.Now;
        public string PEP { get; set; } = "N";
        public Boolean Allow_Forex { get; set; }
        public Boolean Allow_Remit { get; set; }
        public Boolean Allow_Incoming { get; set; }
        public Boolean Allow_Mobile { get; set; }
        public string? Cust_reg_module { get; set; }
        public string? Cust_reg_UserId { get; set; }
        public DateTime? Cust_reg_date { get; set; }
        public string? Cust_reg_branch { get; set; }
        public string? Last_updated_by { get; set; }
        public DateTime? Last_updated_date { get; set; }
        public string? aml_score { get; set; }
        public string Residence { get; set; } = "";

        public string FullName { get; set; } = "";
        public string? IdTypeCode { get; set; } 
        public string IdNo { get; set; } = "";
        public string IdType { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Issueplace { get; set; } = string.Empty;
        public string? IssueContcode { get; set; } 
        public string IdRemarks { get; set; } = string.Empty;
        public string Primary_Id { get; set; } = "Y";
        public string ImageFront { get; set; } = string.Empty;        
        public string ImageBack { get; set; } = string.Empty;
    }
    public class CustomerValidator : AbstractValidator<Customer_mst>
    {

        public CustomerValidator()
        {
            // RuleFor(Customer_mst => Customer_mst.Custtype).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().NotNull().NotEqual("foo");


            When(Customer_mst => Customer_mst.Custtype.ToUpper() == "I", () =>
            {

                RuleFor(Customer_mst => Customer_mst.Name1).NotEmpty().WithMessage("Please enter the First Name");
                RuleFor(Customer_mst => Customer_mst.Name2).NotEmpty().WithMessage("Please enter the Second Name");
                RuleFor(Customer_mst => Customer_mst.Cell1).NotEmpty().WithMessage("Please enter the Mobile No ");
                RuleFor(Customer_mst => Customer_mst.Adrees1).NotEmpty().WithMessage("Please enter the Address");
                RuleFor(Customer_mst => Customer_mst.Nationcode).NotEmpty().WithMessage("Please select Nationality");
                RuleFor(Customer_mst => Customer_mst.Concode).NotEmpty().WithMessage("Please select the Country");
                RuleFor(Customer_mst => Customer_mst.Dob).NotEmpty().WithMessage("Please enter the Dob");
                RuleFor(Customer_mst => Customer_mst.Gender).NotEmpty().WithMessage("Please select Gender");

                RuleFor(Customer_mst => Customer_mst.IdTypeCode).NotEmpty().WithMessage("Please Select ID Type");
                RuleFor(Customer_mst => Customer_mst.IdNo).NotEmpty().WithMessage("Please enter the ID No");
                RuleFor(Customer_mst => Customer_mst.IssueDate).NotEmpty().WithMessage("Please enter the Issue Date");
                RuleFor(Customer_mst => Customer_mst.ExpDate).NotEmpty().WithMessage("Please enter the Exp Date");
                RuleFor(Customer_mst => Customer_mst.IssueContcode).NotEmpty().WithMessage("Please select Country");
            }).Otherwise(() =>
            {

                RuleFor(Customer_mst => Customer_mst.Name1).NotEmpty().WithMessage("Please enter the Name");
                RuleFor(Customer_mst => Customer_mst.Cell1).NotEmpty().WithMessage("Please enter the Mobile No");
                RuleFor(Customer_mst => Customer_mst.Country).NotEmpty().WithMessage("Please select Country");
                RuleFor(Customer_mst => Customer_mst.Adrees1).NotEmpty().WithMessage("Please enter the Address ");
                RuleFor(Customer_mst => Customer_mst.Dob).NotEmpty().WithMessage("Please enter the Reg-Date");
            });

        }
    }

}
