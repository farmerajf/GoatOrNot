using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;
using GoatOrNot.Models;

namespace GoatOrNot.Services
{
    /// <summary>
    /// A service providing goat API methods.
    /// </summary>
    public class GoatApiClient : IGoatApiClient
    {
        public const string ApiBaseUrl = "http://goatapi.mradam.co.uk/v1";

        /// <summary>
        /// Fetches a goat quote.
        /// </summary>
        /// <returns>The goat quote.</returns>
        public async Task<Quote> GetQuoteAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.GetAsync("http://goatapi.mradam.co.uk/v1/quote");
                // Check if the response is success and auto throw exception if it is not
                response.EnsureSuccessStatusCode();


                string json = await response.Content.ReadAsStringAsync();
                var quote = Json.Decode<Quote>(json);
                return quote;
            }
        }
    }
}