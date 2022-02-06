using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace escreverObjetoComoJson
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast);

            Console.WriteLine(jsonString);

            codigoSincronoParaCriarArquivoJSON(weatherForecast);

            FileStream createStream = await codigoAssincrono();
        }
        
        private static void codigoSincronoParaCriarArquivoJSON(WeatherForecast weatherForecast)
        {
            string fileName = "WeatherForecast.json";
            string jsonStringFile = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonStringFile);
        }

        private static async Task<FileStream> codigoAssincrono()
        {
            var weatherForecastAssincrono = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-11"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string fileName = "WeatherForecastAssincrono.json";
            FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weatherForecastAssincrono);
            await createStream.DisposeAsync();

            Console.WriteLine(File.ReadAllText(fileName));
            return createStream;
        }

    }
}
