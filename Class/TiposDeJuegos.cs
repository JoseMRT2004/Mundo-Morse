
using Interface;

namespace Mundo_Morse
{
  public class ModoDeJuegos
  {
        public static void JugarTraduccion(string nombreUsuario)
        {
            Console.Clear();
          FormatBanner.SetFormatBanner(ArteAscii.GetBannerTraduccion(), ConsoleColor.DarkGreen, false);
          FormatBanner.SetFormatBanner("Ingresa una palabra o frase para traducir: ", ConsoleColor.Blue);

            string entrada;

            do
            {
                entrada = (Console.ReadLine() ?? string.Empty).ToUpper().Trim();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                  FormatBanner.SetFormatBanner("La entrada no puede estar vacía o contener solo espacios. Intenta nuevamente.", ConsoleColor.Red);
                    Thread.Sleep(1500);
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(entrada));

            string codigoMorse = TraductorMorse.TraducirAMorse(entrada);
            SonidoMorse.MostrarTraduccionConSonido(codigoMorse);

      FileTxt.Guarda(entrada, codigoMorse, nombreUsuario);
      FormatBanner.SetFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
      Console.ReadKey();
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------

    public static void JugarAdivinanza(string nombreUsuario)
    {
      Console.Clear();
      FormatBanner.SetFormatBanner(ArteAscii.GetBannerAdivinanza(), ConsoleColor.DarkRed, false);
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string palabraMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

      FormatBanner.SetFormatBanner($"Escucha el sonido Morse y adivina la palabra:");
            SonidoMorse.ReproducirSonidoMorse(palabraMorse);

            Console.Write("Ingresa tu respuesta: ");
            string adivinanza = (Console.ReadLine() ?? string.Empty).ToUpper();

            if (adivinanza == palabraCorrecta)
            {
              FormatBanner.SetFormatBanner("¡Correcto!", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, 10);
            }
            else
            {
              FormatBanner.SetFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
          FormatBanner.SetFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------

    public static void JugarSonido(string nombreUsuario)
    {
      Console.Clear();
      FormatBanner.SetFormatBanner(ArteAscii.GetBannerSonidos(), ConsoleColor.DarkBlue, false);
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string sonidoMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

      FormatBanner.SetFormatBanner($"Escucha el sonido en Morse: {sonidoMorse}", ConsoleColor.DarkYellow);
            SonidoMorse.ReproducirSonidoMorse(sonidoMorse);

            Console.Write("Ingresa la palabra correspondiente: ");
            string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();

            if (respuesta == palabraCorrecta)
            {
              FormatBanner.SetFormatBanner("¡Correcto!", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, 10);
            }
            else
            {
              FormatBanner.SetFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.Red);
            }
          FormatBanner.SetFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkBlue);
            Console.ReadKey();
        }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------

    public static void JugarCarrera(string nombreUsuario)
    {
      Console.Clear();
      FormatBanner.SetFormatBanner(ArteAscii.GetBannerCarrera(), ConsoleColor.DarkGreen, false);
      Console.WriteLine();
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string palabra = entradaAleatoria.Key.ToString();
      string palabraMorse = entradaAleatoria.Value;

          FormatBanner.SetFormatBanner($"Traduce la palabra: {palabra} a Morse lo más rápido posible.");
            DateTime inicio = DateTime.Now;
            string traduccionUsuario = (Console.ReadLine() ?? string.Empty).ToUpper();
            DateTime fin = DateTime.Now;
            double tiempo = (fin - inicio).TotalSeconds;

            if (TraductorMorse.TraducirAMorse(palabra) == traduccionUsuario)
            {
              FormatBanner.SetFormatBanner($"¡Correcto! Tiempo: {tiempo} segundos.");
                ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
            }
            else
            {
              FormatBanner.SetFormatBanner("Incorrecto.", ConsoleColor.DarkRed);
            }

          FormatBanner.SetFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------

    public static void JugarDesafio(string nombreUsuario)
    {
      Console.Clear();
      FormatBanner.SetFormatBanner(ArteAscii.GetBannerDesafio(), ConsoleColor.DarkYellow, false);
      Console.WriteLine();
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string palabraMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

          FormatBanner.SetFormatBanner($"Escucha el sonido Morse y adivina la palabra:", ConsoleColor.DarkBlue);
            SonidoMorse.ReproducirSonidoMorse(palabraMorse);

            DateTime inicio = DateTime.Now;
            string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();
            DateTime fin = DateTime.Now;
            double tiempo = (fin - inicio).TotalSeconds;

            if (respuesta == palabraCorrecta)
            {
              FormatBanner.SetFormatBanner($"¡Correcto! Tiempo: {tiempo} segundos.", ConsoleColor.DarkGreen);
                ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
            }
            else
            {
              FormatBanner.SetFormatBanner($"Incorrecto. La respuesta correcta es: {palabraCorrecta}", ConsoleColor.DarkRed);
              FormatBanner.SetFormatBanner($"Tiempo: {tiempo} segundos.", ConsoleColor.DarkBlue);
            }

          FormatBanner.SetFormatBanner("Presiona cualquier tecla para continuar...", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------

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
            using (StreamWriter escritor = new(ruta, false))
            {
                escritor.WriteLine(puntajeActual);
            }
          FormatBanner.SetFormatBanner($"Puntaje actual: {puntajeActual} puntos.");
        }
    }
}