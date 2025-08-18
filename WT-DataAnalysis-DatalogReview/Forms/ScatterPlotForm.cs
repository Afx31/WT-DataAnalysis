using System.Windows.Forms.DataVisualization.Charting;
using WT_DataAnalysis_DatalogReview.Models;

namespace WT_DataAnalysis_DatalogReview;

public partial class ScatterPlotForm : Form
{
    private readonly CsvData _csvData;

    public ScatterPlotForm(CsvData csvData)
    {
        InitializeComponent();

        if (csvData != null)
        {
            _csvData = csvData;
            ChartSetup();
            MapDataToChart();
        }
    }

    private void ChartSetup()
    {
        ChartArea chartArea1 = new ChartArea();
        chartArea1.Name = "ScatterPlotChartArea";
        chartArea1.AxisX.MajorTickMark.Enabled = true;
        chartArea1.AxisX.MinorTickMark.Enabled = true;
        chartArea1.AxisX.MajorTickMark.Size = 0.5f;
        chartArea1.AxisX.MinorTickMark.Size = 0.2f;
        //chartArea1.Position = new ElementPosition(0, 0, 40, 40);
        chartArea1.AxisX.LabelStyle.Format = "0.0";
        chartArea1.AxisX.Minimum = 0;

        // Additional:
        chartArea1.BackColor = ColorTranslator.FromHtml("#1E1E1E");
        chartArea1.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333"); // Originally #333333
        chartArea1.AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
        chartArea1.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea1.AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea1.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
        chartArea1.AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea1.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
        chartArea1.AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
        chartArea1.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea1.AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
        chartArea1.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
        chartArea1.AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
        
        chartArea1.AxisY.Title = "Oil Pressure";
        chartArea1.AxisY.TextOrientation = TextOrientation.Stacked;
        chartArea1.AxisY.TitleFont = new Font("Arial", 18);

        // Zoomable
        chartArea1.AxisX.ScaleView.Zoomable = true;
        chartArea1.AxisY.ScaleView.Zoomable = true;
        
        chart1.ChartAreas.Add(chartArea1);
    }

    private void BuildScatterPlotChart(string chartName, List<double> xAxis, List<double> yAxis, List<double> zAxis, string[] values)
    {
        #region Legends
        Legend mainLegend = new()
        {
            Name = "mainLegend",
            LegendStyle = LegendStyle.Column,
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };
        chart1.Legends.Add(mainLegend);
        chart1.Legends["mainLegend"].Font = new Font("Arial", 10);

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
                Name = "<= " + values[i],
                Color = GetMyScatterPlotColour(i)
            };
            chart1.Legends["mainLegend"].CustomItems.Add(li);
        }
        #endregion

        #region DataPoints
        Series series = new()
        {
            Name = chartName,
            IsValueShownAsLabel = false,
            ChartArea = "ScatterPlotChartArea",
            //Color = ColorTranslator.FromHtml("#FF5722"),
            ChartType = SeriesChartType.Point,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 4,
            XValueType = ChartValueType.Double
        };

        #region Convert these first so we're not doing it constantly throughout the loop
        double val1 = Convert.ToDouble(values[0]);
        double val2 = Convert.ToDouble(values[1]);
        double val3 = Convert.ToDouble(values[2]);
        double val4 = Convert.ToDouble(values[3]);
        double val5 = Convert.ToDouble(values[4]);
        double val6 = Convert.ToDouble(values[5]);
        double val7 = Convert.ToDouble(values[6]);
        double val8 = Convert.ToDouble(values[7]);
        double val9 = Convert.ToDouble(values[8]);
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

        chart1.ChartAreas["ScatterPlotChartArea"].AxisY.Interval = 10;
        chart1.Series.Add(series);
        #endregion
    }

    private void MapDataToChart()
    {
        // RPM | Oil Pressure | Oil Temp
        string[] str1 = { "20", "40", "60", "70", "80", "90", "110", "120", "140" };
        BuildScatterPlotChart("Oil reee", _csvData.ListRpm, _csvData.ListAnalog1, _csvData.ListAnalog0, str1);

        string[] str2 = { "1000", "2000", "3000", "4000", "5000", "6000", "7000", "8000", "9000" };
        //BuildScatterPlotChart("RPM", _csvData.ListHertzTime, _csvData.ListAnalog0, _csvData.ListRpm, str2);
    }

    private void Chart1_MouseMoveOrClick(object sender, MouseEventArgs e)
    {
        if (chart1 != null && e.X > 0)
        {
            ChartArea ca = chart1.ChartAreas[0];

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
