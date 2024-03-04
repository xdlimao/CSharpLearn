using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class OtherProgram
    {
        String xd = "xd";
        public int numero {  get { return numero; } set { numero = value; } }

        public int MyProaerty { get; set; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
    class comprimentar
    { 
        public comprimentar(string t)
        {

        }
        protected virtual void comprimento()
        {
            Console.WriteLine("Comprimentando");
        }
    }

    class oi : comprimentar 
    {
        public oi(string t) : base(t)
        {
            
        }
        protected override void comprimento() 
        { 
            Console.WriteLine("Oi"); 
        }
    }



}
