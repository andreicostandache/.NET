using System;

namespace CarService
{
    /// <summary>
    /// Ofera acces la cate un repository pentru fiecare tip existent si o metoda Save care salveaza modificarile facute in toate repository-urile.
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// Ofera acces la repository-ul ce contine autoturismele.
        /// </summary>
        GenericRepository<Auto> AutoRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine clientii.
        /// </summary>
        GenericRepository<Client> ClientRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine comenzile.
        /// </summary>
        GenericRepository<Comanda> ComandaRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine detaliile comenzilor.
        /// </summary>
        GenericRepository<DetaliuComanda> DetaliuComandaRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine imaginile.
        /// </summary>
        GenericRepository<Imagine> ImagineRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine materialele.
        /// </summary>
        GenericRepository<Material> MaterialRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine mecanicii.
        /// </summary>
        GenericRepository<Mecanic> MecanicRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine operatiile.
        /// </summary>
        GenericRepository<Operatie> OperatieRepository { get; }

        /// <summary>
        /// Ofera acces la repository-ul ce contine sasiurile.
        /// </summary>
        GenericRepository<Sasiu> SasiuRepository { get; }

        /// <summary>
        /// Salveaza modificarile.
        /// </summary>
        void Save();
    }
}
