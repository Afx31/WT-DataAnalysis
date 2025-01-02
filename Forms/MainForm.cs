using WT_DataAnalysis.Forms;

namespace WT_DataAnalysis;

public partial class MainForm : Form
{
    //private bool _IsDarkTheme = true;
    private ChartForm _ChartForm;
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
    //this.Load += toolStripMenuItem_ChartForm_Click;
    //this.Load += toolStripMenuItem_SettingsForm_Click;

        if (debuggingAutoLoadFile)
        {
            string fileName = "";

            CsvData.ReadCsvData(fileName);

            _ChartForm = new ChartForm(CsvData)
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

        // Reload form
            //OpenChartForm();
            //OpenScatterPlotForm();
    }
}

    private void OpenChartForm()
{
        this._SettingsForm?.Hide();
            
        if (_ChartForm == null)
        {
                _ChartForm = new ChartForm(CsvData)
                {
                    MdiParent = this,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
        }

        this._ChartForm?.Show();
}

    private void OpenScatterPlotForm()
    {
        _ChartForm?.Hide();
        _SettingsForm?.Hide();

        if (_ScatterPlotForm != null)
            _ScatterPlotForm.Dispose();

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
        this._ChartForm?.Hide();

        _SettingsForm = new SettingsForm()
        {
            MdiParent = this,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        this._SettingsForm?.Show();
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
                        _ChartForm?.Dispose();
                        _ScatterPlotForm?.Dispose();

                        this.Text = "WillTech - Data Analysis (" + ofd_LoadFile.SafeFileName + ")";

                        if (!string.IsNullOrEmpty(ofd_LoadFile.FileName))
                            CsvData.ReadCsvData(ofd_LoadFile.FileName);

                        _ChartForm = new ChartForm(CsvData)
                        {
                            MdiParent = this,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Reload form
                        OpenChartForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error: Retrieving file to load in");
                    }
                }
                break;
            case "tsmi_ChartForm":
                OpenChartForm();
                break;
            case "tsmi_ScatterPlotForm":
                OpenScatterPlotForm();
                break;
            case "tsmi_SettingsForm":
                OpenSettingsForm();
                break;
        }
    }
}