
using ForexModel;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Helper
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "ABCDEFGHIKMMFFFMMMMMMMMMMMMMMMMMM@3###M";
        private const int JWT_TOKEN_VALIDITY_MINS = 1420;
        public const string ValidIssuer = "DHBForex";
        public const string ValidAudience = "DHBForex.Client";
        public static string GenerateJwtToken(UserMst loginRequest)
        {
           

            /* Generating JWT Token */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginRequest.UserID),
                    new Claim(ClaimTypes.Role, loginRequest.UserGroup.ToString() )
                });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials,
                Issuer = ValidIssuer,
                Audience = ValidAudience
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            /* Returning the user session object */
            //var userSession = new UserSession
            //{
            //    UserName = loginRequest.Email,
            //    Role = roleName!,
            //    Token = token,
            //    ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            //};
            return token;
        }
    }
}
