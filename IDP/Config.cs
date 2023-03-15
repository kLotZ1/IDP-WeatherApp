using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new("roles", "Your role(s)", new[] { "role" }),
            new("country", "Your country(s)", new[] { "country" })
        };

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new("weatherapi", "weather api", new[] { "role", "country" })
        {
            Scopes = { "weatherapi.fullaccess", "weatherapi.read", "weatherapi.write" }
        }
    };


    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new("weatherapi.fullaccess"),
            new("weatherapi.read"),
            new("weatherapi.write")
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "weatherclient",
                ClientName = "weatherclient",
                AllowedGrantTypes = GrantTypes.Code,
                AccessTokenLifetime = 120,
                AllowOfflineAccess = true,
                UpdateAccessTokenClaimsOnRefresh = true,
                RedirectUris =
                {
                    "https://localhost:7066/signin-oidc"
                },
                PostLogoutRedirectUris = { "https://localhost:7066/signout-callback-oidc" },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    "weatherapi.read",
                    "weatherapi.write",
                    "country"
                },
                ClientSecrets = new List<Secret> { new("secret".ToSha256()) },
                RequireConsent = true
            }
        };
}