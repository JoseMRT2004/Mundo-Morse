using Mundo_Morse;

public class TraductorMorse
{
    public static Dictionary<string, string> MorseDiccionario = new Dictionary<string, string>()
    {
        {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
        {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
        {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
        {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
        {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
        {"Z", "--.."},

        {"1", ".----"},{"2", "..---"},{"3", "...--"},{"4", "....-"},
        {"5", "....."},{"6", "-...."},{"7", "--..."},{"8", "---.."},{"9", "----."},
        {"0", "-----"},

        {" ", "/"}, {"!", "-.-.--"}, {"?", "..--.."},

        {"HELLO", ".... . .-.. .-.. ---"}, {"WORLD", ".-- --- .-. .-.. -.."},
        {"SOS", "... --- ..."}, {"CODE", "-.-. --- -.. ."},
        {"MORSE", "-- --- .-. ... ."}, {"CHALLENGE", "-.-. .... .- .-.. .-.. . -. --. ."},
        {"FUN", "..-. ..- -."}, {"LEARN", ".-.. . .- .-. -."},
        {"PROGRAM", ".--. .-. --- --. .-. .- --"}, {"OPEN", "--- .--. . -."},
        {"SOURCE", "... --- ..- .-. -.-. ."}, {"GAME", "--. .- -- ."}
    };

    public static string TraducirAMorse(string entrada)
    {
        string codigo = "";
        foreach (char letra in entrada)
        {
            if (MorseDiccionario.ContainsKey(letra.ToString()))
                codigo += MorseDiccionario[letra.ToString()] + " ";
            else
            {
                FormatBanner.SetFormatBanner("Caracteres no reconocidos intenta con otra palabra", ConsoleColor.DarkRed);
            }
        }
        return codigo;
    }
}