using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGPT.Models
{
    [Table("[Telefones]")]
    public class Telefones
    {
        public int Id { get; set; }
        public int Numero {  get; set; }
        public int ClienteId { get; set; }
    }
}
