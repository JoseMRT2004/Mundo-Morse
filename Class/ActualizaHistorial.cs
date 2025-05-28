using Interface;

namespace Mundo_Morse
{

    public class SqlDbActualizarHistorial : IActualizaDato
    {
        // TODO: Aquí va la lógica para actualizar los datos del modo carrera y desafío  en la base de datos
        public void ActualizaDatoModoCarrera() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
        public void ActualizaDatoModoDesafio() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
    }

    public class FileTxtActualizarHistorial : IActualizaDato
    {
        // TODO: Aquí va la lógica para actualizar los datos del modo carrera y desafío  en un archivo TXT
        public void ActualizaDatoModoCarrera() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
        public void ActualizaDatoModoDesafio() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
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
            BannerManager.MostrarMensajeInfo($"Puntaje actual: {puntajeActual} puntos.");
        }
    }

}
