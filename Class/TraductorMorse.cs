using Interface;

namespace Mundo_Morse
{
    public class TraductorMorse : ITraducirAMorse
    {
        public static Dictionary<string, string> MorseDiccionario = new()
        {
            {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
            {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
            {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
            {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
            {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
            {"Z", "--.."},

            {"1", ".----"}, {"2", "..---"}, {"3", "...--"}, {"4", "....-"},
            {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."},
            {"0", "-----"},

            {" ", "/"}, {"!", "-.-.--"}, {"?", "..--.."},

            {"HELLO", ".... . .-.. .-.. ---"}, {"WORLD", ".-- --- .-. .-.. -.."},
            {"SOS", "... --- ..."}, {"CODE", "-.-. --- -.. ."},
            {"MORSE", "-- --- .-. ... ."}, {"CHALLENGE", "-.-. .... .- .-.. .-.. . -. --. ."},
            {"FUN", "..-. ..- -."}, {"LEARN", ".-.. . .- .-. -."},
            {"PROGRAM", ".--. .-. --- --. .-. .- --"}, {"OPEN", "--- .--. . -."},
            {"SOURCE", "... --- ..- .-. -.-. ."}, {"GAME", "--. .- -- ."}
        };

        private static readonly Dictionary<string, string> MorseATexto = MorseDiccionario
            .ToDictionary(x => x.Value, x => x.Key);

        public static string TraducirAMorse(string entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada))
                throw new ArgumentException("La entrada no puede estar vacía.");

            var resultado = new System.Text.StringBuilder();
            foreach (char letra in entrada.ToUpper())
            {
                if (MorseDiccionario.TryGetValue(letra.ToString(), out string? morse))
                    resultado.Append(morse + " ");
                else if (letra == ' ')
                    resultado.Append("/ ");
                else
                    BannerManager.MostrarMensajeError($"Carácter no reconocido: {letra}");
            }

            return resultado.ToString().TrimEnd();
        }

        public static string TraducirDesdeMorse(string morse)
        {
            if (string.IsNullOrWhiteSpace(morse))
                throw new ArgumentException("La entrada Morse no puede estar vacía.");

            var resultado = new System.Text.StringBuilder();
            string[] palabras = morse.Split('/');

            foreach (string palabra in palabras)
            {
                string[] letras = palabra.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string letra in letras)
                {
                    if (MorseATexto.TryGetValue(letra, out string? texto))
                        resultado.Append(texto);
                    else
                        BannerManager.MostrarMensajeError($"Código Morse no reconocido: {letra}");
                }
                resultado.Append(' ');
            }

            return resultado.ToString().TrimEnd();
        }
    }
}
