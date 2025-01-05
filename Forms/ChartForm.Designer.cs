namespace WT_DataAnalysis
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lbl_Gear = new Label();
            grp_Gear = new GroupBox();
            grp_MaxRpm = new GroupBox();
            lbl_MaxRpm = new Label();
            chart_TrackMap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            grp_MaxSpeed = new GroupBox();
            lbl_MaxSpeed = new Label();
            grp_MaxECT = new GroupBox();
            lbl_MaxECT = new Label();
            grp_MaxIAT = new GroupBox();
            lbl_MaxIAT = new Label();
            grp_MaxOilTemp = new GroupBox();
            lbl_MaxOilTemp = new Label();
            grp_MaxOilPressure = new GroupBox();
            lbl_MaxOilPressure = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            grp_Gear.SuspendLayout();
            grp_MaxRpm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart_TrackMap).BeginInit();
            grp_MaxSpeed.SuspendLayout();
            grp_MaxECT.SuspendLayout();
            grp_MaxIAT.SuspendLayout();
            grp_MaxOilTemp.SuspendLayout();
            grp_MaxOilPressure.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(0, 10, 15);
            chart1.BorderlineColor = Color.FromArgb(45, 45, 45);
            chart1.Dock = DockStyle.Fill;
            chart1.Location = new Point(0, 0);
            chart1.Margin = new Padding(0);
            chart1.Name = "chart1";
            chart1.Size = new Size(1075, 450);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.MouseClick += chart1_MouseClick;
            chart1.MouseWheel += chart1_MouseWheelMove;
            // 
            // lbl_Gear
            // 
            lbl_Gear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Gear.AutoSize = true;
            lbl_Gear.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Gear.Location = new Point(23, 14);
            lbl_Gear.Name = "lbl_Gear";
            lbl_Gear.Size = new Size(28, 37);
            lbl_Gear.TabIndex = 1;
            lbl_Gear.Text = "-";
            // 
            // grp_Gear
            // 
            grp_Gear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grp_Gear.Controls.Add(lbl_Gear);
            grp_Gear.Location = new Point(3, 390);
            grp_Gear.Name = "grp_Gear";
            grp_Gear.Size = new Size(77, 56);
            grp_Gear.TabIndex = 3;
            grp_Gear.TabStop = false;
            grp_Gear.Text = "Gear";
            // 
            // grp_MaxRpm
            // 
            grp_MaxRpm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxRpm.Controls.Add(lbl_MaxRpm);
            grp_MaxRpm.Location = new Point(203, 390);
            grp_MaxRpm.Name = "grp_MaxRpm";
            grp_MaxRpm.Size = new Size(85, 56);
            grp_MaxRpm.TabIndex = 4;
            grp_MaxRpm.TabStop = false;
            grp_MaxRpm.Text = "Max RPM";
            // 
            // lbl_MaxRpm
            // 
            lbl_MaxRpm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxRpm.AutoSize = true;
            lbl_MaxRpm.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxRpm.Location = new Point(9, 14);
            lbl_MaxRpm.Name = "lbl_MaxRpm";
            lbl_MaxRpm.Size = new Size(61, 37);
            lbl_MaxRpm.TabIndex = 1;
            lbl_MaxRpm.Text = "----";
            // 
            // chart_TrackMap
            // 
            chart_TrackMap.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chart_TrackMap.Location = new Point(875, 250);
            chart_TrackMap.Name = "chart_TrackMap";
            chart_TrackMap.Size = new Size(200, 200);
            chart_TrackMap.TabIndex = 5;
            chart_TrackMap.Text = "chart_TrackMap";
            // 
            // grp_MaxSpeed
            // 
            grp_MaxSpeed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxSpeed.Controls.Add(lbl_MaxSpeed);
            grp_MaxSpeed.Location = new Point(294, 390);
            grp_MaxSpeed.Name = "grp_MaxSpeed";
            grp_MaxSpeed.Size = new Size(85, 56);
            grp_MaxSpeed.TabIndex = 5;
            grp_MaxSpeed.TabStop = false;
            grp_MaxSpeed.Text = "Max Speed";
            // 
            // lbl_MaxSpeed
            // 
            lbl_MaxSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxSpeed.AutoSize = true;
            lbl_MaxSpeed.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxSpeed.Location = new Point(14, 14);
            lbl_MaxSpeed.Name = "lbl_MaxSpeed";
            lbl_MaxSpeed.Size = new Size(50, 37);
            lbl_MaxSpeed.TabIndex = 1;
            lbl_MaxSpeed.Text = "---";
            // 
            // grp_MaxECT
            // 
            grp_MaxECT.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxECT.Controls.Add(lbl_MaxECT);
            grp_MaxECT.Location = new Point(385, 390);
            grp_MaxECT.Name = "grp_MaxECT";
            grp_MaxECT.Size = new Size(77, 56);
            grp_MaxECT.TabIndex = 5;
            grp_MaxECT.TabStop = false;
            grp_MaxECT.Text = "Max ECT";
            // 
            // lbl_MaxECT
            // 
            lbl_MaxECT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxECT.AutoSize = true;
            lbl_MaxECT.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxECT.Location = new Point(17, 14);
            lbl_MaxECT.Name = "lbl_MaxECT";
            lbl_MaxECT.Size = new Size(50, 37);
            lbl_MaxECT.TabIndex = 1;
            lbl_MaxECT.Text = "---";
            // 
            // grp_MaxIAT
            // 
            grp_MaxIAT.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxIAT.Controls.Add(lbl_MaxIAT);
            grp_MaxIAT.Location = new Point(468, 390);
            grp_MaxIAT.Name = "grp_MaxIAT";
            grp_MaxIAT.Size = new Size(77, 56);
            grp_MaxIAT.TabIndex = 5;
            grp_MaxIAT.TabStop = false;
            grp_MaxIAT.Text = "Max IAT";
            // 
            // lbl_MaxIAT
            // 
            lbl_MaxIAT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxIAT.AutoSize = true;
            lbl_MaxIAT.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxIAT.Location = new Point(18, 14);
            lbl_MaxIAT.Name = "lbl_MaxIAT";
            lbl_MaxIAT.Size = new Size(39, 37);
            lbl_MaxIAT.TabIndex = 1;
            lbl_MaxIAT.Text = "--";
            // 
            // grp_MaxOilTemp
            // 
            grp_MaxOilTemp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxOilTemp.Controls.Add(lbl_MaxOilTemp);
            grp_MaxOilTemp.Location = new Point(551, 390);
            grp_MaxOilTemp.Name = "grp_MaxOilTemp";
            grp_MaxOilTemp.Size = new Size(95, 56);
            grp_MaxOilTemp.TabIndex = 5;
            grp_MaxOilTemp.TabStop = false;
            grp_MaxOilTemp.Text = "Max Oil Temp";
            // 
            // lbl_MaxOilTemp
            // 
            lbl_MaxOilTemp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxOilTemp.AutoSize = true;
            lbl_MaxOilTemp.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxOilTemp.Location = new Point(24, 14);
            lbl_MaxOilTemp.Name = "lbl_MaxOilTemp";
            lbl_MaxOilTemp.Size = new Size(50, 37);
            lbl_MaxOilTemp.TabIndex = 1;
            lbl_MaxOilTemp.Text = "---";
            // 
            // grp_MaxOilPressure
            // 
            grp_MaxOilPressure.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grp_MaxOilPressure.Controls.Add(lbl_MaxOilPressure);
            grp_MaxOilPressure.Location = new Point(652, 390);
            grp_MaxOilPressure.Name = "grp_MaxOilPressure";
            grp_MaxOilPressure.Size = new Size(112, 56);
            grp_MaxOilPressure.TabIndex = 5;
            grp_MaxOilPressure.TabStop = false;
            grp_MaxOilPressure.Text = "Max Oil Pressure";
            // 
            // lbl_MaxOilPressure
            // 
            lbl_MaxOilPressure.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxOilPressure.AutoSize = true;
            lbl_MaxOilPressure.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxOilPressure.Location = new Point(29, 14);
            lbl_MaxOilPressure.Name = "lbl_MaxOilPressure";
            lbl_MaxOilPressure.Size = new Size(50, 37);
            lbl_MaxOilPressure.TabIndex = 1;
            lbl_MaxOilPressure.Text = "---";
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 450);
            Controls.Add(grp_MaxOilPressure);
            Controls.Add(grp_MaxOilTemp);
            Controls.Add(grp_MaxIAT);
            Controls.Add(grp_MaxECT);
            Controls.Add(grp_MaxSpeed);
            Controls.Add(chart_TrackMap);
            Controls.Add(grp_MaxRpm);
            Controls.Add(grp_Gear);
            Controls.Add(chart1);
            Name = "ChartForm";
            Text = "Chart Form";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            grp_Gear.ResumeLayout(false);
            grp_Gear.PerformLayout();
            grp_MaxRpm.ResumeLayout(false);
            grp_MaxRpm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart_TrackMap).EndInit();
            grp_MaxSpeed.ResumeLayout(false);
            grp_MaxSpeed.PerformLayout();
            grp_MaxECT.ResumeLayout(false);
            grp_MaxECT.PerformLayout();
            grp_MaxIAT.ResumeLayout(false);
            grp_MaxIAT.PerformLayout();
            grp_MaxOilTemp.ResumeLayout(false);
            grp_MaxOilTemp.PerformLayout();
            grp_MaxOilPressure.ResumeLayout(false);
            grp_MaxOilPressure.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lbl_Gear;
        private GroupBox grp_Gear;
        private GroupBox grp_MaxRpm;
        private Label lbl_MaxRpm;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_TrackMap;
        private GroupBox grp_MaxSpeed;
        private Label lbl_MaxSpeed;
        private GroupBox grp_MaxECT;
        private Label lbl_MaxECT;
        private GroupBox grp_MaxIAT;
        private Label lbl_MaxIAT;
        private GroupBox grp_MaxOilTemp;
        private Label lbl_MaxOilTemp;
        private GroupBox grp_MaxOilPressure;
        private Label lbl_MaxOilPressure;
    }
}