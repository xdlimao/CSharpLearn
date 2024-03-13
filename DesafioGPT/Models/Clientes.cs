using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGPT.Models
{
    [Table("[Clientes]")]
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome {  get; set; }
    }
}
