using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortageCalculator
{
     class Program
    {
        static void Main(string[] args)
        {
            // prompt user to enter a loan amount, interest rate, and number of terms
            Console.Write("Enter the loan amount: ");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.Write("Enter the interest rate (%):");
            double interestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the number of terms (months): ");
            double numberOfTerms = double.Parse(Console.ReadLine());

            // prompt user to select compounding interval

            Console.WriteLine("Select compounding interval: ");
            Console.WriteLine("1. Monthly");
            Console.WriteLine("2. Weekly");
            Console.WriteLine("3. Daily");
            Console.WriteLine("4. Continuously");
            Console.Write("Enter your choice (1-4): ");

            int compoundingIntervalOption = int.Parse(Console.ReadLine());

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

            // display monthly payment and total payment
            Console.WriteLine("Monthly Payment: {0:C}", monthlyPayment);
            Console.WriteLine("Total Payment: {0:C}", monthlyPayment * numberOfTerms);
        }
    }
}
