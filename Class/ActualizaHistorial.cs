using Interface;

namespace Mundo_Morse
{

    public class SqlDbActualizarHistorial : IActualizaDato
    {


        public void ActualizaDatoModoCarrera() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
        public void ActualizaDatoModoDesafio() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }

    }



    public class FileTxtActualizarHistorial : IActualizaDato
    {


        public void ActualizaDatoModoCarrera() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
        public void ActualizaDatoModoDesafio() { Console.WriteLine("Ejecutando la función [ TXT ] : GuardaModoDesafio"); }
    }



}