using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMARTWINGS_API.Model.Forex;
namespace ForexModel
{
    public class FxDto
    {
      

        public ForexTransHeaderDTO forexTransHeaderDTO { get; set; }


        public List<ForexTranDetailsDTO> forexTranDetailsDTO { get; set; }

    }
}
