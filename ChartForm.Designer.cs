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
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            grp_Gear.SuspendLayout();
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
            grp_Gear.Location = new Point(3, 384);
            grp_Gear.Name = "grp_Gear";
            grp_Gear.Size = new Size(77, 62);
            grp_Gear.TabIndex = 3;
            grp_Gear.TabStop = false;
            grp_Gear.Text = "Gear";
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grp_Gear);
            Controls.Add(chart1);
            Name = "ChartForm";
            Text = "Chart Form";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            grp_Gear.ResumeLayout(false);
            grp_Gear.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lbl_Gear;
        private GroupBox grp_Gear;
    }
}