using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTWINGS_API.Model.Forex
{
    public class ForexTransHeaderCancelDTO
    {
        public string OrgCode { get; set; } = "";
        public string Refno { get; set; } = "";
        public string Branchcode { get; set; } = "";
        public string SerNo { get; set; } = "";
        public string CancelId { get; set; } = "";
        public string CancelUserID { get; set; } = "";
        public string CancelReason { get; set; } = "";
        public DateTime CancelDate { get; set; } = DateTime.Now;

    }
}
