using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class CustomerOtherDocumentDataService: ICustomerOtherDocumentDataService
    {
        private readonly ISqlDataAccess Db;
        public CustomerOtherDocumentDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<CustomerOtherDocument>> GetCustomerOtherDocument(string Custcode)
        {
            string sql = @"SELECT Id, CustomerCode,DocumentType,DocumentImage, Remarks, Others FROM CustomerOtherDocument WHERE CustomerCode= @CustomerCode ";

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerCode", Custcode.ToUpper(), DbType.String);
            var DataList = await Db.QueryAsync<CustomerOtherDocument>(sql, parameters);

            return DataList.ToList();
        }
        public async Task<CustomerOtherDocument> GetCustomerOtherDocumentID(int Id)
        {
            string sql = @" SELECT Id, CustomerCode,DocumentType,DocumentImage, Remarks, Others FROM CustomerOtherDocument WHERE Id= @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);

            var Data = await Db.QueryFirstOrDefaultAsync<CustomerOtherDocument>(sql, parameters);

            return Data;
        }
        public async Task<int> SaveCustomerOtherDocument(CustomerOtherDocument customerotherdocument)
        {
            string sql = @"INSERT INTO CustomerOtherDocument(CustomerCode,DocumentType, DocumentImage,
              Remarks, Others) VALUES (@CustomerCode,@DocumentType, @DocumentImage,@Remarks, @Others)";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerCode", customerotherdocument.CustomerCode, DbType.String);
            parameters.Add("DocumentType", customerotherdocument.DocumentType, DbType.String);
            parameters.Add("DocumentImage", customerotherdocument.DocumentImage, DbType.String);
            parameters.Add("Remarks", customerotherdocument.Remarks, DbType.String);
            parameters.Add("Others", customerotherdocument.Others, DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> EditCustomerOtherDocument(CustomerOtherDocument customerotherdocument)
        {

            string sql = @" UPDATE CustomerOtherDocument SET CustomerCode = @CustomerCode,DocumentType=@DocumentType,DocumentImage=@DocumentImage, Remarks = @Remarks, Others = @Others WHERE Id = @Id
                       ";


            var parameters = new DynamicParameters();
            parameters.Add("Id", customerotherdocument.Id, DbType.Int32);

            parameters.Add("CustomerCode", customerotherdocument.CustomerCode, DbType.String);
            parameters.Add("DocumentType", customerotherdocument.DocumentType, DbType.String);
            parameters.Add("DocumentImage", customerotherdocument.DocumentImage, DbType.String);
            parameters.Add("Remarks", customerotherdocument.Remarks, DbType.String);
            parameters.Add("Others", customerotherdocument.Others, DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> DeleteCustomerOtherDocument(int ID)
        {
            string sql = @"DELETE FROM CustomerOtherDocument where Id=@Id ";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", ID, DbType.Int32);
            var cnt = await Db.ExecuteAsync<Organization>(sql, parameters);
           
            return cnt;
        }

    }
}
