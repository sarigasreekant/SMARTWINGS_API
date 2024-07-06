using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceBlockCountriesDataService : IServiceBlockCountriesDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceBlockCountriesDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<ServiceBlockCountries>> GetServiceBlockCountries(ServiceBlockCountries serviceBlockCountries)
        {
            

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", serviceBlockCountries.BlkCNationName.Trim());//search code
                parameters.Add("@param2", serviceBlockCountries.ConfigCode.Trim());
                var DataList = await Db.QueryAsync<ServiceBlockCountries>("USP_VN_GET_SERVICECONFIG_BLOCK", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveServiceBlockCountries(ServiceBlockCountries serviceBlockCountries)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";
            
            string sql = "USP_VN_MAS_SERVICE_BLOCKED_COUNTRY";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceBlockCountries.ConfigCode, DbType.String);
            parameters.Add("BlkCServOrgCode", serviceBlockCountries.BlkCServOrgCode, DbType.String);
            parameters.Add("Tabid", serviceBlockCountries.Tabid, DbType.Int32);
            parameters.Add("BlkCCurCode", serviceBlockCountries.BlkCCurCode, DbType.String);
            parameters.Add("BlkCServCode", serviceBlockCountries.BlkCServCode, DbType.String);
            parameters.Add("BlkCNationCode", serviceBlockCountries.BlkCNationCode, DbType.String);
            parameters.Add("BlkCCodeSel", serviceBlockCountries.BlkCCodeSel, DbType.Boolean);
            parameters.Add("BlkCType", serviceBlockCountries.BlkCType, DbType.String);
            parameters.Add("OrgCode", serviceBlockCountries.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceBlockCountries.PortalCode, DbType.String);
            parameters.Add("UserCode", serviceBlockCountries.UserCode, DbType.String);
            

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

        public async Task<int> DeleteServiceBlockCountries(string code, string configcode, string BlkCType)
        {
            string sql = @"DELETE from VN_REF_SERV_BLOCKED_COUNTRY where COUNTRYCODE=@code and CONFIGCODE= @configcode and TYPE = @BlkCType";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);
            parameters.Add("configcode", configcode, DbType.String);
            parameters.Add("BlkCType", BlkCType, DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }

    }
    public interface IServiceBlockCountriesDataService
    {
        Task<IEnumerable<ServiceBlockCountries>> GetServiceBlockCountries(ServiceBlockCountries serviceBlockCountries);
        Task<CommanResponse> SaveServiceBlockCountries(ServiceBlockCountries serviceBlockCountries);
        Task<int> DeleteServiceBlockCountries(string code, string configcode, string BlkCType);

    }
}