using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class Organization
    {
       
        public string OrgCode { get; set; } = "";

        [Required]
        public int? OrgTypeId { get; set; } 
        [Required]
        [StringLength(200)]
        public string OrgName { get; set; } = "";
        [StringLength(50)]
        [Required]
        public string ContactNo { get; set; } = "";
        [StringLength(200)]
        [Required]
        public string Address { get; set; } = "";
        [StringLength(80)]
        public string Street { get; set; } = "";
        [StringLength(80)]
        public string City { get; set; } = "";
        [StringLength(80)]
        public string State { get; set; } = "";
        [StringLength(80)]
        public string PoBox { get; set; } = "";
        [Required]
        [StringLength(10)]

        public string ConCode { get; set; } 

        [StringLength(100)]
        public string CountryName { get; set; } = "";
        [StringLength(20)]
        public string Phone { get; set; } = "";
        [StringLength(20)]
        public string Mobile { get; set; } = "";
        //[StringLength(50)]

        //[EmailAddress(ErrorMessage = "Not a valid Email")]
        public string Email { get; set; } = "";
        [StringLength(50)]
        public string Fax { get; set; } = "";
        [StringLength(50)]
        public string OrgAccno { get; set; } = "";
        [StringLength(50)]
        public string OrgBankNo { get; set; } = "";
        [StringLength(100)]
        public string OrgOtherInfo { get; set; } = "";
        [StringLength(2)]
        public string ActiveFlag { get; set; } = "Y";
        public string OrgTypeName { get; set; } = "";
        public string? CodeType { get; set; } = "00001";
        public string CodeTypedesc { get; set; } = "";
    }
    

}
