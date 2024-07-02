using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.IO;

namespace Helper
{
    
    public class CustomAuthenticationOptions : AuthenticationSchemeOptions
    {
        // Add any custom options if needed
    }

    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        public CustomAuthenticationHandler(
            IOptionsMonitor<CustomAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
#pragma warning disable CS0618 // Type or member is obsolete
            ISystemClock clock)
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            : base(options, logger, encoder, clock)
#pragma warning restore CS0618 // Type or member is obsolete
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Retrieve headers
            var userId = Request.Headers["UserId"];
            var password = Request.Headers["Password"];
            var authorizationHeaderExists = Request.Headers.TryGetValue("Authorization", out var authorizationHeaderValues);

            if (authorizationHeaderExists && authorizationHeaderValues.Any())
            {
                var authorizationHeaderValue = authorizationHeaderValues.First();

                if (TryGetBearerToken(authorizationHeaderValue, out var jwtToken))
                {
                    // Perform JWT validation logic here
                    if (ValidateJwtToken(jwtToken))
                    {
                        // If JWT is valid, set the principal
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userId),
                        // Add more claims as needed
                    };

                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);

                        return Task.FromResult(AuthenticateResult.Success(ticket));
                    }
                }
            }

            // If authentication fails, return a failure result
            return Task.FromResult(AuthenticateResult.Fail("Invalid UserId, Password, or JWT token"));
        }

        // Your custom JWT validation logic goes here
        private bool ValidateJwtToken(string jwtToken)
        {
           
            return jwtToken == "your_hardcoded_jwt_token";
        }

        private bool TryGetBearerToken(string authorizationHeaderValue, out string jwtToken)
        {
            jwtToken = null;

            if (authorizationHeaderValue != null && authorizationHeaderValue.StartsWith("Bearer "))
            {
                jwtToken = authorizationHeaderValue.Substring("Bearer ".Length);
                return true;
            }

            return false;
        }

        // Your custom authentication logic goes here
        private bool YourAuthenticationLogic(string userId, string password)
        {
            // Implement your logic to validate UserId and Password, e.g., against a database
            // Return true if the credentials are valid, false otherwise

            // Example: Check against hardcoded values (for demo purposes only)
            return userId == "demo" && password == "demo";
        }
    }


}