using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ChatAgent_Semantic_Kernel;

public class WeatherPlugin
{
    private readonly List<WeatherModel> _weatherData = new List<WeatherModel>
    {
        new WeatherModel { City = "New York", Temperature = 22, Condition = "Sunny" },
        new WeatherModel { City = "Los Angeles", Temperature = 28, Condition = "Sunny" },
        new WeatherModel { City = "Chicago", Temperature = 18, Condition = "Cloudy" }
    };


    [KernelFunction("get_weather")]
    [Description("Gets the current weather for a specified city")]
    public async Task<WeatherModel?> GetWeatherAsync(string city)
    {
        return _weatherData.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }

}

public class WeatherModel
{
    public string  City { get; internal set; }
    public int Temperature { get; internal set; }
    public string Condition { get; internal set; }
}