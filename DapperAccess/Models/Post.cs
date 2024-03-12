using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAccess.Models
{
    [Table("[Post]")]
    internal class Post
    {
        public Post(int id, string name, string slug)
        {
            Id = id;
            Name = name;
            Slug = slug;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
