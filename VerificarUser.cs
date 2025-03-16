namespace Mundo_Morse
{
    public static class UserValidation
    {
        public static string VerificarNombreUsuario()
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