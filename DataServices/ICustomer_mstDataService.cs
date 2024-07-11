using ForexModel;

namespace ForexDataService
{
    public interface ICustomer_mstDataService
    {
        Task<IEnumerable<Customer_mst>> GetCustomer();
        Task<Customer_mst> GetCustomerByID(string Custcode);
      
        Task<IEnumerable<Customer_mst>> Customer_mstSearch(string CustCode, string Mobile, string name, string @Param);
        Task<IEnumerable<Customer_mst>> Customer_mstSearchNew(CustomerSearch customerSearch);

        Task<IEnumerable<Customer_mst>> GetCustomerKYC(string Custcode);
        Task<string> CheckNumberExistOrNot(string param1,string param2);
    }
}
