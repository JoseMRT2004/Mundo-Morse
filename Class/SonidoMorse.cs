using Interface;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Mundo_Morse
{
    public class SonidoConNAudio : IHacerSonido
    {
        private int _frecuencia;
        private double _volumen;

        public void ConfigurarSonido(int frecuencia, double volumen)
        {
            _frecuencia = frecuencia;
            _volumen = Math.Clamp(volumen, 0.0, 1.0);
        }

        public void ReproducirSonido(string morse)
        {
            if (string.IsNullOrWhiteSpace(morse))
                return;

            Console.Clear();
            foreach (char simbolo in morse)
            {
                Console.Write(simbolo);
                ReproducirSimboloMorse(simbolo);
            }
            Console.WriteLine();
        }

        private void ReproducirSimboloMorse(char simbolo)
        {
            switch (simbolo)
            {
                case '.':
                    GenerarTono(_frecuencia, 200);
                    Thread.Sleep(200);
                    break;
                case '-':
                    GenerarTono(_frecuencia, 600);
                    Thread.Sleep(200);
                    break;
                case ' ':
                    Thread.Sleep(600);
                    break;
                case '/':
                    Thread.Sleep(1200);
                    break;
            }
        }

        private void GenerarTono(int frequency, int duration)
        {
            try
            {
                using var waveOut = new WaveOutEvent();
                var signal = new SignalGenerator
                {
                    Gain = _volumen,
                    Frequency = frequency,
                    Type = SignalGeneratorType.Sin
                }.Take(TimeSpan.FromMilliseconds(duration));

                waveOut.Init(signal);
                waveOut.Play();
                Thread.Sleep(duration);
            }
            catch (Exception ex)
            {
                BannerManager.MostrarMensajeError($"Error al reproducir sonido: {ex.Message}");
            }
        }
    }

    // --------------------------------------------------------------------------------------------------------------------

}