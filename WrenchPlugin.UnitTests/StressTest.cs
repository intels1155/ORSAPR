using WrenchPlugin.Model.Parameters;
using WrenchPlugin.Model.Kompas;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Environment = System.Environment;

namespace WrenchPlugin.UnitTests
{
	/// <summary>
	/// Сводное описание для StressTest
	/// </summary>
	[TestFixture]
	public class StressTest
	{
		[Test]
		public void Start()
		{
			var writer = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\StressTest.txt");//заменено на относительный путь

			var kompass = new KompasConnector();
			//var parameters = new WrenchParameters();
			//var builder = new WrenchBuilder();
			var count = 100;

			var processes = Process.GetProcessesByName("kStudy");
			var process = processes.First();

			var ramCounter = new PerformanceCounter("Process", "Working Set", process.ProcessName);
			var cpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);

			for (int i = 0; i < count; i++)
			{
				cpuCounter.NextValue();
				var kompas = new KompasConnector();
				var parameters = new WrenchParameters();
				var builder = new WrenchBuilder();
				builder.Build(kompas, parameters);

				var ram = ramCounter.NextValue();
				var cpu = cpuCounter.NextValue();

				writer.Write($"{i}. ");
				writer.Write($"RAM: {Math.Round(ram / 1024 / 1024)} MB");
				writer.Write($"\tCPU: {cpu} %");
				writer.Write(Environment.NewLine);
				writer.Flush();
			}
		}
	}
}
