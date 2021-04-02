using System;
using NUnit.Framework;
using WrenchPlugin.Model.Kompas;
using WrenchPlugin.Model.Parameters;
using WrenchPlugin.UI;

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
				180 // WrenchLength 18, 18, 14, 14, 2, 10, 4, 80
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
				180 // WrenchLength
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
		[TestCase(3, 18, 14, 14, 2, 10, 4, 80, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Негативный тест LeftOpeningSize < min (4)")]
		[TestCase(76, 18, 14, 14, 2, 10, 4, 80, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Негативный тест LeftOpeningSize > max (75)")]
		[TestCase(12, 12, 14, 14, 2, 14, 4, 80, nameof(WrenchParameters.LeftOpeningSize),
		  TestName = "Негативный тест LeftOpeningSize (12) < TubeWidth (14)")]

		// LeftOpeningDepth
		[TestCase(18, 1, 14, 14, 2, 10, 4, 80, nameof(WrenchParameters.LeftOpeningDepth),
		  TestName = "Негативный тест LeftOpeningDepth < min (2)")]
		[TestCase(18, 51, 14, 14, 2, 10, 4, 80, nameof(WrenchParameters.LeftOpeningDepth),
		  TestName = "Негативный тест LeftOpeningDepth > max (50)")]

		// RightOpeningSize
		[TestCase(18, 18, 4, 14, 2, 10, 4, 80, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Негативный тест RightOpeningSize < min (5)")]
		[TestCase(18, 18, 81, 14, 2, 10, 4, 80, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Негативный тест RightOpeningSize > max (80)")]
		[TestCase(18, 18, 14, 14, 2, 16, 4, 80, nameof(WrenchParameters.RightOpeningSize),
		  TestName = "Негативный тест RightOpeningSize (14) < TubeWidth (16)")]

		// RightOpeningDepth
		[TestCase(18, 18, 14, 2, 2, 10, 4, 80, nameof(WrenchParameters.RightOpeningDepth),
		  TestName = "Негативный тест RightOpeningDepth < min (2.5)")]
		[TestCase(18, 18, 14, 51, 2, 10, 4, 80, nameof(WrenchParameters.RightOpeningDepth),
		  TestName = "Негативный тест RightOpeningDepth > max (50)")]
		
		// WallThickness
		[TestCase(18, 18, 14, 14, 1, 10, 4, 80, nameof(WrenchParameters.WallThickness),
		  TestName = "Негативный тест WallThickness < min (2)")]
		[TestCase(18, 18, 14, 14, 15, 10, 4, 80, nameof(WrenchParameters.WallThickness),
		  TestName = "Негативный тест WallThickness > max (14)")]

		// TubeWidth
		[TestCase(18, 18, 14, 14, 2, 19, 4, 80, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест TubeWidth > LeftOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 20, 4, 80, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест TubeWidth > RightOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 3, 4, 80, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест TubeWidth < min (4)")]
		[TestCase(75, 18, 80, 14, 2, 76, 4, 80, nameof(WrenchParameters.TubeWidth),
		  TestName = "Негативный тест TubeWidth > max (75)")]

		// HolesDiameter : 3 случая - > min(2), > max(40), > 0,75*TubeWidth
		[TestCase(18, 18, 14, 14, 2, 10, 1, 80, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Негативный тест HolesDiameter < min (2)")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 100, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Негативный тест HolesDiameter > max (40)")]
		[TestCase(18, 18, 14, 14, 2, 10, 9, 80, nameof(WrenchParameters.HolesDiameter),
		  TestName = "Негативный тест HolesDiameter > 0,75*TubeWidth (9)")]

		// WrenchLength : 3 случая - > min(80), > max(400), 
		// < (LeftOpeningDepth + RightOpeningDepth + HolesDiameter) * 2
		[TestCase(18, 18, 14, 14, 2, 10, 1, 79, nameof(WrenchParameters.WrenchLength),
		  TestName = "Негативный тест WrenchLength < min (80)")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 401, nameof(WrenchParameters.WrenchLength),
		  TestName = "Негативный тест WrenchLength > max (400)")]
		[TestCase(18, 30, 14, 20, 2, 10, 4, 107, nameof(WrenchParameters.WrenchLength),
		  TestName = "Негативный тест WrenchLength > ((LeftOpDepth + RightOpDepth + HolesDiam) * 2) ((30+20+4)*2)")]
        public void TestWrenchParameters_ArgumentValue(double rightOpeningSize, 
			double rightOpeningDepth, double leftOpeningSize, double leftOpeningDepth, 
			double wallThickness, double tubeWidth, double holesDiameter, 
			double wrenchLength, string attr)
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
					wrenchLength);
				},
				"Должно возникнуть исключение, если значение поля "
				+ attr + "выходит за диапазон допустимых значений");
		}

		[TestCase("Имя параметра", 0, 10, 5, "Minimum",
			TestName = "Негативный тест минимума параметра")]
		[TestCase("Имя параметра", 5, 4, 5, "Maximum",
			TestName = "Негативный тест максимума параметра")]
		[TestCase("Имя параметра", 1, 1, 1, "Maximum",
			TestName = "Негативный тест максимума параметра")]
		[TestCase("Имя параметра", 1, -1, 1, "Maximum",
			TestName = "Негативный тест максимума параметра")]
		[TestCase("Имя параметра", 1, 1, 1, "Maximum",
			TestName = "Негативный тест максимума параметра")]

		[TestCase("Имя параметра", 1, 5, 6, "Value",
			TestName = "Негативный тест максимума параметра")]
		[TestCase("", 1, 10, 6, "Name",
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
