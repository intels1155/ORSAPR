using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model.Parameters
{
	/// <summary>
	/// Класс параметров ключа
	/// </summary>
	public class WrenchParameters
	{

		/// <summary>
		/// Ширина трубки ключа
		/// </summary>
		private Parameter _tubeWidth;

		/// <summary>
		/// Диаметр отверстий ключа
		/// </summary>
		private Parameter _holesDiameter;

		/// <summary>
		/// Длина ключа
		/// </summary>
		private Parameter _wrenchLength;

		/// <summary>
		/// Тип сечения ключа,
		/// false - шестигранный, true - круглый
		/// </summary>
		private bool _roundSection;

		/// <summary>
		/// Конструктор класса WrenchParameters
		/// </summary>
		/// <param name="leftOpeningSize">Размер зева 1</param>
		/// <param name="leftOpeningDepth">Глубина зева 1</param>
		/// <param name="rightOpeningSize">Размер зева 2</param>
		/// <param name="rightOpeningDepth">Глубина зева 2</param>
		/// <param name="wallThickness">Толщина стенок ключа</param>
		/// <param name="tubeWidth">Ширина трубки ключа</param>
		/// <param name="holesDiameter">Диаметр отверстий ключа</param>
		/// <param name="wrenchLength">Длина ключа</param>
		/// <param name="roundSection"></param>
		public WrenchParameters(
			double leftOpeningSize,
			double leftOpeningDepth,
			double rightOpeningSize,
			double rightOpeningDepth,
			double wallThickness,
			double tubeWidth,
			double holesDiameter,
			double wrenchLength,
			bool roundSection)
		{

			LeftOpeningSize = new Parameter("Размер зева 1", 4, 75, leftOpeningSize);
			LeftOpeningDepth = new Parameter("Глубина зева 1", 2, 50, leftOpeningDepth);
			RightOpeningSize = new Parameter("Размер зева 2", 5, 80, rightOpeningSize);
			RightOpeningDepth = new Parameter("Глубина зева 1", 2.5, 50, rightOpeningDepth);
			WallThickness = new Parameter("Толщина стенки ключа", 2, 14, wallThickness);
			TubeWidth = new Parameter("Ширина трубки ключа", 4, 75, tubeWidth);
			HolesDiameter = new Parameter("Диаметр отверстий ключа", 2, 40, holesDiameter);
			WrenchLength = new Parameter("Длина ключа", 80, 400, wrenchLength);
			RoundSection = roundSection;
		}

		public WrenchParameters():this(16,24,18,26,4,14,6,180, false)
        {}

		/// <summary>
		/// Ширина зева ключа 1
		/// </summary>
		public Parameter LeftOpeningSize { get; set; }

        /// <summary>
		/// Глубина зева ключа 1
		/// </summary>
		public Parameter LeftOpeningDepth { get; set; }

        /// <summary>
		/// Ширина зева ключа 2
		/// </summary>
		/// 		
		public Parameter RightOpeningSize { get; set; }

		/// <summary>
		/// Глубина зева ключа 2
		/// </summary>
		/// 		
		public Parameter RightOpeningDepth { get; set; }


		/// <summary>
		/// Толщина стенок ключа
		/// </summary>
		public Parameter WallThickness { get; set; }

		/// <summary>
		/// Ширина трубки ключа
		/// </summary>
		public Parameter TubeWidth
		{
			get => _tubeWidth;
			set
			{
				if (value.Value > RightOpeningSize.Value 
                    || value.Value > LeftOpeningSize.Value)
				{
					throw new ArgumentException($"- {value.Name} " + 
						$"не может быть больше размера зевов");
				}
				else
				{
					_tubeWidth = value;
				}
			}
		}

		/// <summary>
		/// Диаметр отверстий ключа
		/// </summary>
		public Parameter HolesDiameter
		{
			get => _holesDiameter;
			set
			{
				const double minimalDiameterRatio = 0.75;
				double minimalDiameter = minimalDiameterRatio * TubeWidth.Value;
				if (value.Value > minimalDiameter)
				{
					throw new ArgumentException($"- {value.Name} не может превышать " +
						$"{minimalDiameterRatio} от диаметра трубки");
				}
				else
				{
					_holesDiameter = value;
				}
			}
		}

		/// <summary>
		/// Длина ключа
		/// </summary>
		public Parameter WrenchLength
		{
			get => _wrenchLength;
			set
			{
				const double minimalLengthCoefficient = 2;
				double minimalLength = (LeftOpeningDepth.Value + RightOpeningDepth.Value 
					+ HolesDiameter.Value) * minimalLengthCoefficient;
				if (value.Value < minimalLength)
				{
					//TODO: RSDN +
					throw new ArgumentException($"- {value.Name} при данном " +
						$"диаметре отверстий и глубине зевов " +
						$"должна составлять минимум {minimalLength} мм");
				}
				else
				{
					_wrenchLength = value;
				}
			}
		}

		/// <summary>
		/// Тип сечения средней части ключа
		/// </summary>
		public bool RoundSection { get; set; }
	}
}
