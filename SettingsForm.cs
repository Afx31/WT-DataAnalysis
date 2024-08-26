﻿
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
            cbx_DataPoint1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            cbx_DataPoint2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            cbx_DataPoint3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            cbx_DataPoint4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
            cbx_LineColour1.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
            cbx_LineColour2.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
            cbx_LineColour3.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
            cbx_LineColour4.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));

            if (AppSettings.Chart1DataPoints.Any())
            {
                cbx_DataPoint1.SelectedIndex = AppSettings.Chart1DataPoints[0].DataPoint - 1;
                cbx_DataPoint2.SelectedIndex = AppSettings.Chart2DataPoints[0].DataPoint - 1;
                cbx_DataPoint3.SelectedIndex = AppSettings.Chart3DataPoints[0].DataPoint - 1;
                cbx_DataPoint4.SelectedIndex = AppSettings.Chart4DataPoints[0].DataPoint - 1;

                cbx_LineColour1.SelectedIndex = AppSettings.Chart1DataPoints[0].LineColour - 1;
                cbx_LineColour2.SelectedIndex = AppSettings.Chart2DataPoints[0].LineColour - 1;
                cbx_LineColour3.SelectedIndex = AppSettings.Chart3DataPoints[0].LineColour - 1;
                cbx_LineColour4.SelectedIndex = AppSettings.Chart4DataPoints[0].LineColour - 1;
            }
            #endregion
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (AppSettings.Chart1DataPoints.Count != 0)
            {
                AppSettings.Chart1DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_DataPoint1.SelectedItem;
                AppSettings.Chart1DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour1.SelectedItem;
            }
            else
            {
                ChartDataConfig chartDataConfig = new ChartDataConfig()
                {
                    DataPoint = (int)(CsvData.DataValues)cbx_DataPoint1.SelectedItem,
                    LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour1.SelectedItem
                };
                AppSettings.Chart1DataPoints.Add(chartDataConfig);
            }

            if (AppSettings.Chart2DataPoints.Count != 0)
            {
                AppSettings.Chart2DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_DataPoint2.SelectedItem;
                AppSettings.Chart2DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour2.SelectedItem;
            }
            else
            {
                ChartDataConfig chartDataConfig = new ChartDataConfig()
                {
                    DataPoint = (int)(CsvData.DataValues)cbx_DataPoint2.SelectedItem,
                    LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour2.SelectedItem
                };
                AppSettings.Chart2DataPoints.Add(chartDataConfig);
            }

            if (AppSettings.Chart3DataPoints.Count != 0)
            {
                AppSettings.Chart3DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_DataPoint3.SelectedItem;
                AppSettings.Chart3DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour3.SelectedItem;
            }
            else
            {
                ChartDataConfig chartDataConfig = new ChartDataConfig()
                {
                    DataPoint = (int)(CsvData.DataValues)cbx_DataPoint3.SelectedItem,
                    LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour3.SelectedItem
                };
                AppSettings.Chart3DataPoints.Add(chartDataConfig);
            }

            if (AppSettings.Chart4DataPoints.Count != 0)
            {
                AppSettings.Chart4DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_DataPoint4.SelectedItem;
                AppSettings.Chart4DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour4.SelectedItem;
            }
            else
            {
                ChartDataConfig chartDataConfig = new ChartDataConfig()
                {
                    DataPoint = (int)(CsvData.DataValues)cbx_DataPoint4.SelectedItem,
                    LineColour = (int)(ChartDataConfig.Colours)cbx_LineColour4.SelectedItem
                };
                AppSettings.Chart4DataPoints.Add(chartDataConfig);
            }
        }
    }
}
