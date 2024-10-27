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
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            grp_Gear.SuspendLayout();
            grp_MaxRpm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart_TrackMap).BeginInit();
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
            chart1.Size = new Size(800, 450);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.MouseClick += chart1_MouseClick;
            chart1.MouseLeave += chart1_MouseLeave;
            chart1.MouseMove += chart1_MouseMove;
            chart1.MouseWheel += chart1_MouseWheelMove;
            chart1.MouseDown += chart1_MouseDown;
            chart1.MouseUp += chart1_MouseUp;
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
            grp_MaxRpm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grp_MaxRpm.Controls.Add(lbl_MaxRpm);
            grp_MaxRpm.Location = new Point(86, 390);
            grp_MaxRpm.Name = "grp_MaxRpm";
            grp_MaxRpm.Size = new Size(77, 56);
            grp_MaxRpm.TabIndex = 4;
            grp_MaxRpm.TabStop = false;
            grp_MaxRpm.Text = "Max RPM";
            // 
            // lbl_MaxRpm
            // 
            lbl_MaxRpm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_MaxRpm.AutoSize = true;
            lbl_MaxRpm.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MaxRpm.Location = new Point(4, 14);
            lbl_MaxRpm.Name = "lbl_MaxRpm";
            lbl_MaxRpm.Size = new Size(28, 37);
            lbl_MaxRpm.TabIndex = 1;
            lbl_MaxRpm.Text = "-";
            // 
            // chart_TrackMap
            // 
            chart_TrackMap.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chart_TrackMap.Location = new Point(495, 146);
            chart_TrackMap.Name = "chart_TrackMap";
            chart_TrackMap.Size = new Size(300, 300);
            chart_TrackMap.TabIndex = 5;
            chart_TrackMap.Text = "chart_TrackMap";
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lbl_Gear;
        private GroupBox grp_Gear;
        private GroupBox grp_MaxRpm;
        private Label lbl_MaxRpm;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_TrackMap;
    }
}