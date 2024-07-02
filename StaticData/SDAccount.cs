using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public static class SDAccount
    {
        public static string AssetRoot { get; set; } = "100";
        public static string LiablityRoot { get; set; } = "200,300";
        public static string IncomeRoot { get; set; } = "400";
        public static string ExpenseRoot { get; set; } = "500";
        public static string OpBallceAcc { get; set; } = "30011213141";
        public static string CustomerLoanAcccode { get; set; } = "10011253141";
        public static string CustomerLoanProfitAccode { get; set; } = "40012223241";
        public static string RoundOffAccode { get; set; } = "40011213141";
        public static string ForexServiceChrgAccode { get; set; } = "40011233141";
        public static string TaxAccount { get; set; } = "20011273141";//pleasae createtax Laiblity
    }
}
