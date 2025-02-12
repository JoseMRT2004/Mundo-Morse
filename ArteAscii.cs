// * Aqui Guardamos los Banner_Reutilizables o Modificables 
// ! - Use este sitio wed para generear los Banners o Tiulos: https://fsymbols.com/text-art/

using System;

public class ArteAscii
{
    static void MostrarBanner(string mensaje, ConsoleColor color = ConsoleColor.Blue)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(@$"{mensaje}");
        Console.ResetColor();
    }
    static string ArteIntro() => $@"
                                ░██████╗░░█████╗░███╗░░░███╗███████╗░░░░░░███╗░░░███╗░█████╗░██████╗░░██████╗███████╗
                                ██╔════╝░██╔══██╗████╗░████║██╔════╝░░░░░░████╗░████║██╔══██╗██╔══██╗██╔════╝██╔════╝
                                ██║░░██╗░███████║██╔████╔██║█████╗░░█████╗██╔████╔██║██║░░██║██████╔╝╚█████╗░█████╗░░
                                ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░╚════╝██║╚██╔╝██║██║░░██║██╔══██╗░╚═══██╗██╔══╝░░
                                ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗░░░░░░██║░╚═╝░██║╚█████╔╝██║░░██║██████╔╝███████╗
                                ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝░░░░░░╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝

                                █████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗
                                ╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝";


    static string ArteModoTraduccion() => $@"
   
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

    static string ArteModoAdivinanza() => $@"
    
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

    static string ArteModoSonidos() => $@"
    
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

    static string ArteModoCarrera() => $@"
    
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

    static string ArteModoDesafio() => $@"
    
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

};