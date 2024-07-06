using ForexModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceBlockCustomers
    {
        public int Tabid { get; set; }
        public string? ConfigCode { get; set; } = string.Empty;
        public string? BlkTServOrgCode { get; set; } = string.Empty;
        public string? BlkTCurCode { get; set; } = string.Empty;
        public string? BlkTServCode { get; set; } ="00002";
        public string OrgCode { get; set; } = SD.OrgCode;
        public string? PortalCode { get; set; } = "00001";
        public string? UserCode { get; set; } = "admin";
        public string BlkTServOrgName { get; set; } = string.Empty;
        public string BlkTCurName { get; set; } = string.Empty;
        public string BlkTServName { get; set; } = string.Empty;
        public string BlkTCustCode { get; set; } = string.Empty;
        public string BlkTCustName { get; set; } = string.Empty;
        public string BlkTType { get; set; } = string.Empty;


    }
}
