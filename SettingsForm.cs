
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
            //comboBox5.SelectedIndexChanged -= comboBox_SelectedIndexChanged;

            comboBox1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            comboBox4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            //comboBox5.DataSource = Enum.GetValues(typeof(CsvData.DataValues));

            if (AppSettings.Chart1DataPoints.Any())
            {
                comboBox1.SelectedIndex = AppSettings.Chart1DataPoints[0] - 1;
                //comboBox11.SelectedIndex = AppSettings.Chart1DataPoints[1] - 1; //test
                comboBox2.SelectedIndex = AppSettings.Chart2DataPoints[0] - 1;
                comboBox3.SelectedIndex = AppSettings.Chart3DataPoints[0] - 1;
                comboBox4.SelectedIndex = AppSettings.Chart4DataPoints[0] - 1;

                //comboBox5.SelectedIndex = AppSettings.Chart2DataPoints[1] - 1;
            }

            comboBox1.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            //comboBox5.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            #endregion
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox currentComboBox)
            {
                if (currentComboBox == comboBox1)
                {
                    if (AppSettings.Chart1DataPoints.Any())
                        AppSettings.Chart1DataPoints[0] = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                    else
                        AppSettings.Chart1DataPoints.Add((int)(CsvData.DataValues)currentComboBox.SelectedItem);
                }
                else if (currentComboBox == comboBox2)
                {
                    if (AppSettings.Chart2DataPoints.Any())
                        AppSettings.Chart2DataPoints[0] = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                    else
                        AppSettings.Chart2DataPoints.Add((int)(CsvData.DataValues)currentComboBox.SelectedItem);
                }
                else if (currentComboBox == comboBox3)
                {
                    if (AppSettings.Chart3DataPoints.Any())
                        AppSettings.Chart3DataPoints[0] = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                    else
                        AppSettings.Chart3DataPoints.Add((int)(CsvData.DataValues)currentComboBox.SelectedItem);
                }
                else if (currentComboBox == comboBox4)
                {
                    if (AppSettings.Chart4DataPoints.Any())
                        AppSettings.Chart4DataPoints[0] = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                    else
                        AppSettings.Chart4DataPoints.Add((int)(CsvData.DataValues)currentComboBox.SelectedItem);
                }

                //else if (currentComboBox == comboBox5)
                //{
                //    if (AppSettings.Chart2DataPoints.Any())
                //        AppSettings.Chart2DataPoints[1] = (int)(CsvData.DataValues)currentComboBox.SelectedItem;
                //    else
                //        AppSettings.Chart2DataPoints.Add((int)(CsvData.DataValues)currentComboBox.SelectedItem);
                //}
            }
        }
    }
}
