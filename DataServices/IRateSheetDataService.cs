using SMARTWINGS_API.Model.Rate;

namespace ForexDataService
{
    public interface IRateSheetDataService
    {
        Task<IEnumerable<RateSheet>> GetRateSheet(string Branchcode);
        Task<RateSheet> GetRateSheetByCurCode(string CurCode, string BranchCode);
        Task<int> SaveRateSheet(RateSheet ratesheet);
        Task<int> EditRateSheet(RateSheet ratesheet);
        Task<int> SaveRateSheetWithMargin(RateSheet ratesheet);
        Task<RateSheet> GetRateForForex(string CurCode, string BranchCode);
        Task<decimal> IsStockAvailable(string CurCode, string sCashierCode, string BranchCode);
        Task<decimal> FetchAvgRateCashier(string CurCode, string sCashierCode, string BranchCode);
        Task<decimal> FetchAvgRateBranch(string CurCode, string BranchCode);
    }
}
