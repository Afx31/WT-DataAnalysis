﻿namespace WT_DataAnalysis_DatalogReview;

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
        tsmi_LoadFile = new ToolStripMenuItem();
        tsmi_DatalogReviewForm = new ToolStripMenuItem();
        tsmi_ScatterPlotForm = new ToolStripMenuItem();
        tsmi_SettingsForm = new ToolStripMenuItem();
        tsmi_LapSelector = new ToolStripComboBox();
        toolTip1 = new ToolTip(components);
        ofd_LoadFile = new OpenFileDialog();
        pnl_DataAnalysisBase = new Panel();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
        menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
        menuStrip1.Items.AddRange(new ToolStripItem[] { tsmi_LoadFile, tsmi_DatalogReviewForm, tsmi_ScatterPlotForm, tsmi_SettingsForm, tsmi_LapSelector });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1131, 27);
        menuStrip1.TabIndex = 3;
        menuStrip1.Text = "menuStrip1";
        // 
        // tsmi_LoadFile
        // 
        tsmi_LoadFile.Name = "tsmi_LoadFile";
        tsmi_LoadFile.Size = new Size(66, 23);
        tsmi_LoadFile.Text = "Load File";
        tsmi_LoadFile.Click += toolStripMenuItem_Click;
        // 
        // tsmi_DatalogReviewForm
        // 
        tsmi_DatalogReviewForm.Name = "tsmi_DatalogReviewForm";
        tsmi_DatalogReviewForm.Size = new Size(132, 23);
        tsmi_DatalogReviewForm.Text = "Datalog Review Chart";
        tsmi_DatalogReviewForm.Click += toolStripMenuItem_Click;
        // 
        // tsmi_ScatterPlotForm
        // 
        tsmi_ScatterPlotForm.Name = "tsmi_ScatterPlotForm";
        tsmi_ScatterPlotForm.Size = new Size(79, 23);
        tsmi_ScatterPlotForm.Text = "Scatter Plot";
        tsmi_ScatterPlotForm.Click += toolStripMenuItem_Click;
        // 
        // tsmi_SettingsForm
        // 
        tsmi_SettingsForm.Name = "tsmi_SettingsForm";
        tsmi_SettingsForm.Size = new Size(61, 23);
        tsmi_SettingsForm.Text = "Settings";
        tsmi_SettingsForm.Click += toolStripMenuItem_Click;
        // 
        // tsmi_LapSelector
        // 
        tsmi_LapSelector.Items.AddRange(new object[] { "All Laps" });
        tsmi_LapSelector.Name = "tsmi_LapSelector";
        tsmi_LapSelector.Size = new Size(80, 23);
        tsmi_LapSelector.Text = "All Laps";
        tsmi_LapSelector.SelectedIndexChanged += tsmi_LapSelector_SelectedIndexChanged;
        // 
        // ofd_LoadFile
        // 
        ofd_LoadFile.FileName = "ofd_LoadFile";
        // 
        // pnl_DataAnalysisBase
        // 
        pnl_DataAnalysisBase.Dock = DockStyle.Fill;
        pnl_DataAnalysisBase.Location = new Point(0, 27);
        pnl_DataAnalysisBase.Name = "pnl_DataAnalysisBase";
        pnl_DataAnalysisBase.Size = new Size(1131, 466);
        pnl_DataAnalysisBase.TabIndex = 4;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(1131, 493);
        Controls.Add(pnl_DataAnalysisBase);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "Data Analysis";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btn_theme;
    private ToolTip toolTip1;
    private MenuStrip menuStrip1;
    private OpenFileDialog ofd_LoadFile;
    private ToolStripMenuItem tsmi_LoadFile;
    private ToolStripMenuItem tsmi_DatalogReviewForm;
    private ToolStripMenuItem tsmi_ScatterPlotForm;
    private ToolStripMenuItem tsmi_SettingsForm;
    private ToolStripComboBox tsmi_LapSelector;
    private Panel pnl_DataAnalysisBase;
}
