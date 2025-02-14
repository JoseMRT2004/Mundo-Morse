using NAudio.Wave;
using NAudio.Wave.SampleProviders;

// ! Contiene directamente las funciones-(Modos-de-Juego), logica principal  

namespace Mundo_Morse
{
    class FuncionesJuego
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

        {" ", "/"},

        {"HELLO", ".... . .-.. .-.. ---"}, {"WORLD", ".-- --- .-. .-.. -.."},
        {"SOS", "... --- ..."}, {"CODE", "-.-. --- -.. ."},
        {"MORSE", "-- --- .-. ... ."}, {"CHALLENGE", "-.-. .... .- .-.. .-.. . -. --. ."},
        {"FUN", "..-. ..- -."}, {"LEARN", ".-.. . .- .-. -."},
        {"PROGRAM", ".--. .-. --- --. .-. .- --"}, {"OPEN", "--- .--. . -."},
        {"SOURCE", "... --- ..- .-. -.-. ."}, {"GAME", "--. .- -- ."}
    };

        public static void JugarModoTraduccion(string nombreUsuario)
        {
            Console.Clear();
            Console.WriteLine(ArteAscii.ArteModoTraduccion());
            Console.Write("Ingresa una palabra o frase para traducir: ");
            string entrada = (Console.ReadLine() ?? string.Empty).ToUpper(); // ! Operarador temario para evitar las entradas nulas convirtiendolas String y Mayusculas

            string codigoMorse = TraducirAMorse(entrada);
            MostrarTraduccionConSonido(codigoMorse);

            GuardarTraduccion(entrada, codigoMorse, nombreUsuario);
            ArteAscii.MostrarBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
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

        public static void MostrarTraduccionConSonido(string morse)
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
            ArteAscii.MostrarBanner($"Traducción guardada en → {ruta}", ConsoleColor.Blue);
        }

        public static void JugarModoAdivinanza(string nombreUsuario)
        {
            Console.Clear();
            Console.WriteLine(ArteAscii.ArteModoAdivinanza());
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
                ArteAscii.MostrarBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
            ArteAscii.MostrarBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static void ReproducirSonidoMorse(string morse) // * Generara el sonido usando el paquete [ NAudio ]
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

        public static void JugarModoSonido(string nombreUsuario)
        {
            Console.Clear();
            Console.WriteLine(ArteAscii.ArteModoSonidos());
            Random aleatorio = new Random();
            var entradaAleatoria = diccionarioMorse.ElementAt(aleatorio.Next(diccionarioMorse.Count));
            string sonidoMorse = entradaAleatoria.Value;
            string palabraCorrecta = entradaAleatoria.Key.ToString();

            ArteAscii.MostrarBanner($"Escucha el sonido en Morse: {sonidoMorse}", ConsoleColor.DarkYellow);
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
                ArteAscii.MostrarBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
            ArteAscii.MostrarBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkBlue);
            Console.ReadKey();
        }

        public static void JugarModoCarrera(string nombreUsuario)
        {
            Console.Clear();
            Console.WriteLine(ArteAscii.ArteModoCarrera());
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
            ArteAscii.MostrarBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public static void JugarModoDesafio(string nombreUsuario)
        {
            Console.Clear();
            Console.WriteLine(ArteAscii.ArteModoDesafio());
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
            ArteAscii.MostrarBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
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
            Console.WriteLine($"Puntaje actual: {puntajeActual} puntos.");
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