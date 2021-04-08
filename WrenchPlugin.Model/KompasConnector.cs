using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;

namespace WrenchPlugin.Model.Kompas
{
	/// <summary>
	/// Класс для подключения к САПР КОМПАС-3D
	/// </summary>
	public class KompasConnector
	{

		/// <summary>
		/// 3D-документ
		/// </summary>
		private ksDocument3D _doc3D = null;

		/// <summary>
		/// Соединение с САПР и передача параметров
		/// </summary>
		public KompasConnector()
		{
			TakeKompas();
		}

		/// <summary>
		/// Свойство Kompas (интерфейс API)
		/// </summary>
		public KompasObject Kompas { get; set; } = null;
		/// <summary>
		/// Свойство Part (компонент/сборка)
		/// </summary>
		public ksPart Part { get; set; } = null;

		/// <summary>
		/// Открыть деталь в Компасе
		/// </summary>
		public void TakeKompas()
		{
			try
			{
				Kompas = (KompasObject)Marshal.GetActiveObject
					("KOMPAS.Application.5");
			}
			catch
			{
				Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
				Kompas = (KompasObject)Activator.CreateInstance(t);
			}

			Kompas.Visible = true;
			Kompas.ActivateControllerAPI();

			_doc3D = (ksDocument3D)Kompas.Document3D();
			_doc3D.Create(false, true);
			Part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
		}
	}
}
