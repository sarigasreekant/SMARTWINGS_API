using DataAccess;
using ForexDataService;
using ForexModel;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMARTWINGS_API.DataServices;
using SMARTWINGS_API.Model.Forex;



namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ForexHederDataServiceController : ControllerBase
    {
        private readonly IForexHederDataService _forexHederDataService;//
        private IApplicationErorrLogService _applicationErorrLogService;
        private readonly ILogger<ForexHederDataServiceController> _logger;
        public ForexHederDataServiceController(IForexHederDataService forexHederDataService, IApplicationErorrLogService applicationErorrLogService, ILogger<ForexHederDataServiceController> logger)
        {
            this._forexHederDataService = forexHederDataService;          
            _applicationErorrLogService = applicationErorrLogService;
            _logger = logger;
        }
        [HttpGet("GetForexTranDetails/{Refno}")]
        public async Task<ActionResult<IEnumerable<ForexTranDetails>>> GetForexTranDetails([FromRoute] string Refno)
        {

            try
            {
                var result = await _forexHederDataService.GetForexTranDetails(Refno);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
               
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        [HttpGet("GetForexTranDetailsSearch/{Refno}")]
        public async Task<ActionResult<IEnumerable<ForexTranDetails>>> GetForexTranDetailsSearch([FromRoute] string Refno)
        {

            try
            {
                var result = await _forexHederDataService.GetForexTranDetailsSearch(Refno);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        //[HttpPost("SaveForex")]
        //public async Task<ActionResult<FxResponse>> SaveForex(FxDto fxDto)
        //{
        //    var applicationErorrLog = new ApplicationErorrLog();
        //    applicationErorrLog.ActionName = "SaveForex";
        //    applicationErorrLog.ModuleName = "Forex";
        //    applicationErorrLog.ConttroleName = "ForexHederDataServiceController";
        //    FxResponse objFxResponse = new FxResponse();
        //    objFxResponse.IsSucess = true;
        //    objFxResponse.StatusCode = 200;
        //    objFxResponse.StatusMesage = "Data saved Sucessfully";
        //    objFxResponse.RefNo = "";
        //    string fxRefno = "";
        //    using (DalSession dalSession = new DalSession())
        //    {
        //        List<ForexTranDetailsDTO> ObservableData = fxDto.forexTranDetailsDTO;
        //        ForexTransHeaderDTO addedForexTransHeader = fxDto.forexTransHeaderDTO;
        //        string BranchCode = "" + addedForexTransHeader.Branchcode;

        //        string? CashierCode = "" + addedForexTransHeader.CashierCode;


        //        string? UserId = "" + addedForexTransHeader.UserId;


        //        decimal ServiceCharge = addedForexTransHeader.ServiceCharge;

        //        string? CustomerCode = addedForexTransHeader.Custcode;

        //        var addedForexTranDetails = new ForexTranDetailsDTO();

        //        decimal TotalGross = addedForexTransHeader.TotalGross;
        //        UnitOfWork unitOfWork = dalSession.UnitOfWork;
        //        try
        //        {
        //            unitOfWork.BeginTransaction();

        //            ForexTransactionDataService forexTransactionDataService = new ForexTransactionDataService(dalSession.UnitOfWork);
        //            JournalDataService journalDataService = new JournalDataService(dalSession.UnitOfWork);

        //            fxRefno = await forexTransactionDataService.GetForexRefno(BranchCode);



        //            journalDataService.BranchCode = BranchCode;
        //            journalDataService.CashierCode = CashierCode;
        //            journalDataService.UserId = UserId;
        //            journalDataService.Trandate = Convert.ToDateTime(SD.ServerDateTime());
        //            addedForexTransHeader.OrgCode = SD.OrgCode;
        //            addedForexTransHeader.Branchcode = BranchCode;
        //            addedForexTransHeader.Refno = "" + fxRefno;
        //            addedForexTransHeader.UserId = UserId;
        //            addedForexTransHeader.CashierCode = CashierCode;
        //            addedForexTransHeader.ServiceCharge = ServiceCharge;
        //            addedForexTransHeader.Trandate = Convert.ToDateTime(SD.ServerDateTime());
        //            CustomerCode = addedForexTransHeader.Custcode;
        //            if (string.IsNullOrEmpty(CustomerCode))
        //            {
        //                CustomerCode = "0000000000";
        //                addedForexTransHeader.Custcode = CustomerCode;
        //            }
        //            await forexTransactionDataService.SaveForexTransHeaderDTO(addedForexTransHeader);

        //            int saveForex = 0;
        //            int serval = 0;
        //            foreach (var item in ObservableData)
        //            {
        //                serval = serval + 1;
        //                saveForex = 0;
        //                addedForexTranDetails.OrgCode = SD.OrgCode;
        //                addedForexTranDetails.Branchcode = BranchCode;
        //                addedForexTranDetails.UserId = UserId;
        //                addedForexTranDetails.CashierCode = CashierCode;
        //                addedForexTranDetails.Refno = "" + fxRefno;
        //                addedForexTranDetails.UserId = "" + UserId;
        //                addedForexTranDetails.TranType = item.TranType;
        //                addedForexTranDetails.SerNo = "" + item.SerNo.ToString().PadLeft(5, '0');
        //                addedForexTranDetails.CurCode = item.CurCode;
        //                addedForexTranDetails.FxAmnt = item.FxAmnt;
        //                addedForexTranDetails.Rate = item.Rate;
        //                addedForexTranDetails.EquvAmnt = item.EquvAmnt;
        //                addedForexTranDetails.Profit = item.Profit;
        //                addedForexTranDetails.AvgRate = item.AvgRate;
        //                addedForexTranDetails.CostRate = item.CostRate;
        //                addedForexTranDetails.Slno = +item.Slno;
        //                addedForexTranDetails.MinMax = item.MinMax;
        //                addedForexTranDetails.Trandate = Convert.ToDateTime(SD.ServerDateTime());
        //                saveForex = await forexTransactionDataService.SaveForexTranDetailsDTO(addedForexTranDetails);
        //                if (saveForex < 1)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Header Details Saving  Error ";
        //                    applicationErorrLog.Errordate = System.DateTime.Now;
        //                    applicationErorrLog.EorrDetails = "Header Details Saving  Error";
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);
        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 100;
        //                    objFxResponse.StatusMesage = "Data Not Saved ";
        //                    return Ok(objFxResponse);

        //                }
        //            }
        //            decimal dTotBuy = 0; decimal dTotSell = 0; decimal dBuy_Sell = 0;
        //            int serveno = 0;
        //            Decimal ExchangeVari = 0;
        //            bool isJvSave = false;
        //            ForexTranDetails UpdaeForexTranDetails = new ForexTranDetails();
        //            decimal Profite = 0;
        //            decimal AvgRate = 0;
        //            foreach (var JVitem in ObservableData)
        //            {
        //                Profite = 0;
        //                serveno++;
        //                if (JVitem.CurCode == null || string.IsNullOrEmpty(JVitem.CurCode))
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Transaction currency not found.Please make re-entry";
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = "Transaction currency not found.Please make re-entry";
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 101;
        //                    objFxResponse.StatusMesage = "Transaction currency not found.Please make re-entry ";
        //                    return Ok(objFxResponse);
        //                }
        //                var currencyAccounts = await journalDataService.GetCurrencyAccount(JVitem.CurCode);
        //                if (currencyAccounts == null)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Currency accounts not Found";
        //                    applicationErorrLog.Errordate = System.DateTime.Now;
        //                    applicationErorrLog.EorrDetails = "Currency accounts not Found";
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 103;
        //                    objFxResponse.StatusMesage = "Currency accounts not Found ";
        //                    return Ok(objFxResponse);
        //                }
        //                if (string.IsNullOrEmpty(currencyAccounts.LedgerAccode))
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Currency ledger not found";
        //                    applicationErorrLog.Errordate = System.DateTime.Now;
        //                    applicationErorrLog.EorrDetails = "Currency ledger not found";
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);
        //                     objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 104;
        //                    objFxResponse.StatusMesage = "Currency ledger not found ";
        //                    return Ok(objFxResponse);

        //                }
        //                if (JVitem.TranType == "BUY")
        //                {
        //                    Profite = 0;
        //                    AvgRate = await journalDataService.FetchAvgRateCashier(currencyAccounts.CurCode, journalDataService.CashierCode, journalDataService.BranchCode);
        //                    string forexNarration = $"Fx Buy  {currencyAccounts.CurCode}  Amount : {JVitem.FxAmnt}  Buy Rate : {JVitem.Rate} Cost Rate: {JVitem.CostRate} AvgRate: {AvgRate} ";
        //                    isJvSave = await journalDataService.CreateJVEntry(currencyAccounts.LedgerAccode, "D", JVitem.FxAmnt, JVitem.EquvAmnt, JVitem.Rate, fxRefno, forexNarration, CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                    dTotBuy += JVitem.EquvAmnt;

        //                    if (isJvSave == false)
        //                    {

        //                        unitOfWork.RollbackTransaction();
        //                        applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                        applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                        applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                        await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                        objFxResponse.IsSucess = false;
        //                        objFxResponse.StatusCode = 106;
        //                        objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                        return Ok(objFxResponse);
        //                    }
        //                }

        //                if (JVitem.TranType == "SELL")
        //                {

        //                    decimal sAbsAmt = 0;
        //                    string sAcType = "C";

        //                    AvgRate = await journalDataService.FetchAvgRateCashier(currencyAccounts.CurCode, journalDataService.CashierCode, journalDataService.BranchCode);
        //                    decimal dCurrVal = JVitem.FxAmnt * AvgRate;
        //                    dCurrVal = System.Math.Round(dCurrVal, 2);
        //                    decimal dTotExVar = JVitem.EquvAmnt - dCurrVal;
        //                    string forexNarration = $"Fx Sell  {currencyAccounts.CurCode}  Amount : {JVitem.FxAmnt}   Sell Rate: {JVitem.Rate}   Cost Rate: {JVitem.CostRate} AvgRate: {AvgRate}";

        //                    Profite = dTotExVar;
        //                    if (dCurrVal > 0)
        //                    {
        //                        sAbsAmt = dCurrVal;
        //                        sAcType = "C";
        //                    }
        //                    else
        //                    {
        //                        sAbsAmt = System.Math.Abs(dCurrVal);
        //                        sAcType = "D";
        //                    }

        //                    isJvSave = await journalDataService.CreateJVEntry(currencyAccounts.LedgerAccode, "C", JVitem.FxAmnt, sAbsAmt, JVitem.Rate, fxRefno, forexNarration, CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                    if (isJvSave == false)
        //                    {

        //                        unitOfWork.RollbackTransaction();
        //                        applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                        applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                        applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                        await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                        objFxResponse.IsSucess = false;
        //                        objFxResponse.StatusCode = 107;
        //                        objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                        return Ok(objFxResponse);


        //                    }

        //                    if (dTotExVar > 0)
        //                    {
        //                        ExchangeVari = dTotExVar;
        //                        sAcType = "C";
        //                    }
        //                    else
        //                    {
        //                        ExchangeVari = System.Math.Abs(dTotExVar);
        //                        sAcType = "D";
        //                    }
        //                    if (ExchangeVari > 0)
        //                    {
        //                        if (sAcType == "C")
        //                            forexNarration = $"Fx Sell  Vari-Profit  {currencyAccounts.CurCode} Amount : {JVitem.FxAmnt}   Sell Rate: {JVitem.Rate}   Cost Rate: {JVitem.CostRate}  AvgRate: {AvgRate} ";
        //                        else
        //                            forexNarration = $"Fx Sell  Vari-Loss {currencyAccounts.CurCode}  Amount : {JVitem.FxAmnt}   Sell Rate: {JVitem.Rate}   Cost Rate: {JVitem.CostRate}  AvgRate: {AvgRate} ";

        //                        isJvSave = await journalDataService.CreateJVEntry(currencyAccounts.ExchangeVariAccode, sAcType, 0, ExchangeVari, 0, fxRefno, forexNarration, CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                        if (isJvSave == false)
        //                        {

        //                            unitOfWork.RollbackTransaction();
        //                            applicationErorrLog.ErrorMesage = "Create JV  Profit & loss acccode " + currencyAccounts.ExchangeVariAccode;
        //                            applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                            applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                            await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                            objFxResponse.IsSucess = false;
        //                            objFxResponse.StatusCode = 121;
        //                            objFxResponse.StatusMesage = " Sell Profit JV Entry Error" + journalDataService.ErorrMessage;
        //                            return Ok(objFxResponse);
        //                        }

        //                    }
        //                    dTotSell += JVitem.EquvAmnt;


        //                }
        //                UpdaeForexTranDetails.Refno = fxRefno;
        //                UpdaeForexTranDetails.CurCode = JVitem.CurCode;
        //                UpdaeForexTranDetails.SerNo = "" + JVitem.SerNo.ToString().PadLeft(5, '0');
        //                UpdaeForexTranDetails.CostRate = JVitem.CostRate;
        //                UpdaeForexTranDetails.AvgRate = AvgRate;
        //                UpdaeForexTranDetails.Profit = Profite;
        //                int SaveVal = await forexTransactionDataService.UpdateForexTranDetails(UpdaeForexTranDetails);
        //                if (SaveVal < 1)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Update ForexTran Details Error ";
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = "Update Forex Tran Details Error ";
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 120;
        //                    objFxResponse.StatusMesage = "Update Forex Tran Details Error ";
        //                    return Ok(objFxResponse);

        //                }

        //            }

        //            dBuy_Sell = dTotBuy - dTotSell;
        //            string sTranType = "D";
        //            string Narration = "";
        //            if (dTotBuy - dTotSell > 0)
        //            {
        //                sTranType = "C";
        //                Narration = $"Forex Buy & Sell Paying Local Currency to customer ";

        //            }
        //            else
        //            {
        //                sTranType = "D";
        //                Narration = $"Forex buy & sell receving Local currency from customer ";
        //            }
        //            if (ServiceCharge > 0)
        //            {
        //                string ServiceChargeAc = SDAccount.ForexServiceChrgAccode.Trim();
        //                isJvSave = await journalDataService.CreateJVEntry(ServiceChargeAc, "C", 0, ServiceCharge, 0, fxRefno, "Service Charge  buy and sell", CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                if (isJvSave == false)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Create JV Entry Error 102" + journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = System.DateTime.Now;
        //                    applicationErorrLog.EorrDetails = "Create JV Entry Error 102" + journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 119;
        //                    objFxResponse.StatusMesage = " service Charge JV Error " + journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);

        //                }
        //            }
        //            if (TotalGross > 0)
        //            {
        //                var currencyLedger = await journalDataService.GetCurrencyAccount(SD.LocalCurCode);
        //                isJvSave = await journalDataService.CreateJVEntry(currencyLedger.LedgerAccode, sTranType, 0, TotalGross, 0, fxRefno, Narration, CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                if (isJvSave == false)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = "Create JV Entry Error 103" + journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = System.DateTime.Now;
        //                    applicationErorrLog.EorrDetails = "Create JV Entry Error 103" + journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 118;
        //                    objFxResponse.StatusMesage = " Create JV Entry Error 103 " + journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);

        //                }
        //            }
        //            decimal RoundValue = 0;
        //            if (sTranType == "D")
        //            {
        //                RoundValue = Math.Abs(dBuy_Sell) + ServiceCharge;
        //            }
        //            else if (sTranType == "C")
        //            {
        //                RoundValue = Math.Abs(dBuy_Sell) - ServiceCharge;
        //            }

        //            if (Math.Abs(RoundValue) != TotalGross)
        //            {
        //                string sTyp = journalDataService.TotalCredit > journalDataService.TotalDebit ? "D" : "C";
        //                decimal dRoundOff = Math.Abs(RoundValue) - TotalGross;
        //                string RoundOffAccount = SDAccount.RoundOffAccode.Trim();//RoundOff
        //                if (Math.Abs(dRoundOff) > 0)
        //                {
        //                    isJvSave = await journalDataService.CreateJVEntry(RoundOffAccount, sTyp, 0, Math.Abs(dRoundOff), 0, fxRefno, "Rounding FX", CustomerCode, ((int)CJVModuleName.JVModuleName.FX));
        //                    if (isJvSave == false)
        //                    {

        //                        unitOfWork.RollbackTransaction();
        //                        applicationErorrLog.ErrorMesage = "Round Create JV Entry Error 104" + journalDataService.ErorrMessage;
        //                        applicationErorrLog.Errordate = System.DateTime.Now;
        //                        applicationErorrLog.EorrDetails = "Round Create JV Entry Error 104" + journalDataService.ErorrMessage;
        //                        await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                        objFxResponse.IsSucess = false;
        //                        objFxResponse.StatusCode = 117;
        //                        objFxResponse.StatusMesage = " Rounding Amount JV Error 104 " + journalDataService.ErorrMessage;
        //                        return Ok(objFxResponse);
        //                    }
        //                }
        //            }
        //            if (journalDataService.TotalCredit != journalDataService.TotalDebit)
        //            {

        //                unitOfWork.RollbackTransaction();
        //                applicationErorrLog.ErrorMesage = "journal DataService Total Debit";
        //                applicationErorrLog.Errordate = System.DateTime.Now;
        //                applicationErorrLog.EorrDetails = "journal DataService Total Debit";
        //                await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //                objFxResponse.IsSucess = false;
        //                objFxResponse.StatusCode = 116;
        //                objFxResponse.StatusMesage = "Total Debit and Credit Not Talling " + journalDataService.TotalCredit + " Dr " + journalDataService.TotalDebit;
        //                return Ok(objFxResponse);

        //            }
        //            unitOfWork.CommitTransaction();
        //            objFxResponse.RefNo = fxRefno;
        //            objFxResponse.IsSucess = true;
        //            objFxResponse.StatusCode = 200;
        //            objFxResponse.StatusMesage = "Data saved Sucessfully";

        //            return Ok(objFxResponse);

        //        }
        //        catch (Exception ex)
        //        {
        //            unitOfWork.RollbackTransaction();
        //            _logger.LogError(ex.ToString());
        //             applicationErorrLog.ErrorMesage = ex.Message;
        //            applicationErorrLog.Errordate = System.DateTime.Now;
        //            applicationErorrLog.EorrDetails = ex.ToString();
        //            await _applicationErorrLogService.SaveLog(applicationErorrLog);
        //            objFxResponse.IsSucess = false;
        //            objFxResponse.StatusCode = 112;
        //            objFxResponse.StatusMesage = " Try Cash Error " + ex.Message.ToString();

        //            return Ok(objFxResponse);
        //        }

        //    }


        //}

        [HttpPost("SaveForexTranDetails_Mobile")]
        public async Task<ActionResult<int>> SaveForexTranDetails_Mobile(ForexTranDetails_Mob forexTranDetails_Mob)
        {
            try
            {
                if (forexTranDetails_Mob == null)
                {
                    return BadRequest();
                }
                var FxResponse = new FxResponse();
                using (DalSession dalSession = new DalSession())
                {
                    UnitOfWork unitOfWork = dalSession.UnitOfWork;
                    try
                    {
                        unitOfWork.BeginTransaction();
                        //    ForexTransactionDataService _Forex_Mobile = new ForexTransactionDataService(dalSession.UnitOfWork);
                        FxResponse.StatusCode = await _forexHederDataService.SaveForexTranDetails_Mobile(forexTranDetails_Mob);
                        unitOfWork.CommitTransaction();
                        return Ok(FxResponse);
                    }
                    catch (Exception)
                    {
                        unitOfWork.RollbackTransaction();
                        return Ok(FxResponse);
                    }
                }





            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }

    }
}
