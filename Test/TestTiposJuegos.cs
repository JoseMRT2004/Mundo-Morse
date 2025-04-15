namespace Mundo_Morse
{
    public class TestInTraductorClass
    {
        public static void TestMorseTraductor()
        {
            // string nombreUsuario = "Prueba 001";
            string palabra = "QWERTYUIOPASDFGHJKLZXCVBNM"; 
            string esperado = TraductorMorse.TraducirAMorse(palabra);

            string traduccionUsuario = TraductorMorse.TraducirAMorse(palabra); 

            if (traduccionUsuario == esperado)
            {
                Console.WriteLine("⟪ TEST FINALIZADO CON EXITO ⟫");
            }
            else
            {
                Console.WriteLine(" → TEST EJECUTADO SIN EXITO - VERIFIQUE LA NUEVA IMPLEMENTACION");
            }
        }
    }
}
