using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class CorrespondentConfigDataService: ICorrespondentConfigDataService
    {
        private readonly ISqlDataAccess Db;
        public CorrespondentConfigDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<CorrespondentConfig>> GetCorrespondentConfig(string param1, string param2)
        {   
            try
            {                
                var parameters = new DynamicParameters();
                parameters.Add("@param1", param1);
                parameters.Add("@param2", param2);
                var DataList = await Db.QueryAsync<CorrespondentConfig>("USP_VN_GET_SERVICECONFIG", parameters);

               return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }






        }

        public async Task<CorrespondentConfig> GetCorrespondentConfigByCode(string param1, string param2)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", param1);
                parameters.Add("@param2", param2);
                var DataList = await Db.QueryFirstOrDefaultAsync<CorrespondentConfig>("USP_VN_GET_SERVICECONFIG", parameters);

                return DataList;
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveCorrespondentConfig(CorrespondentConfig correspondenttConfig)
        {

            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;

            string sql = "USP_VN_MAS_SERVICE_CONFIG";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", correspondenttConfig.OrgCode, DbType.String);
            parameters.Add("@PortalCode", "00001", DbType.String);
            parameters.Add("@ConfigCode", correspondenttConfig.ConfigCode, DbType.String);
            parameters.Add("@OrgType", correspondenttConfig.OrgType, DbType.String);
            parameters.Add("@ServOrgCode", correspondenttConfig.ServOrgCode, DbType.String);
            parameters.Add("@CurCode", correspondenttConfig.CurCode, DbType.String);
            parameters.Add("@ServCode", correspondenttConfig.ServCode, DbType.String);
            parameters.Add("@SchrgCurCode", correspondenttConfig.SchrgCurCode, DbType.String);
            parameters.Add("@OchrgCurCode", correspondenttConfig.OchrgCurCode, DbType.String);
            parameters.Add("@TrnsLangCode", correspondenttConfig.TrnsLangCode, DbType.String);
            parameters.Add("@MinLimit", correspondenttConfig.MinLimit, DbType.Decimal);
            parameters.Add("@MaxLimit", correspondenttConfig.MaxLimit, DbType.Decimal);
            parameters.Add("@MinSCharge", correspondenttConfig.MinSCharge, DbType.Decimal);
            parameters.Add("@MaxSCharge", correspondenttConfig.MaxSCharge, DbType.Decimal);
            parameters.Add("@MaxOCharge", correspondenttConfig.MaxOCharge, DbType.Decimal);
            parameters.Add("@MinOCharge", correspondenttConfig.MinOCharge, DbType.Decimal);
            parameters.Add("@AccNo", correspondenttConfig.AccNo, DbType.String);
            parameters.Add("@ActiveFlag", "Y", DbType.String);
            parameters.Add("@AuthLevel", "3", DbType.String);
            parameters.Add("@IsActive", correspondenttConfig.IsActive, DbType.Boolean);
            parameters.Add("@UserCode", correspondenttConfig.UserCode, DbType.String);
            parameters.Add("@Remarks", correspondenttConfig.Remarks, DbType.String);
            parameters.Add("@RateFrom", correspondenttConfig.RateFrom, DbType.String);
            parameters.Add("@EditCom", correspondenttConfig.EditCom, DbType.Boolean);
            parameters.Add("@RateEditFlg", correspondenttConfig.RateEditFlg, DbType.Boolean);
            parameters.Add("@TradeLimit", correspondenttConfig.TradeLimit, DbType.String);
            parameters.Add("@BranchShowFLg", correspondenttConfig.BranchShowFLg, DbType.Boolean);
            parameters.Add("@ApiFileType", correspondenttConfig.ApiFileType, DbType.String);


            try
            {
               // commanResponse.RefNo = Corrcode;
                var rval =  await Db.QueryFirstOrDefaultAsync<string>(sql, parameters);
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
        public interface ICorrespondentConfigDataService
    {
        Task<IEnumerable<CorrespondentConfig>> GetCorrespondentConfig(string param1, string param2);
        Task<CorrespondentConfig> GetCorrespondentConfigByCode(string param1, string param2);
        Task<CommanResponse> SaveCorrespondentConfig(CorrespondentConfig correspondentConfig);
        }
    }

