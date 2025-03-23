namespace WT_DataAnalysis;

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
        SuspendLayout();
        // 
        // btn_RunDatalogReview
        // 
        btn_RunDatalogReview.Location = new Point(259, 159);
        btn_RunDatalogReview.Name = "btn_RunDatalogReview";
        btn_RunDatalogReview.Size = new Size(100, 80);
        btn_RunDatalogReview.TabIndex = 1;
        btn_RunDatalogReview.Text = "Datalog Review";
        btn_RunDatalogReview.UseVisualStyleBackColor = true;
        btn_RunDatalogReview.Click += btn_RunDatalogReview_Click;
        // 
        // btn_RunLiveTelemetry
        // 
        btn_RunLiveTelemetry.Location = new Point(445, 159);
        btn_RunLiveTelemetry.Name = "btn_RunLiveTelemetry";
        btn_RunLiveTelemetry.Size = new Size(100, 80);
        btn_RunLiveTelemetry.TabIndex = 2;
        btn_RunLiveTelemetry.Text = "Live Telemetry";
        btn_RunLiveTelemetry.UseVisualStyleBackColor = true;
        btn_RunLiveTelemetry.Click += btn_RunLiveTelemetry_Click;
        // 
        // StartForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 10, 15);
        ClientSize = new Size(800, 450);
        Controls.Add(btn_RunLiveTelemetry);
        Controls.Add(btn_RunDatalogReview);
        Name = "StartForm";
        Text = "StartForm";
        Load += StartForm_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button btn_RunDatalogReview;
    private Button btn_RunLiveTelemetry;
}
