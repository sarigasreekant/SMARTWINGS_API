using System.Data;

namespace DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        IDbConnection _connection = null;
        IDbTransaction _transaction = null;
        Guid _id = Guid.Empty;
        private bool _disposed;
        public UnitOfWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }
        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }
        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }
        Guid IUnitOfWork.Id
        {
            get { return _id; }
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
          
          

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                Dispose();
                throw;
            }
            finally
            {
                Dispose();

            }
        }
        

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
           
            dispose(true);
            GC.SuppressFinalize(this);
        }
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }

    }
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

