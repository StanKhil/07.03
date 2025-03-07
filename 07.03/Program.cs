using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private const string ApiKey = "1ca9829211b917bfa5934a9d15301d40";

    static async Task Main()
    {
        Console.Write("Введіть назву міста: ");
        string city = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(city))
        {
            Console.WriteLine("Некоректне місто.");
            return;
        }

        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric&lang=ua";
        using HttpClient client = new HttpClient();

        try
        {
            string json = await client.GetStringAsync(url);
            JsonDocument doc = JsonDocument.Parse(json);
            double temperature = doc.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
            Console.WriteLine($"Температура в {city}: {temperature}°C");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}