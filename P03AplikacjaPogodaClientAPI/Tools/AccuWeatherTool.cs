using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P03AplikacjaPogodaClientAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.Tools
{
    public class AccuWeatherTool
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplate_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language=pl-PL";
        private const string currentconditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language=pl-PL";
        private string api_key;

        //private const string api_key = "NNcO2EHMrt9GJg6u55uwxMKiLyfuBDv6";

        public AccuWeatherTool()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>();
                //.SetBasePath(Directory.GetCurrentDirectory()) //odwołanie do pliku config
                //.AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            api_key = configuration["api_key"];
                
        }
        public async Task<City[]?> GetLocation(string locationName)
        {
            string url = base_url + "/" + string.Format(autocomplate_endpoint, api_key, locationName);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                City[]? cities = JsonConvert.DeserializeObject<City[]>(json);

                return cities;
            }
        }

        public async Task<Weather?> GetCurrentCondition(string cityKey)
        {
            string url = base_url + "/" + string.Format(currentconditions_endpoint, cityKey, api_key);

            using (HttpClient client = new HttpClient())
            {
                var respone = await client.GetAsync(url);
                string json = await respone.Content.ReadAsStringAsync();

                Weather[]? temperature = JsonConvert.DeserializeObject<Weather[]>(json);

                return temperature?.FirstOrDefault();
            }
        }
    }
}
