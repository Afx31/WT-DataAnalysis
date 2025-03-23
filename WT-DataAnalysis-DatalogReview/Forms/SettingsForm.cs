using WT_DataAnalysis_DatalogReview.Models;

namespace WT_DataAnalysis_DatalogReview;

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
        #region Chart Data Points
        cbx_Chart1DataPoint1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart1DataPoint2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart1DataPoint3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart1DataPoint4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart2DataPoint1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart2DataPoint2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart2DataPoint3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart2DataPoint4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart3DataPoint1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart3DataPoint2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart3DataPoint3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart3DataPoint4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart4DataPoint1.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart4DataPoint2.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart4DataPoint3.DataSource = Enum.GetValues(typeof(CsvData.DataValues));
        cbx_Chart4DataPoint4.DataSource = Enum.GetValues(typeof(CsvData.DataValues));

        cbx_Chart1LineColour1.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart1LineColour2.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart1LineColour3.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart1LineColour4.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart2LineColour1.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart2LineColour2.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart2LineColour3.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart2LineColour4.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart3LineColour1.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart3LineColour2.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart3LineColour3.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart3LineColour4.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart4LineColour1.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart4LineColour2.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart4LineColour3.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));
        cbx_Chart4LineColour4.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));

        if (AppSettings.Chart1DataPoints.Count != 0)
        {
            cbx_Chart1DataPoint1.SelectedIndex = AppSettings.Chart1DataPoints[0].DataPoint;
            cbx_Chart1DataPoint2.SelectedIndex = AppSettings.Chart1DataPoints[1].DataPoint;
            cbx_Chart1DataPoint3.SelectedIndex = AppSettings.Chart1DataPoints[2].DataPoint;
            cbx_Chart1DataPoint4.SelectedIndex = AppSettings.Chart1DataPoints[3].DataPoint;
            cbx_Chart2DataPoint1.SelectedIndex = AppSettings.Chart2DataPoints[0].DataPoint;
            cbx_Chart2DataPoint2.SelectedIndex = AppSettings.Chart2DataPoints[1].DataPoint;
            cbx_Chart2DataPoint3.SelectedIndex = AppSettings.Chart2DataPoints[2].DataPoint;
            cbx_Chart2DataPoint4.SelectedIndex = AppSettings.Chart2DataPoints[3].DataPoint;
            cbx_Chart3DataPoint1.SelectedIndex = AppSettings.Chart3DataPoints[0].DataPoint;
            cbx_Chart3DataPoint2.SelectedIndex = AppSettings.Chart3DataPoints[1].DataPoint;
            cbx_Chart3DataPoint3.SelectedIndex = AppSettings.Chart3DataPoints[2].DataPoint;
            cbx_Chart3DataPoint4.SelectedIndex = AppSettings.Chart3DataPoints[3].DataPoint;
            cbx_Chart4DataPoint1.SelectedIndex = AppSettings.Chart4DataPoints[0].DataPoint;
            cbx_Chart4DataPoint2.SelectedIndex = AppSettings.Chart4DataPoints[1].DataPoint;
            cbx_Chart4DataPoint3.SelectedIndex = AppSettings.Chart4DataPoints[2].DataPoint;
            cbx_Chart4DataPoint4.SelectedIndex = AppSettings.Chart4DataPoints[3].DataPoint;

            cbx_Chart1LineColour1.SelectedIndex = AppSettings.Chart1DataPoints[0].LineColour;
            cbx_Chart1LineColour2.SelectedIndex = AppSettings.Chart1DataPoints[1].LineColour;
            cbx_Chart1LineColour3.SelectedIndex = AppSettings.Chart1DataPoints[2].LineColour;
            cbx_Chart1LineColour4.SelectedIndex = AppSettings.Chart1DataPoints[3].LineColour;
            cbx_Chart2LineColour1.SelectedIndex = AppSettings.Chart2DataPoints[0].LineColour;
            cbx_Chart2LineColour2.SelectedIndex = AppSettings.Chart2DataPoints[1].LineColour;
            cbx_Chart2LineColour3.SelectedIndex = AppSettings.Chart2DataPoints[2].LineColour;
            cbx_Chart2LineColour4.SelectedIndex = AppSettings.Chart2DataPoints[3].LineColour;
            cbx_Chart3LineColour1.SelectedIndex = AppSettings.Chart3DataPoints[0].LineColour;
            cbx_Chart3LineColour2.SelectedIndex = AppSettings.Chart3DataPoints[1].LineColour;
            cbx_Chart3LineColour3.SelectedIndex = AppSettings.Chart3DataPoints[2].LineColour;
            cbx_Chart3LineColour4.SelectedIndex = AppSettings.Chart3DataPoints[3].LineColour;
            cbx_Chart4LineColour1.SelectedIndex = AppSettings.Chart4DataPoints[0].LineColour;
            cbx_Chart4LineColour2.SelectedIndex = AppSettings.Chart4DataPoints[1].LineColour;
            cbx_Chart4LineColour3.SelectedIndex = AppSettings.Chart4DataPoints[2].LineColour;
            cbx_Chart4LineColour4.SelectedIndex = AppSettings.Chart4DataPoints[3].LineColour;
        }
        #endregion

        #region Misc
        cbx_CursorLineColour.DataSource = Enum.GetValues(typeof(ChartDataConfig.Colours));

        if (AppSettings.CursorLineColour != null)
            cbx_CursorLineColour.SelectedIndex = AppSettings.CursorLineColour;

        if (AppSettings.AutoCursorLine != null)
            chk_AutoCursorLine.Checked = AppSettings.AutoCursorLine;
        #endregion
    }

    private void btn_SaveSettings_Click(object sender, EventArgs e)
    {
        #region Chart Data Points
        #region Chart 1
        if (AppSettings.Chart1DataPoints.Count == 4)
        {
            AppSettings.Chart1DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint1.SelectedItem;
            AppSettings.Chart1DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour1.SelectedItem;

            AppSettings.Chart1DataPoints[1].DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint2.SelectedItem;
            AppSettings.Chart1DataPoints[1].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour2.SelectedItem;

            AppSettings.Chart1DataPoints[2].DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint3.SelectedItem;
            AppSettings.Chart1DataPoints[2].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour3.SelectedItem;

            AppSettings.Chart1DataPoints[3].DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint4.SelectedItem;
            AppSettings.Chart1DataPoints[3].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour4.SelectedItem;
        }
        else
        {
            ChartDataConfig chartDataConfig1 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint1.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour1.SelectedItem
            };
            ChartDataConfig chartDataConfig2 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint2.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour2.SelectedItem
            };
            ChartDataConfig chartDataConfig3 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint3.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour3.SelectedItem
            };
            ChartDataConfig chartDataConfig4 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart1DataPoint4.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart1LineColour4.SelectedItem
            };
            AppSettings.Chart1DataPoints.Add(chartDataConfig1);
            AppSettings.Chart1DataPoints.Add(chartDataConfig2);
            AppSettings.Chart1DataPoints.Add(chartDataConfig3);
            AppSettings.Chart1DataPoints.Add(chartDataConfig4);
        }
        #endregion

        #region Chart 2
        if (AppSettings.Chart2DataPoints.Count == 4)
        {
            AppSettings.Chart2DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint1.SelectedItem;
            AppSettings.Chart2DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour1.SelectedItem;

            AppSettings.Chart2DataPoints[1].DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint2.SelectedItem;
            AppSettings.Chart2DataPoints[1].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour2.SelectedItem;

            AppSettings.Chart2DataPoints[2].DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint3.SelectedItem;
            AppSettings.Chart2DataPoints[2].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour3.SelectedItem;

            AppSettings.Chart2DataPoints[3].DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint4.SelectedItem;
            AppSettings.Chart2DataPoints[3].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour4.SelectedItem;
        }
        else
        {
            ChartDataConfig chartDataConfig1 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint1.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour1.SelectedItem
            };
            ChartDataConfig chartDataConfig2 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint2.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour2.SelectedItem
            };
            ChartDataConfig chartDataConfig3 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint3.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour3.SelectedItem
            };
            ChartDataConfig chartDataConfig4 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart2DataPoint4.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart2LineColour4.SelectedItem
            };
            AppSettings.Chart2DataPoints.Add(chartDataConfig1);
            AppSettings.Chart2DataPoints.Add(chartDataConfig2);
            AppSettings.Chart2DataPoints.Add(chartDataConfig3);
            AppSettings.Chart2DataPoints.Add(chartDataConfig4);
        }
        #endregion

        #region Chart 3
        if (AppSettings.Chart3DataPoints.Count == 4)
        {
            AppSettings.Chart3DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint1.SelectedItem;
            AppSettings.Chart3DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour1.SelectedItem;

            AppSettings.Chart3DataPoints[1].DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint2.SelectedItem;
            AppSettings.Chart3DataPoints[1].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour2.SelectedItem;

            AppSettings.Chart3DataPoints[2].DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint3.SelectedItem;
            AppSettings.Chart3DataPoints[2].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour3.SelectedItem;

            AppSettings.Chart3DataPoints[3].DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint4.SelectedItem;
            AppSettings.Chart3DataPoints[3].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour4.SelectedItem;
        }
        else
        {
            ChartDataConfig chartDataConfig1 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint1.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour1.SelectedItem
            };
            ChartDataConfig chartDataConfig2 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint2.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour2.SelectedItem
            };
            ChartDataConfig chartDataConfig3 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint3.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour3.SelectedItem
            };
            ChartDataConfig chartDataConfig4 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart3DataPoint4.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart3LineColour4.SelectedItem
            };
            AppSettings.Chart3DataPoints.Add(chartDataConfig1);
            AppSettings.Chart3DataPoints.Add(chartDataConfig2);
            AppSettings.Chart3DataPoints.Add(chartDataConfig3);
            AppSettings.Chart3DataPoints.Add(chartDataConfig4);
        }
        #endregion

        #region Chart 4
        if (AppSettings.Chart4DataPoints.Count == 4)
        {
            AppSettings.Chart4DataPoints[0].DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint1.SelectedItem;
            AppSettings.Chart4DataPoints[0].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour1.SelectedItem;

            AppSettings.Chart4DataPoints[1].DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint2.SelectedItem;
            AppSettings.Chart4DataPoints[1].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour2.SelectedItem;

            AppSettings.Chart4DataPoints[2].DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint3.SelectedItem;
            AppSettings.Chart4DataPoints[2].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour3.SelectedItem;

            AppSettings.Chart4DataPoints[3].DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint4.SelectedItem;
            AppSettings.Chart4DataPoints[3].LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour4.SelectedItem;
        }
        else
        {
            ChartDataConfig chartDataConfig1 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint1.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour1.SelectedItem
            };
            ChartDataConfig chartDataConfig2 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint2.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour2.SelectedItem
            };
            ChartDataConfig chartDataConfig3 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint3.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour3.SelectedItem
            };
            ChartDataConfig chartDataConfig4 = new ChartDataConfig()
            {
                DataPoint = (int)(CsvData.DataValues)cbx_Chart4DataPoint4.SelectedItem,
                LineColour = (int)(ChartDataConfig.Colours)cbx_Chart4LineColour4.SelectedItem
            };
            AppSettings.Chart4DataPoints.Add(chartDataConfig1);
            AppSettings.Chart4DataPoints.Add(chartDataConfig2);
            AppSettings.Chart4DataPoints.Add(chartDataConfig3);
            AppSettings.Chart4DataPoints.Add(chartDataConfig4);
        }
        #endregion
        #endregion

        // Misc
        AppSettings.CursorLineColour = (int)(ChartDataConfig.Colours)cbx_CursorLineColour.SelectedItem;
        AppSettings.AutoCursorLine = chk_AutoCursorLine.Checked;

        AppSettings.SaveSettings();
    }

    private void btn_ReloadApplication_Click(object sender, EventArgs e)
    {
        // Save again juuust in case
        AppSettings.SaveSettings();
        Application.Restart();
    }
}
