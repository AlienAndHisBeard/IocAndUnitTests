using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.workers
{
    public class Worker3
    {
        public void Work(string a, string b)
        {
            Console.WriteLine(_calculator.Eval(a, b));
        }
        public ICalculator _calculator { get; set; }
    }
}
