using System.Windows.Forms.DataVisualization.Charting;

namespace WT_DataAnalysis
{
    public partial class ChartForm : Form
    {
        AppSettings AppSettings = AppSettings.Instance;
        public CsvData _CsvData;

        public ChartForm(string filePath)
        {
            InitializeComponent();

            _CsvData = new CsvData();
            if (!string.IsNullOrEmpty(filePath))
            {
                _CsvData.ReadCsvData(filePath);
                InitialChartSetup();
                MapDataPointsToChart(_CsvData);
            }
        }

        private void InitialChartSetup()
        {
            #region -------------------- Chart Areas --------------------
            ChartArea chartArea1 = new ChartArea("ChartArea1");
            ChartArea chartArea2 = new ChartArea("ChartArea2");
            ChartArea chartArea3 = new ChartArea("ChartArea3");
            ChartArea chartArea4 = new ChartArea("ChartArea4");

            // Align the chart areas with the last one
            chartArea1.AlignWithChartArea = "ChartArea4";
            chartArea2.AlignWithChartArea = "ChartArea4";
            chartArea3.AlignWithChartArea = "ChartArea4";

            // Hide the X-axis labels for the first two chart areas
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.LabelStyle.Enabled = false;

            // Tick adjustments
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MinorTickMark.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.MinorTickMark.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisX.MinorTickMark.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = true;
            chartArea4.AxisX.MinorTickMark.Enabled = true;
            chartArea4.AxisX.MajorTickMark.Size = 0.5f;
            chartArea4.AxisX.MinorTickMark.Size = 0.2f;

            // Optional: Hide the X-axis line for the first two chart areas
            chartArea1.AxisX.LineWidth = 0;
            chartArea2.AxisX.LineWidth = 0;
            chartArea3.AxisX.LineWidth = 0;

            chartArea1.Position = new ElementPosition(0, 1, 99.5f, 25); // ElementPosition(0, 1, 100, 25);
            chartArea2.Position = new ElementPosition(0, 25, 99.5f, 25); // ElementPosition(0, 25, 100, 25);
            chartArea3.Position = new ElementPosition(0, 49, 99.5f, 25); // ElementPosition(0, 49, 100, 25);
            chartArea4.Position = new ElementPosition(0, 73, 99.5f, 25); // ElementPosition(0, 73, 100, 25);

            // Axis interval tick decimal formatting
            chartArea1.AxisX.LabelStyle.Format = "0.0";
            chartArea2.AxisX.LabelStyle.Format = "0.0";
            chartArea3.AxisX.LabelStyle.Format = "0.0";
            chartArea4.AxisX.LabelStyle.Format = "0.0";

            // Add the chart areas to the chart
            chart1.ChartAreas.Add(chartArea1);
            chart1.ChartAreas.Add(chartArea2);
            chart1.ChartAreas.Add(chartArea3);
            chart1.ChartAreas.Add(chartArea4);

            foreach (ChartArea ca in chart1.ChartAreas)
            {
                // Tick stuff
                //ca.AxisX.MajorGrid.Enabled = true;
                //ca.AxisX.MinorGrid.Enabled = false;
                //ca.AxisX.MajorTickMark.Enabled = true;
                //ca.AxisX.MinorTickMark.Enabled = false;
                //ca.AxisY.MajorGrid.Enabled = true;
                //ca.AxisY.MinorGrid.Enabled = false;
                //ca.AxisY.MajorTickMark.Enabled = true;
                //ca.AxisY.MinorTickMark.Enabled = false;

                // Colouring
                ca.BackColor = ColorTranslator.FromHtml("#1E1E1E");
                ca.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333"); // Originally #333333
                ca.AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
                ca.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
                ca.AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
                ca.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
                ca.AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
                ca.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
                ca.AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
                ca.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
                ca.AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
                ca.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
                ca.AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

                // Zoomable
                ca.AxisX.ScaleView.Zoomable = true;
                ca.AxisY.ScaleView.Zoomable = true;
            }
            #endregion
        }

        private void MapDataPointsToChart(CsvData csvData)
        {
            int counter = 1;

            void DoDataPoints(List<ChartDataConfig> chartDataConfigs)
            {
                foreach (ChartDataConfig chartDataConfig in chartDataConfigs)
                {
                    CsvData.DataValues enumValue = (CsvData.DataValues)chartDataConfig.DataPoint;
                    if (enumValue == CsvData.DataValues.Empty)
                        continue;

                    ChartDataConfig.Colours colour = (ChartDataConfig.Colours)chartDataConfig.LineColour;

                    // Create Legends
                    Legend legend = new Legend
                    {
                        Name = "Legend:" + counter.ToString() + ":" + enumValue.ToString(),
                        DockedToChartArea = "ChartArea" + counter.ToString(),
                        Docking = Docking.Left,
                        IsDockedInsideChartArea = true,
                        LegendStyle = LegendStyle.Row,
                        ForeColor = Color.White,
                        BackColor = Color.Transparent
                    };

                    chart1.Legends.Add(legend);


                    // Create series
                    Series series = new Series
                    {
                        Name = "Series:" + counter.ToString() + ":" + enumValue.ToString(),
                        LegendText = enumValue.ToString(),
                        IsValueShownAsLabel = false,
                        ChartArea = "ChartArea" + counter.ToString(),
                        Legend = "Legend:" + counter.ToString() + ":" + enumValue.ToString(),
                        Color = ColorTranslator.FromHtml(ChartDataConfig.GetColourValue(colour)),
                        ChartType = SeriesChartType.Line,
                        XValueType = ChartValueType.Double
                    };

                    for (int i = 0; i < csvData.ListTime.Count; i++)
                        series.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.GetDataPointsList(enumValue)[i]);

                    chart1.ChartAreas["ChartArea" + counter.ToString()].AxisY.Interval = csvData.GetDataPointsInterval(enumValue);
                    chart1.Series.Add(series);
                }

                counter++;
            }

            DoDataPoints(AppSettings.Chart1DataPoints);
            DoDataPoints(AppSettings.Chart2DataPoints);
            DoDataPoints(AppSettings.Chart3DataPoints);
            DoDataPoints(AppSettings.Chart4DataPoints);

            foreach (ChartArea ca in chart1.ChartAreas)
            {
                ca.AxisX.Interval = 5; // Seconds ~ Probably want 10 seconds with actual data
                ca.AxisX.MajorGrid.Interval = 1; // Which tick the major grid line will appear on
            }

            // TODO: whats this for again
            //foreach (ChartArea ca in chart1.ChartAreas)
            //{
            //    Axis xAxis = ca.AxisX;

            //    foreach (var time in csvData.ListTime)
            //    {
            //        string[] split = time.Split('.');
            //        TimeSpan ts = new TimeSpan(0, 0, 0, int.Parse(split[0]), int.Parse(split[1]));
            //        var t1 = ts.Minutes.ToString() + ":" + ts.Seconds.ToString() + ":" + ts.Milliseconds.ToString();

            //        CustomLabel customLabel1 = new CustomLabel()
            //        {
            //            FromPosition = double.Parse(time),
            //            ToPosition = double.Parse(time) + 0.1,
            //            Text = t1,
            //            ForeColor = Color.Green
            //        };

            //        xAxis.CustomLabels.Add(customLabel1);
            //    }
            //}
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = chart1;

            if (chart != null)
            {
                // Get the current position of the cursor on the grid, relevant to the axis
                HitTestResult htRes = chart.HitTest(e.X, e.Y);

                if (htRes.ChartArea != null)
                {
                    // Get cursor position - being lazy and taking from first chart area
                    double xValue = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

                    foreach (ChartArea ca in chart.ChartAreas)
                    {
                        // Remove the old one first
                        if (ca.AxisX.StripLines.Any())
                            ca.AxisX.StripLines.Remove(ca.AxisX.StripLines[0]);

                        // Then add the new one
                        ca.AxisX.StripLines.Add(new StripLine()
                        {
                            IntervalOffset = xValue,
                            StripWidth = 0,
                            BorderColor = ColorTranslator.FromHtml(ChartDataConfig.GetColourValue((ChartDataConfig.Colours)AppSettings.CursorLineColour)),
                            BorderWidth = 1,
                            BorderDashStyle = ChartDashStyle.Solid
                        });
                    }

                    // Update legend with current value on yAxis
                    foreach (Series series in chart.Series)
                    {
                        DataPoint matchingPoint = series.Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));
                        series.LegendText = series.Legend.Split(':')[2] + " : " + matchingPoint?.YValues.FirstOrDefault();
                    }

                    //double yValue = Math.Round(ca.AxisY.PixelPositionToValue(e.Y), 2);
                    //chart.Series
                    //    .Where(x => x.ChartArea == ca.Name)
                    //    .ToList()
                    //    .ForEach(x => x.LegendText = x.Name + " = " + yValue.ToString());
                    //double yValue = Math.Round(chart.ChartAreas[series.ChartArea].AxisY.PixelPositionToValue(e.Y), 2);
                }


                // TODO: configurable
                if (false)
                {
                    // Test 1
                    {
                        foreach (DataPoint dp in chart.Series[0].Points)
                        {
                            if (dp.YValues[0] == 871)
                                dp.ToolTip = "test";
                        }
                    }

                    // Test 2
                    {
                        var pos = e.Location;
                        var results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

                        foreach (var result in results)
                        {
                            if (result.ChartElementType == ChartElementType.DataPoint)
                            {
                                var prop = result.Object as DataPoint;
                                if (prop != null)
                                {
                                    //toolTip1.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], chart, pos.X, pos.Y - 15);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void chart1_MouseWheelMove(object sender, MouseEventArgs e)
        {
            Axis xAxis = chart1.ChartAreas[0].AxisX;
            int zoomScale = 2;

            try
            {
                if (e.Delta < 0)
                {
                    xAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    double xMinView = xAxis.ScaleView.ViewMinimum;
                    double xMaxView = xAxis.ScaleView.ViewMaximum;

                    double posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMaxView - xMinView) / zoomScale;
                    double posXEnd = xAxis.PixelPositionToValue(e.Location.X) + (xMaxView - xMinView) / zoomScale;

                    xAxis.ScaleView.Zoom(posXStart, posXEnd);
                }

                // https://stackoverflow.com/questions/75654493/how-to-zoom-a-control-relative-to-the-current-mouse-position
                {
                    int imgx = 0;
                    float zoom = 1;
                    float oldzoom = zoom;

                    if (e.Delta > 0)
                        zoom = Math.Min(zoom + 0.1F, 100F);

                    else if (e.Delta < 0)
                        zoom = Math.Max(zoom - 0.1F, 0.1F);

                    int x = e.Location.X;    // Where location of the mouse in the pictureframe

                    int oldimagex = (int)(x / oldzoom);  // Where in the IMAGE is it now
                    int newimagex = (int)(x / zoom);     // Where in the IMAGE will it be when the new zoom i made

                    imgx += newimagex - oldimagex;  // Where to move image to keep focus on one point
                    xAxis.ScaleView.Zoom(newimagex, oldimagex);

                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            Chart chart = chart1;

            if (chart != null)
            {
                foreach (ChartArea ca in chart.ChartAreas)
                {
                    if (ca?.AxisX.StripLines?.Count > 0)
                        ca.AxisX.StripLines.Remove(ca.AxisX.StripLines[0]);
                }
            }
        }

    }
}
