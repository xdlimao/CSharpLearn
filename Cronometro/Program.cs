namespace Cronometro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.menu();
        }
        void menu()
        {
            Console.Clear();
            Console.WriteLine("Cronometro");
            Console.WriteLine("Digite qual tempo você deseja:");
            Console.WriteLine("xs ou xm, sendo x o número.");
            string parametro = Console.ReadLine().ToLower();

            var tempo = int.Parse(parametro.Substring(0, parametro.Length - 1));
            var tipo = char.Parse(parametro.Substring(parametro.Length - 1, 1));

            if (tipo == 'm')
            {
                timer(tempo * 60);
            } else if (tipo == 's')
            {
                timer(tempo);
            } else
            {
                menu();
            }
        }
        void timer (int tempo)
        {
            int i = 0;
            while (i <= tempo)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(i);
                i++;
            }
            Console.Clear();
            Console.WriteLine("Finalizando cronometro e voltando ao menu");
            Thread.Sleep(3000);
            menu();

        }
    }
}
