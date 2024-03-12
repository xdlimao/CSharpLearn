using System;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            var repositoryuser = new Repository<User>(new SqlConnection(CONNECTION_STRING));
            repositoryuser.Create(new User()
            {
                Name = "Nome",
                Email = "Nome@outlook.com",
                PasswordHash = "Hash",
                Bio = "Pessoa comum",
                Image = "FotoURL",
                Slug = "terraneo",
            });
            var repositoryrole = new Repository<Role>(new SqlConnection(CONNECTION_STRING));
            repositoryrole.Create(new Role()
            {
                Name = "Chefe",
                Slug = "terreneo",
            });
        }

        
        private static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
    }
}