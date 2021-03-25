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

		public double Minimum { get; private set; }

        public double Maximum { get; private set; }

		private double _value;

		public Parameter(string name, double minimum, double maximum, double value)
        {
			Name = name;
            Minimum = minimum;
			Maximum = maximum;
			Value = value;
		}

		public double Value
		{
			get => _value;
			set
			{
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
	}
}
