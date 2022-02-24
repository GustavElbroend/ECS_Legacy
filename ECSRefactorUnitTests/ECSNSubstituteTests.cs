using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ECS_DesignedForTestability;
using NSubstitute;

namespace ECSRefactorUnitTests
{
    public class ECSNSubstituteTests
    {
        private ECS _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private IWindow _window;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            _window = Substitute.For<IWindow>();
        }

        [TestCase(5, 10, true)]
        [TestCase(5, 2, false)]
        [TestCase(36, 20, false)]
        [TestCase(10, 11, true)]
        [TestCase(15, 17, true)]
        public void TestOfRegulateWhereHeaterStateIsAsExpected(int temp, int threshold, bool exp)
        {
            _uut = new ECS(threshold, 45, _heater, _tempSensor, _window);
            _tempSensor.GetTemp().Returns(temp);

            _uut.Regulate();

            if (exp)
            {
                _heater.Received(1).TurnOn();
            }
            else
            {
                _heater.Received(1).TurnOff();
            }
        }

        [TestCase(5, 25, false)]
        [TestCase(30, 26, true)]
        [TestCase(36, 21, true)]
        [TestCase(10, 23, false)]
        [TestCase(15, 24, false)]
        public void TestOfRegulateWhereWindowStateIsAsExpected(int temp, int windowthreshold, bool exp)
        {
            _uut = new ECS(10, windowthreshold, _heater, _tempSensor, _window);

            _tempSensor.GetTemp().Returns(temp);

            _uut.Regulate();

            if (exp)
            {
                _window.Received(1).OpenWindow();
            }
            else
            {
                _window.Received(1).CloseWindow();
            }
        }
    }
}
