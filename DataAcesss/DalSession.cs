using System.Data;
using System.Data.SqlClient;
using Helper;
namespace DataAccess
{
    public sealed class DalSession : IDisposable
    {



        private string _config=""+GlobalConnection.ConnectionString;
        IDbConnection _connection=null ;
        UnitOfWork _unitOfWork =null;
        private bool _disposed;
        public DalSession()
        {

            _config = ""+GlobalConnection.ConnectionString;
            _connection = new SqlConnection(_config.Trim());
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
               _unitOfWork.Dispose();
                _connection.Dispose();
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Close();
                        _unitOfWork.Dispose();
                        _connection.Dispose();
                    }
                    
                }
                _disposed = true;
            }
        }
        ~DalSession()
        {
            dispose(false);
        }
    }
}
