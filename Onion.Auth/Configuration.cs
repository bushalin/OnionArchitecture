using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Onion.Auth
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                // this is the resource we are protecting using identityserver
                // this resource name is defined in the API
                // inside app.AddAuthentication("Bearer") => config.Audience <= is the name of the api
                new ApiResource("basicIdentityApi"),
                new ApiResource("MainApi")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // these are the clients that our identity server have.
            // every client needs to have an id that identity server can identify them and a secret to prove who they really are.
            // we need to define the clientId in the individual client projects
            return new List<Client>
            {
                new Client
                {
                    ClientId = "api_two_id",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("api_two_secret".Sha256())
                    },

                    // scopes that client has access to
                    // this means the only items that this client can access
                    AllowedScopes = { "basicIdentityApi" }
                },

                new Client
                {
                    ClientId = "MVCClient",
                    ClientSecrets = { new Secret("mvc_client_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,

                    RedirectUris = { "https://localhost:44332/signin-oidc" },
                    RequireConsent = false,

                    AllowedScopes =
                    {
                        "basicIdentityApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "MVCWithAngularClient_id",
                    ClientSecrets = { new Secret("MVCWithAngularClient_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "https://localhost:44334/" },
                    RequireConsent = false,

                    AllowedScopes =
                    {
                        "basicIdentityApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "AngularClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,

                    // this is the PKCE type authentication. basically it is the same principal as GrantTypes.Code
                    // we do not have client secret in javascript client that is why we generate a temporary secret and send it to server
                    // server than hash it and compare with the temporary secret that client has sent again.
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:4200/auth-callback" },
                    PostLogoutRedirectUris = { "http://localhost:4200/" },

                    AllowedCorsOrigins = new List<string> { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        "basicIdentityApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "Onion.MVCClient",
                    ClientSecrets = { new Secret("onion_mvc_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,

                    RedirectUris = { "https://localhost:44344/signin-oidc" },
                    RequireConsent = false,

                    AllowedScopes =
                    {
                        "basicIdentityApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}