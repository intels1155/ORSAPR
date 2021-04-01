using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model.Parameters
{
	public class Parameter
	{
		/// <summary>
		/// Имя параметра
		/// </summary>
		private string _name;

		/// <summary>
		/// Минимальное значение параметра
		/// </summary>
		private double _minimum;

		/// <summary>
		/// Максимальное значение параметра
		/// </summary>
		private double _maximum;

		/// <summary>
		/// Значение параметра
		/// </summary>
		private double _value;

		/// <summary>
		/// Конструктор класса "Параметр"
		/// </summary>
		/// <param name="name">Имя параметра</param>
		/// <param name="minimum">Минимальное значение</param>
		/// <param name="maximum">Максимальное значение</param>
		/// <param name="value">Значение</param>
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

		/// <summary>
		/// Минимальное значение параметра
		/// </summary>
		public double Minimum
		{
			get => _minimum;
			set
			{
				ValidateDouble(value);
				_minimum = value;
			}
		}

		/// <summary>
		/// Максимальное значение параметра
		/// </summary>
		public double Maximum
		{
			get => _maximum;
			set 
			{
				if (value <= Minimum)
				{
					throw new ArgumentException("Максимум параметра меньше или равен минимуму");
				}
				ValidateDouble(value);
				_maximum = value;
			}
		}

		/// <summary>
		/// Имя параметра
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Имя параметра не может быть пустым");
				}
				else
				{
					_name = value;
				}
			}
		}

		/// <summary>
		/// Значение параметра
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				ValidateDouble(value);
				if (value < Minimum || value > Maximum)
				{
					throw new ArgumentException($"- {Name}: размер выходит за диапазон" +
						$" от {Minimum} до {Maximum} мм");
				}
				else
				{
					_value = value;
				}
			}
		}

		/// <summary>
		/// Проверка переменной типа double
		/// </summary>
		/// <param name="value"></param>
		private void ValidateDouble(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				throw new ArgumentException("Значение double не является числом");
			}
			else if (value <= 0)
			{
				throw new ArgumentException("Значение double меньше или равно нулю");
			}
		}
	}
}
