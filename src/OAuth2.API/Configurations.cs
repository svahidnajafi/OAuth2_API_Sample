using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace OAuth2.API
{
    public class Configurations
    {
        public static readonly List<ApiResource> ApiResources = new List<ApiResource>()
        {
            new ApiResource("Test")
        };

        public static readonly List<ApiScope> ApiScopes = new List<ApiScope>()
        {
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            new ApiScope("something")
        };

        public static readonly List<IdentityResource> IdentityResources = new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static readonly List<Client> Clients = new List<Client>()
        {
            new Client
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read", "write", IdentityServerConstants.LocalApi.ScopeName}
            }
        };
    }
}