using FactorialCalculator.Interfaces;
using FactorialCalculator.Util;

namespace FactorialCalculator
{
    public class FactorialProgram
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly IFactorialCalculator _calculator;

        private static FactorialProgram? _instance;
        private static readonly object _lock = new object();

        public FactorialProgram(IInputReader inputReader, IOutputWriter outputWriter, IFactorialCalculator calculator)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
            _calculator = calculator;
        }

        public static FactorialProgram GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FactorialProgram(new ConsoleInputReader(), new ConsoleOutputWriter(), new RecursiveFactorialCalculator());
                    }
                }
            }

            return _instance;
        }

        public void Run()
        {
            try
            {
                int number = _inputReader.ReadInput();
                int result = _calculator.CalculateFactorial(number);
                _outputWriter.WriteOutput(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
