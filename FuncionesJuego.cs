using NAudio.Wave;
using NAudio.Wave.SampleProviders;

// Doc - Contiene directamente las funciones-(ModosDeJuegos), logica principal  

namespace Mundo_Morse
{
    public class FuncionesJuego
    {
        static Dictionary<string, string> diccionarioMorse = new Dictionary<string, string>()
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

        {" ", "/"}, {"!", "-.-.--"}, {"?", "..--.."},

        {"HELLO", ".... . .-.. .-.. ---"}, {"WORLD", ".-- --- .-. .-.. -.."}, // TODO: 3. Crear un diccionario separados con mas palabras para adivinar
        {"SOS", "... --- ..."}, {"CODE", "-.-. --- -.. ."},
        {"MORSE", "-- --- .-. ... ."}, {"CHALLENGE", "-.-. .... .- .-.. .-.. . -. --. ."},
        {"FUN", "..-. ..- -."}, {"LEARN", ".-.. . .- .-. -."},
        {"PROGRAM", ".--. .-. --- --. .-. .- --"}, {"OPEN", "--- .--. . -."},
        {"SOURCE", "... --- ..- .-. -.-. ."}, {"GAME", "--. .- -- ."}
    };

        public static void jugarTraduccion(string nombreUsuario)
        {
            Console.Clear();
            ArteAscii.setFormatBanner(ArteAscii.getBannerIntro(), ConsoleColor.DarkYellow, false);
            ArteAscii.setFormatBanner("Ingresa una palabra o frase para traducir: ", ConsoleColor.Blue);
            string entrada = (Console.ReadLine() ?? string.Empty).ToUpper(); // Doc - Operarador temario para evitar las entradas nulas convirtiendolas String y Mayusculas

            string codigoMorse = TraducirAMorse(entrada);
            mostrarTraduccionConSonido(codigoMorse);

            GuardarTraduccion(entrada, codigoMorse, nombreUsuario);
            ArteAscii.setFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static string TraducirAMorse(string entrada)
        {
            string codigo = "";
            foreach (char letra in entrada)
            {
                if (diccionarioMorse.ContainsKey(letra.ToString()))
                    codigo += diccionarioMorse[letra.ToString()] + " ";
            }
            return codigo;
        }

        public static void mostrarTraduccionConSonido(string morse)
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

        public static void GuardarTraduccion(string palabra, string morse, string nombreUsuario)
        {
            string ruta = $"{nombreUsuario}_traducciones.txt";
            using (StreamWriter escritor = new StreamWriter(ruta, true))
            {
                escritor.WriteLine($"{palabra} -> {morse}");
            }
            ArteAscii.setFormatBanner($"Traducción guardada en → {ruta}", ConsoleColor.Green);
        }

        public static void jugarAdivinanza(string nombreUsuario)
        {
            Console.Clear();
            ArteAscii.setFormatBanner(ArteAscii.getBannerAdivinanza(), ConsoleColor.DarkRed, false);
            Random aleatorio = new Random();
            var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
            string palabraMorse = entradaAleatoria.Value;
            string palabraCorrecta = entradaAleatoria.Key.ToString();

            ArteAscii.setFormatBanner($"Escucha el sonido Morse y adivina la palabra:");
            ReproducirSonidoMorse(palabraMorse);

            Console.Write("Ingresa tu respuesta: ");
            string adivinanza = (Console.ReadLine() ?? string.Empty).ToUpper();

            if (adivinanza == palabraCorrecta)
            {
                ArteAscii.setFormatBanner("¡Correcto!", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, 10);
            }
            else
            {
                ArteAscii.setFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
            ArteAscii.setFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static void ReproducirSonidoMorse(string morse) // ! Generara el sonido usando el paquete - [ NAudio ]
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

        public static void jugarSonido(string nombreUsuario)
        {
            Console.Clear();
            ArteAscii.setFormatBanner(ArteAscii.getBannerSonidos(), ConsoleColor.DarkBlue, false);
            Random aleatorio = new Random();
            var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
            string sonidoMorse = entradaAleatoria.Value;
            string palabraCorrecta = entradaAleatoria.Key.ToString();

            ArteAscii.setFormatBanner($"Escucha el sonido en Morse: {sonidoMorse}", ConsoleColor.DarkYellow);
            ReproducirSonidoMorse(sonidoMorse);

            Console.Write("Ingresa la palabra correspondiente: ");
            string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();

            if (respuesta == palabraCorrecta)
            {
                ArteAscii.setFormatBanner("¡Correcto!", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, 10);
            }
            else
            {
                ArteAscii.setFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
            ArteAscii.setFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkBlue);
            Console.ReadKey();
        }

        public static void jugarCarrera(string nombreUsuario)
        {
            Console.Clear();
            ArteAscii.setFormatBanner(ArteAscii.getBannerCarrera(), ConsoleColor.DarkGreen, false);
            Console.WriteLine();
            Random aleatorio = new Random();
            var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
            string palabra = entradaAleatoria.Key.ToString();
            string palabraMorse = entradaAleatoria.Value;

            ArteAscii.setFormatBanner($"Traduce la palabra: {palabra} a Morse lo más rápido posible.");
            DateTime inicio = DateTime.Now;
            string traduccionUsuario = (Console.ReadLine() ?? string.Empty).ToUpper();
            DateTime fin = DateTime.Now;
            double tiempo = (fin - inicio).TotalSeconds;

            if (TraducirAMorse(palabra) == traduccionUsuario)
            {
                ArteAscii.setFormatBanner($"¡Correcto! Tiempo: {tiempo} segundos.");
                ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
            }
            else
            {
                ArteAscii.setFormatBanner("Incorrecto.", ConsoleColor.DarkRed);
            }

            ArteAscii.setFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static void jugarDesafio(string nombreUsuario)
        {
            Console.Clear();
            ArteAscii.setFormatBanner(ArteAscii.getBannerDesafio(), ConsoleColor.DarkYellow, false);
            Console.WriteLine();
            Random aleatorio = new Random();
            var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
            string palabraMorse = entradaAleatoria.Value;
            string palabraCorrecta = entradaAleatoria.Key.ToString();

            ArteAscii.setFormatBanner($"Escucha el sonido Morse y adivina la palabra:", ConsoleColor.DarkBlue);
            ReproducirSonidoMorse(palabraMorse);

            DateTime inicio = DateTime.Now;
            string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();
            DateTime fin = DateTime.Now;
            double tiempo = (fin - inicio).TotalSeconds;

            if (respuesta == palabraCorrecta)
            {
                ArteAscii.setFormatBanner($"¡Correcto! Tiempo: {tiempo} segundos.", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
            }
            else
            {
                ArteAscii.setFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.DarkRed);
                ArteAscii.setFormatBanner($"Tiempo: {tiempo} segundos.", ConsoleColor.DarkBlue);
            }

            ArteAscii.setFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static void ActualizarPuntaje(string nombreUsuario, int puntos)
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
            ArteAscii.setFormatBanner($"Puntaje actual: {puntajeActual} puntos.");
        }

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
    }
};