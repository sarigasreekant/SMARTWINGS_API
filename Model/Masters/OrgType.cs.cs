using System.ComponentModel.DataAnnotations;

namespace ForexNewApp.Model
{
    public class OrgType
    {
        [Required]
        public int? OrgTypeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string? OrgTypeName { get; set; } = "";
        [StringLength(2)]
        public string? ActiveFlag { get; set; } = "Y";
    }
}
