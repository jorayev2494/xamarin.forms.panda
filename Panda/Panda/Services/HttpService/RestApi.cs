using Newtonsoft.Json;
using Panda.Models;
using Panda.Services.Authenticate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Services.HttpService
{
    public class RestApi
    {

        public static string URL = "http://192.168.43.10:8085"; // "http://169.254.94.145";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // Set Authorization Token
            return SetAuthorize(ref client);
        }

        public static async Task<T> GET<T>(string url)
        {
            HttpClient httpClient = GetClient();
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
            string stringContent= await httpResponse.Content.ReadAsStringAsync();
            Debug.WriteLine(stringContent);
            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public static async Task<bool> POST(string url, object data = null)
        {
            HttpClient httpClient = GetClient();

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PostAsync(url, stringContent);
            return httpResponse.IsSuccessStatusCode;
        }

        public static async Task<T> POST<T>(string url, object data = null)
        {
            HttpClient httpClient = GetClient();

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PostAsync(url, stringContent);
            string @string = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(@string);
        }

        public static async Task<T> PUT<T>(string url, object data)
        {
            HttpClient httpClient = GetClient();

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PutAsync(url, stringContent);
            return JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
        }

        public static async Task<Boolean> DELETE(string url)
        {
            HttpClient httpClient = GetClient();
            HttpResponseMessage httpResponse = await httpClient.DeleteAsync(url);
            return httpResponse.StatusCode == HttpStatusCode.NoContent;
        }

        private static HttpClient SetAuthorize(ref HttpClient httpClient)
        {
            if (Auth.HasAccessToken())
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Auth.GetAccessToken());
            else
                httpClient.DefaultRequestHeaders.Remove("Authorization");

            return httpClient;
        }
    }
}
