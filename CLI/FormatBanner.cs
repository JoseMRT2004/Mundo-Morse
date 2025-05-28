// Evita usar esta clase directamente, mejor crea un nuevo método en la clase BannerManager.
// Si es un banner con ASCII, créalo en la clase ArteAscii y dale un formato en la clase BannerManager.
// ! Nota: Recomendación: si te resulta más cómodo usar solo la clase FormatBanner, úsala, pero no combines ambos enfoques.

namespace Mundo_Morse
{
    public class FormatBanner
    {
        public static void SetFormatBanner(string mensaje,
                                           ConsoleColor color = ConsoleColor.Blue,
                                           bool conMarco = true,
                                           bool conTiempoDeEspera = false,
                                           int tiempoDeEspera = 1000)
        {
            Console.ForegroundColor = color;

            if (conMarco)
            {
                MostrarConMarco(mensaje);
            }
            else
            {
                MostrarSinMarco(mensaje);
            }

            if (conTiempoDeEspera)
            {
                AplicarTiempoDeEspera(tiempoDeEspera);
            }

            Console.ResetColor();
        }

        // ---------------------------------------------------------------------------------------

        private static void MostrarConMarco(string mensaje)
        {
            mensaje = mensaje.Trim();
            int longitud = mensaje.Length + 5;
            string horizontal = new('─', longitud);

            Console.WriteLine(@$"                                         
                                                         ┌{horizontal}┐
                                                         │  {mensaje}   │
                                                         └{horizontal}┘");
        }

        // ---------------------------------------------------------------------------------------

        private static void MostrarSinMarco(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        // ---------------------------------------------------------------------------------------

        private static void AplicarTiempoDeEspera(int tiempoDeEspera)
        {
            System.Threading.Thread.Sleep(tiempoDeEspera);
        }

        // ---------------------------------------------------------------------------------------

        public static void SetFormatBanner(string mensaje, bool conMarco)
        {
            SetFormatBanner(mensaje, ConsoleColor.Blue, conMarco);
        }

        // ---------------------------------------------------------------------------------------

        public static void SetFormatBanner(string mensaje, ConsoleColor color)
        {
            SetFormatBanner(mensaje, color, true);
        }

        // ---------------------------------------------------------------------------------------

        public static void SetFormatBanner(string mensaje)
        {
            SetFormatBanner(mensaje, ConsoleColor.Blue);
        }
    }
}

// ! Metodo oficial antes, del codigo de arriba
// ! - Estoy buscando como hacer que quede centrado en cualquier terminal

// public static void SetFormatBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue)    
// {
//     mensaje = mensaje.Trim();
//     Console.ForegroundColor = color;
//     int longitud = mensaje.Length + 5;
//     string horizontal = new string('─', longitud);

//     Console.WriteLine(@$"                                         
//                                                         ┌{horizontal}┐
//                                                         │  {mensaje} │
//                                                         └{horizontal}┘");
//     Console.WriteLine(mensaje);

//     Console.ResetColor();
// }