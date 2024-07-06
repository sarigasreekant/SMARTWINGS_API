using Dapper;
using DataAccess;
using ForexModel;
using System.Data;
namespace ForexDataService
{
    public class ServicePayModesDataService : IServicePayModesDataService
    {
        private readonly ISqlDataAccess Db;
        public ServicePayModesDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<ServicePayModes>> GetServicePayModes(ServicePayModes servicePayModes)
        {
            

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", servicePayModes.PayServName.Trim());
                parameters.Add("@param2", servicePayModes.ConfigCode.Trim());
                var DataList = await Db.QueryAsync<ServicePayModes>("USP_VN_GET_SERVICECONFIG", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<CommanResponse> SaveServicePayModes(ServicePayModes servicePayModes)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";
            string sql = "USP_VN_MAS_SERVICE_PAYMODE";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", servicePayModes.ConfigCode, DbType.String);
            parameters.Add("PayServCode", servicePayModes.PayServCode, DbType.String);            
            parameters.Add("PayCurCode", servicePayModes.PayCurCode, DbType.String);
            parameters.Add("PayServOrgCode", servicePayModes.PayServOrgCode, DbType.String);
            parameters.Add("PayCodeSel", servicePayModes.PayCodeSel, DbType.Boolean);
            parameters.Add("PayModeCode", servicePayModes.PayModeCode, DbType.String);
            parameters.Add("PayName", servicePayModes.PayName, DbType.String);
            parameters.Add("OrgCode", servicePayModes.OrgCode, DbType.String);
            parameters.Add("PortalCode", servicePayModes.OrgCode, DbType.String);
            parameters.Add("UserCode", servicePayModes.OrgCode, DbType.String);

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
        public async Task<int> DeleteServicePayModes(string code, string configcode)
        {
            string sql = @"DELETE from VN_REF_SERV_PAYMODE where PAYCODE=@code and CONFIGCODE= @configcode ";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);


            parameters.Add("configcode", configcode, DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
    }
    public interface IServicePayModesDataService
    {
        Task<IEnumerable<ServicePayModes>> GetServicePayModes(ServicePayModes servicePayModes);
        Task<CommanResponse> SaveServicePayModes(ServicePayModes servicePayModes);
        Task<int> DeleteServicePayModes(string code, string configcode);


    }
}