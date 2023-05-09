using FactorialCalculator.Interfaces;

namespace FactorialCalculator.Util
{
    public class RecursiveFactorialCalculator : IFactorialCalculator
    {
        public int CalculateFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            else
            {
                return number * CalculateFactorial(number - 1);
            }
        }
    }
}
