using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class Occupation
    {
        public string PortalCode { get; set; } = "";
        public string OrgCode { get; set; } = "";
        public string OccuCode { get; set; } = "";
        public string Description { get; set; } = "";
        public string AuthLevel { get; set; } = "";

        public string ActiveFlg { get; set; } = "";
        public string LangCode { get; set; } = "";
        public string Usercode { get; set; } = "";

        public DateTime? CREATEDATE { get; set; } = System.DateTime.Now;

        public string MUserCode { get; set; } = "";
        public DateTime? ModifyDate { get; set; } = System.DateTime.Now;
        public string Remarks { get; set; } = "";
    }
}
