using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EditorHtml
{
    internal class Viewer
    {
        public Viewer(string file) {
            Show(file);
        }
        public void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("----------------------------------------------------------------------------");
            Replace(text);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ReadKey();
            new Menu();
        }
        public void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');
            for(var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(
                        words[i].Substring
                            (
                                words[i].IndexOf('>') + 1,
                                ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                            )
                        );
                    Console.WriteLine(" ");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.WriteLine(" ");
                }
            }
        }
    }
}

