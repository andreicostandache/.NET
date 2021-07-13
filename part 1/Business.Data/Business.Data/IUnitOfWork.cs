namespace Business.Data
{
    interface IUnitOfWork
    {
        CityRepository Cities { get; }

        PoiRepository Pois { get; }

        void Save();
    }
}
