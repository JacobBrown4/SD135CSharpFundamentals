using _09_APIs.Models;
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
            HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/1").Result;

            //if code is 200, Ok, go ahead and display it
            if (response.IsSuccessStatusCode)
            {
                // Accessing the responses content, display as a simple string, but still async

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                // AspNet.WebApi.Client package lets us intrepret the JSON object into a similar C# one
                Person personResponse = response.Content.ReadAsAsync<Person>().Result;

                Console.WriteLine($"\n{personResponse.Name} has {personResponse.EyeColor} eyes");

                foreach(string vehicleUrl in personResponse.Vehicles)
                {
                    HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehicleUrl).Result;

                    //Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);
                    Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicle.Name);
                }
                Console.WriteLine() ;
            }


            SWAPIService swapi = new SWAPIService();
            Console.Write("Give me an Id: ");
            int id = 4; //int.Parse(Console.ReadLine());
            Person person = swapi.GetPersonByIdAsync(id).Result;

            if(person != null)
            {
                Console.WriteLine(person.Name);
                foreach(string vehicleUrl in person.Vehicles)
                {
                    Console.WriteLine(swapi.GetByUrlAsync<Vehicle>(vehicleUrl).Result.Name);
                }
            }

            SearchResult<Person> skywalkers = swapi.GetPersonSearchAsync("w").Result;
            Console.WriteLine(skywalkers.Count);
            foreach(Person personResult in skywalkers.Results.OrderBy(x=>x.LastName).ThenBy(y=>y.Name))
            {
                Console.WriteLine(personResult.Name);
            }
            Console.WriteLine() ;

            SearchResult<Vehicle> vehicles = swapi.GetVehicleSearchAsync("speed").Result;
            foreach(Vehicle vehicle in vehicles.Results)
            {
                Console.WriteLine(vehicle.Name);
                Console.WriteLine(vehicle.Manufacturer);
            }


            Console.ReadKey();
        }
    }
}
