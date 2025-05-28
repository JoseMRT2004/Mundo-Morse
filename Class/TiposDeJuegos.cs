using Interface;

namespace Mundo_Morse
{
  // \\ ------------------------ Modo Traducción ------------------------ //
  public class ModoTraduccion : IModoDeJuegos
  {
    private readonly IHacerSonido _sonido;

    public ModoTraduccion(IHacerSonido sonido)
    {
      _sonido = sonido;
      _sonido.ConfigurarSonido(800, 0.5); // Configuración por defecto
    }

    public static void Jugar(string nombreUsuario = "")
    {
      Console.Clear();
      BannerManager.MostrarBannerTraduccion();
      BannerManager.MostrarMensajeInfo("Ingresa una palabra o frase para traducir:");

      var sonido = new SonidoConNAudio();
      sonido.ConfigurarSonido(800, 0.5);

      string entrada;

      do
      {
        entrada = (Console.ReadLine() ?? string.Empty).ToUpper().Trim();

        if (string.IsNullOrWhiteSpace(entrada))
        {
          BannerManager.MostrarMensajeError("La entrada no puede estar vacía o contener solo espacios. Intenta nuevamente.");
        }

      } while (string.IsNullOrWhiteSpace(entrada));

      string codigoMorse = TraductorMorse.TraducirAMorse(entrada);
      sonido.ReproducirSonido(codigoMorse);

      FileTxtSave.GuardaModoTradcuccion(entrada, codigoMorse, nombreUsuario);
      // Doc: ↓ Solo descomenta si quieres Guardar en DBs-Modifica-Conexion @\Mundo-Morse\DB\Conexion.cs
      // SqlDbSave.Guarda(entrada, codigoMorse, nombreUsuario); 

      BannerManager.MostrarMensajeInfo("Presiona cualquier tecla para continuar...");
      Console.ReadKey();
    }
  }

  // \\ ------------------------ Modo Adivinanza ------------------------ //
  public class ModoAdivinza : IModoDeJuegos
  {
    private static readonly IHacerSonido _sonido = new SonidoConNAudio();

    public static void Jugar(string nombreUsuario)
    {
      Console.Clear();
      BannerManager.MostrarBannerAdivinaza();
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string palabraMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

      _sonido.ConfigurarSonido(800, 0.5);
      BannerManager.MostrarMensajeInfo("Escucha el sonido Morse y adivina la palabra:");
      _sonido.ReproducirSonido(palabraMorse);

      Console.Write("Ingresa tu respuesta: ");
      string adivinanza = (Console.ReadLine() ?? string.Empty).ToUpper();

      if (adivinanza == palabraCorrecta)
      {
        BannerManager.MostrarBannerExito("¡Correcto!");
        FileTxtActualizarHistorial.ActualizarPuntaje(nombreUsuario, 10);
      }
      else
      {
        BannerManager.MostrarMensajeError($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
      }
      BannerManager.MostrarMensajeInfo("Presiona cualquier tecla para continuar...");
      Console.ReadKey();
    }
  }

  // \\ ------------------------ Modo Sonido ------------------------ //
  public class ModoSonido : IModoDeJuegos
  {
    private static readonly IHacerSonido _sonido = new SonidoConNAudio();

    public static void Jugar(string nombreUsuario)
    {
      Console.Clear();
      BannerManager.MostrarBannerSonido();
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string sonidoMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

      _sonido.ConfigurarSonido(800, 0.5);
      BannerManager.MostrarMensajeInfo($"Escucha el sonido en Morse: {sonidoMorse}");
      _sonido.ReproducirSonido(sonidoMorse);

      Console.Write("Ingresa la palabra correspondiente: ");
      string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();

      if (respuesta == palabraCorrecta)
      {
        BannerManager.MostrarBannerExito("¡Correcto!", ConsoleColor.DarkGreen);
        FileTxtActualizarHistorial.ActualizarPuntaje(nombreUsuario, 10);
      }
      else
      {
        BannerManager.MostrarMensajeError($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
      }
      BannerManager.MostrarMensajeSimple("Presiona cualquier tecla para continuar...");
      Console.ReadKey();
    }
  }

  // \\ ------------------------ Modo Desafío ------------------------ //
  public class ModoDesafio : IModoDeJuegos
  {
    private static readonly IHacerSonido _sonido = new SonidoConNAudio();

    public static void Jugar(string nombreUsuario)
    {
      Console.Clear();
      BannerManager.MostrarBannerDesafio();
      Console.WriteLine();
      Random aleatorio = new();
      var entradaAleatoria = TraductorMorse.MorseDiccionario.ElementAt(aleatorio.Next(TraductorMorse.MorseDiccionario.Count));
      string palabraMorse = entradaAleatoria.Value;
      string palabraCorrecta = entradaAleatoria.Key.ToString();

      _sonido.ConfigurarSonido(800, 0.5);
      BannerManager.MostrarMensajeInfo("Escucha el sonido Morse y adivina la palabra:");
      _sonido.ReproducirSonido(palabraMorse);

      DateTime inicio = DateTime.Now;
      string respuesta = (Console.ReadLine() ?? string.Empty).ToUpper();
      DateTime fin = DateTime.Now;
      double tiempo = (fin - inicio).TotalSeconds;

      if (respuesta == palabraCorrecta)
      {
        BannerManager.MostrarBannerExito($"¡Correcto! Tiempo: {tiempo} segundos.");
        FileTxtActualizarHistorial.ActualizarPuntaje(nombreUsuario, (int)(1000 / tiempo));
      }
      else
      {
        BannerManager.MostrarMensajeError($"Incorrecto. La respuesta correcta es: {palabraCorrecta}");
        BannerManager.MostrarMensajeInfo($"Tiempo: {tiempo} segundos.");
      }

      BannerManager.MostrarMensajeInfo("Presiona cualquier tecla para continuar...");
      Console.ReadKey();
    }
  }
}

