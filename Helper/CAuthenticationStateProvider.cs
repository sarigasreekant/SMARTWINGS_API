using ForexDataService;
using ForexModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Helper
{
    public class CAuthenticationStateProvider : AuthenticationStateProvider
    {

        
      
        ProtectedLocalStorage browserStorage;
        public CAuthenticationStateProvider(ProtectedLocalStorage _browserStorage)
        {
          
            browserStorage = _browserStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var resultUser = await browserStorage.GetAsync<string>("SessionUserID");
         

            var User = resultUser.Success ? resultUser.Value.ToString() : "";
          
          

            var UserId = User;

            ClaimsIdentity identity;

            if (UserId != null && UserId != string.Empty)
            {
               
                identity = GetClaimsIdentity(User);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);


            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        public async Task MarkUserAsAuthenticated(string user)
        {

            var result = await browserStorage.GetAsync<string>("SessionUserID");
             user = result.Success ? result.Value.ToString() : "";
          


            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task MarkUserAsLoggedOut()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {


            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(string user)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (user != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name,user)
                                     // new Claim(ClaimTypes.Role, UserGroup.ToString())
                                    // new Claim(ClaimTypes.Country, user.MOBILE)

                                }, "apiauth_type");


            }

            return claimsIdentity;
        }

        private string IsUserEmployedBefore1990(UserMst user)
        {
            //if (user.HireDate.Value.Year < 1990)
            //    return "true";
            //else
            return "false";
        }
    }
}
