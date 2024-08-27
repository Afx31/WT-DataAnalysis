
using static WRD_DataAnalysis.ChartDataConfig;

namespace WRD_DataAnalysis
{
    public class AppSettings
    {
        //private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => new AppSettings());
        private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => LoadSettings());

        public static AppSettings Instance => instance.Value;

        public List<ChartDataConfig> Chart1DataPoints { get; set; } = new List<ChartDataConfig>();
        public List<ChartDataConfig> Chart2DataPoints { get; set; } = new List<ChartDataConfig>();
        public List<ChartDataConfig> Chart3DataPoints { get; set; } = new List<ChartDataConfig>();
        public List<ChartDataConfig> Chart4DataPoints { get; set; } = new List<ChartDataConfig>();
        public int CursorLineColour { get; set; }

        private AppSettings() { }

        // Load settings from file
        private static AppSettings LoadSettings()
        {
            if (File.Exists("AppSettings.json"))
            {
                var json = File.ReadAllText("AppSettings.json");
                var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<AppSettings>(json);

                return settings ?? new AppSettings();
            }

            return new AppSettings();
        }

        // Save settings file
        public static void SaveSettings()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Instance, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("AppSettings.json", json);
        }
    }

    public class ChartDataConfig
    {
        public int DataPoint { get; set; }
        public int LineColour { get; set; }

        public static string GetColourValue(Colours colour)
        {
            switch (colour)
            {
                case Colours.White:
                    return "#FFFFFF";
                case Colours.Red:
                    return "#FF5722";
                case Colours.Green:
                    return "#4CAF50";
                case Colours.Yellow:
                    return "#FFC107";
                case Colours.Blue:
                    return "#2196F3";
                default:
                    return "#FFFFFF";
            }
        }

        public enum Colours
        {
            Empty = 0,
            White = 1,
            Red = 2,
            Green = 3,
            Yellow = 4,
            Blue = 5,
            Colour6 = 6,
            Colour7 = 7,
            Colour8 = 8,
            Colour9 = 9,
            Colour10 = 10
        }
    }
}
