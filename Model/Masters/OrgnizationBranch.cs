using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ForexModel
{

    public class OrgnizationBranch
    {

        public string BranchCode { get; set; } = "";
        [Required]

        public string OrgCode { get; set; }

        
        public string OrgName { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string BranchName { get; set; } = "";
        public string? Address { get; set; } = "";
        [StringLength(50)]
        public string? Street { get; set; } = "";
        [StringLength(50)]
        public string? City { get; set; } = "";
        [StringLength(50)]
        public string? State { get; set; } = "";
        [StringLength(50)]
        public string? PoBox { get; set; } = "";
        [StringLength(50)]
        
        public string? Country { get; set; } = "";
        [StringLength(20)]
        public string? Phone { get; set; } = "";
        [StringLength(20)]
        public string? Mobile { get; set; } = "";
        [StringLength(50)]
        public string? Email { get; set; } = "";
        [StringLength(2)]
        public string? WindowsFlag { get; set; } = "";
        public int? Refno { get; set; } = 0;
        public DateTime? RefDate { get; set; }
        public int? JvMonth { get; set; } = 0;
        public int? JVYear { get; set; } = 0;
        public int? JVDocNo { get; set; } = 0;
        public int? Fxno { get; set; } = 0;
        public DateTime? FxDate { get; set; }
        [StringLength(50)]
        public string? InterBranchAccno { get; set; } = "";
        [StringLength(50)]
        public string? WholeSaleAccount { get; set; } = "";

        public string? ActiveFlag { get; set; } = "Y";

        public string? AgentCode { get; set; } = "";
        public string AgentName { get; set; } = "";
        public string IFSCCODE { get; set; } = "";
       

       

    }
}
