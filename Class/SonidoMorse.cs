using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Mundo_Morse
{
    public class SonidoMorse
    {
        public static void ReproducirSonidoMorse(string morse)
        {
            foreach (char simbolo in morse)
            {
                if (simbolo == '.')
                {
                    PlayTone(1000, 200);
                    Thread.Sleep(200);
                }
                else if (simbolo == '-')
                {
                    PlayTone(1000, 600);
                    Thread.Sleep(200);
                }
                else if (simbolo == ' ')
                {
                    Thread.Sleep(600);
                }
                else if (simbolo == '/')
                {
                    Thread.Sleep(1200);
                }
            }
        }

        public static void MostrarTraduccionConSonido(string morse)
        {
            Console.Clear();
            foreach (char simbolo in morse)
            {
                if (simbolo == '.')
                {
                    Console.Write(".");
                    PlayTone(1000, 200);
                }
                else if (simbolo == '-')
                {
                    Console.Write("-");
                    PlayTone(1000, 600);
                }
                else if (simbolo == ' ')
                {
                    Console.Write(" ");
                    Thread.Sleep(600);
                }
                else if (simbolo == '/')
                {
                    Console.Write("/");
                    Thread.Sleep(1200);
                }
            }
            Console.WriteLine();
        }

        private static void PlayTone(int frequency, int duration)
        {
            using (var waveOut = new WaveOutEvent())
            {
                var signal = new SignalGenerator()
                {
                    Gain = 0.2,
                    Frequency = frequency,
                    Type = SignalGeneratorType.Sin
                }.Take(TimeSpan.FromMilliseconds(duration));
                waveOut.Init(signal);
                waveOut.Play();
                Thread.Sleep(duration);
            }
        }
    }
}