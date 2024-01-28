using System.Text.Json;
using System.Text.Json.Serialization;

namespace MealPlannerUI.ConfigManager
{
    public class ConfigManager
    {
        public readonly string apiUrl;
        private static readonly object _lock = new();
        private static ConfigManager _instance;

        private ConfigManager()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var configPath = Path.Combine(appPath, "MealPlannerConfig.json");
            var rawConfig = File.ReadAllText(configPath);
            //var jsonConfig = JsonSerializer.Deserialize<ConfigManager>(rawConfig);
            JsonDocument jsonConfig = JsonDocument.Parse(rawConfig);
            var root = jsonConfig.RootElement;

            apiUrl = root.GetProperty("ApiUrl").GetString();
        }

        public static ConfigManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new ConfigManager();
                    return _instance;
                }
            }
            else { return _instance; }
        }
    }
}
