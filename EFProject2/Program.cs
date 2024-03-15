using EFProject2.Data;
using EFProject2.Models;

namespace EFProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new DataContext();
            //var user = new User
            //{
            //    Bio = "Herl",
            //    Email = "not@yes.com",
            //    Image = "urlls",
            //    Name = "Perrlr",
            //    PasswordHash = "Hasshers",
            //    Slug = "SLuggterman"
            //};

            //context.Users.Add(user);
            var user = context.Users.First();
            context.Posts.Add(new Post 
            {
                Author=user,
                Body="MeuArtt",
                Category=new Category
                {
                    Name="CategoriesBoy",
                    Slug="backkeeerender",
                },
                CreateDate=System.DateTime.Now,
                //LastUpdateDate=
                Slug="slkkgggggerrrr",
                Summary="Summmarrriesssboi",
                //Tags=null,
                Title="MyAtticledizz",
            });
            context.SaveChanges();
        }
    }
}
