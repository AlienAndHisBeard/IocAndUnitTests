using ioc_unity_containers.calculators;
using ioc_unity_containers.interfaces;
using ioc_unity_containers.workers;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ioc_unity_containers
{
    // Utility simplifing process of coniguring the containers
    public class Container
    {
        
        // Create the utility and use chosen congiguration setup
        public Container(bool useAppConfig, bool tests = false)
        {
            Cont = useAppConfig ? BuildContainerFromConfig(tests) : BuildContainerFromCode();
        }
        public UnityContainer Cont {  get; }

        // Create Unity container as described in App.config
        public static UnityContainer BuildContainerFromConfig(bool tests)
        {
            string configFile = "../../../App.config";
            if (tests)
            {
                configFile = "../../../../ioc_unity_containers/App.config";
            }

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException();
            }

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

            var container = new UnityContainer();
            unitySection.Configure(container, "cont");

            return container;
        }

        // Create Unity container by describing it in code
        public static UnityContainer BuildContainerFromCode()
        {
            UnityContainer cont = new UnityContainer();

            // register calculators
            cont.RegisterType<ICalculator, CatCalc> ("catcalc");
            cont.RegisterType<ICalculator, PlusCalc> ("pluscalc");
            cont.RegisterType<ICalculator, StateCalc>("statecalc", new ContainerControlledLifetimeManager(), new InjectionConstructor(1));

            // register main workers
            cont.RegisterType<Worker>("usecatcalc",
                new InjectionConstructor(new ResolvedParameter<ICalculator>("catcalc")));
            cont.RegisterType<Worker2>("usepluscalc",
                new InjectionMethod("SetCalc",
                new ResolvedParameter<ICalculator>("pluscalc")));
            cont.RegisterType<Worker3>("usecatcalc",
                new InjectionProperty("_calculator",
                new ResolvedParameter<ICalculator>("catcalc")));

            // register workers with state
            cont.RegisterType<Worker>("usestate",
            new InjectionConstructor(new ResolvedParameter<ICalculator>("statecalc")));
            cont.RegisterType<Worker2>("usestate",
                new InjectionMethod("SetCalc", new ResolvedParameter<ICalculator>("statecalc")));
            cont.RegisterType<Worker3>("usestate",
                new InjectionProperty("_calculator", new ResolvedParameter<ICalculator>("statecalc")));

            return cont;
        }
    }
}
