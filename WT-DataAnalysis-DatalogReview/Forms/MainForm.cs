using WT_DataAnalysis_DatalogReview.Models;

namespace WT_DataAnalysis_DatalogReview;

public partial class MainForm : Form
{
    //private bool _IsDarkTheme = true;
    private DatalogReviewForm _DatalogReviewForm;
    private ScatterPlotForm _ScatterPlotForm;
    private SettingsForm _SettingsForm;
    public CsvData CsvData;

public MainForm()
{
    InitializeComponent();

    // ----- Debugging properties -----
    // debuggingMode set to false means it'll open on default screen 1
    bool debuggingMode = true;
    bool debuggingAutoLoadFile = false;

    if (debuggingMode)
    {
        this.StartPosition = FormStartPosition.Manual;
        Screen[] screens = Screen.AllScreens;
        Point location = screens[0].Bounds.Location;
        this.Left = location.X;
    }

        this.WindowState = FormWindowState.Maximized;
        CsvData = new CsvData();

    // Sometimes change these based on what we're working on
    //this.Load += toolStripMenuItem_DatalogReviewForm_Click;
    //this.Load += toolStripMenuItem_SettingsForm_Click;

        if (debuggingAutoLoadFile)
        {
            string fileName = "";

            CsvData.ReadCsvData(fileName);
            SetupLapCountComboBox();

            _DatalogReviewForm = new DatalogReviewForm(CsvData)
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

        // Reload form
            OpenDatalogReviewForm();
            //OpenScatterPlotForm();
    }
}

    private void SetupLapCountComboBox()
    {
        int maxLaps = CsvData.DictLapData.Count;
        for (int i = 0; i < maxLaps; i++)
        {
            string item = "";

            if (i == 0)
                item = "Out Lap";
            else if (i == maxLaps - 1)
                item = "In Lap";
            else
                item = "Lap " + i.ToString();
            
            tsmi_LapSelector.Items.Add(item);
        }
    }

    private void OpenDatalogReviewForm()
{
        _SettingsForm?.Hide();
            
        if (_DatalogReviewForm == null)
        {
                _DatalogReviewForm = new DatalogReviewForm(CsvData)
                {
                    MdiParent = this,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
        }

        _DatalogReviewForm?.Show();
}

    private void OpenScatterPlotForm()
    {
        _DatalogReviewForm?.Hide();
        _SettingsForm?.Hide();
        _ScatterPlotForm?.Dispose();

            _ScatterPlotForm = new ScatterPlotForm(CsvData)
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

        _ScatterPlotForm.Show();
    }

    private void OpenSettingsForm()
    {
        _DatalogReviewForm?.Hide();

        _SettingsForm = new SettingsForm()
        {
            MdiParent = this,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        _SettingsForm?.Show();
    }

private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
{
    //base.OnFormClosing(e);
    //AppSettings.SaveSettings();
}

    private void toolStripMenuItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

        switch (menuItem?.Name)
        {
            case "tsmi_LoadFile":
                if (ofd_LoadFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // First dispose of any existing CSV data
                        if (CsvData != null)
                            CsvData = new CsvData();

                        // Try read CSV file to confirm it's valid
                        using (var sr = new StreamReader(ofd_LoadFile.FileName))
                            sr.ReadToEnd();

                        // Remove current instance
                        _DatalogReviewForm?.Dispose();
                        _ScatterPlotForm?.Dispose();

                        Text = "WillTech - Data Analysis (" + ofd_LoadFile.SafeFileName + ")";

                        if (!string.IsNullOrEmpty(ofd_LoadFile.FileName))
                        {
                            CsvData.ReadCsvData(ofd_LoadFile.FileName);
                            SetupLapCountComboBox();
                        }

                        _DatalogReviewForm = new DatalogReviewForm(CsvData)
                        {
                            MdiParent = this,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Reload form
                        OpenDatalogReviewForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error: Retrieving file to load in");
                    }
                }
                break;
            case "tsmi_DatalogReviewForm":
                OpenDatalogReviewForm();
                break;
            case "tsmi_ScatterPlotForm":
                OpenScatterPlotForm();
                break;
            case "tsmi_SettingsForm":
                OpenSettingsForm();
                break;
        }
    }

    private void tsmi_LapSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedLap = 0;
        if (tsmi_LapSelector.SelectedItem != "All Laps")
            selectedLap = tsmi_LapSelector.Items.IndexOf(tsmi_LapSelector.SelectedItem) - 1;
        else
            selectedLap = 9999; // TODO: Hacky, fix one decade

        _DatalogReviewForm.MapDataPointsToChart(selectedLap);
    }
}