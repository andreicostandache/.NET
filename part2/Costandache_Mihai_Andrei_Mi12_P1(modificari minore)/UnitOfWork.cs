namespace CarService
{
    /// <summary>
    /// Ofera acces la cate un repository pentru fiecare tip existent si o metoda Save care salveaza modificarile facute in toate repository-urile.
    /// </summary>
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ModelServiceContainer context;
        private GenericRepository<Auto> autoRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<Comanda> comandaRepository;
        private GenericRepository<DetaliuComanda> detaliuComandaRepository;
        private GenericRepository<Imagine> imagineRepository;
        private GenericRepository<Material> materialRepository;
        private GenericRepository<Mecanic> mecanicRepository;
        private GenericRepository<Operatie> operatieRepository;
        private GenericRepository<Sasiu> sasiuRepository;

        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="UnitOfWork"/>.
        /// </summary>
        public UnitOfWork() => context = new ModelServiceContainer();

        /// <summary>
        /// Ofera acces la repository-ul ce contine autoturismele.
        /// </summary>
        public GenericRepository<Auto> AutoRepository => autoRepository ?? (autoRepository = new GenericRepository<Auto>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine clientii.
        /// </summary>
        public GenericRepository<Client> ClientRepository => clientRepository ?? (clientRepository = new GenericRepository<Client>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine comenzile.
        /// </summary>
        public GenericRepository<Comanda> ComandaRepository => comandaRepository ?? (comandaRepository = new GenericRepository<Comanda>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine detaliile comenzilor.
        /// </summary>
        public GenericRepository<DetaliuComanda> DetaliuComandaRepository => detaliuComandaRepository ?? (detaliuComandaRepository = new GenericRepository<DetaliuComanda>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine imaginile.
        /// </summary>
        public GenericRepository<Imagine> ImagineRepository => imagineRepository ?? (imagineRepository = new GenericRepository<Imagine>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine materialele.
        /// </summary>
        public GenericRepository<Material> MaterialRepository => materialRepository ?? (materialRepository = new GenericRepository<Material>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine mecanicii.
        /// </summary>
        public GenericRepository<Mecanic> MecanicRepository => mecanicRepository ?? (mecanicRepository = new GenericRepository<Mecanic>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine operatiile.
        /// </summary>
        public GenericRepository<Operatie> OperatieRepository => operatieRepository ?? (operatieRepository = new GenericRepository<Operatie>(context));

        /// <summary>
        /// Ofera acces la repository-ul ce contine sasiurile.
        /// </summary>
        public GenericRepository<Sasiu> SasiuRepository => sasiuRepository ?? (sasiuRepository = new GenericRepository<Sasiu>(context));

        /// <summary>
        /// Salveaza modificarile.
        /// </summary>
        public void Save() => context.SaveChanges();

        /// <summary>
        /// Metoda din interfata IDisposable.
        /// </summary>
        public void Dispose() => context?.Dispose();
    }
}
