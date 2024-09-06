
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

            // Debugging properties
            string debuggingFilePath = "";
            if (true)
            {
                //debuggingFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\data.csv";
                this.StartPosition = FormStartPosition.Manual;
                Screen[] screens = Screen.AllScreens;
                Point location = screens[1].Bounds.Location;
                //this.Left = location.X;
                //this.Top = 100;
                this.Left = location.X + 1300;
                this.Top = 200;
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(1200, 800);
            }

            _SettingsForm = new SettingsForm()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            _ChartForm = new ChartForm(debuggingFilePath)
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Sometimes change these based on what we're working on
            this.Load += toolStripMenuItem_ChartForm_Click;
            //this.Load += toolStripMenuItem_SettingsForm_Click;
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
                    _ChartForm.Dispose();

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

        //private void DoTheme()
        //{
        //_IsDarkTheme = !_IsDarkTheme;

        //this.BackColor = _IsDarkTheme ? Color.DimGray : default;

        //foreach (Control control in this.Controls)
        //{
        //    if (control is Chart chart)
        //    {
        //        chart.BackColor = _IsDarkTheme ? Color.Gray : default;
        //        //chart.ChartAreas[0].BackColor = _IsDarkTheme ? Color.Black : default;
        //    }
        //}
        //}
    }
}
