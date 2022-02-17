using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_DesignedForTestability;


namespace ECSRefactorUnitTests
{
    public class FakeTempSensor : ITempSensor
    {
        private int _temp;

        public FakeTempSensor(int temp)
        {
            _temp = temp;
        }
        public int GetTemp()
        {
            return _temp;
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}
