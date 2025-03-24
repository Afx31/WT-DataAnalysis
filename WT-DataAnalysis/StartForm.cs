namespace WT_DataAnalysis;

public partial class StartForm : Form
{
    public StartForm()
    {
        InitializeComponent();
    }

    private void StartForm_Load(object sender, EventArgs e)
    {

    }

    private void Btn_RunDatalogReview_Click(object sender, EventArgs e)
    {
        WT_DataAnalysis_DatalogReview.MainForm mf = new WT_DataAnalysis_DatalogReview.MainForm();
        mf.Show();
    }

    private void Btn_RunLiveTelemetry_Click(object sender, EventArgs e)
    {
        WT_DataAnalysis_LiveTelemetry.MainForm mf = new WT_DataAnalysis_LiveTelemetry.MainForm();
        mf.Show();
    }
}
