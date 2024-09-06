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
            tsmi_ChartForm = new ToolStripMenuItem();
            tsmi_SettingsForm = new ToolStripMenuItem();
            tsmi_LoadFile = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            ofd_LoadFile = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
            menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmi_LoadFile, tsmi_ChartForm, tsmi_SettingsForm });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1131, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_ChartForm
            // 
            tsmi_ChartForm.Name = "tsmi_ChartForm";
            tsmi_ChartForm.Size = new Size(53, 20);
            tsmi_ChartForm.Text = "Charts";
            tsmi_ChartForm.Click += toolStripMenuItem_ChartForm_Click;
            // 
            // tsmi_SettingsForm
            // 
            tsmi_SettingsForm.Name = "tsmi_SettingsForm";
            tsmi_SettingsForm.Size = new Size(61, 20);
            tsmi_SettingsForm.Text = "Settings";
            tsmi_SettingsForm.Click += toolStripMenuItem_SettingsForm_Click;
            // 
            // tsmi_LoadFile
            // 
            tsmi_LoadFile.Name = "tsmi_LoadFile";
            tsmi_LoadFile.Size = new Size(66, 20);
            tsmi_LoadFile.Text = "Load File";
            tsmi_LoadFile.Click += toolStripMenuItem_LoadFile_Click;
            // 
            // ofd_LoadFile
            // 
            ofd_LoadFile.FileName = "ofd_LoadFile";
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
            Text = "WillTech - Data Acquisition";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_theme;
        private ToolTip toolTip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmi_ChartForm;
        private ToolStripMenuItem tsmi_SettingsForm;
        private ToolStripMenuItem tsmi_LoadFile;
        private OpenFileDialog ofd_LoadFile;
    }
}
