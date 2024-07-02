using ForexModel;
using System.Data;
using System.Globalization;
namespace Helper
{ 
    public static class GlobalConnection
    {

        public static string? ConnectionString { get; set; }

      
        public static string FinancialYear { get; set; } = GetFinalYearYYYYMMDD();
        public static string GetFinalYearDate()
        {
            string Date = "2024/01/01";
            DateTime date1 = DateTime.ParseExact(Date, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("yyyy/MM/dd");
            return ssDate;
        }
        public static string GetFinalYearDateFoamted()
        {
            string Date = "01/01/2024";
            DateTime date1 = DateTime.ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("MM/dd/yyyy");
            return ssDate;
        }
        public static string GetFinalYearYYYYMMDD()
        {
           // select convert(varchar, getdate(),yyyy-mm - dd hh: mm: ss 2022 - 12 - 30 00:38:54 120
            string Date = "2024-01-01 00:00:00";
          
            return Date;
        }
        public static string GetFinalYearYYYYMMDDNoTime()
        {
           
            string Date = "2024-01-01";

            return Date;
        }

        public static string GetFromDateYYYYMMDD(string? Date)

        {

            try
            {
               
                    DateTime date1 = DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string ssDate = date1.ToString("yyyy-MM-dd");
                    return ssDate + " 00:00:00";
               
            }
            catch ( Exception EX)
            {
                return GeCurrentDateYYYMMDD();
            }

        }

        public static string GetTodateYYYYMMDD(string? Date)

        {

            try
            {
                DateTime date1 = DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("yyyy-MM-dd");
            return ssDate+" 23:23:59";
            }
            catch (Exception EX)
            {
                return GeCurrentDateYYYMMDD();
            }

        }
        public static string GeCurrentDateYYYMMDD()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime date1 = DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("yyyy-MM-dd");
            return ssDate;
        }
        public static string GetDateFormated(string Date)
        {

            DateTime date1 = DateTime.ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("MM/dd/yyyy");
            return ssDate;
        }
        public static string GeCurrentDate()
        {
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            DateTime date1 = DateTime.ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string ssDate = date1.ToString("MM/dd/yyyy");
            return ssDate;
        }
     

    }
}
