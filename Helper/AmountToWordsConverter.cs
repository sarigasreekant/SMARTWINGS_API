namespace Helper
{
    public class AmountToWordsConverter
    {
        private static string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static string[] teens = { "", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static string ConvertToWords(double amount)
        {
            int integerPart = (int)Math.Floor(amount);
            int decimalPart = (int)((amount - Math.Floor(amount)) * 100);

            string words = ConvertToWords(integerPart);

            if (decimalPart > 0)
            {
                words += " and " + ConvertToWords(decimalPart) + " Cents";
            }

            return words;
        }

        private static string ConvertToWords(int amount)
        {
            if (amount == 0)
            {
                return units[0];
            }

            if (amount < 0)
            {
                return "Negative " + ConvertToWords(-amount);
            }

            string words = "";

            if ((amount / 1000000) > 0)
            {
                words += ConvertToWords(amount / 1000000) + " Million ";
                amount %= 1000000;
            }

            if ((amount / 1000) > 0)
            {
                words += ConvertToWords(amount / 1000) + " Thousand ";
                amount %= 1000;
            }

            if ((amount / 100) > 0)
            {
                words += ConvertToWords(amount / 100) + " Hundred ";
                amount %= 100;
            }

            if (amount > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                if (amount < 10)
                {
                    words += units[amount];
                }
                else if (amount < 20)
                {
                    words += teens[amount - 10];
                }
                else
                {
                    words += tens[amount / 10];
                    if ((amount % 10) > 0)
                    {
                        words += "-" + units[amount % 10];
                    }
                }
            }

            return words;
        }
    }
}
