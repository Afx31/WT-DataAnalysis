
namespace WT_DataAnalysis
{
    public partial class MainForm : Form
    {
        //private bool _IsDarkTheme = true;
        private ChartForm _ChartForm;
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
                OpenChartForm();
            }
        }

        private void toolStripMenuItem_LoadFile_Click(object sender, EventArgs e)
        {
            if (ofd_LoadFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Try read CSV file to confirm it's valid
                    using (var sr = new StreamReader(ofd_LoadFile.FileName))
                        sr.ReadToEnd();
                    
                    // Remove current instance
                    _ChartForm?.Dispose();

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
        }

        private void toolStripMenuItem_ChartForm_Click(object sender, EventArgs e)
        {
            OpenChartForm();
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

        private void toolStripMenuItem_SettingsForm_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
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
    }
}
