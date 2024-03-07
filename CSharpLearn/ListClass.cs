using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class ListClass
    {
        public ListClass()
        {
            var lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Remove(lista[1]);
            Console.WriteLine(lista[1]);
        }
    public class ClasseLegal { }
    }
}
