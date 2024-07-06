using Dapper;
using DataAccess;
using ForexModel;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace ForexDataService
{
    public class UserMstDataService : IUserMstDataService
    {
        private readonly ISqlDataAccess Db;
        private readonly ILogger<SqlDataAccess> _logger;
        public UserMstDataService(ISqlDataAccess _Db, ILogger<SqlDataAccess> logger)
        {
            Db = _Db;
            _logger = logger;
        }

        public async Task<UserMst> GetUserByID(string UserID)
        {
            try
            {
                string sql = @"SELECT OrgCode, BranchCode, UserID, Password, FullName, UserGroup, MobileNo, VIPToken, ActiveFlag, PhotoUrl, Email, AccuntNo, AccuntNoExceNo, CreatedDate ,UserType
                             FROM UserMst_MobileApp WHERE UserID= @UserID ";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@USERID", UserID, DbType.String);
                var user = await Db.QueryFirstOrDefaultAsync<UserMst>(sql, parameter);

                return user;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<int> SaveUser(UserMst usermst)
        {
            try
            {

                string sql = @" INSERT INTO UserMst_MobileApp(OrgCode, BranchCode, UserID,Password, FullName, UserGroup, MobileNo, VIPToken, 
                            ActiveFlag, PhotoUrl, Email, AccuntNo, AccuntNoExceNo, CreatedDate,UserType) VALUES (@OrgCode, @BranchCode, 
                            @UserID, @Password, @FullName, @UserGroup, @MobileNo, @VIPToken, @ActiveFlag, @PhotoUrl, @Email,
                            @AccuntNo, @AccuntNoExceNo, @CreatedDate,@UserType)";



                var parameters = new DynamicParameters();
                string Pass = Helper.Cryptography.Encrypt(usermst.Password.ToUpper().Trim());
                parameters.Add("@OrgCode", usermst.OrgCode, DbType.String);
                parameters.Add("@BranchCode", usermst.BranchCode, DbType.String);
                parameters.Add("@UserID", usermst.UserID.ToUpper().Trim(), DbType.String);
                parameters.Add("@Password", Pass, DbType.String);
                parameters.Add("@FullName", usermst.FullName.ToUpper(), DbType.String);
                parameters.Add("@UserGroup", usermst.UserGroup, DbType.Int32);
                parameters.Add("@MobileNo", usermst.MobileNo, DbType.String);
                parameters.Add("@VIPToken", usermst.VIPToken, DbType.String);
                parameters.Add("@ActiveFlag", usermst.ActiveFlag, DbType.String);
                parameters.Add("@PhotoUrl", usermst.PhotoUrl, DbType.String);
                parameters.Add("@Email", usermst.Email, DbType.String);
                parameters.Add("@AccuntNo", usermst.AccuntNo, DbType.String);
                parameters.Add("@AccuntNoExceNo", usermst.AccuntNoExceNo, DbType.String);
                parameters.Add("@CreatedDate", usermst.CreatedDate, DbType.DateTime);
                parameters.Add("@UserType", "N", DbType.String);
                var userval = await Db.ExecuteAsync<int>(sql, parameters);

                return userval;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<int> DeleteUser(string UserID)
        {
            try
            {

                string sql = @" UPDATE UserMst_MobileApp  SET ActiveFlag ='N' WHERE UserID=@UserID ";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@UserID", UserID, DbType.String);
                var userCNT = await Db.ExecuteAsync<int>(sql, parameter);

                return userCNT;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }
        }

        public async Task<UserMst> Login(string UserId, string Password)
        {
            string Pass = Helper.Cryptography.Encrypt(Password);
            try
            {
                string sql = @"SELECT OrgCode, BranchCode, UserID, Password, FullName, UserGroup, MobileNo, VIPToken, ActiveFlag
                        ,(select BranchName from OrgnizationBranch where OrgnizationBranch.OrgCode='00001' and 
                         OrgnizationBranch.OrgCode = UserMst_MobileApp.OrgCode and OrgnizationBranch.BranchCode=UserMst_MobileApp.BranchCode 
                         )  BranchName,UserType
                        FROM UserMst_MobileApp WHERE UserID= @UserID and Password=@Password AND ActiveFlag='Y' ";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@UserID", UserId, DbType.String);
                parameter.Add("@Password", Pass, DbType.String);
                var user = await Db.QueryFirstOrDefaultAsync<UserMst>(sql, parameter);

                return user;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public async Task<int> UpdatePassowrdUser(string UserId, string Password)
        {
            try
            {
                string sql = @" UPDATE UserMst_MobileApp SET Password = @Password WHERE  UserID = @UserID  ";
                string Pass = Helper.Cryptography.Encrypt(Password);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", UserId, DbType.String);
                parameters.Add("@Password", Pass, DbType.String);

                var userval = await Db.ExecuteAsync<int>(sql, parameters);

                return userval;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<bool> IsMenuPermitted(int MenuID, string UserGroup)
        {
            int userval = 0;
            try
            {
                if (UserGroup != "" && Convert.ToInt32(MenuID) > 0)
                {
                    string sql = $" SELECT COUNT(1) FROM menu,UserGroupMasterAuth WHERE menu.MenuId=UserGroupMasterAuth.MenuID AND menu.MenuId =@MenuId AND UserGroupMasterAuth.UserGroupId =@UserGroup";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@MenuId", MenuID, DbType.Int32);
                    parameters.Add("@UserGroup", Convert.ToInt32(UserGroup), DbType.Int32);
                    userval = await Db.ExecuteScalarAsync<int>(sql, parameters);
                    if (userval > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public async Task<bool> IsValidToken(string UserId, string Token)
        {
            int userval = 0;
            try
            {
                if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Token))
                {
                    string sql = $" SELECT COUNT(1) FROM  UserMst_MobileApp where  UserID =@UserId and VIPToken = @VIPToken ";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UserID", UserId, DbType.String);
                    parameters.Add("@VIPToken", Token, DbType.String);
                    userval = await Db.ExecuteScalarAsync<int>(sql, parameters);
                    if (userval > 0)
                        return true;
                    else
                        return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        public async Task<ApplicationVersions> ApplicationVersion()
        {
            try
            {
                string sql = @"SELECT Id ,VersionNumber,ReleaseDate 
                             FROM ApplicationVersions ";

                DynamicParameters parameter = new DynamicParameters();


                var user = await Db.QueryFirstOrDefaultAsync<ApplicationVersions>(sql, parameter);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //private async Task<string> GeneratePassword(string CustType)
        //{
        //    string sqlID = @" SELECT [CUSTID] ,[COCUSTID] FROM [dbo].[PWGEN_CUST_MOB] ";
        //    string Custcode = "";
        //    var parameters1 = new DynamicParameters();

        //    IDGEN_CUST? custIdRecord = await Db.QueryFirstOrDefaultAsync<IDGEN_CUST>(sqlID, parameters1);

        //    string servertime = ServerDateTime().ToString();
        //    if (CustType == "I")
        //    {
        //        string SId = "" + custIdRecord.CUSTID.ToString();
        //        Custcode = Custcode + SId.PadLeft(10, '0').Trim();

        //        sqlID = "";
        //        sqlID = @" UPDATE [dbo].[IDGEN_CUST] set  CUSTID =CUSTID+1";


        //        await Db.ExecuteAsync<int>(sqlID, parameters1);
        //    }
        //    return SD.Concode + CustType.ToUpper() + Custcode;
        //}
        public static DateTime ServerDateTime()
        {
            string ServerTimeZone = "04:00";
            string LoginContTimeZone = "04:00";
            DateTime time = DateTime.Now.ToLocalTime();
            string _serverTimeZone = ServerTimeZone;
            double dMin = Convert.ToDouble("." + _serverTimeZone.Substring(_serverTimeZone.IndexOf(':') + 1)) * 100 / 60;
            double dHr = Convert.ToDouble(_serverTimeZone.Substring(0, _serverTimeZone.IndexOf(':')));
            double dST = 0;
            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;
            time = time.AddHours(-1 * dST);
            time = time.AddHours(Convert.ToDouble(LoginContTimeZone.Replace(":", ".")));
            return time;
        }
    }



        
}
