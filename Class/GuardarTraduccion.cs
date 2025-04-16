using System.Data.SqlClient;
using Interface;


namespace Mundo_Morse
{
    public class FileTxt : IGuardarTraduccion
    {

        public static void Guarda(string palabra, string morse, string nombreUsuario)
        {
            try
            {
                string ruta = $"{nombreUsuario}_traducciones.txt";
                using (StreamWriter escritor = new(ruta, true))
                {
                    escritor.WriteLine($"{palabra} -> {morse}");
                }
                FormatBanner.SetFormatBanner($"  -> Traducción guardada en → {ruta}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($" -> Error al guardar en un archivo TXT {ex.Message}", ConsoleColor.Red);
            }
        }

        public class SqlServer : IGuardarTraduccion
        {

            public static void Guarda(string palabra, string morse, string nombreUsuario)
            {
                try
                {
                    using SqlConnection conexion = ConexionDB.ObtenerConexion();
                    conexion.Open();

                    string query = @"
                    INSERT INTO HistorialTraducciones 
                    (NombreUsuario, PalabraOriginal, TraduccionMorse)
                    VALUES (@nombreUsuario, @palabra, @morse);";

                    using SqlCommand cmd = new(query, conexion);
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario ?? string.Empty);
                    cmd.Parameters.AddWithValue("@palabra", palabra ?? string.Empty);
                    cmd.Parameters.AddWithValue("@morse", morse ?? string.Empty);

                    cmd.ExecuteNonQuery();

                    FormatBanner.SetFormatBanner("  -> Traducción guardada en la base de datos.", ConsoleColor.Green);
                }
                catch (Exception ex)
                {
                    FormatBanner.SetFormatBanner($" -> Error al guardar en la base de datos: {ex.Message}", ConsoleColor.Red);
                }

            }
        }


    }
}
