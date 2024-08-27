

using System.Windows.Forms.VisualStyles;

namespace WRD_DataAnalysis
{
    public class CsvData
    {
        #region Properties
        private string[] _headings = new string[12];
        public string[] HeadingsArr
        {
            get => _headings;
            set => _headings = value;
        }

        private string[] _headingsDataTypes = new string[12];
        public string[] HeadingsDataTypes
        {
            get => _headingsDataTypes;
            set => _headingsDataTypes = value;
        }

        private List<string> _listTime = new List<string>();
        public List<string> ListTime
        {
            get => _listTime;
            set => _listTime = value;
        }

        private List<string> _listRpm = new List<string>();
        public List<string> ListRpm
        {
            get => _listRpm;
            set => _listRpm = value;
        }

        private List<string> _listSpeed = new List<string>();
        public List<string> ListSpeed
        {
            get => _listSpeed;
            set => _listSpeed = value;
        }

        private List<string> _listGear = new List<string>();
        public List<string> ListGear
        {
            get => _listGear;
            set => _listGear = value;
        }

        private List<string> _listVoltage = new List<string>();
        public List<string> ListVoltage
        {
            get => _listVoltage;
            set => _listVoltage = value;
        }

        private List<string> _listIAT = new List<string>();
        public List<string> ListIAT
        {
            get => _listIAT;
            set => _listIAT = value;
        }

        private List<string> _listECT = new List<string>();
        public List<string> ListECT
        {
            get => _listECT;
            set => _listECT = value;
        }

        private List<string> _listTPS = new List<string>();
        public List<string> ListTPS
        {
            get => _listTPS;
            set => _listTPS = value;
        }

        private List<string> _listMAP = new List<string>();
        public List<string> ListMAP
        {
            get => _listMAP;
            set => _listMAP = value;
        }

        private List<string> _listLambdaRatio = new List<string>();
        public List<string> ListLambdaRatio
        {
            get => _listLambdaRatio;
            set => _listLambdaRatio = value;
        }

        private List<string> _listOilTemperature = new List<string>();
        public List<string> ListOilTemperature
        {
            get => _listOilTemperature;
            set => _listOilTemperature = value;
        }

        private List<string> _listOilPressure = new List<string>();
        public List<string> ListOilPressure
        {
            get => _listOilPressure;
            set => _listOilPressure = value;
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
                        _headings = values;
                        lineCounter++;
                    }
                    else if (lineCounter == 2)
                    {
                        _headingsDataTypes = values;
                        lineCounter++;
                    }
                    else
                    {
                        _listTime.Add(values[0]);
                        _listRpm.Add(values[1]);
                        _listSpeed.Add(values[2]);
                        _listGear.Add(values[3]);
                        _listVoltage.Add(values[4]);
                        _listIAT.Add(values[5]);
                        _listECT.Add(values[6]);
                        _listTPS.Add(values[7]);
                        _listMAP.Add(values[8]);
                        _listLambdaRatio.Add(values[9]);
                        _listOilTemperature.Add(values[10]);
                        _listOilPressure.Add(values[11]);
                    }
                }
            }
        }

        public List<string> GetDataPointsList(DataValues dataValue)
        {
            switch (dataValue)
            {
                case DataValues.RPM:
                    return ListRpm;
                case DataValues.Speed:
                    return ListSpeed;
                case DataValues.Gear:
                    return ListGear;
                case DataValues.Voltage:
                    return ListVoltage;
                case DataValues.IAT:
                    return ListIAT;
                case DataValues.ECT:
                    return ListECT;
                case DataValues.TPS:
                    return ListTPS;
                case DataValues.MAP:
                    return ListMAP;
                case DataValues.LambdaRatio:
                    return ListLambdaRatio;
                case DataValues.OilTemperature:
                    return ListOilTemperature;
                case DataValues.OilPressure:
                    return ListOilPressure;
                default:
                    return new List<string>();
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
}
