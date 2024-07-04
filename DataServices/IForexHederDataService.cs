using Microsoft.AspNetCore.Mvc;
using SMARTWINGS_API.Model.Forex;

namespace ForexDataService
{
    public interface IForexHederDataService
    {
        Task<IEnumerable<ForexTranDetails>> GetForexTranDetails(string Refno);
        Task<ForexTransHeader> GetForexTransHeader(string Refno);
        Task<IEnumerable<ForexTranDetails>> GetForexTranDetailsForeCancel(string Refno, string CancelId);
        Task<int> CancelForexTransHeaderRequest([FromBody] ForexTransHeader forex_transheader);
        Task<int> CancelForexTransHeaderRequestDTO([FromBody]ForexTransHeaderCancelDTO forex_transheader);
        Task<int> CancelForexTransHeaderRequestAuth([FromBody] ForexTransHeaderCancelDTO forex_transheader);
        Task<IEnumerable<ForexTranDetails>> GetForexForDatshBoard(string UserId);
        Task<ForexDashBoard> GetForexCountDatshBoard(string UserId);
        Task<IEnumerable<RenderingData>> GetForexCurrencyChartDatshBoard(string UserId);
        Task<IEnumerable<IncomeExpense>> GetForexProfitChartDatshBoard(string UserId);
        Task<IEnumerable<ForexTranDetails>> GetForexTranDetailsSearch(string Refno);
        Task<ForexTransHeader> GetForexTransHeaderSearch(string Refno);
        Task<RemitDashBoard> GetRemitCountDatshBoard(string UserId);
        Task<IncomingDashBoard> GetIncomCountDatshBoard(string UserId);
        Task<CustDashBoard> GetCustCountDatshBoard(string UserId);
        Task<int> SaveForexTranDetails_Mobile([FromBody] ForexTranDetails_Mob FOREXMOBILE);


    }
}
