using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class CustomerDTOMobile
    {
        public string Custcode { get; set; } = "";

        public string? Custtype { get; set; } = "I";
        public string CustomerGroup { get; set; } = "";
        [Required]
        public string Name1 { get; set; }

        public string Name2 { get; set; } = "";

        public string Name3 { get; set; } = "";
        [Required]
        public string Cell1 { get; set; }
        public string Mail { get; set; } = "";
        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Nationcode { get; set; }

        public string? Nationality { get; set; }

        public string Adrees1 { get; set; } = "";

        public string Adrees2 { get; set; } = "";

        public string? Concode { get; set; }

        public string? Country { get; set; }

        public string Profession { get; set; } = "";

        public string Activeflg { get; set; } = "Y";

        public string Userid { get; set; } = "";

        public string Branchcode { get; set; } = "";

        public string Company { get; set; } = "";

        public string Photo { get; set; } = "";

        public DateTime? Regdate { get; set; } = System.DateTime.Now;

        [Required]

        public string? IdTypeCode { get; set; }
        [Required]
        public string IdNo { get; set; } = "";
        public string IdType { get; set; } = string.Empty;

        [Required]
        public DateTime? ExpDate { get; set; }

        [Required]
        public string? IssueContcode { get; set; }

        public string ImageFront { get; set; } = string.Empty;
        public string ImageBack { get; set; } = string.Empty;
    }


}

