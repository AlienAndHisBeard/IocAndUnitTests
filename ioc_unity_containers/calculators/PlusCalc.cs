using ioc_unity_containers.interfaces;

namespace ioc_unity_containers.calculators
{
    public class PlusCalc : ICalculator
    {
        public PlusCalc() { }
        public string Eval(string a, string b)
        {
            int intA, intB;
            if (!int.TryParse(a, out intA) || !int.TryParse(b, out intB))
                return "Did not parse to int";
            return $"{intA + intB}"; ;
        }
    }
}
