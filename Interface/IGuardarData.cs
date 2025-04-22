namespace Interface
{
    public interface IGuardarDataModoJuego 
    {
         void GuardaModoTradcuccion(string palabra, string morse, string nombreUsuario);
         void GuardaModoAdivinanza();
         void GuardaModoSonido();
         void GuardaModoCarrera();
         void GuardaModoDesafio();
    }

}