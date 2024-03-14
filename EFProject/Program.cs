using EFProject.Data;
using EFProject.Models;

namespace EFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new DataContext())
            {
                var tag = new Tag()
                {
                    Name = "ASP.NET",
                    Slug = "aspnet"
                };
                context.Tag
            }
        }
    }
}
