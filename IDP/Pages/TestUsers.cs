// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Security.Claims;
using Duende.IdentityServer.Test;
using IdentityModel;

namespace IDP.Pages;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = 69118,
                country = "Germany"
            };

            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "E0D89105-F2A5-440A-B04A-0F898C512F48",
                    Username = "Damir",
                    Password = "test",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.FamilyName, "Akhverdiev"),
                        new Claim(JwtClaimTypes.GivenName, "Damir"),
                        new Claim("role", "admin"),
                        new Claim("country", "srb")
                    }
                },
                new TestUser
                {
                    SubjectId = "05D29E9A-AE98-438F-91A3-8038C25BCC72",
                    Username = "Bob",
                    Password = "test",
                    Claims =
                    {
                        new Claim("role", "freeuser"),
                        new Claim(JwtClaimTypes.Name, "Bobster"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                    }
                },
                new TestUser
                {
                    SubjectId = "8B75F27E-10B0-4C65-85D7-A1771E5BC9CA",
                    Username = "Tom",
                    Password = "test",
                    Claims =
                    {
                        new Claim("role", "admin"),
                        new Claim(JwtClaimTypes.Name, "Tom"),
                        new Claim(JwtClaimTypes.GivenName, "Redle"),
                        new Claim("country", "rus")
                    }
                }
            };
        }
    }
}