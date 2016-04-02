/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Core;
using IdentityServer4.Core.Services.InMemory;

namespace Microbrewit.AuthServer.Configuration
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser{Subject = "torstein", Username = "torstein", Password = "torstein", 
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "torstein"),
                        new Claim(JwtClaimTypes.GivenName, "Torstein"),
                        new Claim(JwtClaimTypes.FamilyName, "Thune"),
                        new Claim(JwtClaimTypes.Email, "torstein@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Admin"),
                        new Claim(JwtClaimTypes.Role, "User"),
                        new Claim(JwtClaimTypes.WebSite, "http://thune.io"),
                        new Claim("Settings", @"{ 'boilVolume': '25'}", Constants.ClaimValueTypes.Json)
                    }
                },
                new InMemoryUser{Subject = "johnfredrik", Username = "johnfredrik", Password = "johnfredrik", 
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "johnfredrik"),
                        new Claim(JwtClaimTypes.GivenName, "John Fredrik"),
                        new Claim(JwtClaimTypes.FamilyName, "Asphaug"),
                        new Claim(JwtClaimTypes.Email, "johnfredrik@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Developer"),
                        new Claim(JwtClaimTypes.Role, "User"),
                        new Claim(JwtClaimTypes.WebSite, "http://asphaug.io"),
                        new Claim("Settings", @"{ 'boilVolume': '25'}", Constants.ClaimValueTypes.Json),
                    }
                },
                    new InMemoryUser{Subject = "snorre", Username = "snorre", Password = "snorre", 
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "snorre"),
                        new Claim(JwtClaimTypes.GivenName, "Snorre Magnus"),
                        new Claim(JwtClaimTypes.FamilyName, "Snorre Magnus Davøen"),
                        new Claim(JwtClaimTypes.Email, "snorre@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Developer"),
                        new Claim(JwtClaimTypes.Role, "User"),
                        new Claim(JwtClaimTypes.WebSite, "http://snorremd.io"),
                        new Claim("Settings", @"{ 'boilVolume': '25'}", Constants.ClaimValueTypes.Json),
                    }
                },
            };

            return users;
        }
    }
}