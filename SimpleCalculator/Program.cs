using System;
using System.Data.Odbc;
using System.Text;

namespace SimpleCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double input;
            string output;
            string operation;
            double firstNumber = 0;
            double secondNumber = 0;
            try
            {
                InputCoverter inputCoverter = new InputCoverter();
                CalculatorEngine.CalculatorEngine calculatorEngine = new CalculatorEngine.CalculatorEngine();

                Console.WriteLine("Enter a numbered valueas  ");

                //Verifies if it's a number and not a word.
                while (!double.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("The value must be a number, please try again, try a number from 1 to 10 for example");
                output = input.ToString();
                firstNumber = inputCoverter.ConvertedInputToNumeric(output);

                Console.WriteLine("Enter a second number");
                //Verifies if it's a number and not a word.
                while (!double.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("The value must be a number, please try again, try a number from 1 to 10 for example");

                output = input.ToString();
                secondNumber = inputCoverter.ConvertedInputToNumeric(output);

                Console.WriteLine("Enter an operation");
                operation = Console.ReadLine().ToLower();
                //Verifies if the operator is valid
                while (operation != "+" && operation != "plus" && operation != "-" && operation != "minus" && operation != "*" && operation != "multiply" && operation != "/" && operation != "divided" && operation != "%" && operation != "modulus")
                {
                    Console.WriteLine("Please enter any valid operation by symbol or their word, like + is also 'plus'");

                    operation = Console.ReadLine().ToLower();
                }

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                //String Builder
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.Append(String.Format("The value of {0} ", firstNumber));
                sb.Append(String.Format("{0} ", operation));
                sb.Append(String.Format("{0} is ", secondNumber));
                sb.Append(result.ToString("0.##"));
                Console.WriteLine(sb);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //real life - log this error
            }
        }
    }
}