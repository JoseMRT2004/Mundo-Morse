using System;

namespace Mundo_Morse
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(ArteAscii.ArteIntro());
            ArteAscii.MostrarBanner("Ingresa tu nombre", ConsoleColor.Cyan);

            string nombreUsuario = Console.ReadLine() ?? string.Empty;
            Console.Clear();

            bool salir = false;
            while (!salir)
            {
                Menu.MostrarMenu();
                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.D1:
                        FuncionesJuego.JugarModoTraduccion(nombreUsuario);
                        break;
                    case ConsoleKey.D2:
                        FuncionesJuego.JugarModoAdivinanza(nombreUsuario);
                        break;
                    case ConsoleKey.D3:
                        FuncionesJuego.JugarModoSonido(nombreUsuario);
                        break;
                    case ConsoleKey.D4:
                        FuncionesJuego.JugarModoCarrera(nombreUsuario);
                        break;
                    case ConsoleKey.D5:
                        FuncionesJuego.JugarModoDesafio(nombreUsuario);
                        break;
                    case ConsoleKey.Escape:
                        salir = true;
                        break;
                    default:
                        ArteAscii.MostrarBanner("Opción no válida", ConsoleColor.Red);
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
            ArteAscii.MostrarBanner("¡Gracias por jugar! Hasta la próxima 🎉", ConsoleColor.Green);
        }
    }
};