using WT_DataAnalysis_DatalogReview;

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

    private void btn_RunDatalogReview_Click(object sender, EventArgs e)
    {
        MainForm mf = new MainForm();
        mf.Show();
    }

    private void btn_RunLiveTelemetry_Click(object sender, EventArgs e)
    {

    }
}
