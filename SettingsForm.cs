
namespace WRD_DataAnalysis
{
    public partial class SettingsForm : Form
    {
        AppSettings AppSettings = AppSettings.Instance;

        public SettingsForm()
        {
            InitializeComponent();
            FormLogic();
        }

        public void FormLogic()
        {
            #region Combo Box's
            comboBox1.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged -= comboBox_SelectedIndexChanged;

            comboBox1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));

            comboBox1.SelectedIndex = AppSettings.Chart1DataPoint;
            comboBox2.SelectedIndex = AppSettings.Chart2DataPoint;
            comboBox3.SelectedIndex = AppSettings.Chart3DataPoint;
            comboBox4.SelectedIndex = AppSettings.Chart4DataPoint;

            comboBox1.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            #endregion
            }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox currentComboBox)
            {
                if (currentComboBox == comboBox1)
                {
                    AppSettings.Chart1DataPoint = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                }
                else if (currentComboBox == comboBox2)
                {
                    AppSettings.Chart2DataPoint = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                }
                else if (currentComboBox == comboBox3)
                {
                    AppSettings.Chart3DataPoint = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                }
                else if (currentComboBox == comboBox4)
                {
                    AppSettings.Chart4DataPoint = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                }
            }
        }
    }
}
