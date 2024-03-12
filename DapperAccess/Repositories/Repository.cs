using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAccess.Repositories
{
    internal class Repository<T> : IDisposable where T : class
    {
        SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> Get() => _connection.GetAll<T>();
        public T Get(int id) => _connection.Get<T>(id);
        public void Insert(T entity) => _connection.Insert(entity);
        public void Delete(int id)
        {
            if (id == 0)
                return;
            var objectmodel = _connection.Get<T>(id);
            _connection.Delete(objectmodel);
        }
        public void Update (T entity) 
            => _connection.Update(entity);

        public void Dispose() { return; }
    }
}
