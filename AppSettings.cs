
namespace WRD_DataAnalysis
{
    public class AppSettings
    {
        //private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => new AppSettings());
        private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => LoadSettings());

        public static AppSettings Instance => instance.Value;

        public int Chart1DataPoint { get; set; }
        public int Chart2DataPoint { get; set; }
        public int Chart3DataPoint { get; set; }
        public int Chart4DataPoint { get; set; }

        private AppSettings() { }

        // Load settings from file
        private static AppSettings LoadSettings()
        {
            if (File.Exists("AppSettings.json"))
            {
                var json = File.ReadAllText("AppSettings.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AppSettings>(json);
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
}
