namespace WRD_DataAnalysis
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem_Theme = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart4).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.GrayText;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_Theme });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1221, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Theme
            // 
            toolStripMenuItem_Theme.Name = "toolStripMenuItem_Theme";
            toolStripMenuItem_Theme.Size = new Size(55, 20);
            toolStripMenuItem_Theme.Text = "Theme";
            toolStripMenuItem_Theme.Click += toolStripMenuItem_Theme_Click;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart1.BackColor = Color.DarkGray;
            chart1.Location = new Point(12, 27);
            chart1.Name = "chart1";
            chart1.Size = new Size(1185, 200);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.PostPaint += chart1_PostPaint;
            chart1.MouseMove += chart1_MouseMove;
            // 
            // chart2
            // 
            chart2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart2.BackColor = Color.DarkGray;
            chart2.Location = new Point(12, 233);
            chart2.Name = "chart2";
            chart2.Size = new Size(1185, 200);
            chart2.TabIndex = 4;
            chart2.Text = "chart2";
            // 
            // chart3
            // 
            chart3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart3.BackColor = Color.DarkGray;
            chart3.Location = new Point(12, 439);
            chart3.Name = "chart3";
            chart3.Size = new Size(1185, 200);
            chart3.TabIndex = 5;
            chart3.Text = "chart3";
            // 
            // chart4
            // 
            chart4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chart4.BackColor = Color.DarkGray;
            chart4.Location = new Point(12, 645);
            chart4.Name = "chart4";
            chart4.Size = new Size(1185, 200);
            chart4.TabIndex = 6;
            chart4.Text = "chart4";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1221, 922);
            Controls.Add(chart4);
            Controls.Add(chart3);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            SizeChanged += MainForm_SizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_theme;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem_Theme;
        private ToolTip toolTip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
    }
}
