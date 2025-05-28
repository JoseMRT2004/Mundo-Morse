namespace Interface
{
    public interface IHacerSonido
    {
        void ConfigurarSonido(int frecuencia, double volumen);
        void ReproducirSonido(string morse);
    }
}