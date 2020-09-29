using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Moral.Api.Ext;

namespace Moral.Api.Infrastructure
{
    public class TokenBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenBuilder"/> class
        /// </summary>
        /// <param name="settings">JWT settings</param>
        public TokenBuilder(Settings settings)
        {
            Settings = settings;
        }

        private Settings Settings { get; set; }

        /// <summary>
        /// Generates a JWT security token
        /// </summary>
        /// <param name="user">Authenitcated user</param>
        /// <param name="authClaims">Auhorization claims for the authenticated users (excluding standard JWT claims)</param>
        /// <param name="expiration">When token expires</param>
        /// <returns>A JWT security token</returns>
        public JwtSecurityToken GenerateToken(
            IdentityUser user,
            IEnumerable<Claim> authClaims,
            out DateTimeOffset expiration)
        {
            IdentityModelEventSource.ShowPII = true;

            if (user == null) throw new ArgumentNullException(nameof(user));

            expiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(Settings.ExpiryMins));

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, expiration.ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, Settings.Audience),
                new Claim(JwtRegisteredClaimNames.Iss, Settings.Issuer)
            };

            if (authClaims != null) claims.AddRange(authClaims);


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SigningKey));

            return new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));
        }
    }
}
