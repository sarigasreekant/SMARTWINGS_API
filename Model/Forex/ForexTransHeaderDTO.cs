using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTransHeaderDTO
    {
        public string? OrgCode { get; set; }
        public string? Refno { get; set; }
        public string? Branchcode { get; set; }
        public string? Custcode { get; set; }
        public string? UserId { get; set; }
        public string? CashierCode { get; set; }
        public DateTime? Trandate { get; set; }
        public string? CustType { get; set; }
        public string? Name1 { get; set; }
        public string? Name2 { get; set; }
        public string? Name3 { get; set; }
        public string? Cell1 { get; set; }
        public string? Cell2 { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? Adrees1 { get; set; }
        public string? Adrees2 { get; set; }
        public string? Place { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Concode { get; set; }
        public string? Country { get; set; }
        public string? Pobox { get; set; }
        public string? Nationcode { get; set; }
        public string? Nationality { get; set; }
        public string? Profession { get; set; }
        public string? Mail { get; set; }
        public string? Fax { get; set; }
        public string? Remarks { get; set; }
        public string? Remark2 { get; set; }
        public DateTime? Dob { get; set; }
        public string? IdNo { get; set; }
        public string? IdDescription { get; set; }
        public string? IdCode { get; set; }
        public string? IdIssueplace { get; set; }
        public string? IdIssueCountry { get; set; }
        public DateTime? IdIssueDate { get; set; }
        public DateTime? IdExpDate { get; set; }
        public string? IdRemarks { get; set; }
        public string? CancelId { get; set; }
        public string? CancelUserID { get; set; }
        public DateTime? CancelDate { get; set; }
        public string? CancelReason { get; set; }
        public string? CancelAuthUserID { get; set; }
        public DateTime? CancelAuthDate { get; set; }
        public string? Purpose { get; set; }
        public string? PurposeCode { get; set; }
        public string? PurposeRemarks { get; set; }
        public string? Source { get; set; }
        public string? SourCode { get; set; }
        public string? SourceRemarks { get; set; }
        public string? JVDocno { get; set; }
        public decimal ServiceCharge { get; set; } = 0;
        public decimal? Tax { get; set; }
        public string? ISCBReported { get; set; }
        public string? ISxmlReported { get; set; }
        public decimal TotalGross { get; set; } = 0;
    }
}
