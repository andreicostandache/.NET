using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Client.
    /// </summary>
    public partial class Client:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Client"/>.
        /// </summary>
        /// <param name="nume">Nume.</param>
        /// <param name="prenume">Prenume.</param>
        /// <param name="adresa">Adresa.</param>
        /// <param name="localitate">Localitate.</param>
        /// <param name="judet">Judet.</param>
        /// <param name="telefon">Telefon.</param>
        /// <param name="email">Email.</param>
        public Client(string nume,string prenume,string adresa,string localitate,string judet,string telefon,string email)
        {
            Autoturisme = new HashSet<Auto>();
            Comenzi = new HashSet<Comanda>();
            Nume = nume;
            Prenume = prenume;
            Adresa = adresa;
            Localitate = localitate;
            Judet = judet;
            Telefon = telefon;
            Email = email;
        }
    }
}
