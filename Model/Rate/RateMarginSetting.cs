using System.ComponentModel.DataAnnotations;
using ForexModel;

namespace SMARTWINGS_API.Model.Rate
{
    public class RateMarginSetting
    {


        public string ORGCODE { get; set; } = "00001";


        public string CORRORGCODE { get; set; } = "00001";


        public string BRANCHCODE { get; set; } = "00000";
        [Required]


        public string CURCODE { get; set; }




        public string CURRENCY { get; set; }



        public string BASECURCODE { get; set; } = SD.LocalCurCode;
        [Required]
        public decimal COSTRATE { get; set; } = 0;
        public decimal CNBMARGIN { get; set; } = 0;
        public decimal CNSMARGIN { get; set; } = 0;
        public decimal CNBMIN { get; set; } = 0;
        public decimal CNBMAX { get; set; } = 0;
        public decimal CNSMIN { get; set; } = 0;
        public decimal CNSMAX { get; set; } = 0;
        public decimal CNBMIND { get; set; } = 0;
        public decimal CNBMAXD { get; set; } = 0;
        public decimal CNSMIND { get; set; } = 0;
        public decimal CNSMAXD { get; set; } = 0;
    }
}
