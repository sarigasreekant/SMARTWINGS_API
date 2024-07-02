using ForexModel;

namespace ForexDataService
{
    public interface ICustomerOtherDocumentDataService
    {
        Task<IEnumerable<CustomerOtherDocument>> GetCustomerOtherDocument(string Custcode);
        Task<CustomerOtherDocument> GetCustomerOtherDocumentID(int Id);
        Task<int> SaveCustomerOtherDocument(CustomerOtherDocument customerotherdocument);
        Task<int> EditCustomerOtherDocument(CustomerOtherDocument customerotherdocument);
        Task<int> DeleteCustomerOtherDocument(int ID);
    }
}
