using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceBusinessRulesDataService : IServiceBusinessRulesDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceBusinessRulesDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<ServiceBusinessRules> GetServiceBusinessRules(ServiceBusinessRules serviceBusinessRules)
        {
            
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "BusinessRuleServ");
                parameters.Add("@param2", serviceBusinessRules.ConfigCode.Trim());
                var DataList = await Db.QueryFirstOrDefaultAsync<ServiceBusinessRules>("USP_VN_GET_SERVICE_BUSINESS_RULES", parameters);

                return DataList;
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveServiceBusinessRules(ServiceBusinessRules serviceBusinessRules)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";
            string sql = "USP_VN_MAS_SERVICE_BUSINESS_RULES";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceBusinessRules.ConfigCode, DbType.String);
            parameters.Add("ServCode", serviceBusinessRules.ServCode, DbType.String);
            parameters.Add("CurCode", serviceBusinessRules.CurCode, DbType.String);
            parameters.Add("ServOrgCode", serviceBusinessRules.ServOrgCode, DbType.String);
            parameters.Add("OrgCode", serviceBusinessRules.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceBusinessRules.OrgCode, DbType.String);
            parameters.Add("UserCode", serviceBusinessRules.OrgCode, DbType.String);
            parameters.Add("AuthReqd", serviceBusinessRules.AuthReqd, DbType.Boolean);
            parameters.Add("BypassGlobalSettings", serviceBusinessRules.BypassGlobalSettings, DbType.Boolean);
            parameters.Add("BranchLevel", serviceBusinessRules.BranchLevel, DbType.Boolean);
            parameters.Add("BrnchAmountLimit", serviceBusinessRules.BrnchAmountLimit, DbType.Decimal);
            parameters.Add("IndividualBranchLimit", serviceBusinessRules.IndividualBranchLimit, DbType.Boolean);
            parameters.Add("HOLevel", serviceBusinessRules.HOLevel, DbType.Boolean);
            parameters.Add("AuthHOlimit", serviceBusinessRules.AuthHOlimit, DbType.Decimal);
            parameters.Add("FundSetmntRequired", serviceBusinessRules.FundSetmntRequired, DbType.Boolean);
            parameters.Add("ValidLedgerBal", serviceBusinessRules.ValidLedgerBal, DbType.Boolean);
            parameters.Add("TransitRequired", serviceBusinessRules.TransitRequired, DbType.Boolean);
            parameters.Add("ChequeNo", serviceBusinessRules.ChequeNo, DbType.Boolean);
            parameters.Add("ChequeNoSts", serviceBusinessRules.ChequeNoSts, DbType.String);
            parameters.Add("BankList", serviceBusinessRules.BankList, DbType.Boolean);
            parameters.Add("BranchList", serviceBusinessRules.BranchList, DbType.Boolean);
            parameters.Add("TestKey", serviceBusinessRules.TestKey, DbType.Boolean);
            parameters.Add("TestKeySts", serviceBusinessRules.TestKeySts, DbType.String);
            parameters.Add("CancellationAllowed", serviceBusinessRules.CancellationAllowed, DbType.Boolean);
            parameters.Add("NoValueTrans", serviceBusinessRules.NoValueTrans, DbType.Boolean);
            parameters.Add("BlockDecimal", serviceBusinessRules.BlockDecimal, DbType.Boolean);
            parameters.Add("BlockLC", serviceBusinessRules.BlockLC, DbType.Boolean);
            parameters.Add("BlockFC", serviceBusinessRules.BlockFC, DbType.Boolean);
            parameters.Add("RateEditable", serviceBusinessRules.RateEditable, DbType.Boolean);
            parameters.Add("BlockCorporate", serviceBusinessRules.BlockCorporate, DbType.Boolean);
            parameters.Add("BlockIndividual", serviceBusinessRules.BlockIndividual, DbType.Boolean);
            parameters.Add("ShowSameBank", serviceBusinessRules.ShowSameBank, DbType.Boolean);
            parameters.Add("AgentBankList", serviceBusinessRules.AgentBankList, DbType.Boolean);
            parameters.Add("OnlineAMLNotRqd", serviceBusinessRules.OnlineAMLNotRqd, DbType.Boolean);
            parameters.Add("BankExpAccRqd", serviceBusinessRules.BankExpAccRqd, DbType.Boolean);
            parameters.Add("BankDetails", serviceBusinessRules.BankDetails, DbType.Boolean);
            parameters.Add("SpotRate", serviceBusinessRules.SpotRate, DbType.Boolean);
            parameters.Add("NoExchvar", serviceBusinessRules.NoExchvar, DbType.Boolean);
            parameters.Add("DispClientRefno", serviceBusinessRules.DispClientRefno, DbType.Boolean);
            parameters.Add("AvoidRoundOff", serviceBusinessRules.AvoidRoundOff, DbType.Boolean);
            parameters.Add("ValidateAMCash", serviceBusinessRules.ValidateAMCash, DbType.Boolean);
            parameters.Add("SendSMS", serviceBusinessRules.SendSMS, DbType.Boolean);
            parameters.Add("SMSFrom", serviceBusinessRules.SMSFrom, DbType.String);
            parameters.Add("BatchingRqd", serviceBusinessRules.BatchingRqd, DbType.String);
            parameters.Add("BatchingOn", serviceBusinessRules.BatchingOn, DbType.String);
            parameters.Add("PreDfndCustcode", serviceBusinessRules.PreDfndCustcode, DbType.Boolean);
            parameters.Add("PreDfndCustcodetxt", serviceBusinessRules.PreDfndCustcodetxt, DbType.String);
            parameters.Add("DOBValidation", serviceBusinessRules.DOBValidation, DbType.String);
            parameters.Add("DOBYear", serviceBusinessRules.DOBYear, DbType.String);
            parameters.Add("TranType", serviceBusinessRules.TranType, DbType.String);
            parameters.Add("PayCode", serviceBusinessRules.PayCode, DbType.String);
            parameters.Add("CustSMS", serviceBusinessRules.CustSMS, DbType.String);
            parameters.Add("AgentCommission", serviceBusinessRules.AgentCommission, DbType.Boolean);
            parameters.Add("BranchAcntVal", serviceBusinessRules.BranchAcntVal, DbType.Boolean);
            parameters.Add("AutoClientRef", serviceBusinessRules.AutoClientRef, DbType.Boolean);


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
    public interface IServiceBusinessRulesDataService
    {
        Task<ServiceBusinessRules> GetServiceBusinessRules(ServiceBusinessRules serviceBusinessRules);
        Task<CommanResponse> SaveServiceBusinessRules(ServiceBusinessRules serviceBusinessRules);

    }
}