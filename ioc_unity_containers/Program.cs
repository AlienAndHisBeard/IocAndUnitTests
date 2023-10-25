using ioc_unity_containers.workers;
using Unity;

namespace ioc_unity_containers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Imperative container");
            Container contUtility = new Container(false);
            IUnityContainer ImperativeContainer = contUtility.Cont;
            RunTheContainerTasks(ImperativeContainer);

            Console.WriteLine("Declarative container");
            contUtility = new Container(true);
            IUnityContainer DeclarativeContainer = contUtility.Cont;
            RunTheContainerTasks(DeclarativeContainer);
        }

        public static void RunTheContainerTasks(IUnityContainer cont)
        {
            // set up main workers
            var worker = cont.Resolve<Worker>("usecatcalc");
            var worker2 = cont.Resolve<Worker2>("usepluscalc");
            var worker3 = cont.Resolve<Worker3>("usecatcalc");

            // set up workers with state
            var workerWState = cont.Resolve<Worker>("usestate");
            var worker2WState = cont.Resolve<Worker2>("usestate");
            var worker3WState = cont.Resolve<Worker3>("usestate");

            // run some tasks
            worker.Work("1", "1");
            worker2.Work("2", "2");
            worker3.Work("3", "3");
            workerWState.Work("4", "4");
            worker2WState.Work("5", "5");
            worker3WState.Work("6", "6");
        }

    }
}