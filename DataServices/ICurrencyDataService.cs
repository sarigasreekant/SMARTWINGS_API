using ForexModel;

namespace ForexDataService
{
    public interface ICurrencyDataService
    {
        Task<IEnumerable<Currency>> GetCurrency();
        Task<Currency> GetCurrencyByID(string CurCode);
        Task<int> SaveCurrency(Currency currency);
        Task<int> EditCurrency(Currency currency);
    }
}
