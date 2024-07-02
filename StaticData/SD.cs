using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public static class SD
    {
        public static string LocalCurCode { get; set; } = "OMR";
        public static string LocalCurName { get; set; } = "OMANI RIYAL";
         public static string LocalCurCodeRemit { get; set; } = "OMR";
          public static string LocalCurCodeAccode { get; set; } = "10011213141";// forex  //Currency Ledger a/c most of tome both same som exchange need diff account code
        public static string LocalCurCodeRemitAccode { get; set; } = "10011213141";// remittance //Currency Ledger a/c
        public static string RemittanceUSD { get; set; } = "USD";
        public static string USDRemitAccode { get; set; } = "10011213273";// remittance // USD Curcode // 
        public static string OrgCode { get; set; } = "00001";
        public static string OrgnizationName { get; set; } = "PurpleBC Exchange LLC";
        public static string HeadOfficeBranchCode { get; set; } = "00000";
        public static string Concode { get; set; } = "OM";
        public static string AppUrl { get; set; } = "http://localhost:8080/";
        public static string ApiUrl { get; set; } = "http://localhost:8080/";
        public static string ServerTimeZone { get; set; } = "+01:00"; // Oman TIME zONE 01 UAE 04 Server Time Zon
        public static string LoginContTimeZone { get; set; } = "+01:00"; // Oman user login Country
        public static string FinancialYear { get; set; } = GetFinalYearDate();
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
            catch (Exception EX)
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
                return ssDate + " 23:23:59";
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
          


            try
            {
                string Date = DateTime.Now.ToString("MM/dd/yyyy");

                string time1 = DateTime.Now.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss");
                DateTime originalDate = DateTime.ParseExact(time1.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string formattedDateString = originalDate.ToString("MM/dd/yyyy");
              
                return formattedDateString;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error parsing date: " + ex.Message);
                return ServerDateTime();
            }
        }
        public static string ServerDateTime()
        {
            DateTime time1 = DateTime.Now.ToLocalTime();

            double dMin = Convert.ToDouble("." + SD.ServerTimeZone.Substring(SD.ServerTimeZone.IndexOf(':') + 1)) * 100 / 60;
            double dHr = Convert.ToDouble(SD.ServerTimeZone.Substring(0, SD.ServerTimeZone.IndexOf(':')));
            double dST = 0;

            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;

            time1 = time1.AddHours(-1 * dST);
            time1 = time1.AddHours(Convert.ToDouble(SD.LoginContTimeZone.Replace(":", ".")));

            return time1.ToString("dd/MMM/yyyy HH:mm:ss");
        }
        public static string serverTimeDDMMYYYY()
        {
            DateTime time1 = DateTime.Now.ToLocalTime();

            double dMin = Convert.ToDouble("." + SD.ServerTimeZone.Substring(SD.ServerTimeZone.IndexOf(':') + 1)) * 100 / 60;
            double dHr = Convert.ToDouble(SD.ServerTimeZone.Substring(0, SD.ServerTimeZone.IndexOf(':')));
            double dST = 0;

            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;

            time1 = time1.AddHours(-1 * dST);
            time1 = time1.AddHours(Convert.ToDouble(SD.LoginContTimeZone.Replace(":", ".")));

            return time1.ToString("dd/MMM/yyyy");
        }
        public static string getTimeZone(string timezonestring)
        {

            string[] time = null;


            try
            {
                time = timezonestring.Split(')');

                time[0] = time[0].Remove(0, 4);
                return time[0];
            }
            catch (Exception)
            {
                return "0:00";
            }
        }


    }
}
