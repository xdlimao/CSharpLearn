using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;Integrated Security=SSPI;TrustServerCertificate=True";
            
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon ASses";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO [Category] VALUES (@id, @titlea, @url, @summary, @order, @description, @featured)";
            using (var connection = new SqlConnection(connectionString))
            {
                var rows = connection.Execute(insertSql, new
                {
                    category.Id,
                    titlea =category.Title,
                    category.Url,
                    category.Description,
                    category.Order,
                    category.Summary,
                    category.Featured
                });
                Console.WriteLine($"Foi inserido ai {rows} nessa bomba");
            }
        }
    }
}
