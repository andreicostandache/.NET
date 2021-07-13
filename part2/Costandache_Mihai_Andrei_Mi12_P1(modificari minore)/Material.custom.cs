using System;
using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Material.
    /// </summary>
    public partial class Material:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Material"/>.
        /// </summary>
        /// <param name="denumire">Denumire.</param>
        /// <param name="cantitate">Cantitate.</param>
        /// <param name="pret">Pret.</param>
        /// <param name="dataAprovizionare">Data aprovizionare.</param>
        public Material(string denumire,decimal cantitate,decimal pret,DateTime dataAprovizionare)
        {
            DetaliiComenzi = new HashSet<DetaliuComanda>();
            Denumire = denumire;
            Cantitate = cantitate;
            Pret = pret;
            DataAprovizionare = dataAprovizionare;
        }
    }
}
