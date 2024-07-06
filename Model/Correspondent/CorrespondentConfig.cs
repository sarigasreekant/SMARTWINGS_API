using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CorrespondentConfig
    {
        public string ConfigCode { get; set; } = string.Empty;

        public string OrgType { get; set; } = string.Empty;
        public string ServOrgCode { get; set; } = string.Empty;
        public string CurCode { get; set; }
        public string ServCode { get; set; }
        public string SchrgCurCode { get; set; } = string.Empty;
        public string OchrgCurCode { get; set; } = string.Empty;
        public string TrnsLangCode { get; set; } = "EN";
        public decimal MinLimit { get; set; } = 0;
        public decimal MaxLimit { get; set; } = 0;
        public decimal MinSCharge { get; set; } = 0;
        public decimal MaxSCharge { get; set; } = 0;
        public decimal MaxOCharge { get; set; } = 0;
        public decimal MinOCharge { get; set; } = 0;
        public string AccNo { get; set; } = string.Empty;
        public string AuthLevel { get; set; } = "3";
        
        public bool IsActive { get; set; } = false;
        public string ActiveFlag { get; set; } = "Y";
        public string OrgCode { get; set; } =  SD.OrgCode;
        public string PortalCode { get; set; } = "00001";
        public string UserCode { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string RateFrom { get; set; } = string.Empty;
        public bool EditCom { get; set; } = false;
        public bool RateEditFlg { get; set; } = false;
        public decimal TradeLimit { get; set; } = 0;
        public bool BranchShowFLg { get; set; } = false;

        public string OrgTypeName { get; set; } = string.Empty;

        public string OrgName { get; set; } = string.Empty;

        public string ServName { get; set; } = string.Empty;
        public string CodeType { get; set; } = string.Empty;
        public string CodeTypedesc { get; set; } = string.Empty;
        public string ApiFileType { get; set; } = string.Empty;
    }
}
