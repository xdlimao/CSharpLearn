using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGPT.Repositories
{
    public class Repository <T> where T : class
    {
        protected SqlConnection _connection;

        public void SetConnection (String connection)
        {
            if (connection != null)
            {
                _connection = new SqlConnection (connection);
            }
        }
        public IEnumerable<T> Get()
            => _connection.GetAll<T>();
        public T Get(int id)
            => _connection.Get<T>(id);
        public void Insert(T entity)
            => _connection.Insert(entity);
        public void Delete(int id)
        {
            var entity = _connection.Get<T>(id);
            _connection.Delete(entity);
        }
        public void Update(T entity)
            => _connection.Update(entity);
    }
}
