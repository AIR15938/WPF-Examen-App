using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Model
{
    public class Temperature
    {

		public Temperature()
		{
			Celsius = 0;
			Fahrenheit = 32;
		
		}

		private double _celsius;
		private double _fahrenheit;
		private double _kelvin;

        public double Celsius { get; private set; }
        public double Fahrenheit { get; private set; }

        public void ChangeTemperatureFromCelsius(double temp)
		{
			
			Celsius = Math.Round(temp, 3);
			Fahrenheit = Math.Round((32 + (9 * temp) / 5), 3);
		}

	
		public void ChangeTemperatureFromKelvin(double temp)
		{
			
			Celsius = Math.Round((temp - 273.15), 3);
			Fahrenheit = Math.Round((((Celsius + 40) * 1.8) - 40), 3);
		}



	}
}
