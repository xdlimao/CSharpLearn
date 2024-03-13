using DesafioGPT.Models;
using DesafioGPT.Repositories;

namespace DesafioGPT
{
    internal class Program
    {
        private const string connstring = "Server=localhost,1433;Database=desafiogpt;Integrated Security = SSPI;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var telrepo = new TelefoneRepository();
            telrepo.SetConnection(connstring);
            foreach (var row in telrepo.GetAllTelefones()) { Console.WriteLine($"Nome: {row.Nome}. Telefone: {row.Numero}"); }
        }
    }
}
