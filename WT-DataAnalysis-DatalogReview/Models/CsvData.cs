namespace WT_DataAnalysis_DatalogReview.Models;

public class CsvData
{
    #region Properties
    public static readonly int ValueCounter = 27;

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

    private List<double> _listMIL = new List<double>();
    public List<double> ListMIL
    {
        get => _listMIL;
        set => _listMIL = value;
    }

    private List<double> _listVTS = new List<double>();
    public List<double> ListVTS
    {
        get => _listVTS;
        set => _listVTS = value;
    }

    private List<double> _listCL = new List<double>();
    public List<double> ListCL
    {
        get => _listCL;
        set => _listCL = value;
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

    private List<double> _listAnalog0 = new List<double>();
    public List<double> ListAnalog0
    {
        get => _listAnalog0;
        set => _listAnalog0 = value;
    }

    private List<double> _listAnalog1 = new List<double>();
    public List<double> ListAnalog1
    {
        get => _listAnalog1;
        set => _listAnalog1 = value;
    }

    private List<double> _listAnalog2 = new List<double>();
    public List<double> ListAnalog2
    {
        get => _listAnalog2;
        set => _listAnalog2 = value;
    }

    private List<double> _listAnalog3 = new List<double>();
    public List<double> ListAnalog3
    {
        get => _listAnalog3;
        set => _listAnalog3 = value;
    }

    private List<double> _listAnalog4 = new List<double>();
    public List<double> ListAnalog4
    {
        get => _listAnalog4;
        set => _listAnalog4 = value;
    }

    private List<double> _listAnalog5 = new List<double>();
    public List<double> ListAnalog5
    {
        get => _listAnalog5;
        set => _listAnalog5 = value;
    }

    private List<double> _listAnalog6 = new List<double>();
    public List<double> ListAnalog6
    {
        get => _listAnalog6;
        set => _listAnalog6 = value;
    }

    private List<double> _listAnalog7 = new List<double>();
    public List<double> ListAnalog7
    {
        get => _listAnalog7;
        set => _listAnalog7 = value;
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

    private List<double> _listSessionStartTimeMs = new List<double>();
    public List<double> ListSessionStartTimeMs
    {
        get => _listSessionStartTimeMs;
        set => _listSessionStartTimeMs = value;
    }

    private List<double> _listLapIndex = new List<double>();
    public List<double> ListLapIndex
    {
        get => _listLapIndex;
        set => _listLapIndex = value;
    }

    private List<double> _listLapStartTimeMs = new List<double>();
    public List<double> ListLapStartTimeMs
    {
        get => _listLapStartTimeMs;
        set => _listLapStartTimeMs = value;
    }

    private Dictionary<double, double> _dictLapTimes = new Dictionary<double, double>();
    public Dictionary<double, double> DictLapTimes
    {
        get => _dictLapTimes;
        set => _dictLapTimes = value;
    }

    private (double, double) _bestLapTime;
    public (double, double) BestLapTime
    {
        get => _bestLapTime;
        set => _bestLapTime = value;
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
                    try
                    {
                        // Debugging
                        //if (values[0] == "00.1")
                        //{
                        //    int i = 0;
                        //}
                        _listHertzTime.Add(double.Parse(values[0]));
                        _listRpm.Add(double.Parse(values[1]));
                        _listSpeed.Add(double.Parse(values[2]));
                        _listGear.Add(double.Parse(values[3]));
                        _listVoltage.Add(double.Parse(values[4]));
                        _listIAT.Add(double.Parse(values[5]));
                        _listECT.Add(double.Parse(values[6]));
                        _listMIL.Add(double.Parse(values[7]));
                        _listVTS.Add(double.Parse(values[8]));
                        _listCL.Add(double.Parse(values[9]));
                        _listTPS.Add(double.Parse(values[10]));
                        _listMAP.Add(double.Parse(values[11]));
                        _listInj.Add(double.Parse(values[12]));
                        _listIgn.Add(double.Parse(values[13]));
                        _listLambdaRatio.Add(double.Parse(values[14]));
                        _listKnockCounter.Add(double.Parse(values[15]));
                        _listTargetCamAngle.Add(double.Parse(values[16]));
                        _listActualCamAngle.Add(double.Parse(values[17]));
                        _listAnalog0.Add(double.Parse(values[18]));
                        _listAnalog1.Add(double.Parse(values[19]));
                        _listAnalog2.Add(double.Parse(values[20]));
                        _listAnalog3.Add(double.Parse(values[21]));
                        _listAnalog4.Add(double.Parse(values[22]));
                        _listAnalog5.Add(double.Parse(values[23]));
                        _listAnalog6.Add(double.Parse(values[24]));
                        _listAnalog7.Add(double.Parse(values[25]));
                        _listEthanolInput1.Add(double.Parse(values[26]));
                        _listEthanolInput2.Add(double.Parse(values[27]));
                        _listEthanolInput3.Add(double.Parse(values[28]));
                        _dictLatLon.Add(double.Parse(values[0]), (double.Parse(values[29]), double.Parse(values[30])));

                        if (!previousLapCounter.Equals(values[32]))
                        {
                            _dictLapData.Add(int.Parse(values[32]), (double.Parse(values[0]), 0.0));
                            previousLapCounter = values[32];

                            // TODO - fix this hack
                            // Default first one to 0.1 hertz start, works better with the chart
                            if (_dictLapData.Count == 1)
                                _dictLapData[0] = (0.1, 0.0);
                        }

                        _listSessionStartTimeMs.Add(double.Parse(values[31]));
                        _listLapIndex.Add(double.Parse(values[32]));
                        _listLapStartTimeMs.Add(double.Parse(values[33]));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Reading in data. Hz: " + values[0] + ". \n\n" + ex.ToString(), "Error: Reading in data.");
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
            case DataValues.MIL:
                return ListMIL.ToArray();
            case DataValues.VTS:
                return ListVTS.ToArray();
            case DataValues.CL:
                return ListCL.ToArray();
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
            case DataValues.Analog0:
                return ListAnalog0.ToArray();
            case DataValues.Analog1:
                return ListAnalog1.ToArray();
            case DataValues.Analog2:
                return ListAnalog2.ToArray();
            case DataValues.Analog3:
                return ListAnalog3.ToArray();
            case DataValues.Analog4:
                return ListAnalog4.ToArray();
            case DataValues.Analog5:
                return ListAnalog5.ToArray();
            case DataValues.Analog6:
                return ListAnalog6.ToArray();
            case DataValues.Analog7:
                return ListAnalog7.ToArray();
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

    public double GetDataValueMaxValue(int dataValue)
    {
        switch (dataValue)
        {
            case 0:
                return ListRpm.Max();
            case 1:
                return ListSpeed.Max();
            case 2:
                return ListGear.Max();
            case 3:
                return ListVoltage.Max();
            case 4:
                return ListIAT.Max();
            case 5:
                return ListECT.Max();
            case 6:
                return ListMIL.Max();
            case 7:
                return ListVTS.Max();
            case 8:
                return ListCL.Max();
            case 9:
                return ListTPS.Max();
            case 10:
                return ListMAP.Max();
            case 11:
                return ListInj.Max();
            case 12:
                return ListIgn.Max();
            case 13:
                return ListLambdaRatio.Max();
            case 14:
                return ListKnockCounter.Max();
            case 15:
                return ListTargetCamAngle.Max();
            case 16:
                return ListActualCamAngle.Max();
            case 17:
                return ListAnalog0.Max();
            case 18:
                return ListAnalog1.Max();
            case 19:
                return ListAnalog2.Max();
            case 20:
                return ListAnalog3.Max();
            case 21:
                return ListAnalog4.Max();
            case 22:
                return ListAnalog5.Max();
            case 23:
                return ListAnalog6.Max();
            case 24:
                return ListAnalog7.Max();
            case 25:
                return ListEthanolInput1.Max();
            case 26:
                return ListEthanolInput2.Max();
            case 27:
                return ListEthanolInput3.Max();
            default:
                return 0;
        }
    }

    public double GetDataValueCurrentValue(int dataValue, int lookupIndex)
    {
        switch (dataValue)
        {
            case 0:
                return ListRpm[lookupIndex];
            case 1:
                return ListSpeed[lookupIndex];
            case 2:
                return ListGear[lookupIndex];
            case 3:
                return ListVoltage[lookupIndex];
            case 4:
                return ListIAT[lookupIndex];
            case 5:
                return ListECT[lookupIndex];
            case 6:
                return ListMIL[lookupIndex];
            case 7:
                return ListVTS[lookupIndex];
            case 8:
                return ListCL[lookupIndex];
            case 9:
                return ListTPS[lookupIndex];
            case 10:
                return ListMAP[lookupIndex];
            case 11:
                return ListInj[lookupIndex];
            case 12:
                return ListIgn[lookupIndex];
            case 13:
                return ListLambdaRatio[lookupIndex];
            case 14:
                return ListKnockCounter[lookupIndex];
            case 15:
                return ListTargetCamAngle[lookupIndex];
            case 16:
                return ListActualCamAngle[lookupIndex];
            case 17:
                return ListAnalog0[lookupIndex];
            case 18:
                return ListAnalog1[lookupIndex];
            case 19:
                return ListAnalog2[lookupIndex];
            case 20:
                return ListAnalog3[lookupIndex];
            case 21:
                return ListAnalog4[lookupIndex];
            case 22:
                return ListAnalog5[lookupIndex];
            case 23:
                return ListAnalog6[lookupIndex];
            case 24:
                return ListAnalog7[lookupIndex];
            case 25:
                return ListEthanolInput1[lookupIndex];
            case 26:
                return ListEthanolInput2[lookupIndex];
            case 27:
                return ListEthanolInput3[lookupIndex];
            default:
                return 0;
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
            case DataValues.MIL:
            case DataValues.VTS:
            case DataValues.CL:
            case DataValues.TPS:
            case DataValues.MAP:
            case DataValues.INJ:
            case DataValues.IGN:
            case DataValues.LambdaRatio:
            case DataValues.TargetCamAngle:
            case DataValues.ActualCamAngle:
            case DataValues.Analog0:
            case DataValues.Analog1:
            case DataValues.Analog2:
            case DataValues.Analog3:
            case DataValues.Analog4:
            case DataValues.Analog5:
            case DataValues.Analog6:
            case DataValues.Analog7:
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
        MIL = 7,
        VTS = 8,
        CL = 9,
        TPS = 10,
        MAP = 11,
        INJ = 12,
        IGN = 13,
        LambdaRatio = 14,
        KnockCounter = 15,
        TargetCamAngle = 16,
        ActualCamAngle = 17,
        Analog0 = 18,
        Analog1 = 19,
        Analog2 = 20,
        Analog3 = 21,
        Analog4 = 22,
        Analog5 = 23,
        Analog6 = 24,
        Analog7 = 25,
        EthanolInput1 = 26,
        EthanolInput2 = 27,
        EthanolInput3 = 28
    }
}
