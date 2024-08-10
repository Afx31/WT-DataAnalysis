using System.Windows.Forms.DataVisualization.Charting;

namespace WRD_DataAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormLogic();
        }

        public void FormLogic()
        {
            //var chartSeries = chart1.Series;

            var series = new Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(series);

            for (int i = 0; i < 10; i++)
                series.Points.AddXY(i, Math.Sin(i * 0.1));
        }
    }
}
