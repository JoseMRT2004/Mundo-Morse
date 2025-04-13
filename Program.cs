// Doc: Archivo principal del programa. Gestiona el menú y la navegación entre los modos de juego.

using Mundo_Morse.Interface;

namespace Mundo_Morse
{
    public class Program : IUserValidation
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Doc: Configura la terminal para soportar caracteres especiales (tildes, símbolos, etc.)

            FormatBanner.SetFormatBanner(ArteAscii.GetBannerIntro(), ConsoleColor.DarkRed, false);

            string nombreUsuario = IUserValidation.VerificarNombreUsuario();

            bool salir = false;
            while (!salir)
            {
                int opcion = Menu.MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        ModoDeJuegos.JugarTraduccion(nombreUsuario);
                        break;
                    case 2:
                        ModoDeJuegos.JugarAdivinanza(nombreUsuario);
                        break;
                    case 3:
                        ModoDeJuegos.JugarSonido(nombreUsuario);
                        break;
                    case 4:
                        ModoDeJuegos.JugarCarrera(nombreUsuario);
                        break;
                    case 5:
                        ModoDeJuegos.JugarDesafio(nombreUsuario);
                        break;
                    case 6:
                        salir = true;
                        break;
                    default:
                        FormatBanner.SetFormatBanner("Opción no válida", ConsoleColor.Red);
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
            FormatBanner.SetFormatBanner("¡Gracias por jugar! Hasta la próxima", ConsoleColor.Green);
        }
    }
};