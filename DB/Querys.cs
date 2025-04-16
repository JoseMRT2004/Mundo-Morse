using System.Data.SqlClient;

namespace Mundo_Morse
{
    public class Consultas
    {
       
        public static List<string> ObtenerHistorialPorUsuario(string nombreUsuario)
        {
            List<string> historial = new();
            try
            {
                using SqlConnection conexion = ConexionDB.ObtenerConexion();
                conexion.Open();

                string query = @"
                    SELECT PalabraOriginal, TraduccionMorse
                    FROM HistorialTraducciones
                    WHERE NombreUsuario = @nombreUsuario
                    ORDER BY FechaCreacion DESC";

                using SqlCommand cmd = new(query, conexion);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario ?? string.Empty);

                using SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    string palabra = lector.GetString(0);
                    string morse = lector.GetString(1);
                    historial.Add($"{palabra} -> {morse}");
                }
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($"❌ Error al consultar historial: {ex.Message}", ConsoleColor.Red);
            }
            return historial;
        }

       
        public static List<string> BuscarPorPalabra(string palabra)
        {
            List<string> traducciones = new();
            try
            {
                using SqlConnection conexion = ConexionDB.ObtenerConexion();
                conexion.Open();

                string query = @"
                    SELECT NombreUsuario, PalabraOriginal, TraduccionMorse
                    FROM HistorialTraducciones
                    WHERE PalabraOriginal LIKE @palabra
                    ORDER BY FechaCreacion DESC";

                using SqlCommand cmd = new(query, conexion);
                cmd.Parameters.AddWithValue("@palabra", "%" + palabra + "%");

                using SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    string usuario = lector.GetString(0);
                    string palabraOriginal = lector.GetString(1);
                    string morse = lector.GetString(2);
                    traducciones.Add($"{usuario} - {palabraOriginal} -> {morse}");
                }
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($"❌ Error al buscar traducciones: {ex.Message}", ConsoleColor.Red);
            }
            return traducciones;
        }

        
        public static List<string> ObtenerTodasLasTraduccionesRecientes()
        {
            List<string> traducciones = new();
            try
            {
                using SqlConnection conexion = ConexionDB.ObtenerConexion();
                conexion.Open();

                string query = @"
                    SELECT NombreUsuario, PalabraOriginal, TraduccionMorse
                    FROM HistorialTraducciones
                    ORDER BY FechaCreacion DESC
                    TOP 10"; 

                using SqlCommand cmd = new(query, conexion);

                using SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    string usuario = lector.GetString(0);
                    string palabraOriginal = lector.GetString(1);
                    string morse = lector.GetString(2);
                    traducciones.Add($"{usuario} - {palabraOriginal} -> {morse}");
                }
            }
            catch (Exception ex)
            {
                FormatBanner.SetFormatBanner($"❌ Error al obtener traducciones recientes: {ex.Message}", ConsoleColor.Red);
            }
            return traducciones;
        }
    }
}
