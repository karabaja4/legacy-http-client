﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LHC.Library.HttpClient;

namespace LHC.App
{
    class Program
    {
        private static LegacyHttpClient _client;
        private static async Task Main()
        {
            _client = new LegacyHttpClient();

            // GET
            var getUrl = "https://github.com";
            Console.WriteLine($"GET {getUrl}");
            var getResult = await _client.Send("GET", getUrl);
            Console.WriteLine($"{getUrl} returned {getResult.StatusCode}");
            Console.WriteLine(FormatResponse(getResult.ResponseText));

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
                Console.WriteLine(FormatResponse(postResult.ResponseText));
            }

            Console.WriteLine("***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static string FormatResponse(string text)
        {
            if (text.Length > 1000)
            {
                return text.Substring(0, 1000) + "...";
            }
            return text;
        }
    }
}
