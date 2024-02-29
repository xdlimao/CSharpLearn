namespace CSharpLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? texto = "";
            Console.WriteLine("Teste de ESC");
            while (true) {
                texto += Console.ReadLine();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    Console.WriteLine("Aapertou ESC");
            };
        }
    }
}
