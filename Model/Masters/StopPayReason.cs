using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class StopPayReason
    {
        
        public string OrgCode { get; set; } = "00001";
        public string BranchCode { get; set; } = "00000";
        public string ConfigCode { get; set; } = "00001";
        public string ReasonId { get; set; } = "";
        public string Reason { get; set; } = "";
        public string ActiveFlag { get; set; } = "Y";
        public string LangCode { get; set; } = "EN";
        public string UserId { get; set; } = "";
        public DateTime? TranDate{ get; set; } = System.DateTime.Now;

        public string MUserId { get; set; } = "";
        public DateTime? ModifyDate { get; set; } = System.DateTime.Now;
    }
}
