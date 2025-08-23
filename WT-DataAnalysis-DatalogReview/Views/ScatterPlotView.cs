using System.Windows.Forms.DataVisualization.Charting;
using WT_DataAnalysis_DatalogReview.Models;

namespace WT_DataAnalysis_DatalogReview.Views;

public partial class ScatterPlotView : UserControl
{
    private CsvData _csvData;
    public ScatterPlotView(CsvData csvData)
    {
        _csvData = csvData;
        InitializeComponent();
        ScatterPlotSetup();
    }

    private void ScatterPlotSetup()
    {
        TableLayoutPanel tableLayout = new()
        {
            Name = "ScatterPlotTableLayout",
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 2
        };
        // Make rows and columns evenly sized
        for (int i = 0; i < 2; i++)
        {
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        }
        this.Controls.Add(tableLayout);


        string[] zAxisValues1 = { "20", "40", "60", "70", "80", "90", "110", "120", "140" };
        ChartSetup([1, 0, 0], "Oil Pressure Behavior Across RPM with Temperature Influence",
                    ["RPM", "Oil Pressure", "Oil Temp"], _csvData.ListRpm, _csvData.ListAnalog1, _csvData.ListAnalog0, zAxisValues1);

        string[] zAxisValues2 = { "1000", "2000", "3000", "4000", "5000", "6000", "7000", "8000", "9000" };
        ChartSetup([2, 1, 0], "Oil Temperature Rise Over Time with Engine Load Context",
                    ["Hertz", "Oil Temp", "RPM"], _csvData.ListHertzTime, _csvData.ListAnalog0, _csvData.ListRpm, zAxisValues2);

        string[] zAxisValues3 = { "20", "40", "60", "70", "80", "90", "110", "120", "140" };
        ChartSetup([3, 0, 1], "Engine Cooling Response Across RPM",
                    ["RPM", "ECT", "Oil Temp"], _csvData.ListRpm, _csvData.ListECT, _csvData.ListAnalog0, zAxisValues3);

        string[] zAxisValues4 = { "10", "20", "30", "40", "50", "60", "70", "80", "90" };
        ChartSetup([4, 1, 1], "Throttle Application vs RPM with Oil Pressure Monitoring",
                    ["RPM", "TPS", "Oil Pressure"], _csvData.ListRpm, _csvData.ListTPS, _csvData.ListAnalog1, zAxisValues4);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tlpGrid">[0] == Chart Number || [1] == Column Number || [2] == Row Number</param>
    /// <param name="chartName"></param>
    /// <param name="axisTitles">[0] == xAxis || [1] == yAxis || [2] == zAxis</param>
    /// <param name="xAxis"></param>
    /// <param name="yAxis"></param>
    /// <param name="zAxis"></param>
    /// <param name="zAxisValues"></param>
    private void ChartSetup(int[] tlpGrid, string chartName, string[] axisTitles, List<double> xAxis, List<double> yAxis, List<double> zAxis, string[] zAxisValues)
    {
        #region Chart
        Chart chart = new()
        {
            Name = "chart_" + tlpGrid[0],
            BackColor = Color.FromArgb(0, 10, 15),
            BorderlineColor = Color.FromArgb(45, 45, 45),
            Location = new Point(0, 0),
            Margin = new Padding(0),
            Size = new Size(1075, 450),
            TabIndex = 0,
            Dock = DockStyle.Fill
        };
        chart.Titles.Add(chartName);
        chart.Titles[0].Font = new Font("Arial", 18);
        chart.Titles[0].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        chart.MouseMove += Chart_MouseMoveOrClick;
        #endregion

        #region Chart Area
        ChartArea chartArea = new();
        chartArea.Name = "ScatterPlotChartArea";
        chartArea.AxisX.MajorTickMark.Enabled = true;
        chartArea.AxisX.MinorTickMark.Enabled = true;
        chartArea.AxisX.MajorTickMark.Size = 0.5f;
        chartArea.AxisX.MinorTickMark.Size = 0.2f;
        //chartArea.Position = new ElementPosition(0, 0, 40, 40);
        chartArea.AxisX.LabelStyle.Format = "0.0";
        chartArea.AxisX.Minimum = 0;

        // Additional:
        chartArea.BackColor = ColorTranslator.FromHtml("#1E1E1E");
        chartArea.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333"); // Originally #333333
        chartArea.AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
        chartArea.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea.AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
        chartArea.AxisX.Title = axisTitles[0];
        chartArea.AxisX.TitleFont = new Font("Arial", 12);
        chartArea.AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

        chartArea.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
        chartArea.AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
        chartArea.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea.AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
        chartArea.AxisY.Title = axisTitles[1];
        chartArea.AxisY.TitleFont = new Font("Arial", 12);
        chartArea.AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea.AxisY.TextOrientation = TextOrientation.Stacked;

        // Zoomable
        chartArea.AxisX.ScaleView.Zoomable = true;
        chartArea.AxisY.ScaleView.Zoomable = true;

        chart.ChartAreas.Add(chartArea);
        #endregion

        BuildScatterPlotDataStructure(chart, xAxis, yAxis, zAxis, axisTitles[2], zAxisValues);

        TableLayoutPanel tlp = this.Controls["ScatterPlotTableLayout"] as TableLayoutPanel;
        tlp.Controls.Add(chart, tlpGrid[1], tlpGrid[2]);
    }

    private void BuildScatterPlotDataStructure(Chart chart, List<double> xAxis, List<double> yAxis, List<double> zAxis, string zAxisTitle, string[] zAxisValues)
    {
        #region Legends
        Legend mainLegend = new()
        {
            Name = "mainLegend",
            LegendStyle = LegendStyle.Column,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            Font = new Font("Arial", 10)
        };
        chart.Legends.Add(mainLegend);

        static Color GetMyScatterPlotColour(int i)
        {
            switch (i)
            {
                case 0:
                    return ColorTranslator.FromHtml("#0000FF");
                case 1:
                    return ColorTranslator.FromHtml("#1E90FF");
                case 2:
                    return ColorTranslator.FromHtml("#00FFFF");
                case 3:
                    return ColorTranslator.FromHtml("#00FF00");
                case 4:
                    return ColorTranslator.FromHtml("#FFFF00"); //ADFF2F;
                case 5:
                    return ColorTranslator.FromHtml("#FFD700");
                case 6:
                    return ColorTranslator.FromHtml("#FFA500");
                case 7:
                    return ColorTranslator.FromHtml("#FF4500");
                case 8:
                    return ColorTranslator.FromHtml("#FF0000");
                default:
                    return Color.White;
            }
        }

        for (int i = 8; i >= 0; i--)
        {
            LegendItem li = new()
            {
                Name = "<= " + zAxisValues[i],
                Color = GetMyScatterPlotColour(i)
            };
            chart.Legends["mainLegend"].CustomItems.Add(li);
        }
        #endregion

        #region DataPoints
        Series series = new()
        {
            Name = zAxisTitle,
            IsValueShownAsLabel = false,
            ChartArea = "ScatterPlotChartArea",
            //Color = ColorTranslator.FromHtml("#FF5722"),
            ChartType = SeriesChartType.Point,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 4,
            XValueType = ChartValueType.Double
        };

        #region Convert these first so we're not doing it constantly throughout the loop
        double val1 = Convert.ToDouble(zAxisValues[0]);
        double val2 = Convert.ToDouble(zAxisValues[1]);
        double val3 = Convert.ToDouble(zAxisValues[2]);
        double val4 = Convert.ToDouble(zAxisValues[3]);
        double val5 = Convert.ToDouble(zAxisValues[4]);
        double val6 = Convert.ToDouble(zAxisValues[5]);
        double val7 = Convert.ToDouble(zAxisValues[6]);
        double val8 = Convert.ToDouble(zAxisValues[7]);
        double val9 = Convert.ToDouble(zAxisValues[8]);
        #endregion

        for (int i = 0; i < xAxis.Count; i++)
        {
            series.Points.AddXY(xAxis[i], yAxis[i]);

            Color colourToUse = Color.White;
            if (zAxis[i] >= val9)
                colourToUse = GetMyScatterPlotColour(8);
            else if (zAxis[i] >= val8)
                colourToUse = GetMyScatterPlotColour(7);
            else if (zAxis[i] >= val7)
                colourToUse = GetMyScatterPlotColour(6);
            else if (zAxis[i] >= val6)
                colourToUse = GetMyScatterPlotColour(5);
            else if (zAxis[i] >= val5)
                colourToUse = GetMyScatterPlotColour(4);
            else if (zAxis[i] >= val4)
                colourToUse = GetMyScatterPlotColour(3);
            else if (zAxis[i] >= val3)
                colourToUse = GetMyScatterPlotColour(2);
            else if (zAxis[i] >= val2)
                colourToUse = GetMyScatterPlotColour(1);
            else if (zAxis[i] >= val1)
                colourToUse = GetMyScatterPlotColour(0);

            series.Points[i].Color = colourToUse;
        }

        chart.ChartAreas["ScatterPlotChartArea"].AxisY.Interval = 10;
        chart.Series.Add(series);
        #endregion
    }

    private void Chart_MouseMoveOrClick(object sender, MouseEventArgs e)
    {
        Chart chart = sender as Chart;
        if (chart == null) return;

        if (chart != null && e.X > 0)
        {
            ChartArea ca = chart.ChartAreas[0];

            if (ca.AxisX.StripLines.Count > 0)
                ca.AxisX.StripLines.RemoveAt(0);
            if (ca.AxisY.StripLines.Count > 0)
                ca.AxisY.StripLines.RemoveAt(0);

            double xValue = ca.AxisX.PixelPositionToValue(e.X);
            double yValue = ca.AxisY.PixelPositionToValue(e.Y);

            ca.AxisX.StripLines.Add(new StripLine()
            {
                IntervalOffset = xValue,
                StripWidth = 0,
                BorderColor = Color.Yellow,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Solid
            });

            ca.AxisY.StripLines.Add(new StripLine()
            {
                IntervalOffset = yValue,
                StripWidth = 0,
                BorderColor = Color.Yellow,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Solid
            });
        }
    }
}
