// Doc: Aquí guardamos los Banner_Reutilizables. 
// Doc - Usa este sitio web para generar los Banners o Títulos: https://fsymbols.com/text-art/  

// TODO: 1. Agregar manejo de errores al introducir el nombre para que no tenga espacios y no esté vacío.  
// TODO: 2. Arreglar los banners que aparecen con un formato distorsionado (pierden forma en la parte superior).  


using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Mundo_Morse
{
    public static class ArteAscii
    {
        public static void SetFormatBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue, bool conMarco = true) // ? Si puedes mejor has un fork, es la solucion mas clara hasta ahora
        {
            mensaje = mensaje.Trim();
            Console.ForegroundColor = color;

            if (conMarco)
            {
                int longitud = mensaje.Length + 5;
                string horizontal = new string('─', longitud);

                Console.WriteLine(@$"                                         
                                                            ┌{horizontal}┐
                                                            │  {mensaje}    │
                                                            └{horizontal}┘");
            }
            else
            {
                Console.WriteLine(mensaje);
            }

            Console.ResetColor();
        }
        // public static void SetFormatBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue) // ! Metodo oficial antes de la solucion de arriba 
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


        public static string getBannerIntro() => $@"


                                        ░██████╗░░█████╗░███╗░░░███╗███████╗░░░░░░███╗░░░███╗░█████╗░██████╗░░██████╗███████╗
                                        ██╔════╝░██╔══██╗████╗░████║██╔════╝░░░░░░████╗░████║██╔══██╗██╔══██╗██╔════╝██╔════╝
                                        ██║░░██╗░███████║██╔████╔██║█████╗░░█████╗██╔████╔██║██║░░██║██████╔╝╚█████╗░█████╗░░
                                        ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░╚════╝██║╚██╔╝██║██║░░██║██╔══██╗░╚═══██╗██╔══╝░░
                                        ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗░░░░░░██║░╚═╝░██║╚█████╔╝██║░░██║██████╔╝███████╗
                                        ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝░░░░░░╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝

                                        █████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗
                                        ╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝";

        public static string getBannerTraduccion() => $@"

   
                                        ███╗░░░███╗░█████╗░██████╗░░█████╗░  ░░░░░░
                                        ████╗░████║██╔══██╗██╔══██╗██╔══██╗  ░░░░░░
                                        ██╔████╔██║██║░░██║██║░░██║██║░░██║  █████╗
                                        ██║╚██╔╝██║██║░░██║██║░░██║██║░░██║  ╚════╝
                                        ██║░╚═╝░██║╚█████╔╝██████╔╝╚█████╔╝  ░░░░░░
                                        ╚═╝░░░░░╚═╝░╚════╝░╚═════╝░░╚════╝░  ░░░░░░

                                        ████████╗██████╗░░█████╗░██████╗░██╗░░░██╗░█████╗░░█████╗░██╗░█████╗░███╗░░██╗
                                        ╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██║░░░██║██╔══██╗██╔══██╗██║██╔══██╗████╗░██║
                                        ░░░██║░░░██████╔╝███████║██║░░██║██║░░░██║██║░░╚═╝██║░░╚═╝██║██║░░██║██╔██╗██║
                                        ░░░██║░░░██╔══██╗██╔══██║██║░░██║██║░░░██║██║░░██╗██║░░██╗██║██║░░██║██║╚████║
                                        ░░░██║░░░██║░░██║██║░░██║██████╔╝╚██████╔╝╚█████╔╝╚█████╔╝██║╚█████╔╝██║░╚███║
                                        ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░░╚═════╝░░╚════╝░░╚════╝░╚═╝░╚════╝░╚═╝░░╚══╝";

        public static string getBannerAdivinanza() => $@"

    
                                        ░█████╗░██████╗░██╗██╗░░░██╗██╗███╗░░██╗░█████╗░  ██╗░░░░░░█████╗░
                                        ██╔══██╗██╔══██╗██║██║░░░██║██║████╗░██║██╔══██╗  ██║░░░░░██╔══██╗
                                        ███████║██║░░██║██║╚██╗░██╔╝██║██╔██╗██║███████║  ██║░░░░░███████║
                                        ██╔══██║██║░░██║██║░╚████╔╝░██║██║╚████║██╔══██║  ██║░░░░░██╔══██║
                                        ██║░░██║██████╔╝██║░░╚██╔╝░░██║██║░╚███║██║░░██║  ███████╗██║░░██║
                                        ╚═╝░░╚═╝╚═════╝░╚═╝░░░╚═╝░░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝  ╚══════╝╚═╝░░╚═╝

                                        ██████╗░░█████╗░██╗░░░░░░█████╗░██████╗░██████╗░░█████╗░  ███████╗███╗░░██╗
                                        ██╔══██╗██╔══██╗██║░░░░░██╔══██╗██╔══██╗██╔══██╗██╔══██╗  ██╔════╝████╗░██║
                                        ██████╔╝███████║██║░░░░░███████║██████╦╝██████╔╝███████║  █████╗░░██╔██╗██║
                                        ██╔═══╝░██╔══██║██║░░░░░██╔══██║██╔══██╗██╔══██╗██╔══██║  ██╔══╝░░██║╚████║
                                        ██║░░░░░██║░░██║███████╗██║░░██║██████╦╝██║░░██║██║░░██║  ███████╗██║░╚███║
                                        ╚═╝░░░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝  ╚══════╝╚═╝░░╚══╝

                                        ███╗░░░███╗░█████╗░██████╗░░██████╗███████╗
                                        ████╗░████║██╔══██╗██╔══██╗██╔════╝██╔════╝
                                        ██╔████╔██║██║░░██║██████╔╝╚█████╗░█████╗░░
                                        ██║╚██╔╝██║██║░░██║██╔══██╗░╚═══██╗██╔══╝░░
                                        ██║░╚═╝░██║╚█████╔╝██║░░██║██████╔╝███████╗
                                        ╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝";

        public static string getBannerSonidos() => $@"

    
                                        ██████╗░███████╗░█████╗░░█████╗░███╗░░██╗░█████╗░░█████╗░██╗███╗░░░███╗██╗███████╗███╗░░██╗████████╗░█████╗░
                                        ██╔══██╗██╔════╝██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██║████╗░████║██║██╔════╝████╗░██║╚══██╔══╝██╔══██╗
                                        ██████╔╝█████╗░░██║░░╚═╝██║░░██║██╔██╗██║██║░░██║██║░░╚═╝██║██╔████╔██║██║█████╗░░██╔██╗██║░░░██║░░░██║░░██║
                                        ██╔══██╗██╔══╝░░██║░░██╗██║░░██║██║╚████║██║░░██║██║░░██╗██║██║╚██╔╝██║██║██╔══╝░░██║╚████║░░░██║░░░██║░░██║
                                        ██║░░██║███████╗╚█████╔╝╚█████╔╝██║░╚███║╚█████╔╝╚█████╔╝██║██║░╚═╝░██║██║███████╗██║░╚███║░░░██║░░░╚█████╔╝
                                        ╚═╝░░╚═╝╚══════╝░╚════╝░░╚════╝░╚═╝░░╚══╝░╚════╝░░╚════╝░╚═╝╚═╝░░░░░╚═╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚════╝░

                                        ██████╗░███████╗  ░██████╗░█████╗░███╗░░██╗██╗██████╗░░█████╗░░██████╗
                                        ██╔══██╗██╔════╝  ██╔════╝██╔══██╗████╗░██║██║██╔══██╗██╔══██╗██╔════╝
                                        ██║░░██║█████╗░░  ╚█████╗░██║░░██║██╔██╗██║██║██║░░██║██║░░██║╚█████╗░
                                        ██║░░██║██╔══╝░░  ░╚═══██╗██║░░██║██║╚████║██║██║░░██║██║░░██║░╚═══██╗
                                        ██████╔╝███████╗  ██████╔╝╚█████╔╝██║░╚███║██║██████╔╝╚█████╔╝██████╔╝
                                        ╚═════╝░╚══════╝  ╚═════╝░░╚════╝░╚═╝░░╚══╝╚═╝╚═════╝░░╚════╝░╚═════╝░";

        public static string getBannerCarrera() => $@"

    
                                        ░█████╗░░█████╗░██████╗░██████╗░███████╗██████╗░░█████╗░  ██████╗░███████╗
                                        ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗  ██╔══██╗██╔════╝
                                        ██║░░╚═╝███████║██████╔╝██████╔╝█████╗░░██████╔╝███████║  ██║░░██║█████╗░░
                                        ██║░░██╗██╔══██║██╔══██╗██╔══██╗██╔══╝░░██╔══██╗██╔══██║  ██║░░██║██╔══╝░░
                                        ╚█████╔╝██║░░██║██║░░██║██║░░██║███████╗██║░░██║██║░░██║  ██████╔╝███████╗
                                        ░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝  ╚═════╝░╚══════╝

                                        ████████╗██████╗░░█████╗░██████╗░██╗░░░██╗░█████╗░░█████╗░██╗░█████╗░███╗░░██╗
                                        ╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██║░░░██║██╔══██╗██╔══██╗██║██╔══██╗████╗░██║
                                        ░░░██║░░░██████╔╝███████║██║░░██║██║░░░██║██║░░╚═╝██║░░╚═╝██║██║░░██║██╔██╗██║
                                        ░░░██║░░░██╔══██╗██╔══██║██║░░██║██║░░░██║██║░░██╗██║░░██╗██║██║░░██║██║╚████║
                                        ░░░██║░░░██║░░██║██║░░██║██████╔╝╚██████╔╝╚█████╔╝╚█████╔╝██║╚█████╔╝██║░╚███║
                                        ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░░╚═════╝░░╚════╝░░╚════╝░╚═╝░╚════╝░╚═╝░░╚══╝

                                        ██████╗░░█████╗░██████╗░██╗██████╗░░█████╗░
                                        ██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗██╔══██╗
                                        ██████╔╝███████║██████╔╝██║██║░░██║███████║
                                        ██╔══██╗██╔══██║██╔═══╝░██║██║░░██║██╔══██║
                                        ██║░░██║██║░░██║██║░░░░░██║██████╔╝██║░░██║
                                        ╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═════╝░╚═╝░░╚═╝";


        public static string getBannerDesafio() => $@"

    
                                        ██████╗░███████╗░██████╗░█████╗░███████╗██╗░█████╗░  ██████╗░███████╗
                                        ██╔══██╗██╔════╝██╔════╝██╔══██╗██╔════╝██║██╔══██╗  ██╔══██╗██╔════╝
                                        ██║░░██║█████╗░░╚█████╗░███████║█████╗░░██║██║░░██║  ██║░░██║█████╗░░
                                        ██║░░██║██╔══╝░░░╚═══██╗██╔══██║██╔══╝░░██║██║░░██║  ██║░░██║██╔══╝░░
                                        ██████╔╝███████╗██████╔╝██║░░██║██║░░░░░██║╚█████╔╝  ██████╔╝███████╗
                                        ╚═════╝░╚══════╝╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝░╚════╝░  ╚═════╝░╚══════╝

                                        ██╗░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░██╗██████╗░░█████╗░██████╗░
                                        ██║░░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗██║██╔══██╗██╔══██╗██╔══██╗
                                        ╚██╗░██╔╝█████╗░░██║░░░░░██║░░██║██║░░╚═╝██║██║░░██║███████║██║░░██║
                                        ░╚████╔╝░██╔══╝░░██║░░░░░██║░░██║██║░░██╗██║██║░░██║██╔══██║██║░░██║
                                        ░░╚██╔╝░░███████╗███████╗╚█████╔╝╚█████╔╝██║██████╔╝██║░░██║██████╔╝
                                        ░░░╚═╝░░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░

                                        ███████╗██╗░░██╗████████╗██████╗░███████╗███╗░░░███╗░█████╗░
                                        ██╔════╝╚██╗██╔╝╚══██╔══╝██╔══██╗██╔════╝████╗░████║██╔══██╗
                                        █████╗░░░╚███╔╝░░░░██║░░░██████╔╝█████╗░░██╔████╔██║███████║
                                        ██╔══╝░░░██╔██╗░░░░██║░░░██╔══██╗██╔══╝░░██║╚██╔╝██║██╔══██║
                                        ███████╗██╔╝╚██╗░░░██║░░░██║░░██║███████╗██║░╚═╝░██║██║░░██║
                                        ╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝";


    }
};