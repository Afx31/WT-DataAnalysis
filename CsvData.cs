namespace WT_DataAnalysis;

public class CsvData
{
    #region Properties
    private string _fileDate;
    public string FileDate
    {
        get => _fileDate;
        set => _fileDate = value;
    }

    private string _track;
    public string Track
    {
        get => _track;
        set => _track = value;
    }

    private string[] _headings = new string[20];
    public string[] HeadingsArr
    {
        get => _headings;
        set => _headings = value;
    }

    private string[] _headingsDataTypes = new string[20];
    public string[] HeadingsDataTypes
    {
        get => _headingsDataTypes;
        set => _headingsDataTypes = value;
    }

    private List<double> _listHertzTime = new List<double>();
    public List<double> ListHertzTime
    {
        get => _listHertzTime;
        set => _listHertzTime = value;
    }

    private List<double> _listRpm = new List<double>();
    public List<double> ListRpm
    {
        get => _listRpm;
        set => _listRpm = value;
    }

    private List<double> _listSpeed = new List<double>();
    public List<double> ListSpeed
    {
        get => _listSpeed;
        set => _listSpeed = value;
    }

    private List<double> _listGear = new List<double>();
    public List<double> ListGear
    {
        get => _listGear;
        set => _listGear = value;
    }

    private List<double> _listVoltage = new List<double>();
    public List<double> ListVoltage
    {
        get => _listVoltage;
        set => _listVoltage = value;
    }

    private List<double> _listIAT = new List<double>();
    public List<double> ListIAT
    {
        get => _listIAT;
        set => _listIAT = value;
    }

    private List<double> _listECT = new List<double>();
    public List<double> ListECT
    {
        get => _listECT;
        set => _listECT = value;
    }

    private List<double> _listTPS = new List<double>();
    public List<double> ListTPS
    {
        get => _listTPS;
        set => _listTPS = value;
    }

    private List<double> _listMAP = new List<double>();
    public List<double> ListMAP
    {
        get => _listMAP;
        set => _listMAP = value;
    }

    private List<double> _listLambdaRatio = new List<double>();
    public List<double> ListLambdaRatio
    {
        get => _listLambdaRatio;
        set => _listLambdaRatio = value;
    }

    private List<double> _listOilTemperature = new List<double>();
    public List<double> ListOilTemperature
    {
        get => _listOilTemperature;
        set => _listOilTemperature = value;
    }

    private List<double> _listOilPressure = new List<double>();
    public List<double> ListOilPressure
    {
        get => _listOilPressure;
        set => _listOilPressure = value;
    }

    private List<double> _listLat = new List<double>();
    public List<double> ListLat
    {
        get => _listLat;
        set => _listLat = value;
    }

    private List<double> _listLon = new List<double>();
    public List<double> ListLon
    {
        get => _listLon;
        set => _listLon = value;
    }

    //private List<Tuple<double, double>> _listLatLon = new List<Tuple<double, double>>();
    //public List<Tuple<double, double>> ListLatLon
    //{
    //    get => _listLatLon;
    //    set => _listLatLon = value;
    //}

    private List<int> _listLapCount = new List<int>();
    public List<int> ListLapCount
    {
        get => _listLapCount;
        set => _listLapCount = value;
    }
    #endregion

    public CsvData()
    {
    }

    public void ReadCsvData(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            int lineCounter = 1;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (lineCounter == 1)
                {
                    _fileDate = values[0];
                    _track = values[1];
                    lineCounter++;
                }
                else if (lineCounter == 2)
                {
                    _headings = values;
                    lineCounter++;
                }
                else if (lineCounter == 3)
                {
                    _headingsDataTypes = values;
                    lineCounter++;
                }
                else
                {
                    _listHertzTime.Add(double.Parse(values[0]));
                    _listRpm.Add(double.Parse(values[1]));
                    _listSpeed.Add(double.Parse(values[2]));
                    _listGear.Add(double.Parse(values[3]));
                    _listVoltage.Add(double.Parse(values[4]));
                    _listIAT.Add(double.Parse(values[5]));
                    _listECT.Add(double.Parse(values[6]));
                    _listTPS.Add(double.Parse(values[7]));
                    _listMAP.Add(double.Parse(values[8]));
                    _listLambdaRatio.Add(double.Parse(values[9]));
                    _listOilTemperature.Add(double.Parse(values[10]));
                    _listOilPressure.Add(double.Parse(values[11]));
                    //_listLatLon.Add(new Tuple<double, double>(double.Parse(values[12]), double.Parse(values[13])));
                    _listLat.Add(double.Parse(values[12]));
                    _listLon.Add(double.Parse(values[13]));
                    _listLapCount.Add(int.Parse(values[14]));
                }
            }
        }
    }

    public double[] GetDataPointsList(DataValues dataValue)
    {
        switch (dataValue)
        {
            case DataValues.RPM:
                return ListRpm.ToArray();
            case DataValues.Speed:
                return ListSpeed.ToArray();
            case DataValues.Gear:
                return ListGear.ToArray();
            case DataValues.Voltage:
                return ListVoltage.ToArray();
            case DataValues.IAT:
                return ListIAT.ToArray();
            case DataValues.ECT:
                return ListECT.ToArray();
            case DataValues.TPS:
                return ListTPS.ToArray();
            case DataValues.MAP:
                return ListMAP.ToArray();
            case DataValues.LambdaRatio:
                return ListLambdaRatio.ToArray();
            case DataValues.OilTemperature:
                return ListOilTemperature.ToArray();
            case DataValues.OilPressure:
                return ListOilPressure.ToArray();
            default:
                return null;
        }
    }

    public int GetDataPointsInterval(DataValues dataValue)
    {
        switch (dataValue)
        {
            case DataValues.RPM:
                return 1000;
            case DataValues.Speed:
                return 20;
            case DataValues.Gear:
                return 1;
            case DataValues.Voltage:
                return 0;
            case DataValues.IAT:
                return 10;
            case DataValues.ECT:
                return 10;
            case DataValues.TPS:
                return 10;
            case DataValues.MAP:
                return 10;
            case DataValues.LambdaRatio:
                return 10;
            case DataValues.OilTemperature:
                return 10;
            case DataValues.OilPressure:
                return 10;
            default:
                return 0;
        }
    }

    public enum DataValues
    {
        Empty = 0,
        RPM = 1,
        Speed = 2,
        Gear = 3,
        Voltage = 4,
        IAT = 5,
        ECT = 6,
        TPS = 7,
        MAP = 8,
        LambdaRatio = 9,
        OilTemperature = 10,
        OilPressure = 11
    }
}
