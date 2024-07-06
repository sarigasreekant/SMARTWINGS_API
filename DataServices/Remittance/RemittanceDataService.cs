using Dapper;
using DataAccess;
using ForexModel;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using QRCoder;
using System.Data;

namespace ForexDataService
{
    public class RemittanceDataService : IRemittanceDataService
    {
        private readonly ISqlDataAccess Db;
        private readonly IWebHostEnvironment _environment;
        public IConfiguration Configuration { get; }
        public RemittanceDataService(ISqlDataAccess _Db, IWebHostEnvironment env, IConfiguration configuration)
        {
            Db = _Db;
            _environment = env;
            Configuration = configuration;
        }
        public async Task<IEnumerable<DropDwnListIdText>> GetBenefBankSearch(BenefBankSearch benefBankSearch)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ServOrgCode", benefBankSearch.ServOrgCode, DbType.String);
                parameters.Add("@CurCode", benefBankSearch.CurCode, DbType.String);
                parameters.Add("@ServCode", benefBankSearch.ServCode, DbType.String);
                parameters.Add("@OrgCode", benefBankSearch.OrgCode, DbType.String);
                parameters.Add("@BranchCode", benefBankSearch.BranchCode, DbType.String);
                parameters.Add("@ServiceCountry", benefBankSearch.ServiceCountry, DbType.String);
                parameters.Add("@ConfigCode", benefBankSearch.ConfigCode, DbType.String);
                parameters.Add("@ServiceCurrency", benefBankSearch.ServiceCurrency.Trim(), DbType.String);
                parameters.Add("@isSamebankOnly", benefBankSearch.isSamebankOnly, DbType.Boolean);
                parameters.Add("@Param1", benefBankSearch.Param1, DbType.String);
                parameters.Add("@Param2", benefBankSearch.Param2, DbType.String);
                parameters.Add("@Param3", benefBankSearch.Param3, DbType.String);
                parameters.Add("@BoolParam1", benefBankSearch.BoolParam1, DbType.Boolean);
                parameters.Add("@BoolParam2", benefBankSearch.BoolParam2, DbType.Boolean);
                var DataList = await Db.QueryAsync<DropDwnListIdText>("USP_VN_GET_REMITTANCE_BANK", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<DropDwnListIdText>> GetBenefBankBranchSearch(BenefBankBranchSearch? benefBankBranchSearch)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ServOrgCode", benefBankBranchSearch.ServOrgCode, DbType.String);
                parameters.Add("@CurCode", benefBankBranchSearch.CurCode, DbType.String);
                parameters.Add("@ServCode", benefBankBranchSearch.ServCode, DbType.String);
                parameters.Add("@OrgCode", benefBankBranchSearch.OrgCode, DbType.String);
                parameters.Add("@BranchCode", benefBankBranchSearch.BranchCode, DbType.String);
                parameters.Add("@ServiceCountry", benefBankBranchSearch.ServiceCountry, DbType.String);
                parameters.Add("@ConfigCode", benefBankBranchSearch.ConfigCode, DbType.String);
                parameters.Add("@ServiceCurrency", benefBankBranchSearch.ServiceCurrency.Trim(), DbType.String);
                parameters.Add("@isSamebankOnly", benefBankBranchSearch.isSamebankOnly, DbType.Boolean);
                parameters.Add("@Param1", benefBankBranchSearch.Param1, DbType.String);
                parameters.Add("@Param2", benefBankBranchSearch.Param2, DbType.String);
                parameters.Add("@Param3", benefBankBranchSearch.Param3, DbType.String);
                parameters.Add("@BoolParam1", benefBankBranchSearch.BoolParam1, DbType.Boolean);
                parameters.Add("@BoolParam2", benefBankBranchSearch.BoolParam2, DbType.Boolean);
                var DataList = await Db.QueryAsync<DropDwnListIdText>("USP_VN_GET_REMITTANCE_BANK_BRANCH", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<OrgnizationBranch>> GetBenifBankSearch(string corrOrgcode, string Countrycode, string Curcode, string ServCode, string Param1, string Param2, string Param3)
        {
            // string sql = @" select tb.OrgCode as Id,tb.OrgName as Text from Organization tb where tb.OrgTypeId=2 and ActiveFlag=@ActiveFlag";
            string sql = @"select ts.*,(select OrgName from Organization where OrgCode=ts.OrgCode)OrgName from OrgnizationBranch ts  where OrgCode IN(select OrgCode from Organization where OrgTypeId=2)";
            string Activeflage = "Y";
            DynamicParameters parameter = new DynamicParameters();
            // parameter.Add("@ActiveFlag", Activeflage, DbType.String);

            var userList = await Db.QueryAsync<OrgnizationBranch>(sql, parameter);


            return userList.ToList();
        }
        public async Task<Organization> GetOrganization(string corrcode)
        {
            string sql = @" select tb.*,(select description from VN_MAS_ORG_BRANCH_CODETYPE where CODE = tb.CodeType)CodeTypedesc from Organization tb where tb.OrgCode=@OrgCode ";

            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@OrgCode", corrcode, DbType.String);
            var Data = await Db.QueryFirstOrDefaultAsync<Organization>(sql, parameter);

            return Data;

        }
        public async Task<CorrespondentConfig> GetCorrOrgcode(string corrcode)
        {
            string sql = @" select ts.*,ta.*,(select description from VN_MAS_ORG_BRANCH_CODETYPE where code=ta.CodeType)CodeTypedesc from VN_MAS_SERVICECONFIG ts, Organization ta where ts.SERVORGCODE=ta.OrgCode and ts.CONFIGCODE=@CorrCode";
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CorrCode", corrcode, DbType.String);
            var Data = await Db.QueryFirstOrDefaultAsync<CorrespondentConfig>(sql, parameter);

            return Data;

        }
       
        public async Task<Remittance> GetRemittanceByNo(string refno)
        {
            string sql = @"exec VN_TRN_GET_RemittanvceByNo @RefNo";
            var parameters = new DynamicParameters();
            parameters.Add("@RefNo", refno, DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<Remittance>(sql, parameters);

            return Data;
        }
       
       
        public async Task<IEnumerable<RemitCorrespondent>> GetCorrespondent(string concode, string curcode, string servcode)
        {
            string sql = @"select ts.SERVORGCODE,ts.CONFIGCODE,ta.OrgName,ts.SERVCODE,ta.CodeType,ta.CountryName,ta.Street,ta.Address,ta.OrgTypeId from VN_REF_SERVCOUNTRY ts,Organization ta  where ts.SERVORGCODE=ta.OrgCode 
                            and ts.COUNTRYCODE=@concode and ts.CURCODE=@curcode and ts.SERVCODE=@servcode";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@concode", concode, DbType.String);
            parameter.Add("@curcode", curcode, DbType.String);
            parameter.Add("@servcode", servcode, DbType.String);
            var userList = await Db.QueryAsync<RemitCorrespondent>(sql, parameter);


            return userList.ToList();
        }
        public async Task<RemitResponse> SaveRemittance(Remittance remit)
        {
            var remitResponse=new RemitResponse();
            try
            {
                string sql = @"VN_TRN_REMITTANCE_SAVE";
                var parameters = new DynamicParameters();
                parameters.Add("@Orgcode", "00001", DbType.String);
                parameters.Add("@Branchcode", remit.BranchCode, DbType.String);
                parameters.Add("@RefNo", remit.RefNo, DbType.String);
                parameters.Add("@TTNo", remit.TTNo, DbType.String);
                parameters.Add("@ServiceCountry", remit.ServiceCountry, DbType.String);
                parameters.Add("@ServiceCountryCode", remit.ServiceCountryCode.ToUpper(), DbType.String);
                parameters.Add("@ServiceCurrency", remit.ServiceCurrency, DbType.String);
                parameters.Add("@ServiceCurrencyCode", remit.ServiceCurrencyCode.ToUpper(), DbType.String);
                parameters.Add("@ServiceServiceName", remit.ServiceServiceName, DbType.String);
                parameters.Add("@ServiceServiceCode", remit.ServiceServiceCode.ToUpper(), DbType.String);
                parameters.Add("@ServiceCorresOrgcode", remit.ServiceCorresOrgcode.ToUpper(), DbType.String);
                parameters.Add("@ServiceCorresName", remit.ServiceCorresName, DbType.String);
                parameters.Add("@CorrCode", remit.CorrCode, DbType.String);
                parameters.Add("@CustCode", remit.CustCode.ToUpper(), DbType.String);
                parameters.Add("@CustType", remit.CustType.ToUpper(), DbType.String);
                parameters.Add("@Name1", remit.Name1.ToUpper(), DbType.String);
                parameters.Add("@Name2", remit.Name2.ToUpper(), DbType.String);
                parameters.Add("@Name3", remit.Name3.ToUpper(), DbType.String);
                parameters.Add("@Name4", remit.Name4, DbType.String);
                parameters.Add("@Cell1", remit.Cell1.ToUpper(), DbType.String);
                parameters.Add("@Cell2", remit.Cell2, DbType.String);
                parameters.Add("@Phone", remit.Phone.ToUpper(), DbType.String);
                parameters.Add("@Gender", remit.Gender.ToUpper(), DbType.String);
                parameters.Add("@Dob", remit.Dob, DbType.DateTime);
                parameters.Add("@Address1", remit.Address1.ToUpper(), DbType.String);
                parameters.Add("@Address2", remit.Address2, DbType.String);
                parameters.Add("@Place", remit.Place.ToUpper(), DbType.String);
                parameters.Add("@Street", remit.Street.ToUpper(), DbType.String);
                parameters.Add("@City", remit.City.ToUpper(), DbType.String);
                parameters.Add("@State", remit.State.ToUpper(), DbType.String);
                parameters.Add("@CountryCode", remit.CountryCode.ToUpper(), DbType.String);
                parameters.Add("@Country", remit.Country, DbType.String);
                parameters.Add("@Pobox", remit.Pobox.ToUpper(), DbType.String);
                parameters.Add("@Nationcode", remit.Nationcode.ToUpper(), DbType.String);
                parameters.Add("@Nationality", remit.Nationality, DbType.String);
                parameters.Add("@Profession", remit.Profession.ToUpper(), DbType.String);
                parameters.Add("@Mail", remit.Mail.ToUpper(), DbType.String);
                parameters.Add("@Fax", remit.Fax, DbType.String);
                parameters.Add("@Company", remit.Company, DbType.String);
                parameters.Add("@Photo", remit.Photo, DbType.String);
                parameters.Add("@Remarks", remit.Remarks.ToUpper(), DbType.String);
                parameters.Add("@IdTypeCode", remit.IdType.ToUpper(), DbType.String);
                parameters.Add("@IdType", remit.IdType.ToUpper(), DbType.String);
                parameters.Add("@IdNo", remit.IdNo.ToUpper(), DbType.String);
                parameters.Add("@IssueDate", remit.IssueDate, DbType.DateTime);
                parameters.Add("@ExpDate", remit.ExpDate, DbType.DateTime);
                parameters.Add("@Issueplace", remit.Issueplace.ToUpper(), DbType.String);
                parameters.Add("@IdIssueCountry", remit.IdIssueCountry.ToUpper(), DbType.String);
                parameters.Add("@IdImageFront", remit.IdImageFront, DbType.String);
                parameters.Add("@IdImageBack", remit.IdImageBack, DbType.String);
                parameters.Add("@OtherDocument1", remit.OtherDocument1, DbType.String);
                parameters.Add("@OtherDocument2", remit.OtherDocument2, DbType.String);
                parameters.Add("@IssueContcode", remit.IssueContcode.ToUpper(), DbType.String);
                parameters.Add("@IdRemarks", remit.IdRemarks.ToUpper(), DbType.String);
                parameters.Add("@SerProfCode", remit.SerProfCode, DbType.Int64);
                parameters.Add("@BenefName1", remit.BenefName1.ToUpper(), DbType.String);
                parameters.Add("@BenefName2", remit.BenefName2.ToUpper(), DbType.String);
                parameters.Add("@BenefName3", remit.BenefName3.ToUpper(), DbType.String);
                parameters.Add("@BenefName4", remit.BenefName4, DbType.String);
                parameters.Add("@BenefCell1", remit.BenefCell1.ToUpper(), DbType.String);
                parameters.Add("@BenefCell2", remit.BenefCell2, DbType.String);
                parameters.Add("@BenefPhone", remit.BenefPhone.ToUpper(), DbType.String);
                parameters.Add("@BenefGender", remit.BenefGender.ToUpper(), DbType.String);
                parameters.Add("@BenefDob", remit.BenefDob, DbType.DateTime);
                parameters.Add("@BenefAddress1", remit.BenefAddress1.ToUpper(), DbType.String);
                parameters.Add("@BenefAddress2", remit.BenefAddress2, DbType.String);
                parameters.Add("@BenefPlace", remit.BenefPlace.ToUpper(), DbType.String);
                parameters.Add("@BenefStreet", remit.BenefStreet.ToUpper(), DbType.String);
                parameters.Add("@BenefCity", remit.BenefCity.ToUpper(), DbType.String);
                parameters.Add("@BenefState", remit.BenefState.ToUpper(), DbType.String);
                parameters.Add("@BenefConcode", remit.BenefConcode.ToUpper(), DbType.String);
                parameters.Add("@BenefCountry", remit.BenefCountry, DbType.String);
                parameters.Add("@BenefPobox", remit.BenefPobox.ToUpper(), DbType.String);
                parameters.Add("@BenefNationCode", remit.BenefNationCode.ToUpper(), DbType.String);
                parameters.Add("@BenefNationality", remit.BenefNationality, DbType.String);
                parameters.Add("@BenefProfession", remit.BenefProfession, DbType.String);
                parameters.Add("@BenefMail", remit.BenefMail, DbType.String);
                parameters.Add("@BenefFax", remit.BenefFax, DbType.String);
                parameters.Add("@BenefIdType", remit.BenefIdType, DbType.String);
                parameters.Add("@BenefIdNo", remit.BenefIdNo, DbType.String);
                parameters.Add("@BenefBankCode", remit.BenefBankCode.ToUpper(), DbType.String);
                parameters.Add("@BenefBankName", remit.BenefBankName, DbType.String);
                parameters.Add("@BenefBankBranchCode", remit.BenefBankBranchCode.ToUpper(), DbType.String);
                parameters.Add("@BenefBankBranchName", remit.BenefBankBranchName, DbType.String);
                parameters.Add("@BenefIFSC", remit.BenefIFSC, DbType.String);
                parameters.Add("@BenefAccountNo", remit.BenefAccountNo, DbType.String);
                parameters.Add("@BenfBankAddress", remit.BenfBankAddress.ToUpper(), DbType.String);
                parameters.Add("@BenefBankCity", remit.BenefBankCity.ToUpper(), DbType.String);
                parameters.Add("@BenfRemarks", remit.BenfRemarks, DbType.String);
                parameters.Add("@FcyAmount", remit.FcyAmount, DbType.Decimal);
                parameters.Add("@Rate", remit.Rate, DbType.Decimal);
                parameters.Add("@LcyAmount", remit.LcyAmount, DbType.Decimal);
                parameters.Add("@CommUSD", remit.CommUSD, DbType.Decimal);
                parameters.Add("@CommLcy", remit.CommLcy, DbType.Decimal);
                parameters.Add("@TaxUSD", remit.TaxUSD, DbType.Decimal);
                parameters.Add("@TaxLcy", remit.TaxLcy, DbType.Decimal);
                parameters.Add("@OtherTaxUSD", remit.OtherTaxUSD, DbType.Decimal);
                parameters.Add("@OtherTaxLcy", remit.OtherTaxLcy, DbType.Decimal);
                parameters.Add("@TotalUSD", remit.TotalUSD, DbType.Decimal);
                parameters.Add("@TotalLcy", remit.TotalLcy, DbType.Decimal);
                parameters.Add("@USDRate", remit.USDRate, DbType.Decimal);
                parameters.Add("@CostRate", remit.CostRate, DbType.Decimal);
                parameters.Add("@OriginalSellRate", remit.OriginalSellRate, DbType.Decimal);
                parameters.Add("@MinSellRate", remit.MinSellRate, DbType.Decimal);
                parameters.Add("@MaxSellRate", remit.MaxSellRate, DbType.Decimal);
                parameters.Add("@MinCommn", remit.MinCommn, DbType.Decimal);
                parameters.Add("@MaxCommn", remit.MaxCommn, DbType.Decimal);
                parameters.Add("@PaidFlag", "Y", DbType.String);
                parameters.Add("@UserId", remit.UserId, DbType.String);
                parameters.Add("@Trandate", remit.Trandate, DbType.DateTime);
                parameters.Add("@CashierCode", remit.UserId, DbType.String);
                parameters.Add("@CancelID", 0, DbType.Int32);        
                parameters.Add("@Occupation", remit.Occupation, DbType.String);
                parameters.Add("@Residence", remit.Residence, DbType.String);              
                parameters.Add("@Purpose", remit.Purpose, DbType.String);
                parameters.Add("@Source", remit.Source, DbType.String);
                parameters.Add("@PurposeDtl", remit.PurposeDtl, DbType.String);
                parameters.Add("@SourceDtl", remit.SourceDtl, DbType.String);
                parameters.Add("@RoutingBankCode", remit.RoutingBankCode, DbType.String);
                parameters.Add("@RoutingBankName", remit.RoutingBankName, DbType.String);
                parameters.Add("@LocCountry", remit.LocCountry, DbType.String);
                parameters.Add("@RepId", remit.RepId, DbType.Int64); 
                parameters.Add("@RepName", remit.RepName, DbType.String);
                parameters.Add("@RepRelation", remit.RepRelation, DbType.String); 
                parameters.Add("@RepMessage", remit.RepMessage, DbType.String);
                parameters.Add("@RefferBy", remit.RefferBy, DbType.String); 
                parameters.Add("@ReferDate", remit.ReferDate, DbType.DateTime);
                parameters.Add("@UBOName", remit.UBOName, DbType.String); 
                parameters.Add("@Suspicious", remit.Suspicious, DbType.String);
                parameters.Add("@NewRefNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);


                var rval = await Db.ExecuteAsyncStoredProcedure<string>(sql, parameters);
                string NewRefNo = parameters.Get<string>("NewRefNo");
                if (!string.IsNullOrEmpty(NewRefNo))
                {
                    remitResponse.RefNo = NewRefNo; 
                    remitResponse.StatusMesage = "Saved Successfully";
                    remitResponse.IsSucess = true;
                }
                else
                {
                    remitResponse.RefNo = string.Empty;
                    remitResponse.StatusMesage = "Data not Saved!!!";
                    remitResponse.IsSucess = false;
                
                }
                return remitResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<RemitResponse> SaveRemittancePay(RemittancePayment remitpay)
        //{
        //    var remitResponse = new RemitResponse();
        //    try
        //    {
        //        string sql = @"USP_VN_TRN_Insert_PAYMODE";
                
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@PortalCode", "00001", DbType.String);
        //        parameters.Add("@OrgCode", "00001", DbType.String);
        //        parameters.Add("@MenuCode", "00000", DbType.String);
        //        parameters.Add("@RefNo", remitpay.RefNo, DbType.String);
        //        parameters.Add("@TranDate", remitpay.TranDate, DbType.DateTime);
        //        parameters.Add("@PayRefNo", remitpay.PayRefNo, DbType.String);
        //        parameters.Add("@UserCode", remitpay.UserCode, DbType.String);

        //        parameters.Add("@PayCode", remitpay.PayCode, DbType.String);
        //        parameters.Add("@AccountCode", remitpay.AccountCode, DbType.String);
        //        parameters.Add("@PayCurCode", remitpay.PayCurCode, DbType.String);
        //        parameters.Add("@PayAmount", remitpay.PayAmount, DbType.Decimal);
        //        parameters.Add("@Rate", remitpay.Rate, DbType.Decimal);
        //        parameters.Add("@PaidAmount", remitpay.PaidAmount, DbType.Decimal);
        //        parameters.Add("@BalAmount", remitpay.BalAmount, DbType.Decimal);
        //        parameters.Add("@Discount", remitpay.Discount, DbType.Decimal);
        //        parameters.Add("@Pay_ID", remitpay.Pay_ID, DbType.Int32);
        //        parameters.Add("@PayCodeName", remitpay.PayCodeName, DbType.String);
        //        parameters.Add("@BankCode", remitpay.BankCode, DbType.String);
        //        parameters.Add("@BankName", remitpay.BankName, DbType.String);
        //        parameters.Add("@CardCharge", remitpay.CardCharge, DbType.Decimal);
        //        parameters.Add("@CheqDt", remitpay.CheqDt, DbType.DateTime);
        //        parameters.Add("@USDAmount", remitpay.USDAmount, DbType.Decimal);
        //        parameters.Add("@TotalDeno", remitpay.TotalDeno, DbType.Decimal);
        //        parameters.Add("@TotalDenoAmt", remitpay.TotalDenoAmt, DbType.Decimal);
        //        parameters.Add("@BalanceCashPay", remitpay.BalanceCashPay, DbType.Decimal);     

        //        var rval = await Db.ExecuteAsyncStoredProcedure<string>(sql, parameters);

        //        if (rval == -1)
        //        {
        //            remitResponse.RefNo = remitpay.RefNo; 
        //            remitResponse.StatusMesage = "Saved Successfully";
        //            remitResponse.IsSucess = true;
        //        }
        //        else
        //        {
        //            remitResponse.RefNo = string.Empty;
        //            remitResponse.StatusMesage = "Data not Saved!!!";
        //            remitResponse.IsSucess = false;

        //        }
        //        return remitResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
       
      
       

        public async Task<RemittanceDTO> GetRemittanceByRefNo(string refno)
        {
            string sql = @"VN_TRN_GET_RemittanvceByNo";
            var parameters = new DynamicParameters();
            parameters.Add("@RefNo", refno, DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<RemittanceDTO>(sql, parameters);

            return Data;
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
            catch (Exception)
            {

                throw;
            }

        }

      
        public async Task<LocalBank> GetLocalBankAccounts(string bankCode, string Curcode)
        {

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "GetLocalBankAccounts");
                parameters.Add("@param2", bankCode.Trim());
                parameters.Add("@param3", Curcode.Trim());
                var DataList = await Db.QueryFirstOrDefaultAsync<LocalBank>("USP_VN_GET_LOCAL_BANK_ACCOUNTS", parameters);

                return DataList;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //public async Task<IEnumerable<Journal>> GetJournalDetails(string Refno, string JvDocno)
        //{
        //    string sql = @"SELECT  [ORGCODE]   ,[BRANCHCODE]  ,[TRANDATE]  ,[JVDOCNO] ,[JVSERNO],[ACCCODE]
        //                  ,[NARRATION] ,[TRANTYPE]  ,[REFNO],[RATE] ,[FXAMT]  ,[EQUVAMT] ,[CUSTCODE] ,[USERID] ,[SERVTYPE],[REVFLG]
        //                    ,[CASHIERCODE],[ISCASHACNT],
        //                    (select DX_MST_ACCOUNTS.DESCRIPTION from DX_MST_ACCOUNTS where DX_MST_ACCOUNTS.ORGCODE='00001'
							 //and DX_MST_ACCOUNTS.ACCCODE=DX_TRNS_JOURNAL.ACCCODE)AccountsName,
        //                     (select Top 1 BranchName from  OrgnizationBranch where OrgCode='00001' and OrgnizationBranch.OrgCode=DX_TRNS_JOURNAL.OrgCode
        //                       AND OrgnizationBranch.BRANCHCODE= DX_TRNS_JOURNAL.BRANCHCODE) BrachName
        //                     FROM DX_TRNS_JOURNAL WHERE ORGCODE=@ORGCODE";
        //    if (Refno != "" && Refno != "az")
        //        sql += " AND REFNO=@REFNO";
        //    if (JvDocno != "" && JvDocno != "az")
        //        sql += " AND  JVDOCNO=@JvDocno";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@ORGCODE", "00001", DbType.String);
        //    if (Refno != "" && Refno != "az")
        //        parameters.Add("@REFNO", Refno.Trim(), DbType.String);
        //    if (JvDocno != "" && JvDocno != "az")
        //        parameters.Add("@JvDocno", JvDocno.Trim(), DbType.String);

        //    try
        //    {
        //        return await Db.QueryAsync<Journal>(sql, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }

        //}
        public async Task<IEnumerable<RemittancePayDTO>>  GetRemittancePaymentByRefNo(string refno)
        {
            string sql = @"SELECT distinct [AccountCode] AccountCode  FROM VN_TRN_PAYMODE where REFNO = @RefNo";
            var parameters = new DynamicParameters();
            parameters.Add("@RefNo", refno, DbType.String);

            try
            {
                return await Db.QueryAsync<RemittancePayDTO>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public async Task<IEnumerable<DropDwnListIdText>> GetRoutingBankSearch(RoutingBankSearch? routingBankSearch)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ServOrgCode", routingBankSearch.ServOrgCode, DbType.String);
                parameters.Add("@CurCode", routingBankSearch.CurCode, DbType.String);
                parameters.Add("@ServCode", routingBankSearch.ServCode, DbType.String);
                parameters.Add("@OrgCode", routingBankSearch.OrgCode, DbType.String);
                parameters.Add("@BranchCode", routingBankSearch.BranchCode, DbType.String);
                parameters.Add("@ServiceCountry", routingBankSearch.ServiceCountry, DbType.String);
                parameters.Add("@ConfigCode", routingBankSearch.ConfigCode, DbType.String);
                parameters.Add("@ServiceCurrency", routingBankSearch.ServiceCurrency.Trim(), DbType.String);
                parameters.Add("@isSamebankOnly", routingBankSearch.isSamebankOnly, DbType.Boolean);
                parameters.Add("@Param1", routingBankSearch.Param1, DbType.String);
                parameters.Add("@Param2", routingBankSearch.Param2, DbType.String);
                parameters.Add("@Param3", routingBankSearch.Param3, DbType.String);
                parameters.Add("@BoolParam1", routingBankSearch.BoolParam1, DbType.Boolean);
                parameters.Add("@BoolParam2", routingBankSearch.BoolParam2, DbType.Boolean);
                var DataList = await Db.QueryAsync<DropDwnListIdText>("USP_VN_GET_ROUTING_BANK", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
    public interface IRemittanceDataService
    {
        Task<RemitResponse> SaveRemittance(Remittance remit);
       // Task<RemitResponse> SaveRemittancePay(RemittancePayment remitpay);
        Task<Organization> GetOrganization(string corrcode);
        Task<IEnumerable<DropDwnListIdText>> GetBenefBankBranchSearch(BenefBankBranchSearch benefBankBranchSearch);
        Task<IEnumerable<DropDwnListIdText>> GetBenefBankSearch(BenefBankSearch benefBankSearch);
        Task<Remittance> GetRemittanceByNo(string refno);
       
        Task<IEnumerable<OrgnizationBranch>> GetBenifBankSearch(string corrOrgcode, string Countrycode, string Curcode, string ServCode, string Param1, string Param2, string Param3);
        Task<IEnumerable<RemitCorrespondent>> GetCorrespondent(string concode, string curcode, string servcode);
        Task<CorrespondentConfig> GetCorrOrgcode(string corrcode);
       

        Task<RemittanceDTO> GetRemittanceByRefNo(string refno);
        Task<ServiceAccounts> GetServiceAccounts(ServiceAccounts serviceAccounts);
       // Task<RemitResponse> SaveRemittanceDenom(DenominationTrn denominationTrn);
        Task<LocalBank> GetLocalBankAccounts(string bankCode, string Curcode);
      //  Task<IEnumerable<Journal>> GetJournalDetails(string Refno, string JvDocno);
        Task<IEnumerable<RemittancePayDTO>> GetRemittancePaymentByRefNo(string refno);
        Task<IEnumerable<DropDwnListIdText>> GetRoutingBankSearch(RoutingBankSearch? routingBankSearch);
    }
}
