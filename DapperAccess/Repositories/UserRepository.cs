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
    internal class UserRepository : Repository<User>
    {
        public UserRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}
