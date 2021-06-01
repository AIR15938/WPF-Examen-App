using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.ViewModel
{
    public class CalcTempViewModel : BindableBase
    {
        private double _inputTemperature;
        private double _result;
        private bool _calculateFahrenheit;
        private bool _calculateCelsius;
        private ICalcTempService _calcTempService;

        ICalcTempService CalcTempService
        {
            get { return _calcTempService; }
            set { _calcTempService = value; }
        }

        public CalcTempViewModel(ICalcTempService calcTempService)
        {
            CalcTempService = calcTempService;
            CalculateFahrenheit = true;
        }

        public double InputTemperature
        {
            get { return _inputTemperature; }
            set
            {
                _inputTemperature = value;
                ConvertTemperature();
                
            }
        }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                
            }
        }

        public bool CalculateFahrenheit
        {
            get { return _calculateFahrenheit; }
            set
            {
                _calculateFahrenheit = value;
                ConvertTemperature();
               
            }
        }

        public bool CalculateCelsius
        {
            get { return _calculateCelsius; }
            set
            {
                _calculateCelsius = value;
                ConvertTemperature();
             
            }
        }

        private void ConvertTemperature()
        {
            if (CalculateFahrenheit)
                Result = CalcTempService.CalculateFahrenheit(InputTemperature);
            else
                Result = CalcTempService.CalculateCelsius(InputTemperature);
        }
    

    }
}
