using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceChargesDataService : IServiceChargesDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceChargesDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<ServiceCharges>> GetServiceCharges(ServiceCharges serviceCharges)
        {
            
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "SearchByCode");
                parameters.Add("@param2", serviceCharges.ConfigCode.Trim());
                parameters.Add("@param3", serviceCharges.BranchCode.Trim());
                var DataList = await Db.QueryAsync<ServiceCharges>("USP_VN_GET_SERVICECHARGE", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveServiceCharges(ServiceCharges serviceCharges)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";
           
            string sql = "USP_VN_MAS_SERVICE_CHARGE";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceCharges.ConfigCode, DbType.String);
            parameters.Add("SChargeCode", serviceCharges.SChargeCode, DbType.Int64);
            parameters.Add("ServOrgCode", serviceCharges.ServOrgCode, DbType.String);
            parameters.Add("CurCode", serviceCharges.CurCode, DbType.String);
            parameters.Add("ChargeType", serviceCharges.ChargeType, DbType.String);
            parameters.Add("SlabFrom", serviceCharges.SlabFrom, DbType.Decimal);
            parameters.Add("SlabTo", serviceCharges.SlabTo, DbType.Decimal);
            parameters.Add("AmtPercType", serviceCharges.AmtPercType, DbType.String);
            parameters.Add("BranchCode", serviceCharges.BranchCode, DbType.String);
            parameters.Add("DeductType", serviceCharges.DeductType, DbType.String);
            parameters.Add("Mincharge", serviceCharges.Mincharge, DbType.Decimal);
            parameters.Add("MaxCharge", serviceCharges.MaxCharge, DbType.Decimal);
            parameters.Add("SlabCurCode", serviceCharges.SlabCurCode, DbType.String);
            parameters.Add("ServCharge", serviceCharges.ServCharge, DbType.Decimal);
            parameters.Add("AuthFlag", serviceCharges.AuthFlag, DbType.String);
            parameters.Add("ActiveFlag", serviceCharges.ActiveFlag, DbType.String);
            parameters.Add("OrgCode", serviceCharges.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceCharges.PortalCode, DbType.String);
            parameters.Add("UserCode", serviceCharges.UserCode, DbType.String);
            parameters.Add("Remarks", serviceCharges.Remarks, DbType.String);
            parameters.Add("Tabid", serviceCharges.Tabid, DbType.Int64);
            parameters.Add("EditType", serviceCharges.EditType, DbType.String);
            parameters.Add("OchrgCurCode", serviceCharges.OchrgCurCode, DbType.String);
            parameters.Add("SchrgCurCode", serviceCharges.SchrgCurCode, DbType.String);
            parameters.Add("OurCharge", serviceCharges.OurCharge, DbType.Decimal);


            try
            {
                var rval = await Db.ExecuteAsync<int>(sql, parameters);
                return commanResponse;

                //var rval = await Db.QueryFirstOrDefaultAsync<string>(sql, parameters);
                //var retData = rval.Split("-", 2);
                //commanResponse.StatusMesage = retData[0];
                //commanResponse.RefNo = retData[1];
                //return commanResponse;

            }
            catch (Exception)
            {
                commanResponse.IsSucess = false;
                commanResponse.StatusMesage = "DataBase Saving Error";
                commanResponse.RefNo = "";
                return commanResponse;
            }
        }

        public async Task<int> DeleteServiceCharges(int code, string configcode)
        {
            string sql = @"DELETE from VN_MAS_SERVCHARGE where SCHARGECODE=@code and CONFIGCODE= @configcode ";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.Int64);


            parameters.Add("configcode", configcode, DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
    }
    public interface IServiceChargesDataService
    {
        Task<IEnumerable<ServiceCharges>> GetServiceCharges(ServiceCharges serviceCharges);
        Task<CommanResponse> SaveServiceCharges(ServiceCharges serviceCharges);
        Task<int> DeleteServiceCharges(int code, string configcode);


    }
}