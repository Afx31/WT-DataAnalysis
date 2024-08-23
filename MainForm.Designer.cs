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
            toolStripMenuItem_ChartForm = new ToolStripMenuItem();
            toolStripMenuItem_SettingsForm = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
            menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_ChartForm, toolStripMenuItem_SettingsForm });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1131, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_ChartForm
            // 
            toolStripMenuItem_ChartForm.Name = "toolStripMenuItem_ChartForm";
            toolStripMenuItem_ChartForm.Size = new Size(53, 20);
            toolStripMenuItem_ChartForm.Text = "Charts";
            toolStripMenuItem_ChartForm.Click += toolStripMenuItem_ChartForm_Click;
            // 
            // toolStripMenuItem_SettingsForm
            // 
            toolStripMenuItem_SettingsForm.Name = "toolStripMenuItem_SettingsForm";
            toolStripMenuItem_SettingsForm.Size = new Size(61, 20);
            toolStripMenuItem_SettingsForm.Text = "Settings";
            toolStripMenuItem_SettingsForm.Click += toolStripMenuItem_SettingsForm_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1131, 493);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_theme;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem_ChartForm;
        private ToolStripMenuItem toolStripMenuItem_SettingsForm;
        private ToolTip toolTip1;
    }
}
