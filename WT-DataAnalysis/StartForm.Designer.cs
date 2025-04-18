﻿namespace WT_DataAnalysis;

partial class StartForm
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
        btn_RunDatalogReview = new Button();
        btn_RunLiveTelemetry = new Button();
        pnl_StartForm = new Panel();
        pnl_StartForm.SuspendLayout();
        SuspendLayout();
        // 
        // btn_RunDatalogReview
        // 
        btn_RunDatalogReview.Location = new Point(12, 12);
        btn_RunDatalogReview.Name = "btn_RunDatalogReview";
        btn_RunDatalogReview.Size = new Size(100, 80);
        btn_RunDatalogReview.TabIndex = 1;
        btn_RunDatalogReview.Text = "Datalog Review";
        btn_RunDatalogReview.UseVisualStyleBackColor = true;
        btn_RunDatalogReview.Click += Btn_RunDatalogReview_Click;
        // 
        // btn_RunLiveTelemetry
        // 
        btn_RunLiveTelemetry.Location = new Point(118, 12);
        btn_RunLiveTelemetry.Name = "btn_RunLiveTelemetry";
        btn_RunLiveTelemetry.Size = new Size(100, 80);
        btn_RunLiveTelemetry.TabIndex = 2;
        btn_RunLiveTelemetry.Text = "Live Telemetry";
        btn_RunLiveTelemetry.UseVisualStyleBackColor = true;
        btn_RunLiveTelemetry.Click += Btn_RunLiveTelemetry_Click;
        // 
        // pnl_StartForm
        // 
        pnl_StartForm.Controls.Add(btn_RunDatalogReview);
        pnl_StartForm.Controls.Add(btn_RunLiveTelemetry);
        pnl_StartForm.Dock = DockStyle.Fill;
        pnl_StartForm.Location = new Point(0, 0);
        pnl_StartForm.Name = "pnl_StartForm";
        pnl_StartForm.Size = new Size(800, 450);
        pnl_StartForm.TabIndex = 3;
        // 
        // StartForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 10, 15);
        ClientSize = new Size(800, 450);
        Controls.Add(pnl_StartForm);
        Name = "StartForm";
        Text = "WillTech";
        pnl_StartForm.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Button btn_RunDatalogReview;
    private Button btn_RunLiveTelemetry;
    private Panel pnl_StartForm;
}
