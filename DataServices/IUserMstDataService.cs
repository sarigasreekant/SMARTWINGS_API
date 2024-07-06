using ForexModel;

namespace ForexDataService
{
    public interface IUserMstDataService
    {
       
        Task<UserMst> GetUserByID(string UserID);
        Task<int> SaveUser(UserMst user);
        Task<int> DeleteUser(string UserID);
        //Task<CommanResponse> EditUser(UserMst usermst);
        Task<UserMst> Login(string UserId, string Password);
        Task<int> UpdatePassowrdUser(string UserId, string Password);
        Task<bool> IsMenuPermitted(int MenuID, string UserGroup);
        Task<ApplicationVersions> ApplicationVersion();
        Task<bool> IsValidToken(string UserId, string Token);
    }
}
