// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;
using System.Collections.Generic;

namespace SeeLive.Identity.Api
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
                 new ApiScope[]
        {
            new ApiScope("SeeLive.Api", "SeeLive API")
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client{
                    ClientId = "SeeLive.Presentation.Web",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                          new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "SeeLive.Api"}
                },
                new Client
                {
                    ClientId = "seelive-ui",
                    ClientName = "SeeLive Angular Client",
                    ClientUri = "http://localhost:4200",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200/" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                    AllowedScopes = { "openid", "SeeLive.Api"}
                }
       };
    }
}