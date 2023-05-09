using FactorialCalculator.Interfaces;

namespace FactorialCalculator.Util
{
    public class ConsoleInputReader : IInputReader
    {
        public int ReadInput()
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                throw new ArgumentException("Invalid input. Please enter a valid integer.");
            }

            return number;
        }
    }
}
