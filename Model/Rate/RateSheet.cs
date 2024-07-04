using System.ComponentModel.DataAnnotations;
using ForexModel;

namespace SMARTWINGS_API.Model.Rate
{
    public class RateSheet
    {



        public string ORGCODE { get; set; } = "00001";


        public string BRANCHCODE { get; set; } = "00000";


        public string CORRORGCODE { get; set; } = "00001";
        [Required]

        public string CURCODE { get; set; }



        public string CURRENCY { get; set; }

        public string BASECURCODE { get; set; } = SD.LocalCurCode;



        public string FACTOR { get; set; }

        [Required]
        public decimal COSTRATE { get; set; }
        [Required]
        public decimal BASERATE { get; set; } = 0;
        public decimal BUYMIN { get; set; } = 0;
        public decimal BUYMAX { get; set; } = 0;
        public decimal SELLMIN { get; set; } = 0;
        public decimal SELLMAX { get; set; } = 0;
        public decimal BUYRATE { get; set; } = 0;
        public decimal SELLRATE { get; set; } = 0;
        public decimal BUYMIND { get; set; } = 0;
        public decimal BUYMAXD { get; set; } = 0;
        public decimal SELLMIND { get; set; } = 0;
        public decimal SELLMAXD { get; set; } = 0;
        public decimal BUYRATED { get; set; } = 0;
        public decimal SELLRATED { get; set; } = 0;



    }
}
