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
		/// Интерфейс модели
		/// </summary>
		private ksPart _iPart;

		/// <summary>
		/// Построение ключа
		/// </summary>
		public void Build(ksPart iPart, KompasObject kompas, WrenchParameters wrenchParameters)
		{
			this._iPart = iPart;
			//var basePlane = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
			CreateMain(iPart, kompas, wrenchParameters);
			CreateHoles(iPart, kompas, wrenchParameters);
		}

		/// <summary>
		/// Построение ключа
		/// </summary>
		/// <param name="iPart"></param>
		/// <param name="kompas">API КОМПАС-3D</param>
		/// <param name="wrenchParameters">Параметры ключа</param>
		public void CreateMain(ksPart iPart, KompasObject kompas, WrenchParameters wrenchParameters)
		{
			double leftOpeningSize = wrenchParameters.LeftOpeningSize;
			double leftOpeningDepth = wrenchParameters.LeftOpeningDepth;
			double rightOpeningSize = wrenchParameters.RightOpeningSize;
			double rightOpeningDepth = wrenchParameters.RightOpeningDepth;
			double tubeWidth = wrenchParameters.TubeWidth;
			double thickness = wrenchParameters.WallThickness;

			// Начальная плоскость
			ksEntity currentPlane = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

			ksEntity Sketch1; 
			ksSketchDefinition SketchDef1; // Указатель на интерфейс параметров эскиза 1
			CreateHexSketch(iPart, kompas, out Sketch1, out SketchDef1, ref currentPlane, 0, leftOpeningSize);

			ksEntity Sketch2;
			ksSketchDefinition SketchDef2; 
			CreateHexSketch(iPart, kompas, out Sketch2, out SketchDef2, ref currentPlane, leftOpeningDepth, leftOpeningSize);
			CreateLoftElement(iPart, Sketch1, Sketch2, thickness); // Элемент по сечениям (sketch1, sketch1)

			ksEntity Sketch3;
			ksSketchDefinition SketchDef3;
			double sketch3offset = 0.75 * wrenchParameters.LeftOpeningDepth;
			CreateHexSketch(iPart, kompas, out Sketch3, out SketchDef3, ref currentPlane, sketch3offset, tubeWidth);
			CreateLoftElement(iPart, Sketch2, Sketch3, thickness);

			ksEntity Sketch4;
			ksSketchDefinition SketchDef4;
			double sketch4offset = wrenchParameters.WrenchLength - 1.75 * (leftOpeningDepth + rightOpeningDepth);
			CreateHexSketch(iPart, kompas, out Sketch4, out SketchDef4, ref currentPlane, sketch4offset, tubeWidth);
			CreateLoftElement(iPart, Sketch3, Sketch4, thickness);

			ksEntity Sketch5;
			ksSketchDefinition SketchDef5;
			double sketch5offset = 0.75 * wrenchParameters.RightOpeningDepth;
			CreateHexSketch(iPart, kompas, out Sketch5, out SketchDef5, ref currentPlane, sketch5offset, rightOpeningSize);
			CreateLoftElement(iPart, Sketch4, Sketch5, thickness);

			ksEntity Sketch6;
			ksSketchDefinition SketchDef6;
			CreateHexSketch(iPart, kompas, out Sketch6, out SketchDef6, ref currentPlane, rightOpeningDepth, rightOpeningSize);
			CreateLoftElement(iPart, Sketch5, Sketch6, thickness);
		}



		/// <summary>
		/// Создать эскиз шестиугольника на смещенной плоскости от базовой плоскости YOZ
		/// </summary>
		/// <param name="Sketch">Интерфейс плоскости эскиза</param>
		/// <param name="DefinitionSketch">Эскиз</param>
		/// <param name="newPlane">Новая смещенная плоскость</param>
		/// <param name="offset"></param>
		public void CreateHexSketch(ksPart iPart, KompasObject kompas, out ksEntity sketch, 
			out ksSketchDefinition sketchDef, ref ksEntity currentPlane, double offset, double size)
		{
			// Интерфейс новой смещенной плоскости
			ksEntity newPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

			// Интерфейс настроек смещенной плоскости
			ksPlaneOffsetDefinition newPlaneDefinition = (ksPlaneOffsetDefinition)newPlane.GetDefinition();

			newPlaneDefinition.SetPlane(currentPlane); // начальная позиция плоскости: от предыдущей
			newPlaneDefinition.direction = true; // направление смещения: прямое
			newPlaneDefinition.offset = offset; // расстояние смещения
			newPlane.Create(); // создать плоскость

			sketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch); // Интерфейс эскиза 
			sketchDef = sketch.GetDefinition();
			sketchDef.SetPlane(newPlane);  // установка новой базовой плоскости для эскиза
			sketchDef.angle = 0; // угол поворота эскиза
			sketch.Create(); // создать эскиз

			currentPlane = newPlane; // установить последнюю созданную плоскость текущей
			ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

			DrawHexagon(kompas, ref sketchDef, ref sketchEdit, size); // экиз шестиугольника на плоскости
		}

		/// <summary>
		/// Эскиз шестиугольника
		/// </summary>
		/// <param name="iPart"></param>
		/// <param name="kompas"></param>
		/// <param name="size"></param>
		public void DrawHexagon(KompasObject kompas, ref ksSketchDefinition sketchDef, 
			ref ksDocument2D sketchEdit, double size)
		{
			//ksDocument2D sketchEdit = sketchDef.BeginEdit();
			ksRegularPolygonParam hexagonParam = (ksRegularPolygonParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RegularPolygonParam);
			hexagonParam.ang = 0;
			hexagonParam.count = 6;
			hexagonParam.describe = true; // Вписанный многоугольник
			hexagonParam.radius = size;
			hexagonParam.style = 1; // Стиль линии - основной
			hexagonParam.xc = 0;
			hexagonParam.yc = 0;
			sketchEdit.ksRegularPolygon(hexagonParam);
			sketchDef.EndEdit();
		}

		/// <summary>
		///  Элемент по сечениям (2 соседних эскиза)
		/// </summary>
		/// <param name="iPart"></param>
		/// <param name="sketch1"></param>
		/// <param name="sketch2"></param>
		/// <param name="thickness">Толщина </param>
		public void CreateLoftElement(ksPart iPart, ksEntity sketch1, ksEntity sketch2, double thickness)
		{
			var loftElement = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_baseLoft);
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
		/// Создать эскиз шестиугольника на смещенной плоскости от базовой плоскости YOZ
		/// </summary>
		/// <param name="Sketch"></param>
		/// <param name="DefinitionSketch"></param>
		/// <param name="newPlane"
		/// <param name="offset"></param>
		public void CreateHoles(ksPart iPart, KompasObject kompas, WrenchParameters wrenchParameters)
		{
			double radius = wrenchParameters.HolesDiameter;
			double ycl = 0 - (wrenchParameters.LeftOpeningDepth * 2 + radius);
			double ycr = 0 - (wrenchParameters.WrenchLength - (wrenchParameters.RightOpeningDepth * 1.75) - radius);
			double extrDepth = wrenchParameters.TubeWidth + wrenchParameters.WallThickness * 2;
			// Отверстие 1 на плоскости XOZ
			//----------------------------------------
			// Эскиз
			ksEntity planeXOZ = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
			ksEntity extrSketch1 = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition extrSketchDef1 = extrSketch1.GetDefinition();
			extrSketchDef1.SetPlane(planeXOZ);
			extrSketchDef1.angle = 0;
			extrSketch1.Create();
			ksDocument2D extrSketchEdit1 = (ksDocument2D)extrSketchDef1.BeginEdit();
			extrSketchEdit1.ksCircle(ycl, 0, radius, 1);
			extrSketchDef1.EndEdit();
			//----------------------------------------
			// Выдаливание
			ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
			cutExtrDef.SetSketch(extrSketch1);
			cutExtrDef.directionType = (short)Direction_Type.dtBoth;
			cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, extrDepth, 0, false);
			cutExtrDef.SetThinParam(false, 0, 0, 0);
			entityCutExtr.Create();

			// Отверстие 2 на плоскости XOY
			//----------------------------------------
			// Эскиз
			ksEntity planeXOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
			ksEntity extrSketch2 = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition extrSketchDef2 = extrSketch2.GetDefinition();
			extrSketchDef2.SetPlane(planeXOY);
			extrSketchDef2.angle = 0;
			extrSketch2.Create();
			ksDocument2D extrSketchEdit2 = (ksDocument2D)extrSketchDef2.BeginEdit();
			extrSketchEdit2.ksCircle(ycr, 0, radius, 1);
			extrSketchDef2.EndEdit();
			//----------------------------------------
			// Выдавливание
			ksEntity entityCutExtr2 = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrDef2 = (ksCutExtrusionDefinition)entityCutExtr2.GetDefinition();
			cutExtrDef2.SetSketch(extrSketch2);
			cutExtrDef2.directionType = (short)Direction_Type.dtBoth;
			cutExtrDef2.SetSideParam(true, (short)End_Type.etBlind, extrDepth, 0, false);
			cutExtrDef2.SetThinParam(false, 0, 0, 0);
			entityCutExtr2.Create();
		}
	}
}
