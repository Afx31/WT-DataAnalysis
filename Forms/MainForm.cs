
namespace WT_DataAnalysis
{
    public partial class MainForm : Form
    {
        //private bool _IsDarkTheme = true;
        private ChartForm _ChartForm;
        private SettingsForm _SettingsForm;

        public MainForm()
        {
            InitializeComponent();

            // ----- Debugging properties -----
            // debuggingMode set to false means it'll open on default screen 1
            bool debuggingMode = true;
            bool debuggingAutoLoadFile = true;

            if (debuggingMode)
            {
                this.StartPosition = FormStartPosition.Manual;
                Screen[] screens = Screen.AllScreens;
                Point location = screens[0].Bounds.Location;
                this.Left = location.X;

                debuggingAutoLoadFile = true;
            }

            this.WindowState = FormWindowState.Maximized;

            _SettingsForm = new SettingsForm()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            _ChartForm = new ChartForm("")
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Sometimes change these based on what we're working on
            //this.Load += toolStripMenuItem_ChartForm_Click;
            //this.Load += toolStripMenuItem_SettingsForm_Click;

            if (debuggingAutoLoadFile)
            {
                _ChartForm.Dispose();
                string testFileName = "";

                _ChartForm = new ChartForm(testFileName)
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

                    _ChartForm = new ChartForm(ofd_LoadFile.FileName)
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
            this._SettingsForm.Hide();
            this._ChartForm.Show();
        }

        private void toolStripMenuItem_SettingsForm_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void OpenSettingsForm()
        {
            this._ChartForm.Hide();
            this._SettingsForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //base.OnFormClosing(e);
            //AppSettings.SaveSettings();
        }
    }
}
