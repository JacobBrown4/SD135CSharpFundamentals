using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _09_APIs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // API's Application Programming Interface

            HttpClient httpClient = new HttpClient();

            // Asynchronous request, everything prior was synchronous
            // Idk how long the response will take, so I'm going to tell it it's okay to wait for a reply
            HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/4").Result;

            //if code is 200, Ok, go ahead and display it
            if (response.IsSuccessStatusCode)
            {
                // Accessing the responses content, display as a simple string, but still async
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadKey();
            }
        }
    }
}
