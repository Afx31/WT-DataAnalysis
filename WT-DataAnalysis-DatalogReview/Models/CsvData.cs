namespace WT_DataAnalysis_DatalogReview.Models;

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

    private List<double> _listInj = new List<double>();
    public List<double> ListInj
    {
        get => _listInj;
        set => _listInj = value;
    }

    private List<double> _listIgn = new List<double>();
    public List<double> ListIgn
    {
        get => _listIgn;
        set => _listIgn = value;
    }

    private List<double> _listLambdaRatio = new List<double>();
    public List<double> ListLambdaRatio
    {
        get => _listLambdaRatio;
        set => _listLambdaRatio = value;
    }

    private List<double> _listKnockCounter = new List<double>();
    public List<double> ListKnockCounter
    {
        get => _listKnockCounter;
        set => _listKnockCounter = value;
    }

    private List<double> _listTargetCamAngle = new List<double>();
    public List<double> ListTargetCamAngle
    {
        get => _listTargetCamAngle;
        set => _listTargetCamAngle = value;
    }

    private List<double> _listActualCamAngle = new List<double>();
    public List<double> ListActualCamAngle
    {
        get => _listActualCamAngle;
        set => _listActualCamAngle = value;
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

    private List<double> _listEthanolInput1 = new List<double>();
    public List<double> ListEthanolInput1
    {
        get => _listEthanolInput1;
        set => _listEthanolInput1 = value;
    }

    private List<double> _listEthanolInput2 = new List<double>();
    public List<double> ListEthanolInput2
    {
        get => _listEthanolInput2;
        set => _listEthanolInput2 = value;
    }

    private List<double> _listEthanolInput3 = new List<double>();
    public List<double> ListEthanolInput3
    {
        get => _listEthanolInput3;
        set => _listEthanolInput3 = value;
    }

    private Dictionary<double, (double, double)> _dictLatLon = new Dictionary<double, (double, double)>();
    public Dictionary<double, (double, double)> DictLatLon
    {
        get => _dictLatLon;
        set => _dictLatLon = value;
    }

    /// <summary>
    /// [Key] = lap itself
    /// [Value] = hertz value at the start & end of that lap
    /// </summary>
    private Dictionary<int, (double, double)> _dictLapData = new Dictionary<int, (double, double)>();
    public Dictionary<int, (double, double)> DictLapData
    {
        get => _dictLapData;
        set => _dictLapData = value;
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
            string previousLapCounter = "-1";

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
                    _listInj.Add(double.Parse(values[9]));
                    _listIgn.Add(double.Parse(values[10]));
                    _listLambdaRatio.Add(double.Parse(values[11]));
                    _listKnockCounter.Add(double.Parse(values[12]));
                    _listTargetCamAngle.Add(double.Parse(values[13]));
                    _listActualCamAngle.Add(double.Parse(values[14]));
                    _listOilTemperature.Add(double.Parse(values[15]));
                    _listOilPressure.Add(double.Parse(values[16]));
                    _listEthanolInput1.Add(double.Parse(values[17]));
                    _listEthanolInput2.Add(double.Parse(values[18]));
                    _listEthanolInput3.Add(double.Parse(values[19]));
                    _dictLatLon.Add(double.Parse(values[0]), (double.Parse(values[20]), double.Parse(values[21])));

                    if (!previousLapCounter.Equals(values[22]))
                    {
                        _dictLapData.Add(int.Parse(values[22]), (double.Parse(values[0]), 0.0));
                        previousLapCounter = values[22];

                        // TODO - fix this hack
                        // Default first one to 0.1 hertz start, works better with the chart
                        if (_dictLapData.Count == 1)
                            _dictLapData[0] = (0.1, 0.0);
                    }
                }
            }
        }

        // Now fill in the end lap hertz
        for (int i = 0; i < _dictLapData.Count; i++)
        {
            var currVal = _dictLapData[i];

            if (i != _dictLapData.Count - 1)
                currVal.Item2 = Math.Round(_dictLapData[i + 1].Item1 - 0.1, 1);
            else
                currVal.Item2 = _listHertzTime.Last();

            _dictLapData[i] = currVal;
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
            case DataValues.INJ:
                return ListInj.ToArray();
            case DataValues.IGN:
                return ListIgn.ToArray();
            case DataValues.LambdaRatio:
                return ListLambdaRatio.ToArray();
            case DataValues.KnockCounter:
                return ListKnockCounter.ToArray();
            case DataValues.TargetCamAngle:
                return ListTargetCamAngle.ToArray();
            case DataValues.ActualCamAngle:
                return ListActualCamAngle.ToArray();
            case DataValues.OilTemperature:
                return ListOilTemperature.ToArray();
            case DataValues.OilPressure:
                return ListOilPressure.ToArray();
            case DataValues.EthanolInput1:
                return ListEthanolInput1.ToArray();
            case DataValues.EthanolInput2:
                return ListEthanolInput2.ToArray();
            case DataValues.EthanolInput3:
                return ListEthanolInput3.ToArray();
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
            case DataValues.IAT:
            case DataValues.ECT:
            case DataValues.TPS:
            case DataValues.MAP:
            case DataValues.INJ:
            case DataValues.IGN:
            case DataValues.LambdaRatio:
            case DataValues.TargetCamAngle:
            case DataValues.ActualCamAngle:
            case DataValues.OilTemperature:
            case DataValues.OilPressure:
            case DataValues.EthanolInput1:
            case DataValues.EthanolInput2:
            case DataValues.EthanolInput3:
                return 10;
            case DataValues.Gear:
                return 1;
            case DataValues.Voltage:
                return 0;
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
        INJ = 9,
        IGN = 10,
        LambdaRatio = 11,
        KnockCounter = 12,
        TargetCamAngle = 13,
        ActualCamAngle = 14,
        OilTemperature = 15,
        OilPressure = 16,
        EthanolInput1 = 17,
        EthanolInput2 = 18,
        EthanolInput3 = 19
    }
}
