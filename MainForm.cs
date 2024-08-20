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
                Point location = screens[1].Bounds.Location;
                this.Left = location.X;
                this.Top = 100;
                this.WindowState = FormWindowState.Maximized;
            }

            CsvData csvData = new CsvData();
            csvData.ReadCsvData(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\data.csv");

            InitialChartSetup();
            MapDataPointsToChart(csvData);
        }

        private void InitialChartSetup()
        {
            Chart chart = chart1;
            //chart.Dock = DockStyle.Fill;

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
            chart.ChartAreas.Add(chartArea1);
            chart.ChartAreas.Add(chartArea2);
            chart.ChartAreas.Add(chartArea3);
            chart.ChartAreas.Add(chartArea4);
            #endregion

            #region -------------------- Legends --------------------
            Legend legend1 = new Legend {
                Name = "Legend1",
                DockedToChartArea = "ChartArea1",
                Docking = Docking.Left,
                IsDockedInsideChartArea = true,
                LegendStyle = LegendStyle.Row,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Legend legend2 = new Legend
            {
                Name = "Legend2",
                DockedToChartArea = "ChartArea2",
                Docking = Docking.Left,
                IsDockedInsideChartArea = true,
                LegendStyle = LegendStyle.Row,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Legend legend3 = new Legend
            {
                Name = "Legend3",
                DockedToChartArea = "ChartArea2",
                Docking = Docking.Left,
                IsDockedInsideChartArea = true,
                LegendStyle = LegendStyle.Row,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Legend legend4 = new Legend
            {
                Name = "Legend4",
                DockedToChartArea = "ChartArea3",
                Docking = Docking.Left,
                IsDockedInsideChartArea = true,
                LegendStyle = LegendStyle.Row,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Legend legend5 = new Legend
            {
                Name = "Legend5",
                DockedToChartArea = "ChartArea4",
                Docking = Docking.Left,
                IsDockedInsideChartArea = true,
                LegendStyle = LegendStyle.Row,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            chart.Legends.Add(legend1);
            chart.Legends.Add(legend2);
            chart.Legends.Add(legend3);
            chart.Legends.Add(legend4);
            chart.Legends.Add(legend5);
            #endregion

            #region -------------------- Misc --------------------
            foreach (ChartArea ca in chart.ChartAreas)
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
            var series1 = new Series
            {
                Name = "Rpm",
                ChartArea = "ChartArea1",
                Legend = "Legend1",
                Color = ColorTranslator.FromHtml("#FF5722"),
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
                series1.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListRpm[i]);
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 1000;

            var series2 = new Series
            {
                Name = "ECT",
                ChartArea = "ChartArea2",
                Legend = "Legend2",
                Color = ColorTranslator.FromHtml("#4CAF50"),
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };
            var series3 = new Series
            {
                Name = "Oil Temp",
                ChartArea = "ChartArea2",
                Legend = "Legend3",
                Color = ColorTranslator.FromHtml("#FFC107"),
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
            {
                series2.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListECT[i]);
                series3.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilTemp[i]);
            }
            chart1.ChartAreas["ChartArea2"].AxisY.Interval = 10;


            var series4 = new Series
            {
                Name = "Oil Temp2",
                ChartArea = "ChartArea3",
                Legend = "Legend4",
                Color = ColorTranslator.FromHtml("#2196F3"),
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
                series4.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilTemp[i]);
            chart1.ChartAreas["ChartArea3"].AxisY.Interval = 10;


            var series5 = new Series
            {
                Name = "Oil Pressure",
                ChartArea = "ChartArea4",
                Legend = "Legend5",
                Color = ColorTranslator.FromHtml("#FFC107"),
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };
            for (int i = 0; i < csvData.ListTime.Count; i++)
                series5.Points.AddXY(double.Parse(csvData.ListTime[i]), csvData.ListOilPressure[i]);
            chart1.ChartAreas["ChartArea4"].AxisY.Interval = 10;


            Chart chart = chart1;
            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);
            chart.Series.Add(series5);

            foreach (ChartArea ca in chart1.ChartAreas)
            {
                ca.AxisX.Interval = 5; // Seconds ~ Probably want 10 seconds with actual data
                ca.AxisX.MajorGrid.Interval = 1; // Which tick the major grid line will appear on
            }
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
                            BorderColor = Color.Red,
                            BorderWidth = 1,
                            BorderDashStyle = ChartDashStyle.Solid
                        });
                    }

                    // Update legend with current value on yAxis
                    foreach (Series series in chart.Series)
                    {
                        DataPoint matchingPoint = series.Points.FirstOrDefault(x => x.XValue == Math.Round(xValue, 1));
                        series.LegendText = series.Name + " : " + matchingPoint?.YValues.FirstOrDefault();
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
                                toolTip1.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], chart, pos.X, pos.Y - 15);
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


        private void toolStripMenuItem_Theme_Click(object sender, EventArgs e)
        {
            DoTheme();
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
    }
}
