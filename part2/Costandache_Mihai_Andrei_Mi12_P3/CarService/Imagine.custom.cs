using System;

namespace CarService
{
    /// <summary>
    /// Entitatea Imagine.
    /// </summary>
    public partial class Imagine:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Imagine"/>
        /// </summary>
        public Imagine()
        {

        }
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Imagine"/>.
        /// </summary>
        /// <param name="titlu">Titlu.</param>
        /// <param name="descriere">Descriere.</param>
        /// <param name="data">Data.</param>
        /// <param name="foto">Imaginea ca sir de bytes.</param>
        public Imagine(string titlu,string descriere,DateTime data,byte[] foto)
        {
            Titlu = titlu;
            Descriere = descriere;
            Data = data;
            Foto = foto;
        }
    }
}
