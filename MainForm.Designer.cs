using System.Windows.Forms;

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
            tableLayoutPanel1 = new TableLayoutPanel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
            menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_Theme });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1131, 24);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(chart1, 0, 0);
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(12, 39);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.30025F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.699752F));
            tableLayoutPanel1.Size = new Size(1107, 442);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart1.BackColor = Color.FromArgb(0, 10, 15);
            chart1.BorderlineColor = Color.FromArgb(45, 45, 45);
            chart1.Location = new Point(3, 3);
            chart1.Name = "chart1";
            chart1.Size = new Size(1101, 406);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.MouseMove += chart1_MouseMove;
            chart1.MouseWheel += chart1_MouseWheelMove;
            chart1.MouseLeave += chart1_MouseLeave;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1131, 493);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_theme;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem_Theme;
        private ToolTip toolTip1;
        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
