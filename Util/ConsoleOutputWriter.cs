using FactorialCalculator.Interfaces;

namespace FactorialCalculator.Util
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteOutput(int result)
        {
            Console.WriteLine($"Factorial: {result}");
        }
    }
}
