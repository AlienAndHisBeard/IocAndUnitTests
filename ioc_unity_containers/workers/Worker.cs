using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.workers
{
    public class Worker
    {
        public Worker(ICalculator calculator) 
        {
            _calculator = calculator;
        }
        public void Work(string a, string b) 
        {
            Console.WriteLine(_calculator.Eval(a, b));
        }
        private ICalculator _calculator;
    }
}
