using ioc_unity_containers;

namespace ioc_unit_tests
{
    public class CalcUnitTests
    {

        private UnityContainer _container;

        public UnityContainer BuildContainerBasedOnFlag(bool useAppConfig)
        {
            Container contUtility = new Container(useAppConfig, true);
            _container = contUtility.Cont;
            return _container;
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingCatCalc_ShouldReturnCatCalc(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var catCalc = _container.Resolve<ICalculator>("catcalc");

            catCalc.Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void EvalWithCatCalc_ShouldReturn_12(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var catCalc = _container.Resolve<ICalculator>("catcalc");

            catCalc.Eval("1", "2").Should().Be("12");
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingLabWorker_ShouldReturnLabWorker(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var labWorker = _container.Resolve<Worker>("usecatcalc");

            labWorker.Should().NotBeNull();
        }



        [Theory]
        [InlineData(true, "1", "2", "12")]
        [InlineData(true, "-1", "2", "-12")]
        [InlineData(true, "0", "0", "00")]
        [InlineData(false, "1", "2", "12")]
        [InlineData(false, "-1", "2", "-12")]
        [InlineData(false, "0", "0", "00")]
        public void WorkWithLabWorker_ShouldReturnConcantatedString(bool useAppConfig, string a, string b, string expected)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var labWorker = _container.Resolve<Worker>("usecatcalc");
            using (var sw = new StringWriter()){
                Console.SetOut(sw);

                labWorker.Work(a, b);

                var result = sw.ToString().Trim();
                result.Should().Be(expected);
            }
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingLabWorker2_ShouldReturnLabWorker2(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var labWorker = _container.Resolve<Worker2>("usepluscalc");

            labWorker.Should().NotBeNull();
        }



        [Theory]
        [InlineData(true, "1", "2", "3")]
        [InlineData(true, "-1", "2", "1")]
        [InlineData(true, "0", "0", "0")]
        [InlineData(false, "1", "2", "3")]
        [InlineData(false, "-1", "2", "1")]
        [InlineData(false, "0", "0", "0")]
        public void WorkWithLabWorker2_ShouldReturnAddedNumbers(bool useAppConfig, string a, string b, string expected)
        {
            BuildContainerBasedOnFlag(useAppConfig);
            var labWorker = _container.Resolve<Worker2>("usepluscalc");
            using (var sw = new StringWriter()){
                Console.SetOut(sw);

                labWorker.Work(a, b);

                var result = sw.ToString().Trim();
                result.Should().Be(expected);
            }
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingLabWorker3_ShouldReturnLabWorker3(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var labWorker = _container.Resolve<Worker3>("worker3");

            labWorker.Should().NotBeNull();
        }



        [Theory]
        [InlineData(true, "1", "2", "12")]
        [InlineData(true, "-1", "2", "-12")]
        [InlineData(true, "0", "0", "00")]
        [InlineData(false, "1", "2", "12")]
        [InlineData(false, "-1", "2", "-12")]
        [InlineData(false, "0", "0", "00")]
        public void WorkWithLabWorker3_ShouldReturnConcantatedString(bool useAppConfig, string a, string b, string expected)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var labWorker = _container.Resolve<Worker3>("usecatcalc");
            using (var sw = new StringWriter()){
                Console.SetOut(sw);

                labWorker.Work(a, b);

                var result = sw.ToString().Trim();
                result.Should().Be(expected);
            }
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingPlusCalc_ShouldReturnPlusCalc(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var plusCalc = _container.Resolve<ICalculator>("pluscalc");

            plusCalc.Should().NotBeNull();
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void EvalWithPlusCalc_ShouldReturn3(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var plusCalc = _container.Resolve<ICalculator>("pluscalc");

            plusCalc.Should().NotBeNull();

            plusCalc.Eval("1", "2").Should().Be("3");
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingStateCalc_ShouldReturnStateCalc(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var stateCalc = _container.Resolve<ICalculator>("statecalc");

            stateCalc.Should().NotBeNull();
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ResolvingStateCalcMultipleTimes_ShouldReturnTheSameStateCalc(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var stateCalc = _container.Resolve<ICalculator>("statecalc");

            var stateCalc2 = _container.Resolve<ICalculator>("statecalc");

            stateCalc.Should().Be(stateCalc2);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MultipleEvalsWithStateCalc_ShouldReturnIncrementedValue(bool useAppConfig)
        {
            BuildContainerBasedOnFlag(useAppConfig);

            var stateCalc = _container.Resolve<ICalculator>("statecalc");

            var stateCalc2 = _container.Resolve<ICalculator>("statecalc");

            stateCalc.Eval("1", "2").Should().Be("121");
            stateCalc2.Eval("1", "2").Should().Be("122");
        }

    }
}