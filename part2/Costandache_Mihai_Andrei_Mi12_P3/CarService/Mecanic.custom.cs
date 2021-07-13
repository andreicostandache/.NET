using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Mecanic.
    /// </summary>
    public partial class Mecanic:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Mecanic"/>.
        /// </summary>
        /// <param name="nume">Nume.</param>
        /// <param name="prenume">Prenume.</param>
        public Mecanic(string nume,string prenume)
        {
            DetaliiComenzi = new HashSet<DetaliuComanda>();
            Nume = nume;
            Prenume = prenume;
        }
    }
}
