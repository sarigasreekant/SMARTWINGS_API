using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceCharges
    {
        public int SChargeCode { get; set; } = 0;
        public string? ConfigCode { get; set; }
        public string? ServOrgCode { get; set; }
        public string? CurCode { get; set; }
        public string? ChargeType { get; set; }
        public decimal SlabFrom { get; set; } = 0;
        public decimal SlabTo { get; set; } = 0;
        public string AmtPercType { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string DeductType { get; set; } = string.Empty;
        // public bool EditFlg { get; set; }
        public decimal Mincharge { get; set; }
        public decimal MaxCharge { get; set; }
        public string SlabCurCode { get; set; } = string.Empty;
        public decimal ServCharge { get; set; }
        public string AuthFlag { get; set; } = "3";
        public string ActiveFlag { get; set; }="Y";
        public string OrgCode { get; set; } = SD.OrgCode;
        public string PortalCode { get; set; } = "00001";
        public string UserCode { get; set; } = "admin";
        public string Remarks { get; set; } = string.Empty;
        public string DeductText { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string ChargeText { get; set; } = string.Empty;
        public string AmtPercText { get; set; } = string.Empty;
        public int Tabid { get; set; } = 0;
        public string EditType { get; set; } = string.Empty;

        public string OchrgCurCode { get; set; } = string.Empty;
        public string SchrgCurCode { get; set; } = string.Empty;
        public decimal OurCharge { get; set; } = 0;
    }
}
