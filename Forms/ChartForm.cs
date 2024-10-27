﻿using System.Windows.Forms.DataVisualization.Charting;

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
                DrawTrackMap(_CsvData.ListLatLon);
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

            // Optional: Hide the X-axis line for the first two chart areas`
            chartArea1.AxisX.LineWidth = 0;
            chartArea2.AxisX.LineWidth = 0;
            chartArea3.AxisX.LineWidth = 0;

            chartArea1.Position = new ElementPosition(0, 0, 99.5f, 24); // ElementPosition(0, 0, 99.5f, 23);
            chartArea2.Position = new ElementPosition(0, 24, 99.5f, 24); // ElementPosition(0, 22, 99.5f, 23);
            chartArea3.Position = new ElementPosition(0, 48, 99.5f, 24); // ElementPosition(0, 44, 99.5f, 23);
            chartArea4.Position = new ElementPosition(0, 73, 99.5f, 24); // ElementPosition(0, 67, 99.5f, 23);

            // Axis interval tick decimal formatting
            chartArea1.AxisX.LabelStyle.Format = "0.0";
            chartArea2.AxisX.LabelStyle.Format = "0.0";
            chartArea3.AxisX.LabelStyle.Format = "0.0";
            chartArea4.AxisX.LabelStyle.Format = "0.0";
            chartArea1.AxisX.Minimum = 0;
            chartArea2.AxisX.Minimum = 0;
            chartArea3.AxisX.Minimum = 0;
            chartArea4.AxisX.Minimum = 0;

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

            # region Lat/Lon stuff
            Series seriesLat = new Series()
            {
                Name = "Series:4:Lat",
                ChartArea = "ChartArea4",
                XValueType = ChartValueType.Double
            };
            Series seriesLon = new Series()
            {
                Name = "Series:4:Lon",
                ChartArea = "ChartArea4",
                XValueType = ChartValueType.Double
            };

            var listLat = csvData.ListLatLon.Select(x => x.Item1).ToList();
            var listLon = csvData.ListLatLon.Select(x => x.Item2).ToList();

            for (int i = 0; i < csvData.ListHertzTime.Count; i++)
                seriesLat.Points.AddXY(double.Parse(csvData.ListHertzTime[i]), listLat[i]);
            for (int i = 0; i < csvData.ListHertzTime.Count; i++)
                seriesLon.Points.AddXY(double.Parse(csvData.ListHertzTime[i]), listLon[i]);

            chart1.Series.Add(seriesLat);
            chart1.Series.Add(seriesLon);
            #endregion

            /* TODO: Fix this properly
             * Using it so we can reference the gear position for the label at the bottom of the screen,
             * whilst still getitng relevant position based on chart position click
             */
            chart1.Series["Series:4:Gear"].Enabled = false;
            chart1.Series["Series:4:Lat"].Enabled = false;
            chart1.Series["Series:4:Lon"].Enabled = false;
            chart1.ChartAreas["ChartArea4"].AxisY.Interval = 10;

            foreach (ChartArea ca in chart1.ChartAreas)
            {
                ca.AxisX.Interval = 10; // Seconds
                ca.AxisX.MajorTickMark.Interval = 10; // Major ticks at every x units
                //ca.AxisX.MajorGrid.Interval = 10; // Which tick the major grid line will appear on


                // ---- X Axis time formatting ----
                // This works, but once you zoom in it's then all wrong
                // Initial setup
                //var tempList = new List<string>();
                //var tempSpan = new TimeSpan(0, 0, 0);
                //for (int i = 0; i < csvData.ListTime.Count; i += 10)
                //{
                //    tempList.Add(tempSpan.ToString(@"mm\.ss"));
                //    tempSpan = tempSpan.Add(TimeSpan.FromSeconds(10));
                //}

                //// Now assign to X Axis
                //int start = -5;
                //int end = 5;
                //for (int i = 0; i < tempList.Count; i += 1)
                //{
                //    ca.AxisX.CustomLabels.Add(start, end, tempList[i]);
                //    start += 10;
                //    end += 10;
                //}
            }

            // Do Max values
            var maxRpm = "0";
            foreach (var value in csvData.ListRpm)
            {
                if (int.Parse(value) >= int.Parse(maxRpm))
                    maxRpm = value;
            }

            lbl_MaxRpm.Text = maxRpm;
        }

        private void DrawTrackMap(List<Tuple<double, double>> listLatLon)
        {
            ChartArea chartAreaTrackMap = new ChartArea("ChartAreaTrackMap");

            chartAreaTrackMap.AxisX.Minimum = 152.028940;
            chartAreaTrackMap.AxisX.Maximum = 152.040025;
            chartAreaTrackMap.AxisY.Minimum = -28.265911;
            chartAreaTrackMap.AxisY.Maximum = -28.255305;

            chartAreaTrackMap.Position.Height = 100;
            chartAreaTrackMap.Position.Width = 100;

            // Don't run if needing to debug coordinates positioning
            if (true)
            {
                chartAreaTrackMap.AxisX.MajorGrid.Enabled = false;
                chartAreaTrackMap.AxisY.MajorGrid.Enabled = false;

                chartAreaTrackMap.AxisX.MajorTickMark.Enabled = false;
                chartAreaTrackMap.AxisY.MajorTickMark.Enabled = false;
                chartAreaTrackMap.AxisX.MinorTickMark.Enabled = false;
                chartAreaTrackMap.AxisY.MinorTickMark.Enabled = false;

                chartAreaTrackMap.AxisX.LabelStyle.Enabled = false;
                chartAreaTrackMap.AxisY.LabelStyle.Enabled = false;
            }

            chart_TrackMap.ChartAreas.Add(chartAreaTrackMap);

            Series series = new Series("TrackMapSeries");
            series.ChartType = SeriesChartType.Point;

            foreach (var coord in listLatLon)
            {
                series.Points.AddXY(coord.Item2, coord.Item1);
            }

            chart_TrackMap.Series.Add(series);
        }

        private void MoveTrackMapCurrentPosition(double lat, double lon)
        {
            // First clear the previous marker
            if (previousMarkerDataPoint >= 0)
            {
                DataPoint point = chart_TrackMap.Series[0].Points[previousMarkerDataPoint];
                point.MarkerColor = default;
                point.MarkerSize = default;
                point.MarkerStyle = default;
            }

            for (var i = 0; i < chart_TrackMap.Series[0].Points.Count; i++)
            {
                DataPoint point = chart_TrackMap.Series[0].Points[i];
                
                if (point.XValue == lon && point.YValues.FirstOrDefault() == lat)
                {
                    // TODO: This works but the blue line goes through circle
                    //point.MarkerColor = Color.Red;
                    //point.MarkerSize = 20;
                    //point.MarkerStyle = MarkerStyle.Circle;
                    
                    //point.Color = Color.Red;

                    // TODO: This is the shitty workaround
                    // Remove the current series if it exists
                    if (previousMarkerDataPoint >= 0)
                    {
                        Series removeSeries = chart_TrackMap.Series[1];
                        chart_TrackMap.Series.Remove(removeSeries);
                    }

                    Series series = new Series("DataMarker");
                    series.Points.AddXY(lon, lat);

                    series.Points[0].MarkerColor = Color.Red;
                    series.Points[0].MarkerSize = 20;
                    series.Points[0].MarkerStyle = MarkerStyle.Circle;
                    series.Points[0].Color = Color.Red;

                    chart_TrackMap.Series.Add(series);

                    previousMarkerDataPoint = i;
                    break;
                }
            }
        }

        bool isDragging = false;

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = true;
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (AppSettings.AutoCursorLine)
            if (isDragging)
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

                        //foreach (ChartArea ca in chart.ChartAreas)
                        Parallel.ForEach(chart.ChartAreas, ca =>
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
                        });

                        double currentLat = 0.0;
                        double currentLon = 0.0;
                        // Update legend with current value on yAxis

                        //foreach (Series series in chart.Series)
                        Parallel.ForEach(chart.Series, series =>
                        {
                            DataPoint matchingPoint = series.Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));
                            if (matchingPoint != null)
                            {
                            series.LegendText = series.Legend.Split(':')[2] + " : " + matchingPoint?.YValues.FirstOrDefault();

                                //if (series.Name == "Series:4:Gear")
                                //    lbl_Gear.Text = matchingPoint?.YValues.FirstOrDefault().ToString();

                                if (series.Name == "Series:4:Lat")
                                    currentLat = (double)matchingPoint?.YValues.FirstOrDefault();

                                if (series.Name == "Series:4:Lon")
                                    currentLon = (double)matchingPoint?.YValues.FirstOrDefault();
                        }
                        });

                        MoveTrackMapCurrentPosition(currentLat, currentLon);
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
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!AppSettings.AutoCursorLine)
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

                        double currentLat = 0.0;
                        double currentLon = 0.0;

                        // Update legend with current value on yAxis
                        foreach (Series series in chart.Series)
                        {
                            DataPoint matchingPoint = series.Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));
                            series.LegendText = series.Legend.Split(':')[2] + " : " + matchingPoint?.YValues.FirstOrDefault();
                            
                            if (series.Name == "Series:4:Gear")
                                lbl_Gear.Text = matchingPoint?.YValues.FirstOrDefault().ToString();

                            if (series.Name == "Series:4:Lat")
                                currentLat = (double)matchingPoint?.YValues.FirstOrDefault();

                            if (series.Name == "Series:4:Lon")
                                currentLon = (double)matchingPoint?.YValues.FirstOrDefault();
                        }

                        MoveTrackMapCurrentPosition(currentLat, currentLon);

                        // --- No idea
                        //double yValue = Math.Round(ca.AxisY.PixelPositionToValue(e.Y), 2);
                        //chart.Series
                        //    .Where(x => x.ChartArea == ca.Name)
                        //    .ToList()
                        //    .ForEach(x => x.LegendText = x.Name + " = " + yValue.ToString());
                        //double yValue = Math.Round(chart.ChartAreas[series.ChartArea].AxisY.PixelPositionToValue(e.Y), 2);
                    }
                }
            }
        }

        /// <summary>
        /// Zoom functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseWheelMove(object sender, MouseEventArgs e)
        {
            Axis xAxis = chart1.ChartAreas[0].AxisX;
            double zoomScale = 0.1; //0.05
            double currentXMinView = xAxis.ScaleView.ViewMinimum;
            double currentXMaxView = xAxis.ScaleView.ViewMaximum;
            double posXStart = 0;
            double posXEnd = 0;

            try
            {
                double cursorXValue = xAxis.PixelPositionToValue(e.X);

                if (e.Delta > 0) // Zooming in
                {
                    // Style 1 - zooms based on cursor position
                    if (true)
                    {
                        double startRange = (cursorXValue - currentXMinView) * zoomScale;
                        double endRange = (currentXMaxView - cursorXValue) * zoomScale;
                        posXStart = currentXMinView + startRange;
                        posXEnd = currentXMaxView - endRange;
                    }

                    // Style 2 - zooms based on overall size
                    if (false)
                    {
                        double range = (currentXMaxView - currentXMinView) * zoomScale;
                        posXStart = currentXMinView + range;
                        posXEnd = currentXMaxView - range;
                    }

                    // Center the zoom around the current xValue (mouse position)
                    //xAxis.ScaleView.Zoom(cursorXValue - range / 2, cursorXValue + range / 2);

                    xAxis.ScaleView.Zoom(posXStart, posXEnd);
                }
                else if (e.Delta < 0) // Zooming out
                {
                    if (xAxis.ScaleView.IsZoomed)
                    {
                        // Style 1 - zooms based on cursor position
                        if (true)
                        {
                            double startRange = (cursorXValue - currentXMinView) * zoomScale;
                            double endRange = (currentXMaxView - cursorXValue) * zoomScale;
                            posXStart = currentXMinView - startRange;
                            posXEnd = currentXMaxView + endRange;
                        }

                        // Style 2 - zooms based on overall size
                        if (false)
                        {
                            double range = (currentXMaxView - currentXMinView) * zoomScale;
                            posXStart = currentXMinView - range;
                            posXEnd = currentXMaxView + range;
                        }

                        xAxis.ScaleView.Zoom(posXStart, posXEnd);
                    }
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

            if (chart != null && AppSettings.AutoCursorLine)
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