using System.Windows.Forms.DataVisualization.Charting;

namespace WT_DataAnalysis.Forms;

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

    private void MapDataToChart()
    {
        #region Legends
        Legend mainLegend = new Legend()
        {
            Name = "mainLegend",
            LegendStyle = LegendStyle.Column,
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };
        LegendItem legendItem1 = new LegendItem()
        {
            Name = "<= 1,000",
            Color = ColorTranslator.FromHtml("#0000FF")
        };
        LegendItem legendItem2 = new LegendItem()
        {
            Name = "<= 2,000",
            Color = ColorTranslator.FromHtml("#1E90FF")
        };
        LegendItem legendItem3 = new LegendItem()
        {
            Name = "<= 3,000",
            Color = ColorTranslator.FromHtml("#00FFFF")
        };
        LegendItem legendItem4 = new LegendItem()
        {
            Name = "<= 4,000",
            Color = ColorTranslator.FromHtml("#00FF00")
        };
        LegendItem legendItem5 = new LegendItem()
        {
            Name = "<= 5,000",
            Color = ColorTranslator.FromHtml("#FFFF00") //ADFF2F
        };
        LegendItem legendItem6 = new LegendItem()
        {
            Name = "<= 6,000",
            Color = ColorTranslator.FromHtml("#FFD700")
        };
        LegendItem legendItem7 = new LegendItem()
        {
            Name = "<= 7,000",
            Color = ColorTranslator.FromHtml("#FFA500")
        };
        LegendItem legendItem8 = new LegendItem()
        {
            Name = "<= 8,000",
            Color = ColorTranslator.FromHtml("#FF4500")
        };
        LegendItem legendItem9 = new LegendItem()
        {
            Name = "<= 9,000",
            Color = ColorTranslator.FromHtml("#FF0000")
        };
        //LegendItem legendItem10 = new LegendItem()
        //{
        //    Name = "<= 10,000",
        //    Color = ColorTranslator.FromHtml("#FF0000")
        //};

        chart1.Legends.Add(mainLegend);
        chart1.Legends["mainLegend"].Font = new Font("Arial", 10);
        //chart1.Legends["mainLegend"].CustomItems.Add(legendItem10);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem9);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem8);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem7);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem6);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem5);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem4);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem3);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem2);
        chart1.Legends["mainLegend"].CustomItems.Add(legendItem1);
        #endregion

        Series series = new Series()
        {
            Name = "RPM",
            IsValueShownAsLabel = false,
            ChartArea = "ScatterPlotChartArea",
            //Color = ColorTranslator.FromHtml("#FF5722"),
            ChartType = SeriesChartType.Point,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 4,
            XValueType = ChartValueType.Double
        };

        for (int i = 0; i < _csvData.ListHertzTime.Count; i++)
        {
            series.Points.AddXY(double.Parse(_csvData.ListHertzTime[i]), _csvData.ListOilPressure[i]);

            Color colourToUse = Color.White;
            switch(double.Parse(_csvData.ListRpm[i]))
            {
                //case <= 1000:
                //    colourToUse = ColorTranslator.FromHtml("#0000FF");
                //    break;
                case <= 2000:
                    colourToUse = ColorTranslator.FromHtml("#0000FF");
                    break;
                case <= 3000:
                    colourToUse = ColorTranslator.FromHtml("#1E90FF");
                    break;
                case <= 4000:
                    colourToUse = ColorTranslator.FromHtml("#00FFFF");
                    break;
                case <= 5000:
                    colourToUse = ColorTranslator.FromHtml("#00FF00"); //ADFF2F
                    break;
                case <= 6000:
                    colourToUse = ColorTranslator.FromHtml("#FFFF00");
                    break;
                case <= 7000:
                    colourToUse = ColorTranslator.FromHtml("#FFD700");
                    break;
                case <= 8000:
                    colourToUse = ColorTranslator.FromHtml("#FFA500");
                    break;
                case <= 9000:
                    colourToUse = ColorTranslator.FromHtml("#FF4500");
                    break;
                case <= 10000:
                    colourToUse = ColorTranslator.FromHtml("#FF0000");
                    break;
            }

            series.Points[i].Color = colourToUse;
        }

        chart1.ChartAreas["ScatterPlotChartArea"].AxisY.Interval = 10;
        chart1.Series.Add(series);
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
