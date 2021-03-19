using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WrenchPlugin.Model;

namespace WrenchPlugin.UI
{
	public partial class MainForm : Form
	{
		//private KompasConnector _kompasConnector;
		//private WrenchParameters _wrenchParameters;
		
		/// <summary>
		/// Окно программы
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			defaultParamComboBox.SelectedIndex = 0;
		}


		/// <summary>
		/// Обработчик кнопки "Построить"
		/// </summary>
		private void BuildButton_Click(object sender, EventArgs e)
		{
			try
			{
				WrenchParameters _wrenchParameters = new WrenchParameters(
					(double)leftOpenSizeNum.Value,
					(double)leftOpenDepthNum.Value,
					(double)rightOpenSizeNum.Value,
					(double)rightOpenDepthNum.Value,
					(double)wallThicknessNum.Value,
					(double)tubeWidthNum.Value,
					(double)holesDiameterNum.Value,
					(double)wrenchLengthNum.Value);
				KompasConnector kompasConnector = new KompasConnector();
				WrenchBuilder wrenchbuilder = new WrenchBuilder();
				wrenchbuilder.Build(kompasConnector, _wrenchParameters);
			}
			catch (ArgumentException ex)
			{
				// Вывод MessageBox со списком ошибок(ex.Message) при наличии несовместимых параметров
				MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

		}

		/// <summary>
		/// Выбор предустановленных параметров в ComboBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void defaultParamComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (defaultParamComboBox.SelectedIndex == 0) // параметры для демонстрации (по умолчанию)
			{
				leftOpenSizeNum.Value = 16;
				leftOpenDepthNum.Value = 24;
				rightOpenSizeNum.Value = 18;
				rightOpenDepthNum.Value = 26;
				wallThicknessNum.Value = 4;
				tubeWidthNum.Value = 14;
				holesDiameterNum.Value = 6;
				wrenchLengthNum.Value = 180;
			}
			if (defaultParamComboBox.SelectedIndex == 1) // выбор минимальных параметров
			{
				foreach (Control c in ParameterBox.Controls)
				{
					if (c.GetType() == typeof(NumericUpDown))
					{
						NumericUpDown num = c as NumericUpDown;
						num.Value = num.Minimum;
					}
				}
			}
			if (defaultParamComboBox.SelectedIndex == 2) // выбор максимальных параметров
			{
				foreach (Control c in ParameterBox.Controls)
				{
					if (c.GetType() == typeof(NumericUpDown))
					{
						NumericUpDown num = c as NumericUpDown;
						num.Value = num.Maximum; 
					}
				}
			}
		}
	}
}
