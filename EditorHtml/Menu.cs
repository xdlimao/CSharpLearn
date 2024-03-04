using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorHtml
{
    internal class Menu
    {
        public Menu()
        {
            Show();
            DrawScreen();
            WriteOptions();
            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void DrawScreen()
        {
            const int sizeScreen = 70;

            Console.Write("+");
            for(int i = 0; i < sizeScreen; i++) 
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");

            for (int i = 0; i < 20; i++)
            {
                Console.Write("|");
                for (int o = 0; o < sizeScreen; o++)
                    Console.Write(' ');
                Console.Write("|");
                Console.Write("\n");

            }

            Console.Write("+");
            for (int i = 0; i < sizeScreen; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }

        public void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor de HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("==============");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo Arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }
        public void HandleMenuOption(short option)
        {
            switch(option)
            {
                case 1: new Editor(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: new Menu(); break;
            }
        }
    }
}
