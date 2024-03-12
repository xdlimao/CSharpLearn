using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;
using DapperAccess.Models;
using System.Net.NetworkInformation;
using DapperAccess.Repositories;

namespace DapperAccess
{
    class Program
    {
        private const string connstring = "Server=localhost,1433;Database=balta;Integrated Security = SSPI;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            /*
            using (var repository = new Repository<User>(new SqlConnection(connstring)))
            {
                foreach (var row in repository.Get())
                {
                    Console.WriteLine(row.Name);
                }
            }*/
            var sqlconnect = new SqlConnection(connstring);
            sqlconnect.Open();
            var query = @"select * from career";
            var rows = sqlconnect.Query(query);
            foreach ( var row in rows )
            {
                Console.WriteLine(row);
            }
        }
    }
}
