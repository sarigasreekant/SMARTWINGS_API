using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class Country
    {
        [Required]
        [StringLength(10)]
        public string ConCode { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string? CountryName { get; set; } = "";
        [StringLength(300)]
        public string? TimeZone { get; set; } = "";
        [StringLength(10)]
        public string? DialCode { get; set; } = "";
        [StringLength(10)]
        [Required]

        public string CurCode { get; set; } 

        [StringLength(50)]

        public string GroupCountry { get; set; } 

        [StringLength(50)]
        public string? INTCode { get; set; } = "";
        [StringLength(10)]
        public string? CBConcode { get; set; } = "";
        [StringLength(50)]
        public string OTHconcode { get; set; } = "";
        [StringLength(4)]
        public string ActiveFlag { get; set; } = "Y";
        public string Nationality { get; set; } = "";

    }
}
