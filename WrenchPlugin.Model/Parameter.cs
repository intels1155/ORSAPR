using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model
{
    public class Parameter
    {
        public double Minimum { get; set; }

        public double Maximum { get; set; }

        public double Value { get; set; }

		public string ParameterName { get; set; }

        public Parameter(double minimum, double maximum, double value)
        {
            Minimum = minimum;
			Maximum = maximum;
			Value = value;
        }
    }
}
