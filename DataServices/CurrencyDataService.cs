using Dapper;
using DataAccess;

using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class CurrencyDataService: ICurrencyDataService
    {
        private readonly ISqlDataAccess Db;
        public CurrencyDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<Currency>> GetCurrency()
        {
            string sql = @"SELECT CurCode, CurrencyName, CurDecimal, 
                         Groupcountry, Display, CBCurcode, OTCurocde,RateMaskM,RateMaskD,RateFactor,Activeflag,ShowRatesheet,LedgerAccode,TransitAccode,ExchangeVariAccode,DealingAccode 
                      FROM Currency where Activeflag=@Activeflag";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Activeflag", "Y", DbType.String);
            var DataList = await Db.QueryAsync<Currency>(sql, parameter);





            return DataList.ToList();
        }
        public async Task<Currency> GetCurrencyByID(string CurCode)
        {
            string sql = @"SELECT CurCode, CurrencyName, CurDecimal, Groupcountry, Display, CBCurcode, 
                            OTCurocde,RateMaskM,RateMaskD,RateFactor,Activeflag,ShowRatesheet,LedgerAccode,TransitAccode,ExchangeVariAccode,DealingAccode FROM Currency WHERE CurCode= @CurCode";

            var parameters = new DynamicParameters();
            parameters.Add("@CurCode", CurCode.ToUpper(), DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<Currency>(sql, parameters);

            return Data;
        }
        public async Task<int> SaveCurrency(Currency currency)
        {
            string sql = @"INSERT INTO Currency(CurCode,orgcode,CurrencyName, CurDecimal, Groupcountry, Display, CBCurcode, OTCurocde,RateMaskM,RateMaskD,RateFactor,Activeflag,ShowRatesheet)
                         VALUES 
                            (@CurCode,@orgcode,@CurrencyName, @CurDecimal, @Groupcountry, @Display, @CBCurcode, @OTCurocde,@RateMaskM,@RateMaskD,@RateFactor,@Activeflag,@ShowRatesheet)";
            var parameters = new DynamicParameters();
            parameters.Add("CurCode", currency.CurCode.ToUpper(), DbType.String);
            parameters.Add("orgcode", SD.OrgCode, DbType.String);
            parameters.Add("CurrencyName", currency.CurrencyName.ToUpper(), DbType.String);
            parameters.Add("CurDecimal", currency.CurDecimal, DbType.Int32);
            parameters.Add("Groupcountry", currency.Groupcountry, DbType.String);
            parameters.Add("Display", currency.Display, DbType.String);
            parameters.Add("CBCurcode", currency.CBCurcode, DbType.String);
            parameters.Add("OTCurocde", currency.OTCurocde, DbType.String);
            parameters.Add("RateMaskM", currency.RateMaskM, DbType.String);
            parameters.Add("RateMaskD", currency.RateMaskD, DbType.String);
            parameters.Add("RateFactor", currency.RateFactor, DbType.String);
            parameters.Add("Activeflag", currency.Activeflag, DbType.String);
            parameters.Add("ShowRatesheet", currency.ShowRatesheet, DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> EditCurrency(Currency currency)
        {

            string sql = @" UPDATE Currency SET CurrencyName = @CurrencyName, CurDecimal = @CurDecimal, Groupcountry = @Groupcountry, 
                           Display = @Display, CBCurcode = @CBCurcode, OTCurocde = @OTCurocde,RateMaskM=@RateMaskM,RateMaskD=@RateMaskD, 
                           RateFactor=@RateFactor,Activeflag=@Activeflag,ShowRatesheet=@ShowRatesheet
                      
                           WHERE CurCode = @CurCode
                       ";


            var parameters = new DynamicParameters();
            parameters.Add("CurCode", currency.CurCode.ToUpper(), DbType.String);

            parameters.Add("CurrencyName", currency.CurrencyName.ToUpper(), DbType.String);
            parameters.Add("CurDecimal", currency.CurDecimal, DbType.Int32);
            parameters.Add("Groupcountry", currency.Groupcountry, DbType.String);
            parameters.Add("Display", currency.Display, DbType.String);
            parameters.Add("CBCurcode", currency.CBCurcode, DbType.String);
            parameters.Add("OTCurocde", currency.OTCurocde, DbType.String);
            parameters.Add("RateMaskM", currency.RateMaskM, DbType.String);
            parameters.Add("RateMaskD", currency.RateMaskD, DbType.String);
            parameters.Add("RateFactor", currency.RateFactor, DbType.String);
            parameters.Add("Activeflag", currency.Activeflag, DbType.String);
            parameters.Add("ShowRatesheet", currency.ShowRatesheet, DbType.String);
         //   parameters.Add("@LedgerAccode", currency.LedgerAccode.Trim(), DbType.String);
            //parameters.Add("@TransitAccode", currency.TransitAccode.Trim(), DbType.String);
           // parameters.Add("@ExchangeVariAccode", currency.ExchangeVariAccode.Trim(), DbType.String);
          //  parameters.Add("@DealingAccode", currency.DealingAccode.Trim(), DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        
    }
}
