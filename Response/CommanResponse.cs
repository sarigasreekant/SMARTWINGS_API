using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CommanResponse
    {
        public string RefNo { get; set; } = string.Empty;
        public string StatusMesage { get; set; } = string.Empty;
        public int StatusCode { get; set; } = 400;
        public bool IsSucess { get; set; } =false;
    }
}
