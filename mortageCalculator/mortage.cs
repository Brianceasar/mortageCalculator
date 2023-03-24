using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortageCalculator
{
     class mortage
    {
        static void Main(string[] args)
        {
            // prompt user to enter a loan amount, interest rate, and number of terms
            Console.Write("Enter the loan amount: ");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.Write("Enter the interest rate (%):");
            double interestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the number of terms (In months): ");
            double numberOfTerms = double.Parse(Console.ReadLine());

            // prompt user to select compounding interval

            Console.WriteLine("Select compounding interval: ");
            Console.WriteLine("1. Monthly");
            Console.WriteLine("2. Weekly");
            Console.WriteLine("3. Daily");
            Console.WriteLine("4. Continuously");
            Console.Write("Enter your choice (1-4): ");

            int compoundingIntervalOption = int.Parse(Console.ReadLine());


            // Prompt user to select currency
            Console.WriteLine("Select currency: ");
            Console.WriteLine("1 - USD");
            Console.WriteLine("2 - EUR");
            Console.WriteLine("3 - GBP");
            Console.WriteLine("4 - Tanzanian shilling");
            Console.Write("Enter option (1-4): ");
            int currencyOption = int.Parse(Console.ReadLine());

            // Convert loan amount to USD
            double usdLoanAmount;
            switch (currencyOption)
            {
                case 1: // USD
                    usdLoanAmount = loanAmount;
                    break;
                case 2: // EUR
                    usdLoanAmount = CurrencyConverter.ConvertToUSD(loanAmount, "EUR");
                    break;
                case 3: // GBP
                    usdLoanAmount = CurrencyConverter.ConvertToUSD(loanAmount, "GBP");
                    break;
                case 4: // Tanzanian shilling
                    usdLoanAmount = CurrencyConverter.ConvertToUSD(loanAmount, "TZS");
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Using USD as default currency.");
                    usdLoanAmount = loanAmount;
                    break;
            }


            // Calculate monthly interest rate based on selected compounding interval
            double monthlyInterestRate;
            switch (compoundingIntervalOption)
            {
                case 1: // monthly
                    monthlyInterestRate = interestRate / 12 / 100;
                    break;
                case 2: // weekly
                    monthlyInterestRate = interestRate / 52 / 100;
                    break;
                case 3: // daily
                    monthlyInterestRate = interestRate / 365 / 100;
                    break;
                case 4: // continuously
                    monthlyInterestRate = Math.Pow((1 + interestRate / 100), (1 / 12)) - 1;
                    break;
                default:
                    Console.WriteLine("Invalid option was selected. Using monthly compounding interval");
                    monthlyInterestRate = 0;
                    break;
            }
            // Calculate monthly payment
            double monthlyPayment = (loanAmount * monthlyInterestRate) / (1 - Math.Pow((1 + monthlyInterestRate), -numberOfTerms));

            // display monthly payment and total payment in USD
            Console.WriteLine("Monthly Payment: {0:C}", monthlyPayment);
            Console.WriteLine("Total Payment: {0:C}", monthlyPayment * numberOfTerms);

            // Convert monthly payment and total payment to selected currency
            switch (currencyOption)
            {
                case 1: // USD
                    break;
                case 2: // EUR
                    monthlyPayment = CurrencyConverter.ConvertToEUR(monthlyPayment, "USD");
                    break;
                case 3: // GBP
                    monthlyPayment = CurrencyConverter.ConvertToGBP(monthlyPayment, "USD");
                    break;
                case 4: // Tanzanian shilling
                    monthlyPayment = CurrencyConverter.ConvertToTZS(monthlyPayment, "USD");
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Using USD as default currency.");
                    break;
            }

            // Display monthly payment and total payment in selected currency
            switch (currencyOption)
            {
                case 1: // USD
                    break;
                case 2: // EUR
                    Console.WriteLine("Monthly payment (in EUR): {0:C}", monthlyPayment);
                    Console.WriteLine("Total payment (in EUR): {0:C}", monthlyPayment * numberOfTerms);
                    break;
                case 3: // GBP
                    Console.WriteLine("Monthly payment (in GBP): {0:C}", monthlyPayment);
                    Console.WriteLine("Total payment (in GBP): {0:C}", monthlyPayment * numberOfTerms);
                    break;
                case 4: // Tanzanian shilling
                    Console.WriteLine("Monthly payment (in TZS): {0:N0}", monthlyPayment);
                    Console.WriteLine("Total payment (in TZS): {0:N0}", monthlyPayment * numberOfTerms);
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Using USD as default currency.");
                    break;
            }
            // Calculate and display time to pay back loan
            Console.WriteLine("Time to pay back loan: {0} months", numberOfTerms);
        }
    }
    static class CurrencyConverter
    {
        public static double ConvertToUSD(double amount, string currencyCode)
        {
            // This is a placeholder implementation that returns a random number between 1&10
            Random random = new Random();
            return amount / (random.Next(1, 10));
        }
        public static double ConvertToEUR(double amount, string currencyCode)
        {
            // This is a placeholder implementation that simply returns a random number between 0.8 and 1.2
            Random random = new Random();
            return amount * (random.NextDouble() * 0.4 + 0.8);
        }

        public static double ConvertToGBP(double amount, string currencyCode)
        {
            // This is a placeholder implementation that simply returns a random number between 0.6 and 1.4
            Random random = new Random();
            return amount * (random.NextDouble() * 0.8 + 0.6);
        }

        public static double ConvertToTZS(double amount, string currencyCode)
        {
            // This is a placeholder implementation that simply returns a random number between 1000 and 1500
            Random random = new Random();
            return amount * (random.Next(1000, 1500));
        }
    }
}
