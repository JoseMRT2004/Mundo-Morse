using Microsoft.Data.SqlClient;
using Interface;


namespace Mundo_Morse
{
    public class FileTxtSave : IGuardarDataModoJuego
    {
        public static void GuardaModoTradcuccion(string palabra, string morse, string nombreUsuario)
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
                BannerManager.MostrarMensajeError($" Error al guardar en un archivo TXT {ex.Message}");
            }
        }

        // Todo: Agregar la logica de cada metodo 
        public void GuardaModoAdivinanza() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoAdivinanza"); }

        public void GuardaModoSonido() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoSonido"); }

        public void GuardaModoCarrera() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoCarrera"); }

        public void GuardaModoDesafio() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }




    }



    // -------------------------------------------------------------------------------------------------------------------------------------



    public class SqlDbSave : IGuardarDataModoJuego
    {

        public static void GuardaModoTradcuccion(string palabra, string morse, string nombreUsuario)
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

                BannerManager.MostrarBannerExito(" Traducción guardada en la base de datos → Sql Server", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                BannerManager.MostrarMensajeError($" {ex.Message}");
            }

        }

        // Todo: Agregar la logica de cada metodo 
        public void GuardaModoAdivinanza() { Console.WriteLine("Ejecutando la función [ Sql ] : GuardaModoAdivinanza"); }

        public void GuardaModoSonido() { Console.WriteLine("Ejecutando la función [ Sql ] : GuardaModoSonido"); }

        public void GuardaModoCarrera() { Console.WriteLine("Ejecutando la función [ Sql ] : GuardaModoCarrera"); }

        public void GuardaModoDesafio() { Console.WriteLine("Ejecutando la función [ Sql ] : GuardaModoDesafio"); }


    }


}

