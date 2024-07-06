using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceAccountsDataService : IServiceAccountsDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceAccountsDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<ServiceAccounts> GetServiceAccounts(ServiceAccounts serviceAccounts)
        {

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "ForServACConfig");
                parameters.Add("@param2", serviceAccounts.ConfigCode.Trim());
                var DataList = await Db.QueryFirstOrDefaultAsync<ServiceAccounts>("USP_VN_GET_SERVICECONFIG_ACCOUNTS", parameters);

                return DataList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ServiceAccounts?> GetServiceAccountsByCode(string param1, string param2)
        {


            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", param1);
                parameters.Add("@param2", param2);
                var DataList = await Db.QueryFirstOrDefaultAsync<ServiceAccounts>("USP_VN_GET_SERVICECONFIG_ACCOUNTS", parameters);

                return DataList;
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveServiceAccounts(ServiceAccounts serviceAccounts)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";

            string sql = "USP_VN_MAS_SERVICE_ACCOUNTS";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceAccounts.ConfigCode, DbType.String);
            parameters.Add("ServOrgCode", serviceAccounts.ServOrgCode, DbType.String);
            parameters.Add("CurCode", serviceAccounts.CurCode, DbType.String);
            parameters.Add("ServCode", serviceAccounts.ServCode, DbType.String);
            parameters.Add("OrgCode", serviceAccounts.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceAccounts.PortalCode, DbType.String);
            parameters.Add("UserCode", serviceAccounts.UserCode, DbType.String);
            parameters.Add("ShortLedgerName", serviceAccounts.ShortLedgerName, DbType.String);
            parameters.Add("LedgerCurCode", serviceAccounts.LedgerCurCode, DbType.String);
            parameters.Add("CommCurwise", serviceAccounts.CommCurwise, DbType.Boolean);
            parameters.Add("ExchCurwise", serviceAccounts.ExchCurwise, DbType.Boolean);
            parameters.Add("ChangeLedger", serviceAccounts.ChangeLedger, DbType.Boolean);
            parameters.Add("LedgerCurrency", serviceAccounts.LedgerCurrency, DbType.String);
            parameters.Add("BankName", serviceAccounts.BankName, DbType.String);
            parameters.Add("BankNo", serviceAccounts.BankNo, DbType.String);
            parameters.Add("SwiftCode", serviceAccounts.SwiftCode, DbType.String);
            parameters.Add("CreditLimit", serviceAccounts.CreditLimit, DbType.Decimal);
            parameters.Add("LedgerAC", serviceAccounts.LedgerAC, DbType.String);
            parameters.Add("TransitAC", serviceAccounts.TransitAC, DbType.String);
            parameters.Add("CommisionAC", serviceAccounts.CommisionAC, DbType.String);
            parameters.Add("BankChargeAC", serviceAccounts.BankChargeAC, DbType.String);
            parameters.Add("ExVariationAC", serviceAccounts.ExVariationAC, DbType.String);
            parameters.Add("AccruedAC", serviceAccounts.AccruedAC, DbType.String);
            parameters.Add("LedgerACName", serviceAccounts.LedgerACName, DbType.String);
            parameters.Add("TransitACName", serviceAccounts.TransitACName, DbType.String);
            parameters.Add("CommisionACName", serviceAccounts.CommisionACName, DbType.String);
            parameters.Add("BankChargeACName", serviceAccounts.BankChargeACName, DbType.String);
            parameters.Add("ExVariationACName", serviceAccounts.ExVariationACName, DbType.String);
            parameters.Add("AccruedACName", serviceAccounts.AccruedACName, DbType.String);
            parameters.Add("SettlementAC", serviceAccounts.SettlementAC, DbType.String);
            parameters.Add("SettleService", serviceAccounts.SettleService, DbType.String);
            parameters.Add("SettleCurCode", serviceAccounts.SettleCurCode, DbType.String);
            parameters.Add("PostToSettAC", serviceAccounts.PostToSettAC, DbType.Boolean);
            parameters.Add("SettlementACName", serviceAccounts.SettlementACName, DbType.String);


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

    }
    public interface IServiceAccountsDataService
    {
        Task<ServiceAccounts> GetServiceAccounts(ServiceAccounts serviceAccounts);
        Task<ServiceAccounts> GetServiceAccountsByCode(string param1, string param2);
        Task<CommanResponse> SaveServiceAccounts(ServiceAccounts serviceAccounts);

    }
}