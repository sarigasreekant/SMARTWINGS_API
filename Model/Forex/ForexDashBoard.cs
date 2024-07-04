namespace SMARTWINGS_API.Model.Forex
{
    public class ForexDashBoard
    {
        public decimal Amount { get; set; } = 0;
        public int FCOUNT { get; set; } = 0;
        public decimal camount { get; set; } = 0;
        public int Ccont { get; set; } = 0;
        public int Acount { get; set; } = 0;
    }
    public class RemitDashBoard
    {
        public decimal Amount { get; set; } = 0;
        public int FCOUNT { get; set; } = 0;
        public decimal camount { get; set; } = 0;
        public int Ccont { get; set; } = 0;
        public int Acount { get; set; } = 0;
        public int Pcount { get; set; } = 0;
    }
    public class IncomingDashBoard
    {
        public decimal Amount { get; set; } = 0;
        public int FCOUNT { get; set; } = 0;
        public decimal camount { get; set; } = 0;
        public int Ccont { get; set; } = 0;
        public int Acount { get; set; } = 0;
        public int Pcount { get; set; } = 0;
    }
    public class CustDashBoard
    {
        public decimal Amount { get; set; } = 0;
        public int FCOUNT { get; set; } = 0;
        public decimal camount { get; set; } = 0;
        public int Ccont { get; set; } = 0;
    }
    public class RenderingData
    {

        public string X { get; set; } = string.Empty;

        public decimal Y { get; set; } = 0;

        public string Text { get; set; } = string.Empty;


        public string Fill { get; set; } = string.Empty;

    }
    public class IncomeExpense
    {
        public DateTime? Period { get; set; }
        public decimal Income { get; set; } = 0;
        public decimal Expense { get; set; } = 0;

        public string CurCode { get; set; } = string.Empty;

    }

}
