using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LerDesserializacaoJson
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public string SummaryField;
        public IList<DateTimeOffset> DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
        public string[] SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }
    
    class Program
    {
        static async Task Main(string[] args)
        {
            string jsonString =
            @"{
            ""Date"": ""2019-08-01T00:00:00-07:00"",
            ""TemperatureCelsius"": 25,
            ""Summary"": ""Hot"",
            ""DatesAvailable"": [
                ""2019-08-01T00:00:00-07:00"",
                ""2019-08-02T00:00:00-07:00"",
                ""2019-08-12T00:00:00-07:00"",
                ""2019-09-02T00:00:00-07:00""
            ],
            ""TemperatureRanges"": {
                ""Cold"": {
                           ""High"": 20,
                           ""Low"": -10
                },
                ""Hot"": {
                           ""High"": 60,
                           ""Low"": 20
                }
            },
            ""SummaryWords"": [
                ""Cool"",
                ""Windy"",
                ""Humid""
            ]
            }
            ";

            WeatherForecast weatherForecast =
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
            foreach (var data in weatherForecast.DatesAvailable)
            {
                System.Console.WriteLine($"Data da avaliação: {data}");
            }

            LerArquivoSincrono();

            await LerArquivoAssincrono();

        }

        private static void LerArquivoSincrono()
        {
            string fileName = "WeatherForecast.json";
            string jsonStringSincrono = File.ReadAllText(fileName);
            WeatherForecast weatherForecastSincrono = JsonSerializer.Deserialize<WeatherForecast>(jsonStringSincrono);

            Console.WriteLine("Leitura Sincrona");
            Console.WriteLine($"Date: {weatherForecastSincrono.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecastSincrono.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecastSincrono.Summary}");
            foreach (var data in weatherForecastSincrono.DatesAvailable)
            {
                System.Console.WriteLine($"Data da avaliação: {data}");
            }
        }

        public static async Task LerArquivoAssincrono()
        {
            string fileName = "WeatherForecast.json";

            using FileStream openStream = File.OpenRead(fileName);

            WeatherForecast weatherForecast = 
                await JsonSerializer.DeserializeAsync<WeatherForecast>(openStream);

            Console.WriteLine("Leitura Assincrona");    
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
        }
    }
}

