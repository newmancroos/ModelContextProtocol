using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace MCP_Server;

[McpServerToolType]
public class WeatherTool
{
    public readonly List<WeatherModel> weatherData = new()
    {
        new WeatherModel { City = "New York", Temperature = "15°C", Condition = "Cloudy" },
        new WeatherModel { City = "Los Angeles", Temperature = "22°C", Condition = "Sunny" },
        new WeatherModel { City = "Chicago", Temperature = "10°C", Condition = "Rainy" }
    };

    [McpServerTool(Name = "get_weather"), Description("Get the current weather for a specified city.")]
    public async Task<WeatherModel?> GetWeatherAsync(string city)
    {
        // Simulate an asynchronous operation
        return weatherData.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }
}
public class WeatherModel
{
    public string City { get; internal set; }
    public string Temperature { get; internal set; }
    public string Condition { get; internal set; }
}

