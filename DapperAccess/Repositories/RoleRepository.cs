using Dapper.Contrib.Extensions;
using DapperAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAccess.Repositories
{
    internal class RoleRepository : IDisposable
    {
        public RoleRepository(SqlConnection connection)
        {
            this.connection = connection;
        }
        private readonly SqlConnection connection;
        public IEnumerable<Role> Get()
            => connection.GetAll<Role>();
        public Role Get(int id)
            => connection.Get<Role>(id);
        public void Insert(Role user)
            => connection.Insert(user);
        public void Update(Role role)
           => connection.Update(role);
        public void Delete(int id)
        {
            if (id == 0)
                return;

            var role = connection.Get<Role>(id);
            connection.Delete(role);
        }
        public void Dispose() { return; }
    }
}
