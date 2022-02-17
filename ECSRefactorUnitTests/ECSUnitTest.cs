using NUnit.Framework;
using ECS_DesignedForTestability;

namespace ECSRefactorUnitTests
{
    public class Tests
    {
        private ECS _uut;
        private FakeTempSensor _tempSensor;
        private FakeHeater _heater;
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(5,10,true)]
        [TestCase(5, 2, false)]
        [TestCase(36, 20, false)]
        [TestCase(10, 11, true)]
        [TestCase(15, 17, true)]
        public void TestOfRegulateWhereHeaterStateIsAsExpected(int temp, int threshold, bool exp)
        {
            _uut = new ECS(threshold);
            _heater = new FakeHeater();
            _uut._heater = _heater;
            _tempSensor = new FakeTempSensor(temp);
            _uut._tempSensor = _tempSensor;

            _uut.Regulate();
            Assert.That(_heater._heaterOn, Is.EqualTo(exp));
        }
        //Vi bygger det nu
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(15)]
        [TestCase(18)]
        public void TestCorrectSetThreshold(int threshold)
        {
            _uut = new ECS(threshold);

            
            Assert.That(_uut.GetThreshold(), Is.EqualTo(threshold));
        }
    }
}