using EFProject.Data;
using EFProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var post = context.Posts
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .Where(x => x.Id == 1)
                    .ToList();
                foreach(var rows in post)
                {
                    Console.WriteLine(rows.Category.Name);
                }
            }
        }
    }
}
