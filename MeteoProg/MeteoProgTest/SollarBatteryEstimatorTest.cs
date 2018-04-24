using System;
using BussinesLogic;
using BussinesLogic.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MeteoProgTest
{
    [TestClass]
    public class SollarBatteryEstimatorTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            ILogger logger = new NullLogger();

           IWeatherDataProvider fakeProvider = new FakeWeatherProvider(logger);
            
           var sollarbattery = new SollarBatteryEstimator(fakeProvider, logger);

            var estimationForWeak = sollarbattery.GetEnergyEstimationForWeak();

            Assert.AreEqual(1570, estimationForWeak);
        }
    }
}
