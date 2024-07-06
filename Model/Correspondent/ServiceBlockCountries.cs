using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceBlockCountries
    {
        public int Tabid { get; set; }
        public string? ConfigCode { get; set; }

        public string? PortalCode { get; set; } = "00001";
        public string OrgCode { get; set; } = SD.OrgCode;
        public string UserCode { get; set; } = "admin";

        public string BlkCServOrgCode { get; set; } = string.Empty;
        public string? BlkCCurCode { get; set; } = string.Empty;
        public string? BlkCServCode { get; set; } = string.Empty;
        public string BlkCServOrgName { get; set; } = string.Empty;
        public string BlkCCurName { get; set; } = string.Empty;
        public string BlkCServName { get; set; } = string.Empty;
        public string BlkCNationCode { get; set; } = string.Empty;
        public bool BlkCCodeSel { get; set; } = false;
        public string BlkCType { get; set; } = string.Empty;
        public string BlkCNationName { get; set; } = string.Empty;
    }
}
