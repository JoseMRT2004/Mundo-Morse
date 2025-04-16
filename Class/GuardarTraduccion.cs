using System.Data.SqlClient;
using Interface;


namespace Mundo_Morse
{
    public class FileTxtSave : IGuardarTraduccion
    {

        public static void Guarda(string palabra, string morse, string nombreUsuario)
        {
            try
            {
                string horaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string ruta = $"{nombreUsuario}-traducciones.txt";
                using (StreamWriter escritor = new(ruta, true))
                {
                    escritor.WriteLine($@"
                    -----------------------
                    Nombre: {nombreUsuario}
                    {palabra} -> {morse} 
                    - [{horaActual}]
                    -----------------------");
                }
                FormatBanner.SetFormatBanner($" Traducción guardada en → {ruta}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($" Error al guardar en un archivo TXT {ex.Message}", ConsoleColor.Red);
            }
        }
    }


    // -------------------------------------------------------------------------------------------------------------------------------------


    public class SqlDbSave : IGuardarTraduccion
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

                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@palabra", palabra);
                cmd.Parameters.AddWithValue("@morse", morse);

                cmd.ExecuteNonQuery();

                FormatBanner.SetFormatBanner(" Traducción guardada en la base de datos → Sql Server", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($" {ex.Message}", ConsoleColor.Red, false);
            }

        }
    }


}

