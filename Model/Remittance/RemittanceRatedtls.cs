using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class RemittanceRatedtls
    {
        public string CurCode { get; set; }
        public string Description { get; set; }
        public string  Factor { get; set; }
        public string CURRENCY { get; set; }
        public string BASECURCODE { get; set; }

        public decimal BASERATE { get; set; }
        public decimal BUYMIN { get; set; }
        public decimal BUYMAX { get; set; }
        public decimal SELLMIN { get; set; }
        public decimal SELLMAX { get; set; }
        public decimal BUYRATE { get; set; }
        public decimal SELLRATE { get; set; }
        public decimal BUYMIND { get; set; }
        public decimal BUYMAXD { get; set; }
        public decimal SELLMIND { get; set; }
        public decimal SELLMAXD { get; set; }
        public decimal BUYRATED { get; set; }
        public decimal SELLRATED { get; set; }
        public decimal COSTRATE { get; set; }
        public decimal ServCharge { get; set; }
        public string SCHRGCURCODE { get; set;}
        public decimal SlabFrom { get; set; }
        public decimal SlabTo { get; set;}
        public decimal Mincharge { get; set; } = 0;
        public decimal Maxcharge { get; set; } = 0;
        public string CommnType { get; set; }

    }
}
