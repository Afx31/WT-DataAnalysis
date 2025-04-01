namespace WT_DataAnalysis;

public partial class StartForm : Form
{
    public StartForm()
    {
        InitializeComponent();
        this.IsMdiContainer = true;

        bool dev = true;

        if (dev)
        {
            this.StartPosition = FormStartPosition.Manual;
            Screen[] screens = Screen.AllScreens;
            Point location = screens[2].Bounds.Location;
            this.Left = location.X;
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
}
