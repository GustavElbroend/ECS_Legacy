using NUnit.Framework;

namespace ECSRefactorUnitTests
{
    public class Tests
    {
        private FakeHeater _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new FakeHeater();
        }

        [TestCase()]
        public void TestTurnOn()
        {
            Assert.Pass();
        }
    }
}