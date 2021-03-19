using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace WrenchPlugin.Model
{
	/// <summary>
	/// Класс для подключения к САПР КОМПАС-3D
	/// </summary>
	public class KompasConnector
	{
		/// <summary>
		/// Главный интерфейс API КОМПАС-3D
		/// </summary>
		private KompasObject _kompas = null;

		/// <summary>
		/// 3D-документ
		/// </summary>
		private ksDocument3D _doc3D = null;

		/// <summary>
		/// Интерфейс детали/компонента сборки
		/// </summary>
		private ksPart _part = null;

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
		public KompasObject Kompas
		{
			get
			{
				return _kompas;
			}
			set
			{
				_kompas = value;
			}
		}
		/// <summary>
		/// Свойство Part (компонент/сборка)
		/// </summary>
		public ksPart Part
		{
			get
			{
				return _part;
			}
			set
			{
				_part = value;
			}
		}

		/// <summary>
		/// Открыть деталь в Компасе
		/// </summary>
		public void TakeKompas()
		{
			if (_kompas == null)
			{
				Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
				_kompas = (KompasObject)Activator.CreateInstance(t);
			}
			_kompas.Visible = true;
			_kompas.ActivateControllerAPI();

			_doc3D = (ksDocument3D)_kompas.Document3D();
			_doc3D.Create(false, true);
			_part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
		}
	}
}
