using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ServiceCountries
    {
        public string? ConfigCode { get; set; } = string.Empty;
        public string? ServOrgCode { get; set; } = string.Empty;
        public string? CurCode { get; set; } = string.Empty;       
        public string? ServCode { get; set; } = string.Empty;        
        public string OrgCode { get; set; } = SD.OrgCode;
        public string? PortalCode { get; set; } = "00001";
        public string? UserCode { get; set; } = "admin";


        public string? CountryName { get; set; } = string.Empty;
        public string? CountryCode { get; set; } = string.Empty;



    }
}
