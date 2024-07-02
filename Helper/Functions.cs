namespace Helper
{
    public class Functions
    {
        public Functions()
        {
        }
        public static string RegExReplace(string str, string pattern)
        {
            try
            {
                str = System.Text.RegularExpressions.Regex.Replace(str, @"[^\u0000-\u007F]", "");

                if (pattern != "")
                    str = System.Text.RegularExpressions.Regex.Replace(str, "[" + pattern + "]", "");
                else
                    str = System.Text.RegularExpressions.Regex.Replace(str, "[~`@#$!%\\^&*ÄÂ()_\\-+=<>?;'\"\\[\\]\\|]", "");

                return str;
            }
            catch (Exception)
            {

                return "";
            }
        }
        public static string ConvertDate(string sDate)
        {
            //string[] langArray
            string sOut = "";
            try
            {
                string[] str = sDate.Split('/');
                sOut = str[1].ToString() + '/' + str[0].ToString() + '/' + str[2].ToString();

                return sOut;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool CheckDate(string sDate)
        {
            //string[] langArray
            try
            {
                bool bOut = false;
                string[] str = sDate.Split('/');
                if (int.Parse(str[0]) == 0 | int.Parse(str[2]) == 0)
                {
                    bOut = false;
                    return bOut; // TODO: might not be correct. Was : Exit Function
                }
                if (int.Parse(str[0]) > 31 | int.Parse(str[1]) > 12 | int.Parse(str[2]) < 1900)
                {
                    //Or CInt(str(2)) > Date.Now.Year
                    bOut = false;
                    return bOut; // TODO: might not be correct. Was : Exit Function
                }
                bOut = true;
                return bOut;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool IsNumeric(object num)
        {
            try
            {
                Convert.ToDouble(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int ToInt(object num)
        {
            try
            {
                return Convert.ToInt32(num);
            }
            catch
            {
                return 0;
            }
        }

        public static Double ToDouble(object num)
        {
            try
            {
                return Convert.ToDouble(num);
            }
            catch
            {
                return 0;
            }
        }

        public static System.Decimal ToDecimal(object num)
        {
            try
            {
                return decimal.Parse(num.ToString());
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static int Multiple(int intNum, int intNoTimes)
        {
            int intMultipleVal = 1;
            for (int i = 1; i <= intNoTimes; i++)
            {
                intMultipleVal *= intNum;
            }

            return intMultipleVal;

        }

        public static bool IsCheck(Object objDate)
        {
            string strDate = objDate.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDate(Object objDate)
        {
            string strDate = objDate.ToString();
            try
            {
                //DateTime dt = DateTime.Parse(strDate, new System.Globalization.CultureInfo("[en-NZ]")); // Convert.ToDateTime(objDate);//DateTime.ParseExact(strDate,"dd/MM/yyyy",null);
                DateTime dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", null);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static string ToDateDDMMYY(string dat)
        {
            DateTime dt = Convert.ToDateTime(dat);
            return dt.ToString("dd/mm/yy");
        }

        public static string ToDateDDMMMYYYY(string dat)
        {
            if (!IsDate(dat)) return dat;
            string[] strDt;
            strDt = dat.Split('/');
            if (strDt.Length < 3)
                strDt = dat.Split('-');
            if (ToInt(strDt[1]) > 12)
            {
                string strTmp = strDt[1];
                strDt[1] = strDt[0];
                strDt[0] = strTmp;
            }
            dat = strDt[0] + "/" + strDt[1] + "/" + strDt[2];

            try
            {
                DateTime dt = Convert.ToDateTime(dat);
                return dt.ToString("dd/MMM/yyyy");
            }
            catch (Exception)
            {
                if (ToInt(strDt[0]) > 12)
                {
                    string strTmp = strDt[0];
                    strDt[0] = strDt[1];
                    strDt[1] = strTmp;
                }
                dat = strDt[0] + "/" + strDt[1] + "/" + strDt[2];
                DateTime dt = Convert.ToDateTime(dat);
                return dt.ToString("dd/MMM/yyyy");
            }
        }

        public static string FormatDate(string sDateTime, string sFormat)
        {
            try
            {
                return Convert.ToDateTime(sDateTime).ToString(sFormat);
            }
            catch (Exception)
            {
                return sDateTime;
            }
        }

        public static char ToChar(object objChar)
        {
            try
            {
                return Convert.ToChar(objChar);
            }
            catch
            {
                return Convert.ToChar(' ');
            }
        }

        public String ChangeNumericToWords(int Num)
        {

            int rem;
            int count = 2;

            int rem1;
            int position = 0;
            string Words;

            rem = Num % 10;
            rem1 = rem;
            Num = Num / 10;
            rem = Num % 10;
            if (rem1 == 0)
            {
                Words = Conv2(rem);
            }
            else
            {
                if (rem == 1)
                {
                    Words = Conv3(rem1);
                }
                else
                    Words = Conv2(rem) + Conv1(rem1);
            }
            Num = Num / 10;
            while (Num > 0)
            {
                rem1 = rem;
                rem = Num % 10;
                count++;

                if (count == 3)
                {
                    if (Words == "")
                        Words = Conv1(rem) + " " + position;
                    else
                        Words = Conv1(rem) + " " + position + " " + "and" + " " + Words;
                }
                if (count == 4 || count == 6 || count == 8)
                {
                    if (Next(Num) == 1)
                    {
                        Words = Conv3(rem) + " " + position + " " + Words;
                        count++;
                        Num = Num / 10;
                        rem = Num % 10;

                    }
                    else
                        Words = Conv1(rem) + " " + position + " " + Words;
                }

                if ((count == 5 || count == 7 || count == 9) && rem != 1)
                {
                    Words = Conv2(rem) + " " + Words;
                    position = position - 1;

                }
                if (count == 10)
                {
                    Words = Conv1(rem) + " " + "hundred and" + " " + Words;
                    Words = Words.Replace("hundred and zero", "hundred");
                }

                Num = Num / 10;
                position = position + 1;
            }

            Words = Words.Replace("0", "hundred");
            Words = Words.Replace("1", "thousand");
            Words = Words.Replace("2", "lakh");
            Words = Words.Replace("3", "crore");
            Words = Words.Replace(" zero crore", "");
            Words = Words.Replace(" zero lakh", "");
            Words = Words.Replace(" zero thousand", "");
            Words = Words.Replace(" zero hundred", "");
            Words = Words.Replace("zero", "");

            string start = Words.Substring(0, 1);
            start = start.ToUpper();
            Words = Words.Remove(0, 1);
            return start + Words;
        }

        string Conv1(int rs)
        {
            string Word;
            switch (rs)
            {
                case 1:
                    Word = "one";
                    break;
                case 2:
                    Word = "two";
                    break;
                case 3:
                    Word = "three";
                    break;
                case 4:
                    Word = "four";
                    break;
                case 5:
                    Word = "five";
                    break;
                case 6:
                    Word = "six";
                    break;
                case 7:
                    Word = "seven";
                    break;
                case 8:
                    Word = "eight";
                    break;
                case 9:
                    Word = "nine";
                    break;
                case 10:
                    Word = "ten";
                    break;
                default:
                    Word = "zero";
                    break;
            }
            return Word;

        }

        string Conv2(int rs)
        {
            string Word;
            switch (rs)
            {
                case 1:
                    Word = "ten";
                    break;
                case 2:
                    Word = "twenty";
                    break;
                case 3:
                    Word = "thirty";
                    break;
                case 4:
                    Word = "fourty";
                    break;
                case 5:
                    Word = "fifty";
                    break;
                case 6:
                    Word = "sixty";
                    break;
                case 7:
                    Word = "seventy";
                    break;
                case 8:
                    Word = "eigty";
                    break;
                case 9:
                    Word = "ninety";
                    break;
                default:
                    Word = "";
                    break;
            }
            return Word;
        }

        string Conv3(int Num1)
        {
            string Word = "";
            switch (Num1)
            {

                case 1:
                    Word = "eleven";
                    break;
                case 2:
                    Word = "twelve";
                    break;
                case 3:
                    Word = "thirteen";
                    break;
                case 4:
                    Word = "fourteen";
                    break;
                case 5:
                    Word = "fifteen";
                    break;
                case 6:
                    Word = "sixteen";
                    break;
                case 7:
                    Word = "seventeen";
                    break;
                case 8:
                    Word = "eighteen";
                    break;
                case 9:
                    Word = "nineteen";
                    break;
                case 0:
                    Word = "ten";
                    break;
            }
            return Word;
        }


        int Next(int Num)
        {
            Num = Num / 10;
            int nextr;
            nextr = Num % 10;
            return nextr;

        }
    }
}
