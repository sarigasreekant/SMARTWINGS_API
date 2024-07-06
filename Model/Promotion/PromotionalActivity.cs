using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class PromotionalActivity
    {
        public string OrgCode { get; set; } = "00001";      
        public string PromoCode { get; set; } = string.Empty;       
        public string PromoName { get; set; } = string.Empty;
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;       
        public string Country { get; set; } = string.Empty;
        public string PromoType { get; set; } = string.Empty;
        public string ServCode { get; set; } = string.Empty;
        public string ConfigCode { get; set; } = string.Empty;
        public decimal LoyaltyPerTxn { get; set; } = 0;     
        public decimal ServiceCharge { get; set; }  = decimal.Zero;
        public decimal ExchangeRate { get; set; } = 0;
        public string ActiveFlag { get; set; } = "Y";
        public string UserCode { get; set; } = string.Empty;
        public DateTime Created_Date { get; set; }
        public string M_UserCode { get; set; } = string.Empty;
        public DateTime Mod_Date { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;

        public string CountryName { get; set; } = string.Empty;
        public string PromoTypeName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string ConfigName { get; set; } = string.Empty;

    }
}
