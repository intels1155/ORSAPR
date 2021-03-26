using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model
{
	public class Parameter
	{
		public string Name { get; set; }

		private double _minimum;

		private double _maximum;

		private double _value;

		public Parameter(string name, double minimum, double maximum, double value)
		{
			
			if (minimum >= maximum)
			{
				throw new ArgumentException($"{name}: максимум параметра меньше или равен минимуму");
			}
			Name = name;
			Minimum = minimum;
			Maximum = maximum;
			Value = value;
		}

		public void CheckRange(string name, double minimum, double maximum, double value)
		{
			if (minimum >= maximum)
			{
				throw new ArgumentException($"Диапазон параметра '{name}' задан неверно");
			}
		}

		public double Minimum
		{
			get => _minimum;
			set
			{
				ValidateDouble(value);
				_minimum = value;
			}
		}

		public double Maximum
		{
			get => _maximum;
			set 
			{
				ValidateDouble(value);
				_maximum = value;
			}
		}

		public double Value
		{
			get => _value;
			set
			{
				ValidateDouble(value);
				if (value < Minimum || value > Maximum)
				{
					throw new ArgumentException($"- {Name}: размер выходит за диапазон " +
						$"от {Minimum} до {Maximum} мм");
				}
				else
				{
					_value = value;
				}
			}
		}

		private void ValidateDouble(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				throw new ArgumentException("Значение не является числом");
			}
			else if (value <= 0)
			{
				throw new ArgumentException("Значение double меньше или равно нулю");
			}
		}
	}
}
