using Dapper;
using DHBForexAPI;
using Helper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SqlDataAccess : ISqlDataAccess, IDisposable
    {
        private readonly IConfiguration _configuration;

        private string _config = string.Empty;
        private readonly ILogger<SqlDataAccess> _logger;
        public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _config = "" + _configuration.GetConnectionString("SqlConnection").ToString().Trim();
        }
        public IEnumerable<T> Query<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var Data = cnn.Query<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var Data = await cnn.QueryAsync<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }

                        return Data;

                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public T ExecuteScalar<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var count = cnn.ExecuteScalar<T>(sql, Pram);

                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return count;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public async Task<T> ExecuteScalarAsync<T>(string sql, DynamicParameters Pram)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var count = await cnn.ExecuteScalarAsync<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return count;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public T QuerySingle<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var Data = cnn.QuerySingle<T>(sql, Pram);

                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public async Task<T> QuerySingleAsync<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var Data = await cnn.QuerySingleAsync<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public T QueryFirstOrDefault<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }

                        var Data = cnn.QueryFirstOrDefault<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }


        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var Data = await cnn.QueryFirstOrDefaultAsync<T>(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public int Execute<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var i = cnn.Execute(sql, Pram);


                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return i;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public async Task<int> ExecuteAsync<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var Cnt = await cnn.ExecuteAsync(sql, Pram);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Cnt;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<int> ExecuteAsyncStoredProcedure<T>(string sql, DynamicParameters Pram)
        {



            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var Cnt = await cnn.ExecuteAsync(sql, Pram, commandType: CommandType.StoredProcedure);

                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Cnt;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }

        public async Task<T> ExecuteScalarAsyncExecuteAsyncStoredProcedure<T>(string sql, DynamicParameters Pram)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var count = await cnn.ExecuteScalarAsync<T>(sql, Pram, commandType: CommandType.StoredProcedure);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return count;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }

        }
        public DataTable DataTableQuery(string sql, DynamicParameters Pram)
        {
            DataTable table = new DataTable();
            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var reader = cnn.ExecuteReader(sql, Pram);
                        table.Load(reader);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return table;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<DataTable> DataTableQueryAsync(string sql, DynamicParameters Pram)
        {
            DataTable table = new DataTable();
            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var reader = await cnn.ExecuteReaderAsync(sql, Pram);
                        table.Load(reader);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return table;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<int> ExecuteAsynModel<T>(string sql, T data)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }
                        var Cnt = await cnn.ExecuteAsync(sql, data);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }
                        return Cnt;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }
        public async Task<IEnumerable<T>> QuerySPAsync<T>(string sql, DynamicParameters Pram)
        {

            try
            {
                using (IDbConnection cnn = new SqlConnection(_config))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                        {
                            cnn.Open();
                        }

                        var Data = await cnn.QueryAsync<T>(sql, Pram, null, commandTimeout: 180, CommandType.StoredProcedure);
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }

                        return Data;
                    }
                    catch (Exception ex)
                    {

                        cnn.Close();
                        cnn.Dispose();

                        _logger.LogError(ex.ToString());

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                throw;
            }
        }


        public void Dispose()
        {
           
            GC.SuppressFinalize(this);


        }



    }
}
