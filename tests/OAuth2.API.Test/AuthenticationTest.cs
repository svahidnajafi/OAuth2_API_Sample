using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace OAuth2.API.Test
{
    public class AuthenticationTest : TestBase
    {
        public AuthenticationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {}
        
        [Fact]
        public async Task Get_UnAuthorizedTest()
        {
            var url = "/secret";

            //Act
            var response = await Client.GetAsync(url);

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task HealthCheckTest()
        {
            var url = "/home";
            
            // Act
            var response = await Client.GetAsync(url);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_AuthorizationAccessTokenTest()
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
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AccessTokenTest()
        {
            var accessToken = await GetAccessTokenAsync();
            Assert.NotNull(accessToken);
        }

        [Fact]
        public async Task GetSecretEndpointResultTest()
        {
            var url = "/secret";
            var accessToken = await GetAccessTokenAsync();
            Client.SetBearerToken(accessToken);
            var response = await Client.GetAsync(url);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}