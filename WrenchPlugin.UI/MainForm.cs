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
                //TODO: RSDN
				WrenchParameters wrenchParameters = new WrenchParameters(
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
				wrenchbuilder.Build(kompasConnector, wrenchParameters);
			}
			catch (ArgumentException ex)
			{
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
			var tmpParams = new WrenchParameters();
			//TODO: switch-case
			switch (defaultParamComboBox.SelectedIndex)
			{
				case 0: // параметры для демонстрации (по умолчанию)
					leftOpenSizeNum.Value = (decimal)tmpParams.LeftOpeningSize.Value;
					leftOpenDepthNum.Value = (decimal)tmpParams.LeftOpeningDepth.Value;
					rightOpenSizeNum.Value = (decimal)tmpParams.RightOpeningSize.Value;
					rightOpenDepthNum.Value = (decimal)tmpParams.RightOpeningDepth.Value;
					wallThicknessNum.Value = (decimal)tmpParams.WallThickness.Value;
					tubeWidthNum.Value = (decimal)tmpParams.TubeWidth.Value;
					holesDiameterNum.Value = (decimal)tmpParams.HolesDiameter.Value;
					wrenchLengthNum.Value = (decimal)tmpParams.WrenchLength.Value;
					break;
				case 1: // выбор минимальных параметров
					leftOpenSizeNum.Value = (decimal)tmpParams.LeftOpeningSize.Minimum;
					leftOpenDepthNum.Value = (decimal)tmpParams.LeftOpeningDepth.Minimum;
					rightOpenSizeNum.Value = (decimal)tmpParams.RightOpeningSize.Minimum;
					rightOpenDepthNum.Value = (decimal)tmpParams.RightOpeningDepth.Minimum;
					wallThicknessNum.Value = (decimal)tmpParams.WallThickness.Minimum;
					tubeWidthNum.Value = (decimal)tmpParams.TubeWidth.Minimum;
					holesDiameterNum.Value = (decimal)tmpParams.HolesDiameter.Minimum;
					wrenchLengthNum.Value = (decimal)tmpParams.WrenchLength.Minimum;
					break;
				case 2: // выбор максимальных параметров
					leftOpenSizeNum.Value = (decimal)tmpParams.LeftOpeningSize.Maximum;
					leftOpenDepthNum.Value = (decimal)tmpParams.LeftOpeningDepth.Maximum;
					rightOpenSizeNum.Value = (decimal)tmpParams.RightOpeningSize.Maximum;
					rightOpenDepthNum.Value = (decimal)tmpParams.RightOpeningDepth.Maximum;
					wallThicknessNum.Value = (decimal)tmpParams.WallThickness.Maximum;
					tubeWidthNum.Value = (decimal)tmpParams.TubeWidth.Maximum;
					holesDiameterNum.Value = (decimal)tmpParams.HolesDiameter.Maximum;
					wrenchLengthNum.Value = (decimal)tmpParams.WrenchLength.Maximum;
					break;
			}
		}
	}
}
