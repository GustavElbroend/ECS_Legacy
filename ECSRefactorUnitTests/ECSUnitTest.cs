using NUnit.Framework;
using ECS_DesignedForTestability;

namespace ECSRefactorUnitTests
{
    public class Tests
    {
        private ECS _uut;
        private ITempSensor _tempSensor;
        [SetUp]
        public void Setup()
        {
            _tempSensor = new FakeTempSensor();
            _uut = new ECS(10);
            _uut._heater = new FakeHeater();
            _uut._tempSensor = _tempSensor;
        }

        [TestCase(5,10,true)]
        public void TestOfRegulateWhereHeaterTurnsOn(int temp, int threshold, bool exp)
        {
            _tempSensor.
            _uut.Regulate();
            _uut._heater.

            Assert.Pass();
        }

        [TestCase()]
        public void TestTurnOn()
        {
            Assert.Pass();
        }
    }
}