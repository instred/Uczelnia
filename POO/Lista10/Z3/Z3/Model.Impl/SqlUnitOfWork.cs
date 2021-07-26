using System.Data.SqlClient;

namespace Z3.Model.Impl
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _conn;

        public SqlUnitOfWork( string connectionString )
        {
            _conn = new SqlConnection(connectionString);
            _conn.Open();
        }

        private IPersonRepository _person;
        public IPersonRepository Person => _person ??= new SqlPersonRepository(_conn);

        public void Dispose()
        {
            _conn?.Dispose();
        }
    }
}
