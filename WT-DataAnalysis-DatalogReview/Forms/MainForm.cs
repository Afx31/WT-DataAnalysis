using WT_DataAnalysis_DatalogReview.Models;
using WT_DataAnalysis_DatalogReview.Views;

namespace WT_DataAnalysis_DatalogReview;

public partial class MainForm : Form
{
    public CsvData CsvData;

    public MainForm()
    {
        InitializeComponent();
        //IsMdiContainer = true;
        this.WindowState = FormWindowState.Maximized;

        // ----- Debugging properties -----
        // debuggingMode set to false means it'll open on default screen 1
        bool debuggingMode = true;
        bool debuggingAutoLoadFile = false;
        bool debuggingAutoLoadDatalogReviewView = false;

        if (debuggingMode)
        {
            this.StartPosition = FormStartPosition.Manual;
            Screen[] screens = Screen.AllScreens;
            Point location = screens[2].Bounds.Location;
            this.Left = location.X;

            if (debuggingAutoLoadFile)
            {
                string fileName = "";

                CsvData.ReadCsvData(fileName);
                SetupLapCountComboBox();

                // Reload form
                OpenDatalogReviewForm();
                //OpenScatterPlotForm();
            }

            if (debuggingAutoLoadDatalogReviewView)
            {
                OpenDatalogReviewForm();
        }
    }
    }

    private void ShowView(UserControl view)
    {
        if (pnl_DataAnalysisBase.Controls.Count > 0)
        {
            var oldView = pnl_DataAnalysisBase.Controls[0];
            oldView.Dispose();
            pnl_DataAnalysisBase.Controls.Clear();
        }

        view.Dock = DockStyle.Fill;
        pnl_DataAnalysisBase.Controls.Add(view);
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
        if (CsvData == null)
        {
            MessageBox.Show("Please load a CSV datalog file first", "No Data Loaded", MessageBoxButtons.OK);
            return;
        }

        DatalogReviewView view = new(CsvData);
        ShowView(view);
    }

    private void OpenScatterPlotForm()
    {
        if (CsvData == null)
        {
            MessageBox.Show("Please load a CSV datalog file first", "No Data Loaded", MessageBoxButtons.OK);
            return;
        }

        ScatterPlotView view = new(CsvData);
        ShowView(view);
        }

    private void OpenSettingsForm()
    {
        SettingsView view = new();
        ShowView(view);
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
                        CsvData = new();

                        // Try read CSV file to confirm it's valid
                        using (var sr = new StreamReader(ofd_LoadFile.FileName))
                            sr.ReadToEnd();

                        Text = "WillTech - Data Analysis (" + ofd_LoadFile.SafeFileName + ")";

                        if (!string.IsNullOrEmpty(ofd_LoadFile.FileName))
                        {
                            CsvData.ReadCsvData(ofd_LoadFile.FileName);
                            SetupLapCountComboBox();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error: Retrieving file to load in");
                    }
                }                
                OpenDatalogReviewForm();
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
        // TODO:
        //int selectedLap = 0;
        //if (tsmi_LapSelector.SelectedItem != "All Laps")
        //    selectedLap = tsmi_LapSelector.Items.IndexOf(tsmi_LapSelector.SelectedItem) - 1;
        //else
        //    selectedLap = 9999; // TODO: Hacky, fix one decade

        //_DatalogReviewForm.MapDataPointsToChart(selectedLap);
    }
}