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
	public class WrenchBuilder
	{
		/// <summary>
		/// Интерфейс компонента
		/// </summary>
		private ksPart _part;

		/// <summary>
		/// Интерфейс API КОМПАС
		/// </summary>
		private KompasObject _kompas;

		/// <summary>
		/// Построение ключа
		/// </summary>
		public void Build(KompasConnector kompasConnector, WrenchParameters wrenchParameters)
		{
			this._part = kompasConnector.Part;
			this._kompas = kompasConnector.Kompas;
			CreateMain(kompasConnector, _part, wrenchParameters);
			CutExtrusionHoles(kompasConnector, _part, wrenchParameters);
		}

		/// <summary>
		/// Построение ключа
		/// </summary>
		/// <param name="kompas">API КОМПАС-3D</param>
		/// <param name="part">Интерфейс компонента</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		private void CreateMain(KompasConnector kompasConnector, ksPart part, WrenchParameters wrenchParameters)
		{
			// Начальная плоскость
			ksEntity currentPlane = (ksEntity)kompasConnector.Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

			// Массив эскизов
			ksEntity[] sketchList = new ksEntity[6];

			// Массив расстояний смещения плоскостей эскизов
			double[] planeOffsetList = {
				0,
				wrenchParameters.LeftOpeningDepth,
				0.75 * wrenchParameters.LeftOpeningDepth,
				wrenchParameters.WrenchLength - 1.75 * (wrenchParameters.LeftOpeningDepth + wrenchParameters.RightOpeningDepth),
				0.75 * wrenchParameters.RightOpeningDepth,
				wrenchParameters.RightOpeningDepth
			};

			// Массив размеров многоугольников
			double[] polygonSizeList = {
				wrenchParameters.LeftOpeningSize,
				wrenchParameters.LeftOpeningSize,
				wrenchParameters.TubeWidth,
				wrenchParameters.TubeWidth,
				wrenchParameters.RightOpeningSize,
				wrenchParameters.RightOpeningSize
			};
	
			for (int i = 0; i < sketchList.Length; i++)
			{
				CreateHexSketch(kompasConnector, part, out sketchList[i], ref currentPlane, planeOffsetList[i], polygonSizeList[i]);
			}

			for (int i = 0; i < polygonSizeList.Length - 1; i++)
			{
				CreateLoftElement(part, sketchList[i], sketchList[i + 1], wrenchParameters.WallThickness); 
			}
		}

		/// <summary>
		/// Вырезание отверстий в ключе
		/// </summary>
		/// <param name="kompasConnector"></param>
		/// <param name="part"></param>
		/// <param name="wrenchParameters"></param>
		private void CutExtrusionHoles(KompasConnector kompasConnector, ksPart part, WrenchParameters wrenchParameters)
		{
			double circleRadius = wrenchParameters.HolesDiameter / 2;

			// Координаты Y точек центра окружностей
			double[] circleCenterPointY = {
				0 - (wrenchParameters.LeftOpeningDepth * 2 + circleRadius), // центр эскиза 1 отв.
				0 - (wrenchParameters.WrenchLength - (wrenchParameters.RightOpeningDepth * 1.75) - circleRadius) // центр эскиза 2 отв.
			};

			// Плоскости XOZ, XOY
			ksEntity[] defaultPlanes = {
				(ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ),
				(ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY)
			};

			// Вырезание
			for (int i = 0; i < defaultPlanes.Length; i++)
			{
				CutExtrusion(part, wrenchParameters, defaultPlanes[i], circleCenterPointY[i]);
			}
		}

		/// <summary>
		/// Создать эскиз шестиугольника на смещенной плоскости
		/// </summary>
		/// <param name="kompasConnector"></param>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="sketchDef"></param>
		/// <param name="currentPlane"></param>
		/// <param name="offset"></param>
		/// <param name="size"></param>
		/// <returns>Эскиз шестиугольника</returns>
		private ksEntity CreateHexSketch(KompasConnector kompasConnector, ksPart part, out ksEntity sketch, 
			 ref ksEntity currentPlane, double offset, double size)
		{
			// Интерфейс новой смещенной плоскости
			ksEntity newPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);

			// Интерфейс настроек смещенной плоскости
			ksPlaneOffsetDefinition newPlaneDefinition = (ksPlaneOffsetDefinition)newPlane.GetDefinition();
			newPlaneDefinition.SetPlane(currentPlane); // начальная позиция плоскости: от предыдущей
			newPlaneDefinition.direction = true; // направление смещения: прямое
			newPlaneDefinition.offset = offset; // расстояние смещения
			newPlane.Create(); // создать плоскость

			sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch); // Интерфейс эскиза 
			ksSketchDefinition sketchDef = sketch.GetDefinition();
			sketchDef.SetPlane(newPlane);  // установка новой базовой плоскости для эскиза
			sketchDef.angle = 0; // угол поворота эскиза
			sketch.Create(); // создать эскиз

			currentPlane = newPlane; // установить последнюю созданную плоскость текущей

			ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
			DrawHexagon(kompasConnector, ref sketchDef, ref sketchEdit, size); // эскиз шестиугольника на плоскости

			return sketch;
		}

		/// <summary>
		/// Рисование шестиугольника на эскизе
		/// </summary>
		/// <param name="kompasConnector"></param>
		/// <param name="sketchDef"></param>
		/// <param name="sketchEdit"></param>
		/// <param name="size">Размер шестиугольника</param>
		private void DrawHexagon(KompasConnector kompasConnector, ref ksSketchDefinition sketchDef, ref ksDocument2D sketchEdit, double size)
		{
			var hexagonParam = (ksRegularPolygonParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RegularPolygonParam);
			hexagonParam.ang = 0;
			hexagonParam.count = 6; // Число углов многоугольника
			hexagonParam.describe = true; // Вписанный многоугольник
			hexagonParam.radius = size / 2; // Радиус окружности вокруг многоугольника
			hexagonParam.style = 1; // Стиль линии - основной
			hexagonParam.xc = 0;
			hexagonParam.yc = 0;
			sketchEdit.ksRegularPolygon(hexagonParam);
			sketchDef.EndEdit();
		}

		/// <summary>
		///  Элемент по сечениям (2 соседних эскиза)
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch1"></param>
		/// <param name="sketch2"></param>
		/// <param name="thickness">Толщина </param>
		private void CreateLoftElement(ksPart part, ksEntity sketch1, ksEntity sketch2, double thickness)
		{
			var loftElement = (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseLoft);
			var baseLoftDefinition = (ksBaseLoftDefinition)loftElement.GetDefinition();
			// Параметры операции по сечениям: замкнутость траектории, резерв для дальн. использования, авто. форм. траектории
			baseLoftDefinition.SetLoftParam(false, true, true);
			// Параметры тонкой стенки: признак операции, направление, толщина в прямом направл., толщина в обр. направл.
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
		/// <param name="part"></param>
		/// <param name="wrenchParameters"></param>
		/// <param name="plane">Плоскость</param>
		/// <param name="circleCenterPointY">Координата Y точки центра окружности отверстия</param>
		private void CutExtrusion(ksPart part, WrenchParameters wrenchParameters, ksEntity plane, double circleCenterPointY)
		{
			double radius = wrenchParameters.HolesDiameter; // радиус окружности
			double extrDepth = wrenchParameters.TubeWidth * 2; // глубина выдавливания

			// Эскиз окружности
			ksEntity extrSketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition extrSketchDef = extrSketch.GetDefinition();
			extrSketchDef.SetPlane(plane);
			extrSketchDef.angle = 0;
			extrSketch.Create();
			ksDocument2D extrSketchEdit = (ksDocument2D)extrSketchDef.BeginEdit();
			extrSketchEdit.ksCircle(circleCenterPointY, 0, radius, 1);
			extrSketchDef.EndEdit();

			// Вырезание по эскизу
			ksEntity entityCutExtr = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
			cutExtrDef.SetSketch(extrSketch);
			cutExtrDef.directionType = (short)Direction_Type.dtMiddlePlane;
			cutExtrDef.SetSideParam(true, (short)End_Type.etThroughAll, extrDepth, 0, false); // forward, cut type, depth, angle, angle dir.
			cutExtrDef.SetThinParam(false, 0, 0, 0);
			entityCutExtr.Create();
		}
	}
}