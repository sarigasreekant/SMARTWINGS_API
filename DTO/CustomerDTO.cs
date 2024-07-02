using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CustomerDTO
    {
        public string Custcode { get; set; } = string.Empty;

        public string Custtype { get; set; } = string.Empty;
        public string CustomerGroup { get; set; } = string.Empty;
        public string Name1 { get; set; } = string.Empty;

        public string Name2 { get; set; } = string.Empty;

        public string Name3 { get; set; } = string.Empty;
        public string Name4 { get; set; } = string.Empty;
        public string Cell1 { get; set; } = string.Empty;

        public string Cell2 { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public DateTime? Dob { get; set; }

        public string Adrees1 { get; set; } = string.Empty;

        public string Adrees2 { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Concode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Pobox { get; set; } = string.Empty;

        public string Nationcode { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public string Profession { get; set; } = string.Empty;
        public string Occupation { get; set; } = "";
        public string Mail { get; set; } = string.Empty;

        public string Fax { get; set; } = string.Empty;

        public string Activeflg { get; set; } = string.Empty;

        public string Userid { get; set; } = string.Empty;


        public string Branchcode { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;

        public string Photo { get; set; } = string.Empty;

        public string Amldoc_collected { get; set; } = "N";

        public string Risktype { get; set; } = "L";

        public string Amltype { get; set; } = "N";

        public string Aml_auth { get; set; } = "N";

        public string Aml_auth_user { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public string Remark2 { get; set; } = string.Empty;
        public DateTime? Regdate { get; set; } = System.DateTime.Now;

        public string PEP { get; set; } = "N";
        public Boolean Allow_Forex { get; set; }
        public Boolean Allow_Remit { get; set; }
        public Boolean Allow_Incoming { get; set; }
        public Boolean Allow_Mobile { get; set; }
        public string? Cust_reg_module { get; set; } = string.Empty;
        public string? Cust_reg_UserId { get; set; } = string.Empty;
        public DateTime? Cust_reg_date { get; set; } = System.DateTime.Now;
        public string? Cust_reg_branch { get; set; } = string.Empty;
        public string? Last_updated_by { get; set; } = string.Empty;
        public DateTime? Last_updated_date { get; set; }   = System.DateTime.Now;
        public string? aml_score { get; set; } = string.Empty;
        public string Residence { get; set; } = "";

        public string FullName { get; set; } = "";
        public string IdTypeCode { get; set; } = "";
        public string IdNo { get; set; } = "";
        public string IdType { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Issueplace { get; set; } = string.Empty;
        public string IssueContcode { get; set; } = string.Empty;
        public string IdRemarks { get; set; } = string.Empty;
        public string Primary_Id { get; set; } = "N";
        public string ImageFront { get; set; } = string.Empty;
        public string ImageBack { get; set; } = string.Empty;
    }
}
