using Dapper;
using DataAccess;
using ForexDataService;
using ForexModel;
using MathNet.Numerics.RootFinding;
using System.Data;

namespace ForexDataService
{
    public class PromoActivityDataService : IPromoActivityDataService
    {

        private readonly ISqlDataAccess Db;

        public PromoActivityDataService(ISqlDataAccess _Db)
        {
            Db = _Db;


        }
        IUnitOfWork unitOfWork = null;
        public PromoActivityDataService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public async Task<IEnumerable<PromotionalActivity>> GetPromoActivity()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PromoCode", "", DbType.String);
                parameters.Add("@Param1", "AllActive", DbType.String);
                parameters.Add("@Param2", "Y", DbType.String);
                parameters.Add("@Param3", "", DbType.String);
                parameters.Add("@Param4", "", DbType.String);                
                var DataList = await Db.QueryAsync<PromotionalActivity>("USP_VN_GET_PROMO_ACTIVITY", parameters);
                return DataList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<PromotionalActivity> GetPromoActivityByID(string PromoCode)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PromoCode", PromoCode, DbType.String);
                parameters.Add("@Param1", "SearchByCode", DbType.String);
                parameters.Add("@Param2", "", DbType.String);
                parameters.Add("@Param3", "", DbType.String);
                parameters.Add("@Param4", "", DbType.String);
                var DataList = await Db.QueryFirstOrDefaultAsync<PromotionalActivity>("USP_VN_GET_PROMO_ACTIVITY", parameters);
                return DataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> SavePromoActivity(PromotionalActivity promoActivity)
        {
            
                //string sql = @"USP_VN_MAS_PROMO_ACTIVITY";
                string sql = @"USP_VN_MAS_PROMO_ACTIVITY";
                var parameters = new DynamicParameters();
                parameters.Add("@OrgCode", promoActivity.OrgCode, DbType.String);
                parameters.Add("@PromoCode", promoActivity.PromoCode, DbType.String);
                parameters.Add("@PromoName", promoActivity.PromoName.ToUpper(), DbType.String);
                parameters.Add("@FromDate", promoActivity.FromDate, DbType.Date);
                parameters.Add("@ToDate", promoActivity.ToDate, DbType.DateTime);         
                parameters.Add("@Country", promoActivity.Country, DbType.String);
                parameters.Add("@PromoType", promoActivity.PromoType, DbType.String);
                parameters.Add("@ServCode", promoActivity.ServCode, DbType.String);
                parameters.Add("@ConfigCode", promoActivity.ConfigCode, DbType.String);
                parameters.Add("@LoyaltyPerTxn", promoActivity.LoyaltyPerTxn, DbType.Decimal);
                parameters.Add("@ServiceCharge", promoActivity.ServiceCharge, DbType.Decimal);
                parameters.Add("@ExchangeRate", promoActivity.ExchangeRate, DbType.Decimal);
                parameters.Add("@ActiveFlag", promoActivity.ActiveFlag, DbType.String);
                parameters.Add("@UserCode", promoActivity.UserCode, DbType.String);
                parameters.Add("@Message", promoActivity.Message, DbType.String);
                parameters.Add("@Remarks", promoActivity.Remarks, DbType.String);
                parameters.Add("@CountryName", promoActivity.CountryName, DbType.String);
                parameters.Add("@PromoTypeName", promoActivity.PromoTypeName, DbType.String);
                parameters.Add("@ConfigName", promoActivity.ConfigName, DbType.String);
                parameters.Add("@ServiceName", promoActivity.ServiceName, DbType.String);
                parameters.Add("@Type", "Add", DbType.String);

                var rval = await Db.ExecuteAsyncStoredProcedure<int>(sql, parameters);
            return rval;
        }

        public async Task<int> EditPromoActivity(PromotionalActivity promoActivity)
        {

            //string sql = @"USP_VN_MAS_PROMO_ACTIVITY";
            string sql = @"USP_VN_MAS_PROMO_ACTIVITY";
            var parameters = new DynamicParameters();
            parameters.Add("@OrgCode", promoActivity.OrgCode, DbType.String);
            parameters.Add("@PromoCode", promoActivity.PromoCode, DbType.String);
            parameters.Add("@PromoName", promoActivity.PromoName.ToUpper(), DbType.String);
            parameters.Add("@FromDate", promoActivity.FromDate, DbType.DateTime);
            parameters.Add("@ToDate", promoActivity.ToDate, DbType.DateTime);
            parameters.Add("@Country", promoActivity.Country, DbType.String);
            parameters.Add("@PromoType", promoActivity.PromoType.ToUpper(), DbType.String);
            parameters.Add("@ServCode", promoActivity.ServCode, DbType.String);
            parameters.Add("@ConfigCode", promoActivity.ConfigCode, DbType.String);
            parameters.Add("@LoyaltyPerTxn", promoActivity.LoyaltyPerTxn, DbType.Decimal);
            parameters.Add("@ServiceCharge", promoActivity.ServiceCharge, DbType.Decimal);
            parameters.Add("@ExchangeRate", promoActivity.ExchangeRate, DbType.Decimal);
            parameters.Add("@ActiveFlag", promoActivity.ActiveFlag, DbType.String);
            parameters.Add("@UserCode", promoActivity.UserCode, DbType.String);
            parameters.Add("@Message", promoActivity.Message, DbType.String);
            parameters.Add("@Remarks", promoActivity.Remarks, DbType.String);
            parameters.Add("@CountryName", promoActivity.CountryName, DbType.String);
            parameters.Add("@PromoTypeName", promoActivity.PromoTypeName, DbType.String);
            parameters.Add("@ConfigName", promoActivity.ConfigName, DbType.String);
            parameters.Add("@ServiceName", promoActivity.ServiceName, DbType.String);
            parameters.Add("@Type", "Edit", DbType.String);

            var rval = await Db.ExecuteAsyncStoredProcedure<int>(sql, parameters);

            return rval;



        }
    }
    public interface IPromoActivityDataService
    {
        Task<IEnumerable<PromotionalActivity>> GetPromoActivity();
        Task<PromotionalActivity> GetPromoActivityByID(string PromoCode);
        Task<int> SavePromoActivity(PromotionalActivity promoActivity);
        Task<int> EditPromoActivity(PromotionalActivity promoActivity);
    }
}