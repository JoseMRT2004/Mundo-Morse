namespace Interface
{
    /// <summary>
    /// Define el contrato para la traducción de texto a código Morse.
    /// </summary>
    public interface ITraducirAMorse
    {
        /// <summary>
        /// Traduce una cadena de texto a código Morse.
        /// </summary>
        /// <param name="entrada">El texto a traducir</param>
        /// <returns>La traducción en código Morse</returns>
        static abstract string TraducirAMorse(string entrada);

        /// <summary>
        /// Traduce código Morse a texto.
        /// </summary>
        /// <param name="morse">El código Morse a traducir</param>
        /// <returns>La traducción en texto</returns>
        static abstract string TraducirDesdeMorse(string morse);
    }
}