using Dapper;
using DataAccess;
using ForexModel;
using QRCoder;
using System.Data;

namespace ForexDataService
{ 
    public class RemittanceRatedtlsDataService : IRemittanceRatedtlsDataService
    {
        private readonly ISqlDataAccess Db;
        public RemittanceRatedtlsDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<RemittanceRatedtls> GetRate(string ConCode, string CurCode, string BranchCode, string ServCode, string param1, string param2, string param3)
        {
            try
            {
                string sql = @"exec VN_get_RemittanceRatedtls @ConCode,@CurCode,@BranchCode,@ServCode,@param1,@param2,@param3";

                var parameters = new DynamicParameters();
                parameters.Add("@ConCode", ConCode, DbType.String);
                parameters.Add("@CurCode", CurCode, DbType.String);
                parameters.Add("@BranchCode", BranchCode, DbType.String);
                parameters.Add("@ServCode", ServCode, DbType.String);
                parameters.Add("@param1", param1, DbType.String);
                parameters.Add("@param2", param2, DbType.String);
                parameters.Add("@param3", param3, DbType.String);

                var Data = await Db.QueryFirstOrDefaultAsync<RemittanceRatedtls>(sql, parameters);

                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RemittanceRatedtls> GetRateCommision(CommisionSearch commisionSearch)
        {

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ServOrgCode", commisionSearch.ServOrgCode, DbType.String);
                parameters.Add("@CurCode", commisionSearch.CurCode, DbType.String);
                parameters.Add("@ServCode", commisionSearch.ServCode, DbType.String);
                parameters.Add("@OrgCode",  commisionSearch.OrgCode, DbType.String);
                parameters.Add("@BranchCode", commisionSearch.BranchCode, DbType.String);
                parameters.Add("@ServiceCountry", commisionSearch.ServiceCountry, DbType.String);
                parameters.Add("@ConfigCode", commisionSearch.ConfigCode, DbType.String);
                parameters.Add("@ServiceCurrency", commisionSearch.ServiceCurrency.Trim(), DbType.String);
                parameters.Add("@FcyAmount", commisionSearch.FcyAmount, DbType.Decimal);
                parameters.Add("@LcyAmount", commisionSearch.LcyAmount, DbType.Decimal);
                parameters.Add("@CommType", commisionSearch.CommType, DbType.String);
                parameters.Add("@BenefBank", commisionSearch.BenefBank, DbType.String);
                parameters.Add("@BenifBranchCode", commisionSearch.BenifBranchCode, DbType.String);
                parameters.Add("@Param1", commisionSearch.Param1, DbType.String);
                parameters.Add("@Param2", commisionSearch.Param2, DbType.String);
                parameters.Add("@Param3", commisionSearch.Param3, DbType.String);
                parameters.Add("@BoolParam1", commisionSearch.BoolParam1, DbType.Boolean);
                parameters.Add("@BoolParam2", commisionSearch.BoolParam2, DbType.Boolean);
                var DataList = await Db.QueryFirstOrDefaultAsync<RemittanceRatedtls>("USP_VN_GET_REMITTANCE_CHARGE", parameters);

                return DataList;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    public interface IRemittanceRatedtlsDataService
    {
        Task<RemittanceRatedtls> GetRate(string ConCode, string CurCode, string BranchCode, string ServCode, string param1, string param2, string param3);
        Task<RemittanceRatedtls> GetRateCommision(CommisionSearch commisionSearch);

    }
}
