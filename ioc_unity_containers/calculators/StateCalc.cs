using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.calculators
{
    public class StateCalc : ICalculator
    {
        private int index;

        public StateCalc(int index)
        {
            this.index = index;
        }

        public string Eval(string a, string b)
        {

            return $"{a}{b}{index++}";
        }
    }
}
