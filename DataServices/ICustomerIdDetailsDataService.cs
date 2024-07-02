using ForexModel;

namespace ForexDataService
{
    public interface ICustomerIdDetailsDataService
    {
        Task<IEnumerable<CustomerIdDetails>> GetCustomerIdDetail(string Custcode);
        Task<CustomerIdDetails> CustomerIdDetailsByID(string Custcode);
        Task<int> SaveCustomerIdDetails(CustomerIdDetails customeriddetails);
        Task<int> EditCustomerIdDetails(CustomerIdDetails customeriddetails);
        Task<int> DeleteCustomerIdDetails(string Cutomercode, string IdTypecode);
        Task<CustomerIdDetails> CustomerPrimaryIdDetailsByID(string Custcode);

    }
}
