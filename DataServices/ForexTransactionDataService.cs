using Dapper;
using DataAccess;
using ForexModel;
using SMARTWINGS_API.Model.Forex;
using System.Data;


namespace SMARTWINGS_API.DataServices
{
    public class ForexTransactionDataService
    {
        IUnitOfWork unitOfWork = null;
        public ForexTransactionDataService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<int> SaveForexTransHeader(ForexTransHeader forex_transheader)
        {
            string sql = @"INSERT INTO Forex_TransHeader(OrgCode,Refno, Branchcode, Custcode, UserId, CashierCode, Trandate, CustType, Name1, Name2, Name3, Cell1, Cell2, Phone, Gender, Adrees1, Adrees2, Place, Street, 
                    City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, Remarks, Remark2, Dob, IdNo, IdDescription, IdCode, IdIssueplace, IdIssueCountry, IdIssueDate, IdExpDate, IdRemarks, CancelId, 
                  
                 Purpose, PurposeCode, PurposeRemarks, Source, SourCode, SourceRemarks, JVDocno, ServiceCharge, Tax, ISCBReported, ISxmlReported) 
              VALUES (@OrgCode,@Refno, @Branchcode, @Custcode, @UserId, @CashierCode, @Trandate, @CustType, @Name1, @Name2, @Name3, @Cell1, @Cell2, @Phone, @Gender, @Adrees1, @Adrees2, @Place, @Street, @City, @State, @Concode, @Country, @Pobox, @Nationcode, @Nationality, @Profession, @Mail, @Fax, @Remarks, @Remark2, @Dob, @IdNo, @IdDescription, @IdCode, @IdIssueplace, @IdIssueCountry,
           @IdIssueDate, @IdExpDate, @IdRemarks, @CancelId,  @Purpose, @PurposeCode, @PurposeRemarks, @Source, @SourCode, @SourceRemarks, @JVDocno, @ServiceCharge, @Tax, @ISCBReported, @ISxmlReported)";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@Branchcode", forex_transheader.Branchcode, DbType.String);
            parameters.Add("@Custcode", forex_transheader.Custcode, DbType.String);
            parameters.Add("@UserId", forex_transheader.UserId, DbType.String);
            parameters.Add("@CashierCode", forex_transheader.CashierCode, DbType.String);
            parameters.Add("@Trandate", forex_transheader.Trandate, DbType.DateTime);
            parameters.Add("@CustType", forex_transheader.CustType, DbType.String);
            parameters.Add("@Name1", forex_transheader.Name1, DbType.String);
            parameters.Add("@Name2", forex_transheader.Name2, DbType.String);
            parameters.Add("@Name3", forex_transheader.Name3, DbType.String);
            parameters.Add("@Cell1", forex_transheader.Cell1, DbType.String);
            parameters.Add("@Cell2", forex_transheader.Cell2, DbType.String);
            parameters.Add("@Phone", forex_transheader.Phone, DbType.String);
            parameters.Add("@Gender", forex_transheader.Gender, DbType.String);
            parameters.Add("@Adrees1", forex_transheader.Adrees1, DbType.String);
            parameters.Add("@Adrees2", forex_transheader.Adrees2, DbType.String);
            parameters.Add("@Place", forex_transheader.Place, DbType.String);
            parameters.Add("@Street", forex_transheader.Street, DbType.String);
            parameters.Add("@City", forex_transheader.City, DbType.String);
            parameters.Add("@State", forex_transheader.State, DbType.String);
            parameters.Add("@Concode", forex_transheader.Concode, DbType.String);
            parameters.Add("@Country", forex_transheader.Country, DbType.String);
            parameters.Add("@Pobox", forex_transheader.Pobox, DbType.String);
            parameters.Add("@Nationcode", forex_transheader.Nationcode, DbType.String);
            parameters.Add("@Nationality", forex_transheader.Nationality, DbType.String);
            parameters.Add("@Profession", forex_transheader.Profession, DbType.String);
            parameters.Add("@Mail", forex_transheader.Mail, DbType.String);
            parameters.Add("@Fax", forex_transheader.Fax, DbType.String);
            parameters.Add("@Remarks", forex_transheader.Remarks, DbType.String);
            parameters.Add("@Remark2", forex_transheader.Remark2, DbType.String);
            if (forex_transheader.Dob.ToString() != "")
                parameters.Add("@Dob", forex_transheader.Dob.ToString(), DbType.Date);
            else
                parameters.Add("@Dob", DBNull.Value, DbType.Date);
            parameters.Add("@IdNo", forex_transheader.IdNo, DbType.String);
            parameters.Add("@IdDescription", forex_transheader.IdDescription, DbType.String);
            parameters.Add("@IdCode", forex_transheader.IdCode, DbType.String);
            parameters.Add("@IdIssueplace", forex_transheader.IdIssueplace, DbType.String);
            parameters.Add("@IdIssueCountry", forex_transheader.IdIssueCountry, DbType.String);
            if (forex_transheader.IdIssueDate.ToString() != "")
                parameters.Add("@IdIssueDate", forex_transheader.IdIssueDate, DbType.Date);
            else
                parameters.Add("@IdIssueDate", DBNull.Value, DbType.Date);
            if (forex_transheader.IdExpDate.ToString() != "")
                parameters.Add("@IdExpDate", forex_transheader.IdExpDate, DbType.Date);
            else
                parameters.Add("@IdExpDate", DBNull.Value, DbType.Date);
            parameters.Add("@IdRemarks", forex_transheader.IdRemarks, DbType.String);
            parameters.Add("@CancelId", "0", DbType.String);
            //parameters.Add("@CancelUserID", forex_transheader.CancelUserID, DbType.String);
            //parameters.Add("@CancelDate", forex_transheader.CancelDate, DbType.DateTime);
            //parameters.Add("@CancelReason", forex_transheader.CancelReason, DbType.String);
            //parameters.Add("@CancelAuthUserID", forex_transheader.CancelAuthUserID, DbType.String);
            //parameters.Add("@CancelAuthDate", forex_transheader.CancelAuthDate, DbType.DateTime);
            parameters.Add("@Purpose", forex_transheader.Purpose, DbType.String);
            parameters.Add("@PurposeCode", forex_transheader.PurposeCode, DbType.String);
            parameters.Add("@PurposeRemarks", forex_transheader.PurposeRemarks, DbType.String);
            parameters.Add("@Source", forex_transheader.Source, DbType.String);
            parameters.Add("@SourCode", forex_transheader.SourCode, DbType.String);
            parameters.Add("@SourceRemarks", forex_transheader.SourceRemarks, DbType.String);
            parameters.Add("@JVDocno", forex_transheader.JVDocno, DbType.String);
            parameters.Add("@ServiceCharge", forex_transheader.ServiceCharge, DbType.Decimal);
            parameters.Add("@Tax", forex_transheader.Tax, DbType.Decimal);
            parameters.Add("@ISCBReported", forex_transheader.ISCBReported, DbType.String);
            parameters.Add("@ISxmlReported", forex_transheader.ISxmlReported, DbType.String);

            try
            {

                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;

            }


        }
        public async Task<int> SaveForexTransHeaderDTO(ForexTransHeaderDTO forex_transheader)
        {

            string sql = "spForex_TransHeader_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@Branchcode", forex_transheader.Branchcode, DbType.String);
            parameters.Add("@Custcode", forex_transheader.Custcode, DbType.String);
            parameters.Add("@UserId", forex_transheader.UserId, DbType.String);
            parameters.Add("@CashierCode", forex_transheader.CashierCode, DbType.String);
            parameters.Add("@Trandate", forex_transheader.Trandate, DbType.DateTime);
            parameters.Add("@CustType", forex_transheader.CustType, DbType.String);
            parameters.Add("@Name1", forex_transheader.Name1, DbType.String);
            parameters.Add("@Name2", forex_transheader.Name2, DbType.String);
            parameters.Add("@Name3", forex_transheader.Name3, DbType.String);
            parameters.Add("@Cell1", forex_transheader.Cell1, DbType.String);
            parameters.Add("@Cell2", forex_transheader.Cell2, DbType.String);
            parameters.Add("@Phone", forex_transheader.Phone, DbType.String);
            parameters.Add("@Gender", forex_transheader.Gender, DbType.String);
            parameters.Add("@Adrees1", forex_transheader.Adrees1, DbType.String);
            parameters.Add("@Adrees2", forex_transheader.Adrees2, DbType.String);
            parameters.Add("@Place", forex_transheader.Place, DbType.String);
            parameters.Add("@Street", forex_transheader.Street, DbType.String);
            parameters.Add("@City", forex_transheader.City, DbType.String);
            parameters.Add("@State", forex_transheader.State, DbType.String);
            parameters.Add("@Concode", forex_transheader.Concode, DbType.String);
            parameters.Add("@Country", forex_transheader.Country, DbType.String);
            parameters.Add("@Pobox", forex_transheader.Pobox, DbType.String);
            parameters.Add("@Nationcode", forex_transheader.Nationcode, DbType.String);
            parameters.Add("@Nationality", forex_transheader.Nationality, DbType.String);
            parameters.Add("@Profession", forex_transheader.Profession, DbType.String);
            parameters.Add("@Mail", forex_transheader.Mail, DbType.String);
            parameters.Add("@Fax", forex_transheader.Fax, DbType.String);
            parameters.Add("@Remarks", forex_transheader.Remarks, DbType.String);
            parameters.Add("@Remark2", forex_transheader.Remark2, DbType.String);
            if (forex_transheader.Dob.ToString() != "")
                parameters.Add("@Dob", forex_transheader.Dob.ToString(), DbType.Date);
            else
                parameters.Add("@Dob", DBNull.Value, DbType.Date);
            parameters.Add("@IdNo", forex_transheader.IdNo, DbType.String);
            parameters.Add("@IdDescription", forex_transheader.IdDescription, DbType.String);
            parameters.Add("@IdCode", forex_transheader.IdCode, DbType.String);
            parameters.Add("@IdIssueplace", forex_transheader.IdIssueplace, DbType.String);
            parameters.Add("@IdIssueCountry", forex_transheader.IdIssueCountry, DbType.String);
            if (forex_transheader.IdIssueDate.ToString() != "")
                parameters.Add("@IdIssueDate", forex_transheader.IdIssueDate, DbType.Date);
            else
                parameters.Add("@IdIssueDate", DBNull.Value, DbType.Date);
            if (forex_transheader.IdExpDate.ToString() != "")
                parameters.Add("@IdExpDate", forex_transheader.IdExpDate, DbType.Date);
            else
                parameters.Add("@IdExpDate", DBNull.Value, DbType.Date);
            parameters.Add("@IdRemarks", forex_transheader.IdRemarks, DbType.String);
            parameters.Add("@CancelId", "0", DbType.String);

            parameters.Add("@Purpose", forex_transheader.Purpose, DbType.String);
            parameters.Add("@PurposeCode", forex_transheader.PurposeCode, DbType.String);
            parameters.Add("@PurposeRemarks", forex_transheader.PurposeRemarks, DbType.String);
            parameters.Add("@Source", forex_transheader.Source, DbType.String);
            parameters.Add("@SourCode", forex_transheader.SourCode, DbType.String);
            parameters.Add("@SourceRemarks", forex_transheader.SourceRemarks, DbType.String);
            parameters.Add("@JVDocno", forex_transheader.JVDocno, DbType.String);
            parameters.Add("@ServiceCharge", forex_transheader.ServiceCharge, DbType.Decimal);
            parameters.Add("@Tax", forex_transheader.Tax, DbType.Decimal);
            parameters.Add("@ISCBReported", forex_transheader.ISCBReported, DbType.String);
            parameters.Add("@ISxmlReported", forex_transheader.ISxmlReported, DbType.String);

            try
            {

                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, commandTimeout: 180, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;

            }


        }
        public async Task<int> SaveForexTranDetails(ForexTranDetails forex_trandetails)
        {
            string sql = @" INSERT INTO Forex_TranDetails(OrgCode,Refno, Branchcode, SerNo, Trandate, UserId, CashierCode, TranType, CurCode, 
                       FxAmnt, Rate, EquvAmnt, Profit, AvgRate, CostRate) VALUES (@OrgCode,@Refno, @Branchcode, @SerNo, @Trandate, @UserId, @CashierCode, 
                       @TranType, @CurCode, @FxAmnt, @Rate, @EquvAmnt, @Profit, @AvgRate, @CostRate)";
            var parameters = new DynamicParameters();
            parameters.Add("OrgCode", forex_trandetails.OrgCode, DbType.String);
            parameters.Add("Refno", forex_trandetails.Refno, DbType.String);
            parameters.Add("Branchcode", forex_trandetails.Branchcode, DbType.String);
            parameters.Add("SerNo", forex_trandetails.SerNo, DbType.String);
            parameters.Add("Trandate", forex_trandetails.Trandate, DbType.DateTime);
            parameters.Add("UserId", forex_trandetails.UserId, DbType.String);
            parameters.Add("CashierCode", forex_trandetails.CashierCode, DbType.String);
            parameters.Add("TranType", forex_trandetails.TranType, DbType.String);
            parameters.Add("CurCode", forex_trandetails.CurCode, DbType.String);
            parameters.Add("FxAmnt", forex_trandetails.FxAmnt, DbType.Decimal);
            parameters.Add("Rate", forex_trandetails.Rate, DbType.String);
            parameters.Add("EquvAmnt", forex_trandetails.EquvAmnt, DbType.Decimal);
            parameters.Add("Profit", forex_trandetails.Profit, DbType.Decimal);
            parameters.Add("AvgRate", forex_trandetails.AvgRate, DbType.Decimal);
            parameters.Add("CostRate", forex_trandetails.CostRate, DbType.Decimal);

            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;

            }

        }       
        public async Task<int> SaveForexTranDetailsDTO(ForexTranDetailsDTO forex_trandetails)
        {

            string sql = "spForex_TranDetails_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("OrgCode", forex_trandetails.OrgCode, DbType.String);
            parameters.Add("Refno", forex_trandetails.Refno, DbType.String);
            parameters.Add("Branchcode", forex_trandetails.Branchcode, DbType.String);
            parameters.Add("SerNo", forex_trandetails.SerNo, DbType.String);
            parameters.Add("Trandate", forex_trandetails.Trandate, DbType.DateTime);
            parameters.Add("UserId", forex_trandetails.UserId, DbType.String);
            parameters.Add("CashierCode", forex_trandetails.CashierCode, DbType.String);
            parameters.Add("TranType", forex_trandetails.TranType, DbType.String);
            parameters.Add("CurCode", forex_trandetails.CurCode, DbType.String);
            parameters.Add("FxAmnt", forex_trandetails.FxAmnt, DbType.Decimal);
            parameters.Add("Rate", forex_trandetails.Rate, DbType.String);
            parameters.Add("EquvAmnt", forex_trandetails.EquvAmnt, DbType.Decimal);
            parameters.Add("Profit", forex_trandetails.Profit, DbType.Decimal);
            parameters.Add("AvgRate", forex_trandetails.AvgRate, DbType.Decimal);
            parameters.Add("CostRate", forex_trandetails.CostRate, DbType.Decimal);

            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, commandTimeout: 180, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;

            }

        }
        public async Task<int> UpdateForexTranDetails(ForexTranDetails forex_trandetails)
        {
            //string sql = @" UPDATE  Forex_TranDetails SET Profit=@Profit ,CostRate= @CostRate ,AvgRate=@AvgRate WHERE Refno=@Refno AND SerNo=@SerNo and CurCode=@CurCode   ";
            string sql = "spForex_TranDetails_UpdateProfit";
            var parameters = new DynamicParameters();
            parameters.Add("Refno", forex_trandetails.Refno, DbType.String);
            parameters.Add("SerNo", forex_trandetails.SerNo.PadLeft(5, '0'), DbType.String);
            parameters.Add("CurCode", forex_trandetails.CurCode, DbType.String);
            parameters.Add("Profit", forex_trandetails.Profit, DbType.Decimal);
            parameters.Add("AvgRate", forex_trandetails.AvgRate, DbType.Decimal);
            parameters.Add("CostRate", forex_trandetails.CostRate, DbType.Decimal);

            int rval = 0;

            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, commandTimeout: 180, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;

            }

        }
        public async Task<int> UpdateForexTransHeader(ForexTransHeader forex_transheader)
        {
            string sql = @" UPDATE  Forex_TransHeader SET JVDocno=@JVDocno  WHERE OrgCode=@OrgCode and Refno=@Refno";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("JVDocno", forex_transheader.JVDocno, DbType.String);


            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;

            }

        }
        public async Task<int> CancelForexTransHeader(ForexTransHeader forex_transheader)
        {
            string sql = @"SP_Forex_Cancel";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@CancelId", forex_transheader.CancelId, DbType.String);
            parameters.Add("@UserID", forex_transheader.CancelUserID, DbType.String);
            parameters.Add("@TranDate", forex_transheader.CancelDate, DbType.DateTime);
            parameters.Add("@CancelReason", "Cancel Refund", DbType.String);
            parameters.Add("@Type", "CancelRefund", DbType.String);



            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;

            }

        }
        public async Task<int> CancelForexTransHeaderDTO(ForexTransHeaderDTO forex_transheader)
        {
            string sql = @"SP_Forex_Cancel";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", forex_transheader.OrgCode, DbType.String);
            parameters.Add("@Refno", forex_transheader.Refno, DbType.String);
            parameters.Add("@CancelId", forex_transheader.CancelId, DbType.String);
            parameters.Add("@UserID", forex_transheader.CancelUserID, DbType.String);
            parameters.Add("@TranDate", forex_transheader.CancelDate, DbType.DateTime);
            parameters.Add("@CancelReason", "Cancel Refund", DbType.String);
            parameters.Add("@Type", "CancelRefund", DbType.String);



            try
            {
                return await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<OrgnizationBranch> GetOrgnizationBranchByID(string BranchCode, string OrgCode)
        {
            string sql = @"SELECT BranchCode, OrgCode, BranchName, Address, Street, City, State, PoBox, Country, Phone, Mobile, Email, WindowsFlag, Refno, RefDate, JvMonth, JVYear, JVDocNo, Fxno,
                     FxDate, InterBranchAccno, WholeSaleAccount FROM OrgnizationBranch WHERE BranchCode= @BranchCode  and OrgCode=@OrgCode ";

            try
            {
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@BranchCode", BranchCode, DbType.String);
                parameter.Add("@OrgCode", OrgCode, DbType.String);
                var Data = await unitOfWork.Connection.QueryFirstOrDefaultAsync<OrgnizationBranch>(sql, parameter);

                return Data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> GetForexRefno(string BranchCode)
        {
            OrgnizationBranch Data = new OrgnizationBranch();
            string Refno = "";
            string endDate = SD.GeCurrentDate();
            string sql = @" SELECT BranchCode, OrgCode, BranchName, Address, Street, City, State, PoBox, Country, Phone, Mobile, Email, WindowsFlag, Refno, RefDate, JvMonth, JVYear, JVDocNo, Fxno,
                     FxDate, InterBranchAccno, WholeSaleAccount  FROM OrgnizationBranch WHERE OrgCode=@OrgCode AND BranchCode= @BranchCode and CAST(FxDate AS Date) =@FxDate ";



            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrgCode", "00001", DbType.String);
            parameter.Add("@BranchCode", BranchCode, DbType.String);
            parameter.Add("@FxDate", SD.GeCurrentDate(), DbType.String);
            try
            {
                Data = await unitOfWork.Connection.QueryFirstOrDefaultAsync<OrgnizationBranch>(sql, parameter, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {

                throw;

            }
            int rval = 0;
            var dateString = DateTime.Now.ToString("yyyyMMdd");
            int? fxRfno = 0;
            if (Data != null)
            {
                sql = @"  UPDATE OrgnizationBranch SET Fxno = Fxno+1 ,FxDate = CONVERT(VARCHAR(10), GETDATE(), 101)  WHERE OrgCode='00001' AND BranchCode = @BranchCode  ";

                fxRfno = Data.Fxno + 1;


            }
            else
            {
                sql = @"  UPDATE OrgnizationBranch SET Fxno = 1 , FxDate = CONVERT(VARCHAR(10), GETDATE(), 101) WHERE OrgCode='00001' AND BranchCode = @BranchCode  ";
                fxRfno = 1;

            }
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@BranchCode", BranchCode, DbType.String);
                rval = await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
            }
            catch (Exception)
            {
                throw;

            }
            Refno = "FX" + BranchCode.PadLeft(5, '0') + dateString.PadLeft(8, '0') + fxRfno.ToString().PadLeft(5, '0');
            return Refno;
        }
        public async Task<CashierMst> GetCashierByUserName(string UserID)
        {
            string sql = @" SELECT CashierCode, OrgCode, BranchCode, CashierName, UserId, CREATEDATE, ActiveFlg, STKEQVFLG, STKFXFLG, FUNCTIONFLG, CASHIERACNTCODE, IDENTITYFLG, MAINCASHIER, EXESSACC FROM CashierMst WHERE CashierCode= @CashierCode";


            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CashierName", UserID, DbType.String);
            var Cashier = await unitOfWork.Connection.QueryFirstOrDefaultAsync<CashierMst>(sql, parameter);

            return Cashier;
        }
        public async Task<int> AuthPaymentVoucher(string Refno, string UserId)
        {
            string sql = @" UPDATE PaymentVoucher SET  AuthFalag = 'Y', AuthUserID = @AuthUserID WHERE Refno = @Refno and  AuthFalag = 'N'";
            var parameters = new DynamicParameters();

            parameters.Add("@Refno", Refno, DbType.String);
            parameters.Add("@AuthUserID", UserId, DbType.String);

            var rval = await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);

            return rval;
        }
        public async Task<int> AuthReceiptsVoucher(string Refno, string UserId)
        {
            string sql = @" UPDATE ReceiptsVoucher SET  AuthFalag = 'Y', AuthUserID = @AuthUserID WHERE Refno = @Refno and  AuthFalag = 'N'";
            var parameters = new DynamicParameters();

            parameters.Add("@Refno", Refno, DbType.String);
            parameters.Add("@AuthUserID", UserId, DbType.String);

            var rval = await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);

            return rval;
        }
        public async Task<IEnumerable<OrgnizationBranch>> GetOrgnizationBranch(string OrgCode, string branchCode)
        {
            string sql = @"SELECT BranchCode, OrgCode, BranchName, Address, Street, City, State, PoBox, Country, Phone, Mobile, Email, WindowsFlag, Refno, RefDate, JvMonth, JVYear, JVDocNo, Fxno,
                     FxDate, InterBranchAccno, WholeSaleAccount,ActiveFlag,AgentCode FROM OrgnizationBranch where OrgCode=@Orgcode";

            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(branchCode))
            {
                sql += @" and BranchCode=@BranchCode";
                parameter.Add("@BranchCode ", branchCode, DbType.String);
            }
            parameter.Add("@Orgcode", OrgCode, DbType.String);
            var DataList = await unitOfWork.Connection.QueryAsync<OrgnizationBranch>(sql, parameter, unitOfWork.Transaction, 180);





            return DataList.ToList();
        }



        //public async Task<int> SaveRemittancePay(RemittancePayment remitpay)
        //{
        //    // need to pass DTO List add loop here 


        //    var parameters = new DynamicParameters();
        //    parameters.Add("@PortalCode", "00001", DbType.String);
        //    parameters.Add("@OrgCode", "00001", DbType.String);
        //    parameters.Add("@MenuCode", "00000", DbType.String);
        //    parameters.Add("@RefNo", remitpay.RefNo, DbType.String);
        //    parameters.Add("@TranDate", remitpay.TranDate, DbType.DateTime);
        //    parameters.Add("@PayRefNo", remitpay.PayRefNo, DbType.String);
        //    parameters.Add("@UserCode", remitpay.UserCode, DbType.String);
        //    parameters.Add("@PayCode", remitpay.PayCode, DbType.String);
        //    parameters.Add("@AccountCode", remitpay.AccountCode, DbType.String);
        //    parameters.Add("@PayAmount", remitpay.PayAmount, DbType.Decimal);
        //    parameters.Add("@Rate", remitpay.Rate, DbType.Decimal);
        //    parameters.Add("@PaidAmount", remitpay.PaidAmount, DbType.Decimal);
        //    parameters.Add("@BalAmount", remitpay.BalAmount, DbType.Decimal);
        //    parameters.Add("@Discount", remitpay.Discount, DbType.Decimal);
        //    parameters.Add("@Pay_ID", remitpay.Pay_ID, DbType.Int32);
        //    parameters.Add("@PayCodeName", remitpay.PayCodeName, DbType.String);
        //    parameters.Add("@BankCode", remitpay.BankCode, DbType.String);
        //    parameters.Add("@BankName", remitpay.BankName, DbType.String);
        //    parameters.Add("@CardCharge", remitpay.CardCharge, DbType.Decimal);
        //    parameters.Add("@CheqDt", remitpay.CheqDt, DbType.DateTime);
        //    parameters.Add("@TotalDeno", remitpay.TotalDeno, DbType.Decimal);
        //    parameters.Add("@TotalDenoAmt", remitpay.TotalDenoAmt, DbType.Decimal);
        //    parameters.Add("@BalanceCashPay", remitpay.BalanceCashPay, DbType.Decimal);
        //    parameters.Add("@PayCurCode", remitpay.PayCurCode, DbType.String);
        //    parameters.Add("@PayCurName", remitpay.PayCurName, DbType.String);
        //    parameters.Add("@USDAmount", remitpay.USDAmount, DbType.Decimal);
        //    parameters.Add("@USDBalAmount", remitpay.USDBalAmount, DbType.Decimal);
        //    parameters.Add("@IsDenoRqd", remitpay.IsDenoRqd, DbType.Boolean);
        //    parameters.Add("@IsUSDRqd", remitpay.IsUSDRqd, DbType.Boolean);
        //    parameters.Add("@USDRate", remitpay.USDRate, DbType.Decimal);


        //    try
        //    {
        //        string sql = @"USP_VN_TRN_INSERT_PAYMODE";

        //        var rval = await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);

        //        return rval;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<int> SaveIncomingPay(IncomingPay remitpay)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@PortalCode", "00001", DbType.String);
            parameters.Add("@OrgCode", "00001", DbType.String);
            parameters.Add("@MenuCode", "00000", DbType.String);
            parameters.Add("@PayRefNo", remitpay.PayRefNo, DbType.String);
            parameters.Add("@ClientRefNo", remitpay.ClientRefNo, DbType.String);
            parameters.Add("@TranDate", remitpay.TranDate, DbType.DateTime);
            parameters.Add("@UserCode", remitpay.UserCode, DbType.String);
            parameters.Add("@AccountCode", remitpay.AccountCode, DbType.String);
            parameters.Add("@PayAmount", remitpay.PayAmount, DbType.Decimal);
            parameters.Add("@Rate", remitpay.Rate, DbType.Decimal);
            parameters.Add("@Discount", remitpay.Discount, DbType.Decimal);
            parameters.Add("@Pay_ID", remitpay.Pay_ID, DbType.Int32);
            parameters.Add("@PayCodeName", remitpay.PayCodeName, DbType.String);
            parameters.Add("@BankCode", remitpay.BankCode, DbType.String);
            parameters.Add("@BankName", remitpay.BankName, DbType.String);
            parameters.Add("@CardCharge", remitpay.CardCharge, DbType.Decimal);
            parameters.Add("@CheqDt", remitpay.CheqDt, DbType.DateTime);
            parameters.Add("@RefNo", remitpay.RefNo, DbType.String);
            parameters.Add("@CLCYAmount", remitpay.CLCYAmount, DbType.Decimal);
            parameters.Add("@LCYAmount", remitpay.LCYAmount, DbType.Decimal);
            parameters.Add("@PayCode", remitpay.PayCode, DbType.String);
            parameters.Add("@PaidAmount", remitpay.PaidAmount, DbType.Decimal);
            parameters.Add("@BalAmount", remitpay.BalAmount, DbType.Decimal);
            parameters.Add("@TotalDeno", remitpay.TotalDeno, DbType.Decimal);
            parameters.Add("@TotalDenoAmt", remitpay.TotalDenoAmt, DbType.Decimal);
            parameters.Add("@BalanceCashPay", remitpay.BalanceCashPay, DbType.Decimal);
            parameters.Add("@PayCurCode", remitpay.PayCurCode, DbType.String);
            parameters.Add("@PayCurName", remitpay.PayCurName, DbType.String);
            parameters.Add("@USDAmount", remitpay.USDAmount, DbType.Decimal);
            parameters.Add("@USDBalAmount", remitpay.USDBalAmount, DbType.Decimal);
            parameters.Add("@IsDenoRqd", remitpay.IsDenoRqd, DbType.Boolean);
            parameters.Add("@IsUSDRqd", remitpay.IsUSDRqd, DbType.Boolean);
            parameters.Add("@USDRate", remitpay.USDRate, DbType.Decimal);
            try
            {
                string sql = "USP_VN_TRN_INSERT_INCOMINGPAY";

                var rval = await unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
                //var rval =  await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<int>(sql, parameters);

                return rval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
