using System.Windows.Forms.DataVisualization.Charting;

namespace WT_DataAnalysis.Forms;

public partial class ScatterPlotForm : Form
{
    private CsvData _csvData;

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
        chartArea1.AxisX.MajorTickMark.Enabled = true;
        chartArea1.AxisX.MinorTickMark.Enabled = true;
        chartArea1.AxisX.MajorTickMark.Size = 0.5f;
        chartArea1.AxisX.MinorTickMark.Size = 0.2f;
        chartArea1.Position = new ElementPosition(0, 0, 99.5f, 24);
        chart1.ChartAreas.Add(chartArea1);


    }

    private void MapDataToChart()
    {

    }
}
