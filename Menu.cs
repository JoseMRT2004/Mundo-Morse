namespace Mundo_Morse
{
    public static class Menu
    {
        private static int selectedIndex = 0;
        private static readonly string[] options = [
            " • Traducción de Morse 📜",
            " • Adivina la Palabra en Morse ❓",
            " • Juega con Sonidos 🎶",
            " • Carrera de Traducción 🚀",
            " • Desafío de Velocidad ⏱️",
            " • Salir 🔚"
        ];

        // ! Cambia el color del menu Principal 
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

                // ! Actualizar el índice seleccionado según la tecla presionada
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                }

            } while (keyPressed != ConsoleKey.Enter); // ! Esperar a que el usuario presione Enter

            return selectedIndex + 1;
        }

        private static void MostrarOpciones()
        {
            Console.ForegroundColor = colorFondo;
            Console.WriteLine(@"
                                     ╔═════════════════════════════════════════════════════════════════════════════════╗
                                     ║                                                                                 ║
                                                          🌟 --- Mundo Morse - Menú de Juegos --- 🌟                  
                                     ║                                                                                 ║
                                     ╚═════════════════════════════════════════════════════════════════════════════════╝

                                                 ╔═══════════════════════════════════════════════════╗");

            // Mostrar las opciones con flechas
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("                                                            ➡️ ");
                    Console.ForegroundColor = colorSeleccionado;
                }
                else
                {
                    Console.Write("                                                              ");
                    Console.ForegroundColor = colorTexto;
                }

                Console.WriteLine($"{options[i]}");
                Console.ResetColor();
            }
            Console.ForegroundColor = colorFondo;


            Console.WriteLine(@"
                                                  ╚═══════════════════════════════════════════════════╝

                                    ═══════════════════════════════════════════════════════════════════════════════════
                                        💡 Usa las Flechas para Navegar y Enter para Seleccionar 💡
                              ═══════════════════════════════════════════════════════════════════════════════════════════
                                    ");
            Console.ResetColor();
            Console.ResetColor();

        }
    }
}