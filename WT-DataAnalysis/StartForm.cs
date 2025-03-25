namespace WT_DataAnalysis;

public partial class StartForm : Form
{
    public StartForm()
    {
        InitializeComponent();
        this.IsMdiContainer = true;
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
