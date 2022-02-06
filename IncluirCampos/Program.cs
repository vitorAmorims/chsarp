using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace IncluirCampos
{
    public class Forecast
    {
        public DateTime Date;
        public int TemperatureC;
        public string Summary;
    }

    public class Forecast2
    {
        public DateTime Date;
        public int TemperatureC;
        public string Summary;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var json =
                @"{""Date"":""2020-09-06T11:31:01.923395"",""TemperatureC"":""-1"",""Summary"":""Cold""} ";
            Console.WriteLine($"Input JSON: {json}");

            var options = new JsonSerializerOptions { WriteIndented = true };
            var forecast = JsonSerializer.Deserialize<Forecast>(json, options);

            Console.WriteLine($"forecast.Date: {forecast.Date.Date}");
            Console.WriteLine($"forecast.TemperatureC: {forecast.TemperatureC}");
            Console.WriteLine($"forecast.Summary: {forecast.Summary}");

            var roundTrippedJson = JsonSerializer.Serialize<Forecast>(forecast);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");

            var forecast2 = JsonSerializer.Deserialize<Forecast2>(json);
            forecast2.Date = DateTime.Now;
            forecast2.TemperatureC = 35;
            forecast2.Summary = "Summer";

            Console.WriteLine($"forecast2.Date: {forecast2.Date}");
            Console.WriteLine($"forecast2.TemperatureC: {forecast2.TemperatureC}");
            Console.WriteLine($"forecast2.Summary: {forecast2.Summary}");
        }
    }
}
