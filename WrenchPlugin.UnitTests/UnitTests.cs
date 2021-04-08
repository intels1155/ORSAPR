using System;
using NUnit.Framework;
using WrenchPlugin.Model.Parameters;

namespace WrenchPlugin.UnitTests
{
	[TestFixture]
	public class WrenchTests
	{
		/// <summary>
		/// Параметры ключа
		/// </summary>
		private WrenchParameters _wrenchParams;

		/// <summary>
		/// Параметры ключа по умолчанию
		/// </summary>
		private WrenchParameters _defaultWrenchParameters;

		/// <summary>
		/// Параметр
		/// </summary>
		private Parameter _parameter;

		[SetUp]
		public void Setup()
		{
			_wrenchParams = new WrenchParameters(
				18, // LeftOpeningSize
				18, // LefttOpeningDepth
				14, // RightOpeningSize
				14, // RightOpeningDepth
				2, // WallThickness
				10, // TubeWidth
				4, // HolesDiameter
				180, // WrenchLength
				false
				);
			_defaultWrenchParameters = new WrenchParameters();
			_parameter = new Parameter("Имя параметра", 0.5, 10.5, 5);
		}

		[Test(Description = "Позитивный тест конструктора класса WrenchParameters")]
		public void TestWrenchParameters_CorrectValue()
		{
			var expectedWrenchParameters = new WrenchParameters(
				18, // LeftOpeningSize
				18, // LefttOpeningDepth
				14, // RightOpeningSize
				14, // RightOpeningDepth
				2, // WallThickness
				10, // TubeWidth
				4, // HolesDiameter
				180, // WrenchLength
				false
				);
			var actual = _wrenchParams;

			Assert.AreEqual
				(expectedWrenchParameters.LeftOpeningSize.Value, actual.LeftOpeningSize.Value,
				"Некорректное значение LeftOpeningSize");
			Assert.AreEqual
				(expectedWrenchParameters.LeftOpeningDepth.Value, actual.LeftOpeningDepth.Value,
				"Некорректное значение LeftOpeningDepth");
			Assert.AreEqual
				(expectedWrenchParameters.RightOpeningSize.Value, actual.RightOpeningSize.Value,
				"Некорректное значение RightOpeningSize");
			Assert.AreEqual
				(expectedWrenchParameters.RightOpeningDepth.Value, actual.RightOpeningDepth.Value,
				"Некорректное значение RightOpeningDepth");
			Assert.AreEqual
				(expectedWrenchParameters.WallThickness.Value, actual.WallThickness.Value,
				"Некорректное значение WallThickness");
			Assert.AreEqual
				(expectedWrenchParameters.TubeWidth.Value, actual.TubeWidth.Value,
				"Некорректное значение TubeWidth");
			Assert.AreEqual
				(expectedWrenchParameters.HolesDiameter.Value, actual.HolesDiameter.Value,
				"Некорректное значение HolesDiameter");
			Assert.AreEqual
				(expectedWrenchParameters.WrenchLength.Value, actual.WrenchLength.Value,
				"Некорректное значение WrenchLength");
			Assert.AreEqual
				(expectedWrenchParameters.RoundSection, actual.RoundSection,
				"Некорректное значение RoundSection");
		}

		[Test(Description = "Позитивный тест конструктора по умолчанию " +
			"класса WrenchParameters")]
		public void TestDefaultWrenchParameters_CorrectValue()
		{
			var expectedDefaultWrenchParameters = new WrenchParameters();
			var actual = _defaultWrenchParameters;

			Assert.AreEqual
			(expectedDefaultWrenchParameters.LeftOpeningSize.Value, actual.LeftOpeningSize.Value,
				"Некорректное значение LeftOpeningSize");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.LeftOpeningDepth.Value, actual.LeftOpeningDepth.Value,
				"Некорректное значение LeftOpeningDepth");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.RightOpeningSize.Value, actual.RightOpeningSize.Value,
				"Некорректное значение RightOpeningSize");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.RightOpeningDepth.Value, actual.RightOpeningDepth.Value,
				"Некорректное значение RightOpeningDepth");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.WallThickness.Value, actual.WallThickness.Value,
				"Некорректное значение WallThickness");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.TubeWidth.Value, actual.TubeWidth.Value,
				"Некорректное значение TubeWidth");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.HolesDiameter.Value, actual.HolesDiameter.Value,
				"Некорректное значение HolesDiameter");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.WrenchLength.Value, actual.WrenchLength.Value,
				"Некорректное значение WrenchLength");
			Assert.AreEqual
			(expectedDefaultWrenchParameters.RoundSection, actual.RoundSection,
				"Некорректное значение RoundSection");
		}

		[Test(Description = "Позитивный тест конструктора класса Parameter")]
		public void TestParameter_CorrectValue()
		{
			var expectedParameter = new Parameter("Имя параметра", 0.5, 10.5, 5);
			var actual = _parameter;

			Assert.AreEqual
				(expectedParameter.Name, actual.Name, 
				"Некорректное значение Name");
			Assert.AreEqual
				(expectedParameter.Minimum, actual.Minimum,
				"Некорректное значение Minimum");
			Assert.AreEqual
				(expectedParameter.Maximum, actual.Maximum,
				"Некорректное значение Maximum");
			Assert.AreEqual
				(expectedParameter.Value, actual.Value,
				"Некорректное значение Value");
		}

		// LeftOpeningSize
		[TestCase(3, 18, 14, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Присвоение полю LeftOpeningSize значения меньше минимума")]
		[TestCase(76, 18, 14, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Присвоение полю LeftOpeningSize значения больше максимума")]
		[TestCase(12, 12, 14, 14, 2, 14, 4, 80, false, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Негативный тест LeftOpeningSize (12) < TubeWidth (14)")]

		// LeftOpeningDepth
		[TestCase(18, 1, 14, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.LeftOpeningDepth),
		  TestName = "Присвоение полю LeftOpeningDepth значения меньше минимума")]
		[TestCase(18, 51, 14, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.LeftOpeningDepth),
		  TestName = "Присвоение полю LeftOpeningDepth значения больше максимума")]

		// RightOpeningSize
		[TestCase(18, 18, 4, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Присвоение полю RightOpeningSize значения меньше минимума")]
		[TestCase(18, 18, 81, 14, 2, 10, 4, 80, false, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Присвоение полю RightOpeningSize значения больше максимума")]
		[TestCase(18, 18, 14, 14, 2, 16, 4, 80, false, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Негативный тест RightOpeningSize (14) < TubeWidth (16)")]

		// RightOpeningDepth
		[TestCase(18, 18, 14, 2, 2, 10, 4, 80, false, nameof(WrenchParameters.RightOpeningDepth),
		  TestName = "Присвоение полю RightOpeningDepth значения меньше минимума")]
		[TestCase(18, 18, 14, 51, 2, 10, 4, 80, false, nameof(WrenchParameters.RightOpeningDepth),
		  TestName = "Присвоение полю RightOpeningDepth значения больше максимума")]
		
		// WallThickness
		[TestCase(18, 18, 14, 14, 1, 10, 4, 80, false, nameof(WrenchParameters.WallThickness),
		  TestName = "Присвоение полю WallThickess значения меньше минимума")]
		[TestCase(18, 18, 14, 14, 15, 10, 4, 80, false, nameof(WrenchParameters.WallThickness),
		  TestName = "Присвоение полю WallThickess значения больше максимума")]

		// TubeWidth
		[TestCase(18, 18, 14, 14, 2, 19, 4, 80, false, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест при значении TubeWidth > LeftOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 20, 4, 80, false, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест при значении TubeWidth > RightOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 3, 4, 80, false, nameof(WrenchParameters.TubeWidth),
		  TestName = "Присвоение полю TubeWidth значения меньше минимума")]
		[TestCase(75, 18, 80, 14, 2, 76, 4, 80, false, nameof(WrenchParameters.TubeWidth),
		  TestName = "Присвоение полю TubeWidth значения больше максимума")]

		// HolesDiameter : 3 случая - > min(2), > max(40), > 0,75*TubeWidth
		[TestCase(18, 18, 14, 14, 2, 10, 1, 80, false, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Присвоение полю HolesDiameter значения меньше минимума")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 100, false, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Присвоение полю HolesDiameter значения больше максимума")]
		[TestCase(18, 18, 14, 14, 2, 10, 9, 80, false, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Негативный тест при значении HolesDiameter > 0,75*TubeWidth")]

		// WrenchLength : 3 случая - > min(80), > max(400), 
		// < (LeftOpeningDepth + RightOpeningDepth + HolesDiameter) * 2
		[TestCase(18, 18, 14, 14, 2, 10, 1, 79, false, nameof(WrenchParameters.WrenchLength),
		  TestName = "Присвоение полю WrenchLength значения меньше минимума")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 401, false, nameof(WrenchParameters.WrenchLength),
		  TestName = "Присвоение полю WrenchLength значения больше максимума")]
		[TestCase(18, 30, 14, 20, 2, 10, 4, 107, false, nameof(WrenchParameters.WrenchLength),
		  TestName = "Негативный тест при значении поля WrenchLength > " +
		             "((LeftOpeningDepth + RightOpeningDepth + HolesDiameter) * 2) ((30+20+4)*2)")]
        public void TestWrenchParameters_ArgumentValue(double rightOpeningSize, 
			double rightOpeningDepth, double leftOpeningSize, double leftOpeningDepth, 
			double wallThickness, double tubeWidth, double holesDiameter, 
			double wrenchLength, bool roundSection, string attribute)
		{
			Assert.Throws<ArgumentException>(
				() =>
				{
					var parameters = new WrenchParameters
					(rightOpeningSize,
					rightOpeningDepth,
					leftOpeningSize,
					leftOpeningDepth,
					wallThickness,
					tubeWidth,
					holesDiameter,
					wrenchLength,
					roundSection);
				},
				"Должно возникнуть исключение, если значение поля "
				+ attribute + "выходит за диапазон допустимых значений");
		}

		[TestCase("Имя параметра", 0, 10, 5, nameof(Parameter.Minimum),
			TestName = "Минимум параметра равен 0")]
		[TestCase("Имя параметра", -1, 10, 5, nameof(Parameter.Minimum),
			TestName = "Минимум параметра меньше 0")]
		[TestCase("Имя параметра", 5, 4, 5, nameof(Parameter.Minimum),
			TestName = "Минимум параметра больше максимума")]
		[TestCase("Имя параметра", double.PositiveInfinity, 10, 2, nameof(Parameter.Minimum),
			TestName = "Негативный тест минимума параметра на PositiveInfinity")]
		[TestCase("Имя параметра", double.NegativeInfinity, 10, 2, nameof(Parameter.Minimum),
			TestName = "Негативный тест минимума параметра на NegativeInfinity")]
		[TestCase("Имя параметра", double.NaN, 10, 2, nameof(Parameter.Minimum),
			TestName = "Негативный тест минимума параметра на NaN")]

		[TestCase("Имя параметра", 1, 1, 1, nameof(Parameter.Maximum),
			TestName = "Максимум параметра равен минимуму")]
		[TestCase("Имя параметра", 2, 1, 3, nameof(Parameter.Maximum),
			TestName = "Максимум параметра меньше минимума")]
		[TestCase("Имя параметра", 2, 0, 1, nameof(Parameter.Maximum),
			TestName = "Максимум параметра равен 0")]
		[TestCase("Имя параметра", 1, -1, 1, nameof(Parameter.Maximum),
			TestName = "Максимум параметра меньше 0")]
		[TestCase("Имя параметра", 1, double.PositiveInfinity, 2, nameof(Parameter.Maximum),
			TestName = "Негативный тест максимума параметра на PositiveInfinity")]
		[TestCase("Имя параметра", 1, double.NegativeInfinity, 2, nameof(Parameter.Maximum),
			TestName = "Негативный тест максимума параметра на NegativeInfinity")]
		[TestCase("Имя параметра", 1, double.NaN, 2, nameof(Parameter.Maximum),
			TestName = "Негативный тест максимума параметра на NaN")]

		[TestCase("Имя параметра", 1, 5, 6, nameof(Parameter.Value),
			TestName = "Значение параметра больше максимума")]
		[TestCase("Имя параметра", 1, 5, 0.5, nameof(Parameter.Value),
			TestName = "Значение параметра меньше минимума")]
		[TestCase("Имя параметра", 1, 10, double.PositiveInfinity, nameof(Parameter.Value),
			TestName = "Негативный тест значения параметра на PositiveInfinity")]
		[TestCase("Имя параметра", 1, 10, double.NegativeInfinity, nameof(Parameter.Value),
			TestName = "Негативный тест значения параметра на NegativeInfinity")]
		[TestCase("Имя параметра", 1, 10, double.NaN, nameof(Parameter.Value),
			TestName = "Негативный тест значения параметра на NaN")]

		[TestCase("", 1, 10, 6, nameof(Parameter.Name),
			TestName = "Негативный тест имени параметра")]

		public void TestParameter_ArgumentValue(string name, double minimum, 
			double maximum, double value, string attribute)
		{
			Assert.Throws<ArgumentException>(
				() =>
				{
					var parameter = new Parameter(name, minimum, maximum, value);
				},
				"Должно возникнуть исключение, если значение поля "
				+ attribute + "выходит за диапазон допустимых значений");
		}
	}
}
