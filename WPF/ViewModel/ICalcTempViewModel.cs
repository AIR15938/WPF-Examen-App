using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.ViewModel
{
    public interface ICalcTempService
    {
        double CalculateFahrenheit(double celsius);
        double CalculateCelsius(double fahrenheit);
    }
}
