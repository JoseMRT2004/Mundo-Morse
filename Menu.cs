// * Menu principal del juego contienen, tenerlo aqui facilida su modificacion
// ! Deccidi dejalo apartado por razones de control de versiones asi sabre cuando modifique solo el menu

namespace Mundo_Morse
{
    class Menu
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine(@"
                                    ╔═════════════════════════════════════════════════════════════════════════════════╗
                                    ║                                                                                 ║
                                                        🌟 --- Mundo Morse - Menú de Juegos --- 🌟                  
                                    ║                                                                                 ║
                                    ╚═════════════════════════════════════════════════════════════════════════════════╝

                                                    ╔═══════════════════════════════════════════════════╗
                                                            📜 [1] - Traducción de Morse                    
                                                            ❓ [2] - Adivina la Palabra en Morse                
                                                            🎶 [3] - Juega con Sonidos                          
                                                            🚀 [4] - Carrera de Traducción                      
                                                            ⏱️ [5] - Desafío de Velocidad                       
                                                    ╚═══════════════════════════════════════════════════╝

                                                      ═════════════════════════════════════════════════
                                                       💡 Pulsa el Número de la Opción Deseada 💡
                                                              🔚 Presiona ESC para Salir 🔚
                                                    ═════════════════════════════════════════════════════
                                    ");
        }

    }
};