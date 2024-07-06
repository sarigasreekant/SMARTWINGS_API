using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServicePayModes
    {
       // public int Tabid { get; set; } = 0;
        public string? ConfigCode { get; set; } = string.Empty;
        public string? PayServOrgCode { get; set; }
        public string? PayCurCode { get; set; }
        public string? PayServCode { get; set; }
        public string PayServOrgName { get; set; } = string.Empty;
        public string PayCurName { get; set; } = string.Empty;
        public string PayServName { get; set; } = string.Empty;
        public string? PayModeCode { get; set; }
        public string PayName { get; set; } = string.Empty;
        public string PortalCode { get; set; } = "00001";
        public string OrgCode { get; set; } = SD.OrgCode;
        public string UserCode { get; set; } = "admin";
        public bool PayCodeSel { get; set; } = false;
    }
}
