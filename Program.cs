// Doc: Archivo principal del programa. Gestiona el menú y la navegación entre los modos de juego.

using Interface;

namespace Mundo_Morse
{
    public class Program : IUserValidation
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Doc: Configura la terminal para soportar caracteres especiales (tildes, símbolos, etc.)

            BannerManager.MostrarIntro();
            string nombreUsuario = IUserValidation.VerificarNombreUsuario(); // Doc: Esta usando la implementacion que tiene por defecto para verificar el User 

            bool salir = false;
            while (!salir)
            {
                int opcion = Menu.MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        ModoTraduccion.Jugar(nombreUsuario);
                        break;
                    case 2:
                        ModoAdivinza.Jugar(nombreUsuario);
                        break;
                    case 3:
                        ModoSonido.Jugar(nombreUsuario);
                        break;
                    case 4:
                        ModoDesafio.Jugar(nombreUsuario);
                        break;
                    case 5:
                        salir = BannerManager.MostrarDiccionario();
                        break;
                    case 6:
                        salir = true;
                        break;
                    default:
                        BannerManager.MostrarMensajeError("Opción no válida");
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
            FormatBanner.SetFormatBanner("¡Gracias por jugar! Hasta la próxima", ConsoleColor.Green);
        }
    }
};