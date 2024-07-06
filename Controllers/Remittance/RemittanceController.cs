using DataAccess;

using ForexDataService;
using ForexModel;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
//using NPOI.SS.Formula.Functions;
using QRCoder;
//using Syncfusion.Blazor.RichTextEditor;
using System;
using System.Data;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RemittanceController : ControllerBase
    {
        private readonly IRemittanceDataService _remittanceDatatService;
        private readonly IServiceAccountsDataService _serviceAccountsDataService;
        private readonly ICustomer_mstDataService _customer_mstDataService;
        private readonly ILogger<RemittanceController> _logger;
        private IApplicationErorrLogService _applicationErorrLogService;
        public RemittanceController(IRemittanceDataService remittanceDatatService, IApplicationErorrLogService applicationErorrLogService,ICustomer_mstDataService customer_MstDataService, ILogger<RemittanceController> logger)
        {
            this._remittanceDatatService = remittanceDatatService;
            _applicationErorrLogService = applicationErorrLogService;
            _customer_mstDataService = customer_MstDataService;
            _logger = logger;
        }

        [HttpGet("GetBenifBankSearch/{corrOrgcode}/{Countrycode}/{Curcode}/{ServCode}/{Param1}/{Param2}/{Param3}")]
        public async Task<ActionResult<IEnumerable<OrgnizationBranch>>> GetBenifBankSearch([FromRoute] string corrOrgcode, string Countrycode, string Curcode, string ServCode, string Param1, string Param2, string Param3)
        {
            try
            {
                var result = await _remittanceDatatService.GetBenifBankSearch(corrOrgcode, Countrycode, Curcode, ServCode, Param1, Param2, Param3);

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
        [HttpPost("GetBenefBankBranchSearch")]
        public async Task<ActionResult<IEnumerable<DropDwnListIdText>>> GetBenefBankBranchSearch(BenefBankBranchSearch? benefBankBranchSearch)
        {

            try
            {
                var result = await _remittanceDatatService.GetBenefBankBranchSearch(benefBankBranchSearch);

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
        [HttpPost("GetBenefBankSearch")]
        public async Task<ActionResult<IEnumerable<DropDwnListIdText>>> GetBenefBankSearch(BenefBankSearch? benefBankSearch)
        {

            try
            {
                var result = await _remittanceDatatService.GetBenefBankSearch(benefBankSearch);

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
       
        [HttpGet("GetCorrespondent/{concode}/{curcode}/{servcode}")]
        public async Task<ActionResult<IEnumerable<RemitCorrespondent>>> GetCorrespondent(string concode, string curcode, string servcode)
        {

            try
            {
                var result = await _remittanceDatatService.GetCorrespondent(concode, curcode, servcode);

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

        [HttpGet("GetOrganization/{corrcode}")]
        public async Task<ActionResult<Organization>> GetOrganizationByID([FromRoute] string corrcode)
        {
            try
            {
                var result = await _remittanceDatatService.GetOrganization(corrcode);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpGet("GetCorrOrgcode/{corrcode}")]
        public async Task<ActionResult<CorrespondentConfig>> GetCorrOrgcode([FromRoute] string corrcode)
        {
            try
            {
                var result = await _remittanceDatatService.GetCorrOrgcode(corrcode);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpGet("GetRemittanceByNo/{refno}")]
        public async Task<ActionResult<Remittance>> GetRemittanceByNo([FromRoute] string refno)
        {
            try
            {
                var result = await _remittanceDatatService.GetRemittanceByNo(refno);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
       

        [HttpPost("SaveRemittance")]
        public async Task<ActionResult<RemitResponse>> SaveRemittance(Remittance remittance)
        {
            try
            {
                if (remittance == null)
                {
                    return BadRequest();
                }
               
                var custcode = remittance.CustCode;
                Customer_mst custdetails = new Customer_mst();
                
                custdetails= await _customer_mstDataService.GetCustomerByID(custcode);
                if (custdetails == null)
                {
                    return BadRequest();
                }
                remittance.Name1=custdetails.Name1;
                remittance.Name2=custdetails.Name2;
                remittance.Name3 = custdetails.Name3;
                remittance.Name4= custdetails.Name4;
                remittance.Cell1 = custdetails.Cell1;
                remittance.Gender = custdetails.Gender;
                remittance.Dob=custdetails.Dob;
                remittance.Address1 = custdetails.Adrees2;
                remittance.CountryCode = custdetails.Country;
                remittance.Country = custdetails.Country;
                remittance.Nationcode = custdetails.Nationcode;
                remittance.Nationality = custdetails.Nationality;
                remittance.Profession=custdetails.Profession;
                remittance.Mail=custdetails.Mail;
                remittance.Company= custdetails.Company;
                remittance.Photo=custdetails.Photo;
                remittance.IdType= custdetails.IdType;
                remittance.IdNo=custdetails.IdNo;
                remittance.ExpDate=custdetails.ExpDate;
                remittance.IssueContcode = custdetails.IssueContcode;
                remittance.IdImageFront = custdetails.ImageFront;
                remittance.IdImageBack = custdetails.ImageBack;
               
                
                var result = await _remittanceDatatService.SaveRemittance(remittance);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }        

        
        [HttpGet("GetRemittanceByRefNo/{refno}")]
        public async Task<ActionResult<RemittanceDTO>> GetRemittanceByRefNo([FromRoute] string refno)
        {
            try
            {
                var result = await _remittanceDatatService.GetRemittanceByRefNo(refno);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }       

        //[HttpPost("SaveRemittancePayDTO")]
        //public async Task<ActionResult<RemitResponse>> SaveRemittancePayDTO(RemitDTO remitDTO)
        //{
        //    List<RemittancePayDTO> ObservableData = remitDTO.remittancePayDTO;
        //    RemittanceDTO addedRemittance = remitDTO.remittanceDTO;
        //    ServiceAccounts serviceAccounts = new ServiceAccounts();
        //    var applicationErorrLog = new ApplicationErorrLog();
        //    applicationErorrLog.ActionName = "SaveRemittancePay";
        //    applicationErorrLog.ModuleName = "Remittance";
        //    applicationErorrLog.ConttroleName = "RemittanceController";
        //    RemitResponse objFxResponse = new RemitResponse();
        //    objFxResponse.IsSucess = true;
        //    objFxResponse.StatusCode = 200;
        //    objFxResponse.StatusMesage = "Data saved Sucessfully";
        //    objFxResponse.RefNo = "";
        //    var corresAcc = new ServiceAccounts();
        //    corresAcc.ConfigCode = addedRemittance.CorrCode;
        //    corresAcc.UserCode = addedRemittance.UserId;
        //    serviceAccounts = await _remittanceDatatService.GetServiceAccounts(corresAcc);
        //    if (string.IsNullOrEmpty(serviceAccounts.LedgerAC) || string.IsNullOrEmpty(serviceAccounts.CommisionAC) || string.IsNullOrEmpty(serviceAccounts.ExVariationAC))
        //    {
        //        objFxResponse.IsSucess = false;
        //        objFxResponse.StatusCode = 116;
        //        objFxResponse.StatusMesage = "Please add Account for this Correspondent!!!";
        //        return Ok(objFxResponse);
        //    }
        //    var RemitanceObj = new RemittanceDTO();
        //    RemitanceObj = remitDTO.remittanceDTO;
        //    string RefNo = RemitanceObj.RefNo;
        //    using (DalSession dalSession = new DalSession())
        //    {
        //        decimal TotalGross = RemitanceObj.TotalLcy;
        //        UnitOfWork unitOfWork = dalSession.UnitOfWork;
        //        unitOfWork.BeginTransaction();

        //        ForexTransactionDataService forexTransactionDataService = new ForexTransactionDataService(dalSession.UnitOfWork);
        //        JournalDataService journalDataService = new JournalDataService(dalSession.UnitOfWork);

        //        journalDataService.BranchCode = RemitanceObj.BranchCode;
        //        journalDataService.CashierCode = addedRemittance.UserId;// need to check where passing USERId
        //        journalDataService.UserId = addedRemittance.UserId;
        //        journalDataService.Trandate = Convert.ToDateTime(SD.ServerDateTime());
        //        bool isJvSave = false;
        //        string CorrespondentLedger = "" + serviceAccounts.LedgerAC;
        //        string CommAccount = "" + serviceAccounts.CommisionAC;
        //        string ExchangeVariAccount = "" + serviceAccounts.ExVariationAC;
        //        string TaxAccount = SDAccount.TaxAccount;// need to crate SDValue

        //        string RetNarration = "Remittance";
        //        decimal Profit = 0;
        //        decimal LcyAmount = 0;
        //        decimal LRate = 0;
        //        #region Payment Mode Save
        //        int Success = 0;
        //        int val = 0;
        //        RemittancePayment addeditPaymentmode = new RemittancePayment();
        //        foreach (var items in ObservableData)
        //        {
        //            if(items.PayCode == "00001")
        //            {
        //                addeditPaymentmode.AccountCode = SD.LocalCurCodeRemitAccode;
        //            }
        //            else
        //            {
        //                if(items.BankCode != null || items.BankCode != "") {
        //                var BankAc = await _remittanceDatatService.GetLocalBankAccounts(items.BankCode, SD.LocalCurCode);
        //                    if(BankAc != null)
        //                    {
        //                        addeditPaymentmode.AccountCode = BankAc.BankLedgerCode;
        //                    }
        //                    else
        //                    {
        //                        addeditPaymentmode.AccountCode = items.AccountCode;

        //                    }
        //                }
        //                else
        //                {
        //                    addeditPaymentmode.AccountCode = items.AccountCode;

        //                }

        //            }

        //            val = val + 1;
        //            addeditPaymentmode.PortalCode = items.PortalCode;
        //            addeditPaymentmode.OrgCode = items.OrgCode;
        //            addeditPaymentmode.MenuCode = items.MenuCode;
        //            addeditPaymentmode.PayRefNo = items.PayRefNo;
        //            addeditPaymentmode.TranDate = items.TranDate;
        //            addeditPaymentmode.UserCode = items.UserCode;
        //            addeditPaymentmode.PayCurCode = items.PayCurCode;
        //            addeditPaymentmode.PayAmount = items.PayAmount;
        //            addeditPaymentmode.Rate = items.Rate;
        //            addeditPaymentmode.Discount = items.Discount;
        //            addeditPaymentmode.Pay_ID = items.Pay_ID;
        //            addeditPaymentmode.PayCodeName = items.PayCodeName;
        //            addeditPaymentmode.BankCode = items.BankCode;
        //            addeditPaymentmode.BankName = items.BankName;
        //            addeditPaymentmode.CardCharge = items.CardCharge;
        //            addeditPaymentmode.CheqDt = items.CheqDt;
        //            addeditPaymentmode.USDAmount = items.USDAmount;
        //            addeditPaymentmode.RefNo = items.RefNo;
        //            addeditPaymentmode.PaidAmount = items.PaidAmount;
        //            addeditPaymentmode.BalAmount = items.BalAmount;
        //            addeditPaymentmode.PayCode = items.PayCode;
        //            addeditPaymentmode.TotalDeno = items.TotalDeno;
        //            addeditPaymentmode.TotalDenoAmt = items.TotalDenoAmt;
        //            addeditPaymentmode.BalanceCashPay = items.BalanceCashPay;

        //            addeditPaymentmode.PayCurName = items.PayCurName;
        //            addeditPaymentmode.USDBalAmount = items.USDBalAmount;
        //            addeditPaymentmode.IsDenoRqd = items.IsDenoRqd;
        //            addeditPaymentmode.USDRate = items.USDRate;
        //            addeditPaymentmode.IsUSDRqd = items.IsUSDRqd;

                    
        //            var RemResult = await forexTransactionDataService.SaveRemittancePay(addeditPaymentmode);


        //        }
        //        #endregion payment Mode save
        //        // if() bank lcyamount= fcyamount *cost rate    proft=RemitanceObj.LcyAmoun-lcyamount; else
        //        #region Jv Service Region

        //        Decimal TotalDebit = 0;
        //        Decimal TotalCredit = 0;

        //        if (serviceAccounts.OrgType == 2)// bank 
        //        {
        //            LcyAmount = Convert.ToDecimal(RemitanceObj.FcyAmount * RemitanceObj.CostRate);
        //            Profit = Convert.ToDecimal(RemitanceObj.LcyAmount - LcyAmount);
        //            LRate = RemitanceObj.CostRate;
        //            if (LcyAmount < 0)
        //                LcyAmount = System.Math.Abs(LcyAmount);
        //        }
        //        else
        //        {
        //            LcyAmount = RemitanceObj.LcyAmount;
        //            LRate = RemitanceObj.Rate;
        //        }

        //        if (LcyAmount > 0)
        //        {
        //            isJvSave = await journalDataService.CreateJVEntry(CorrespondentLedger, "C", RemitanceObj.FcyAmount, LcyAmount, LRate, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));


        //            if (isJvSave == false)
        //            {

        //                unitOfWork.RollbackTransaction();
        //                applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                objFxResponse.IsSucess = false;
        //                objFxResponse.StatusCode = 106;
        //                objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                return Ok(objFxResponse);
        //            }
        //            TotalCredit = TotalCredit + LcyAmount;
        //        }
        //        if (RemitanceObj.CommLcy > 0)
        //        {
        //            isJvSave = await journalDataService.CreateJVEntry(CommAccount, "C", 0, RemitanceObj.CommLcy, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //            if (isJvSave == false)
        //            {

        //                unitOfWork.RollbackTransaction();
        //                applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                objFxResponse.IsSucess = false;
        //                objFxResponse.StatusCode = 106;
        //                objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                return Ok(objFxResponse);
        //            }

        //            TotalCredit = TotalCredit + RemitanceObj.CommLcy;
        //        }
        //        if (RemitanceObj.TaxLcy > 0)
        //        {
        //            isJvSave = await journalDataService.CreateJVEntry(TaxAccount, "C", 0, RemitanceObj.TaxLcy, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //            if (isJvSave == false)
        //            {

        //                unitOfWork.RollbackTransaction();
        //                applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                objFxResponse.IsSucess = false;
        //                objFxResponse.StatusCode = 106;
        //                objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                return Ok(objFxResponse);
        //            }
        //            TotalCredit = TotalCredit + RemitanceObj.TaxLcy;
        //        }
        //        if (Profit != 0)
        //        {
        //            if (Profit > 0)//PROFIT 
        //            {
        //                isJvSave = await journalDataService.CreateJVEntry(ExchangeVariAccount, "C", Profit, Profit, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                TotalCredit = TotalCredit + Profit;
        //            }
        //            else
        //            {
        //                Profit = System.Math.Abs(Profit);// IF IT GOES TO LOSS /

        //                isJvSave = await journalDataService.CreateJVEntry(ExchangeVariAccount, "D", Profit, Profit, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                TotalDebit = TotalDebit + Profit;
        //            }
        //            if (isJvSave == false)
        //            {

        //                unitOfWork.RollbackTransaction();
        //                applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                objFxResponse.IsSucess = false;
        //                objFxResponse.StatusCode = 106;
        //                objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                return Ok(objFxResponse);
        //            }
        //        }

        //        // dibt 


        //        var ListPayMode = remitDTO.remittancePayDTO;

        //        // var CashMode = from Cash in ListPayMode where Cash.PayCode == "Cash" select Cash;//Need tp check paycode 
        //        // 00001 - Cash, 00002 - Cheque, 00003 -POS, 00003 - A/c Transfer
        //        var CashMode = ListPayMode.FirstOrDefault(cash => cash.PayCode == "00001");
        //        var AccountTransfer = ListPayMode.FirstOrDefault(cash => cash.PayCode == "00004");
        //        var Cheque = ListPayMode.FirstOrDefault(cash => cash.PayCode == "00002");
        //        var DebitCard = ListPayMode.FirstOrDefault(cash => cash.PayCode == "00003");

        //        if (CashMode != null)
        //        {
        //            decimal Amount = CashMode.PaidAmount; // need to check this amount no getting value 
        //            // need to Identify whether its USD or LOcal 
        //            if (CashMode.PayCurCode == SD.LocalCurCode)
        //            {
        //                if (Amount > 0)
        //                {
        //                    isJvSave = await journalDataService.CreateJVEntry(SD.LocalCurCodeRemitAccode, "D", Amount, Amount, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
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
        //                    TotalDebit = TotalDebit + Amount;
        //                }
        //            }
        //            else
        //            {
        //                //USD Part 
        //                decimal USDAmount = CashMode.USDAmount;
        //                decimal USDLcyAmount = CashMode.PaidAmount;
        //                decimal USdRate = CashMode.USDRate;// u need to add one more fileds USDRate okok
        //                if (USDAmount > 0)// need to check USD please change value 
        //                {
        //                    isJvSave = await journalDataService.CreateJVEntry(SD.USDRemitAccode, "D", USDAmount, USDLcyAmount, USdRate, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
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
        //                    TotalDebit = TotalDebit + Amount;
        //                }
        //            }

        //        }

        //        // need to change account code accordingly 
        //        if (AccountTransfer != null)
        //        {
        //            var Amount = AccountTransfer.PaidAmount; // need to check this amount 
        //            var BankAc = await _remittanceDatatService.GetLocalBankAccounts(AccountTransfer.BankCode, SD.LocalCurCode);
        //            var BanAcCode = BankAc.BankLedgerCode;
        //            if (Amount > 0)
        //            {
        //                isJvSave = await journalDataService.CreateJVEntry(BanAcCode, "D", Amount, Amount, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                if (isJvSave == false)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 106;
        //                    objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);
        //                }

        //                TotalDebit = TotalDebit + Amount;
        //            }
        //        }
        //        if (Cheque != null)
        //        {
        //            var Amount = Cheque.PaidAmount; // need to check this amount 
        //            var BankAc = await _remittanceDatatService.GetLocalBankAccounts(Cheque.BankCode, SD.LocalCurCode);
        //            var BanAcCode = BankAc.BankLedgerCode;
        //            if (Amount > 0)
        //            {
        //                isJvSave = await journalDataService.CreateJVEntry(BanAcCode, "D", Amount, Amount, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                if (isJvSave == false)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 106;
        //                    objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);
        //                }
        //                TotalDebit = TotalDebit + Amount;
        //            }
        //        }
        //        if (DebitCard != null)
        //        {
        //            var Amount = DebitCard.PaidAmount; // need to check this amount 
        //            var BankAc = await _remittanceDatatService.GetLocalBankAccounts(DebitCard.BankCode, SD.LocalCurCode);
        //            var BanAcCode = BankAc.BankLedgerCode;
        //            if (Amount > 0)
        //            {
        //                isJvSave = await journalDataService.CreateJVEntry(BanAcCode, "D", Amount, Amount, 0, RemitanceObj.RefNo, RetNarration, RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                if (isJvSave == false)
        //                {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 106;
        //                    objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);
        //                }
        //                TotalDebit = TotalDebit + Amount;
        //            }
        //        }

        //        if (TotalDebit - TotalCredit != 0)
        //        {
        //            var RoundOffValue = TotalDebit - TotalCredit;
        //            if (RoundOffValue > 0) //if debit more credit lesss
        //            {
        //                if (RoundOffValue > 0) //if debit more credit lesss
        //                {
        //                    isJvSave = await journalDataService.CreateJVEntry(SDAccount.RoundOffAccode, "C", RoundOffValue, RoundOffValue, 0, RemitanceObj.RefNo, RetNarration + "Round Off Amount", RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
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
        //            }
        //            else
        //            {
        //                if(Math.Abs(RoundOffValue) > 2) 
        //                { 
        //                  isJvSave = await journalDataService.CreateJVEntry(SDAccount.RoundOffAccode, "D", Math.Abs(RoundOffValue), Math.Abs(RoundOffValue), 0, RemitanceObj.RefNo, RetNarration + "Round Off Amount", RemitanceObj.CustCode, ((int)CJVModuleName.JVModuleName.Remittance));
        //                  if (isJvSave == false)
        //                  {

        //                    unitOfWork.RollbackTransaction();
        //                    applicationErorrLog.ErrorMesage = journalDataService.ErorrMessage;
        //                    applicationErorrLog.Errordate = Convert.ToDateTime(SD.ServerDateTime());
        //                    applicationErorrLog.EorrDetails = journalDataService.ErorrMessage;
        //                    await _applicationErorrLogService.SaveLog(applicationErorrLog);


        //                    objFxResponse.IsSucess = false;
        //                    objFxResponse.StatusCode = 106;
        //                    objFxResponse.StatusMesage = journalDataService.ErorrMessage;
        //                    return Ok(objFxResponse);
        //                  }
        //                }
        //            }
        //        }

        //        if (journalDataService.TotalCredit != journalDataService.TotalDebit)
        //        {

        //            unitOfWork.RollbackTransaction();
        //            applicationErorrLog.ErrorMesage = "journal DataService Total Debit";
        //            applicationErorrLog.Errordate = System.DateTime.Now;
        //            applicationErorrLog.EorrDetails = "journal DataService Total Debit";
        //            await _applicationErorrLogService.SaveLog(applicationErorrLog);

        //            objFxResponse.IsSucess = false;
        //            objFxResponse.StatusCode = 116;
        //            objFxResponse.StatusMesage = "Total Debit and Credit Not Talling " + journalDataService.TotalCredit + " Dr " + journalDataService.TotalDebit;
        //            return Ok(objFxResponse);

        //        }
        //        #endregion jvservice region
        //        #region Remittance Update Paid Flag
        //        #endregion  Remittance Update 
        //        unitOfWork.CommitTransaction();
        //        objFxResponse.RefNo = RefNo;
        //        objFxResponse.IsSucess = true;
        //        objFxResponse.StatusCode = 200;
        //        objFxResponse.StatusMesage = "Data saved Sucessfully";

        //        return Ok(objFxResponse);
        //    }
        //    // please modify this cuction and 

        //    // objFxResponse = await forexTransactionDataService.SaveRemittancePay(remitpay); 
        //    return Ok(objFxResponse);




        //}

       
        [HttpPost("GetRoutingBankSearch")]
        public async Task<ActionResult<IEnumerable<DropDwnListIdText>>> GetRoutingBankSearch(RoutingBankSearch? routingBankSearch)
        {

            try
            {
                var result = await _remittanceDatatService.GetRoutingBankSearch(routingBankSearch);

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

    }
}

//[HttpPost("SaveRemittancePay")]
//public async Task<ActionResult<RemitResponse>> SaveRemittancePay(RemittancePayment remitpay)
//{
//    try
//    {
//        if (remitpay == null)
//        {
//            return BadRequest();
//        }


//        var result = await _remittanceDatatService.SaveRemittancePay(remitpay);
//        return Ok(result);



//    }
//    catch (Exception ex)
//    {
//        _logger.LogError(ex.ToString());
//        return StatusCode(StatusCodes.Status500InternalServerError,
//           "Error saving data");
//    }
//}