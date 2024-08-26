
namespace WRD_DataAnalysis
{
    public class AppSettings
    {
        //private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => new AppSettings());
        private static readonly Lazy<AppSettings> instance = new Lazy<AppSettings>(() => LoadSettings());

        public static AppSettings Instance => instance.Value;

        public List<int> Chart1DataPoints { get; set; } = new List<int>();
        public List<int> Chart2DataPoints { get; set; } = new List<int>();
        public List<int> Chart3DataPoints { get; set; } = new List<int>();
        public List<int> Chart4DataPoints { get; set; } = new List<int>();

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
}
