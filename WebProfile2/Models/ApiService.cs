using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace WebProfile2.Models
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:44390/api/";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Profile>> GetProfile()
        {
            List<Profile> profile = null;

            HttpResponseMessage response = await _httpClient.GetAsync("Profile");

            if (response.IsSuccessStatusCode)
            {
                profile = await response.Content.ReadAsAsync<List<Profile>>();
            }

            return profile;
        }

        public async Task<bool> CreateProfile(Profile profile)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Profile", profile);

            return response.IsSuccessStatusCode;
        }

        public async Task<Profile> UpdateProfile(int? id)
        {
            Profile profile = new Profile();

            HttpResponseMessage response = await _httpClient.GetAsync("Profile/{id}");

            if (response.IsSuccessStatusCode)
            {
                profile = await response.Content.ReadFromJsonAsync<Profile>();
            }

            return profile;
        }

        public async Task<bool> UpdateProfile(Profile profile)
        {

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Profile", profile);

            return response.IsSuccessStatusCode;
        }

        public async Task<Profile> GetDeleteProfile(int? id)
        {
            Profile profile = new Profile();

            HttpResponseMessage response = await _httpClient.GetAsync("Profile/{id}");

            if (response.IsSuccessStatusCode)
            {
                profile = await response.Content.ReadFromJsonAsync<Profile>();
            }

            return profile;
        }

        public async Task<bool> Delete(int? id)
        {

            HttpResponseMessage response = await _httpClient.DeleteAsync("Profile/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
