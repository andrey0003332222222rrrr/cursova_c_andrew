using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherMyApp.Model;
using WeatherMyApp.ViewModel;
using Newtonsoft;
using Newtonsoft.Json;

namespace WeatherMyApp.ViewModel.Helpers
{
    public class WeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string API_KEY = "dCykZiXqaudOlWnjA80dlbbSo5kY8mCq";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENTCONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = BASE_URL + String.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            return cities;
        }
        public static async Task<CurrentCondition> GetCurrentCondition(string location)
        {
            CurrentCondition currentCondition = new CurrentCondition();
            string url = BASE_URL + String.Format(CURRENTCONDITIONS_ENDPOINT, location, API_KEY);

            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                currentCondition = (JsonConvert.DeserializeObject<List<CurrentCondition>>(json)).FirstOrDefault();
            }
            return currentCondition;
        }

    }
}
