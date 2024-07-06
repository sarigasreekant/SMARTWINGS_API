using ForexModel;
using SMARTWINGS_API.Model.Forex;

namespace SMARTWINGS_API.DataServices
{
    public interface IForexTransactionDataService
    {
        Task<int> SaveForexTransHeader(ForexTransHeader forex_transheader);
        Task<int> SaveForexTranDetails(ForexTranDetails forex_trandetails);
        Task<OrgnizationBranch> GetOrgnizationBranchByID(string BranchCode, string OrgCode);
        Task<string> GetForexRefno(string BranchCode);
        Task<int> SaveRemittancePay(RemittancePayment remitpay);
        Task<int> SaveIncomingPay(IncomingPay remitpay);

     
    }
}
