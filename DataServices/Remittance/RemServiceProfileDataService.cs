using Dapper;
using DataAccess;
using ForexModel;
//using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using QRCoder;
using System.Data;

namespace ForexDataService
{
    public class RemServiceProfileDataService : IRemServiceProfileDataService
    {

        private readonly ISqlDataAccess Db;
        public RemServiceProfileDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<RemServiceProfile>> GetServiceProfile(string custcode, string servcode)
        {
            string sql = @"USP_VN_TRN_GET_RemitServiceProfile_MApp";
            string Activeflage = "Y";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ACTIVEFLG", Activeflage, DbType.String);
            parameter.Add("@CUSTCODE", custcode, DbType.String);
            parameter.Add("@SERVCODE", servcode, DbType.String);

            var userList = await Db.QueryAsync<RemServiceProfile>(sql, parameter);


            return userList.ToList();
        }
        public async Task<RemServiceProfile> GetServiceProfilebyId(int servno)
        {
            string sql = @"select * from VN_MAS_SERVICEPROFILE where SerProfCode=@SERVNO";
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SERVNO", servno, DbType.String);
            var Data = await Db.QueryFirstOrDefaultAsync<RemServiceProfile>(sql, parameter);

            return Data;

        }
        public async Task<int> SaveServiceProf(ServiceProfileDTO prof)
        {
            var pResponse = new CommanResponse();
            try
            {
                string sql = @"USP_VN_TRN_BENEFICIARY_SAVE";
                var parameters = new DynamicParameters();
               
                parameters.Add("@CustCode", prof.CustCode, DbType.String);
                parameters.Add("@ContCode", "", DbType.String);
                parameters.Add("@Country", "", DbType.String);
                parameters.Add("@CurCode", "", DbType.String);
                parameters.Add("@Currency", "", DbType.String);
                parameters.Add("@ServCode", prof.ServiceServiceCode, DbType.String);
                parameters.Add("@ServiceName", prof.ServiceName, DbType.String);
                parameters.Add("@CorrOrgCode", "", DbType.String);
                parameters.Add("@CorresOrgName", "", DbType.String);
                parameters.Add("@CorrBranchCode", "", DbType.String);
                parameters.Add("@SubCorrOrgCode", "", DbType.String);
                parameters.Add("@SubCorrBranchCode", "", DbType.String);
                parameters.Add("@CorrCode", "", DbType.String);
                parameters.Add("@BenefFullName", prof.BenefFullName, DbType.String);
                parameters.Add("@BenefName1", "", DbType.String);
                parameters.Add("@BenefName2", "", DbType.String);
                parameters.Add("@BenefName3", "" , DbType.String);
                parameters.Add("@BenefName4", "", DbType.String);
                parameters.Add("@BenefGender", "", DbType.String);
                parameters.Add("@BenefDob", DateTime.Now, DbType.DateTime);
                parameters.Add("@BenefCell1", prof.BenefCell1, DbType.String);
                parameters.Add("@BenefCell2", "", DbType.String);
                parameters.Add("@BenefPhone1", "", DbType.String);
                parameters.Add("@BenefPhone2", "", DbType.String);
                parameters.Add("@BenefAddress1", "", DbType.String);
                parameters.Add("@BenefAddress2", "", DbType.String);
                parameters.Add("@BenefPlace", "", DbType.String);
                parameters.Add("@BenefStreet", "", DbType.String);
                parameters.Add("@BenefCity", "", DbType.String);
                parameters.Add("@BenefState", "", DbType.String);
                parameters.Add("@BenefPobox", "", DbType.String);
                parameters.Add("@BenefConcode", prof.BenefCountry, DbType.String);
                parameters.Add("@BenefCountry", "", DbType.String);
                parameters.Add("@BenefNationcode", prof.BenefNationCode, DbType.String);
                parameters.Add("@BenefNationality", "", DbType.String);
                parameters.Add("@BenefDialCode", "", DbType.String);
                parameters.Add("@BenefPOB", "", DbType.String);
                parameters.Add("@BenefIdType", "", DbType.String);
                parameters.Add("@BenefIdNo", "", DbType.String);
                parameters.Add("@BenefBankCode", prof.BenefBankCode, DbType.String);
                parameters.Add("@BenefBankName", "", DbType.String);
                parameters.Add("@BenefBankBranchCode", prof.BenefBankBranchCode, DbType.String);
                parameters.Add("@BenefBankBranchName", "", DbType.String);
                parameters.Add("@BenefIFSC", "", DbType.String);
                parameters.Add("@BenefAccountNo", prof.BenefAccountNo, DbType.String);
                parameters.Add("@BenfBankAddress", "", DbType.String);
                parameters.Add("@BenefBankCity", "", DbType.String);
                parameters.Add("@BenfRemarks", "", DbType.String);
                parameters.Add("@MTCustCode", "", DbType.String);
                parameters.Add("@RecvrName", "", DbType.String);
                parameters.Add("@RecvrAddress", "", DbType.String);
                parameters.Add("@LiasCode", "", DbType.String);
                parameters.Add("@IdCode", "", DbType.String);
                parameters.Add("@AcntTypeCode", "", DbType.String);
                parameters.Add("@AcntTypeDesc", "", DbType.String);
                parameters.Add("@OrgCode", prof.OrgCode, DbType.String);
                parameters.Add("@LangCode", "EN", DbType.String);
                parameters.Add("@ActiveFlag", "Y", DbType.String);
                parameters.Add("@UserId", prof.UserCode, DbType.String);
                parameters.Add("@CreatedDate", prof.CreatedDate, DbType.DateTime);
                
                //parameters.Add("@NewRefNo", dbType: DbType.Int64, direction: ParameterDirection.Output, size: 100);


                var rval = await Db.ExecuteAsyncStoredProcedure<int>(sql, parameters);
                //string NewRefNo = parameters.Get<int>("NewRefNo");
                //if (!string.IsNullOrEmpty(NewRefNo))
                //{
                //    pResponse.RefNo = NewRefNo;
                //    pResponse.StatusMesage = "Saved Successfully";
                //    pResponse.IsSucess = true;
                //}
                //else
                //{
                //    pResponse.RefNo = string.Empty;
                //    pResponse.StatusMesage = "Data not Saved!!!";
                //    pResponse.IsSucess = false;

                //}
                return rval;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
    }

    public interface IRemServiceProfileDataService
    {
        Task<IEnumerable<RemServiceProfile>> GetServiceProfile(string custcode,string servcode);
        Task<RemServiceProfile> GetServiceProfilebyId(int servno);
        Task<int> SaveServiceProf(ServiceProfileDTO prof);
    }
}
