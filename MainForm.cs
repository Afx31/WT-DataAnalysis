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
            // Setup ChartAreas
            ChartArea chartArea1 = new ChartArea("Chart Area 1");
            ChartArea chartArea2 = new ChartArea("Chart Area 2");
            ChartArea chartArea3 = new ChartArea("Chart Area 3");
            ChartArea chartArea4 = new ChartArea("Chart Area 4");
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

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisX2.MinorTickMark.Enabled = false;

            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart2.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisX2.MinorTickMark.Enabled = false;

            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart3.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart3.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart3.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart3.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
            chart3.ChartAreas[0].AxisX2.MinorTickMark.Enabled = false;

            chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart4.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart4.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart4.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart4.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
            chart4.ChartAreas[0].AxisX2.MinorTickMark.Enabled = false;

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
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current position of the cursor on the grid, relevant to the axis
            HitTestResult htRes = chart1.HitTest(e.X, e.Y);
            if (htRes.ChartArea != null)
            {
                // Get cursor position
                double xValue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

                // Remove the old one first
                if (chart1.ChartAreas[0].AxisX.StripLines.Any())
                    chart1.ChartAreas[0].AxisX.StripLines.Remove(chart1.ChartAreas[0].AxisX.StripLines[0]);

                // Then add the new one
                chart1.ChartAreas[0].AxisX.StripLines.Add(new StripLine()
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
                var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        if (prop != null)
                        {
                            toolTip1.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
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

        private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            //if (e.ChartElement is ChartArea)
            //{
            //    ChartArea area = e.ChartElement as ChartArea;
            //    Graphics g = e.ChartGraphics.Graphics;

            //    // Convert Y value to pixel position
            //    double pixelPosition = area.AxisY.ValueToPixelPosition(1.5);

            //    // Draw a line at Y = 2
            //    g.DrawLine(new Pen(Color.Blue, 2), area.Position.X, (float)pixelPosition, area.Position.Right, (float)pixelPosition);
            //}
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
