namespace WT_DataAnalysis;

public partial class StartForm : Form
{
    public StartForm()
    {
        InitializeComponent();
        this.IsMdiContainer = true;
        CenterPanel();

        bool dev = true;
        bool autoStartDataloggingReview = false;
        bool autoStartLiveTelemetry = false;

        if (dev)
        {
            this.StartPosition = FormStartPosition.Manual;
            Screen[] screens = Screen.AllScreens;
            Point location = screens[0].Bounds.Location;
            this.Left = location.X;
            this.Size = new Size(1400, 1100);
            this.WindowState = FormWindowState.Maximized;

            if (autoStartDataloggingReview)
                Btn_RunDatalogReview_Click(null, EventArgs.Empty);

            if (autoStartLiveTelemetry)
                Btn_RunLiveTelemetry_Click(null, EventArgs.Empty);
        }
    }

    private void Btn_RunDatalogReview_Click(object sender, EventArgs e)
    {
        pnl_StartForm.Hide();

        WT_DataAnalysis_DatalogReview.MainForm form = new()
        {
            MdiParent = this,
            TopLevel = false
        };
        form.FormClosed += (s, args) => pnl_StartForm.Visible = true;
        form.Show();
    }

    private void Btn_RunLiveTelemetry_Click(object sender, EventArgs e)
    {
        pnl_StartForm.Hide();

        WT_DataAnalysis_LiveTelemetry.MainForm form = new()
        {
            MdiParent = this,
            TopLevel = false
        };
        form.FormClosed += (s, args) => pnl_StartForm.Visible = true;
        form.Show();
    }

    private void CenterPanel()
    {
        pnl_Buttons.Left = (this.ClientSize.Width - pnl_Buttons.Width) / 2;
        pnl_Buttons.Top = (this.ClientSize.Height - pnl_Buttons.Height) / 4;
    }

    private void StartForm_Resize(object sender, EventArgs e)
    {
        CenterPanel();
    }
}
