using Dapper;
using System.Data;

namespace DataAccess
{
    public interface ISqlDataAccess
    {
        IEnumerable<T> Query<T>(string sql, DynamicParameters Pram);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters Pram);
        T ExecuteScalar<T>(string sql, DynamicParameters Pram);
        Task<T> ExecuteScalarAsync<T>(string sql, DynamicParameters Pram);
        T QuerySingle<T>(string sql, DynamicParameters Pram);
        Task<T> QuerySingleAsync<T>(string sql, DynamicParameters Pram);
        T QueryFirstOrDefault<T>(string sql, DynamicParameters Pram);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters Pram);
        int Execute<T>(string sql, DynamicParameters Pram);
        Task<int> ExecuteAsync<T>(string sql, DynamicParameters Pram);
        Task<int> ExecuteAsyncStoredProcedure<T>(string sql, DynamicParameters Pram);
       
        Task<T> ExecuteScalarAsyncExecuteAsyncStoredProcedure<T>(string sql, DynamicParameters Pram);
        DataTable DataTableQuery(string sql, DynamicParameters Pram);
        Task<DataTable> DataTableQueryAsync(string sql, DynamicParameters Pram);
        Task<int> ExecuteAsynModel<T>(string sql, T data);
        Task<IEnumerable<T>> QuerySPAsync<T>(string sql, DynamicParameters Pram);



    }
}
