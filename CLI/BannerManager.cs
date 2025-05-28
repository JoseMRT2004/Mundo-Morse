/*
BannerManager:
- MostrarIntro: Muestra el banner de introducción en color cian sin borde.
- MostrarBannerTraduccion: Muestra el banner de traducción en color verde sin borde.
- MostrarMensajeInfo: Muestra un mensaje informativo con un borde amarillo.
- MostrarMensajeError: Muestra un mensaje de error con un borde rojo.
- MostrarMensajeSimple: Muestra un mensaje simple en color blanco sin borde.
*/


namespace Mundo_Morse
{
    public static class BannerManager
    {
        public static void MostrarIntro()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Intro), ConsoleColor.Cyan, false);
        }

        public static void MostrarBannerTraduccion()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Traduccion), ConsoleColor.Green, false);
        }

        public static void MostrarBannerAdivinaza()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Adivinanza), ConsoleColor.Green, false);
        }

        public static void MostrarBannerSonido()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Sonidos), ConsoleColor.Green, false);
        }

        public static void MostrarBannerCarrera()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Carrera), ConsoleColor.Green, false);
        }

        public static void MostrarBannerDesafio()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.Desafio), ConsoleColor.Green, false);
        }

        public static bool MostrarDiccionario()
        {
            FormatBanner.SetFormatBanner(ArteAscii.GetBanner(BannerType.DiccionarioMorse), ConsoleColor.DarkYellow, false, true, 1200);

            FormatBanner.SetFormatBanner("Presiona cualquier tecla para volver al menú o 'E' para salir.", ConsoleColor.DarkYellow);
            var key = Console.ReadKey(intercept: true);

            return key.Key == ConsoleKey.E;  // ! Incluir esto en La class FormattBanner esto no deveria estar aqui
        }

        public static void MostrarMensajeInfo(string mensaje)
        {
            FormatBanner.SetFormatBanner(mensaje, ConsoleColor.Yellow, true);
        }

        public static void MostrarMensajeError(string mensaje)
        {
            FormatBanner.SetFormatBanner(mensaje, ConsoleColor.Red, true);
        }

        public static void MostrarMensajeSimple(string mensaje)
        {
            FormatBanner.SetFormatBanner(mensaje, ConsoleColor.White, true, true);
        }

        public static void MostrarBannerExito(string mensaje, ConsoleColor color = ConsoleColor.DarkGreen)
        {
            FormatBanner.SetFormatBanner(mensaje, color, true);
        }
    }
}
