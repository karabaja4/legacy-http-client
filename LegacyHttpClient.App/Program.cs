using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LegacyHttpClient.App
{
    class Program
    {
        private static Library.HttpClient.LegacyHttpClient _client;
        static async Task Main(string[] args)
        {
            _client = new Library.HttpClient.LegacyHttpClient();

            // GET
            var getUrl = "https://httpbin.org/ip";
            Console.WriteLine($"GET {getUrl}");
            var getResult = await _client.Send("GET", getUrl);
            Console.WriteLine($"{getUrl} returned {getResult.StatusCode}");
            Console.WriteLine(getResult.ResponseText);

            Console.WriteLine("***");

            // POST
            var postUrl = "https://httpbin.org/post";
            var postJson = JsonConvert.SerializeObject(new
            {
                Input = "hello world"
            });
            Console.WriteLine($"POST {postUrl}");
            using (var postContent = new StringContent(postJson, Encoding.UTF8, "application/json"))
            {
                var postResult = await _client.Send("POST", postUrl, postContent);
                Console.WriteLine($"{postUrl} returned {postResult.StatusCode}");
                Console.WriteLine(postResult.ResponseText);
            }

            Console.WriteLine("***");
            Console.ReadKey();

        }
    }
}
