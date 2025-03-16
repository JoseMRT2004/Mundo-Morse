
namespace Mundo_Morse
{

    public static class FormatBanner
    {
        public static void SetFormatBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue, bool conMarco = true) // todo: Good first issue: Has que el los Banner sean dinamicos, que los tamanos se adacten a las terminales 
        {
            Console.ForegroundColor = color;

            if (conMarco)
            {
                mensaje = mensaje.Trim();
                int longitud = mensaje.Length + 5;
                string horizontal = new('─', longitud);

                Console.WriteLine(@$"                                         
                                                                           ┌{horizontal}┐
                                                                           │  {mensaje}   │
                                                                           └{horizontal}┘");
            }
            else
            {
                Console.WriteLine(mensaje);
            }

            Console.ResetColor();
        }
    }
};
// public static void SetFormatBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue) // ! Metodo oficial antes, de la gracita de codigo de arriba 
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