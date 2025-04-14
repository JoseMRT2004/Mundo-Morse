namespace Mundo_Morse
{
    public class GuardarTraduccion
    {
        public static void Guardar(string palabra, string morse, string nombreUsuario)
        {
            string ruta = $"{nombreUsuario}_traducciones.txt";
            using (StreamWriter escritor = new(ruta, true))
            {
                escritor.WriteLine($"{palabra} -> {morse}");
            }
          FormatBanner.SetFormatBanner($"Traducción guardada en → {ruta}", ConsoleColor.Green);
        }

        //TODO:  En esta sesio agrega el codigo para aguarsar en  una base de datos de tipo relasional: 
        //TODO:  - Proyectos-24\Mundo-Morse\DB\MundoMorseDB.sql Crea la base de datos

    }
}