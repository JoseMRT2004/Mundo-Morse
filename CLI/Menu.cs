namespace Mundo_Morse
{
    public static class Menu
    {
        private static int selectedIndex = 0;
        private static readonly string[] options = [
            " • Traducción de Morse 📜",
            " • Adivina la Palabra en Morse ❓",
            " • Juega con Sonidos 🎶",
            " • Desafío de Desafío 💪",
            " • Mostrar Diccionario 📚",
            " • Salir 🔚"
        ];

        private static class MenuStyle
        {
            public const string MarcoSuperior = "╔═════════════════════════════════════════════════════════════════════════════════╗";
            public const string MarcoInferior = "╚═════════════════════════════════════════════════════════════════════════════════╝";
            public const string LineaVacia = "║                                                                                 ║";
            public const string MarcoOpciones = "╔═══════════════════════════════════════════════════╗";
            public const string MarcoOpcionesInferior = "╚═══════════════════════════════════════════════════╝";
            public const string LineaSeparadora = "═══════════════════════════════════════════════════════════════════════════════════";
            public const string FlechaSeleccion = "➡️ ";
            public const string EspaciadoNormal = "  ";
            public const int IndentacionBase = 50;
        }

        private static readonly ConsoleColor colorFondo = ConsoleColor.DarkCyan;
        private static readonly ConsoleColor colorSeleccionado = ConsoleColor.Green;
        private static readonly ConsoleColor colorTexto = ConsoleColor.DarkCyan;

        public static int MostrarMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                MostrarOpciones();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                ActualizarSeleccion(keyPressed);

            } while (keyPressed != ConsoleKey.Enter);

            return selectedIndex + 1;
        }

        private static void ActualizarSeleccion(ConsoleKey keyPressed)
        {
            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
            }
        }

        private static void MostrarOpciones()
        {
            using (new ColorScope(colorFondo))
            {
                MostrarEncabezado();
                MostrarListaOpciones();
                MostrarPieMenu();
            }
        }

        private static void MostrarEncabezado()
        {
            Console.WriteLine($@"
                                     {MenuStyle.MarcoSuperior}
                                     {MenuStyle.LineaVacia}
                                                          🌟 --- Mundo Morse - Menú de Juegos --- 🌟                  
                                     {MenuStyle.LineaVacia}
                                     {MenuStyle.MarcoInferior}

                                                 {MenuStyle.MarcoOpciones}");
        }

        private static void MostrarListaOpciones()
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(new string(' ', MenuStyle.IndentacionBase));
                Console.Write(i == selectedIndex ? MenuStyle.FlechaSeleccion : MenuStyle.EspaciadoNormal);

                using (new ColorScope(i == selectedIndex ? colorSeleccionado : colorTexto))
                {
                    Console.WriteLine(options[i]);
                }
            }
        }

        private static void MostrarPieMenu()
        {
            Console.WriteLine($@"
                                                  {MenuStyle.MarcoOpcionesInferior}

                                    {MenuStyle.LineaSeparadora}
                                        💡 Usa las Flechas para Navegar y Enter para Seleccionar 💡
                              {MenuStyle.LineaSeparadora}
                                    ");
        }
    }

    internal class ColorScope : IDisposable
    {
        public ColorScope(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Dispose()
        {
            Console.ResetColor();
        }
    }
}