using Dapper;
using DataAccess;

namespace Helper
{
    public class CSysControl
    {
        private readonly ISqlDataAccess Db;
        public CSysControl(ISqlDataAccess _Db)
        {
            Db = _Db;

        }
        public  DateTime ServerDateTime()
        {
            string ServerTimeZone = "04:00";
            string LoginContTimeZone = "04:00";
            DateTime time = DateTime.Now.ToLocalTime();
            string _serverTimeZone = ServerTimeZone;
            double dMin = Convert.ToDouble("." + _serverTimeZone.Substring(_serverTimeZone.IndexOf(':') + 1)) * 100 / 60;
            double dHr = Convert.ToDouble(_serverTimeZone.Substring(0, _serverTimeZone.IndexOf(':')));
            double dST = 0;
            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;
            time = time.AddHours(-1 * dST);
            time = time.AddHours(Convert.ToDouble(LoginContTimeZone.Replace(":", ".")));
            return time;
        }
        public  string serverTimeDDMMYYYY()
        {
            string ServerTimeZone = "04:00";
            string LoginContTimeZone = "04:00";
            DateTime time = DateTime.Now.ToLocalTime();
            string _serverTimeZone = ServerTimeZone;

            DateTime time1;
            time1 = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("dd/MMM/yyyy HH:mm:ss"));//.ToShortTimeString()
#pragma warning disable CS0436 // Type conflicts with imported type
            double dMin = Helper.Functions.ToDouble("." + ServerTimeZone.Substring(ServerTimeZone.IndexOf(':') + 1)) * 100 / 60;
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
            double dHr = Helper.Functions.ToDouble(ServerTimeZone.Substring(0, ServerTimeZone.IndexOf(':')));
#pragma warning restore CS0436 // Type conflicts with imported type
            double dST = 0;
            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;
            time1 = time1.AddHours(-1 * dST);
#pragma warning disable CS0436 // Type conflicts with imported type
            time1 = time1.AddHours(Helper.Functions.ToDouble(LoginContTimeZone.Replace(":", ".")));
#pragma warning restore CS0436 // Type conflicts with imported type
            return time1.ToString("dd/MMM/yyyy");
        }
        public  string GetMontName(string sMonth)
        {
            switch (sMonth)
            {
                case "1": return "Jan";
                case "2": return "Feb";
                case "3": return "Mar";
                case "4": return "Apr";
                case "5": return "May";
                case "6": return "Jun";
                case "7": return "Jul";
                case "8": return "Aug";
                case "9": return "Sep";
                case "10": return "Oct";
                case "11": return "Nov";
                case "12": return "Dec";
                default: return "";
            }
        }
        public  string GetValue(string strParm)
        {
            string sqlselect = @"SELECT TOP 1 VALUE  FROM Sys_Controle  WHERE Upper(PARAMETER) ='" + strParm.ToUpper() + "' ";
            DynamicParameters parameter = new DynamicParameters();
           string strVal = Db.ExecuteScalar<string>(sqlselect, parameter);
           
            
            return strVal;
        }
        public  string GetFinancialYr(string date)
        {
            string isYearEndProcessed = "" + GetValue("YEARENDPROCESSED");

            if (isYearEndProcessed != "Y")
                return GetValue("FINANCIALYEAR");
            else
            {
                try
                {
                    string year = Convert.ToDateTime(date).Year.ToString();
                    string finYr =GetValue("FINANCIALYEAR").Trim().Substring(0, 7);
                    return finYr + year;
                }
                catch { return GetValue("FINANCIALYEAR"); }
            }
        }

    }
}
