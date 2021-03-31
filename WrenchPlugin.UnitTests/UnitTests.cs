﻿using System;
using NUnit.Framework;
using WrenchPlugin.Model.Kompas;
using WrenchPlugin.Model.Parameters;
using WrenchPlugin.UI;

namespace WrenchPlugin.UnitTests
{
	[TestFixture]
	public class WrenchTests
	{
		private WrenchParameters _wrenchParams;

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
		}

		[Test(Description = "Позитивный тест конструктора класса WrenchParameters")]
		public void TestWrenchParameters_CorrectValue()
		{
			var expectedParameters = new WrenchParameters(
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
				(expectedParameters.LeftOpeningSize.Value, actual.LeftOpeningSize.Value,
				"Некорректное значение LeftOpeningSize");
			Assert.AreEqual
				(expectedParameters.LeftOpeningDepth.Value, actual.LeftOpeningDepth.Value,
				"Некорректное значение LeftOpeningDepth");
			Assert.AreEqual
				(expectedParameters.RightOpeningSize.Value, actual.RightOpeningSize.Value,
				"Некорректное значение RightOpeningSize");
			Assert.AreEqual
				(expectedParameters.RightOpeningDepth.Value, actual.RightOpeningDepth.Value,
				"Некорректное значение RightOpeningDepth");
			Assert.AreEqual
				(expectedParameters.WallThickness.Value, actual.WallThickness.Value,
				"Некорректное значение WallThickness");
			Assert.AreEqual
				(expectedParameters.TubeWidth.Value, actual.TubeWidth.Value,
				"Некорректное значение TubeWidth");
			Assert.AreEqual
				(expectedParameters.HolesDiameter.Value, actual.HolesDiameter.Value,
				"Некорректное значение HolesDiameter");
			Assert.AreEqual
				(expectedParameters.WrenchLength.Value, actual.WrenchLength.Value,
				"Некорректное значение WrenchLength");
		}

		// LeftOpeningSize
		[TestCase(3, 18, 14, 14, 2, 10, 4, 80, "LeftOpeningSize",
		  TestName = "Негативный тест LeftOpeningSize < min (4)")]
		[TestCase(76, 18, 14, 14, 2, 10, 4, 80, "LeftOpeningSize",
		  TestName = "Негативный тест LeftOpeningSize > max (75)")]
		[TestCase(12, 12, 14, 14, 2, 14, 4, 80, "LeftOpeningSize",
		  TestName = "Негативный тест LeftOpeningSize (12) < TubeWidth (14)")]

		// LeftOpeningDepth
		[TestCase(18, 1, 14, 14, 2, 10, 4, 80, "LeftOpeningDepth",
		  TestName = "Негативный тест LeftOpeningDepth < min (2)")]
		[TestCase(18, 51, 14, 14, 2, 10, 4, 80, "LeftOpeningDepth",
		  TestName = "Негативный тест LeftOpeningDepth > max (50)")]

		// RightOpeningSize
		[TestCase(18, 18, 4, 14, 2, 10, 4, 80, "RightOpeningSize",
		  TestName = "Негативный тест RightOpeningSize < min (5)")]
		[TestCase(18, 18, 81, 14, 2, 10, 4, 80, "RightOpeningSize",
		  TestName = "Негативный тест RightOpeningSize > max (80)")]
		[TestCase(18, 18, 14, 14, 2, 16, 4, 80, "RightOpeningSize",
		  TestName = "Негативный тест RightOpeningSize (14) < TubeWidth (16)")]

		// RightOpeningDepth
		[TestCase(18, 18, 14, 2, 2, 10, 4, 80, "LeftOpeningDepth",
		  TestName = "Негативный тест RightOpeningDepth < min (2.5)")]
		[TestCase(18, 18, 14, 51, 2, 10, 4, 80, "RightOpeningDepth",
		  TestName = "Негативный тест RightOpeningDepth > max (50)")]
		
		// WallThickness
		[TestCase(18, 18, 14, 14, 1, 10, 4, 80, "WallThickness",
		  TestName = "Негативный тест WallThickness < min (2)")]
		[TestCase(18, 18, 14, 14, 15, 10, 4, 80, "WallThickness",
		  TestName = "Негативный тест WallThickness > max (14)")]

		// TubeWidth
		[TestCase(18, 18, 14, 14, 2, 19, 4, 80, "TubeWidth",
		  TestName = "Негативный тест TubeWidth > LeftOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 20, 4, 80, "TubeWidth",
		  TestName = "Негативный тест TubeWidth > RightOpeningSize")]
		[TestCase(18, 18, 14, 14, 2, 3, 4, 80, "TubeWidth",
		  TestName = "Негативный тест TubeWidth < min (4)")]
		[TestCase(75, 18, 80, 14, 2, 76, 4, 80, "TubeWidth",
		  TestName = "Негативный тест TubeWidth > max (75)")]

		//HolesDiameter : 3 случая - > min(2), > max(40), > 0,75*TubeWidth
		[TestCase(18, 18, 14, 14, 2, 10, 1, 80, "HolesDiameter",
		  TestName = "Негативный тест HolesDiameter < min (2)")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 100, "HolesDiameter",
		  TestName = "Негативный тест HolesDiameter > max (40)")]
		[TestCase(18, 18, 14, 14, 2, 10, 9, 80, "HolesDiameter",
		  TestName = "Негативный тест HolesDiameter > 0,75*TubeWidth (9)")]

		//WrenchLength : 3 случая - > min(80), > max(400), 
		// < (LeftOpeningDepth + RightOpeningDepth + HolesDiameter) * 2
		[TestCase(18, 18, 14, 14, 2, 10, 1, 79, "WrenchLength",
		  TestName = "Негативный тест WrenchLength < min (80)")]
		[TestCase(75, 18, 80, 14, 2, 70, 41, 401, "WrenchLength",
		  TestName = "Негативный тест WrenchLength > max (400)")]
		[TestCase(18, 30, 14, 20, 2, 10, 4, 107, "HolesDiameter",
		  TestName = "Негативный тест WrenchLength > ((LeftOpDepth + RightOpDepth + HolesDiam) * 2) ((30+20+4)*2)")]
        //TODO: RSDN
		public void TestWrenchParameters_ArgumentValue
		(double rightOpeningSize, double rightOpeningDepth, double leftOpeningSize,
		  double leftOpeningDepth, double wallThickness, double tubeWidth,
		  double holesDiameter, double wrenchLength, string attr)
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
	}
}
