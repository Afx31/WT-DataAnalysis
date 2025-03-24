using System.Windows.Forms.DataVisualization.Charting;
using WT_DataAnalysis_DatalogReview.Models;
using WT_DataAnalysis_DatalogReview.Utils;

namespace WT_DataAnalysis_DatalogReview;

public partial class DatalogReviewForm : Form
{
    AppSettings AppSettings = AppSettings.Instance;
    private readonly CsvData _csvData;
    int previousMarkerDataPoint = -1;
    bool isDragging = false;

    public DatalogReviewForm(CsvData csvData)
    {
        InitializeComponent();

        if (csvData != null)
        {
            _csvData = csvData;
            InitialChartControlSetup();
            InitialChartSetup();
            MapDataPointsToChart(9999);
            DrawTrackMap();
        }
    }

    private void InitialChartControlSetup()
    {
        /* Three modes of moving the line:
         * 1 - Single click (Left)
         * 2 - Click and drag (Right)
         * 3 - Auto move with cursor
         */

        // This will handle both cases
        chart1.MouseMove += chart1_MouseMove;

        if (AppSettings.AutoCursorLine)
        {
            chart1.MouseLeave += chart1_MouseLeave;
        }
        else
        {
            // #1
            chart1.MouseClick += chart1_MouseClick;

            // #2
            chart1.MouseDown += chart1_MouseDown;
            chart1.MouseUp += chart1_MouseUp;
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

    public void MapDataPointsToChart(int displayThisSpecificLap)
    {
        bool loadAllLaps = false;
        int startIndex = 0;
        int endIndex = 0;
        List<double> loadThisHertzRange = new List<double>();

        // Display all laps
        if (displayThisSpecificLap == 9999)
        {
            loadAllLaps = true;
        }
        else if (_csvData.DictLapData.ContainsKey(displayThisSpecificLap))
        {
            var currLap = _csvData.DictLapData[displayThisSpecificLap];
            double thisLapsStartingHertz = currLap.Item1;
            double thisLapsEndingHertz = currLap.Item2;

            // Lookup the hertz index in the ListHertzTime, then range those
            startIndex = _csvData.ListHertzTime.IndexOf(thisLapsStartingHertz);
            endIndex = _csvData.ListHertzTime.IndexOf(thisLapsEndingHertz);
            loadThisHertzRange = _csvData.ListHertzTime.GetRange(startIndex, endIndex - startIndex + 1);
        }

        // Cleanup for changing chart
        while (chart1.Series.Count > 0)
            chart1.Series.RemoveAt(0);
        while (chart1.Legends.Count > 0)
            chart1.Legends.RemoveAt(0);
        if (chart_TrackMap.Series.Any(x => x.Name == "DataMarker"))
        {
            Series removeSeries = chart_TrackMap.Series[1];
            chart_TrackMap.Series.Remove(removeSeries);
        }

        double[] GetRelevantDataForThisHertzRange(double[] fullList)
        {
            List<double> retrievedList = new List<double>();

            for (int i = startIndex; i <= endIndex; i++)
                retrievedList.Add((double)fullList.GetValue(i));

            return retrievedList.ToArray();
        }

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
                    ChartType = SeriesChartType.FastLine,
                    XValueType = ChartValueType.Double
                };

                if (loadAllLaps)
                    series.Points.DataBindXY(_csvData.ListHertzTime.ToArray(), _csvData.GetDataPointsList(enumValue));
                else
                    series.Points.DataBindXY(loadThisHertzRange.ToArray(), GetRelevantDataForThisHertzRange(_csvData.GetDataPointsList(enumValue)));

                chart1.ChartAreas["ChartArea" + counter.ToString()].AxisY.Interval = _csvData.GetDataPointsInterval(enumValue);
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
            ca.AxisX.Minimum = double.NaN;
            ca.AxisX.Maximum = double.NaN;
            ca.RecalculateAxesScale();
            ca.AxisX.ScaleView.ZoomReset();
        }

        if (chart1.Series.Any(x => x.Name == "Series4:4:Gear"))
            chart1.Series["Series:4:Gear"].Enabled = false;
        chart1.ChartAreas["ChartArea4"].AxisY.Interval = 10;

        if (loadAllLaps)
        {
            foreach (ChartArea ca in chart1.ChartAreas)
            {
                foreach (var lap in _csvData.DictLapData)
                {
                    string lapText = "";
                    int maxLaps = _csvData.DictLapData.Count;

                    if (lap.Key == 0)
                        lapText = "Out Lap";
                    else if (lap.Key == maxLaps - 1)
                        lapText = "In Lap";
                    else
                        lapText = "Lap " + lap.Key.ToString();

                    ca.AxisX.StripLines.Add(new StripLine()
                    {
                        IntervalOffset = lap.Value.Item1,
                        StripWidth = 0,
                        BorderColor = Color.Gray,
                        BorderWidth = 1,
                        BorderDashStyle = ChartDashStyle.Solid,
                        Text = lapText,
                        ForeColor = Color.Gray,
                        TextOrientation = TextOrientation.Horizontal,
                        TextAlignment = StringAlignment.Near
                    });
                }
            }
        }

        foreach (ChartArea ca in chart1.ChartAreas)
        {
            ca.AxisX.Interval = 20; // Seconds mark
            ca.AxisX.MajorTickMark.Interval = 20; // Major ticks at every x units
            //ca.AxisX.MajorGrid.Interval = 10; // Which tick the major grid line will appear on

            // ---- X Axis time formatting ----
            // This works, but once you zoom in it's then all wrong
            // Initial setup
            //var tempList = new List<string>();
            //var tempSpan = new TimeSpan(0, 0, 0);
            //for (int i = 0; i < _csvData.ListHertzTime.Count; i += 10)
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

        #region Max values
        double maxRpm = _csvData.ListRpm.Max();
        double maxSpeed = _csvData.ListSpeed.Max();
        double maxECT = _csvData.ListECT.Max();
        double maxIAT = _csvData.ListIAT.Max();
        double maxOilTemp = _csvData.ListOilTemperature.Max();
        double maxOilPressure = _csvData.ListOilPressure.Max();

        lbl_MaxRpm.Text = maxRpm.ToString();
        lbl_MaxSpeed.Text = maxSpeed.ToString();
        lbl_MaxECT.Text = maxECT.ToString();
        lbl_MaxIAT.Text = maxIAT.ToString();
        lbl_MaxOilTemp.Text = maxOilTemp.ToString();
        lbl_MaxOilPressure.Text = maxOilPressure.ToString();
        #endregion

        #region Test code for calculating the laps based on lat/lon
        // TODO: Defaulting the lap segregation manually until the dash can auto handle it correctly
        // USED this to work out the laps for the data we have, then updated the lap in the data.
        // It's also testing the GPS stuff for the dash, so maybe handy to keep it somewhere
        //if (false)
        //{
        //    double thisTrackLatMin = 0;
        //    double thisTrackLatMax = 0;
        //    double thisTrackLonMin = 0;
        //    double thisTrackLonMax = 0;
        //    double previousLat = 0.0;
        //    double previousLon = 0.0;

        //    switch (_csvData.Track)
        //    {
        //        case "smsp":
        //            thisTrackLatMin = -33.803825;
        //            thisTrackLatMax = -33.803653;
        //            thisTrackLonMin = 150.870923;
        //            thisTrackLonMax = 150.870962;
        //            break;
        //        case "morganpark":
        //            thisTrackLatMin = -28.262069;
        //            thisTrackLatMax = -28.262085;
        //            thisTrackLonMin = 152.036327;
        //            thisTrackLonMax = 152.036430;
        //            break;
        //    }

        //    bool FinishLineCheck(double x1, double y1, double x2, double y2, // Finish line points (start - finish)
        //                        double x3, double y3, double x4, double y4)  // Movement path points (previous - current)
        //    {
        //        // Represent the finish line as a line segment defined by two GPS points.
        //        // Use a geometric algorithm to determine if your movement path crosses this line.

        //        // ** We calculate the intersection point on both the finish line AND movement line                
        //        // - FinishLine = line across the track (min to max points)
        //        // - MovementPath = previous location to current location

        //        double denominator = (x3 - x4) * (y1 - y2) - (y3 - y4) * (x1 - x2);

        //        // If denominator is 0, the lines are parallel or coincident
        //        if (Math.Abs(denominator) < 1e-10)
        //            return false;

        //        // Calculate the numerators
        //        double tNumerator = (x3 - x1) * (y1 - y2) - (y3 - y1) * (x1 - x2);
        //        double uNumerator = (x3 - x1) * (y3 - y4) - (y3 - y1) * (x3 - x4);

        //        // Solve for t and u
        //        // t - Parametric value along the finish line segment
        //        // u - Parametric value along the movement path
        //        double t = tNumerator / denominator;
        //        double u = uNumerator / denominator;

        //        // Check if the intersection happens on both segments
        //        return (t >= 0 && t <= 1) && (u >= 0 && u <= 1);
        //    }


        //    List<Tuple<double, string>> lapList = new List<Tuple<double, string>>();
        //    lapList.Add(new Tuple<double, string>(hertzTimeArr[1], "Out"));

        //    for (int i = 0; i < _csvData.ListLat.Count; i++)
        //    {
        //        if (FinishLineCheck(thisTrackLatMin, thisTrackLonMin, thisTrackLatMax, thisTrackLonMax,
        //                            previousLat, previousLon, _csvData.ListLat[i], _csvData.ListLon[i]))
        //        {
        //            lapList.Add(new Tuple<double, string>(hertzTimeArr[i], lapList.Count.ToString()));
        //            i += 100; // Hack, otherwise it'll pick up the next 10 items as its 10hz. Dash will skip over this anyways
        //        }

        //        previousLat = _csvData.ListLat[i];
        //        previousLon = _csvData.ListLon[i];
        //    }
        //}
        #endregion
    }

    private void DrawTrackMap()
    {
        ChartArea chartAreaTrackMap = new ChartArea("ChartAreaTrackMap");

        CurrentTrackCoords trackMapMaxCoords = TrackData.GetTrackMapMaxCoords(_csvData.Track);
        chartAreaTrackMap.AxisX.Minimum = trackMapMaxCoords.LatMin;
        chartAreaTrackMap.AxisX.Maximum = trackMapMaxCoords.LatMax;
        chartAreaTrackMap.AxisY.Minimum = trackMapMaxCoords.LonMin;
        chartAreaTrackMap.AxisY.Maximum = trackMapMaxCoords.LonMax;

        chartAreaTrackMap.Position.Height = 100;
        chartAreaTrackMap.Position.Width = 100;
        chartAreaTrackMap.BackColor = Color.DarkGray;

        // Disable if needed to view the coords axis labels
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

        Series trackMapSeries = new Series("TrackMapSeries")
        {
            ChartType = SeriesChartType.FastPoint,
            Color = Color.White,
            MarkerSize = 2
        };


        List<double> unpackedLat = new List<double>();
        List<double> unpackedLon = new List<double>();

        foreach (var item in _csvData.DictLatLon)
        {
            unpackedLat.Add(item.Value.Item1);
            unpackedLon.Add(item.Value.Item2);
        }
        trackMapSeries.Points.DataBindXY(unpackedLon.ToArray(), unpackedLat.ToArray());
        chart_TrackMap.Series.Add(trackMapSeries);


        // Finish line
        Series finishLineSeries = new Series("FinishLineSeries")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Red,
            BorderWidth = 4
        };
        CurrentTrackCoords finishLineCoords = TrackData.GetFinishLineCoords(_csvData.Track);
        finishLineSeries.Points.AddXY(finishLineCoords.LonMin, finishLineCoords.LatMin);
        finishLineSeries.Points.AddXY(finishLineCoords.LonMax, finishLineCoords.LatMax);
        chart_TrackMap.Series.Add(finishLineSeries);
    }

    private void DoCurrentCursorPositionDataEvalution(object sender, MouseEventArgs e)
    {
        if (chart1 != null && e.X > 0)
        {
            // Get cursor position - being lazy and taking from first chart area
            double xValue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

            //foreach (ChartArea ca in chart.ChartAreas)
            Parallel.ForEach(chart1.ChartAreas, ca =>
            {
                // Remove the old one first
                StripLine cursorStripLine = ca.AxisX.StripLines.FirstOrDefault(x => x.Text == "");
                ca.AxisX.StripLines.Remove(cursorStripLine);

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
            string gearValue = "";

            // Update legend with current value on yAxis
            //foreach (Series series in chart1.Series)
            Parallel.ForEach(chart1.Series, series =>
            {
                DataPoint matchingPoint = series.Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));

                if (matchingPoint != null)
                {
                    series.LegendText = series.Legend.Split(':')[2] + " : " + matchingPoint.YValues.FirstOrDefault();

                    if (series.Name == "Series:4:Gear")
                        gearValue = matchingPoint.YValues.FirstOrDefault().ToString();
                }
            });

            {
                DataPoint matchingPoint = chart1.Series[0].Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));

                if (matchingPoint != null)
                {
                    var latLonVal = _csvData.DictLatLon[matchingPoint.XValue];
                    currentLat = latLonVal.Item1;
                    currentLon = latLonVal.Item2;
                }

                // TODO: Suss this later
                // Have to move this out for some reason because of the multi threading.
                lbl_Gear.Text = gearValue;

                MoveTrackMapCurrentPosition(currentLat, currentLon);

                // TODO: No idea what this was for
                //double yValue = Math.Round(ca.AxisY.PixelPositionToValue(e.Y), 2);
                //chart.Series
                //    .Where(x => x.ChartArea == ca.Name)
                //    .ToList()
                //    .ForEach(x => x.LegendText = x.Name + " = " + yValue.ToString());
                //double yValue = Math.Round(chart.ChartAreas[series.ChartArea].AxisY.PixelPositionToValue(e.Y), 2);
            }
        }
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
                // TODO: This is the shitty workaround
                // Remove the current series if it exists
                if (previousMarkerDataPoint >= 0 && chart_TrackMap.Series.Any(x => x.Name == "DataMarker"))
                    chart_TrackMap.Series.Remove(chart_TrackMap.Series["DataMarker"]);

                Series series = new Series("DataMarker");
                series.ChartType = SeriesChartType.Point;
                series.Points.AddXY(lon, lat);
                series.Points[0].MarkerColor = Color.Red;
                series.Points[0].MarkerSize = 15;
                series.Points[0].MarkerStyle = MarkerStyle.Circle;
                series.Points[0].Color = Color.Red;

                chart_TrackMap.Series.Add(series);

                previousMarkerDataPoint = i;
                break;
            }
        }
    }

    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            DoCurrentCursorPositionDataEvalution(sender, e);
    }

    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            isDragging = true;
    }

    private void chart1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            isDragging = false;
    }

    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (AppSettings.AutoCursorLine || isDragging)
            DoCurrentCursorPositionDataEvalution(sender, e);
    }

    /// <summary>
    /// Zoom functionality
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void chart1_MouseWheelMove(object sender, MouseEventArgs e)
    {
        /* NOTE
         * - This is experimental, trying to find the right solution with scaling so it's pleasant to the eye
         * - So there might be some different iterations commented out, just testing things as I go
         */

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

            // TODO: Need to test this
            // https://stackoverflow.com/questions/75654493/how-to-zoom-a-control-relative-to-the-current-mouse-position
            {
                //int imgx = 0;
                //float zoom = 1;
                //float oldzoom = zoom;

                //if (e.Delta > 0)
                //    zoom = Math.Min(zoom + 0.1F, 100F);

                //else if (e.Delta < 0)
                //    zoom = Math.Max(zoom - 0.1F, 0.1F);

                //int x = e.Location.X;    // Where location of the mouse in the pictureframe

                //int oldimagex = (int)(x / oldzoom);  // Where in the IMAGE is it now
                //int newimagex = (int)(x / zoom);     // Where in the IMAGE will it be when the new zoom i made

                //imgx += newimagex - oldimagex;  // Where to move image to keep focus on one point
                //xAxis.ScaleView.Zoom(newimagex, oldimagex);

                //Invalidate();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR: " + ex);
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