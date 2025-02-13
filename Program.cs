// TODO: Validar y manejar errores en la entrada de datos (formato, tipos, nulos)


using System;
using NAudio.Wave;
using System.Threading;
using NAudio.Wave.SampleProviders;
class Program
{
    static void PlayTone(int frequency, int duration)
    {
        using (var waveOut = new WaveOutEvent())
        {
            var signal = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = frequency,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(duration));
            waveOut.Init(signal);
            waveOut.Play();
            Thread.Sleep(duration);
        }
    }
    static Dictionary<string, string> diccionarioMorse = new Dictionary<string, string>() // * FIXME: Separar en diccionarios diferentes 
    {
        {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
        {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
        {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
        {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
        {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
        {"Z", "--.."},

        {"1", ".----"},{"2", "..---"},{"3", "...--"},{"4", "....-"},
        {"5", "....."},{"6", "-...."},{"7", "--..."},{"8", "---.."},{"9", "----."},
        {"0", "-----"},

        {" ", "/"},

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


        MostrarBanner(" --- Ingresa tu nombre ---");
        string nombreUsuario = Console.ReadLine() ?? string.Empty;

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
        string arte = $@"
                                        
                                    ░██████╗░░█████╗░███╗░░░███╗███████╗░░░░░░███╗░░░███╗░█████╗░██████╗░░██████╗███████╗
                                    ██╔════╝░██╔══██╗████╗░████║██╔════╝░░░░░░████╗░████║██╔══██╗██╔══██╗██╔════╝██╔════╝
                                    ██║░░██╗░███████║██╔████╔██║█████╗░░█████╗██╔████╔██║██║░░██║██████╔╝╚█████╗░█████╗░░
                                    ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░╚════╝██║╚██╔╝██║██║░░██║██╔══██╗░╚═══██╗██╔══╝░░
                                    ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗░░░░░░██║░╚═╝░██║╚█████╔╝██║░░██║██████╔╝███████╗
                                    ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝░░░░░░╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝

                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                                    █████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗
                                    ╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝
                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";
        Console.WriteLine(arte);
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@$"
                                    ╔═════════════════════════════════════════════════════════════════════════════════╗
                                    ║                                                                                 ║
                                                        🌟 --- Mundo Morse - Menú de Juegos --- 🌟                  
                                    ║                                                                                 ║
                                    ╚═════════════════════════════════════════════════════════════════════════════════╝

                                                ╔═══════════════════════════════════════════════════╗
                                                        📜 [1] - Traducción de Morse                   
                                                        ❓ [2] - Adivina la Palabra en Morse                
                                                        🎶 [3] - Juega con Sonidos                         
                                                        🚀 [4] - Carrera de Traducción                     
                                                        ⏱️ [5] - Desafío de Velocidad                     
                                                ╚═══════════════════════════════════════════════════╝

                                                    ═══════════════════════════════════════════
                                                    💡 Pulsa el Número de la Opción Deseada 💡
                                                            🔚 Presiona ESC para Salir 🔚
                                                 ═══════════════════════════════════════════════════

                                    ");
        Console.ResetColor();
    }

    static void MostrarBanner(string texto) // ! Eliminar est funcion y usar [https://fsymbols.com/text-art/] 
                                            // ! - Para generar los banner trata de guardarlos en un array o en un archivo diferente para mejor calridad
    {
        int longitud = texto.Length + 5;
        string horizontal = new string('─', longitud);
        Console.WriteLine($"                                           ┌{horizontal}┐");
        Console.WriteLine($"                                           │  {texto}   │");
        Console.WriteLine($"                                           └{horizontal}┘");
    }

    static void JugarModoTraduccion(string nombreUsuario)
    {
        MostrarBanner("🚀 MODO DE TRADUCCIÓN 🚀");
        Console.WriteLine();
        Console.Write("Ingresa una palabra o frase para traducir: ");
        string entrada = (Console.ReadLine() ?? string.Empty).ToUpper();

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
                Console.Write(".");
                PlayTone(1000, 200);
            }
            else if (simbolo == '-')
            {
                Console.Write("-");
                PlayTone(1000, 600);
            }
            else if (simbolo == ' ')
            {
                Console.Write(" ");
                Thread.Sleep(600);
            }
            else if (simbolo == '/')
            {
                Console.Write("/");
                Thread.Sleep(1200);
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
        MostrarBanner($"Traducción guardada en → {ruta}");
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
        string adivinanza = (Console.ReadLine() ?? string.Empty).ToUpper();

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
                PlayTone(1000, 200);
                Thread.Sleep(200);
            }
            else if (simbolo == '-')
            {
                PlayTone(1000, 600);
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
        string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();

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
        string traduccionUsuario = (Console.ReadLine() ?? string.Empty).ToUpper();
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
        string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();
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