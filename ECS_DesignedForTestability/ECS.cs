using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ECS_DesignedForTestability
{
    public class ECS
    {
        private int _threshold;
        private int _windowThreshold;
        public ITempSensor _tempSensor { private get; set; }
        public  IHeater _heater { private get; set; }
        public IWindow _window { private get; set; }
        public bool StartIsActive { get; set; }

        public ECS(int thr, int windowThreshold, IHeater heater, ITempSensor tempSensor, IWindow window)
        {
            SetThreshold(thr);
            SetWindowThreshold(windowThreshold);
            _window = window;
            _heater = heater;
            _tempSensor = tempSensor;
            StartIsActive = true;
        }

        public void Run()
        {
            while (true)
            {
                while (StartIsActive)
                {
                    Regulate();
                    Thread.Sleep(1000);
                }
            }
        }

        public void Regulate()
        {
            if (_windowThreshold < _threshold)
                throw new Exception("Invalid setup");

            var t = _tempSensor.GetTemp();
                Console.WriteLine($"Temperature measured was {t}");
                if (t < _threshold)
                    _heater.TurnOn();
                else
                    _heater.TurnOff();

                if (t > _windowThreshold)
                    _window.OpenWindow();
                else
                {
                    _window.CloseWindow();
                }
        }
        
        public void SetWindowThreshold(int thr)
        {
            _windowThreshold = thr;
        }

        public int GetWindowThreshold()
        {
            return _windowThreshold;
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
