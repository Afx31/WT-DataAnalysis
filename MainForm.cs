
namespace WRD_DataAnalysis
{
    public partial class MainForm : Form
    {
        //private bool _IsDarkTheme = true;
        private ChartForm _ChartForm;
        private SettingsForm _SettingsForm;

        public MainForm()
        {
            InitializeComponent();

            // Debugging
            if (true)
            {
                this.StartPosition = FormStartPosition.Manual;
                Screen[] screens = Screen.AllScreens;
                Point location = screens[1].Bounds.Location;
                this.Left = location.X;
                this.Top = 100;
                this.WindowState = FormWindowState.Maximized;
            }

            _ChartForm = new ChartForm()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            _SettingsForm = new SettingsForm()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            this.Load += toolStripMenuItem_ChartForm_Click;
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
            this._ChartForm.Hide();
            this._SettingsForm.Show();
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
