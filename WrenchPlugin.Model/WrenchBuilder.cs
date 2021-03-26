using System;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrenchPlugin.Model
{
    //TODO: RSDN
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
		private void CreateMain(KompasConnector kompasConnector, WrenchParameters wrenchParameters)
		{
			// Начальная плоскость
			ksEntity currentPlane = (ksEntity)kompasConnector
				.Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

			// Массив эскизов
			ksEntity[] sketchList = new ksEntity[6];

			//TODO: В именованые константы
			const double openingsPartRatio = 0.75;
			const double middlePlaneRatio = 1.75;

			double leftOffset = openingsPartRatio * wrenchParameters.LeftOpeningDepth.Value;
			double middleOffset = wrenchParameters.WrenchLength.Value - middlePlaneRatio
					* (wrenchParameters.LeftOpeningDepth.Value 
					+ wrenchParameters.RightOpeningDepth.Value);
			double rightOffset = openingsPartRatio * wrenchParameters.RightOpeningDepth.Value;

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
				CreateHexSketch(kompasConnector, out sketchList[i], 
					ref currentPlane, planeOffsetList[i], polygonSizeList[i]);
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
		private void CutExtrusionHoles(KompasConnector kompasConnector, WrenchParameters wrenchParameters)
		{
			double circleRadius = wrenchParameters.HolesDiameter.Value / 2;

			const double pointY1Ratio = 2;
			const double pointY2Ratio = 1.75;

			// Координаты Y центра отверстий
			double pointY1 = -(wrenchParameters.LeftOpeningDepth.Value 
				* pointY1Ratio + circleRadius);
			double pointY2 = -(wrenchParameters.WrenchLength.Value -
					(wrenchParameters.RightOpeningDepth.Value * pointY2Ratio) 
					- circleRadius);

			double[] centerPointY = {
				pointY1,
				pointY2
			};

			// Плоскости XOZ, XOY
			ksEntity[] defaultPlanes = {
				(ksEntity)kompasConnector.Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ),
				(ksEntity)kompasConnector.Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY)
			};

			// Вырезание
			for (int i = 0; i < defaultPlanes.Length; i++)
			{
				CutExtrusion(kompasConnector, wrenchParameters, defaultPlanes[i], 
					centerPointY[i]);
			}
		}

		/// <summary>
		/// Создать эскиз шестиугольника на смещенной плоскости
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketch">Эскиз</param>
		/// <param name="currentPlane">Последняя созданная плоскость</param>
		/// <param name="offset">Расстояние до новой плоскости</param>
		/// <param name="size">Размер шестиугольника</param>
		/// <returns>Эскиз шестиугольника</returns>
		private ksEntity CreateHexSketch(KompasConnector kompasConnector, out ksEntity sketch, 
			 ref ksEntity currentPlane, double offset, double size)
		{
			ksEntity newPlane = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition newPlaneDefinition = (ksPlaneOffsetDefinition)newPlane
				.GetDefinition();
			// начальная позиция плоскости: от предыдущей
			newPlaneDefinition.SetPlane(currentPlane); 
			newPlaneDefinition.direction = true;
			newPlaneDefinition.offset = offset;
			newPlane.Create();
			sketch = (ksEntity)kompasConnector.Part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDef = sketch.GetDefinition();
			sketchDef.SetPlane(newPlane);
			sketchDef.angle = 0;
			sketch.Create();
			currentPlane = newPlane;
			ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
			DrawHexagon(kompasConnector, ref sketchDef, ref sketchEdit, size);
			return sketch;
		}

		/// <summary>
		/// Рисование шестиугольника на эскизе
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketchDef">Интерфейс эскиза</param>
		/// <param name="sketchEdit">2D-документ</param>
		/// <param name="size">Размер шестиугольника</param>
		private void DrawHexagon(KompasConnector kompasConnector, 
			ref ksSketchDefinition sketchDef, ref ksDocument2D sketchEdit, double size)
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
			sketchEdit.ksRegularPolygon(hexagonParam);
			sketchDef.EndEdit();
		}

		/// <summary>
		///  Элемент по сечениям (2 соседних эскиза)
		/// </summary>
		/// <param name="kompasConnector">API КОМПАС-3D</param>
		/// <param name="sketch1">Эскиз сечения 1</param>
		/// <param name="sketch2">Эскиз сечения 2</param>
		/// <param name="thickness">Толщина стенки ключа</param>
		private void CreateLoftElement(KompasConnector kompasConnector, ksEntity sketch1, 
			ksEntity sketch2, double thickness)
		{
			var loftElement = (ksEntity)kompasConnector.Part.NewEntity((short)Obj3dType.o3d_baseLoft);
			var baseLoftDefinition = (ksBaseLoftDefinition)loftElement.GetDefinition();
			// Параметры операции по сечениям: замкнутость траектории, 
			// резерв для дальн. использования, авто. форм. траектории
			baseLoftDefinition.SetLoftParam(false, true, true);
			// Параметры тонкой стенки: признак операции, направление, 
			// толщина в прямом направл., толщина в обр. направл.
			baseLoftDefinition.SetThinParam(true, (short)Direction_Type.dtNormal, thickness, 0);
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
		private void CutExtrusion(KompasConnector kompasConnector, WrenchParameters wrenchParameters, 
		    ksEntity plane, double centerPointY)
		{
			double extrusionDepth = wrenchParameters.TubeWidth.Value * 4; 

			ksEntity extrusionSketch = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition extrusionSketchDefinition = extrusionSketch.GetDefinition();
			extrusionSketchDefinition.SetPlane(plane);
			extrusionSketchDefinition.angle = 0;
			extrusionSketch.Create();
			CircleSketch(kompasConnector, wrenchParameters.HolesDiameter.Value, 
				ref extrusionSketchDefinition, centerPointY);
			extrusionSketchDefinition.EndEdit();
			// Вырезание по эскизу
			ksEntity entityCutExtr = (ksEntity)kompasConnector
				.Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr
				.GetDefinition();
			cutExtrDef.SetSketch(extrusionSketch);
			cutExtrDef.directionType = (short)Direction_Type.dtMiddlePlane;
			// Вырезание от средней плоскости через всю деталь
			cutExtrDef.SetSideParam(true, (short)End_Type.etThroughAll, extrusionDepth, 0, false); 
			cutExtrDef.SetThinParam(false, 0, 0, 0);
			entityCutExtr.Create();
		}

        /// <summary>
        /// Эскиз окружности для вырезания
        /// </summary>
        /// <param name="kompasConnector">API КОМПАС-3D</param>
        /// <param name="diameter">Диаметр окружности</param>
        /// <param name="sketchDef">Интерфейс эскиза</param>
        /// <param name="centerPointY">Координата Y центра окружности</param>
        private void CircleSketch(KompasConnector kompasConnector, double diameter, 
			ref ksSketchDefinition sketchDef, double centerPointY)
		{
			double radius = diameter / 2;
			ksDocument2D extrSketchEdit = (ksDocument2D)sketchDef.BeginEdit();
			extrSketchEdit.ksCircle(centerPointY, 0, radius, 1);
		}
	}
}