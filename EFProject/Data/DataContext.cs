using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts{ get; set; }
        //public DbSet<PostTag> PostTags{ get; set; }
        //public DbSet<Role> Roles{ get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<User> Users{ get; set; }
        //public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<Teste> Testes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Blog;Integrated Security = SSPI;TrustServerCertificate=True");
        }
    }
}
