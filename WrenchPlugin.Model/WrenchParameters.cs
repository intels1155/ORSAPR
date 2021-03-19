using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model
{
	/// <summary>
	/// Класс параметров ключа.
	/// </summary>
	public class WrenchParameters
	{
		/// <summary>
		/// Ширина зева ключа 1
		/// </summary>
		private double _leftOpeningSize;

		/// <summary>
		/// Глубина зева ключа 1
		/// </summary>
		private double _leftOpeningDepth;

		/// <summary>
		/// Ширина зева ключа 2
		/// </summary>
		private double _rightOpeningSize;

		/// <summary>
		/// Глубина зева ключа 2
		/// </summary>
		private double _rightOpeningDepth;

		/// <summary>
		/// Толщина стенок ключа
		/// </summary>
		private double _wallThickness;

		/// <summary>
		/// Ширина трубки ключа
		/// </summary>
		private double _tubeWidth;

		/// <summary>
		/// Диаметр отверстий ключа
		/// </summary>
		private double _holesDiameter;

		/// <summary>
		/// Длина ключа.
		/// </summary>
		private double _wrenchLength;

		// Список ошибок в параметрах
		private List<string> _errorMessage = new List<string>();

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
		public WrenchParameters(
			double leftOpeningSize,
			double leftOpeningDepth,
			double rightOpeningSize,
			double rightOpeningDepth,
			double wallThickness,
			double tubeWidth,
			double holesDiameter,
			double wrenchLength)
		{

			LeftOpeningSize = leftOpeningSize;
			LeftOpeningDepth = leftOpeningDepth;
			RightOpeningSize = rightOpeningSize;
			RightOpeningDepth = rightOpeningDepth;
			WallThickness = wallThickness;
			TubeWidth = tubeWidth;
			HolesDiameter = holesDiameter;
			WrenchLength = wrenchLength;
			ValuesValidationErrors();
		}

		/// <summary>
		/// Собрать сообщения об ошибках
		/// </summary>
		private void ValuesValidationErrors()
		{
			if (_errorMessage.Count > 0)
			{
				throw new ArgumentException(string.Join("\n", _errorMessage));
			}
		}

		/// <summary>
		/// Ширина зева ключа 1
		/// </summary>
		public double LeftOpeningSize
		{
			get => _leftOpeningSize;
			set
			{
				if (value < 4 || value < TubeWidth || value > 75)
				{
					_errorMessage.Add("- Размер зева 1 выходит за предел допустимых значений (4 - 75 мм)");
				}
				else
				_leftOpeningSize = value;
			}
		}

		/// <summary>
		/// Глубина зева ключа 1
		/// </summary>
		public double LeftOpeningDepth
		{
			get	=> _leftOpeningDepth;
			set
			{
				if (value < 2 || value > 50)
				{
					_errorMessage.Add("- Глубина зева 1 выходит за предел допустимых значений (2 - 50 мм)");
				}
				else
				_leftOpeningDepth = value;
			}
		}

		/// <summary>
		/// Ширина зева ключа 2
		/// </summary>
		/// 		
		public double RightOpeningSize
		{
			get => _rightOpeningSize;
			set
			{
				// диаметр зева не больше трубки ключа
				if (value < 5 || value < TubeWidth || value > 80)
				{
					_errorMessage.Add("- Размер зева 2 выходит за предел допустимых значений (5 - 80 мм)");
				}
				else
				_rightOpeningSize = value;
			}
		}

		/// <summary>
		/// Глубина зева ключа 2
		/// </summary>
		/// 		
		public double RightOpeningDepth
		{
			get => _rightOpeningDepth;
			set
			{
				if (value < 2.5 || value > 50)
				{
					_errorMessage.Add("- Глубина зева 2 выходит за предел допустимых значений (2.5 - 50 мм)");
				}
				else
				_rightOpeningDepth = value;
			}
		}

		/// <summary>
		/// Толщина стенок ключа
		/// </summary>
		public double WallThickness
		{
			get => _wallThickness;
			set
			{
				if (value < 2 || value > 14)
				{
					_errorMessage.Add("- Толщина стенки ключа выходит за предел допустимых значений (2 - 14 мм)");
				}
				else
				_wallThickness = value;
			}
		}

		/// <summary>
		/// Ширина трубки ключа
		/// </summary>
		public double TubeWidth
		{
			get => _tubeWidth;
			set
			{
				if (value < 4 || value > 75)
				{
					_errorMessage.Add("- Диаметр трубки ключа выходит за предел допустимых значений (4 - 75 мм)");
				}
				if (value > RightOpeningSize || value > LeftOpeningSize)
				{
					_errorMessage.Add("- Диаметр трубки ключа не может быть больше размера зевов");
				}
				else
				_tubeWidth = value;
			}
		}

		/// <summary>
		/// Диаметр отверстий ключа
		/// </summary>
		public double HolesDiameter
		{
			get => _holesDiameter;
			set
			{
				// диаметр отверстий не больше 0.75 * диаметр трубки ключа
				if (value < 2 || value > 40)
				{
					_errorMessage.Add("- Диаметр отверстий ключа выходит за предел допустимых значений (2 - 40 мм)");
				}
				else if (value > 0.75 * TubeWidth)
				{
					_errorMessage.Add("- Диаметр отверстий ключа не может превышать 0.75 от диаметра трубки");
				}
				else
				_holesDiameter = value;
			}
		}

		/// <summary>
		/// Длина ключа
		/// </summary>
		public double WrenchLength
		{
			get => _wrenchLength;
			set
			{
				double minLength = (LeftOpeningDepth + RightOpeningDepth + HolesDiameter) * 2;
				if (value < 80 || value > 400)
				{
					_errorMessage.Add("- Длина ключа выходит за предел допустимых значений (80 - 400 мм)");
				}
				else if (value < minLength)
				{
					_errorMessage.Add("- Длина ключа при данном диаметре отверстий и глубине зевов должна составлять как минимум " 
						+ minLength + " мм");
				}
				else
				_wrenchLength = value;
			}
		}
	}
}
