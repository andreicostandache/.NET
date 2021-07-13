using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Auto.
    /// </summary>
    public partial class Auto:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Auto"/>.
        /// </summary>
        /// <param name="numarAuto">Numar autoturism.</param>
        /// <param name="serieSasiu">Serie sasiu.</param>
        public Auto(string numarAuto,string serieSasiu)
        {
            Comenzi = new HashSet<Comanda>();
            NumarAuto = numarAuto;
            SerieSasiu = serieSasiu;
        }
    }
}
