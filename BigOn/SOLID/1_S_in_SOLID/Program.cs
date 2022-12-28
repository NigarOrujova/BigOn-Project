using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _1_S_in_SOLID
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new DataProvider();
            var rep = new Reporting();

            var json = await provider.GetData("https://jsonplaceholder.typicode.com");

            await rep.PrintAsConsole(json);
            await rep.PrintAsPdf(json);
        }
    }

    public class DataProvider
    {
        public async Task<string> GetData(string link)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(link);

            var response = await client.GetAsync("/todos");

            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return message;
            }

            return null;
        }
    }

    public class Reporting
    {
        //https://jsonplaceholder.typicode.com
        public async Task PrintAsConsole(string json)
        {
            List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(json);

            foreach (var item in todos)
            {
                Console.WriteLine($"{item.id}, {item.title}");
            }
        }
        public async Task PrintAsPdf(string json)
        {
            List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(json);

            throw new NotImplementedException();
        }
        public async Task PrintAsExcel(string json)
        {
            List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(json);

            throw new NotImplementedException();
        }
    }

    public class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }

    public enum ReportType
    {
        Pdf,
        Console,
        Excel
    }
}
