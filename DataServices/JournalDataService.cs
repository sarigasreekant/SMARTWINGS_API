using Dapper;
using DataAccess;
using ForexModel;
using Helper;
using SMARTWINGS_API.Model.Rate;
using System.Data;
using System.Globalization;

namespace ForexDataService
{
    public class JournalDataService
    {
        IUnitOfWork unitOfWork;
       
        public decimal TotalDebit { get; set; } = 0;
        public decimal TotalCredit { get; set; } = 0;
        public string JvServno { get; set; } = string.Empty;
        public string JVDocNo { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string CashierCode { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string ErorrMessage { get; set; } = "";
        public DateTime Trandate { get; set; } = Convert.ToDateTime(SD.ServerDateTime());
        public JournalDataService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<int> SaveJournal(Journal dx_trns_journal)
        {
            string sql = "[dbo].[spDX_TRNS_JOURNAL_Insert]";
            var parameters = new DynamicParameters();
            parameters.Add("@ORGCODE", dx_trns_journal.ORGCODE.Trim(), DbType.String);
            parameters.Add("@BRANCHCODE", dx_trns_journal.BRANCHCODE.Trim(), DbType.String);
            parameters.Add("@TRANDATE", dx_trns_journal.TRANDATE, DbType.DateTime);
            parameters.Add("@JVDOCNO", dx_trns_journal.JVDOCNO.Trim(), DbType.String);
            parameters.Add("@JVSERNO", dx_trns_journal.JVSERNO.Trim(), DbType.String);
            parameters.Add("@ACCCODE", dx_trns_journal.ACCCODE.Trim(), DbType.String);
            parameters.Add("@NARRATION", dx_trns_journal.NARRATION.ToUpper().Trim(), DbType.String);
            parameters.Add("@TRANTYPE", dx_trns_journal.TRANTYPE.ToUpper().Trim(), DbType.String);
            parameters.Add("@REFNO", dx_trns_journal.REFNO.Trim(), DbType.String);
            parameters.Add("@RATE", dx_trns_journal.RATE, DbType.Decimal);
            parameters.Add("@FXAMT", dx_trns_journal.FXAMT, DbType.Decimal);
            parameters.Add("@EQUVAMT", dx_trns_journal.EQUVAMT, DbType.Decimal);
            parameters.Add("@CUSTCODE", dx_trns_journal.CUSTCODE.Trim(), DbType.String);
            parameters.Add("@USERID", dx_trns_journal.USERID.ToUpper().Trim(), DbType.String);
            parameters.Add("@SERVTYPE", dx_trns_journal.SERVTYPE, DbType.Int16);
            parameters.Add("@REVFLG", dx_trns_journal.REVFLG.Trim(), DbType.String);
            parameters.Add("@CASHIERCODE", dx_trns_journal.CASHIERCODE.ToUpper().Trim(), DbType.String);
            parameters.Add("@ISCASHACNT", dx_trns_journal.ISCASHACNT, DbType.Int16);
           
            try
            {
                int val = await this.unitOfWork.Connection.ExecuteAsync(sql, parameters,unitOfWork.Transaction,commandTimeout:180, commandType: CommandType.StoredProcedure);
                return val;
            }
            catch (Exception  ex)
            {
              
                throw ex;
                
            }




           
        }
        public async Task<bool> CreateJVEntry(string sACCCODE, string sTRANTYPE, decimal nFXAMT, decimal nEQUVAMT, decimal nRATE, string sREFNO, string sNARRATION, string sCUSTCODE, int sSERVTYPE)
        {
            try
            {
                if (nEQUVAMT > 0)
                {
                    var journal = new Journal();

                    journal.ORGCODE = SD.OrgCode;
                    journal.BRANCHCODE = BranchCode;
                    journal.ACCCODE = sACCCODE;
                    journal.TRANTYPE = sTRANTYPE.ToUpper().Trim();
                    journal.FXAMT = nFXAMT;
                    journal.EQUVAMT = nEQUVAMT;
                    journal.RATE = nRATE;
                    journal.REFNO = sREFNO;
                    journal.NARRATION = sNARRATION;
                    journal.CUSTCODE = sCUSTCODE;
                    journal.SERVTYPE = sSERVTYPE;
                    journal.USERID = UserId;
                    journal.CASHIERCODE = CashierCode;
                    journal.TRANDATE = Trandate;

                    if (String.IsNullOrEmpty(journal.USERID))
                    {
                        ErorrMessage = "User Id Mandatory For JV entry ";
                        return false;
                    }
                    if (String.IsNullOrEmpty(journal.CASHIERCODE))
                    {
                        ErorrMessage = "Cashier Code Mandatory For JV entry ";
                        return false;
                    }
                    if (String.IsNullOrEmpty(journal.BRANCHCODE))
                    {
                        ErorrMessage = "BranchCode Mandatory For JV entry ";
                        return false;
                    }
                    if (String.IsNullOrEmpty(JVDocNo))
                    {
                        JVDocNo = await GetJvDocNo(BranchCode);

                    }
                    var Accounts = await GetAccounts(sACCCODE);
                    if (Accounts == null)
                    {
                        ErorrMessage = "Invalid Account No entry";
                        return false;
                    }

                    if (String.IsNullOrEmpty(Accounts.ACCCODE))
                    {
                        ErorrMessage = "Invalid Account No entry " + sACCCODE;
                        return false;
                    }
                    if (String.IsNullOrEmpty(journal.NARRATION))
                    {
                        ErorrMessage = "Narration requird " ;
                        return false;
                    }


                    if (String.IsNullOrEmpty(JvServno))
                        JvServno = "000001";
                    else
                        JvServno = (Convert.ToDouble(JvServno) + 1).ToString().PadLeft(6, '0');

                    journal.JVDOCNO = JVDocNo;
                    journal.JVSERNO = JvServno;

                    if (String.IsNullOrEmpty(journal.JVDOCNO) || String.IsNullOrEmpty(journal.JVSERNO))
                    {
                        ErorrMessage = "Jvdocno and JvServno Mandaotry For JV entry";
                        return false;
                    }
                    int val = 0;
                    if (Accounts != null)
                    {
                       
                        if (Accounts.CURCODE == SD.LocalCurCode)
                        {
                            journal.RATE = 0;
                            journal.FXAMT = 0;
                        }
                        //100112131 local currency //100112132 fx currency //4001222 Exchange varition
                        if (Accounts.ACCGRPCODE == "100112131" || Accounts.ACCGRPCODE == "100112132" || Accounts.ACCGRPCODE == "400122231")
                        {
                            journal.ISCASHACNT = 1;
                        }
                        else
                        {
                            journal.ISCASHACNT = 0;
                        }
                    }
                   
                    val = await SaveJournal(journal);
                    if (val > 0)
                    {
                        if (sTRANTYPE == "C")
                            TotalCredit += journal.EQUVAMT;
                        else
                            TotalDebit += journal.EQUVAMT;
                        return true;
                    }
                    else
                    {
                        JVDocNo = "";
                        JvServno = "";

                        ErorrMessage = "Database Saving Issue";
                        return false;
                    }
                }
                else
                {
                    ErorrMessage = "Lcy amount should be greater than 0";
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErorrMessage = "Database Saving Issue "+ex.Message;
                return false;
            }
        }
        public async Task<string> GetJvDocNo(string BranchCode)
        {
            DateTime dST = DateTime.Now;

            string sql = @" SELECT BranchCode, JvMonth, JVYear, JVDocNo FROM OrgnizationBranch WHERE    OrgCode='00001' AND BranchCode= @BranchCode and JvMonth=@JvMonth and JVYear=@JVYear ";


            OrgnizationBranch Data = new OrgnizationBranch();
            DynamicParameters parameter = new DynamicParameters();
            string sOrgCode = "00001";
            parameter.Add("@BranchCode", BranchCode, DbType.String);
            parameter.Add("@JvMonth", dST.Month, DbType.String);
            parameter.Add("@JVYear", dST.Year, DbType.String);
            decimal jvdIdNo = 0;


            try
            {
                Data = await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<OrgnizationBranch>(sql, parameter, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


            sql = "";
            if (Data != null)
            {
                sql = $"  UPDATE OrgnizationBranch SET JVDOCNO = JVDOCNO+1,JvMonth={dST.Month}, JVYear={dST.Year}   WHERE OrgCode='00001' AND BranchCode = @BranchCode   and JvMonth={dST.Month} and  JVYear={dST.Year}";
                jvdIdNo = Convert.ToDecimal(Data.JVDocNo + 1);
            }
            else
            {
                sql = $"  UPDATE OrgnizationBranch SET JVDOCNO = 1, JvMonth={dST.Month}, JVYear={dST.Year} WHERE  OrgCode='00001' AND BranchCode = @BranchCode ";
                jvdIdNo = 1;
            }

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@BranchCode", BranchCode, DbType.String);

                var rval = await this.unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


            string sID = "JV" + sOrgCode.Substring(sOrgCode.Length - 3, 3) + BranchCode.Substring(BranchCode.Length - 3, 3) + dST.Month.ToString("00") + dST.Year.ToString().Substring(2) + "-" + jvdIdNo.ToString("0000000");


            return sID;


        }
        public async Task<AccountsMaster> GetAccounts(string Accode)
        {
            string sql = @"SELECT  ACCCODE, DESCRIPTION, ACCGRPCODE, TREEPATH, BRANCHFLAG, ENTRYFLAG, CURCODE, 
                   REVALFLAG, ACCLEVEL, CURTYPECODE, ISCONTROLACNT, PAYMENTFLG 
               
               FROM DX_MST_ACCOUNTS  where  ACCCODE= @ACCCODE and ACCLEVEL=5 ";



            var parameters = new DynamicParameters();
            parameters.Add("@ACCCODE", Accode, DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<AccountsMaster>(sql, parameters, unitOfWork.Transaction, 180);

            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<string> GetLedgerAccount(string Accode)
        {
            string sql = @"SELECT  ACCCODE
               FROM DX_MST_ACCOUNTS  where  ACCCODE= @ACCCODE and ACCLEVEL=5 ";



            var parameters = new DynamicParameters();
            parameters.Add("@ACCCODE", Accode, DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, parameters, unitOfWork.Transaction, 180);

            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<Currency> GetCurrencyAccount(string CurCode)
        {
            string sql = @"SELECT CurCode,LedgerAccode,TransitAccode,ExchangeVariAccode,DealingAccode from  Currency WHERE CurCode= @CurCode";

            var parameters = new DynamicParameters();
            parameters.Add("@CurCode", CurCode, DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<Currency>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<string> GetCurrencyLedgerAccount(string CurCode)
        {
            string sql = @"SELECT LedgerAccode from  Currency WHERE CurCode= @CurCode";

            var parameters = new DynamicParameters();
            parameters.Add("@CurCode", CurCode.ToUpper(), DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<decimal> IsStockAvailable(string sCurCode, string sCashierCode, string sBranchCode)
        {


           
            string Sql = "";
            string sAccCode = await this.GetCurrencyLedgerAccount(sCurCode);
            if (sAccCode == "")
                return 0;
            if (sCashierCode == "")
                return 0;
            if (sBranchCode == "")
                return 0;
            if (sCurCode == SD.LocalCurCode || sCurCode == SD.LocalCurCodeRemit)
            {
                Sql = @" SELECT ISNULL(SUM(ISNULL(DX_TRNS_CURR_LEDGER.LCYDR,0)),0) - ISNULL(SUM(ISNULL(DX_TRNS_CURR_LEDGER.LCYCR,0)),0) AS CALBALFX FROM DX_TRNS_CURR_LEDGER WHERE ORGCODE = '00001' AND BRANCHCODE = @BRANCHCODE AND ";
                Sql += $" ACCCODE = @ACCCODE  AND CASHIERCODE = @CASHIERCODE AND TRANDATE >= @FINALYYEAR AND  TRANDATE <= @ENDTRANDATE";

            }
            else
            {

                Sql = @" SELECT ISNULL(SUM(ISNULL(DX_TRNS_CURR_LEDGER.FCYDR,0)),0) - ISNULL(SUM(ISNULL(DX_TRNS_CURR_LEDGER.FCYCR,0)),0) AS CALBALFX FROM DX_TRNS_CURR_LEDGER WHERE ORGCODE = '00001' AND BRANCHCODE = @BRANCHCODE AND ";
                Sql += $" ACCCODE = @ACCCODE  AND CASHIERCODE = @CASHIERCODE AND TRANDATE >= @FINALYYEAR AND  TRANDATE <= @ENDTRANDATE";
            }


            decimal dBal = 0;


            try

            {
                string Fyear = SD.GetFinalYearDate();
                string EndDate = SD.GeCurrentDate();
                var parameters = new DynamicParameters();
                parameters.Add("@BRANCHCODE ", sBranchCode, DbType.String);
                parameters.Add("@ACCCODE", sAccCode, DbType.String);
                parameters.Add("@CASHIERCODE", sCashierCode, DbType.String);
                parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                parameters.Add("@ENDTRANDATE", EndDate, DbType.String);


                dBal = await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<decimal>(Sql, parameters, unitOfWork.Transaction, 180);
                return dBal;
            }
            catch (Exception ex)
            {
                throw ;
               
            }


        }
        public async Task<decimal> FetchAvgRateCashier(string sCurCode, string sCashierCode, string sBranchCode)
        {
            decimal dBal = 0;
            if (sCurCode == "")
                return 0;

            if (sCurCode != SD.LocalCurCode && sCurCode != SD.LocalCurCodeRemit)
            {

               
                string sAccCode = await this.GetCurrencyLedgerAccount(sCurCode);
                if (sAccCode == "")
                    return 0;
                if (sCashierCode == "")
                    return 0;
                if (sBranchCode == "")
                    return 0;
             
                string Sql = @"SELECT ISNULL(ISNULL(SUM(LCYDR) - SUM(LCYCR),0) / ISNULL(SUM(FCYDR) - SUM(FCYCR),0),0)  FROM DX_TRNS_CURR_LEDGER WHERE ORGCODE = '00001' AND BRANCHCODE = @BRANCHCODE AND ACCCODE=@ACCCODE AND CASHIERCODE = @CASHIERCODE
                             AND  TRANDATE >= @FINALYYEAR AND  TRANDATE <= @ENDTRANDATE HAVING SUM(LCYDR) - SUM(LCYCR) > 0 AND SUM(FCYDR) - SUM(FCYCR) > 0";


             


                try
                {
                    string Fyear = SD.GetFinalYearDate();
                    string EndDate = SD.GeCurrentDate();
                    var parameters = new DynamicParameters();
                    parameters.Add("@BRANCHCODE ", sBranchCode.Trim(), DbType.String);
                    parameters.Add("@ACCCODE", sAccCode.Trim(), DbType.String);
                    parameters.Add("@CASHIERCODE", sCashierCode.Trim(), DbType.String);
                    parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                    parameters.Add("@ENDTRANDATE", EndDate, DbType.String);

                    dBal = await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<decimal>(Sql, parameters, unitOfWork.Transaction, 180);
                    return dBal;

                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                }

            }
            else
                return 1;
           
        }
        public async Task<decimal> FetchAvgRateBranch(string CurCode, string BranchCode)
        {
            decimal dBal = 0;
            if (CurCode == "")
                return 0;
            if (CurCode != SD.LocalCurCode)
            {

               

                string sAccCode = await this.GetCurrencyLedgerAccount(CurCode);
                if (sAccCode == "")
                    return 0;
              
                if (BranchCode == "")
                    return 0;

                string Sql = @"SELECT ISNULL(ISNULL(SUM(LCYDR) - SUM(LCYCR),0) / ISNULL(SUM(FCYDR) - SUM(FCYCR),0),0)  FROM DX_TRNS_CURR_LEDGER WHERE ORGCODE = '00001' AND BRANCHCODE = @BRANCHCODE AND ACCCODE =@ACCCODE 
                             AND  TRANDATE >= @FINALYYEAR AND  TRANDATE <= @ENDTRANDATE HAVING SUM(LCYDR) - SUM(LCYCR) > 0 AND SUM(FCYDR) - SUM(FCYCR) > 0";





                try
                {
                    string Fyear = SD.GetFinalYearDate();
                    string EndDate = SD.GeCurrentDate();

                    var parameters = new DynamicParameters();
                    parameters.Add("@BRANCHCODE ", BranchCode, DbType.String);
                    parameters.Add("@ACCCODE", sAccCode, DbType.String);
                 
                    parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                    parameters.Add("@ENDTRANDATE", EndDate, DbType.String);

                    dBal = await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<decimal>(Sql, parameters, unitOfWork.Transaction, 180);
                    return dBal;

                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                }

            }
            else
                return 1;

        }
        public async Task<IEnumerable<Journal>> GetJournalDetails(string Refno,string JvDocno)
        {
            string sql = @"SELECT  [ORGCODE]   ,[BRANCHCODE]  ,[TRANDATE]  ,[JVDOCNO] ,[JVSERNO],[ACCCODE]
                          ,[NARRATION] ,[TRANTYPE]  ,[REFNO],[RATE] ,[FXAMT]  ,[EQUVAMT] ,[CUSTCODE] ,[USERID] ,[SERVTYPE],[REVFLG]
                            ,[CASHIERCODE],[ISCASHACNT]
                             FROM DX_TRNS_JOURNAL WHERE REFNO=@REFNO";

            var parameters = new DynamicParameters();
            parameters.Add("@REFNO", Refno, DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryAsync<Journal>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<string> GetInterBranchLedgerAccount(string BranchCode)
        {
            string sql = @"select OrgnizationBranch.InterBranchAccno from OrgnizationBranch  where OrgnizationBranch.OrgCode='00001' and BranchCode=@BranchCode ";

            var parameters = new DynamicParameters();
            parameters.Add("@BranchCode", BranchCode.ToUpper(), DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


        }
        public async Task<string> GetBranchName(string BranchCode)
        {
            string sql = @"select BranchName from OrgnizationBranch  where OrgnizationBranch.OrgCode='00001' and BranchCode=@BranchCode ";

            var parameters = new DynamicParameters();
            parameters.Add("@BranchCode", BranchCode.ToUpper(), DbType.String);
            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }

        }
        public async Task<string> GetCashierName(string cashierCode)
        {
            string sql = @"select CashierName from CashierMst  where CashierMst.OrgCode='00001' and CashierCode=@cashierCode ";

            var parameters = new DynamicParameters();
            parameters.Add("@cashierCode", cashierCode.ToUpper(), DbType.String);

            try
            {
                return await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception ex)
            {
                throw ;

            }


        }



    }


    
}
