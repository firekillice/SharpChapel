using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tower
{
    internal class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public Dictionary<int, int> WeatherForecasts { get; set; }
    }

    [Serializable]
    public class MyObject
    {
        public int n1 { get; set; }
        public int n2 { get; set; }
        public string str { get; set; }
    }

    internal static class Serialize
    {
        public static void FirstView()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                WeatherForecasts = new Dictionary<int, int> { {1,2 },{ 3, 2 },{ 4, 2 } }
            };

            var json = JsonSerializer.Serialize(weatherForecast);
            Console.WriteLine(json);   
            var wf = JsonSerializer.Deserialize<WeatherForecast>(json);

            SerializableObj();
        }

        public static void SerializableObj()
        {
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "一些字符串";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create,
            FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }
    }
}
