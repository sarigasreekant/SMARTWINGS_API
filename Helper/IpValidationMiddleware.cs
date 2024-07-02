using Dapper;
using DataAccess;
using ForexModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;
namespace Helper
{
    public class IpValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISqlDataAccess Db;
        private readonly ILogger<SqlDataAccess> _logger;
        public IpValidationMiddleware(RequestDelegate next, ISqlDataAccess _Db, ILogger<SqlDataAccess> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
               Db = _Db;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get the client's IP address from the HttpContext
            var ipAddress = context.Connection.RemoteIpAddress;

            // Your IP address validation logic here
            if (!IsValidIpAddress(ipAddress, context))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Invalid IP address");
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }

        private bool IsValidIpAddress(IPAddress ipAddress, HttpContext context)
        {
            try
            {
                string sql = @"SELECT OrgCode, BranchCode, UserID, Password, FullName, UserGroup, MobileNo, VIPToken, ActiveFlag, PhotoUrl, Email, AccuntNo, AccuntNoExceNo, CreatedDate 
                             FROM UserMst WHERE UserID= @UserID ";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@USERID", "PRADEEP", DbType.String);
                var user =  Db.QueryFirstOrDefault<dynamic>(sql, parameter);

               
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }

            return ipAddress != null && ipAddress.ToString() == "192.168.1.117";
        }
    }

    public static class IpValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpValidationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpValidationMiddleware>();
        }
    }
}