using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Operatie.
    /// </summary>
    public partial class Operatie:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Operatie"/>.
        /// </summary>
        /// <param name="denumire">Denumire.</param>
        /// <param name="timpExecutie">Timp executie.</param>
        public Operatie(string denumire,decimal timpExecutie)
        {
            DetaliiComenzi = new HashSet<DetaliuComanda>();
            Denumire = denumire;
            TimpExecutie = timpExecutie;
        }
    }
}
