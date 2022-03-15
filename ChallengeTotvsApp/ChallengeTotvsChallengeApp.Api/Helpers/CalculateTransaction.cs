using System;
using System.Collections.Generic;


namespace TotvsChallengeApp.Application.Helpers
{
    public static class CalculateTransaction
    {
        public static decimal CalculateChange(decimal totalCost, decimal amountPaid)
        {
            return amountPaid - totalCost;
        }

        public static List<string> CalculateChangeDetail(decimal change)
        {
			
			int B100, B50, B20, B10, C50, C10, C05, C01;
			B100 = 0;
			B50 = 0;
			B20 = 0;
			B10 = 0;
			C50 = 0;
			C10 = 0;
			C05 = 0;
			C01 = 0;

			var difference = change;
			var message = new List<string>();

			if (difference >= 100)
			{
				B100 = ((int)difference / 100);
				difference = difference - (B100 * 100);
				message.Add(string.Format("{0} Bilhete de BRL 100,00", B100));
			}

			if (difference >= 50)
			{
				B50 = ((int)difference / 50);
				difference = difference - (B50 * 50);
				message.Add(string.Format("{0} Bilhete de BRL 50,00", B50 ));
			}

			if (difference >= 20)
			{
				B20 = ((int)difference / 20);
				difference = difference - (B20 * 20);
				message.Add(string.Format("{0} Bilhete de BRL 20,00", B20));
			}

			if (difference >= 10)
			{
				B10 = ((int)difference / 10);
				difference = difference - (B10 * 10);
				message.Add(string.Format("{0} Bilhete de BRL 10,00", B10));
			}
			
			if (difference >= (decimal)0.50)
			{
				C50 = (int)(difference / (decimal)0.50);
				difference = difference - (decimal)(C50 * 0.50);
				message.Add(string.Format("{0} Moedas de BRL 0,50", C50));
			}

			if (difference >= (decimal)0.10)
			{
				C10 = (int)(difference / (decimal)0.10);
				difference = difference - (decimal)(C10 * 0.10);
				message.Add(string.Format("{0} Moedas de BRL 0,10" , C10));
			}

			if (difference >= (decimal)0.05)
			{
				C05 = (int)Math.Round(difference / (decimal)0.05);
				difference = difference - (decimal)(C05 * 0.05);
				message.Add(string.Format("{0} Moedas de BRL 0,05", C05));
			}

			if (difference >= (decimal)0.01)
			{
				C01 = (int)Math.Round(difference / (decimal)0.01);
				difference = difference - (decimal)(C01 * 0.01);
				message.Add(string.Format("{0} Moedas de BRL 0,01", C01));
			}

			return message;
		}

		public static bool CheckDecimals(decimal number)
        {
			return Decimal.Round(number, 2) == number;
        }
    }
}
