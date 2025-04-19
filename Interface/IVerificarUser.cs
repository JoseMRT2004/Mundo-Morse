using Mundo_Morse;
namespace Interface
{
    public interface IUserValidation
    {
        public static string VerificarNombreUsuario() // ! Esto funciona como Veificacion por defecto, si no se implelemta de forma explisista como hacerlo
        {
            string nombreUsuario;
            do
            {
                FormatBanner.SetFormatBanner(@$"Ingresa tu nombre: ", ConsoleColor.Blue);
                nombreUsuario = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(nombreUsuario) || nombreUsuario.All(char.IsDigit))
                {
                    Console.WriteLine("El nombre no puede estar vacío o contener solo espacios.");
                    Thread.Sleep(1500); // Optional: Delay for user to read the message
                    Console.Clear();
                }
            } while (string.IsNullOrWhiteSpace(nombreUsuario) || nombreUsuario.All(char.IsDigit));

            return nombreUsuario;
        }
    }
}