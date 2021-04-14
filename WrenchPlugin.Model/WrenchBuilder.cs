using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using WrenchPlugin.Model.Parameters;

namespace WrenchPlugin.Model.Kompas
{
	/// <summary>
	/// Класс построения модели ключа
	/// </summary>
	public class WrenchBuilder
	{
		/// <summary>
		/// Построение модели
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		public void Build(KompasConnector kompasConnector, WrenchParameters wrenchParameters)
		{
			CreateMain(kompasConnector,  wrenchParameters);
			CutExtrusionHoles(kompasConnector, wrenchParameters);
		}

		/// <summary>
		/// Построение основной части ключа
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		private void CreateMain(KompasConnector kompasConnector, 
			WrenchParameters wrenchParameters)
		{
			// Начальная плоскость
			ksEntity currentPlane = (ksEntity)kompasConnector
				.Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

			// Массив эскизов
			ksEntity[] sketchList = new ksEntity[6];
			
			const double openingsPartRatio = 0.75;
			const double middlePlaneRatio = 1.75;

			double leftOffset = openingsPartRatio 
				* wrenchParameters.LeftOpeningDepth.Value;
			double middleOffset = wrenchParameters.WrenchLength.Value - middlePlaneRatio
				* (wrenchParameters.LeftOpeningDepth.Value 
				+ wrenchParameters.RightOpeningDepth.Value);
			double rightOffset = openingsPartRatio 
				* wrenchParameters.RightOpeningDepth.Value;

			// Массив расстояний смещения плоскостей эскизов
			double[] planeOffsetList = {
				0,
				wrenchParameters.LeftOpeningDepth.Value,
				leftOffset,
				middleOffset,
				rightOffset,
				wrenchParameters.RightOpeningDepth.Value
			};

			// Массив размеров многоугольников
			double[] polygonSizeList = {
				wrenchParameters.LeftOpeningSize.Value,
				wrenchParameters.LeftOpeningSize.Value,
				wrenchParameters.TubeWidth.Value,
				wrenchParameters.TubeWidth.Value,
				wrenchParameters.RightOpeningSize.Value,
				wrenchParameters.RightOpeningSize.Value
			};

			for (int i = 0; i < sketchList.Length; i++)
			{
				if ((i == 2 || i == 3) && (wrenchParameters.RoundSection))
				{
					CreateSketch(kompasConnector, out sketchList[i], 
						ref currentPlane, planeOffsetList[i], polygonSizeList[i], true);
				}
				else
				{
					CreateSketch(kompasConnector, out sketchList[i],
						ref currentPlane, planeOffsetList[i], polygonSizeList[i], false);
				}
			}

			for (int i = 0; i < polygonSizeList.Length - 1; i++)
			{
				CreateLoftElement(kompasConnector, sketchList[i], 
					sketchList[i + 1], wrenchParameters.WallThickness.Value); 
			}
		}

		/// <summary>
		/// Вырезание отверстий в ключе
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		private void CutExtrusionHoles(KompasConnector kompasConnector, 
			WrenchParameters wrenchParameters)
		{
			double circleRadius = wrenchParameters.HolesDiameter.Value / 2;
			const double pointYRatio = 2;
			// Координаты Y центра отверстий
			double pointY1 = -(wrenchParameters.LeftOpeningDepth.Value 
				* pointYRatio + circleRadius);
			double pointY2 = -(wrenchParameters.WrenchLength.Value -
					(wrenchParameters.RightOpeningDepth.Value * pointYRatio) 
					- circleRadius);

			double[] centerPointY = {
				pointY1,
				pointY2
			};

			ksEntity[] defaultPlanes = {
				(ksEntity)kompasConnector.Part
					.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ),
				(ksEntity)kompasConnector.Part
					.GetDefaultEntity((short)Obj3dType.o3d_planeXOY)
			};

			for (int i = 0; i < defaultPlanes.Length; i++)
			{
				CutExtrusion(kompasConnector, wrenchParameters, defaultPlanes[i], 
					centerPointY[i]);
			}
		}

		/// <summary>
		/// Создание эскиза на смещенной плоскости
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketch">Эскиз</param>
		/// <param name="currentPlane">Последняя созданная плоскость</param>
		/// <param name="offset">Расстояние до новой плоскости</param>
		/// <param name="size">Размер шестиугольника</param>
		/// <param name="roundSection">Сечение трубки ключа</param>
		/// <returns>Эскиз шестиугольника/окружности</returns>
		private ksEntity CreateSketch(KompasConnector kompasConnector, 
			out ksEntity sketch, ref ksEntity currentPlane, double offset, 
			double size, bool roundSection)
		{
			ksEntity newPlane = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition newPlaneDefinition = (ksPlaneOffsetDefinition)newPlane
				.GetDefinition();

			newPlaneDefinition.SetPlane(currentPlane); 
			newPlaneDefinition.direction = true;
			newPlaneDefinition.offset = offset;
			newPlane.Create();
			sketch = (ksEntity)kompasConnector.Part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(newPlane);
			sketchDefinition.angle = 0;
			sketch.Create();
			currentPlane = newPlane;
			if (roundSection)
			{
				DrawCircle(kompasConnector, size, ref sketchDefinition, 0);
			}
			else
			{
				DrawHexagon(kompasConnector, ref sketchDefinition, size);
			}
			return sketch;
		}

		/// <summary>
		/// Эскиз шестиугольника
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketchDefinition">Интерфейс эскиза</param>
		/// <param name="size">Размер шестиугольника</param>
		private void DrawHexagon(KompasConnector kompasConnector, 
			ref ksSketchDefinition sketchDefinition, double size)
		{
			var hexagonParam = (ksRegularPolygonParam)kompasConnector
				.Kompas.GetParamStruct((short)StructType2DEnum.ko_RegularPolygonParam);

			hexagonParam.ang = 0;
			hexagonParam.count = 6;
			// Вписанный многоугольник
			hexagonParam.describe = true; 
			// Радиус окружности вокруг многоугольника
			hexagonParam.radius = size / 2; 
			hexagonParam.style = 1; 
			hexagonParam.xc = 0;
			hexagonParam.yc = 0;
			ksDocument2D sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
			sketchEdit.ksRegularPolygon(hexagonParam);
			sketchDefinition.EndEdit();
		}

		/// <summary>
		/// Эскиз окружности
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="diameter">Диаметр окружности</param>
		/// <param name="sketchDefinition">Интерфейс эскиза</param>
		/// <param name="centerPointY">Координата Y центра окружности</param>
		private void DrawCircle(KompasConnector kompasConnector, double diameter,
			ref ksSketchDefinition sketchDefinition, double centerPointY)
		{
			double radius = diameter / 2;
			ksDocument2D sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
			sketchEdit.ksCircle(centerPointY, 0, radius, 1);
			sketchDefinition.EndEdit();
		}

		/// <summary>
		///  Элемент по сечениям (по 2 соседним эскизам)
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketch1">Эскиз сечения 1</param>
		/// <param name="sketch2">Эскиз сечения 2</param>
		/// <param name="thickness">Толщина стенки ключа</param>
		private void CreateLoftElement(KompasConnector kompasConnector, 
			ksEntity sketch1, ksEntity sketch2, double thickness)
		{
			var loftElement = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_baseLoft);
			var baseLoftDefinition = (ksBaseLoftDefinition)loftElement.GetDefinition();

			baseLoftDefinition.SetLoftParam(false, true, true);
			baseLoftDefinition.SetThinParam(true, (short)Direction_Type.dtNormal, 
				thickness, 0);
			var sketches = (ksEntityCollection)baseLoftDefinition.Sketchs();
			sketches.Clear();
			sketches.Add(sketch1);
			sketches.Add(sketch2);
			loftElement.Create();
		}

		/// <summary>
		/// Вырезание отверстий в ключе
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		/// <param name="plane">Плоскость эскиза</param>
		/// <param name="centerPointY">Координата Y центра отверстия</param>
		private void CutExtrusion(KompasConnector kompasConnector, 
			WrenchParameters wrenchParameters, ksEntity plane, double centerPointY)
		{
			const double extrusionRatio = 4;
			double extrusionDepth = wrenchParameters.TubeWidth.Value 
				* extrusionRatio; 

			ksEntity extrusionSketch = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition extrusionSketchDefinition = extrusionSketch
				.GetDefinition();
			extrusionSketchDefinition.SetPlane(plane);
			extrusionSketchDefinition.angle = 0;
			extrusionSketch.Create();
			DrawCircle(kompasConnector, wrenchParameters.HolesDiameter.Value,
				ref extrusionSketchDefinition, centerPointY);
			// Вырезание по эскизу
			ksEntity entityCutExtrusion = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrusionDefinition = (ksCutExtrusionDefinition)
				entityCutExtrusion.GetDefinition();
			cutExtrusionDefinition.SetSketch(extrusionSketch);
			cutExtrusionDefinition.directionType = (short)Direction_Type.dtMiddlePlane;
			// Вырезание от средней плоскости через всю деталь
			cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etThroughAll, 
				extrusionDepth, 0, false);
			cutExtrusionDefinition.SetThinParam(false, 0, 0, 0);
			entityCutExtrusion.Create();
		}
	}
}