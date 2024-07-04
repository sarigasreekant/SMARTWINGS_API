using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class ApplicationErorrLog
    {

        public int LId { get; set; } = 0;

        public string ModuleName { get; set; } = String.Empty;
      
        public string ConttroleName { get; set; } = String.Empty;

        public string ActionName { get; set; } = String.Empty;

        public string ErrorMesage { get; set; } = String.Empty;
        public string EorrDetails { get; set; } = String.Empty;
        public DateTime Errordate { get; set; } = System.DateTime.Now;
    }
}
