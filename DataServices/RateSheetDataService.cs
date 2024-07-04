using Dapper;
using DataAccess;
using ForexModel;
using Helper;
using QRCoder;
using SMARTWINGS_API.Model.Rate;
using System.Data;
using System.Globalization;

namespace ForexDataService
{
    public class RateSheetDataService : IRateSheetDataService
    {
        private readonly ISqlDataAccess Db;
        public RateSheetDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<RateSheet>> GetRateSheet( string Branchcode)
        {
            string sql = @"USP_VN_GET_RATE_SHEET";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@param1", "ByBranchCode", DbType.String);
            parameter.Add("@param2", Branchcode, DbType.String);
            parameter.Add("@param3", SD.LocalCurCode, DbType.String);
            var DataList = await Db.QueryAsync<RateSheet>(sql, parameter);





            return DataList.ToList();
        }
        public async Task<RateSheet> GetRateSheetByCurCode(string CurCode, string BranchCode)
        {
            string sql = @"USP_VN_GET_RATE_SHEET";

            var parameters = new DynamicParameters();
            parameters.Add("@param1", "ByCurCode", DbType.String);
            parameters.Add("@param2", CurCode.ToUpper(), DbType.String);
            parameters.Add("@param3", BranchCode, DbType.String);
            
            var Data = await Db.QueryFirstOrDefaultAsync<RateSheet>(sql, parameters);

            return Data;
        }
        public async Task<int> SaveRateSheet(RateSheet ratesheet)
        {
            string sql = @" INSERT INTO RateSheet( ORGCODE,BRANCHCODE, CORRORGCODE, CURCODE, CURRENCY, BASECURCODE, FACTOR, BASERATE, BUYMIN, BUYMAX, SELLMIN, SELLMAX, BUYRATE, SELLRATE, BUYMIND, BUYMAXD, SELLMIND, SELLMAXD, BUYRATED, SELLRATED, COSTRATE )
                          VALUES (@ORGCODE,@BRANCHCODE, @CORRORGCODE, @CURCODE,@CURRENCY, @BASECURCODE, @FACTOR, @BASERATE, @BUYMIN, @BUYMAX, @SELLMIN, @SELLMAX, @BUYRATE, @SELLRATE, @BUYMIND, @BUYMAXD, @SELLMIND, @SELLMAXD, @BUYRATED, @SELLRATED, @COSTRATE)";
            var parameters = new DynamicParameters();
            parameters.Add("ORGCODE", ratesheet.ORGCODE, DbType.String);
            parameters.Add("BRANCHCODE", ratesheet.BRANCHCODE, DbType.String);
            parameters.Add("CORRORGCODE", ratesheet.CORRORGCODE, DbType.String);
            parameters.Add("CURCODE", ratesheet.CURCODE, DbType.String);
            parameters.Add("CURRENCY", ratesheet.CURRENCY, DbType.String);
            parameters.Add("BASECURCODE", ratesheet.BASECURCODE, DbType.String);
            parameters.Add("FACTOR", ratesheet.FACTOR, DbType.String);
            parameters.Add("BASERATE", ratesheet.BASERATE, DbType.Decimal);
            parameters.Add("BUYMIN", ratesheet.BUYMIN, DbType.Decimal);
            parameters.Add("BUYMAX", ratesheet.BUYMAX, DbType.Decimal);
            parameters.Add("SELLMIN", ratesheet.SELLMIN, DbType.Decimal);
            parameters.Add("SELLMAX", ratesheet.SELLMAX, DbType.Decimal);
            parameters.Add("BUYRATE", ratesheet.BUYRATE, DbType.Decimal);
            parameters.Add("SELLRATE", ratesheet.SELLRATE, DbType.Decimal);
            parameters.Add("BUYMIND", ratesheet.BUYMIND, DbType.Decimal);
            parameters.Add("BUYMAXD", ratesheet.BUYMAXD, DbType.Decimal);
            parameters.Add("SELLMIND", ratesheet.SELLMIND, DbType.Decimal);
            parameters.Add("SELLMAXD", ratesheet.SELLMAXD, DbType.Decimal);
            parameters.Add("BUYRATED", ratesheet.BUYRATED, DbType.Decimal);
            parameters.Add("SELLRATED", ratesheet.SELLRATED, DbType.Decimal);
            parameters.Add("COSTRATE", ratesheet.COSTRATE, DbType.Decimal);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> EditRateSheet(RateSheet ratesheet)
        {

            string sql = @" UPDATE RateSheet SET CURRENCY=@CURRENCY,
                           BASECURCODE = @BASECURCODE, FACTOR = @FACTOR, BASERATE = @BASERATE, BUYMIN = @BUYMIN, BUYMAX = @BUYMAX, 
                           SELLMIN = @SELLMIN, SELLMAX = @SELLMAX, BUYRATE = @BUYRATE, SELLRATE = @SELLRATE, BUYMIND = @BUYMIND, 
                          BUYMAXD = @BUYMAXD, SELLMIND = @SELLMIND, SELLMAXD = @SELLMAXD, BUYRATED = @BUYRATED, SELLRATED = @SELLRATED, 
                          COSTRATE = @COSTRATE WHERE ORGCODE = @ORGCODE  AND BRANCHCODE=@BRANCHCODE AND  CURCODE=@CURCODE
                       ";

            var parameters = new DynamicParameters();
            parameters.Add("ORGCODE", ratesheet.ORGCODE, DbType.String);
            parameters.Add("BRANCHCODE", ratesheet.BRANCHCODE, DbType.String);
            parameters.Add("CORRORGCODE", ratesheet.CORRORGCODE, DbType.String);
            parameters.Add("CURCODE", ratesheet.CURCODE, DbType.String);
            parameters.Add("CURRENCY", ratesheet.CURRENCY, DbType.String);
            parameters.Add("BASECURCODE", ratesheet.BASECURCODE, DbType.String);
            parameters.Add("FACTOR", ratesheet.FACTOR, DbType.String);
            parameters.Add("BASERATE", ratesheet.BASERATE, DbType.Decimal);
            parameters.Add("BUYMIN", ratesheet.BUYMIN, DbType.Decimal);
            parameters.Add("BUYMAX", ratesheet.BUYMAX, DbType.Decimal);
            parameters.Add("SELLMIN", ratesheet.SELLMIN, DbType.Decimal);
            parameters.Add("SELLMAX", ratesheet.SELLMAX, DbType.Decimal);
            parameters.Add("BUYRATE", ratesheet.BUYRATE, DbType.Decimal);
            parameters.Add("SELLRATE", ratesheet.SELLRATE, DbType.Decimal);
            parameters.Add("BUYMIND", ratesheet.BUYMIND, DbType.Decimal);
            parameters.Add("BUYMAXD", ratesheet.BUYMAXD, DbType.Decimal);
            parameters.Add("SELLMIND", ratesheet.SELLMIND, DbType.Decimal);
            parameters.Add("SELLMAXD", ratesheet.SELLMAXD, DbType.Decimal);
            parameters.Add("BUYRATED", ratesheet.BUYRATED, DbType.Decimal);
            parameters.Add("SELLRATED", ratesheet.SELLRATED, DbType.Decimal);
            parameters.Add("COSTRATE", ratesheet.COSTRATE, DbType.Decimal);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }

        public async Task<int> SaveRateSheetWithMargin(RateSheet ratesheet)
        {
            string Branchcode = "";
            string CurrencyName = "";
            string CurrencyFactor = "D";

            decimal CostRate = 0;

            decimal BuyRate = 0;
            decimal SellRate = 0;
            decimal BuyMinRate = 0;
            decimal BuyMaxRate = 0;
            decimal SellMin = 0;
            decimal SellMax = 0;
            string CurrencyFormat = "";

            string sql = @"USP_VN_GET_RATE_SHEET";

            var parameters = new DynamicParameters();
            parameters.Add("@param1", "MarginByCurCode", DbType.String);
            parameters.Add("@param2", ratesheet.CURCODE.ToUpper(), DbType.String);
            parameters.Add("@param3", "", DbType.String);
            
            var addeditRateMarginSettingList = await Db.QueryAsync<RateMarginSetting>(sql, parameters);

            sql = @"USP_VN_GET_RATE_SHEET";

            var parameter = new DynamicParameters();
            parameters.Add("@param1", "MarginByCurCode", DbType.String);
            parameters.Add("@param2", ratesheet.CURCODE.ToUpper(), DbType.String);
            parameters.Add("@param3", "", DbType.String);
           // parameter.Add("@CurCode", ratesheet.CURCODE.ToUpper(), DbType.String);

            var currency = await Db.QueryFirstOrDefaultAsync<Currency>(sql, parameter);


            if (currency != null)
            {
                CurrencyFormat = currency.RateMaskM;
                CurrencyName = currency.CurrencyName;
                CurrencyFactor = currency.RateFactor;
            }

            var DataExitHo = await GetRateSheetByCurCode(ratesheet.CURCODE.ToUpper(), SD.HeadOfficeBranchCode);
            decimal HoCostRate = DataExitHo.COSTRATE;
            if (addeditRateMarginSettingList != null)
            {
                foreach (var addeditRateMarginSetting in addeditRateMarginSettingList)
                {
                   

                    Branchcode = addeditRateMarginSetting.BRANCHCODE;
                    //if (CurrencyFactor.Trim() == "D") {
                        
                    //    SellRate = HoCostRate - addeditRateMarginSetting.CNSMARGIN;
                    //    SellMin = HoCostRate - addeditRateMarginSetting.CNSMARGIN + addeditRateMarginSetting.CNSMIN;
                    //    SellMax = HoCostRate - addeditRateMarginSetting.CNSMARGIN - addeditRateMarginSetting.CNSMAX;
                    //    BuyRate = HoCostRate + addeditRateMarginSetting.CNBMARGIN;
                    //    BuyMinRate = HoCostRate + addeditRateMarginSetting.CNBMARGIN + addeditRateMarginSetting.CNBMIN;
                    //    BuyMaxRate = HoCostRate - addeditRateMarginSetting.CNBMARGIN - addeditRateMarginSetting.CNBMAX;
                    //}
                    //else { 
                        // IF uae AND kENYA oNLY NEED  THIS OPTION FACTOR NO NEED TO CHECK 
                        SellRate = HoCostRate + addeditRateMarginSetting.CNSMARGIN;
                        SellMin = HoCostRate + addeditRateMarginSetting.CNSMARGIN - addeditRateMarginSetting.CNSMIN;
                        SellMax = HoCostRate + addeditRateMarginSetting.CNSMARGIN + addeditRateMarginSetting.CNSMAX;
                        BuyRate = HoCostRate - addeditRateMarginSetting.CNBMARGIN;
                        BuyMinRate = HoCostRate - addeditRateMarginSetting.CNBMARGIN - addeditRateMarginSetting.CNBMIN; 
                        BuyMaxRate = HoCostRate - addeditRateMarginSetting.CNBMARGIN + addeditRateMarginSetting.CNBMAX;
                    //}
                    BuyRate = Convert.ToDecimal(BuyRate.ToString(CurrencyFormat));

                   
                    SellRate = Convert.ToDecimal(SellRate.ToString(CurrencyFormat));

                    
                    BuyMinRate = Convert.ToDecimal(BuyMinRate.ToString(CurrencyFormat));

                   
                    BuyMaxRate = Convert.ToDecimal(BuyMaxRate.ToString(CurrencyFormat));

                    
                    SellMin = Convert.ToDecimal(SellMin.ToString(CurrencyFormat));

                    
                    SellMax = Convert.ToDecimal(SellMax.ToString(CurrencyFormat));

                    RateSheet addeditRateSheet = new RateSheet();
                    addeditRateSheet.COSTRATE = DataExitHo.COSTRATE;
                    addeditRateSheet.BASERATE = DataExitHo.BASERATE;

                    addeditRateSheet.ORGCODE = "00001";
                    addeditRateSheet.BRANCHCODE = Branchcode;
                    addeditRateSheet.CORRORGCODE = "00001";
                    addeditRateSheet.CURCODE = addeditRateMarginSetting.CURCODE;
                    addeditRateSheet.CURRENCY = addeditRateMarginSetting.CURRENCY;
                    addeditRateSheet.BASECURCODE = DataExitHo.BASECURCODE;
                    addeditRateSheet.FACTOR = DataExitHo.FACTOR;
                    addeditRateSheet.COSTRATE = DataExitHo.COSTRATE;
                    addeditRateSheet.BASERATE = DataExitHo.BASERATE;
                    if (BuyRate > 0)
                    {
                        addeditRateSheet.BUYRATE = BuyRate;
                    }
                    else
                    {
                        addeditRateSheet.BUYRATE = DataExitHo.COSTRATE;
                    }
                    if (SellRate > 0)
                        addeditRateSheet.SELLRATE = SellRate;
                    else
                        addeditRateSheet.SELLRATE = DataExitHo.COSTRATE;
                    if (BuyMinRate > 0)
                        addeditRateSheet.BUYMIN = BuyMinRate;
                    else
                        addeditRateSheet.BUYMIN = DataExitHo.COSTRATE;
                    if (BuyMaxRate > 0)
                        addeditRateSheet.BUYMAX = BuyMaxRate;
                    else
                        addeditRateSheet.BUYMAX = DataExitHo.COSTRATE;
                    if (SellMin > 0)
                        addeditRateSheet.SELLMIN = SellMin;
                    else
                        addeditRateSheet.SELLMIN = DataExitHo.COSTRATE;
                    if (SellMax > 0)
                        addeditRateSheet.SELLMAX = SellMax;
                    else
                        addeditRateSheet.SELLMAX = DataExitHo.COSTRATE;

                    if (addeditRateSheet.BUYRATE > 0)
                    {
                        addeditRateSheet.BUYMIND = 1 / addeditRateSheet.BUYRATE;
                        addeditRateSheet.BUYMIND = Convert.ToDecimal(addeditRateSheet.BUYMIND.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.BUYMIND = 1 / addeditRateSheet.COSTRATE;
                        addeditRateSheet.BUYMIND = Convert.ToDecimal(addeditRateSheet.BUYMIND.ToString(CurrencyFormat));
                    }
                    if (addeditRateSheet.BUYMAX > 0)
                    {
                        addeditRateSheet.BUYMAXD = 1 / addeditRateSheet.BUYMAX;
                        addeditRateSheet.BUYMAXD = Convert.ToDecimal(addeditRateSheet.BUYMAXD.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.BUYMAXD = 1 / addeditRateSheet.COSTRATE;
                        addeditRateSheet.BUYMAXD = Convert.ToDecimal(addeditRateSheet.BUYMAXD.ToString(CurrencyFormat));
                    }

                    if (addeditRateSheet.SELLMIN > 0)
                    {
                        addeditRateSheet.SELLMIND = 1 / addeditRateSheet.SELLMIN;
                        addeditRateSheet.SELLMIND = Convert.ToDecimal(addeditRateSheet.SELLMIND.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.SELLMIND = 1 / addeditRateSheet.COSTRATE;
                        addeditRateSheet.SELLMIND = Convert.ToDecimal(addeditRateSheet.SELLMIND.ToString(CurrencyFormat));
                    }
                    if (addeditRateSheet.SELLMAX > 0)
                    {
                        addeditRateSheet.SELLMAXD = 1 / addeditRateSheet.SELLMAX;
                        addeditRateSheet.SELLMAXD = Convert.ToDecimal(addeditRateSheet.SELLMAXD.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.SELLMAXD = 0;
                    }
                    if (addeditRateSheet.BASERATE > 0)
                    {
                        addeditRateSheet.BUYRATED = 1 / addeditRateSheet.BASERATE;
                        addeditRateSheet.BUYRATED = Convert.ToDecimal(addeditRateSheet.BUYRATED.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.BUYRATED = 0;
                    }
                    if (addeditRateSheet.SELLRATE > 0)
                    {
                        addeditRateSheet.SELLRATED = 1 / addeditRateSheet.SELLRATE;
                        addeditRateSheet.SELLRATED = Convert.ToDecimal(addeditRateSheet.SELLRATED.ToString(CurrencyFormat));
                    }
                    else
                    {
                        addeditRateSheet.SELLRATED = 0;
                    }

                    addeditRateSheet.CURRENCY = addeditRateMarginSetting.CURRENCY;
                    var DataExitBranch = await GetRateSheetByCurCode(addeditRateMarginSetting.CURCODE, Branchcode);
                    if (DataExitBranch != null)
                    {
                        await EditRateSheet(addeditRateSheet);


                    }
                    else
                    {
                        await SaveRateSheet(addeditRateSheet);
                    }
                }

            }

            return 1;
        

            }

        public async Task<RateSheet> GetRateForForex(string CurCode, string BranchCode)
        {
            string sql = @"USP_VN_GET_RATE_SHEET";

            var parameters = new DynamicParameters();
            parameters.Add("@param1", "RateForForex", DbType.String);
            parameters.Add("@param2", CurCode.ToUpper(), DbType.String);
            parameters.Add("@param3", BranchCode, DbType.String);
           // parameters.Add("@CURCODE", CurCode.ToUpper(), DbType.String);
            //parameters.Add("@BranchCode", BranchCode, DbType.String);
            var Data = await Db.QueryFirstOrDefaultAsync<RateSheet>(sql, parameters);
            if (Data==null)
            {
                 sql = @"USP_VN_GET_RATE_SHEET";

                var parameter = new DynamicParameters();
                parameter.Add("@param1", "RateForForexHO", DbType.String);
                parameter.Add("@param2", CurCode.ToUpper(), DbType.String);
                parameter.Add("@param3", "00000", DbType.String);
               // parameter.Add("@CURCODE", CurCode.ToUpper(), DbType.String);
             
                 Data = await Db.QueryFirstOrDefaultAsync<RateSheet>(sql, parameter);
            }
            return Data;
        }
        public async Task<decimal> IsStockAvailable(string CurCode, string sCashierCode, string BranchCode)
        {



            string Sql = "";
            string sAccCode = await this.GetCurrencyLedgerAccount(CurCode);
            if (sAccCode == "")
                return 0;
            if (sCashierCode == "")
                return 0;
            if (BranchCode == "")
                return 0;
            var param = "";
            if (CurCode == SD.LocalCurCode)
            {
                Sql = @"USP_VN_GET_AVG_RATE_STOCK";
                 param = "LocalCurStock";
            }
            else
            {

                Sql = @"USP_VN_GET_AVG_RATE_STOCK";
                 param = "ForiegnCurStock";
            }

            decimal dBal = 0;

            try

            {
                string Fyear = SD.GetFinalYearDate();
                string EndDate = SD.GeCurrentDate();
                var parameters = new DynamicParameters();
                parameters.Add("@param1 ", param, DbType.String);
                parameters.Add("@BRANCHCODE ", BranchCode, DbType.String);
                parameters.Add("@ACCCODE", sAccCode, DbType.String);
                parameters.Add("@CASHIERCODE", sCashierCode, DbType.String);
                parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                parameters.Add("@ENDTRANDATE", EndDate, DbType.String);

                dBal = await Db.QueryFirstOrDefaultAsync<decimal>(Sql, parameters);

             
                return dBal;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public async Task<string> GetCurrencyLedgerAccount(string CurCode)
        {
            string sql = @"USP_VN_GET_RATE_SHEET";

            var parameters = new DynamicParameters();
            parameters.Add("@param1", "CurLedgerAccode", DbType.String);
            parameters.Add("@param2", CurCode.ToUpper(), DbType.String);
            parameters.Add("@param3", "00000", DbType.String);
           // parameters.Add("@CurCode", CurCode.ToUpper(), DbType.String);
            try
            {
                return  await Db.QueryFirstOrDefaultAsync<string>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public async Task<decimal> FetchAvgRateCashier(string CurCode, string sCashierCode, string BranchCode)
        {
            decimal dBal = 0;
            if (CurCode == "")
                return 0;

            if (CurCode != SD.LocalCurCode && CurCode != SD.LocalCurCodeRemit)
            {


                string sAccCode = await this.GetCurrencyLedgerAccount(CurCode);
                if (sAccCode == "")
                    return 0;
                if (sCashierCode == "")
                    return 0;
                if (BranchCode == "")
                    return 0;

                string Sql = @"USP_VN_GET_AVG_RATE_STOCK";





                try
                {
                    string Fyear = SD.GetFinalYearDate();
                    string EndDate = SD.GeCurrentDate();
                    var parameters = new DynamicParameters();
                    parameters.Add("@param1 ", "AvgRateCashier", DbType.String);
                    parameters.Add("@BRANCHCODE ", BranchCode.Trim(), DbType.String);
                    parameters.Add("@ACCCODE", sAccCode.Trim(), DbType.String);
                    parameters.Add("@CASHIERCODE", sCashierCode.Trim(), DbType.String);
                    parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                    parameters.Add("@ENDTRANDATE", EndDate, DbType.String);

                    dBal = await this.Db.QueryFirstOrDefaultAsync<decimal>(Sql, parameters);
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

                string Sql = @"USP_VN_GET_AVG_RATE_STOCK";





                try
                {
                    string Fyear = SD.GetFinalYearDate();
                    string EndDate = SD.GeCurrentDate();

                    var parameters = new DynamicParameters();
                    parameters.Add("@param1 ", "AvgRateBranch", DbType.String);
                    parameters.Add("@BRANCHCODE ", BranchCode, DbType.String);
                    parameters.Add("@ACCCODE", sAccCode, DbType.String);

                    parameters.Add("@FINALYYEAR", Fyear, DbType.String);
                    parameters.Add("@ENDTRANDATE", EndDate, DbType.String);

                    dBal = await this.Db.QueryFirstOrDefaultAsync<decimal>(Sql, parameters);
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

    }
}
