using System.ComponentModel.DataAnnotations;

namespace ForexModel
{



    public class UserMst
    {
        
      
        public string OrgCode { get; set; } = "00001";

        [Required]
        public string BranchCode { get; set; } = String.Empty;
        [Required]
        [StringLength(10)]
        public string UserID { get; set; } = String.Empty;
        [Required]
        [StringLength(30)]
        public string Password { get; set; } = String.Empty;
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = String.Empty;
        [Required]
        public int UserGroup { get; set; } = 0;
        [StringLength(50)]

        public string MobileNo { get; set; } = String.Empty;
        [StringLength(50)]
        public string VIPToken { get; set; } = String.Empty;
        [StringLength(2)]
        public string ActiveFlag { get; set; } = "Y";
        [StringLength(300)]
        public string PhotoUrl { get; set; } = String.Empty;

        [StringLength(50)]
        public string Email { get; set; } = String.Empty;
        [StringLength(50)]
        public string AccuntNo { get; set; } = String.Empty;
        [StringLength(50)]
        public string AccuntNoExceNo { get; set; } = String.Empty;
        public string BranchName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public string JWTToken { get; set; } = String.Empty;
        public string UserType { get; set; } = "N";
        public bool IsScucess { get; set; } = true;
    }

}
