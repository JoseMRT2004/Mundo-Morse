using System;
using System.Threading;

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        MostrarBanner(ArteIntro(), ConsoleColor.Cyan);
        Console.ResetColor();

        MostrarBanner("--- Ingresa tu nombre ---", ConsoleColor.Blue);
        string nombreUsuario = string.Empty;

        while (string.IsNullOrWhiteSpace(nombreUsuario))
        {
            nombreUsuario = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MostrarBanner("Ingresa un nombre válido.", ConsoleColor.Red);
            }
        }

        Console.Clear();
        MostrarMenu();

        string eleccion = Console.ReadKey(true).Key.ToString();

        while (eleccion != "Escape")
        {
            switch (eleccion)
            {
                case "D1":
                    JugarModoTraduccion(nombreUsuario);
                    break;
                case "D2":
                    JugarModoAdivinanza(nombreUsuario);
                    break;
                case "D3":
                    JugarModoSonido(nombreUsuario);
                    break;
                case "D4":
                    JugarModoCarrera(nombreUsuario);
                    break;
                case "D5":
                    JugarModoDesafio(nombreUsuario);
                    break;
                default:
                    MostrarBanner("Opción no válida. Intenta de nuevo.", ConsoleColor.Red);
                    break;
            }

            Console.Clear();
            MostrarMenu();
            eleccion = Console.ReadKey(true).Key.ToString();
        }

        MostrarBanner("Gracias por jugar. ¡Hasta la próxima!", ConsoleColor.Green);
    }
};