using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;
using DapperAccess.Models;

namespace DapperAccess
{
    class Program
    {
        private const string connstring = "Server=localhost,1433;Database=Blog;Integrated Security = SSPI;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(connstring))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users) 
                { 
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}
