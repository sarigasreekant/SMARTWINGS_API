using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class RemitDTO
    {
        public RemittanceDTO remittanceDTO { get; set; }
        public List<RemittancePayDTO> remittancePayDTO { get; set; }
    }
}
