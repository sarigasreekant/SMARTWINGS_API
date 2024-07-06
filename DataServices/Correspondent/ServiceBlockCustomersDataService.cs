using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceBlockCustomersDataService : IServiceBlockCustomersDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceBlockCustomersDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<ServiceBlockCustomers>> GetServiceBlockCustomers(ServiceBlockCustomers serviceBlockCustomers)
        {


            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "ServBlockedCustomer");
                parameters.Add("@param2", serviceBlockCustomers.ConfigCode.Trim());
                var DataList = await Db.QueryAsync<ServiceBlockCustomers>("USP_VN_GET_SERVICECONFIG_BLOCK", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CommanResponse> SaveServiceBlockCustomers(ServiceBlockCustomers serviceBlockCustomers)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";

            string sql = "USP_VN_MAS_SERVICE_BLOCKED_CUSTOMER";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceBlockCustomers.ConfigCode, DbType.String);
            parameters.Add("BlkTServOrgCode", serviceBlockCustomers.BlkTServOrgCode, DbType.String);
            parameters.Add("Tabid", serviceBlockCustomers.Tabid, DbType.Int32);
            parameters.Add("BlkTCurCode", serviceBlockCustomers.BlkTCurCode, DbType.String);
            parameters.Add("BlkTServCode", serviceBlockCustomers.BlkTServCode, DbType.String);
            parameters.Add("BlkTCustCode", serviceBlockCustomers.BlkTCustCode, DbType.String);
            parameters.Add("BlkTCustName", serviceBlockCustomers.BlkTCustName, DbType.String);
            parameters.Add("BlkTType", serviceBlockCustomers.BlkTType, DbType.String);
            parameters.Add("OrgCode", serviceBlockCustomers.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceBlockCustomers.PortalCode, DbType.String);
            parameters.Add("UserCode", serviceBlockCustomers.UserCode, DbType.String);
            


            try
            {

                var rval = await Db.QueryFirstOrDefaultAsync<string>(sql, parameters);
                var retData = rval.Split("-", 2);
                commanResponse.StatusMesage = retData[0];
                commanResponse.RefNo = retData[1];
                return commanResponse;

            }
            catch (Exception)
            {
                commanResponse.IsSucess = false;
                commanResponse.StatusMesage = "DataBase Saving Error";
                commanResponse.RefNo = "";
                return commanResponse;
            }
        }
        public async Task<int> DeleteServiceBlockCustomers(string code, string configcode)
        {
            string sql = @"DELETE from VN_REF_SERV_BLOCKED_CUSTOMER where CUSTCODE=@code and CONFIGCODE= @configcode ";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);


            parameters.Add("configcode", configcode, DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
    }
    public interface IServiceBlockCustomersDataService
    {
        Task<IEnumerable<ServiceBlockCustomers>> GetServiceBlockCustomers(ServiceBlockCustomers serviceBlockCustomers);
        Task<CommanResponse> SaveServiceBlockCustomers(ServiceBlockCustomers serviceBlockCustomers);
        Task<int> DeleteServiceBlockCustomers(string code, string configcode);
    }
}