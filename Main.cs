using System;

namespace Mundo_Morse
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Doc - Dependencia para los fomatos y colores en la terminal

            ArteAscii.setFormatBanner(ArteAscii.getBannerIntro(), ConsoleColor.DarkRed, false);

            string nombreUsuario = FuncionesJuego.verificarNombreUser();


            bool salir = false;
            while (!salir)
            {
                Menu.getBannerMenu(ConsoleColor.DarkCyan);
                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.D1:
                        FuncionesJuego.jugarTraduccion(nombreUsuario);
                        break;
                    case ConsoleKey.D2:
                        FuncionesJuego.jugarAdivinanza(nombreUsuario);
                        break;
                    case ConsoleKey.D3:
                        FuncionesJuego.jugarSonido(nombreUsuario);
                        break;
                    case ConsoleKey.D4:
                        FuncionesJuego.jugarCarrera(nombreUsuario);
                        break;
                    case ConsoleKey.D5:
                        FuncionesJuego.jugarDesafio(nombreUsuario);
                        break;
                    case ConsoleKey.Escape:
                        salir = true;
                        break;
                    default:
                        ArteAscii.setFormatBanner("Opción no válida", ConsoleColor.Red);
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
            ArteAscii.setFormatBanner("¡Gracias por jugar! Hasta la próxima", ConsoleColor.Green);
        }
    }
};