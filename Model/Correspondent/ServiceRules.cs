using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ForexModel
{
    public class ServiceRules
    {
        public string PortalCode { get; set; } = "00001";
        public string OrgCode { get; set; } = SD.OrgCode;
        public string UserCode { get; set; } = "admin";

        public string?  FieldName { get; set; } = string.Empty;
        public string  IsVisible { get; set; } = string.Empty;
        public string  IsMandatory { get; set; } = string.Empty;
        public int FieldLength { get; set; } = 0;
        public string  ControlID { get; set; } = string.Empty;
        public string  LangCode { get; set; } = "EN";
        public int  MinLength { get; set; } = 0;
        public string? DispName { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool Mandatory { get; set; } = false;
        public bool visible { get; set; } = false;
        public string  Modules { get; set; } = string.Empty;
        public string  LabelName { get; set; } = string.Empty;
        public string  LabelText { get; set; } = string.Empty;
        public string  SetLength { get; set; } = string.Empty;
        public string ColShows { get; set; } = string.Empty;
        public string ServCode { get; set; } = string.Empty;
        public string ServOrgCode { get; set; } = string.Empty;
        public string ConfigCode { get; set; } = string.Empty;

    }
}
