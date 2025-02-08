// TODO: Validar y manejar errores en la entrada de datos (formato, tipos, nulos)
// TODO: Crear README.md con descripción, instalación y ejemplos de uso
// TODO: Centrar mensajes del título del juego (usar CSS o función de centrado)
// TODO: Reemplazar el valor de "string arte" con el título real (Morse - Challenge)


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static Dictionary<string, string> diccionarioMorse = new Dictionary<string, string>() // * FIXME: Separar en diccionarios diferentes 
    {
        {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
        {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
        {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
        {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
        {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
        {"Z", "--.."}, {"1", ".----"},{"2", "..---"},{"3", "...--"},{"4", "....-"},
        {"5", "....."},{"6", "-...."},{"7", "--..."},{"8", "---.."},{"9", "----."},
        {"0", "-----"},{" ", "/"},
        {"HELLO", ".... . .-.. .-.. ---"}, {"WORLD", ".-- --- .-. .-.. -.."},
        {"SOS", "... --- ..."}, {"CODE", "-.-. --- -.. ."},
        {"MORSE", "-- --- .-. ... ."}, {"CHALLENGE", "-.-. .... .- .-.. .-.. . -. --. ."},
        {"FUN", "..-. ..- -."}, {"LEARN", ".-.. . .- .-. -."},
        {"PROGRAM", ".--. .-. --- --. .-. .- --"}, {"OPEN", "--- .--. . -."},
        {"SOURCE", "... --- ..- .-. -.-. ."}, {"GAME", "--. .- -- ."}
    };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Cyan;

        MostrarArteIntro();
        Console.ResetColor();

        MostrarBanner("--- ¡Bienvenido a Mundo Morse! ---");
            MostrarBanner(" --- Ingresa tu nombre ---");
        string nombreUsuario = Console.ReadLine();

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
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            Console.Clear();
            MostrarMenu();
            eleccion = Console.ReadKey(true).Key.ToString();
        }

        MostrarBanner("Gracias por jugar. ¡Hasta la próxima!");
    }

    static void MostrarArteIntro() 
    {
        string arte = @"
                        ██████╗  █████╗ ███╗   ███╗███████╗    ██╗     ██╗███╗   ██╗███████╗
                        ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██║     ██║████╗  ██║██╔════╝
                        ██║  ███╗███████║██╔████╔██║█████╗      ██║     ██║██╔██╗ ██║█████╗  
                        ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║     ██║██║╚██╗██║██╔══╝  
                        ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ███████╗██║██║ ╚████║███████╗
                        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝    ╚══════╝╚═╝╚═╝  ╚═══╝╚══════╝

                                    ███╗   ███╗ ██████╗ ██████╗ ███████╗███████╗
                                    ████╗ ████║██╔═══██╗██╔══██╗██╔════╝██╔════╝
                                    ██╔████╔██║██║   ██║██║  ██║█████╗  ███████╗
                                    ██║╚██╔╝██║██║   ██║██║  ██║██╔══╝  ╚════██║
                                    ██║ ╚═╝ ██║╚██████╔╝██████╔╝███████╗███████║
                                    ╚═╝     ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝╚══════╝                                                                    
                                    ";
        Console.WriteLine(arte);
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@$"
                       ╔══════════════════════════════════════════════════════════════════╗
                       ║                                                                  ║
                       -           ✨ --- Mundo Morse - Menú de Juegos --- ✨            -
                       ║                                                                  ║
                       ╚══════════════════════════════════════════════════════════════════╝

                                ╔══════════════════════════════════════════════╗
                                ║ [1] - Traducir de Morse                      ║
                                ║ [2] - Adivinar la palabra en Morse           ║
                                ║ [3] - Jugar con sonidos                      ║
                                ║ [4] - Carrera de Traducción                  ║
                                ║ [5] - Desafío de Velocidad                   ║
                                ╚══════════════════════════════════════════════╝

                                ═══════════════════════════════════════════════
                                        ---- Pulse el Numero de opcion ----
                                          -- Presiona ESC para salir --
                                ═══════════════════════════════════════════════
");
        Console.ResetColor();
    }

    static void MostrarBanner(string texto)
    {
        int longitud = texto.Length + 5;
        string horizontal = new string('─', longitud);
        Console.WriteLine($"┌{horizontal}┐");
        Console.WriteLine($"│  {texto}   │");
        Console.WriteLine($"└{horizontal}┘");
    }

    static void JugarModoTraduccion(string nombreUsuario)
    {
        MostrarBanner("🚀 MODO DE TRADUCCIÓN 🚀");
        Console.WriteLine();
        Console.Write("Ingresa una palabra o frase para traducir: ");
        string entrada = Console.ReadLine().ToUpper();

        string codigoMorse = TraducirAMorse(entrada);
        MostrarTraduccionConSonido(codigoMorse);

        GuardarTraduccion(entrada, codigoMorse, nombreUsuario);
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static string TraducirAMorse(string entrada)
    {
        string codigo = "";
        foreach (char letra in entrada)
        {
            if (diccionarioMorse.ContainsKey(letra.ToString()))
                codigo += diccionarioMorse[letra.ToString()] + " ";
        }
        return codigo;
    }

    static void MostrarTraduccionConSonido(string morse)
    {
        Console.Clear();
        foreach (char simbolo in morse)
        {
            if (simbolo == '.')
            {
                Console.Beep(1000, 200);
                Console.Write(".");
            }
            else if (simbolo == '-')
            {
                Console.Beep(1000, 600);
                Console.Write("-");
            }
            else if (simbolo == ' ')
            {
                Thread.Sleep(600);
                Console.Write(" ");
            }
            else if (simbolo == '/')
            {
                Thread.Sleep(1200);
                Console.Write("/");
            }
        }
        Console.WriteLine();
    }

    static void GuardarTraduccion(string palabra, string morse, string nombreUsuario)
    {
        string ruta = $"{nombreUsuario}_traducciones.txt";
        using (StreamWriter escritor = new StreamWriter(ruta, true))
        {
            escritor.WriteLine($"{palabra} -> {morse}");
        }
        MostrarBanner($"Traducción guardada en →_→ {ruta}");
    }

    static void JugarModoAdivinanza(string nombreUsuario)
    {
        MostrarBanner("🔮 MODO DE ADIVINANZA 🔮");
        Console.WriteLine();
        Random aleatorio = new Random();
        var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
        string palabraMorse = entradaAleatoria.Value;
        string palabraCorrecta = entradaAleatoria.Key.ToString();

        Console.WriteLine($"Escucha el sonido Morse y adivina la palabra:");
        ReproducirSonidoMorse(palabraMorse);

        Console.Write("Ingresa tu respuesta: ");
        string adivinanza = Console.ReadLine().ToUpper();

        if (adivinanza == palabraCorrecta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Correcto!");
            ActualizarPuntaje(nombreUsuario, 10);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            MostrarBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
        }
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ReproducirSonidoMorse(string morse)
    {
        foreach (char simbolo in morse)
        {
            if (simbolo == '.')
            {
                Console.Beep(1000, 200);
                Thread.Sleep(200);
            }
            else if (simbolo == '-')
            {
                Console.Beep(1000, 600);
                Thread.Sleep(200);
            }
            else if (simbolo == ' ')
            {
                Thread.Sleep(600);
            }
            else if (simbolo == '/')
            {
                Thread.Sleep(1200);
            }
        }
    }

    static void JugarModoSonido(string nombreUsuario)
    {
        MostrarBanner("🎵 MODO DE SONIDO 🎵");
        Console.WriteLine();
        Random aleatorio = new Random();
        var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
        string sonidoMorse = entradaAleatoria.Value;
        string palabraCorrecta = entradaAleatoria.Key.ToString();

        Console.WriteLine($"Escucha el sonido en Morse: {sonidoMorse}");
        ReproducirSonidoMorse(sonidoMorse);

        Console.Write("Ingresa la palabra correspondiente: ");
        string respuesta = Console.ReadLine().ToUpper();

        if (respuesta == palabraCorrecta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Correcto!");
            ActualizarPuntaje(nombreUsuario, 10);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            MostrarBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
        }
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void JugarModoCarrera(string nombreUsuario)
    {
        MostrarBanner("🏁 CARRERA DE TRADUCCIÓN 🏁");
        Console.WriteLine();
        Random aleatorio = new Random();
        var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
        string palabra = entradaAleatoria.Key.ToString();
        string palabraMorse = entradaAleatoria.Value;

        Console.WriteLine($"Traduce la palabra: {palabra} a Morse lo más rápido posible.");
        DateTime inicio = DateTime.Now;
        string traduccionUsuario = Console.ReadLine().ToUpper();
        DateTime fin = DateTime.Now;
        double tiempo = (fin - inicio).TotalSeconds;

        if (TraducirAMorse(palabra) == traduccionUsuario)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡Correcto! Tiempo: {tiempo} segundos.");
            ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrecto.");
        }
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void JugarModoDesafio(string nombreUsuario)
    {
        MostrarBanner("⚡ DESAFÍO DE VELOCIDAD ⚡");
        Console.WriteLine();
        Random aleatorio = new Random();
        var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
        string palabraMorse = entradaAleatoria.Value;
        string palabraCorrecta = entradaAleatoria.Key.ToString();

        Console.WriteLine($"Escucha el sonido Morse y adivina la palabra:");
        ReproducirSonidoMorse(palabraMorse);

        DateTime inicio = DateTime.Now;
        string respuesta = Console.ReadLine().ToUpper();
        DateTime fin = DateTime.Now;
        double tiempo = (fin - inicio).TotalSeconds;

        if (respuesta == palabraCorrecta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡Correcto! Tiempo: {tiempo} segundos.");
            ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
            Console.WriteLine($"Tiempo: {tiempo} segundos.");
        }
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ActualizarPuntaje(string nombreUsuario, int puntos)
    {
        string ruta = $"{nombreUsuario}_puntajes.txt";
        int puntajeActual = 0;
        if (File.Exists(ruta))
        {
            string[] lineas = File.ReadAllLines(ruta);
            if (lineas.Length > 0)
                int.TryParse(lineas[0], out puntajeActual);
        }
        puntajeActual += puntos;
        using (StreamWriter escritor = new StreamWriter(ruta, false))
        {
            escritor.WriteLine(puntajeActual);
        }
        Console.WriteLine($"Puntaje actual: {puntajeActual} puntos.");
    }
}  