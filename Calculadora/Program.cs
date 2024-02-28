namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }

        double valor1 = 0;
        double valor2 = 0;
        
        void Start()
        {
            Console.WriteLine("Bem-vindo a calculadora de dois elementos, super útil.");

            InserirValores();

            Menu();

        }
        void Menu()
        {
            Console.WriteLine("Selecione uma das opções abaixo para começar a calcular os valores!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Console.WriteLine("O resultado da soma foi: " + Soma(valor1, valor2)); break;
                case 2: Console.WriteLine("O resultado da subtração foi: " + Subtracao(valor1, valor2)); break;
                case 3: Console.WriteLine("O resultado da multiplicação foi: " + Multiplicacao(valor1, valor2)); break;
                case 4: Console.Write("O resultado da divisão foi: " + Divisao(valor1, valor2)); break;
                case 5: System.Environment.Exit(0); break;
                default:; break;
            }
        }
        void InserirValores()
        {
            Console.WriteLine("Qual é o primeiro valor?");
            valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual é o segundo valor?");
            valor2 = double.Parse(Console.ReadLine());
        }

        double Soma(double valor1, double valor2)
        {
            return valor1 + valor2;
        }
        double Subtracao(double valor1, double valor2)
        {
            return valor1 - valor2;
        }
        double Multiplicacao(double valor1, double valor2)
        {
            return valor1 * valor2;
        }
        double Divisao(double valor1, double valor2)
        {
            return valor1 / valor2;
        }
    }
}
