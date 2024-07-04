using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class CurrencyRevalution
    {

        public int ID { get; set; }


        public string RefNo { get; set; }



        public string OrgCode { get; set; }


        public DateTime RevalDate { get; set; }


        public string JvDocNo { get; set; }



        public string Acccode { get; set; }



        public string ExchangeVaraccno { get; set; }

        public decimal CostRate { get; set; }
        public decimal FxAmount { get; set; }
        public decimal LcyAmount { get; set; }


        public string BranchCode { get; set; }



        public string CurCode { get; set; }



        public string CashierCode { get; set; }

        public DateTime Trandate { get; set; }


        public string ActiveFlag { get; set; }



        public string UserId { get; set; }

        public decimal Profit { get; set; }
        public decimal AvgRate { get; set; }
    }
}
