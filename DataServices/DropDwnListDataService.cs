using Dapper;
using DataAccess;
using ForexModel;
using ForexNewApp.Model;
using QRCoder;

using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace ForexDataService
{
    public class DropDwnListDataService : IDropDwnListDataService
    {
        private readonly ISqlDataAccess Db;
        public DropDwnListDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<ForexModel.DropDwnList>> GetDropDwnList(string dropType, int Id = 0, string Parameter = "")
        {
            string sql = "";
            DynamicParameters parameter = new DynamicParameters();

            switch (dropType)
            {

                case "OrgType":
                    sql = @" SELECT OrgTypeId as Id, OrgTypeName as Text FROM OrgType where ActiveFlag='Y' ";
                    break;
                case "OrgBranch":
                    sql = $" SELECT BranchID as Id, BranchName as Text FROM OrgnizationBranch where OrgId={Id} ";
                    break;



                case "Currency":
                    sql = @" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency where ActiveFlag='Y' ";
                    break;
                case "UserGroupMast":
                    sql = @"SELECT UserGroupId as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y' ";
                    if (Id != 0)
                    {
                        sql += $" AND UserGroupId=UserGroupId";
                        parameter.Add("UserGroupId", Id, DbType.Int32);
                    }
                    break;
                case "Organization":
                    sql = @"SELECT OrgId as Id, OrgName as Text FROM Organization where ActiveFlag='Y' ";

                    break;
                case "MenuModule":
                    sql = @" SELECT  MenuId as Id,MenuName as Text from  Menu WHERE ParentId=0 AND ACTIVEFLG='Y' ";

                    break;
                default:
                    sql = @"SELECT UserGroupId as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y' ";
                    break;
            }

            var DataList = await Db.QueryAsync<ForexModel.DropDwnList>(sql, parameter);





            return DataList.ToList();
        }
        public async Task<IEnumerable<ForexModel.DropDwnListIdText>> GetDropDwnListIdText(string dropType, string Id = "", string Parameter = "")
        {
            string sql = "";
            DynamicParameters parameter = new DynamicParameters();

            switch (dropType)
            {

                case "OrgType":
                    sql = @" SELECT CAST(OrgTypeId AS varchar(20)) as Id, OrgTypeName as Text FROM OrgType where ActiveFlag='Y' ";
                    break;
                case "AMLTYPE":
                    sql = @" SELECT CAST(AMLTYPE AS varchar(20)) as Id, AMLTYPEDES as Text FROM AMLTYPE  ";
                    break;
                case "Organization":
                    sql = @" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' ";

                    break;
                case "OrganizationType":
                    sql = @" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' ";
                    if (Id != "" && Id != "a2")
                    {
                        int OrgTypeID = Convert.ToInt32(Id);
                        sql += $" AND OrgTypeId=@OrgTypeId";
                        parameter.Add("OrgTypeId", OrgTypeID, DbType.Int32);
                    }
                    break;
                case "ORGAGENT":
                    sql = @" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgTypeId=4 ";
                    break;
                case "OrgBranch":
                    sql = $" SELECT BranchCode as Id, BranchName as Text FROM OrgnizationBranch where OrgCode=@OrgCode ";
                    parameter.Add("OrgCode", Id, DbType.String);
                    if (Parameter != "" && Parameter != "a2")
                    {
                        sql += $" AND BranchCode=@BranchCode";
                        parameter.Add("BranchCode", Parameter, DbType.String);
                    }
                    break;
                case "Country":
                    sql = @" SELECT CAST(ConCode AS varchar(20)) as Id, CountryName as Text FROM Country where ActiveFlag='Y' ";
                    break;

                case "Currency":
                    sql = @" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency where Activeflag='Y' ";
                    break;

                case "Service":
                    sql = @" SELECT CAST(ServCode AS varchar(20)) as Id, ServiceName as Text from ServiceMaster ";
                    break;
                

                case "Nationality":
                    sql = @"   SELECT CAST(ConCode AS varchar(20)) as Id, Nationality as Text FROM Country where ACTIVEFLAG='Y'  ";
                    break;
                case "Purpose":
                    sql = @" SELECT CAST(PURPCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_PURPOSE where ACTIVEFLAG='Y' and PURPTYPE='P'  ";
                    break;
                case "Source":
                    sql = @" SELECT CAST(PURPCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_PURPOSE where ACTIVEFLAG='Y' and PURPTYPE='S'  ";
                    break;
                case "Profession":
                    sql = @" SELECT CAST(PROFCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_PROFESSION where ACTIVEFLG='Y'  ";
                    break;
                case "Occupation":
                    sql = @" SELECT CAST(OCCUCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_OCCUPATION where ACTIVEFLG='Y'  ";
                    break;
                case "Residence":
                    sql = @" SELECT CAST(RESIDENTCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_RESIDENCE where ACTIVEFLAG='Y'  ";
                    break;

                case "CodeType":
                    sql = @" SELECT CAST(CODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_ORG_BRANCH_CODETYPE where ACTIVEFLG='Y' ";
                    break;
                case "ForexCurrency":
                    sql = $" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CURRENCY as Text FROM RATESHEET where ORGCODE='00001' AND BRANCHCODE='00000' AND CORRORGCODE='00001' and CurCode NOT IN ('{SD.LocalCurCode}','{SD.LocalCurCodeRemit}') ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND CURCODE=@CURCODE";
                        parameter.Add("CURCODE", Id, DbType.String);
                    }
                    break;
                case "FXCurrency":
                    sql = $" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CURRENCY as Text FROM RATESHEET where ORGCODE='00001' AND BRANCHCODE='00000' AND CORRORGCODE='00001' ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND CURCODE=@CURCODE";
                        parameter.Add("CURCODE", Id, DbType.String);
                    }
                    break;
                case "ForextType":
                    sql = @" SELECT CAST(TYPE AS varchar(20)) as Id, TEXT as Text FROM  FOREXTYPE";

                    break;
                case "UserMst":
                    sql = @" SELECT CAST(UserID AS varchar(20)) as Id, UserID as Text FROM  UserMst where OrgCode='00001' AND ActiveFlag='Y' ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND BranchCode=@BranchCode";
                        parameter.Add("BranchCode", Id, DbType.String);
                    }
                    break;
                case "RateCurrency":
                    sql = $" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency where CurCode Not in ( select CURCODE from RATEMARGINSETTINGS where BRANCHCODE=@BRANCHCODE )  ";
                    parameter.Add("BranchCode", Id, DbType.String);
                    break;
                case "GroupCountry":
                    sql = @" SELECT CAST(GroupName AS varchar(50)) as Id, GroupName as Text FROM GroupCountry where ActiveFlag='Y' ";
                    break;
                case "CustomerType":
                    sql = @" SELECT CAST(CustType AS varchar(50)) as Id, CustTypeName as Text FROM CustomerType";
                    break;
                case "Gender":
                    sql = @" SELECT CAST(TRIM(GenderId) AS varchar(50)) as Id, Gender as Text FROM Gendermst";
                    break;
                case "IDTYPE":
                    sql = @" SELECT CAST(IDTYPCODE AS varchar(50)) as Id, IDTYPE as Text FROM IDTYPE";
                    break;
                case "PayMode":
                    sql = @" SELECT CAST(PAYCODE AS varchar(50)) as Id, DESCRIPTION as Text FROM [VN_MAS_PAYMODE] where ACTIVEFLAG='Y' and TYPE_CODE = 'R'";
                    break;
                case "CorrespondentPayMode":
                    sql = @"SELECT distinct  CAST(PAYCODE AS varchar(50)) as Id, DESCRIPTION as Text  FROM VN_MAS_PAYMODE b where b.ACTIVEFLAG = 'Y' and b.LANGCODE = 'EN' and TYPE_CODE = 'R' and b.PAYCODE  in (SELECT PAYCODE FROM VN_REF_SERV_PAYMODE where [CONFIGCODE] = @param2)";
                    parameter.Add("param2", Int32.Parse(Id), DbType.Int32);
                    break;
                case "UserGroupMast":
                    sql = @"SELECT CAST(UserGroupID AS varchar(20)) as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND UserGroupID=@UserGroupID";
                        parameter.Add("UserGroupID", Int32.Parse(Id), DbType.Int32);
                    }
                    break;
                case "PAYMODECURRENCY":
                    sql = @"SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CURRENCY as Text FROM PaymentModeCurrency where ACTIVEFLAG ='Y' ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND CURCODE=@CURCODE";
                        parameter.Add("CURCODE", Id, DbType.String);
                    }
                    break;
                case "PAYMENTVOUCH":
                    sql = @"SELECT CAST(ACCCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM DX_MST_ACCOUNTS where PAYMENTFLG ='Y' ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND DESCRIPTION=@DESCRIPTION";
                        parameter.Add("DESCRIPTION", Id, DbType.String);
                    }
                    break;
                case "JVAccounts":
                    sql = @"SELECT CAST(ACCCODE AS varchar(20)) as Id, DESCRIPTION + ' - ' + ACCCODE as Text FROM DX_MST_ACCOUNTS where ISCONTROLACNT ='N'AND ACCLEVEL=5 AND  ACCGRPCODE NOT IN ( '100112131','100112132') ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND DESCRIPTION=@DESCRIPTION";
                        parameter.Add("@DESCRIPTION", Id, DbType.String);
                    }
                    break;
                case "JVReports":
                    sql = @"SELECT CAST(ACCCODE AS varchar(20)) as Id, DESCRIPTION + ' - ' + ACCCODE as Text FROM DX_MST_ACCOUNTS where ISCONTROLACNT ='N'AND ACCLEVEL=5  ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND DESCRIPTION=@DESCRIPTION";
                        parameter.Add("@DESCRIPTION", Id, DbType.String);
                    }
                    break;
                case "JVTYPE":
                    sql = @"SELECT CAST(Type AS varchar(20)) as Id, Description  as Text FROM JournalType ";

                    break;

                case "MenuModule":

                    sql = @"SELECT CAST(MenuId AS varchar(20)) as Id, MenuName as Text FROM Menu where  ACTIVEFLG = 'Y'";
                    break;
                case "Cashier":

                    sql = @"SELECT CAST(CashierCode AS varchar(20)) as Id, CashierName as Text FROM CashierMst ";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" where BranchCode=@BranchCode";
                        parameter.Add("@BranchCode", Id, DbType.String);
                    }
                    break;
                case "LOCALBANK":

                    sql = @"SELECT DISTINCT CAST(BankCode AS varchar(20)) as Id, BankName as Text FROM LocalBank ";
                    break;
                case "LOCALBANKLEDGER":

                    sql = $"SELECT CAST(BankLedgerCode AS varchar(20)) as Id, BankLedgerName +   '(' + BankLedgerCode +')' as Text FROM LocalBank WHERE BankCode=@BankCode AND CurCode=@CurCode ";
                    parameter.Add("BankCode", Id, DbType.String);
                    parameter.Add("CurCode", Parameter, DbType.String);
                    break;
                case "ServiceMaster":

                    sql = $"SELECT CAST(trim(ServCode) AS varchar(20)) as Id, ServiceName as Text FROM ServiceMaster ";
                    break;
                case "CorresPonSearch":

                    sql = $" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgCode IN( SELECT SERVORGCODE FROM  VN_MAS_SERVICECONFIG ) ";
                    break;
                case "CorresPonSearchInComing":

                    sql = $" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgCode IN( SELECT SERVORGCODE FROM  VN_MAS_SERVICECONFIG where ServCode = @ServCode) ";
                    parameter.Add("ServCode", Id, DbType.String);
                    break;
                case "CustomerGroups":

                    sql = $" SELECT CAST(CustGroup AS varchar(100)) as Id,  CustGroup as Text FROM  CustomerGroups  ";
                    break;
                //case "CodeType":
                //    sql = @" SELECT CAST(CODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_ORG_BRANCH_CODETYPE where ACTIVEFLG='Y' ";
                //    break;

                case "RateFrom":

                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00005' ";
                    break;
                case "CorrespondentSearch":

                    sql = $" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgCode IN( SELECT SERVORGCODE FROM  VN_MAS_SERVICECONFIG )";
                    break;
                case "CorrespondentBank":

                    sql = $" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgCode IN( SELECT SERVORGCODE FROM  VN_MAS_SERVICECONFIG ) and OrgTypeId=2 ";
                    break;
                case "CorrespondentAgent":

                    sql = $" SELECT CAST(OrgCode AS varchar(20)) as Id,  OrgName as Text FROM  Organization where ActiveFlag='Y' AND OrgCode IN( SELECT SERVORGCODE FROM  VN_MAS_SERVICECONFIG ) and OrgTypeId!=2 ";
                    break;

                case "SMSFrom":

                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00008' ";
                    break;
                case "BlockedCustomer":

                    sql = $"SELECT Custcode as Id , Name1 +' '+ Name2+' '+Name3 as Text FROM customer_mst where Activeflg = 'Y' and Custcode not in (SELECT  [CUSTCODE]  FROM VN_REF_SERV_BLOCKED_CUSTOMER where CONFIGCODE = @ConfigCode)";
                    parameter.Add("ConfigCode", Id, DbType.String);
                    break;
                case "BlockedCustNationality":

                    sql = $"SELECT  ConCode as Id,Nationality  as Text  from Country WHERE ACTIVEFLAG = 'Y' and ConCode not in (SELECT COUNTRYCODE FROM VN_REF_SERV_BLOCKED_COUNTRY where TYPE = 'C' and CONFIGCODE = @ConfigCode)";
                    parameter.Add("ConfigCode", Id, DbType.String);
                    break;
                case "BlockedBenNationality":

                    sql = $"SELECT  ConCode as Id,Nationality  as Text  from Country WHERE ACTIVEFLAG = 'Y' and ConCode not in (SELECT COUNTRYCODE FROM VN_REF_SERV_BLOCKED_COUNTRY where TYPE = 'B' and CONFIGCODE = @ConfigCode)";
                    parameter.Add("ConfigCode", Id, DbType.String);
                    break;
                case "DeductType":

                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00002' ";
                    break;
                case "ChargeType":

                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00007' ";
                    break;
                case "AmtPerc":

                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00003' ";
                    break;
                case "ServiceRuleOrgn":

                    sql = $" SELECT DISTINCT MC.CONFIGCODE AS Id,  MO.ORGNAME + '-' + MC.SERVORGCODE Text FROM ORGANIZATION MO, VN_MAS_SERVICECONFIG MC" +
                           " WHERE MO.ORGCODE = MC.SERVORGCODE AND MC.SERVCODE = @SerCode  AND MC.ACTIVEFLAG = 'Y' " +
                           " UNION " +
                           " SELECT DISTINCT MC.CONFIGCODE AS Id, MO.ORGNAME + '-' + MC.SERVORGCODE Text FROM ORGANIZATION MO, VN_MAS_SERVICECONFIG MC" +
                           " WHERE MO.ORGCODE = MC.SERVORGCODE AND MC.SERVCODE = @SerCode AND MC.ACTIVEFLAG = 'Y'";
                    parameter.Add("SerCode", Id, DbType.String);
                    break;
                case "CurrencyAccount":
                    sql = @" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency WHERE (LedgerAccode IS NULL  OR LedgerAccode ='')  order by CurrencyName";
                    break;
                case "ServCountry":

                    sql = $" select distinct CAST(tc.ConCode AS varchar(100)) as Id ,tc.CountryName as Text from Country tc,VN_REF_SERVCOUNTRY ts where ts.COUNTRYCODE=tc.ConCode ";
                    break;
                case "ServCurr":

                    sql = $" select distinct CAST(trim(tc.CurCode) AS varchar(100)) as Id ,tc.CurrencyName as Text from Currency tc, VN_REF_SERVCOUNTRY ts where ts.CURCODE=tc.CurCode" +
                        $" and ts.COUNTRYCODE=@CONCODE ";
                    parameter.Add("CONCODE", Id, DbType.String);
                    break;
                case "ServService":

                    sql = $" select distinct CAST(trim(tc.SERVCODE) AS varchar(100)) as Id ,tc.ServiceName as Text from ServiceMaster tc, VN_REF_SERVCOUNTRY ts where ts.SERVCODE=tc.SERVCODE" +
                            $" and ts.COUNTRYCODE = @CONCODE and ts.CURCODE = @CURCODE";
                    parameter.Add("CURCODE", Id, DbType.String);
                    parameter.Add("CONCODE", Parameter, DbType.String);
                    break;
               
                case "BenfBank":
                    
                    sql = $" select  CAST(trim(OrgCode) AS varchar(100)) as Id ,OrgName as Text from Organization where OrgTypeId = 2 and ActiveFlag = 'Y' ";
                    break;
                case "BenfBankBranch":
                    
                    sql = $" select  CAST(BranchCode AS varchar(100)) as Id ,BranchName as Text from OrgnizationBranch where OrgCode IN(select OrgCode from Organization where OrgTypeId = 2) and ActiveFlag = 'Y' ";
                    break;

                case "MatchMethod":

                    sql = $" select CAST(METHODCODE as varchar(100)) as Id,DESCRIPTION as Text from VN_MAS_BLACKLIST_MODE where ACTIVEFLAG='Y'";
                    break;
                case "AMLLISTTYPE":
                    sql = @" SELECT CAST(AMLTYPECODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_AMLLISTTYPE  ";
                    break;
                case "AMLCATEGORY":
                    sql = @" SELECT CAST(CATEGORYCODE AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_MAS_AMLCATEGORY  ";
                    break;
                case "TransType":
                    sql = @"select CAST(COde as varchar(20))as Id,Description as Text  from TransType where Activeflag='Y'";
                    break;
                case "Language":
                    sql = @"select LANGCODE as Id,LANGUAGE as Text from VN_MAS_LANGUAGE where ACTIVEFLAG='Y'";
                    break;
                case "Valuedate":
                    sql = @"select CAST(ID as varchar(1)) as Id,DESCRIPTION as Text from VN_MAS_VALUEDATE_DEALING where ACTIVEFLAG='Y'";
                    break;

                case "ALLOWMODULE":
                    sql = @"select CAST(Code as varchar(50)) as Id,Name as Text from PEP_ALLOW_MODULES where ACTIVEFLG='Y'";
                    break;
                case "ReconcilLedger":
                    sql = @"select distinct a.DESCRIPTION +   ' - '+b.LEDGER_ACNT as Text,b.LEDGER_ACNT as Id from DX_MST_ACCOUNTS a, VN_MAS_SERVICECONFIG_ACCOUNTS b
                            where  a.ACCCODE=b.LEDGER_ACNT and b.SERVORGCODE IN(select OrgCode from Organization where OrgTypeId=2) and ACTIVEFLAG='Y'";
                    break;
                case "ApiFileType":
                    sql = $" SELECT CAST(STATUS_ID AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00011' ";
                    break;
                case "FundManagerRecacc":
                    sql = @"select a.DESCRIPTION as Text,b.LEDGER_ACNT as Id from DX_MST_ACCOUNTS a, VN_MAS_SERVICECONFIG_ACCOUNTS b  where  a.ACCCODE=b.LEDGER_ACNT and b.SERVORGCODE=@SERVORGCODE";
                    parameter.Add("SERVORGCODE", Id, DbType.String);
                    break;                    
                case "RemitRateCurrency":
                    sql = $" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency where CurCode Not in ( select CURCODE from Remittance_Rate_Margin where BRANCHCODE=@BRANCHCODE )  ";
                    parameter.Add("BranchCode", Id, DbType.String);
                    break;
                case "StopPayReason":
                    sql = @"SELECT CAST(REASONID AS varchar(50)) as Id, REASON as Text FROM VN_MAS_STOP_PAY_REASON where ACTIVEFLAG='Y'";
                    break;
                case "CustStatus":

                    sql = $" SELECT CAST(TRIM(ORDER_BY) AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00012' ";
                    break;
                case "FACategory":
                    sql = $" SELECT CAST(FA_CAT_ID AS varchar(100)) as Id,  FA_CATEGORY as Text FROM  PB_TBL_FA_CATEGORY WHERE FA_STATUS<>0 ";
                    break;
                case "FAVendor":
                    sql = $" SELECT CAST(FA_VENDOR_ID AS varchar(100)) as Id,  FA_VENDOR as Text FROM  PB_TBL_FA_VENDOR where FA_STATUS<>0  ";
                    break;
                case "FAItem":
                    sql = $" SELECT CAST(FA_ITEM_ID AS varchar(100)) as Id,  FA_ITEM as Text FROM  PB_TBL_FA_ITEM  where FA_CATEGORY=@catCode and status<>0 ";
                    parameter.Add("catCode", Id, DbType.String);
                    break;
                case "FAPrID":
                    sql = $"SELECT CAST(PURCHASE_ID AS varchar(100)) as Id,  QUATATN_NO + '-' + INVOICE_NO as Text FROM  PB_TBL_ITEM_MASTER  where STATUS=1";
                    break;
                case "FABranchID":
                    sql = $" SELECT distinct CAST(t.PAYMENT_BR AS varchar(100)) as Id,  a.BranchName as Text FROM PB_TBL_ITEM_DTL t,OrgnizationBranch a where t.PAYMENT_BR=a.BranchCode   and a.OrgCode=0001 and t.STATUS = 2";
                    break;
                case "FAselCategory":
                    sql = $" SELECT distinct CAST(t.FA_CATEGORY AS varchar(100)) as Id,  a.FA_CATEGORY as Text FROM PB_TBL_ITEM_DTL t,PB_TBL_FA_CATEGORY a where t.FA_CATEGORY=a.FA_CAT_ID     and t.STATUS =2 and t.PAYMENT_BR=@brcode";
                    parameter.Add("brcode", Id, DbType.String);
                    break;
                case "FAselItem":
                    sql = $"  SELECT distinct CAST(t.ITEM_ID AS varchar(100)) as Id,  a.FA_ITEM + ' - ' + t.ITEM_ID as Text FROM PB_TBL_ITEM_DTL t,PB_TBL_FA_ITEM a where t.FA_ITEM=a.FA_ITEM_ID  and t.STATUS =2 and t.FA_CATEGORY=@catcode and t.PAYMENT_BR=@brcode";
                    parameter.Add("catcode", Id, DbType.String);
                    parameter.Add("brcode", Parameter, DbType.String);
                    break;
                case "DepBranchID":
                    sql = $"select distinct CAST(t.PAYMENT_BR AS varchar(100)) as Id,  a.BranchName as Text  from PB_TBL_ITEM_DTL t, OrgnizationBranch a,PB_TBL_ITEM_MASTER s where t.PAYMENT_BR =a.BranchCode and a.OrgCode=0001 and t.PURCHASE_ID=s.PURCHASE_ID and s.status=2  ";
                    break;
                case "FAAccounts":
                    sql = @"SELECT CAST(ACCCODE AS varchar(20)) as Id, DESCRIPTION + ' - ' + ACCCODE as Text FROM DX_MST_ACCOUNTS where ISCONTROLACNT ='N'AND ACCLEVEL=5 AND  ACCGRPCODE  IN ( '100122131')";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND DESCRIPTION=@DESCRIPTION";
                        parameter.Add("@DESCRIPTION", Id, DbType.String);
                    }
                    break;
                case "DEPAccounts":
                    sql = @"SELECT CAST(ACCCODE AS varchar(20)) as Id, DESCRIPTION + ' - ' + ACCCODE as Text FROM DX_MST_ACCOUNTS where ISCONTROLACNT ='N'AND ACCLEVEL=5 AND  ACCGRPCODE  IN ( '100122231')";
                    if (Id != "" && Id != "a2")
                    {
                        sql += $" AND DESCRIPTION=@DESCRIPTION";
                        parameter.Add("@DESCRIPTION", Id, DbType.String);
                    }
                    break;
                case "FASaleAuthBrID":
                    sql = $" SELECT distinct CAST(t.BRANCHCODE AS varchar(100)) as Id,  a.BranchName as Text FROM PB_TBL_ITEM_SALE t,OrgnizationBranch a where t.BRANCHCODE=a.BranchCode   and a.OrgCode=0001 and t.STATUS = 1";
                    break;
                case "FASaleAuthCat":
                    sql = $" SELECT distinct CAST(t.FA_CATEGORY AS varchar(100)) as Id,  a.FA_CATEGORY as Text FROM PB_TBL_ITEM_SALE t,PB_TBL_FA_CATEGORY a where t.FA_CATEGORY=a.FA_CAT_ID     and t.STATUS =1 and t.BRANCHCODE=@brcode";
                    parameter.Add("brcode", Id, DbType.String);
                    break;
                case "FAWritAuthBrID":
                    sql = $" SELECT distinct CAST(t.BRANCHCODE AS varchar(100)) as Id,  a.BranchName as Text FROM PB_TBL_ITEM_WRITOF t,OrgnizationBranch a where t.BRANCHCODE=a.BranchCode   and a.OrgCode=0001 and t.STATUS = 1";
                    break;
                case "FAWritAuthCat":
                    sql = $" SELECT distinct CAST(t.FA_CATEGORY AS varchar(100)) as Id,  a.FA_CATEGORY as Text FROM PB_TBL_ITEM_WRITOF t,PB_TBL_FA_CATEGORY a where t.FA_CATEGORY=a.FA_CAT_ID     and t.STATUS =1 and t.BRANCHCODE=@brcode";
                    parameter.Add("brcode", Id, DbType.String);
                    break;
                case "PromoType":

                    sql = $" SELECT CAST(TRIM(STATUS_ID) AS varchar(100)) as Id,  DESCRIPTION as Text FROM  VN_SYS_STATUS_MASTER where MODULE_ID = '00001' and OPTION_ID = '00013' ";
                    break;

                    ////AML RULES
                case "RULETYPE":

                    sql = $" SELECT CAST(TRIM(RULETYPE) AS varchar(100)) as Id,  DESCRIPTION as Text FROM  AML_RULE_TYPE ";
                    break;
                case "RULEMODULE":

                    sql = $" SELECT CAST(TRIM(MODULE) AS varchar(100)) as Id,  DESCRIPTION as Text FROM  AMLRULE_TYPE_MODULE ";
                    break;
                case "RULEACTION":

                    sql = $" SELECT CAST(TRIM(ACTION) AS varchar(100)) as Id,  DESCRIPTION as Text FROM  AML_RULE_ACTION ";
                    break;
                case "RULEFIELDTRANS":

                    sql = $" SELECT ID as Id,  DISPLAYNAME as Text FROM  VN_AML_RULE_FIELDS where PARENTID=0 order by sortorder asc";
                    break;
                case "RULEOPERATOR":

                    sql = $" SELECT sqlcode as Id,  symbol as Text FROM  AML_RULE_OPERATORS where displayflag='2' ";
                    break;
                case "RULEOPERATORMULTI":

                    sql = $" SELECT sqlcode as Id,  symbol as Text FROM  AML_RULE_OPERATORS where displayflag='1' ";
                    break;
                case "RULEPERIOD":

                    sql = $" SELECT Code as Id,  Description as Text FROM  AML_RULE_PERIOD ";
                    break;
                case "RULEMODULEAPPLY":

                    sql = $" SELECT Code as Id,  Description as Text FROM  AML_RULE_MODULE_APPLY ";
                    break;
                case "RULECUSTOMER":

                    sql = $" select Custcode as Id,concat(Custcode,' - ',Name1,' ',Name2) as Text from customer_mst where Activeflg='Y' ";
                    break;

                /////Rule end
                default:
                    sql = @"SELECT CAST(UserGroupID AS varchar(20)) as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y";
                    break;
            }

            var DataList = await Db.QueryAsync<ForexModel.DropDwnListIdText>(sql, parameter);





            return DataList.ToList();
        }

        public async Task<ForexModel.DropDwnListIdText> GetDropDwnText(string dropType, string Id = "")
        {
            string sql = "";
            DynamicParameters parameter = new DynamicParameters();

            switch (dropType)
            {


                case "Country":
                    sql = @" SELECT CAST(ConCode AS varchar(20)) as Id, CountryName as Text FROM Country where ActiveFlag='Y' ";
                    if (Id != "")
                    {
                        sql += $" AND ConCode=@ConCode";
                        parameter.Add("ConCode", Id, DbType.String);
                    }
                    break;
                case "Currency":
                    sql = @" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CurrencyName as Text FROM Currency ";
                    if (Id != "")
                    {
                        sql += $" AND CurCode=@CurCode";
                        parameter.Add("CurCode", Id, DbType.String);
                    }
                    break;
                case "ForexCurrency":
                    sql = @" SELECT CAST(trim(CurCode) AS varchar(20)) as Id, CURRENCY as Text FROM RATESHEET where ORGCODE='00001' AND BRANCHCODE='00000' AND CORRORGCODE='00001' ";
                    if (Id != "")
                    {
                        sql += $" AND CURCODE=@CURCODE";
                        parameter.Add("CURCODE", Id, DbType.String);
                    }
                    break;
                case "ForextType":
                    sql = @" SELECT CAST(TYPE AS varchar(20)) as Id, TEXT as Text FROM  FOREXTYPE";

                    break;
                case "IDTYPECODE":
                    sql = @" SELECT CAST(IDTYPCODE AS varchar(50)) as Id, IDTYPE as Text FROM IDTYPE";
                    if (Id != "")
                    {
                        sql += $"  WHERE IDTYPCODE=@IdCode";
                        parameter.Add("IdCode", Id, DbType.String);
                    }

                    break;
                case "UserGroupMast":
                    sql = @"SELECT CAST(UserGroupID AS varchar(20)) as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y ";
                    if (Id != "")
                    {
                        sql += $" AND UserGroupID=@UserGroupID";
                        parameter.Add("UserGroupID", Int32.Parse(Id), DbType.String);
                    }
                    break;
                case "CustomerGroups":

                    sql = $" SELECT CAST(CustGroup AS varchar(100)) as Id,  CustGroup as Text FROM  CustomerGroups  ";
                    break;

                default:
                    sql = @"SELECT CAST(UserGroupID AS varchar(20)) as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y";
                    break;
            }

            var DataList = await Db.QueryFirstOrDefaultAsync<ForexModel.DropDwnListIdText>(sql, parameter);





            return DataList;
        }

        public async Task<IEnumerable<ForexModel.DropDwnListIdText>> GetDropDwnListText(string dropType, string Id = "", string Parameter1 = "", string Parameter2 = "", string Parameter3 = "")
        {
            string sql = "";
            DynamicParameters parameter = new DynamicParameters();

            switch (dropType)
            {

                case "SysControl":
                    
                    sql = @" SELECT CAST(STATUS_ID AS varchar(20)) as Id, DESCRIPTION as Text FROM VN_SYS_STATUS_MASTER 
                                where MODULE_ID=@Parameter1 and OPTION_ID=@Parameter2 and REMARKS=@Parameter3 ";
                    parameter.Add("Parameter1", Parameter1, DbType.String);
                    parameter.Add("Parameter2", Parameter2, DbType.String);
                    parameter.Add("Parameter3", Parameter3, DbType.String);

                    break;

                case "ServOrg":

                    //sql = $" select distinct CAST(tg.OrgCode AS varchar(100)) as Id ,tg.OrgName as Text  from Organization tg, VN_REF_SERVCOUNTRY ts" +
                    //    $" where ts.SERVORGCODE = tg.OrgCode and ts.SERVCODE =@SRVCODE and ts.CURCODE=@CURCODE and ts.COUNTRYCODE=@CONCODE";
                    sql = $"SELECT CAST(a.SERVORGCODE AS varchar(100)) as Id, a.PortalCode, a.OrgCode, b.OrgTypeName OrgType, h.ORGNAME   as Text, c.CurrencyName CurCode, d.ServCode ServCode," +
                        $" e.CurrencyName+'-'+a.OCHRGCURCODE OchrgCurCode, i.CurrencyName SCHRGCURCODE FROM VN_MAS_SERVICECONFIG a,OrgType b,Currency c,ServiceMaster d," +
                        $"Currency e,Organization h,Currency i where h.OrgTypeId = b.OrgTypeId and a.CurCode = c.CurCode and  a.ServCode = d.ServCode and a.OCHRGCURCODE = e.CurCode " +
                        $"and a.ServOrgCode = h.ORGCODE and a.SCHRGCURCODE = i.CurCode and  a.CurCode = @CURCODE and a.ServCode = @SRVCODE and a.ActiveFlag = 'Y' order by a.ConfigCode";

                    parameter.Add("SRVCODE", Id, DbType.String);
                    parameter.Add("CURCODE", Parameter1, DbType.String);
                    parameter.Add("CONCODE", Parameter2, DbType.String);
                    

                    break;

                case "ServCorresp":

                    sql = @" select trim(ts.CONFIGCODE) as Id,ta.OrgName as Text from VN_REF_SERVCOUNTRY ts,Organization ta  where ts.SERVORGCODE=ta.OrgCode 
                            and ts.COUNTRYCODE=@CONCODE and ts.CURCODE=@CURCODE and ts.SERVCODE=@SRVCODE";
                    parameter.Add("CONCODE", Parameter1, DbType.String);
                    parameter.Add("CURCODE", Parameter2, DbType.String);
                    parameter.Add("SRVCODE", Parameter3, DbType.String);

                    break;
                default:
                    sql = @"SELECT CAST(UserGroupID AS varchar(20)) as Id, UserGroupName as Text FROM UserGroupMast where ActiveFlag='Y";
                    break;
            }

            var DataList = await Db.QueryAsync<ForexModel.DropDwnListIdText>(sql, parameter);

            return DataList.ToList();

        }
    }
}
    
