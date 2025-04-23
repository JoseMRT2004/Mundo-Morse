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
    }

}
