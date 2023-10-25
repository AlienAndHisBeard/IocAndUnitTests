using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.workers
{
    public class Worker2
    {
        public void Work(string a, string b)
        {
            Console.WriteLine(_calculator.Eval(a, b));
        }
        public void SetCalc(ICalculator calculator) { _calculator = calculator; }
        private ICalculator _calculator;
    }
}
