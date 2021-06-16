using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace GHPRS.Core.Services
{

    // TODO Mwasi : Add retry logic in the case of an invalidated token
    public class MetabaseService : IMetabaseService
    {
        private readonly IMemoryCache _cache;
        private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);
        private readonly IConfiguration _configuration;
        private readonly ILogger<MetabaseService> _logger;
        private readonly string _url;
        public MetabaseService(IConfiguration configuration, ILogger<MetabaseService> logger, IMemoryCache cache)
        {
            _configuration = configuration;
            _logger = logger;
            _cache = cache;
            _url = configuration["Metabase:Url"];
        }

        public async Task<string> GetSessionToken()
        {
            var semaphore = GetUsersSemaphore;
            _cache.TryGetValue(CacheKeys.Entry, out string token);
            if (token != null) return token;
            try
            {
                await semaphore.WaitAsync();
                _cache.TryGetValue(CacheKeys.Entry, out token); // Recheck to make sure it didn't populate before entering semaphore
                if (token != null)
                {
                    return token;
                }
                token = await MetabaseSessionToken();
                // Save data in cache and set the relative expiration time to 14 days
                _cache.Set(CacheKeys.Entry, token, TimeSpan.FromDays(13));
            }
            finally
            {
                semaphore.Release();
            }

            return token;
        }

        public async Task<IActionResult> CreateUser(MetabaseUser user)
        {
            IActionResult result;
            using var client = new HttpClient {BaseAddress = new Uri(_url)};
            // get metabase session token
            var token = await GetSessionToken();
            client.DefaultRequestHeaders.Add("X-Metabase-Session", token);
            string jsonString = JsonSerializer.Serialize(user);
            var response = await client.PostAsync("user", new StringContent(jsonString, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = new OkObjectResult(apiResponse);
            }
            else
            {
                result = new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                string apiResponse = await response.Content.ReadAsStringAsync();
                _logger.LogError(apiResponse);

            }

            return result;
        }

        public async Task<IActionResult> GetCurrentUser()
        {
            IActionResult result;
            using var client = new HttpClient {BaseAddress = new Uri(_url)};
            // get metabase session token
            var token = await GetSessionToken();
            client.DefaultRequestHeaders.Add("X-Metabase-Session", token);
            var response = await client.GetAsync("user/current");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = new OkObjectResult(apiResponse);
            }
            else
            {
                result = new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                string apiResponse = await response.Content.ReadAsStringAsync();
                _logger.LogError(apiResponse);

            }
            return result;
        }

        private async Task<string> MetabaseSessionToken()
        {
            string result = "";
            using var client = new HttpClient {BaseAddress = new Uri(_url)};
            var login = new MetabaseLogin()
            {
                UserName = _configuration["Metabase:UserName"],
                Password = _configuration["Metabase:Password"]
            };
            string jsonString = JsonSerializer.Serialize(login);
            var response = await client.PostAsync("session", new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                dynamic resultObject  = JObject.Parse(apiResponse);
                result = resultObject.id;
            }
            else
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                _logger.LogError(apiResponse);

            }

            return result;
        }
    }
}
