using System.Collections.Generic;
using IdentityServer4.Core.Models;

namespace Microbrewit.AuthServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // JS OAuth 2.0 Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oauth",
                    ClientName = "JavaScript OAuth 2.0 Client",
                    ClientUri = "http://identityserver.io",

                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:28895/index.html"
                    },

                     AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.Roles.Name,
                        StandardScopes.OfflineAccess.Name,
                        "microbrewit-api"
                    }
                },
                
                  ///////////////////////////////////////////
                // Microbrewit
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "microbrewit",
                    ClientName = "Microbrewit",
                    ClientUri = "http://microbrew.it",
                    
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris = new List<string>
                    {
                        "http://localhost:3000/"
                    },

                     AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.Roles.Name,
                        StandardScopes.OfflineAccess.Name,
                        "microbrewit-api"
                    }
                },
                
                 ///////////////////////////////////////////
                // Postman 
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "postman",
                    ClientName = "PostMan",
                    ClientUri = "http://microbrew.it",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.AuthorizationCode,
                     RedirectUris = new List<string>
                    {
                        "https://www.getpostman.com/oauth2/callback"
                    },
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.Roles.Name,
                        "microbrewit-api"
                    },
                    RequireConsent = false,
                },
            };
        }
    }
}