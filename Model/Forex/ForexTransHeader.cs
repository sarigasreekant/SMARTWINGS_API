using System.ComponentModel.DataAnnotations;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTransHeader
    {

        [StringLength(10)]
        public string OrgCode { get; set; } = "00001";

        [StringLength(26)]

        public string Refno { get; set; }

        [StringLength(10)]

        public string Branchcode { get; set; }


        [StringLength(26)]

        public string Custcode { get; set; }


        [StringLength(26)]

        public string UserId { get; set; }


        [StringLength(26)]

        public string CashierCode { get; set; }

        public DateTime Trandate { get; set; } = DateTime.Now;
        [StringLength(5)]
        public string CustType { get; set; } = "";
        [StringLength(100)]
        [Required]

        public string Name1 { get; set; }

        [StringLength(100)]
        public string Name2 { get; set; } = "";
        [StringLength(100)]
        public string Name3 { get; set; } = "";
        [StringLength(25)]
        public string Cell1 { get; set; } = "";
        [StringLength(25)]
        public string Cell2 { get; set; } = "";
        [StringLength(25)]
        public string Phone { get; set; } = "";
        [StringLength(50)]
        public string? Gender { get; set; } = "";
        [StringLength(100)]
        public string Adrees1 { get; set; } = "";
        [StringLength(100)]
        public string Adrees2 { get; set; } = "";
        [StringLength(100)]
        public string Place { get; set; } = "";
        [StringLength(100)]
        public string Street { get; set; } = "";
        [StringLength(100)]
        public string City { get; set; } = "";
        [StringLength(100)]
        public string State { get; set; } = "";
        [StringLength(100)]
        public string? Concode { get; set; } = "";
        [StringLength(100)]
        public string Country { get; set; } = "";
        [StringLength(100)]
        public string Pobox { get; set; } = "";
        [StringLength(100)]
        public string? Nationcode { get; set; } = "";
        [StringLength(100)]
        public string Nationality { get; set; } = "";
        [StringLength(100)]
        public string Profession { get; set; } = "";
        [StringLength(100)]
        public string Mail { get; set; } = "";
        [StringLength(100)]
        public string Fax { get; set; } = "";
        [StringLength(200)]
        public string Remarks { get; set; } = "";
        [StringLength(200)]
        public string Remark2 { get; set; } = "";
        public DateTime? Dob { get; set; }
        [StringLength(50)]
        public string IdNo { get; set; } = "";
        [StringLength(100)]
        public string IdDescription { get; set; } = "";
        [StringLength(50)]
        public string IdCode { get; set; } = "";
        [StringLength(100)]
        public string IdIssueplace { get; set; } = "";
        [StringLength(100)]
        public string IdIssueCountry { get; set; } = "";
        public DateTime? IdIssueDate { get; set; }
        public DateTime? IdExpDate { get; set; }
        [StringLength(200)]
        public string IdRemarks { get; set; } = "";
        [StringLength(100)]
        public string CancelId { get; set; } = "";
        [StringLength(25)]
        public string CancelUserID { get; set; } = "";
        public DateTime CancelDate { get; set; }
        [StringLength(500)]
        public string CancelReason { get; set; } = "";
        [StringLength(25)]

        public string CancelAuthUserID { get; set; }

        public DateTime CancelAuthDate { get; set; }
        [StringLength(100)]
        public string Purpose { get; set; } = "";
        [StringLength(10)]
        public string PurposeCode { get; set; } = "";
        [StringLength(100)]

        public string PurposeRemarks { get; set; }

        [StringLength(100)]
        public string Source { get; set; } = "";
        [StringLength(10)]
        public string SourCode { get; set; } = "";
        [StringLength(100)]
        public string SourceRemarks { get; set; } = "";
        [StringLength(50)]
        public string JVDocno { get; set; } = "";
        public decimal ServiceCharge { get; set; } = 0;
        public decimal Tax { get; set; } = 0;
        [StringLength(5)]
        public string ISCBReported { get; set; } = "N";
        [StringLength(5)]
        public string ISxmlReported { get; set; } = "N";
        public decimal GroTotalGross { get; set; } = 0;
        public string? BranchName { get; set; } = "";
    }
}
