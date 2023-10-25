using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.calculators
{
    public class CatCalc : ICalculator
    {
        public CatCalc() { }
        public string Eval(string a, string b)
        {
            return a + b;
        }
    }
}
