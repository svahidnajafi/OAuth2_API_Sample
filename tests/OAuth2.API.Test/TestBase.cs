using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAuth2.API.Test.Models;
using Xunit;

namespace OAuth2.API.Test
{
    public class TestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> Factory;
        protected readonly HttpClient Client;

        public TestBase(WebApplicationFactory<Startup> factory)
        {
            Factory = factory;
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
        }

        protected async Task<string> GetAccessTokenAsync()
        {
            var url = "/connect/token";
            
            //Act
            var credentials = new Dictionary<string, string>();
            credentials.Add("client_id", "client_id");
            credentials.Add("client_secret", "client_secret");
            credentials.Add("grant_type", "client_credentials");
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(credentials) };
            var response = await Client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var resultObj = JsonConvert.DeserializeObject<JObject>(result);
            var accessToken = resultObj.Property(OidcConstants.AuthorizeResponse.AccessToken).Value.ToString();
            return accessToken;
        }
    }
}