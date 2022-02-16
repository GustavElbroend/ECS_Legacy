using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_DesignedForTestability;

namespace ECSRefactorUnitTests
{
    public class FakeHeater : IHeater
    {
        private bool _heaterOn = false;

        public void TurnOn()
        {
            _heaterOn = true;
        }

        public void TurnOff()
        {
            _heaterOn = false;
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}
