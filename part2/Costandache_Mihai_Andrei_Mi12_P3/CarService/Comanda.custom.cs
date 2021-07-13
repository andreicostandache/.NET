using System;
using System.Collections.Generic;

namespace CarService
{
    /// <summary>
    /// Entitatea Comanda.
    /// </summary>
    public partial class Comanda:Entitate
    {
        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="Comanda"/>.
        /// </summary>
        /// <param name="stareComanda">Stare comanda - in asteptare, executata, refuzata.</param>
        /// <param name="dataProgramare">Data inceperii executiei.</param>
        /// <param name="dataFinalizare">Data finalizarii.</param>
        /// <param name="kmBord">Km la bord in momentul intrarii masinii in service.</param>
        /// <param name="descriere">Descriere.</param>
        public Comanda(string stareComanda,DateTime dataProgramare,DateTime dataFinalizare,int kmBord,string descriere)
        {
            DetaliiComenzi = new HashSet<DetaliuComanda>();
            StareComanda = stareComanda;
            DataSystem = DateTime.Now;
            DataProgramare = dataProgramare;
            DataFinalizare = dataFinalizare;
            KmBord = kmBord;
            Descriere = descriere;
        }
       
        /// <summary>
        /// Returneaza valoarea cumulata a pieselor.
        /// </summary>
        public decimal ValoarePiese
        {
            get
            {
                decimal nr = 0;
                foreach (var item in DetaliiComenzi)
                    nr += item.Material.Cantitate * item.Material.Pret;
                return decimal.Parse(string.Format("{0:0.##}",nr));
            }
        }
    }
}
