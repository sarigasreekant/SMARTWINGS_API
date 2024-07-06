using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CommisionSearch
    {
        public string ServOrgCode { get; set; } = string.Empty;
        public string CurCode { get; set; } = string.Empty;
        public string ServCode { get; set; } = string.Empty;
        public string OrgCode { get; set; } = SD.OrgCode;
        public string BranchCode { get; set; } = string.Empty;
        public string ServiceCountry { get; set; } = "";
        public string ConfigCode { get; set; } = string.Empty;
        public string ServiceCurrency { get; set; } = "";
        public decimal FcyAmount { get; set; } = 0;
        public decimal LcyAmount { get; set; } = 0;
        public string CommType { get; set; } = string.Empty; //online,Ratesheet       

        public string BenefBank { get; set; } = "zQ";
        public string BenifBranchCode { get; set; } = "zQ";
        public string Param1 { get; set; } = "zQ";
        public string Param2 { get; set; } = "zQ";
        public string Param3 { get; set; } = "zQ";         
        public bool BoolParam1 { get; set; } = false;
        public bool BoolParam2 { get; set; } = false;
    }
}
