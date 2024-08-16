using System.Diagnostics.Metrics;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace WRD_DataAnalysis
{
    public partial class MainForm : Form
    {
        private bool _IsDarkTheme = true;

        public MainForm()
        {
            InitializeComponent();

            // Debugging
            if (true)
            {
                this.StartPosition = FormStartPosition.Manual;
                Screen[] screens = Screen.AllScreens;
                Point location = screens[2].Bounds.Location;
                this.Left = location.X;
                this.Top = 100;
                this.WindowState = FormWindowState.Maximized;
            }

            CsvData csvData = new CsvData();
            csvData.ReadCsvData(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\data.csv");

            InitialChartSetup();
            ChartPositioningSetup();
            MapDataPointsToChart(csvData);
            FormLogic();
            //DoTheme();
        }

        public void FormLogic()
        {
            // Series - used to store data that is to be displayed, along with the attributes of that data
            // ChartAreas - used to draw one or more charts using one set of axes (with DataPoints)


            //foreach (DataPoint dp in series.Points)
            //{
            //    if (dp.XValue == 5)
            //        dp.ToolTip = "test";
            //}
        }

        public void InitialChartSetup()
        {
            /*
             * TODO: Very hardcoded for now, just on initial setup. Still working out a decent colouring scheme
             * "I'll rework it dynamically one day.."
             */
            
            // Setup ChartAreas
            ChartArea chartArea1 = new ChartArea("Chart Area 1");
            ChartArea chartArea2 = new ChartArea("Chart Area 2");
            ChartArea chartArea3 = new ChartArea("Chart Area 3");
            ChartArea chartArea4 = new ChartArea("Chart Area 4");
            
            // https://stackoverflow.com/questions/32925981/remove-white-and-unnecessary-space-from-chart-control
            chartArea1.Position = new ElementPosition(0, 0, 100, 100);
            chartArea2.Position = new ElementPosition(0, 0, 100, 100);
            chartArea3.Position = new ElementPosition(0, 0, 100, 100);
            chartArea4.Position = new ElementPosition(0, 0, 100, 100);
            chartArea1.AxisX.LabelStyle.Format = "0.0";

            chart1.ChartAreas.Add(chartArea1);
            chart2.ChartAreas.Add(chartArea2);
            chart3.ChartAreas.Add(chartArea3);
            chart4.ChartAreas.Add(chartArea4);

            Legend legend1 = new Legend("Legend 1");
            Legend legend2 = new Legend("Legend 2");
            Legend legend3 = new Legend("Legend 3");
            Legend legend4 = new Legend("Legend 4");
            chart1.Legends.Add(legend1);
            chart2.Legends.Add(legend2);
            chart3.Legends.Add(legend3);
            chart4.Legends.Add(legend4);

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart2.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart2.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart3.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart3.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart4.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart4.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart4.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            // ---- Colouring ----
            // Chart
            chart1.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#1E1E1E");
            chart2.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#1E1E1E");
            chart3.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#1E1E1E");
            chart4.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#1E1E1E");

            // Chart Area
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333"); // Originally #333333
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart1.ChartAreas[0].AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart1.ChartAreas[0].AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart1.ChartAreas[0].AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart2.ChartAreas[0].AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart2.ChartAreas[0].AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart2.ChartAreas[0].AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart2.ChartAreas[0].AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart2.ChartAreas[0].AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart2.ChartAreas[0].AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart2.ChartAreas[0].AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart2.ChartAreas[0].AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

            chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart3.ChartAreas[0].AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart3.ChartAreas[0].AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart3.ChartAreas[0].AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart3.ChartAreas[0].AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart3.ChartAreas[0].AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
            chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart3.ChartAreas[0].AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart3.ChartAreas[0].AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart3.ChartAreas[0].AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart3.ChartAreas[0].AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart3.ChartAreas[0].AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

            chart4.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart4.ChartAreas[0].AxisX.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart4.ChartAreas[0].AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart4.ChartAreas[0].AxisX.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart4.ChartAreas[0].AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart4.ChartAreas[0].AxisX.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");
            chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#333333");
            chart4.ChartAreas[0].AxisY.MinorGrid.LineColor = ColorTranslator.FromHtml("#4D4D4D");
            chart4.ChartAreas[0].AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart4.ChartAreas[0].AxisY.MinorTickMark.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chart4.ChartAreas[0].AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#CCCCCC");
            chart4.ChartAreas[0].AxisY.TitleForeColor = ColorTranslator.FromHtml("#FFFFFF");

            // Series
            // done in KMapDataPointsToChart()


            //chart1.Dock = DockStyle.Fill;
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
            //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }

        public void ChartPositioningSetup()
        {
            chart1.Height = (this.Height / 4) - 30;

            chart2.Location = new Point(chart2.Location.X, chart1.Location.Y + chart1.Height + 5);

            chart2.Height = (this.Height / 4) - 30;

            chart3.Location = new Point(chart3.Location.X, chart2.Location.Y + chart2.Height + 5);

            chart3.Height = (this.Height / 4) - 30;

            chart4.Location = new Point(chart4.Location.X, chart3.Location.Y + chart3.Height + 5);

            chart4.Height = (this.Height / 4) - 30;
        }

        public void MapDataPointsToChart(CsvData csvData)
        {
            var series = new Series
            {
                Name = "Rpm",
                Color = Color.Blue,
                ChartType = SeriesChartType.Line
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
            {
                //var t1 = csvData.ListRpm[i];
                //var t2 = csvData.ListTime[i];
                series.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListRpm[i]);
            }
            series.XValueType = ChartValueType.Double;
            chart1.ChartAreas[0].AxisX.Interval = 0.100;
            chart1.ChartAreas[0].AxisY.Interval = 1000;
            chart1.Series.Add(series);



            var series2 = new Series
            {
                Name = "ECT",
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };
            var series22 = new Series
            {
                Name = "Oil Temp",
                Color = Color.Orange,
                ChartType = SeriesChartType.Line
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
            {
                series2.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListECT[i]);
                series22.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilTemp[i]);
            }
            series2.XValueType = ChartValueType.Double;
            series22.XValueType = ChartValueType.Double;
            chart2.ChartAreas[0].AxisX.Interval = 0.100;
            chart2.ChartAreas[0].AxisY.Interval = 10;
            chart2.Series.Add(series2);
            chart2.Series.Add(series22);


            var series3 = new Series
            {
                Name = "Oil Temp",
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
            {
                series3.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilTemp[i]);
            }
            series3.XValueType = ChartValueType.Double;
            chart3.ChartAreas[0].AxisX.Interval = 0.100;
            chart3.ChartAreas[0].AxisY.Interval = 10;
            chart3.Series.Add(series3);


            var series4 = new Series
            {
                Name = "Oil Pressure",
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
            {
                series4.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilPressure[i]);
            }
            series4.XValueType = ChartValueType.Double;
            chart4.ChartAreas[0].AxisX.Interval = 0.100;
            chart4.ChartAreas[0].AxisY.Interval = 10;
            chart4.Series.Add(series4);

            chart1.Series[0].Color = ColorTranslator.FromHtml("#FF5722");
            chart2.Series[0].Color = ColorTranslator.FromHtml("#4CAF50");
            chart2.Series[1].Color = ColorTranslator.FromHtml("#FFC107");
            chart3.Series[0].Color = ColorTranslator.FromHtml("#2196F3");
            chart4.Series[0].Color = ColorTranslator.FromHtml("#FFC107");
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            Chart currentChart = sender as Chart;

            if (currentChart != null)
            {
            // Get the current position of the cursor on the grid, relevant to the axis
                HitTestResult htRes = currentChart.HitTest(e.X, e.Y);
            if (htRes.ChartArea != null)
            {
                // Get cursor position
                    double xValue = currentChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

                // Remove the old one first
                    if (currentChart.ChartAreas[0].AxisX.StripLines.Any())
                        currentChart.ChartAreas[0].AxisX.StripLines.Remove(currentChart.ChartAreas[0].AxisX.StripLines[0]);

                // Then add the new one
                    currentChart.ChartAreas[0].AxisX.StripLines.Add(new StripLine()
                {
                    IntervalOffset = xValue,
                    StripWidth = 0,
                    BorderColor = Color.Red,
                    BorderWidth = 1,
                    BorderDashStyle = ChartDashStyle.Solid
                });
            }

            // TODO: configurable
            if (false)
            {
                var pos = e.Location;
                    var results = currentChart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        if (prop != null)
                        {
                                toolTip1.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], currentChart, pos.X, pos.Y - 15);
                            }
                        }
                        }
                    }
                }
            }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            Chart currentChart = sender as Chart;

            if (currentChart?.ChartAreas[0].AxisX.StripLines.Any() != null)
                currentChart.ChartAreas[0].AxisX.StripLines.Remove(currentChart.ChartAreas[0].AxisX.StripLines[0]);
        }

        private void DoTheme()
        {
            _IsDarkTheme = !_IsDarkTheme;

            this.BackColor = _IsDarkTheme ? Color.DimGray : default;

            foreach (Control control in this.Controls)
            {
                if (control is Chart chart)
                {
                    chart.BackColor = _IsDarkTheme ? Color.Gray : default;
                    //chart.ChartAreas[0].BackColor = _IsDarkTheme ? Color.Black : default;
                }
            }
        }

        private void toolStripMenuItem_Theme_Click(object sender, EventArgs e)
        {
            DoTheme();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ChartPositioningSetup();
        }
    }
}
