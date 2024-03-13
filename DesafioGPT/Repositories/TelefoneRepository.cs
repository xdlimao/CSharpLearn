using Dapper;
using Dapper.Contrib.Extensions;
using DesafioGPT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGPT.Repositories
{
    public class TelefoneRepository : Repository<Telefones>
    {

        public void Insert(Telefones telefone)
        {
            _connection.Insert(telefone);
        }
        public IEnumerable<ClienteTelefone> GetAllTelefones()
        {
            var query = @"  SELECT
                            [Clientes].[Nome] as Nome,
                            [Telefones].[Numero] as Numero
                            FROM
                            [Clientes] inner join [Telefones]
                            ON [Clientes].[Id] = [Telefones].[ClienteId]
                         ";

            var entities = _connection.Query<ClienteTelefone>(query);
            return entities;
        }
    }
    public class ClienteTelefone
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
    }
}
