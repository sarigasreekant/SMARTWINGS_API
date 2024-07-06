using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class CurrencyTransferViewModel
    {
       
        public string BranchCode { get; set; } = "";
     
        public string CurCode { get; set; } = "";
      
        public decimal FcyAmount { get; set; }

        public string Rate { get; set; }

        public decimal LcyAmount { get; set; }

        public string CashierCode { get; set; }


        public string CasShierName { get; set; }

    

        public string UserId { get; set; }


        public string Remarks { get; set; }


    }
}
