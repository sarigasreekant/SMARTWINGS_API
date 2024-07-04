using Dapper;
using DataAccess;
using Helper;
using SMARTWINGS_API.Model.Forex;
using System.Data;

namespace ForexDataService
{

    public class ForexHederDataService: IForexHederDataService
    {
        
        private readonly ISqlDataAccess Db;
        public ForexHederDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        IUnitOfWork unitOfWork = null;
        public async Task<ForexTransHeader> GetForexTransHeader(string Refno)
        {
            string sql = @" SELECT OrgCode ,Refno ,Branchcode ,Custcode,UserId  ,CashierCode ,Trandate,CustType,Name1,Name2,Name3,Cell1,Cell2,Phone,Gender,
                            Adrees1,Adrees2,Place,Street,City,State,Concode,Country,Pobox,Nationcode,Nationality,Profession,Mail,Fax,Remarks,Remark2,Dob,
                            IdNo,IdDescription,IdCode,IdIssueplace,IdIssueCountry,IdIssueDate,IdExpDate,IdRemarks,CancelId,CancelUserID,CancelDate,
                            CancelReason,CancelAuthUserID,CancelAuthDate,Purpose,PurposeCode,PurposeRemarks,Source,SourCode,SourceRemarks,JVDocno,
                            ServiceCharge,Tax,ISCBReported,ISxmlReported 
                           from Forex_TransHeader where Refno =@Refno ";

            var parameters = new DynamicParameters();
            parameters.Add("@Refno", Refno.ToUpper(), DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<ForexTransHeader>(sql, parameters);

            return Data;
        }
        public async Task<IEnumerable<ForexTranDetails>> GetForexTranDetails(string Refno)
        {
            string sql = @"SELECT OrgCode, Refno, Branchcode, SerNo, Trandate, UserId, CashierCode, TranType, CurCode, FxAmnt, EquvAmnt ,Rate,Profit,AvgRate,CostRate
                     FROM Forex_TranDetails WHERE Refno= @Refno";
            var parameters = new DynamicParameters();
            parameters.Add("@Refno", Refno.ToUpper(), DbType.String);
            var DataList = await Db.QueryAsync<ForexTranDetails>(sql, parameters);

            return DataList;
        }
        public async Task<ForexTransHeader> GetForexTransHeaderSearch(string Refno)
        {
            string sql = @" SELECT a.OrgCode ,a.Refno ,a.Branchcode ,Custcode,a.UserId  ,a.CashierCode ,Trandate,CustType,Name1,Name2,Name3,Cell1,Cell2,
                                a.Phone,Gender,Adrees1,Adrees2,Place,a.Street,a.City,a.State,Concode,a.Country,a.Pobox,Nationcode,Nationality,Profession,
                                Mail,Fax,Remarks,Remark2,Dob,IdNo,IdDescription,IdCode,IdIssueplace,IdIssueCountry,IdIssueDate,IdExpDate,IdRemarks,
                                CancelId,CancelUserID,CancelDate,CancelReason,CancelAuthUserID,CancelAuthDate,Purpose,PurposeCode,PurposeRemarks,Source,
                                SourCode,SourceRemarks,a.JVDocno,ServiceCharge,Tax,ISCBReported,ISxmlReported,b.BranchName 
                            from OrgnizationBranch b,Forex_TransHeader a 
                                where a.OrgCode = b.OrgCode  and a.Branchcode = b.BranchCode and a.Refno =@Refno ";

            var parameters = new DynamicParameters();
            parameters.Add("@Refno", Refno.ToUpper(), DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<ForexTransHeader>(sql, parameters);

            return Data;
        }
        public async Task<IEnumerable<ForexTranDetails>> GetForexTranDetailsSearch(string Refno)
        {
            string sql = @"SELECT a.OrgCode, a.Refno, a.Branchcode, SerNo, Trandate, UserId, CashierCode, TranType, CurCode, FxAmnt, EquvAmnt ,Rate,
                                Profit,AvgRate,CostRate,b.BranchName
                           FROM OrgnizationBranch b , Forex_TranDetails a  
                            WHERE a.OrgCode = b.OrgCode  and a.Branchcode = b.BranchCode and a.Refno= @Refno";
            var parameters = new DynamicParameters();
            parameters.Add("@Refno", Refno.ToUpper(), DbType.String);
            var DataList = await Db.QueryAsync<ForexTranDetails>(sql, parameters);

            return DataList;
        }
        public async Task<IEnumerable<ForexTranDetails>> GetForexTranDetailsForeCancel(string Refno,string CancelId)
        {
            string sql = @"SELECT FH.OrgCode, FD.Refno, FD.Branchcode, FD.SerNo, FD.Trandate, FD.UserId, FD.CashierCode, FD.TranType, FD.CurCode, 
                                FD.FxAmnt, FD.EquvAmnt ,FD.Rate,FD.Profit,FD.AvgRate,FD.CostRate  
                           FROM Forex_TranDetails AS FD 
                            inner join  Forex_TransHeader AS FH  on FD.Refno =FH.Refno  
                           WHERE FH.Refno= @Refno  AND FH.CancelId=@CancelId ";
            var parameters = new DynamicParameters();
            parameters.Add("@Refno", Refno, DbType.String);
            parameters.Add("@CancelId", CancelId.Trim(), DbType.String);
            var DataList = await Db.QueryAsync<ForexTranDetails>(sql, parameters);

            return DataList;
        }
        public async Task<int> CancelForexTransHeaderRequest(ForexTransHeader forex_transheader)
        {
            string sql = @"SP_Forex_Cancel";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@CancelId", forex_transheader.CancelId, DbType.String);
            parameters.Add("@UserID", forex_transheader.CancelUserID, DbType.String);
            parameters.Add("@TranDate", forex_transheader.CancelDate, DbType.DateTime);
            parameters.Add("@CancelReason", forex_transheader.CancelReason, DbType.String);
            parameters.Add("@Type", "CancelRequest", DbType.String);


            int rval = 0;
            try
            {
                rval = await Db.ExecuteAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
#pragma warning disable CS0162 // Unreachable code detected
                rval = 0;
#pragma warning restore CS0162 // Unreachable code detected
            }
            return rval;
        }
        public async Task<int> CancelForexTransHeaderRequestDTO(ForexTransHeaderCancelDTO forex_transheader)
        {
            string sql = @"SP_Forex_Cancel";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@CancelId", forex_transheader.CancelId, DbType.String);
            parameters.Add("@UserID", forex_transheader.CancelUserID, DbType.String);
            parameters.Add("@TranDate", forex_transheader.CancelDate, DbType.DateTime);
            parameters.Add("@CancelReason", forex_transheader.CancelReason, DbType.String);
            parameters.Add("@Type", "CancelRequest", DbType.String);

            int rval = 0;
            try
            {
                rval = await Db.ExecuteAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
#pragma warning disable CS0162 // Unreachable code detected
                rval = 0;
#pragma warning restore CS0162 // Unreachable code detected
            }
            return rval;
        }
        public async Task<int> CancelForexTransHeaderRequestAuth(ForexTransHeaderCancelDTO forex_transheader)
        {
            string sql = @"SP_Forex_Cancel";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@CancelId", forex_transheader.CancelId, DbType.String);
            parameters.Add("@UserID", forex_transheader.CancelUserID, DbType.String);
            parameters.Add("@TranDate", forex_transheader.CancelDate, DbType.DateTime);
            parameters.Add("@CancelReason", "Cancel Authrization", DbType.String);
            parameters.Add("@Type", "CancelAuthrization", DbType.String);

            int rval = 0;
            try
            {
                rval = await Db.ExecuteAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
#pragma warning disable CS0162 // Unreachable code detected
                rval = 0;
#pragma warning restore CS0162 // Unreachable code detected
            }
            return rval;
        }
        public async Task<IEnumerable<ForexTranDetails>> GetForexForDatshBoard(string UserId)
        {
            string sql = @"SELECT OrgCode, Refno, Branchcode, SerNo, Trandate, UserId, CashierCode, TranType, CurCode, FxAmnt, EquvAmnt ,Rate,Profit,AvgRate,CostRate
                     FROM Forex_TranDetails WHERE CONVERT(VARCHAR(10), TRANDATE, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                 sql += @" and UserId =@UserId";
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            sql += @" UNION ALL 
                    select Orgcode,RefNo,Branchcode,0,Trandate,UserCode,CashierCode,'','',FcyAmount,LcyAmount,Rate,0,0,0
                    from Remittance where CONVERT(VARCHAR(10), TRANDATE, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
            if (UserId != "")
            {
                sql += @" and UserCode =@UserId";
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            sql += @" UNION ALL 
                    select Orgcode,RefNo,Branchcode,0,Trandate,UserCode,CashierCode,'','',FcyAmount,LcyAmount,Rate,0,0,0
                    from Incoming where CONVERT(VARCHAR(10), TRANDATE, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
            if (UserId != "")
            {
                sql += @" and UserCode =@UserId";
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            var DataList = await Db.QueryAsync<ForexTranDetails>(sql, parameters);

            return DataList;
        }
        public async Task<ForexDashBoard> GetForexCountDatshBoard(string UserId)
        {
            string sql = @" select sum(Amount) as Amount,sum(FCOUNT) as FCOUNT,sum(camount) as camount,sum(Ccont) as Ccont,sum(Acount) as Acount from (
                SELECT 
                      sum([EquvAmnt]) as Amount,
	                  count(1)as FCOUNT,0 as camount,0 as Ccont,0 as Acount
    
                  FROM Forex_TranDetails,Forex_TransHeader
                  where Forex_TranDetails.Refno=Forex_TransHeader.Refno
                  and Forex_TransHeader.CancelId=0 and CONVERT(VARCHAR(10), Forex_TranDetails.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)
                  union all 

                  SELECT 
    
                      0 as Amount,
	                  0 as FCOUNT, sum([EquvAmnt]) as  camount,count(1) as Ccont,0 as Acount
    
                  FROM Forex_TranDetails,Forex_TransHeader
                  where Forex_TranDetails.Refno=Forex_TransHeader.Refno
                  and Forex_TransHeader.CancelId<>0 and 
                 cast([Forex_TranDetails].Trandate as date)= cast(GETDATE() as date)

				 union all 

                  SELECT 
    
                      0 as Amount,
	                  0 as FCOUNT, 0 as  camount,0 as Ccont,count(1) as Acount
    
                  FROM Forex_TranDetails,Forex_TransHeader
                  where Forex_TranDetails.Refno=Forex_TransHeader.Refno
                  and Forex_TransHeader.CancelId=1 and 
                 cast([Forex_TranDetails].Trandate as date)= cast(GETDATE() as date)";
            if (UserId != "")
                sql += @" and Forex_TransHeader.UserId =@UserId";
            sql += @"   )t2 ";
 
            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            var DataList = await Db.QueryFirstOrDefaultAsync<ForexDashBoard>(sql, parameters);

            return DataList;
        }

        public async Task<RemitDashBoard> GetRemitCountDatshBoard(string UserId)
        {
            string sql = @" select sum(FCOUNT) as FCOUNT,sum(camount) as camount,sum(Ccont) as Ccont,sum(Acount) as Acount,sum(Pcount) as Pcount from (
                SELECT 
                      
	                  count(1)as FCOUNT,0 as camount,0 as Ccont,0 as Acount,0 as Pcount
    
                  FROM Remittance
                  where 
                   Remittance.CancelId=0 and CONVERT(VARCHAR(10), Remittance.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)
                  union all 

                  SELECT 
    
                      0 as Amount,
	                  0 as FCOUNT, count(1) as Ccont,0 as Acount,0 as Pcount
    
                  FROM Remittance where
                  Remittance.CancelId<>0 and 
                 cast(Remittance.Trandate as date)= cast(GETDATE() as date)
				  union all 

                  SELECT 
    
                      0 as Amount,
	                  0 as FCOUNT,  0 as Ccont, count(1) as Acount ,0 as Pcount
    
                  FROM Remittance where
                  Remittance.CancelId=1 and 
                 cast(Remittance.Trandate as date)= cast(GETDATE() as date)
				  union all 

                  SELECT 
    
                      0 as Amount,
	                  0 as FCOUNT,  0 as Ccont, 0 as Acount ,count(1) as Pcount
    
                  FROM Remittance where
                  Remittance.PaidFlag='N' and 
                 cast(Remittance.Trandate as date)= cast(GETDATE() as date)";
				 
			

				
            if (UserId != "")
                sql += @" and Remittance.UserId =@UserId";
            sql += @"   )t2 ";

            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            var DataList = await Db.QueryFirstOrDefaultAsync<RemitDashBoard>(sql, parameters);

            return DataList;
        }

        public async Task<IncomingDashBoard> GetIncomCountDatshBoard(string UserId)
        {
            string sql = @" select sum(FCOUNT) as FCOUNT,sum(camount) as camount,sum(Ccont) as Ccont,sum(Pcount) as Pcount from (
                SELECT 
                      
	                  count(1)as FCOUNT,0 as camount,0 as Ccont,0 as Pcount
    
                  FROM Incoming
                  where 
                   Incoming.CancelId=0 and CONVERT(VARCHAR(10), Incoming.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)

				    union all 

             SELECT 
    
                 0 as Amount,
                0 as FCOUNT,  0 as Ccont ,count(1) as Pcount
    
                 FROM Incoming where
                 Incoming.PaidFlag='N' and 
                    cast(Incoming.Trandate as date)= cast(GETDATE() as date)";
            if (UserId != "")
                sql += @" and Remittance.UserId =@UserId";
            sql += @"   )t2 ";

            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            var DataList = await Db.QueryFirstOrDefaultAsync<IncomingDashBoard>(sql, parameters);

            return DataList;
        }
        public async Task<CustDashBoard> GetCustCountDatshBoard(string UserId)
        {
            string sql = @" select sum(FCOUNT) as FCOUNT,sum(camount) as camount,sum(Ccont) as Ccont from (
                SELECT 
                      
	                  count(1)as FCOUNT,0 as camount,0 as Ccont
    
                  FROM customer_mst
                  where 
                    CONVERT(VARCHAR(10), customer_mst.RegDate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
            if (UserId != "")
                sql += @" and Remittance.UserId =@UserId";
            sql += @"   )t2 ";

            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            var DataList = await Db.QueryFirstOrDefaultAsync<CustDashBoard>(sql, parameters);

            return DataList;
        }
        public async Task<IEnumerable<RenderingData>> GetForexCurrencyChartDatshBoard(string UserId)
        {
            string sql = @" SELECT CurCode as X ,sum(FxAmnt) as Y FROM Forex_TranDetails ";
            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                sql += @" WHERE  UserId =@UserId AND CONVERT(VARCHAR(10), Forex_TranDetails.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            sql += @"  group by CurCode";
            var DataList = await Db.QueryAsync<RenderingData>(sql, parameters);

            return DataList;
        }
        public async Task<IEnumerable<IncomeExpense>> GetForexProfitChartDatshBoard(string UserId)
        {
            string sql = @" SELECT CURCODE as CurCode,SUM(Profit) AS Income,SUM(LOSS) AS Expense FROM (
                SELECT CurCode AS CURCODE,Profit as PROFIT ,0 AS LOSS FROM Forex_TranDetails WHERE  PROFIT>0 AND  CONVERT(VARCHAR(10), Forex_TranDetails.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101)";
                   if (UserId != "")
                sql += @" and UserId =@UserId";
            sql += @"  UNION ALL 
            SELECT CurCode AS CURCODE ,0 as PROFIT  ,Profit AS LOSS FROM Forex_TranDetails WHERE  PROFIT<0 AND  CONVERT(VARCHAR(10), Forex_TranDetails.Trandate, 101)= CONVERT(VARCHAR(10), GETDATE(), 101) 
             ";
            if (UserId != "")
                sql += @" and UserId =@UserId";

            var parameters = new DynamicParameters();
            if (UserId != "")
            {
                parameters.Add("@UserId", UserId.ToUpper(), DbType.String);
            }
            sql += @" )T2 GROUP BY CURCODE ";
            var DataList = await Db.QueryAsync<IncomeExpense>(sql, parameters);

            return DataList;
        }
        public async Task<int> SaveForexTranDetails_Mobile(ForexTranDetails_Mob forex_trandetails_Mobile)
        {
            string sql = @" INSERT INTO Forex_TranDetails_Mobile(Orgcode,Mob_Refno, Pickup_Date, Trandate, TranType, Curcode, FxAmnt, Rate, EquvAmnt, 
               AvgRate, CostRate, Create_Date, Custcode, auth_flag, auth_date,auth_user,auth_branch,Activeflg,Paidflg) VALUES (@Orgcode,@Mob_Refno,@Pickup_Date,@Trandate,@TranType,@Curcode,@FxAmnt,@Rate,@EquvAmnt,
			   @AvgRate,@CostRate,@Create_Date,@Custcode,@auth_flag,@auth_date,@auth_user,@auth_branch,@Activeflg,@Paidflg)";
            var parameters = new DynamicParameters();
            parameters.Add("OrgCode", forex_trandetails_Mobile.OrgCode, DbType.String);
            parameters.Add("Mob_Refno", forex_trandetails_Mobile.Mob_Refno, DbType.String);
            parameters.Add("Pickup_Date", forex_trandetails_Mobile.Pickup_Date, DbType.DateTime);
            parameters.Add("Trandate", forex_trandetails_Mobile.Trandate, DbType.DateTime);
            parameters.Add("TranType", forex_trandetails_Mobile.TranType, DbType.String);
            parameters.Add("CurCode", forex_trandetails_Mobile.CurCode, DbType.String);
            parameters.Add("FxAmnt", forex_trandetails_Mobile.FxAmnt, DbType.Decimal);
            parameters.Add("Rate", forex_trandetails_Mobile.Rate, DbType.String);
            parameters.Add("EquvAmnt", forex_trandetails_Mobile.EquvAmnt, DbType.Decimal);
            parameters.Add("AvgRate", forex_trandetails_Mobile.AvgRate, DbType.Decimal);
            parameters.Add("CostRate", forex_trandetails_Mobile.CostRate, DbType.Decimal);
            parameters.Add("Create_Date", forex_trandetails_Mobile.Create_Date, DbType.DateTime);
            parameters.Add("Custcode", forex_trandetails_Mobile.Custcode, DbType.String);
            parameters.Add("auth_flag", forex_trandetails_Mobile.auth_flag, DbType.String);
            parameters.Add("auth_date", forex_trandetails_Mobile.auth_date, DbType.DateTime);
            parameters.Add("auth_user", forex_trandetails_Mobile.auth_user, DbType.String);
            parameters.Add("auth_branch", forex_trandetails_Mobile.auth_branch, DbType.String);
            parameters.Add("Activeflg", forex_trandetails_Mobile.Activeflg, DbType.String);
            parameters.Add("Paidflg", forex_trandetails_Mobile.Paidflg, DbType.String);
            try
            {
                var val = await Db.ExecuteAsync<int>(sql, parameters);
                return val;
            }
            catch (Exception)
            {
                throw;

            }

        }


    }
}
