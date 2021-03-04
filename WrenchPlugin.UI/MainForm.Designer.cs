namespace WrenchPlugin.UI
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.WrenchSize1Label = new System.Windows.Forms.Label();
			this.WrenchSize2Label = new System.Windows.Forms.Label();
			this.Opening1DepthLabel = new System.Windows.Forms.Label();
			this.Opening2DepthLabel = new System.Windows.Forms.Label();
			this.WrenchLengthLabel = new System.Windows.Forms.Label();
			this.ThicknessLabel = new System.Windows.Forms.Label();
			this.DiameterLabel = new System.Windows.Forms.Label();
			this.BuildButton = new System.Windows.Forms.Button();
			this.ParameterBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.holesDiameterNum = new System.Windows.Forms.NumericUpDown();
			this.wallThicknessNum = new System.Windows.Forms.NumericUpDown();
			this.rightOpenDepthNum = new System.Windows.Forms.NumericUpDown();
			this.rightOpenSizeNum = new System.Windows.Forms.NumericUpDown();
			this.leftOpenDepthNum = new System.Windows.Forms.NumericUpDown();
			this.leftOpenSizeNum = new System.Windows.Forms.NumericUpDown();
			this.tubeWidthNum = new System.Windows.Forms.NumericUpDown();
			this.wrenchLengthNum = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TubeSizeLabel = new System.Windows.Forms.Label();
			this.defaultParamComboBox = new System.Windows.Forms.ComboBox();
			this.DefaultParametersLabel = new System.Windows.Forms.Label();
			this.ParameterBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.holesDiameterNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wallThicknessNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rightOpenDepthNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rightOpenSizeNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.leftOpenDepthNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.leftOpenSizeNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tubeWidthNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wrenchLengthNum)).BeginInit();
			this.SuspendLayout();
			// 
			// WrenchSize1Label
			// 
			this.WrenchSize1Label.AutoSize = true;
			this.WrenchSize1Label.Location = new System.Drawing.Point(20, 31);
			this.WrenchSize1Label.Name = "WrenchSize1Label";
			this.WrenchSize1Label.Size = new System.Drawing.Size(88, 13);
			this.WrenchSize1Label.TabIndex = 0;
			this.WrenchSize1Label.Text = "Ширина зева 1  ";
			// 
			// WrenchSize2Label
			// 
			this.WrenchSize2Label.AutoSize = true;
			this.WrenchSize2Label.Location = new System.Drawing.Point(166, 30);
			this.WrenchSize2Label.Name = "WrenchSize2Label";
			this.WrenchSize2Label.Size = new System.Drawing.Size(82, 13);
			this.WrenchSize2Label.TabIndex = 1;
			this.WrenchSize2Label.Text = "Ширина зева 2";
			// 
			// Opening1DepthLabel
			// 
			this.Opening1DepthLabel.AutoSize = true;
			this.Opening1DepthLabel.Location = new System.Drawing.Point(20, 78);
			this.Opening1DepthLabel.Name = "Opening1DepthLabel";
			this.Opening1DepthLabel.Size = new System.Drawing.Size(84, 13);
			this.Opening1DepthLabel.TabIndex = 2;
			this.Opening1DepthLabel.Text = "Глубина зева 1";
			// 
			// Opening2DepthLabel
			// 
			this.Opening2DepthLabel.AutoSize = true;
			this.Opening2DepthLabel.Location = new System.Drawing.Point(166, 78);
			this.Opening2DepthLabel.Name = "Opening2DepthLabel";
			this.Opening2DepthLabel.Size = new System.Drawing.Size(90, 13);
			this.Opening2DepthLabel.TabIndex = 3;
			this.Opening2DepthLabel.Text = "Глубина зева 2  ";
			// 
			// WrenchLengthLabel
			// 
			this.WrenchLengthLabel.AutoSize = true;
			this.WrenchLengthLabel.Location = new System.Drawing.Point(166, 196);
			this.WrenchLengthLabel.Name = "WrenchLengthLabel";
			this.WrenchLengthLabel.Size = new System.Drawing.Size(74, 13);
			this.WrenchLengthLabel.TabIndex = 4;
			this.WrenchLengthLabel.Text = "Длина ключа";
			// 
			// ThicknessLabel
			// 
			this.ThicknessLabel.AutoSize = true;
			this.ThicknessLabel.Location = new System.Drawing.Point(166, 145);
			this.ThicknessLabel.Name = "ThicknessLabel";
			this.ThicknessLabel.Size = new System.Drawing.Size(131, 13);
			this.ThicknessLabel.TabIndex = 5;
			this.ThicknessLabel.Text = "Толщина стенки ключа  ";
			// 
			// DiameterLabel
			// 
			this.DiameterLabel.AutoSize = true;
			this.DiameterLabel.Location = new System.Drawing.Point(20, 196);
			this.DiameterLabel.Name = "DiameterLabel";
			this.DiameterLabel.Size = new System.Drawing.Size(108, 13);
			this.DiameterLabel.TabIndex = 6;
			this.DiameterLabel.Text = "Диаметр отверстий";
			// 
			// BuildButton
			// 
			this.BuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BuildButton.FlatAppearance.BorderSize = 2;
			this.BuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BuildButton.Location = new System.Drawing.Point(68, 300);
			this.BuildButton.Name = "BuildButton";
			this.BuildButton.Size = new System.Drawing.Size(212, 30);
			this.BuildButton.TabIndex = 0;
			this.BuildButton.Text = "Построить модель в КОМПАС-3D";
			this.BuildButton.UseVisualStyleBackColor = true;
			this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
			// 
			// ParameterBox
			// 
			this.ParameterBox.Controls.Add(this.label1);
			this.ParameterBox.Controls.Add(this.holesDiameterNum);
			this.ParameterBox.Controls.Add(this.wallThicknessNum);
			this.ParameterBox.Controls.Add(this.rightOpenDepthNum);
			this.ParameterBox.Controls.Add(this.rightOpenSizeNum);
			this.ParameterBox.Controls.Add(this.leftOpenDepthNum);
			this.ParameterBox.Controls.Add(this.leftOpenSizeNum);
			this.ParameterBox.Controls.Add(this.tubeWidthNum);
			this.ParameterBox.Controls.Add(this.wrenchLengthNum);
			this.ParameterBox.Controls.Add(this.label12);
			this.ParameterBox.Controls.Add(this.label11);
			this.ParameterBox.Controls.Add(this.label10);
			this.ParameterBox.Controls.Add(this.label9);
			this.ParameterBox.Controls.Add(this.label8);
			this.ParameterBox.Controls.Add(this.label5);
			this.ParameterBox.Controls.Add(this.label3);
			this.ParameterBox.Controls.Add(this.label2);
			this.ParameterBox.Controls.Add(this.TubeSizeLabel);
			this.ParameterBox.Controls.Add(this.DiameterLabel);
			this.ParameterBox.Controls.Add(this.WrenchSize1Label);
			this.ParameterBox.Controls.Add(this.WrenchSize2Label);
			this.ParameterBox.Controls.Add(this.Opening1DepthLabel);
			this.ParameterBox.Controls.Add(this.WrenchLengthLabel);
			this.ParameterBox.Controls.Add(this.Opening2DepthLabel);
			this.ParameterBox.Controls.Add(this.ThicknessLabel);
			this.ParameterBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.ParameterBox.Location = new System.Drawing.Point(12, 39);
			this.ParameterBox.Name = "ParameterBox";
			this.ParameterBox.Size = new System.Drawing.Size(320, 250);
			this.ParameterBox.TabIndex = 18;
			this.ParameterBox.TabStop = false;
			this.ParameterBox.Text = "Параметры ключа";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label1.Location = new System.Drawing.Point(37, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 1);
			this.label1.TabIndex = 25;
			// 
			// holesDiameterNum
			// 
			this.holesDiameterNum.DecimalPlaces = 1;
			this.holesDiameterNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.holesDiameterNum.Location = new System.Drawing.Point(23, 212);
			this.holesDiameterNum.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.holesDiameterNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.holesDiameterNum.Name = "holesDiameterNum";
			this.holesDiameterNum.Size = new System.Drawing.Size(66, 20);
			this.holesDiameterNum.TabIndex = 7;
			this.holesDiameterNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// wallThicknessNum
			// 
			this.wallThicknessNum.DecimalPlaces = 1;
			this.wallThicknessNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.wallThicknessNum.Location = new System.Drawing.Point(169, 160);
			this.wallThicknessNum.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
			this.wallThicknessNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.wallThicknessNum.Name = "wallThicknessNum";
			this.wallThicknessNum.Size = new System.Drawing.Size(66, 20);
			this.wallThicknessNum.TabIndex = 8;
			this.wallThicknessNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// rightOpenDepthNum
			// 
			this.rightOpenDepthNum.DecimalPlaces = 1;
			this.rightOpenDepthNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.rightOpenDepthNum.Location = new System.Drawing.Point(169, 94);
			this.rightOpenDepthNum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.rightOpenDepthNum.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
			this.rightOpenDepthNum.Name = "rightOpenDepthNum";
			this.rightOpenDepthNum.Size = new System.Drawing.Size(66, 20);
			this.rightOpenDepthNum.TabIndex = 5;
			this.rightOpenDepthNum.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
			// 
			// rightOpenSizeNum
			// 
			this.rightOpenSizeNum.DecimalPlaces = 1;
			this.rightOpenSizeNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.rightOpenSizeNum.Location = new System.Drawing.Point(169, 46);
			this.rightOpenSizeNum.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
			this.rightOpenSizeNum.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.rightOpenSizeNum.Name = "rightOpenSizeNum";
			this.rightOpenSizeNum.Size = new System.Drawing.Size(66, 20);
			this.rightOpenSizeNum.TabIndex = 4;
			this.rightOpenSizeNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// leftOpenDepthNum
			// 
			this.leftOpenDepthNum.DecimalPlaces = 1;
			this.leftOpenDepthNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.leftOpenDepthNum.Location = new System.Drawing.Point(23, 94);
			this.leftOpenDepthNum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.leftOpenDepthNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.leftOpenDepthNum.Name = "leftOpenDepthNum";
			this.leftOpenDepthNum.Size = new System.Drawing.Size(66, 20);
			this.leftOpenDepthNum.TabIndex = 3;
			this.leftOpenDepthNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// leftOpenSizeNum
			// 
			this.leftOpenSizeNum.DecimalPlaces = 1;
			this.leftOpenSizeNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.leftOpenSizeNum.Location = new System.Drawing.Point(23, 46);
			this.leftOpenSizeNum.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
			this.leftOpenSizeNum.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.leftOpenSizeNum.Name = "leftOpenSizeNum";
			this.leftOpenSizeNum.Size = new System.Drawing.Size(66, 20);
			this.leftOpenSizeNum.TabIndex = 2;
			this.leftOpenSizeNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// tubeWidthNum
			// 
			this.tubeWidthNum.DecimalPlaces = 1;
			this.tubeWidthNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tubeWidthNum.Location = new System.Drawing.Point(23, 164);
			this.tubeWidthNum.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
			this.tubeWidthNum.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.tubeWidthNum.Name = "tubeWidthNum";
			this.tubeWidthNum.Size = new System.Drawing.Size(66, 20);
			this.tubeWidthNum.TabIndex = 6;
			this.tubeWidthNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// wrenchLengthNum
			// 
			this.wrenchLengthNum.DecimalPlaces = 1;
			this.wrenchLengthNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.wrenchLengthNum.Location = new System.Drawing.Point(169, 212);
			this.wrenchLengthNum.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.wrenchLengthNum.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
			this.wrenchLengthNum.Name = "wrenchLengthNum";
			this.wrenchLengthNum.Size = new System.Drawing.Size(66, 20);
			this.wrenchLengthNum.TabIndex = 9;
			this.wrenchLengthNum.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label12.Location = new System.Drawing.Point(95, 214);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 13);
			this.label12.TabIndex = 24;
			this.label12.Text = "(2 - 40 мм)";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label11.Location = new System.Drawing.Point(241, 162);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "(2 - 14 мм)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label10.Location = new System.Drawing.Point(241, 96);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "(2,5 - 50 мм)";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label9.Location = new System.Drawing.Point(241, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "(5 - 80 мм)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label8.Location = new System.Drawing.Point(95, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "(2 - 50 мм)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label5.Location = new System.Drawing.Point(95, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "(4 - 75 мм)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label3.Location = new System.Drawing.Point(95, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "(4 - 75 мм)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label2.Location = new System.Drawing.Point(241, 214);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "(80 - 400 мм)";
			// 
			// TubeSizeLabel
			// 
			this.TubeSizeLabel.AutoSize = true;
			this.TubeSizeLabel.Location = new System.Drawing.Point(20, 148);
			this.TubeSizeLabel.Name = "TubeSizeLabel";
			this.TubeSizeLabel.Size = new System.Drawing.Size(117, 13);
			this.TubeSizeLabel.TabIndex = 15;
			this.TubeSizeLabel.Text = "Размер трубки ключа";
			// 
			// defaultParamComboBox
			// 
			this.defaultParamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.defaultParamComboBox.FormattingEnabled = true;
			this.defaultParamComboBox.Items.AddRange(new object[] {
            "По умолчанию",
            "Минимальные",
            "Максимальные"});
			this.defaultParamComboBox.Location = new System.Drawing.Point(214, 12);
			this.defaultParamComboBox.Name = "defaultParamComboBox";
			this.defaultParamComboBox.Size = new System.Drawing.Size(121, 21);
			this.defaultParamComboBox.TabIndex = 1;
			this.defaultParamComboBox.SelectedIndexChanged += new System.EventHandler(this.defaultParamComboBox_SelectedIndexChanged);
			// 
			// DefaultParametersLabel
			// 
			this.DefaultParametersLabel.AutoSize = true;
			this.DefaultParametersLabel.Location = new System.Drawing.Point(65, 15);
			this.DefaultParametersLabel.Name = "DefaultParametersLabel";
			this.DefaultParametersLabel.Size = new System.Drawing.Size(143, 13);
			this.DefaultParametersLabel.TabIndex = 22;
			this.DefaultParametersLabel.Text = "Параметры по умолчанию:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 341);
			this.Controls.Add(this.DefaultParametersLabel);
			this.Controls.Add(this.defaultParamComboBox);
			this.Controls.Add(this.ParameterBox);
			this.Controls.Add(this.BuildButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "WrenchPlugin";
			this.ParameterBox.ResumeLayout(false);
			this.ParameterBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.holesDiameterNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wallThicknessNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rightOpenDepthNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rightOpenSizeNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.leftOpenDepthNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.leftOpenSizeNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tubeWidthNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wrenchLengthNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label WrenchSize1Label;
		private System.Windows.Forms.Label WrenchSize2Label;
		private System.Windows.Forms.Label Opening2DepthLabel;
		private System.Windows.Forms.Label WrenchLengthLabel;
		private System.Windows.Forms.Label ThicknessLabel;
		private System.Windows.Forms.Label DiameterLabel;
		private System.Windows.Forms.Button BuildButton;
		private System.Windows.Forms.Label Opening1DepthLabel;
		private System.Windows.Forms.GroupBox ParameterBox;
		private System.Windows.Forms.Label TubeSizeLabel;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tubeWidthNum;
		private System.Windows.Forms.NumericUpDown wrenchLengthNum;
		private System.Windows.Forms.NumericUpDown rightOpenDepthNum;
		private System.Windows.Forms.NumericUpDown rightOpenSizeNum;
		private System.Windows.Forms.NumericUpDown leftOpenDepthNum;
		private System.Windows.Forms.NumericUpDown leftOpenSizeNum;
		private System.Windows.Forms.NumericUpDown holesDiameterNum;
		private System.Windows.Forms.NumericUpDown wallThicknessNum;
		private System.Windows.Forms.ComboBox defaultParamComboBox;
		private System.Windows.Forms.Label DefaultParametersLabel;
		private System.Windows.Forms.Label label1;
	}
}

