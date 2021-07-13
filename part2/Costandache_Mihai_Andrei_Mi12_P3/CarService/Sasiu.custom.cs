using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Sasiu.
    /// </summary>
    public partial class Sasiu:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Sasiu"/>.
        /// </summary>
        /// <param name="codSasiu">Cod sasiu.</param>
        /// <param name="denumire">Denumire.</param>
        public Sasiu(string codSasiu,string denumire)
        {
            Autoturisme = new HashSet<Auto>();
            CodSasiu = codSasiu;
            Denumire = denumire;
        }
    }
}
